using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
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
    public partial class FrmAdjustmentOfSurplus : UIForm
    {
        int readRfid = 0;

        CommonDataBLL commonDataBLL = new CommonDataBLL();
        public bool isSuccess = false;
        public FrmAdjustmentOfSurplus()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!MachinePublic.ConnectionState || !MachinePublic.WeightState || readRfid == MachinePublic.ReadRfidData)
            {
                return;
            }
            if (MachinePublic.ReadRfidData == -1 || MachinePublic.Weight < 100)
            {
                if (lblINFO.Text != "提示：请将药品放入称重工位")
                {
                    lblINFO.Text = "提示：请将药品放入称重工位";
                }
                return;
            }

            var meDetails = commonDataBLL.GetMedicineCabinetDetail(MachinePublic.ReadRfidData);
            if (meDetails == null)
            {
                if (lblINFO.Text != "提示：该药品未在药柜上架")
                {
                    lblINFO.Text = "提示：该药品未在药柜上架";
                }
                return;
            }
            if (txtKCYL.Text != meDetails.Stock.ToString())
            {
                txtKCYL.Text = meDetails.Stock.ToString();
            }
            if (txtTPQPZL.Text != (MachinePublic.Weight - meDetails.EmptyBottleWeight).ToString())
            {
                txtTPQPZL.Text = (MachinePublic.Weight - meDetails.EmptyBottleWeight).ToString();
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
                if (txtJC.Text != name) { txtJC.Text = name; }
            }

            //调整量计算
            float tzl = (float)MachinePublic.Weight - meDetails.EmptyBottleWeight.Value - meDetails.Stock.Value;
            if (txtTZL.Text != tzl.ToString())
            {
                txtTZL.Text = tzl.ToString();
            }
            readRfid = MachinePublic.ReadRfidData;
        }

        private void FrmAdjustmentOfSurplus_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            MedicineCabinetOperationLogInfo loginfo = new MedicineCabinetOperationLogInfo();
            loginfo.ParticleId = meDetail.RFID.Value;
            loginfo.ParticleCode = parinfo.Code;
            loginfo.ParticleName = parinfo.Name + meDetail.RFID.Value % 10000;
            loginfo.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.余量校准;
            loginfo.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
            loginfo.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
            loginfo.OperationLogDecribe = "药柜颗粒余量校准";
            loginfo.InitialQuantity = meDetail.Stock.Value;
            loginfo.CurrentWeightQuantity = float.Parse(txtTPQPZL.Text);
            loginfo.UsedQuantity = 0;
            loginfo.AddQuantity = 0;
            loginfo.AdjustmentQuantity = float.Parse(txtTZL.Text);

            meDetail.Stock = loginfo.CurrentWeightQuantity;

            MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
            string msg = medicineCabinetDrugManageBLL.AddParticleNum(null, meDetail, loginfo);
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
    }
}
