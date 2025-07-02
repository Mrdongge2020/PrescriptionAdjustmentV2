using AdjustmentSys.BLL.Common;
using AdjustmentSys.Models.Assembiy;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.TCP;
using AdjustmentSysUI.UITool;
using NPOI.SS.UserModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmBoxedDeviceTest : UIPage
    {
        public static bool CheckOpen;
        public static bool SetIp;
        UIRadioButton[] Rb = new UIRadioButton[11];
        UIRadioButton[] Xb = new UIRadioButton[16];
        int lok;
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();

        public FrmBoxedDeviceTest()
        {
      
            InitializeComponent();
            uiGroupBox1.Enabled = false;
            uiGroupBox2.Enabled = false;
            uiRadioButtonGroup2.Enabled = false;
            uiGroupBox3.Enabled = false;
            uiGroupBox4.Enabled = false;

            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cbKLMC.ValueMember = "Id";
            cbKLMC.DisplayMember = "Name";
            cbKLMC.DataSource = pDatas;
            cbKLMC.SelectedIndex = -1;
            ControlOpterUI.SetTitleStyle(this);
        }
        private void FrmBoxedDeviceTest_Load(object sender, EventArgs e)
        {
            Rb[0] = rbtj1;
            Rb[1] = rbtj2;
            Rb[2] = rbtj3;
            Rb[3] = rbtj4;
            Rb[4] = rbtj5;
            Rb[5] = rbtj6;
            Rb[6] = rbtj7;
            Rb[7] = rbtj8;
            Rb[8] = rbtj9;
            Rb[9] = rbtj10;
            Rb[10] = rbtj11;


            Xb[0] = rbSRZT1;
            Xb[1] = rbSRZT2;
            Xb[2] = rbSRZT3;
            Xb[3] = rbSRZT4;
            Xb[4] = rbSRZT5;
            Xb[5] = rbSRZT6;
            Xb[6] = rbSRZT7;
            Xb[7] = rbSRZT8;
            Xb[8] = rbSRZT9;
            Xb[9] = rbSRZT10;
            Xb[10] = rbSRZT11;
            Xb[11] = rbSRZT12;
            Xb[12] = rbSRZT13;
            Xb[13] = rbSRZT14;
            Xb[14] = rbSRZT15;
            Xb[15] = rbSRZT16;
        }

        private void btnydkzhl_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 11; i++)
                {
                    if (!Rb[i].Checked) { continue; }
                    if (i < 8 && !FrmBoxedDevice.deviceMaching.AdjustmentStations[i].HomeExcute)
                    {
                            FrmBoxedDevice.deviceMaching.AdjustmentStations[i].HomeExcute = true;
                            lbInfos.Items.Insert(0, Rb[i].Text + "|设备正在执行回原点...|");
                    }
                    if (i==8 && !FrmBoxedDevice.deviceMaching.Sealbox.HomeExcute) 
                    {
                        FrmBoxedDevice.deviceMaching.Sealbox.HomeExcute = true;
                        lbInfos.Items.Insert(0, Rb[i].Text + "|设备正在执行回原点...|");
                    }
                    if (i == 9 && !FrmBoxedDevice.deviceMaching.Turntable.HomeExcute)
                    {
                        FrmBoxedDevice.deviceMaching.Turntable.HomeExcute = true;
                        lbInfos.Items.Insert(0, Rb[i].Text + "|设备正在执行回原点...|");
                    }
                    if (i == 10 && !FrmBoxedDevice.deviceMaching.Supplyboxs.HomeExcute)
                    {
                        FrmBoxedDevice.deviceMaching.Supplyboxs.HomeExcute = true;
                        lbInfos.Items.Insert(0, Rb[i].Text + "|设备正在执行回原点...|");
                    }
                }
                lbInfos.Items.Insert(0, "请等待回零完成后再操作");

            }
            catch (Exception ex)
            {
                lbInfos.Items.Insert(0, "执行回零异常，原因:" + ex.Message);
            }
        }

        private void btnydkzxr_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < 12; i++)
                {
                    if (Rb[i - 1].Checked)
                    {
                        FrmBoxedDevice.deviceMaching.WDate = (Int16)dudydkz.Value;
                        FrmBoxedDevice.deviceMaching.WDnumber = (short)(i - 1);
                        FrmBoxedDevice.deviceMaching.WExcute = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                lbInfos.Items.Insert(0, "偏移值写入失败,原因:" + ex.Message);
                ex.ToString();
            }
        }

        private void btnTestStart_ActiveChanging(object sender, CancelEventArgs e)
        {
            if (this.btnTestStart.Active)
            {
                timer1.Stop();
                uiGroupBox1.Enabled = false;
                uiGroupBox2.Enabled = false;
                uiRadioButtonGroup2.Enabled = false;
                uiGroupBox3.Enabled = false;
                uiGroupBox4.Enabled = false;
                CheckOpen = false;
                FrmBoxedDevice.deviceMaching.RunState = WorkStateEnum.Write;
                lbInfos.Items.Insert(0, DateTime.Now + "已关闭调试模式");
            }
            else
            {
                if (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
                {
                    if (FrmBoxedDevice.deviceMaching.RunState == WorkStateEnum.Density)
                    {
                        lbInfos.Items.Insert(0, DateTime.Now + "设备正在执行密度测量，无法切换到调试模式");
                        return;
                    }
                    if (FrmBoxedDevice.deviceMaching.PrescriptionInfo== null)
                    {
                        timer1.Start();
                        CheckOpen = true;
                        uiGroupBox1.Enabled = true;
                        uiGroupBox2.Enabled = true;
                        uiRadioButtonGroup2.Enabled = true;
                        uiGroupBox3.Enabled = true;
                        uiGroupBox4.Enabled = true;
                        FrmBoxedDevice.deviceMaching.RunState = WorkStateEnum.Set;
                        dudydkz.Value = FrmBoxedDevice.deviceMaching.AdjustmentStations[0].HomeData;
                        iudDZTSfkmjcw.Value = FrmBoxedDevice.deviceMaching.Sealbox.Data1;
                        iudDZTSfkmfkw.Value = FrmBoxedDevice.deviceMaching.Sealbox.Data2;
                        if (FrmBoxedDevice.deviceMaching.Sealbox.Data3 > 0)
                        {
                            iudDZTStmcd.Value = FrmBoxedDevice.deviceMaching.Sealbox.Data3;
                        }
                        iudDZTSfkys.Value = FrmBoxedDevice.deviceMaching.Sealbox.SealTime;
                        lbInfos.Items.Insert(0, "已开启调试模式");
                    }
                    else
                    {
                        ShowErrorDialog("设备正在调剂,禁止切换至调试模式");
                    }
                }
                else
                {
                    ShowErrorDialog("未连接到设备");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                if (DataProcessingTool.GetBitValue(FrmBoxedDevice.deviceMaching.InX, (i + 1)))
                {
                    Xb[i].Checked = true;

                }
                else
                {
                    Xb[i].Checked = false;
                }
                if (i < 8 && Rb[i].Checked && i != lok)
                {
                    dudydkz.Value = FrmBoxedDevice.deviceMaching.AdjustmentStations[i].HomeData;
                }
                if (i == 8 && Rb[i].Checked && i != lok)
                {
                    dudydkz.Value = FrmBoxedDevice.deviceMaching.Sealbox.HomeData;
                }
                if (i == 9 && Rb[i].Checked && i != lok)
                {
                    dudydkz.Value = FrmBoxedDevice.deviceMaching.Turntable.HomeData;
                }
                if (i == 10 && Rb[i].Checked && i != lok)
                {
                    dudydkz.Value = FrmBoxedDevice.deviceMaching.Supplyboxs.HomeData;
                }
                lok = i;
            }
            if (dudydkz.Value == 0 && FrmBoxedDevice.deviceMaching.AdjustmentStations[0].HomeData != 0)
            {
                dudydkz.Value = FrmBoxedDevice.deviceMaching.AdjustmentStations[0].HomeData;
            }
            if (iudDZTSfkmjcw.Value == 0 && FrmBoxedDevice.deviceMaching.Sealbox.Data1 != 0)
            {
                iudDZTSfkmjcw.Value = FrmBoxedDevice.deviceMaching.Sealbox.Data1;
            }
            if (iudDZTSfkmfkw.Value == 0 && FrmBoxedDevice.deviceMaching.Sealbox.Data2 != 0)
            {
                iudDZTSfkmfkw.Value = FrmBoxedDevice.deviceMaching.Sealbox.Data2;
            }
            if (iudDZTStmcd.Value == 0 && FrmBoxedDevice.deviceMaching.Sealbox.Data3 != 0)
            {
                iudDZTStmcd.Value = FrmBoxedDevice.deviceMaching.Sealbox.Data3;
            }
            if (iudDZTSfkys.Value == 0 && FrmBoxedDevice.deviceMaching.Sealbox.SealTime != 0)
            {
                iudDZTSfkys.Value = FrmBoxedDevice.deviceMaching.Sealbox.SealTime;
            }

            for (int i = 0; i < 11; i++)
            {
                if (i<8 && FrmBoxedDevice.deviceMaching.AdjustmentStations[i].HomeFinsh)
                {
                    FrmBoxedDevice.deviceMaching.AdjustmentStations[i].HomeExcute = false;
                }

                if (i == 8 && FrmBoxedDevice.deviceMaching.Sealbox.HomeFinsh)
                {
                    FrmBoxedDevice.deviceMaching.Sealbox.HomeExcute=false;
                }
                if (i == 9 && FrmBoxedDevice.deviceMaching.Turntable.HomeFinsh)
                {
                    FrmBoxedDevice.deviceMaching.Turntable.HomeExcute = false;
                }
                if (i == 10 && FrmBoxedDevice.deviceMaching.Supplyboxs.HomeFinsh)
                {
                    FrmBoxedDevice.deviceMaching.Supplyboxs.HomeExcute = false;
                }
            }
            if (FrmBoxedDevice.deviceMaching.WFish)
            {
                FrmBoxedDevice.deviceMaching.WExcute = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|数据写入成功|");
            }
            if (FrmBoxedDevice.deviceMaching.Sealbox.Excute && FrmBoxedDevice.deviceMaching.Sealbox.Finsh)
            {
                FrmBoxedDevice.deviceMaching.Sealbox.Excute = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|封口执行完成|");
            }
            if (FrmBoxedDevice.deviceMaching.Outboxs.Excute && FrmBoxedDevice.deviceMaching.Outboxs.Finsh)
            {
                FrmBoxedDevice.deviceMaching.Outboxs.Excute = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|出盒执行完成");
            }
            if (FrmBoxedDevice.deviceMaching.Turntable.Excute && FrmBoxedDevice.deviceMaching.Turntable.Finsh)
            {
                FrmBoxedDevice.deviceMaching.Turntable.Excute = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|转盘位移完成|");
            }
            if (FrmBoxedDevice.deviceMaching.Supplyboxs.Excute && FrmBoxedDevice.deviceMaching.Supplyboxs.Finsh)
            {
                FrmBoxedDevice.deviceMaching.Supplyboxs.Excute = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|供盒完成|");
            }
            if (FrmBoxedDevice.deviceMaching.AdjustmentStations[0]!=null && FrmBoxedDevice.deviceMaching.AdjustmentStations[0].Excute && FrmBoxedDevice.deviceMaching.AdjustmentStations[0].Finsh)
            {
                FrmBoxedDevice.deviceMaching.AdjustmentStations[0].Excute = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|下药完成|");
            }

            if (MachinePublic.WriteRfidFish)
            {
                MachinePublic.WriteRfidExcule = false;
                lbInfos.Items.Insert(0, DateTime.Now + "|" + txtKLBH.Text + "RFID数据写入成功|");

            }
            if (MachinePublic.WriteRfidError)
            {
                MachinePublic.WriteRfidExcule = false;
                MessageBox.Show("|" + txtKLBH.Text + "|写入失败");
                lbInfos.Items.Insert(0, DateTime.Now + "|RFID数据写入失败|");

            }
        }

        private void btnDZTSgh_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.Supplyboxs.Excute = true;
            lbInfos.Items.Insert(0, DateTime.Now + "|下盒操作成功|");
        }

        private void btnDZTSxz_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.ZmoveNumber = 1;
            FrmBoxedDevice.deviceMaching.Turntable.Excute = true;
            lbInfos.Items.Insert(0, DateTime.Now + "|位移操作成功|");
        }

        private void btnDZTSfk_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.Sealbox.Excute = true;
            lbInfos.Items.Insert(0, DateTime.Now + "|封口操作成功|");
        }

        private void btnDZTSch_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.Outboxs.Excute = true;
            lbInfos.Items.Insert(0, DateTime.Now + "|出盒操作成功|");
        }

        private void btnDZTSbfbqdxy_Click(object sender, EventArgs e)
        {
            int d = (int)dudDZTSbfb.Value * 10;

            if (d != 0)
            {
                FrmBoxedDevice.deviceMaching.AdjustmentStations[0].Steper = d;
                FrmBoxedDevice.deviceMaching.AdjustmentStations[0].Excute = true;
            }
            else
            {
                ShowErrorDialog(DateTime.Now + "|设置下药参数异常|");
                dudDZTSbfb.Focus();
            }
        }

        private void btnDZTSfkysxr_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.WDate = (Int16)iudDZTSfkys.Value;
            FrmBoxedDevice.deviceMaching.WDnumber = 14;
            FrmBoxedDevice.deviceMaching.WExcute = true;
        }

        private void btnDZTSfkmjcwxr_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.WDate = (Int16)iudDZTSfkmjcw.Value;
            FrmBoxedDevice.deviceMaching.WDnumber = 11;
            FrmBoxedDevice.deviceMaching.WExcute = true;
        }

        private void btnDZTSfkmfkwxr_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.WDate = (Int16)iudDZTSfkmfkw.Value;
            FrmBoxedDevice.deviceMaching.WDnumber = 12;
            FrmBoxedDevice.deviceMaching.WExcute = true;
        }

        private void btnDZTStmcdxr_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.WDate = (Int16)iudDZTStmcd.Value;
            FrmBoxedDevice.deviceMaching.WDnumber = 13;
            FrmBoxedDevice.deviceMaching.WExcute = true;
        }

        private void btnDZTSsc_Click(object sender, EventArgs e)
        {
            ReverseBit16(ref FrmBoxedDevice.deviceMaching.WoutY, (byte)(cbDZTS.SelectedIndex + 1), true);
        }

        public Int16 ReverseBit16(ref Int16 tag, byte bitIndex, bool trueORFalse)
        {
            Int16 temp = (Int16)(0x01 << (bitIndex - 1));
            if (trueORFalse)
            {
                return (tag |= temp);
            }
            else
            {
                if (((tag >> (bitIndex - 1)) & 0x01) == 1)
                {
                    return (tag &= (byte)(~temp));
                }
                else
                {
                    return tag;
                }
            }
        }

        private void btnDZTSqbqc_Click(object sender, EventArgs e)
        {
            FrmBoxedDevice.deviceMaching.WoutY = 0;
        }

        private void btnKLBHxr_Click(object sender, EventArgs e)
        {
            int ParticlesID = (Convert.ToInt32(txtKLBH.Text));
            MachinePublic.WriteRfidData = ParticlesID;
            MachinePublic.WriteRfidExcule = true;
        }

        private void btnKLMCxr_Click(object sender, EventArgs e)
        {
            try
            {
                int ParticlesID = (int)cbKLMC.SelectedValue;
                if (ParticlesID > 0)
                {
                    MachinePublic.WriteRfidData = ParticlesID;
                    MachinePublic.WriteRfidExcule = true;
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog("颗粒名称写入异常,原因:" + ex.Message);
            }
        }

        private void btnLedOpen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FrmBoxedDevice.D600.Length; i++)
            {
                FrmBoxedDevice.D600[i] = -1;
            }
        }

        private void btnLedClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FrmBoxedDevice.D600.Length; i++)
            {
                FrmBoxedDevice.D600[i] = 0;
            }
            // deviceMaching.WriteLED = true;
            lbInfos.Items.Insert(0, DateTime.Now + "已关闭全部灯光");
        }
    }
}
