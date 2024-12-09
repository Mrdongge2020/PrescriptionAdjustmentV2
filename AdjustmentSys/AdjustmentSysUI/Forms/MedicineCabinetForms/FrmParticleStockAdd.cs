using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.DAL.Drug;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using Microsoft.IdentityModel.Tokens;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmParticleStockAdd : UIForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        MedicineCabinetDetail medicineCabinetDetail = new MedicineCabinetDetail();
        CommonDataBLL commonDataBLL = new CommonDataBLL();
        public bool isSuccess = false;
        ManufacturerRuleResultModel ruleResultModel = null;
        public FrmParticleStockAdd()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            List<ComboxModel> mDatas = _comboxDataBLL.GetManufacturerComboxData();
            cbCJ.ValueMember = "Id";
            cbCJ.DisplayMember = "Name";
            cbCJ.DataSource = mDatas;
            cbCJ.SelectedIndex = -1;
        }

        int readRfid = 0;
        private void timerParticleStockAdd_Tick(object sender, EventArgs e)
        {
            if (!MachinePublic.ConnectionState || !MachinePublic.WeightState || readRfid == MachinePublic.ReadRfidData)
            {
                return;
            }
            if (MachinePublic.ReadRfidData == -1 || MachinePublic.Weight < 100)
            {
                if (!lbErroe.Items.Contains("请将药品放入称重工位"))
                {
                    lbErroe.Items.Add("请将药品放入称重工位");
                }
                return;
            }
            var meDetails = commonDataBLL.GetMedicineCabinetDetail(MachinePublic.ReadRfidData);
            if (meDetails == null)
            {
                if (!lbErroe.Items.Contains("该药品未在药柜上架"))
                {
                    lbErroe.Items.Add("该药品未在药柜上架");
                }
                return;
            }
            if (lblKCYL.Text != meDetails.Stock.ToString())
            {
                lblKCYL.Text = meDetails.Stock.ToString();
            }
            if (lblDQCZ.Text != (MachinePublic.Weight - meDetails.EmptyBottleWeight).ToString())
            {
                lblDQCZ.Text = (MachinePublic.Weight - meDetails.EmptyBottleWeight).ToString();
            }

            //调整量计算
            float syl = float.TryParse(lblSYZL.Text, out float w) ? w : 0;//上药量
            float tzl = (float)MachinePublic.Weight - meDetails.EmptyBottleWeight.Value - syl - meDetails.Stock.Value;
            if (lblTZZL.Text != tzl.ToString())
            {
                lblTZZL.Text = tzl.ToString();
            }
            //获取全部颗粒信息
            var particles = commonDataBLL.GetCommonParticles();
            if (particles == null)
            {
                return;
            }
            string name = particles.FirstOrDefault(x => x.ID == meDetails.ParticlesID)?.Name;
            if (!string.IsNullOrEmpty(name))
            {
                name = name + (int)MachinePublic.ReadRfidData % 10000;
                if (lblParticleName.Text != name) { lblParticleName.Text = name; }
            }
            readRfid = MachinePublic.ReadRfidData;
        }

        private void FrmParticleStockAdd_Load(object sender, EventArgs e)
        {
            //medicineCabinetDetail.CabinetID = ConfigTB.CabinetID;
            medicineCabinetDetail.ParticlesID = 0;
            timerParticleStockAdd.Start();
            this.txtBZTM.Focus();
            lbErroe.Items.Insert(0, DateTime.Now + "|请将药品放入称重工位|");
        }

        private void btnSBTM_Click(object sender, EventArgs e)
        {
            ruleResultModel = null;
            string code = txtBZTM.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                ShowWarningDialog("异常提示", "请扫描颗粒条码");
                this.txtBZTM.Focus();
                return;
            }
            int mid = cbCJ.SelectedValue == null ? 0 : (int)cbCJ.SelectedValue;
            //获取厂家信息
            var mcodes = commonDataBLL.GetManufacturerCodes(mid);
            if (mcodes == null || mcodes.Count <= 0)
            {
                ShowWarningDialog("异常提示", "无可用的厂家条码信息");
                return;
            }
            mcodes = mcodes.Where(x => x.ExampleCode.Length == code.Length).ToList();
            if (mcodes == null || mcodes.Count <= 0)
            {
                ShowWarningDialog("异常提示", "未找到相匹配的厂家条码信息");
                return;
            }
            //获取全部颗粒信息
            var particles = commonDataBLL.GetCommonParticles();
            if (particles == null || particles.Count <= 0)
            {
                ShowWarningDialog("异常提示", "无可用药品字典信息");
                return;
            }
            ParticlesInfo particlesInfo = null;
            for (int i = 0; i < mcodes.Count; i++)
            {
                //解析
                var ruler = GetAnalysisResult(mcodes[i], code);
                if (ruler == null)
                {
                    continue;
                }
                var currentPartic = particles.Where(x => x.PackageNumber == ruler.PackageNumber).ToList();
                if (currentPartic != null && currentPartic.Count == 1)
                {
                    //找到颗粒，赋值
                    particlesInfo = currentPartic[0];
                    lblSYZL.Text = ruler.LoadCapacity.ToString();
                    lblBatch.Text = ruler.BatchNumber;
                    if (!string.IsNullOrEmpty(ruler.VaildUntil) && DateTime.TryParse(ruler.VaildUntil, out DateTime t))
                    {
                        dtpDQRQ.Value = t;
                    }
                    lblBatch.Text = ruler.BatchNumber;
                    cbCJ.SelectedValue = particlesInfo.ManufacturerId;

                    ruleResultModel = ruler;
                    break;
                }
            }

            if (particlesInfo == null)
            {
                ShowWarningDialog("异常提示", "未找到相关颗粒信息");
                return;
            }

            var meParticles = commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            if (meParticles == null || meParticles.Count <= 0)
            {
                ShowWarningDialog("异常提示", "无可用药柜药品信息");
                return;
            }
            //meParticles = meParticles.Where(x => x.ParticlesID == particlesInfo.ID).ToList();
            //if (meParticles == null || meParticles.Count <= 0)
            //{
            //    ShowWarningDialog("异常提示", "该药品未在药柜上架");
            //    return;
            //}
            int rfid = MachinePublic.ReadRfidData;
            var cumeParticles = meParticles.FirstOrDefault(x => x.RFID == rfid);
            if (cumeParticles == null)
            {
                ShowWarningDialog("异常提示", "包装条码药品与称重药品不一致");
                return;
            }

            btnOK.Enabled = true;
        }


        /// <summary>
        /// 获取解析结果
        /// </summary>
        /// <param name="code">编码规则</param>
        /// <returns></returns>
        private ManufacturerRuleResultModel GetAnalysisResult(ManufacturerResolutionCode code, string codeStr)
        {
            DrugManufacturerBLL drugManufacturerBLL = new DrugManufacturerBLL();
            ManufacturerRuleResultModel resultModel = new ManufacturerRuleResultModel();

            resultModel.PackageNumber = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Packaging, codeStr, code.LargePackagingCodeIndex, code.LargePackagingCodeLength);
            resultModel.PackageType = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.PackagingType, codeStr, (int)code.PackagingTypeIndex, (int)code.PackagingTypeLength);
            resultModel.BatchNumber = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.BatchNumber, codeStr, (int)code.BatchNumberIndex, (int)code.BatchNumberLength);
            resultModel.VaildUntil = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.VaildUntil, codeStr, (int)code.ValidityPeriodIndex, (int)code.ValidityPeriodLength);
            resultModel.Density = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Density, codeStr, code.DensityIndex, code.DensityLength));
            resultModel.Equivalent = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Equivalent, codeStr, (int)code.EquivalentIndex, (int)code.EquivalentLength));
            resultModel.LoadCapacity = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.LoadingCapacity, codeStr, (int)code.LoadingCapacityIndex, (int)code.LoadingCapacityLength));
            return resultModel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //药柜颗粒信息
            var meDetail = commonDataBLL.GetMedicineCabinetDetail(MachinePublic.ReadRfidData);
            if (meDetail == null)
            {
                ShowWarningDialog("异常提示", "药柜颗粒信息不存在");
                return;
            }
            // MedicineCabinetDetail medicineCabinetDetail= new MedicineCabinetDetail();
            //meDetail.RFID = readRfid;
            meDetail.BatchNumber = lblBatch.Text;
            meDetail.CurentAdjustAmount = float.Parse(lblTZZL.Text);


            if (!string.IsNullOrEmpty(meDetail.BatchNumber) && meDetail.BatchNumber != lblBatch.Text)
            {
                if (!ShowAskDialog("批号提示", "当前药品批号与药柜批号记录不一致，是否更新药柜批号记录后继续上药？", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
                {
                    return;
                }
                meDetail.BatchNumber = lblBatch.Text;
            }
            if (dtpDQRQ.Value != default && dtpDQRQ.Value < meDetail.ValidityTime)
            {
                meDetail.ValidityTime = dtpDQRQ.Value;
            }
            string addNumStr = lblSYZL.Text;
            float addNum = float.TryParse(addNumStr, out float a) ? a : 0;
            if (addNum == 0)
            {
                ShowWarningDialog("异常提示", "上药重量不能为0");
                return;
            }
            meDetail.Stock = meDetail.Stock.Value + addNum;

            //获取全部颗粒信息
            var particles = commonDataBLL.GetCommonParticles();
            if (particles == null || particles.Count <= 0)
            {
                ShowWarningDialog("异常提示", "药品字典信息不存在");
                return;
            }

            var parinfo = particles.FirstOrDefault(x => x.ID == meDetail.ParticlesID);
            if (parinfo == null)
            {
                ShowWarningDialog("异常提示", "该药品字典信息不存在");
                return;
            }
            if (ruleResultModel == null)
            {
                ShowWarningDialog("异常提示", "请识别包装条码");
                return;
            }

            if (ruleResultModel.PackageNumber != parinfo.PackageNumber)
            {
                ShowWarningDialog("异常提示", "包装码与实际上药药品不一致");
                return;
            }
            if (ruleResultModel.Density != parinfo.Density)
            {
                if (!ShowAskDialog("密度提示", "当前药品包装密度与药品字典记录不一致，是否更新字典密度后继续上药？", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
                {
                    return;
                }

                var densityCoefficient = (parinfo.Density * parinfo.DensityCoefficient * meDetail.DensityCoefficient) / (ruleResultModel.Density * parinfo.DensityCoefficient);
                parinfo.Density = ruleResultModel.Density;
                meDetail.DensityCoefficient = densityCoefficient;
            }

            MedicineCabinetOperationLogInfo loginfo = new MedicineCabinetOperationLogInfo();
            loginfo.ParticleId = meDetail.RFID.Value;
            loginfo.ParticleCode = parinfo.Code;
            loginfo.ParticleName = parinfo.Name + meDetail.RFID.Value % 10000;
            loginfo.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.添加药品;
            loginfo.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
            loginfo.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
            loginfo.OperationLogDecribe = "药柜颗粒正常上药";
            loginfo.InitialQuantity = float.Parse(lblKCYL.Text);
            loginfo.CurrentWeightQuantity = float.Parse(lblDQCZ.Text);
            loginfo.UsedQuantity = 0;
            loginfo.AddQuantity = float.Parse(lblSYZL.Text);
            loginfo.AdjustmentQuantity = float.Parse(lblTZZL.Text);

            MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
            string msg = medicineCabinetDrugManageBLL.AddParticleNum(parinfo, meDetail, loginfo);
            if (msg == "")
            {
                isSuccess = true;
                this.Close();
            }
            else
            {
                ShowErrorDialog("错误提示", msg);
            }

        }

        private void CheckData()
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmParticleStockAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerParticleStockAdd.Stop();
        }
    }
}
