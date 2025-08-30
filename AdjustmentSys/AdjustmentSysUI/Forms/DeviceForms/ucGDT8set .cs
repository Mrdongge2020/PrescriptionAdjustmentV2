using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Sunny.UI;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms.DeviceForms;
using AdjustmentSys.Models.PublicModel;
using Microsoft.IdentityModel.Logging;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Models.User;
using AdjustmentSys.BLL.Common;
using AdjustmentSys.Models.CommModel;
using AdjustmentSysUI.UITool;


namespace YD
{
    public partial class ucGDT8set : UIPage
    {
        public static bool CheckOpen;
        public static bool SetIp;
        RadioButton[] Rb = new RadioButton[11];
        RadioButton[] Xb = new RadioButton[16];
        int c;

        public ucGDT8set()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4S.Enabled = false;
            groupBox4.Enabled = false;

            ControlOpterUI.SetTitleStyle(this);
        }

        private void ucGDT8set_Load(object sender, EventArgs e)
        {
            ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            comboBox5xz.ValueMember = "Id";
            comboBox5xz.DisplayMember = "Name";
            comboBox5xz.DataSource = pDatas;
            comboBox5xz.SelectedIndex = -1;

            Rb[1] = radioButton1;
            Rb[2] = radioButton2;
            Rb[3] = radioButton3;
            Rb[4] = radioButton4;
            Rb[5] = radioButton5;
            Rb[6] = radioButton6;
            Rb[7] = radioButton7;
            Rb[8] = radioButton8;
            Rb[9] = radioButton9;
            Rb[10] = radioButton10;


            Xb[0] = radioButton26x;
            Xb[1] = radioButton25x;
            Xb[2] = radioButton24x;
            Xb[3] = radioButton23x;
            Xb[4] = radioButton22x;
            Xb[5] = radioButton20x;
            Xb[6] = radioButton21x;
            Xb[7] = radioButton19x;
            Xb[8] = radioButton18x;
            Xb[9] = radioButton17x;
            Xb[10] = radioButton16x;
            Xb[11] = radioButton15x;
            Xb[12] = radioButton14x;
            Xb[13] = radioButton13x;
            Xb[14] = radioButton12x;
            Xb[15] = radioButton11x;

            comboBox1D.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            radioButton3.Checked = true;
            //    numericUpDown2.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "SealT"));//封口温度
            numericUpDownGT3.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "SealYtime", "1500"));//封口时间
            numericUpDown2.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "SealPosation1", "103"));//夹袋位置
            numericUpDown5D.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "SealPosation2", "103"));//封袋位置
            numericUpDownDT4.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "SealPosation3", "122"));//封袋位置

            numericUpDownGT6.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "MakePosation1", "132"));//制袋长度
            numericUpDownGT7.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "MakePosation2", "30"));//退膜长度
            checkBoxDT1.Checked = Convert.ToBoolean(IniFileHelper.ReadIniData("PlcHome", "LED", "1").ToString().Trim() == "1" ? true : false);//灯柜亮灯颜色
            numericUpDown1GT8.Value = MachinePublic.Outboxunber;
            if (AdjustmentSys.DAL.Common.ConfigTB.IsShowTemperature)
            {
                //string tvalue= IniFileHelper.ReadIniData("appSettings", "SetTemperature1");
                //if (!string.IsNullOrEmpty(tvalue) && double.TryParse(tvalue,out double v1)) 
                //{
                //    nudWD1.Value = (decimal)v1;
                //}
                //tvalue = IniFileHelper.ReadIniData("appSettings", "SetTemperature2");
                //if (!string.IsNullOrEmpty(tvalue) && double.TryParse(tvalue, out double v2))
                //{
                //    nudWD2.Value = (decimal)v2;
                //}
                //tvalue = IniFileHelper.ReadIniData("appSettings", "SetTemperature3");
                //if (!string.IsNullOrEmpty(tvalue) && double.TryParse(tvalue, out double v3))
                //{
                //    nudWD3.Value = (decimal)v3;
                //}
                nudWD1.Value = (decimal)MachinePublic.SetTemperature1;
                nudWD2.Value = (decimal)MachinePublic.SetTemperature2;
                nudWD3.Value = (decimal)MachinePublic.SetTemperature3;
                this.groupBox5.Visible = true;
            }
            else
            {
                this.groupBox5.Visible = false;
            }

            //   textBox_IP.Text = IniFileHelper.ReadIniData("PlcIp", "PlcIp");//ip
            //  textBoxS3.Text = IniFileHelper.ReadIniData("PlcIp", "Plcmask");//子网掩码
            //  textBoxS4.Text = IniFileHelper.ReadIniData("PlcIp", "PlcGateway");//默认网关

        }
        public static Int16 ByteCheck16(byte[] B400, byte Code1)
        {
            if (B400.Length > Code1 + 3)
            {
                return (Int16)((B400[Code1] << 8) + (B400[Code1 + 1]));
            }
            {
                MessageBox.Show("EORRE1");
                return -1;

            }
        }
        private void comboBox5xz_TextUpdate(object sender, EventArgs e)
        {
            //Form1_Mian.DictionaryPrescriptionGrain.DataDic(comboBox5xz);
            Cursor = Cursors.Default;//保持鼠标指针原来状态，有时候鼠标指针会被下拉筐覆盖，所以要进行一次设置。
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH1", "-800"));//1#回零值
                                                                                                          // numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV9")) / 8400) * 60;//1#回零速度
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH2", "-17600"));//1#回零值
                                                                                                            //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV9")) / 8400) * 60;//1#回零速度
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH3", "-1400"));//1#回零值
                                                                                                           //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV7")) / 8400) * 60;//1#回零速度
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH4", "-1570"));//1#回零值
                                                                                                           //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV7")) / 8400) * 60;//1#回零速度
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH5", "-1800"));//1#回零值
                                                                                                           //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV7")) / 8400) * 60;//1#回零速度
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH6", "-1700"));//1#回零值
                                                                                                           //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV7")) / 8400) * 60;//1#回零速度
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH7", "-1680"));//1#回零值
                                                                                                           //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV7")) / 8400) * 60;//1#回零速度
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH8", "-1550"));//1#回零值
                                                                                                           //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV7")) / 8400) * 60;//1#回零速度
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH9", "-1470"));//1#回零值
                                                                                                           //   numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV8")) / 8400) * 60;//1#回零速度
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {


            numericUpDownGT1.Value = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CH10", "-1450"));//1#回零值
                                                                                                            //  numericUpDown4.Value = (int)(Convert.ToDouble(IniFileHelper.ReadIniData("PlcHome", "CHV9")) / 8400) * 60;//1#回零速度
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < 11; i++)
                {
                    if (Rb[i].Checked)
                    {

                        int d = i;

                        string St = "CH" + d.ToString();
                        IniFileHelper.ReadIniData("PlcHome", St, numericUpDownGT1.Value.ToString());
                        FrmBagDevice.CH[i] = (Int16)numericUpDownGT1.Value;
                        lbCurrInfoset8.Items.Insert(0, "偏移值写入成功");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                lbCurrInfoset8.Items.Insert(0, "偏移值写入失败");
                ex.ToString();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    for (int i = 1; i < 11; i++)
                    {
                        if (Rb[i].Checked && !FrmBagDevice.ObjMachine.TAxisHomeExcute[i - 1])
                        {

                            FrmBagDevice.ObjMachine.TAxisHomeExcute[i - 1] = true;
                            lbCurrInfoset8.Items.Insert(0, i + "|设备正在执行回原点...|");
                            return;
                        }


                    }
                    lbCurrInfoset8.Items.Insert(0, "请等待回零完成后再操作");

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }


            }





        }
        private bool CheckAdd(DataGridView dataGridView1, DataGridViewRow Result)
        {
            for (c = 0; c < dataGridView1.RowCount; c++)
            {
                if (Result.Cells[0].Value != null)
                {
                    if (dataGridView1.Rows[c].Cells[0].Value == Result.Cells[0].Value)
                    {
                        return false;

                    }
                }
            }

            return true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            MonterEorr(FrmBagDevice.ObjMachine);


            for (int i = 0; i < 16; i++)
            {
                if (FrmBagDevice.GetBitValue(ByteCheck16(FrmBagDevice.B400, 13), (i + 1)))
                {
                    Xb[i].Checked = true;
                }
                else
                {
                    Xb[i].Checked = false;
                }


            }
            for (int i = 0; i < 10; i++)
            {
                if (FrmBagDevice.ObjMachine.TAxisHomefinish[i])
                {
                    FrmBagDevice.ObjMachine.TAxisHomeExcute[i] = false;

                }
            }
            if (FrmBagDevice.GetBitValue(ByteCheck16(FrmBagDevice.B400, 11), 11))
            {
                FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 6, false);
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|" + textBox1.Text + "RFID数据写入成功|");

            }
            if (FrmBagDevice.GetBitValue(ByteCheck16(FrmBagDevice.B400, 11), 12))
            {
                FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 6, false);
                MessageBox.Show("|" + textBox1.Text + "|写入失败");
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|RFID数据写入失败|");

            }
            if (FrmBagDevice.GetBitValue(ByteCheck16(FrmBagDevice.B400, 11), 13))
            {
                FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 5, false);
            }
            if (MachinePublic.WriteRFIDFish)
            {
                MachinePublic.WriteRFIDExcule = false;
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|数据写入成功|");
            }
            if (MachinePublic.WriteRFIDEorr)
            {
                MachinePublic.WriteRFIDExcule = false;
                MessageBox.Show("|写入失败|");
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|数据写入失败|");
            }
        }

        private void btnOpenDubugMode_Click(object sender, EventArgs e)
        {
            if (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
            {

                if (FrmBagDevice.ObjMachine.Runstate == Machine.Workstate.Density)
                {
                    lbCurrInfoset8.Items.Insert(0, DateTime.Now + "设备正在执行密度测量，无法切换到调试模式");
                    return;
                }
                if (FrmBagDevice.ObjMachine.PrescriptionID == null)
                {

                    if (timer1.Enabled)
                    {
                        FrmBagDevice.D200[29] = 0;
                        timer1.Stop();
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                        groupBox3.Enabled = false;
                        groupBox4S.Enabled = false;
                        groupBox4.Enabled = false;
                        CheckOpen = false;
                        FrmBagDevice.ObjMachine.Runstate = Machine.Workstate.Write;
                        lbCurrInfoset8.Items.Insert(0, DateTime.Now + "已关闭调试模式");
                    }
                    else
                    {
                        FrmBagDevice.D200[29] = 1;
                        timer1.Start();
                        CheckOpen = true;
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        groupBox3.Enabled = true;
                        groupBox4S.Enabled = true;
                        groupBox4.Enabled = true;
                        FrmBagDevice.ObjMachine.Runstate = Machine.Workstate.Set;
                        lbCurrInfoset8.Items.Insert(0, "已开启调试模式");
                    }
                }

                else
                {

                    MessageBox.Show("设备正在调剂， 禁止切换至调试模式");
                }
            }

            else
            {
                MessageBox.Show("未连接到设备");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "SealT", numericUpDown2.Value.ToString());
            //  if (   DriveG.jxModbusSlaveTp.SetSealTemperatrue(3, (int)numericUpDown2.Value)==mbError.None)
            {

                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封口温度设置成功|");

            }
            //   else
            {
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封口温度设置失败|");

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            {
                OperateLog.WriteLog(LogTypeEnum.用户操作, "PlcHome[SealYtime]=" + numericUpDownGT3.Value.ToString());
                MachinePublic.SealYTime = (Int16)numericUpDownGT3.Value;
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封口时间设置成功|");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBagDevice.ObjMachine.Mbox = true;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|制袋操作成功|");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBagDevice.ObjMachine.Seal = true;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封口出袋操作成功|");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FrmBagDevice.ObjMachine.Zmovenuber = 1;
            FrmBagDevice.ObjMachine.Zmove = true;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|位移操作成功|");
        }

        private void button9_Click(object sender, EventArgs e)
        {

            MachinePublic.WriteRFIDdate = (Convert.ToInt32(textBox1.Text));
            MachinePublic.WriteRFIDExcule = true;

        }


        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox5xz.SelectedValue != null)
                {
                    int ParticlesID = (int)comboBox5xz.SelectedValue;//(int)ParticlesDictionaries.GetParticlesParamname(comboBox5xz.Text, DAL.ParticlesDictionaries.ParticlesParam.ParticlesID);
                    if (ParticlesID != 0)
                    {
                        MachinePublic.WriteRFIDdate = ParticlesID;
                        MachinePublic.WriteRFIDExcule = true;
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        private void ErrorUpdate(DataGridViewRow Row)
        {
            try
            {
                if (Row != null && Row.Cells.Count >= 3)
                {
                    OperateLog.WriteLog(LogTypeEnum.用户操作, SysLoginUser._currentUser.UserName + "复位错误：" + Row.Cells[1].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                OperateLog.WriteLog(LogTypeEnum.系统异常, SysLoginUser._currentUser.UserName + "复位错误异常，原因:" + ex.Message);
                MessageBox.Show("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:1068.3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MonterEorr(Machine ObjUserMachine)
        {
            dataGridViewGT1.DataSource = MachinePublic.DataTableEorr;

            if (dataGridViewGT1.ColumnCount < 3)
            {
                DataGridViewButtonColumn DGb = new DataGridViewButtonColumn();
                DGb.DefaultCellStyle.NullValue = "复位";
                DGb.HeaderText = "异常处理";
                dataGridViewGT1.Columns.Add(DGb);
                dataGridViewGT1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex != -1)
            {
                ErrorUpdate(dataGridViewGT1.Rows[e.RowIndex]);
                string buttonText = dataGridViewGT1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();

                if (buttonText == "复位")
                {

                    string aid = dataGridViewGT1.Rows[e.RowIndex].Cells[0].Value.ToString();

                    switch (aid)
                    {
                        case "|制袋工位已有袋|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 5, true);
                            break;

                        case "|制袋袋膜打开失败|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 6, true);
                            break;
                        case "|制袋封边失败|":

                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 7, true);
                            break;
                        case "|制袋封底失败|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 8, true);
                            break;
                        case "|制袋失败|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 9, true);
                            break;

                        case "|封袋时未检测到袋子|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 10, true);
                            break;

                        case "|封袋时打开袋膜失败|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 11, true);
                            break;
                        case "|封袋时取袋失败|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 12, true);
                            break;
                        case "|封袋失败|":
                            FrmBagDevice.ReverseBit32(ref FrmBagDevice.ObjMachine.iRestError, 13, true);
                            break;



                    }
                }
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            int c = comboBox1D.SelectedIndex + 1;
            int d = (int)numericUpDown1DTB.Value * 10;


            if (c != 0 && d != 0)
            {
                FrmBagDevice.ObjMachine.ParticlesStation[c].Steper = d;
                FrmBagDevice.ObjMachine.ParticlesStation[c].StartDeruge = true;

            }
            else
            {
                MessageBox.Show(DateTime.Now + "|设置下药参数异常|");
            }

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //(short)comboBox3.SelectedIndex
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[27], (byte)(comboBox3.SelectedIndex + 1), true);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FrmBagDevice.D200[27] = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "SealPosation1", numericUpDown2.Value.ToString());
            FrmBagDevice.SealPosation1 = (Int16)numericUpDown2.Value;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋夹膜位置设置成功|");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "SealPosation2", numericUpDown5D.Value.ToString());
            FrmBagDevice.SealPosation2 = (Int16)numericUpDown5D.Value;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋封口位置设置成功|");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "SealPosation3", numericUpDownDT4.Value.ToString());
            FrmBagDevice.SealPosation3 = (Int16)numericUpDownDT4.Value;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋出袋位置设置成功|");
        }
        private void button14_Click(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "MakePosation1", (numericUpDownGT6.Value).ToString());
            FrmBagDevice.MakePosation1 = (Int16)numericUpDownGT6.Value;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|制袋长度设置成功|");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "MakePosation2", (numericUpDownGT7.Value).ToString());
            FrmBagDevice.MakePosation2 = (Int16)numericUpDownGT7.Value;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|制袋退膜长度设置成功|");
        }





        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 1, true);



        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 5, true);
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 1, false);
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {

            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 2, true);
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 5, true);
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 2, false);
        }

        private void button17_MouseDown(object sender, MouseEventArgs e)
        {

            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 3, true);
        }

        private void button17_MouseUp(object sender, MouseEventArgs e)
        {
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 5, true);
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 3, false);
        }

        private void button18_MouseDown(object sender, MouseEventArgs e)
        {

            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 4, true);
        }

        private void button18_MouseUp(object sender, MouseEventArgs e)
        {
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 5, true);
            FrmBagDevice.ReverseBit16(ref FrmBagDevice.D200[30], 4, false);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            DialogResult objDialogResult = MessageBox.Show("是否设置当前位置为夹膜位?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (objDialogResult == DialogResult.Yes)
            {
                numericUpDown2.Value = ByteCheck16(FrmBagDevice.B400, 38 * 2 + 9);
                IniFileHelper.WriteIniData("PlcHome", "SealPosation1", numericUpDown2.Value.ToString());
                FrmBagDevice.SealPosation1 = (Int16)numericUpDown2.Value;
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋夹膜位置设置成功|");
            }
            else
            {
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋夹膜位置设置已取消|");
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            DialogResult objDialogResult = MessageBox.Show("是否设置当前位置为封口位?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (objDialogResult == DialogResult.Yes)
            {
                int DD = ByteCheck16(FrmBagDevice.B400, 38 * 2 + 9);
                numericUpDown5D.Value = ByteCheck16(FrmBagDevice.B400, 38 * 2 + 9);
                FrmBagDevice.SealPosation2 = (Int16)numericUpDown5D.Value;
                IniFileHelper.WriteIniData("PlcHome", "SealPosation2", numericUpDown5D.Value.ToString());

                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋封口位置设置成功|");
            }
            else
            {
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋封口位置设置已取消|");
            }


        }

        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult objDialogResult = MessageBox.Show("是否设置当前位置为出袋位?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (objDialogResult == DialogResult.Yes)
            {
                numericUpDownDT4.Value = ByteCheck16(FrmBagDevice.B400, 38 * 2 + 9);
                IniFileHelper.WriteIniData("PlcHome", "SealPosation3", numericUpDownDT4.Value.ToString());
                FrmBagDevice.SealPosation3 = (Int16)numericUpDownDT4.Value;
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋出袋位置设置成功|");
            }
            else
            {
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|封袋出袋位置设置已取消|");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            for (int i = 0; i < MachinePublic.WD600.Length; i++)
            {
                MachinePublic.WD600[i] = -1;
            }
            int MaxCoordinateX = 48; //灯柜允许最大列
            int Maxnuber = Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.LargeCabinetCount); //大药柜数量
            int NowX = 0;
            if (Maxnuber > 0)
            {
                for (int i = 0; i < Maxnuber; i++)
                {
                    NowX = MachinePublic.WD600[42 + i] + NowX;
                    if (NowX <= MaxCoordinateX)
                    {
                        MachinePublic.WD600[42 + i] = 16;
                    }
                }
            }
            int Minnuber = Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.SmallCabinetCount); //小药柜数量

            if (Minnuber > 0)
            {
                NowX = Maxnuber * 16;
                for (int i = 0; i < Minnuber; i++)
                {
                    {
                        NowX = MachinePublic.WD600[42 + Maxnuber + i] + NowX;
                        if (NowX <= MaxCoordinateX)
                        {
                            MachinePublic.WD600[42 + Maxnuber + i] = 8;
                        }
                    }
                }
            }
            MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            MachinePublic.WD600[50] = 1;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|已关闭全部灯珠|");
        }


        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < MachinePublic.WD600.Length; i++)
            {
                MachinePublic.WD600[i] = 0;
            }
            int MaxCoordinateX = 48; //灯柜允许最大列
            int Maxnuber = Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.LargeCabinetCount); //大药柜数量
            int NowX = 0;
            if (Maxnuber > 0)
            {
                for (int i = 0; i < Maxnuber; i++)
                {
                    NowX = MachinePublic.WD600[42 + i] + NowX;
                    if (NowX <= MaxCoordinateX)
                    {
                        MachinePublic.WD600[42 + i] = 16;
                    }
                }
            }
            int Minnuber = Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.SmallCabinetCount); //小药柜数量

            if (Minnuber > 0)
            {
                NowX = Maxnuber * 16;
                for (int i = 0; i < Minnuber; i++)
                {
                    {
                        NowX = MachinePublic.WD600[42 + Maxnuber + i] + NowX;
                        if (NowX <= MaxCoordinateX)
                        {
                            MachinePublic.WD600[42 + Maxnuber + i] = 8;
                        }
                    }
                }
            }
            MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            MachinePublic.WD600[50] = 1;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|已打开全部灯珠|");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDT1.Checked)
            {
                IniFileHelper.WriteIniData("PlcHome", "LED", "1");
                MachinePublic.LEDgr = true;
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|已将当前设备使用灯珠：设置为红色|");
            }
            else
            {
                IniFileHelper.WriteIniData("PlcHome", "LED", "0");
                MachinePublic.LEDgr = false;
                lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|已将当前设备使用灯珠：设置为绿色|");

            }

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            for (int i = 0; i < MachinePublic.WD600.Length; i++)
            {
                MachinePublic.WD600[i] = 0;
            }


            byte DBit = (byte)((comboBox2.SelectedIndex + 1) % 16);
            if (DBit == 0)
            {
                DBit = 16;
            }
            byte X = (byte)(Math.Ceiling((double)(comboBox2.SelectedIndex + 1) / 16) - 1);
            byte Y = (byte)(Convert.ToByte(comboBox4.SelectedIndex) * 3);
            byte H = (byte)(Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.CabinetRowCount) - comboBox4.SelectedIndex);
            int D = (X + Y);
            if (DBit < 17 && D < 42)
            {
                if (H % 2 == 0)
                {
                    MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << (16 - DBit)));

                }
                else
                {
                    MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << DBit - 1));
                }
            }

            int MaxCoordinateX = 48; //灯柜允许最大列
            int Maxnuber = Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.LargeCabinetCount); //大药柜数量
            int NowX = 0;
            if (Maxnuber > 0)
            {
                for (int i = 0; i < Maxnuber; i++)
                {
                    NowX = MachinePublic.WD600[42 + i] + NowX;
                    if (NowX <= MaxCoordinateX)
                    {
                        MachinePublic.WD600[42 + i] = 16;
                    }
                }
            }
            int Minnuber = Convert.ToInt16(SysDeviceInfo.currentDeviceInfo.SmallCabinetCount); //小药柜数量

            if (Minnuber > 0)
            {
                NowX = Maxnuber * 16;
                for (int i = 0; i < Minnuber; i++)
                {
                    {
                        NowX = MachinePublic.WD600[42 + Maxnuber + i] + NowX;
                        if (NowX <= MaxCoordinateX)
                        {
                            MachinePublic.WD600[42 + Maxnuber + i] = 8;
                        }
                    }
                }
            }
            MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            MachinePublic.WD600[50] = 1;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|已点亮指定灯珠|");
        }

        private void button3GT8_Click(object sender, EventArgs e)
        {
            IniFileHelper.WriteIniData("PlcHome", "Outboxnuber", ((int)numericUpDown1GT8.Value).ToString());
            MachinePublic.Outboxunber = (int)numericUpDown1GT8.Value;
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|设置药筐装袋数量成功|");
        }

        private void btnWD1_Click(object sender, EventArgs e)
        {

            if (nudWD1.Value > 230)
            {
                MessageBox.Show("设定温度不能超过230度。");
                return;
            }
            IniFileHelper.WriteIniData("appSettings", "SetTemperature1", ((int)nudWD1.Value).ToString());
            MachinePublic.SetTemperature1 = (int)nudWD1.Value;
            FrmBagDevice.D200[36] = (Int16)(nudWD1.Value * 10);
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|设置塑封温度值成功|");
        }

        private void btnWD2_Click(object sender, EventArgs e)
        {
            if (nudWD2.Value > 230)
            {
                MessageBox.Show("设定温度不能超过230度。");
                return;
            }
            IniFileHelper.WriteIniData("appSettings", "SetTemperature2", ((int)nudWD2.Value).ToString());
            MachinePublic.SetTemperature2 = (int)nudWD2.Value;
            FrmBagDevice.D200[37] = (Int16)(nudWD2.Value * 10);
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|设置底封温度值成功|");
        }

        private void btnWD3_Click(object sender, EventArgs e)
        {
            if (nudWD3.Value > 230)
            {
                MessageBox.Show("设定温度不能超过230度。");
                return;
            }
            IniFileHelper.WriteIniData("appSettings", "SetTemperature3", ((int)nudWD3.Value).ToString());
            MachinePublic.SetTemperature3 = (int)nudWD3.Value;
            FrmBagDevice.D200[38] = (Int16)(nudWD3.Value * 10);
            lbCurrInfoset8.Items.Insert(0, DateTime.Now + "|设置顶封温度值成功|");
        }


    }

}

