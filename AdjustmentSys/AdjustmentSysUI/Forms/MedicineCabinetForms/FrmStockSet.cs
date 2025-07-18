﻿using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using NPOI.XSSF.Model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmStockSet : UIForm
    {
        int readRfid = 0;

        CommonDataBLL commonDataBLL = new CommonDataBLL();
        public bool isSuccess = false;
        public FrmStockSet()
        {
            InitializeComponent();
        }

        private void FrmStockSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
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
            if (lblDQCZ.Text != (MachinePublic.Weight - meDetails.EmptyBottleWeight).ToString())
            {
                lblDQCZ.Text = (MachinePublic.Weight - meDetails.EmptyBottleWeight).ToString();
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
                if (lblName.Text != name) { lblName.Text = name; }
            }
            readRfid = MachinePublic.ReadRfidData;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var kcStr = txtKCYL.Text;
            float kcNum=float.TryParse(kcStr, out float kcNum1)? kcNum1:-1;
            if (kcNum < 0)
            {
                this.ShowWarningDialog("异常提示", "库存余量数据必须大于0");
                return;
            }
            //药柜颗粒信息
            var meDetail = commonDataBLL.GetMedicineCabinetDetail(MachinePublic.ReadRfidData);
            if (meDetail == null)
            {
                this.ShowWarningDialog("异常提示", "药柜颗粒信息不存在");
                return;
            }
            //获取全部颗粒信息
            var particles = commonDataBLL.GetCommonParticles();
            if (particles == null || particles.Count <= 0)
            {
                this.ShowWarningDialog("异常提示", "药品字典信息不存在");
                return;
            }

            var parinfo = particles.FirstOrDefault(x => x.ID == meDetail.ParticlesID);
            if (parinfo == null)
            {
                this.ShowWarningDialog("异常提示", "该药品字典信息不存在");
                return;
            }
            MedicineCabinetOperationLogInfo loginfo = new MedicineCabinetOperationLogInfo();
            loginfo.ParticleId = meDetail.RFID.Value;
            loginfo.ParticleCode = parinfo.Code;
            loginfo.ParticleName = parinfo.Name + meDetail.RFID.Value % 10000;
            loginfo.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.库存设置;
            loginfo.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
            loginfo.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
            loginfo.OperationLogDecribe = "药柜颗粒库存修改";
            loginfo.InitialQuantity = meDetail.Stock.Value;
            loginfo.CurrentWeightQuantity = float.Parse(lblDQCZ.Text);
            loginfo.UsedQuantity = 0;
            loginfo.AddQuantity =0;
            loginfo.AdjustmentQuantity = meDetail.Stock.Value- kcNum;

            meDetail.Stock = kcNum;
            MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
            string msg = medicineCabinetDrugManageBLL.AddParticleNum(parinfo, meDetail, loginfo);
            if (msg == "")
            {
                isSuccess = true;
                this.Close();
            }
            else
            {
                this.ShowErrorDialog("错误提示", msg);
            }
        }
    }
}
