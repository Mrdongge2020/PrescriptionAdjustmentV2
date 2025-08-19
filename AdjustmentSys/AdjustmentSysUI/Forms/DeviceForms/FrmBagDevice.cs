using AdjustmentSys.DAL.Common;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSys.Tool.TCP;
using AdjustmentSysUI.Forms.UserControlForms;
using AdjustmentSysUI.UITool;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool.Enums;
using AdjustmentSysUI.Forms.MedicineCabinetForms;
using AdjustmentSys.Models.User;
using AdjustmentSysUI.Forms.PrescriptionForms;

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmBagDevice : UIPage
    {
        public FrmBagDevice()
        {
            InitializeComponent();
            ControlOpterUI.SetTitleStyle(this);
        }

        private void FrmBagDevice_Load(object sender, EventArgs e)
        {
            UC_PreFlowList uC_PreFlowList = this.uC_PreFlowList1;
            uC_PreFlowList.AddButton();
        }
        //public  bool CheckSC = false;//判断本机是服务器 还是客户端； 接通为服务器 断开为客户端
        public static Machine ObjMachine = new Machine(); //设备对象
        public Machine SaveMachine = new Machine(); //保存的设备对象
        private PrescriptionProcessingFactory PresHandle = new PrescriptionProcessingFactory(); //当前处理处方
        public DataPrescriptionTB NewPresData = new DataPrescriptionTB(); //加工厂处理后的数据
        public int Oldtemp;
        List<bool> BoxDfstate = new List<bool>();

        List<Station> liststations = new List<Station>();
        List<Model> listmodels = new List<Model>();
        ShowsItem showseal = new ShowsItem();
        ShowsItem showmakebox = new ShowsItem();
        ShowsItem showtem = new ShowsItem();

        List<Machine.DetailM> Listdetail = new List<Machine.DetailM>();
        Statecolorl colorlg = new Statecolorl(); //工位的状态与字体颜色
        Thread Jxssend;
        int c;
        int MouseRows;
        List<string> namefish = new List<string>();
        public string Stoping;
        public string MachineHCState; //运行状态缓存

        public static Int16[] CH = new Int16[12];
        public static int[] CHV = new int[4];

        public static Int16 SealPosation1;//夹袋位置
        public static Int16 SealPosation2;//封袋位置
        public static Int16 SealPosation3;//出袋位置
        public static Int16 MakePosation1;//制袋长度
        public static Int16 MakePosation2;//退袋长度
        long Stationtime = 0; //闪烁
        public static byte[] B400 = new byte[250];
        public static Int16[] D200 = new Int16[40];
        public static Int16[] D600 = new Int16[51];  //0-41 存储状态 42-47 存储每个药柜的的列数  49灯柜颜色，50 开启灯柜

        public SpeechSynthesizer synthesizer = new SpeechSynthesizer();


        string particleName = "";

        public struct Btname
        {
            public string code;
            public string name;
            public int state;

        }

        public Keys dKeys;
        private void DriveG_Load(object sender, EventArgs e)
        {
            //int height = Convert.ToInt32(dgvDeviceError.Font.Height * 1.2);
            //dgvDeviceError.RowTemplate.Height = height;

            TableAdd();

            SetBootParam();
            this.Focus();
            if (backgroundWorker1.IsBusy)
                return;
            backgroundWorker1.RunWorkerAsync();//开启设备监视线程    
        }
        private void TableAdd()
        {
            MachinePublic.DataTableEorr.Clear();
            DataTable table = new DataTable();
            table.Columns.Add("异常原因", typeof(string));
            table.Columns.Add("异常分析", typeof(string));

            MachinePublic.DataTableEorr = table;
            //   dgvDeviceError.DataSource = MachinePublic.DataTableEorr;

            //DataGridViewButtonColumn DGb = new DataGridViewButtonColumn();
            //DGb.DefaultCellStyle.NullValue = "复位";
            //DGb.HeaderText = "异常处理";
            //dgvDeviceError.Columns.Add(DGb);
            //dgvDeviceError.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region //初始值
        private void SetBootParam()
        {
            Station station = new Station();
            station.Text = "无";
            station.Parvalue = 0;
            station.BGColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            for (int i = 0; i < 8; i++)
            {
                liststations.Add(station);

            }
            Model model = new Model();
            model.Text = "1";

            for (int i = 0; i < 16; i++)
            {
                listmodels.Add(model);

            }

            showseal.MText = "封口";
            showseal.Text = "等待封口";

            showmakebox.MText = "制袋";
            showmakebox.Text = "等待制袋";

            showtem.MText = "温度信息";
            showtem.Text = "竖封:180/180\r\n底封:180/180\r\n顶封:180/180\r\n";
            //IniFileHelper.ReadIniData("DeviceInfo", "DeviceID");
            CH[1] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH1"));//出袋补位值
            CH[2] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH2"));//转盘补位值
            CH[3] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH3"));//1#调剂头补位值
            CH[4] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH4"));//2#调剂头补位值
            CH[5] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH5"));//3#调剂头补位值
            CH[6] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH6"));//4#调剂头补位值
            CH[7] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH7"));//5#调剂头补位值
            CH[8] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH8"));//6#调剂头补位值
            CH[9] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH9"));//7#调剂头补位值
            CH[10] = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "CH10"));//8#调剂头补位值

            CHV[1] = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CHV7"));//10#回零值
            CHV[2] = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CHV8"));//10#回零值
            CHV[3] = Convert.ToInt32(IniFileHelper.ReadIniData("PlcHome", "CHV9"));//10#回零值

            SealPosation1 = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "SealPosation1"));//夹袋位置
            SealPosation2 = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "SealPosation2"));//封袋位置
            SealPosation3 = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "SealPosation3"));//封袋位置

            MakePosation1 = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "MakePosation1"));//制袋长度
            MakePosation2 = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "MakePosation2"));//退膜长度
            MachinePublic.LEDgr = Convert.ToBoolean(IniFileHelper.ReadIniData("PlcHome", "LED").ToString().Trim() == "1" ? true : false);//灯柜亮灯颜色
            MachinePublic.Outboxunber = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "Outboxnuber").ToString());//每次出袋的数量
            PresHandle.AdjustAWay = ConfigTB.AdjustWay;
            PresHandle.BoxCellVolume = ConfigTB.BoxCellVolume;
            //PresHandle.CabinetID = ConfigTB.CabinetID;

            PresHandle.DoseLimitDefaultValue = ConfigTB.DoseLimitDefaultValue;
            PresHandle.DoseLimitDown = ConfigTB.DoseLimitDown;
            PresHandle.LidHoleNumber = 2;
            synthesizer.Volume = 100; // 设置音量
            synthesizer.Rate = 2;
            try
            {

                D200 = new Int16[40];

                Jxssend = new Thread(Jxs);
                Jxssend.IsBackground = true;
                Jxssend.Start();

            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(ex.ToString());


            }

            MachinePublic.SealYTime = Convert.ToInt16(IniFileHelper.ReadIniData("PlcHome", "SealYtime"));//封口延时
        }


        public static short[] OrOperation(short[] array1, short[] array2)
        {
            if (array1.Length != array2.Length)
                throw new ArgumentException("Arrays must be of the same length.");

            short[] result = new short[array1.Length];
            byte[] buffer1 = new byte[array1.Length * sizeof(short)];
            byte[] buffer2 = new byte[array2.Length * sizeof(short)];
            byte[] orResult = new byte[buffer1.Length];

            Buffer.BlockCopy(array1, 0, buffer1, 0, buffer1.Length);
            Buffer.BlockCopy(array2, 0, buffer2, 0, buffer2.Length);

            for (int i = 0; i < buffer1.Length; i++)
            {
                orResult[i] = (byte)(buffer1[i] | buffer2[i]);
            }

            Buffer.BlockCopy(orResult, 0, result, 0, orResult.Length);

            return result;
        }
        #endregion
        #region
        bool IsArraysEqual(short[] array1, short[] array2)
        {
            return array1.SequenceEqual(array2);
        }
        private void Jxs()
        {
            try
            {
                ObjMachine = new Machine(); //设备对象
                int Stopnuber = 0;
                while (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
                {

                    if (Stopnuber > 9)
                    {
                        SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                    }
                    MachinePublic.Connectionstate = SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus;
                    if (FrmBagDevice.D600[50] == 0 && MachinePublic.RD600[50] == 1) //读取客户端灯柜数据
                    {
                        // FrmBagDevice.D600 = MachinePublic.RD600;
                        for (int i = 0; i < MachinePublic.WD600.Length; i++)
                        {
                            FrmBagDevice.D600[i] = MachinePublic.RD600[i];
                        }
                    }
                    if (FrmBagDevice.D600[50] == 0 && MachinePublic.WD600[50] == 1) //本机需要写入灯柜数据
                    {
                        for (int i = 0; i < MachinePublic.WD600.Length; i++)
                        {
                            FrmBagDevice.D600[i] = MachinePublic.WD600[i];
                        }
                        // FrmBagDevice.D600= MachinePublic.WD600;
                    }
                    if (FrmMain.CheckSC)
                    {
                        if (FrmBagDevice.D600[50] == 1)
                        {
                            if (!FrmMain.modBusTCP_Cliect.Write_Intall(600, D600))
                            {
                                Stopnuber = Stopnuber + 1;
                                goto a1;
                            }
                            if (IsArraysEqual(FrmBagDevice.D600, MachinePublic.RD600))
                            {
                                MachinePublic.RD600[50] = 0;
                            }
                            if (IsArraysEqual(FrmBagDevice.D600, MachinePublic.WD600))
                            {
                                MachinePublic.WD600[50] = 0;
                            }
                        }
                        if (ObjMachine.WriteLEDfish)
                        {
                            FrmBagDevice.D600[50] = 0;
                            if (!FrmMain.modBusTCP_Cliect.Write_Int16(650, 0))
                            {
                                FrmBagDevice.D600[50] = 1;
                            }
                        }
                    }
                    if (!FrmMain.modBusTCP_Cliect.Write_Intall(200, D200))
                    {
                        Stopnuber = Stopnuber + 1;
                        goto a1;
                    }
                    var D400 = FrmMain.modBusTCP_Cliect.Read_Intall(400, 100);
                    if (D400 != null)
                    {

                        B400 = D400;
                    }
                    else
                    {
                        Stopnuber = Stopnuber + 1;
                        goto a1;
                    }
                    Setplcd();
                    Stopnuber = 0;
                a1: Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {

                this.ShowErrorDialog(ex.ToString());
            }
        }
        public  Int16 ByteCheck16(byte[] B400, byte Code1)
        {
            if (B400.Length > Code1 + 3)
            {
                return (Int16)((B400[Code1] << 8) + (B400[Code1 + 1]));
            }
            {
                this.ShowErrorDialog("EORRE1");
                return -1;

            }
        }
        private int ByteCheck32(byte[] B200, byte Code1)
        {
            try
            {
                if (B200.Length > Code1 + 3)
                {
                    return (B200[Code1] << 8) + (B200[Code1 + 1]) + (B200[Code1 + 2] << 24) + (B200[Code1 + 3] << 16);
                }
                {
                    this.ShowErrorDialog("EORRE1");
                    return -1;
                }
            }
            catch
            {
                this.ShowErrorDialog("EORRE1");
                return -1;
            }
        }
        private int[] RfidByteCheck32(byte[] B200, byte Code1)
        {
            try
            {
                int[] value = new int[9];
                int Pvalue;
                for (int i = 0; i < 9; i++)
                {
                    Pvalue = Code1 + (i * 4);
                    if (B200.Length > Pvalue + 3)
                    {
                        value[i] = (B200[Pvalue] << 8) + B200[Pvalue + 1] + (B200[Pvalue + 2] << 24) + (B200[Pvalue + 3] << 16);
                    }
                }

                return value;

            }
            catch
            {
                this.ShowErrorDialog("EORRE1");
                return null;
            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            backgroundWorker1.WorkerReportsProgress = true;
            Machine myObj = new Machine(); //保存的设备对象
            Readmachine(ref myObj);
            if (myObj.PrescriptionID != null)
            {
                try
                {
                    if (this.ShowAskDialog("之前处方未完成是否恢复？"))
                    {
                        //停止设备当前动作
                        NewPresData = uC_PreFlowList1.prescriptionBinModel.CheckedPreInfos.FirstOrDefault(x => x.PrescriptionID == myObj.PrescriptionID);// Dispensing.PrescriptionDictionary[myObj.PrescriptionID];

                        myObj.Zmove = false;
                        myObj.Mbox = false;
                        myObj.ParticlesStation[1].StartDeruge = false;
                        myObj.ParticlesStation[2].StartDeruge = false;
                        myObj.ParticlesStation[3].StartDeruge = false;
                        myObj.ParticlesStation[4].StartDeruge = false;
                        myObj.ParticlesStation[5].StartDeruge = false;
                        myObj.ParticlesStation[6].StartDeruge = false;
                        myObj.ParticlesStation[7].StartDeruge = false;
                        myObj.ParticlesStation[8].StartDeruge = false;
                        myObj.Seal = false;
                        myObj.Restsate = 0;
                        myObj.Runstate = Machine.Workstate.Rest;
                        ObjMachine = myObj;
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    this.ShowErrorDialog("恢复数据出现异常:|" + ex.ToString() + "|,已取消恢复");
                }

            }
            while (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
            {
                SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                State();
                RFIDstate();

                backgroundWorker1.ReportProgress(0, ObjMachine);
                System.Threading.Thread.Sleep(70);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Machine ObjMachineP = e.UserState as Machine;
            if (ObjMachineP == null) { return; };
            StateDisplay(ObjMachineP);
        }
        private bool Checkstation(Machine.DetailgG Station) //判断颗粒是否全部调剂完成
        {

            for (int d = 1; d < 17; d++)
            {
                if (ObjMachine.BoxST[d] != null)
                {

                    var boxst = ObjMachine.BoxST[d].ParticlesDetail.Where(z => (z.ParticlesCode == Station.ParticlesCode) && (Station.DrugeValue != ObjMachine.BoxCount));

                    if (boxst != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool Checkboxstation(Machine.DetailgG Station) //判断工位颗粒的本次所有药盒颗粒是否调剂完成
        {
            for (int d = 1; d < 17; d++)
            {
                if (ObjMachine.BoxST[d] != null)
                {
                    foreach (Machine.ParticlesDetail rulse in ObjMachine.BoxST[d].ParticlesDetail)//查找出该颗粒
                    {
                        if (Station.ParticlesCode == rulse.ParticlesCode)
                        {
                            if (!rulse.finish)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        private void Setplcd()
        {
            if (B400 == null) { return; }
            D200[1] = (Int16)ObjMachine.ParticlesStation[1].Steper;
            D200[2] = (Int16)ObjMachine.ParticlesStation[2].Steper;
            D200[3] = (Int16)ObjMachine.ParticlesStation[3].Steper;
            D200[4] = (Int16)ObjMachine.ParticlesStation[4].Steper;
            D200[5] = (Int16)ObjMachine.ParticlesStation[5].Steper;
            D200[6] = (Int16)ObjMachine.ParticlesStation[6].Steper;
            D200[7] = (Int16)ObjMachine.ParticlesStation[7].Steper;
            D200[8] = (Int16)ObjMachine.ParticlesStation[8].Steper;
            D200[9] = (Int16)ObjMachine.Zmovenuber;
            D200[35] = MachinePublic.SealYTime;
            ObjMachine.iError = ByteCheck32(B400, 9 + 2 * 36);
            ObjMachine.Homefinish = GetBitValue(ByteCheck16(B400, 9), 1);
            ObjMachine.Zmovefinsh = GetBitValue(ByteCheck16(B400, 9), 2);
            ObjMachine.Mboxfinsh = GetBitValue(ByteCheck16(B400, 9), 3);
            ObjMachine.Sealfinshd = GetBitValue(ByteCheck16(B400, 9), 4);
            ObjMachine.ParticlesStation[1].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 5);
            ObjMachine.ParticlesStation[2].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 6);
            ObjMachine.ParticlesStation[3].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 7);
            ObjMachine.ParticlesStation[4].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 8);
            ObjMachine.ParticlesStation[5].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 9);
            ObjMachine.ParticlesStation[6].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 10);
            ObjMachine.ParticlesStation[7].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 11);
            ObjMachine.ParticlesStation[8].Derugefinish = GetBitValue(ByteCheck16(B400, 9), 12);
            ObjMachine.Sealfinsh = GetBitValue(ByteCheck16(B400, 9), 13);
            ObjMachine.Outboxfinsh = GetBitValue(ByteCheck16(B400, 9), 14);

            ObjMachine.TAxisHomefinish[0] = GetBitValue(ByteCheck16(B400, 11), 1);
            ObjMachine.TAxisHomefinish[1] = GetBitValue(ByteCheck16(B400, 11), 2);
            ObjMachine.TAxisHomefinish[2] = GetBitValue(ByteCheck16(B400, 11), 3);
            ObjMachine.TAxisHomefinish[3] = GetBitValue(ByteCheck16(B400, 11), 4);
            ObjMachine.TAxisHomefinish[4] = GetBitValue(ByteCheck16(B400, 11), 5);
            ObjMachine.TAxisHomefinish[5] = GetBitValue(ByteCheck16(B400, 11), 6);
            ObjMachine.TAxisHomefinish[6] = GetBitValue(ByteCheck16(B400, 11), 7);
            ObjMachine.TAxisHomefinish[7] = GetBitValue(ByteCheck16(B400, 11), 8);
            ObjMachine.TAxisHomefinish[8] = GetBitValue(ByteCheck16(B400, 11), 9);
            ObjMachine.TAxisHomefinish[9] = GetBitValue(ByteCheck16(B400, 11), 10);
            ObjMachine.WriteLEDfish = GetBitValue(ByteCheck16(B400, 11), 14);

            MachinePublic.WriteRFIDFish = GetBitValue(ByteCheck16(B400, 11), 11);
            MachinePublic.WriteRFIDEorr = GetBitValue(ByteCheck16(B400, 11), 12);
            MachinePublic.Weight = Math.Round((double)(ByteCheck32(B400, 32 * 2 + 9)) / 100, 2);
            MachinePublic.WeightState = GetBitValue(ByteCheck16(B400, 30 * 2 + 9), 9);
            ObjMachine.RFID = RfidByteCheck32(B400, 10 * 2 + 9);

            //温度读取
            MachinePublic.ReadTemperature1 = ByteCheck16(B400, 40 * 2 + 9) / 10;
            MachinePublic.ReadTemperature2 = ByteCheck16(B400, 41 * 2 + 9) / 10;
            MachinePublic.ReadTemperature3 = ByteCheck16(B400, 42 * 2 + 9) / 10;
            //MachinePublic.SetTemperature1 = ByteCheck16(B400, 43 * 2 + 9) / 10;
            //MachinePublic.SetTemperature2 = ByteCheck16(B400, 44 * 2 + 9) / 10;
            //MachinePublic.SetTemperature3 = ByteCheck16(B400, 45 * 2 + 9) / 10;

            ReverseBit16(ref D200[0], 1, ObjMachine.HomeExcute);
            ReverseBit16(ref D200[30], 6, MachinePublic.WriteRFIDExcule);
            if (ObjMachine.Runstate != Machine.Workstate.Write && ObjMachine.Runstate != Machine.Workstate.Home)
            {
                ReverseBit16(ref D200[0], 2, ObjMachine.Zmove);
                ReverseBit16(ref D200[0], 3, ObjMachine.Mbox);
                ReverseBit16(ref D200[0], 4, ObjMachine.Seal);
                ReverseBit16(ref D200[0], 5, ObjMachine.ParticlesStation[1].StartDeruge);
                ReverseBit16(ref D200[0], 6, ObjMachine.ParticlesStation[2].StartDeruge);
                ReverseBit16(ref D200[0], 7, ObjMachine.ParticlesStation[3].StartDeruge);
                ReverseBit16(ref D200[0], 8, ObjMachine.ParticlesStation[4].StartDeruge);
                ReverseBit16(ref D200[0], 9, ObjMachine.ParticlesStation[5].StartDeruge);
                ReverseBit16(ref D200[0], 10, ObjMachine.ParticlesStation[6].StartDeruge);
                ReverseBit16(ref D200[0], 11, ObjMachine.ParticlesStation[7].StartDeruge);
                ReverseBit16(ref D200[0], 12, ObjMachine.ParticlesStation[8].StartDeruge);
                ReverseBit16(ref D200[0], 13, ObjMachine.Outbox);

                ReverseBit16(ref D200[0], 14, ObjMachine.ResetSealfinshd);
                ReverseBit16(ref D200[23], 1, ObjMachine.TAxisHomeExcute[0]);
                ReverseBit16(ref D200[23], 2, ObjMachine.TAxisHomeExcute[1]);
                ReverseBit16(ref D200[23], 3, ObjMachine.TAxisHomeExcute[2]);
                ReverseBit16(ref D200[23], 4, ObjMachine.TAxisHomeExcute[3]);
                ReverseBit16(ref D200[23], 5, ObjMachine.TAxisHomeExcute[4]);
                ReverseBit16(ref D200[23], 6, ObjMachine.TAxisHomeExcute[5]);
                ReverseBit16(ref D200[23], 7, ObjMachine.TAxisHomeExcute[6]);
                ReverseBit16(ref D200[23], 8, ObjMachine.TAxisHomeExcute[7]);
                ReverseBit16(ref D200[23], 9, ObjMachine.TAxisHomeExcute[8]);
                ReverseBit16(ref D200[23], 10, ObjMachine.TAxisHomeExcute[9]);
                ReverseBit16(ref D200[23], 11, MachinePublic.ZeroWeight);

            }
            // FrmBagDevice.D200[31] = (short)(ParticlesID >> 16);
            //FrmBagDevice.D200[32] = (short)(ParticlesID & 0XFFFF);
            FrmBagDevice.D200[31] = (short)(MachinePublic.WriteRFIDdate >> 16);
            FrmBagDevice.D200[32] = (short)(MachinePublic.WriteRFIDdate & 0XFFFF);
            // ReverseBit16(ref D200[23], 11, ObjMachine.LEDgr);
            // ReverseBit16(ref D200[23], 12, ObjMachine.WriteLED);
            if (ObjMachine.WriteLEDfish)
            {
                ObjMachine.WriteLED = false;
            }
            D200[10] = CH[3];
            D200[11] = CH[4];
            D200[12] = CH[5];
            D200[13] = CH[6];
            D200[14] = CH[7];
            D200[15] = CH[8];
            D200[16] = CH[9];
            D200[17] = CH[10];
            D200[25] = CH[1];
            D200[24] = CH[2];

            D200[20] = SealPosation1;
            D200[21] = SealPosation2;
            D200[22] = SealPosation3;
            D200[18] = MakePosation1;
            D200[19] = MakePosation2;

        }

        private void RFIDstate()
        {
            if (MachinePublic.Weight < 0.1 && MachinePublic.ZeroWeight)
            {
                MachinePublic.ZeroWeight = false;
            }

            int[] Rfidnumber = new int[9];
            Rfidnumber = ObjMachine.RFID;
            MachinePublic.ReadRFIDdate = Rfidnumber[0];
            if (MachinePublic.UpdateParticles > 0) //刷新数据 没处方时刷新数据
            {

                if (ObjMachine.PrescriptionID == null)
                {
                    MachinePublic.UpdateParticles = 0;
                    ObjMachine.ParticlesStation[0].Rfidnumber = 0;

                }
                else
                {
                    var update_ParticlesDetai = ObjMachine.ParticlesDetailp.Where(d => d.ParticlesName == ObjMachine.ParticlesStation[0].ParticlesName).FirstOrDefault();
                    if (update_ParticlesDetai == null) //处方列表没有该药品
                    {
                        MachinePublic.UpdateParticles = 0;
                        ObjMachine.ParticlesStation[0].Rfidnumber = 0;
                    }
                    else
                    {
                        if (update_ParticlesDetai.state != 5 && update_ParticlesDetai.state != 4)
                        {
                            update_ParticlesDetai.state = 1;
                        }
                    }

                }
            }
            for (int i = 0; i < Rfidnumber.Length; i++) //RFID数据的获取
            {
                if (ObjMachine.ParticlesStation[0].Rfidnumber == 0)
                {
                    MachinePublic.objCabinetStorageInfoTB = null;
                }


                if (Rfidnumber[i] > 0 && Rfidnumber[i] < 900000) //称重工位
                {
                    if (ObjMachine.ParticlesStation[i].Rfidnumber != Rfidnumber[i])
                    {
                        string Pname = null;


                        if (!CheckRfidnumber(Rfidnumber[i], ref Pname)) //查询颗粒名称
                        {
                            if (i > 0)
                            {
                                ObjMachine.ParticlesStation[i].ParticlesName = Pname;
                                ObjMachine.ParticlesStation[i].Rfidnumber = Rfidnumber[i];
                                ObjMachine.ParticlesStation[i].ParticlesCode = Rfidnumber[i].ToString();
                                if (ObjMachine.ParticlesDetailp == null)//没有处方时 调剂工位工位状态
                                {
                                    if (ObjMachine.ParticlesStation[i].ParticlesName != null)   //处方列表没有该药品信息
                                    {
                                        if (ObjMachine.ParticlesStation[i].Particlesstate != 4)
                                        {
                                            ObjMachine.ParticlesStation[i].Particlesstate = 10;
                                        }
                                    }
                                    else
                                    {
                                        ObjMachine.ParticlesStation[i].Particlesstate = 0;
                                    }
                                }
                            }
                            if (i == 0 && MachinePublic.Weight > 200 && MachinePublic.WeightState) //称重工位状态 重量>0 
                            {
                                CabinetStorageInfoTB Cabinetweight = new CabinetStorageInfoTB();
                                ObjMachine.ParticlesStation[0].Rfidnumber = Rfidnumber[0];
                                ObjMachine.ParticlesStation[0].ParticlesCode = Rfidnumber[0].ToString();
                                ObjMachine.ParticlesStation[0].ParticlesName = Pname;
                                qCheckWeight(ObjMachine.ParticlesStation[0]);
                                Cabinetweight = Cabinetweight.GetCabinetStorageInfo(ObjMachine.ParticlesStation[0].Rfidnumber);

                                if (Cabinetweight != null && Cabinetweight.EmptyBottleWeigh < 200)
                                {
                                    Cabinetweight.EmptyBottleWeigh = (float)ConfigTB.EmptyBottleWeight;
                                }
                                if (Cabinetweight != null)
                                {
                                    ObjMachine.ParticlesStation[0].Dweight = Convert.ToSingle(Math.Round(MachinePublic.Weight - Cabinetweight.EmptyBottleWeigh, 1));
                                }
                                else
                                {
                                    ObjMachine.ParticlesStation[0].Dweight = Convert.ToSingle(Math.Round(MachinePublic.Weight - ConfigTB.EmptyBottleWeight, 1));
                                }
                                if (Cabinetweight != null)
                                {
                                    Cabinetweight.ParticlesName = Pname;
                                }
                                MachinePublic.showParticleWeight = ObjMachine.ParticlesStation[0].Dweight;
                                MachinePublic.objCabinetStorageInfoTB = Cabinetweight;
                                ObjMachine.ParticlesStation[0].Particlesstate = 2;

                                if (Cabinetweight != null && ObjMachine.PrescriptionID == null)
                                {
                                    LEDlight(Cabinetweight);
                                }
                                if (!MachinePublic.DensityExcule)
                                {
                                    if (ConfigTB.Autospeak)
                                    {
                                        sndPlaye(Pname, true);
                                    }
                                    else
                                    {
                                        sndPlaye1(Pname, true);
                                    }
                                }
                                if (ObjMachine.PrescriptionID != null && Cabinetweight != null) //判断处方是否有该药瓶 且处于等待称重药品状态
                                {
                                    var m_ParticlesDetai = ObjMachine.ParticlesDetailp.Where(d => d.ParticlesName == ObjMachine.ParticlesStation[0].ParticlesName).FirstOrDefault();
                                    if (m_ParticlesDetai == null) //处方列表没有该药品
                                    {
                                        ObjMachine.ParticlesStation[0].Particlesstate = 10; //处方列表没有该药品
                                                                                            // sndPEe(false);
                                        sndPlaye("非处方药品");
                                        return;
                                    }
                                    if (m_ParticlesDetai.state == 6)//已有该药品称重信息
                                    {
                                        ObjMachine.ParticlesStation[0].Particlesstate = 11; //已有该药品称重信息
                                        sndPEe(false);
                                    }
                                    if (m_ParticlesDetai.state == 5) //待上架
                                    {
                                        // 当前药瓶的库存量 > 两次下药量 * 每次下药重量 + 10
                                        if (Cabinetweight.ParticlesStockQuantity > m_ParticlesDetai.NewDose * 2 + 20 + ConfigTB.ParticlesBottomLineValue && ObjMachine.ParticlesStation[0].Dweight > m_ParticlesDetai.NewDose * 2 + ConfigTB.ParticlesBottomLineValue)
                                        {
                                            m_ParticlesDetai.state = 1;
                                        }
                                    }
                                    if (MachinePublic.UpdateParticles != 0 && m_ParticlesDetai.ParticlesCode == MachinePublic.UpdateParticles.ToString() && (m_ParticlesDetai.state == 2 || m_ParticlesDetai.state == 3 || m_ParticlesDetai.state == 5))
                                    {
                                        m_ParticlesDetai.state = 1;
                                        MachinePublic.UpdateParticles = 0;
                                        return;
                                    }
                                    if (m_ParticlesDetai.state == 1 || m_ParticlesDetai.state == 2)//处方处于待称重状态 //或待上架
                                    {
                                        var Detai = NewPresData.ParticlesDetail.Where(c => c.ParticlesName == ObjMachine.ParticlesStation[0].ParticlesName).FirstOrDefault();
                                        if (Detai == null) { return; }
                                        Detai.CabinetParticles = Cabinetweight;
                                        Detai.CurrentWeight = ObjMachine.ParticlesStation[0].Dweight;
                                        MachinePublic.objCabinetStorageInfoTB = null;
                                        if (!PresHandle.CheckParticlesDetail(ref Detai)) { MachinePublic.objCabinetStorageInfoTB = Detai.CabinetParticles; return; }       //检查颗粒重量数据
                                        MachinePublic.objCabinetStorageInfoTB = Detai.CabinetParticles;
                                        int Steper = 0;
                                        int Steper1 = 0;
                                        if (ObjMachine.Oddsate)
                                        {
                                            Steper = PresHandle.DataHandles(ref Detai, ObjMachine.ParticlesStation[0].Dweight, ObjMachine.BoxCount - 1);//计算本次重量;
                                            float OnyTotalAmountUse = 0;
                                            if (Math.Abs(Detai.CabinetParticles.OnyTotalAmountUse) > 0)
                                            {
                                                OnyTotalAmountUse = (float)Math.Round((Detai.CabinetParticles.OnyTotalAmountUse / (ObjMachine.BoxCount - 1)) / 2, 2);
                                            }
                                            double NewDose = Math.Round(Detai.NewDose + OnyTotalAmountUse, 2);
                                            Detai.CabinetParticles.OnyTotalAmountUse = (float)Math.Round(OnyTotalAmountUse + Detai.CabinetParticles.OnyTotalAmountUse, 2);
                                            Steper1 = PresHandle.OdddataHandles(NewDose, Detai);
                                            if (Steper1 == 0) { return; }
                                            m_ParticlesDetai.Steper1 = Steper1;
                                        }
                                        else
                                        {
                                            Steper = PresHandle.DataHandles(ref Detai, ObjMachine.ParticlesStation[0].Dweight, ObjMachine.BoxCount);
                                        }
                                        if (Steper == 0) { return; }
                                        //判断处方付数*分服次数是否为奇数
                                        m_ParticlesDetai.Steper = Steper;
                                        m_ParticlesDetai.Dweight = ObjMachine.ParticlesStation[0].Dweight;
                                        UpdateBox(m_ParticlesDetai);
                                        m_ParticlesDetai.state = 2;
                                        MachinePublic.UpdateParticles = 0;
                                        sndPlaye("称重完成请放入调剂工位");//  AddTotal(Detai); //误差量记录
                                                                //关闭灯光
                                                                //  CloseLED(new List<Machine.DetailM> { m_ParticlesDetai });
                                        if (ConfigTB.CheckLEDf)
                                        {
                                            CloseLED1(ObjMachine.ParticlesDetailp);
                                        }

                                    }
                                }
                            }

                        }
                    }
                }
                if ((Rfidnumber[i] == -1) && ObjMachine.ParticlesStation[i].Particlesstate != 3 && !ObjMachine.ParticlesStation[i].StartDeruge)
                {
                    Machine.DetailgG DetailgGnull = new Machine.DetailgG();

                    if (ObjMachine.ParticlesStation[i].ParticlesName != null && ObjMachine.ParticlesDetailp != null && i > 0)//取走工位药瓶时 将药瓶设置为已称重状态
                    {
                        var listParticlesDetais = ObjMachine.ParticlesDetailp.Where(d => d.ParticlesName == ObjMachine.ParticlesStation[i].ParticlesName).FirstOrDefault();
                        if (listParticlesDetais != null)
                        {
                            if (listParticlesDetais.state != 1 && listParticlesDetais.state != 0 && listParticlesDetais.state != 5) //已 经称重过的药瓶
                            {
                                if (listParticlesDetais.state != 4)
                                {
                                    listParticlesDetais.state = 2;
                                }
                                listParticlesDetais.DrugeValue = Math.Max(ObjMachine.ParticlesStation[i].DrugeValue, listParticlesDetais.DrugeValue);
                            }
                        }
                    }
                    ObjMachine.ParticlesStation[i] = DetailgGnull;
                }
            }
            if (ObjMachine.PrescriptionID != null && ObjMachine.PrescriptionID == NewPresData.PrescriptionID && ObjMachine.ParticlesDetailp != null) //判断数据是否写入
            {
                for (int i = 1; i < ObjMachine.ParticlesStation.Length; i++)
                {

                    if (ObjMachine.ParticlesStation[i].ParticlesName == null)
                    {
                        continue;
                    }
                    var NolistParticlesDetais = ObjMachine.ParticlesDetailp.Where(d => (d.ParticlesName == ObjMachine.ParticlesStation[i].ParticlesName && ObjMachine.ParticlesStation[i].Particlesstate == 4)).FirstOrDefault();
                    {
                        if (NolistParticlesDetais != null)
                        {
                            if (Checkboxstation(ObjMachine.ParticlesStation[i]) && NolistParticlesDetais.state != 8)
                            {
                                ObjMachine.ParticlesStation[i].Steper = NolistParticlesDetais.Steper;
                                ObjMachine.ParticlesStation[i].Particlesstate = 2; //工位写入待调剂状态
                                ObjMachine.ParticlesStation[i].DrugeValue = NolistParticlesDetais.DrugeValue;
                                NolistParticlesDetais.state = 3; //已放入   
                            }
                        }
                    }
                    var listParticlesDetais = ObjMachine.ParticlesDetailp.Where(d => (d.ParticlesName == ObjMachine.ParticlesStation[i].ParticlesName && ObjMachine.ParticlesStation[i].Particlesstate != 4)).FirstOrDefault();
                    {
                        if (listParticlesDetais == null)
                        {
                            continue;
                        }

                        if (listParticlesDetais.state == 2 && ObjMachine.PrescriptionID != null)
                        {

                            if (Checkstation(ObjMachine.ParticlesStation[i]) && !ObjMachine.ParticlesStation[i].Colkstate) //药盒里是否有该处方药品，该药品是否调剂完成
                            {
                                if (ObjMachine.ParticlesStation[i].Particlesstate != 3)
                                {
                                    ObjMachine.ParticlesStation[i].Steper = listParticlesDetais.Steper;
                                    ObjMachine.ParticlesStation[i].Particlesstate = 2; //工位写入待调剂状态
                                    ObjMachine.ParticlesStation[i].DrugeValue = listParticlesDetais.DrugeValue;
                                    listParticlesDetais.state = 3; //已放入                     
                                    sndPEe(true);
                                }
                            }
                        }
                        if ((listParticlesDetais.state == 1 || ObjMachine.ParticlesStation[i].Particlesstate == 10) && ObjMachine.ParticlesStation[i].Particlesstate != 12)
                        {
                            ObjMachine.ParticlesStation[i].Particlesstate = 12; //该药品未称重
                            sndPEe(false);
                        }
                        if (listParticlesDetais.state == 0 && ObjMachine.ParticlesStation[i].Particlesstate != 4 && ObjMachine.ParticlesStation[i].Particlesstate != 10)
                        {
                            ObjMachine.ParticlesStation[i].Particlesstate = 10; //处方列表没有该药品
                            sndPEe(false);
                        }
                        if (ObjMachine.ParticlesStation[i].Particlesstate != 8 && Checkboxstation(ObjMachine.ParticlesStation[i]))
                        {
                            var m_ParticlesDetai = ObjMachine.ParticlesDetailp.Where(d => d.ParticlesName == ObjMachine.ParticlesStation[i].ParticlesName).FirstOrDefault();
                            if (m_ParticlesDetai == null) { return; }
                            if (m_ParticlesDetai.state == 5)
                            {
                                ObjMachine.ParticlesStation[i].Particlesstate = 8;
                            }
                        }
                    }
                }
            }

        }
        public static void LEDlight(CabinetStorageInfoTB Cab)
        {
            //for (int i = 0; i < MachinePublic.WD600.Length; i++)
            //{
            //    MachinePublic.WD600[i] = 0;
            //}


            //byte DBit = (byte)((Cab.CoordinateX) % 16);
            //if (DBit == 0)
            //{
            //    DBit = 16;
            //}
            //byte X = (byte)(Math.Ceiling((double)Cab.CoordinateX / 16) - 1);
            //byte Y = (byte)(Convert.ToByte(Cab.CoordinateY - 1) * 3);
            //byte H = (byte)(Convert.ToInt16(ConfigTB.Cy) - (Cab.CoordinateY - 1));
            //int D = (X + Y);
            //if (DBit < 17 && D < 42)
            //{
            //    if (H % 2 == 0)
            //    {
            //        MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << (16 - DBit)));

            //    }
            //    else
            //    {
            //        MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << DBit - 1));
            //    }
            //}


            //int MaxCoordinateX = 48; //灯柜允许最大列
            //int Maxnuber = Convert.ToInt16(ConfigTB.Cn1); //大药柜数量
            //int NowX = 0;
            //if (Maxnuber > 0)
            //{
            //    for (int i = 0; i < Maxnuber; i++)
            //    {
            //        NowX = MachinePublic.WD600[42 + i] + NowX;
            //        if (NowX <= MaxCoordinateX)
            //        {
            //            MachinePublic.WD600[42 + i] = 16;
            //        }
            //    }
            //}
            //int Minnuber = Convert.ToInt16(ConfigTB.Cn2); //小药柜数量

            //if (Minnuber > 0)
            //{
            //    NowX = Maxnuber * 16;
            //    for (int i = 0; i < Minnuber; i++)
            //    {
            //        {
            //            NowX = MachinePublic.WD600[42 + Maxnuber + i] + NowX;
            //            if (NowX <= MaxCoordinateX)
            //            {
            //                MachinePublic.WD600[42 + Maxnuber + i] = 8;
            //            }
            //        }
            //    }
            //}
            //MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            //MachinePublic.WD600[50] = 1;
        }
        /// <summary>
        /// 检查工位药瓶余量是否不足 记录当前扣除的库存量
        /// </summary>
        /// <param name="DG"></param>
        /// <returns></returns>
        private bool CheckWeight(Machine.DetailgG DG)
        {
            var listParticlesDetais = ObjMachine.ParticlesDetailp.Where(d => (d.ParticlesName == DG.ParticlesName)).FirstOrDefault();
            if (listParticlesDetais == null || DG.DrugeValue == 0) { return false; }
            double novalue = 0;
            if (ObjMachine.Oddsate || ObjMachine.Oddstata1)
            {
                novalue = DG.DrugeValue - 0.5;
            }
            else
            {
                novalue = DG.DrugeValue;
            }
            if (listParticlesDetais.Dweight < (listParticlesDetais.NewDose * 2 * (Math.Abs(novalue) + 1) + ConfigTB.ParticlesBottomLineValue) - listParticlesDetais.DeductStockWeight && listParticlesDetais.state != 4)
            {
                //本次扣除库存量= 当前下药次数*每格重量*2 -已经扣除的库存量；
                double DeductStockWeight = 0;
                if (ObjMachine.Oddsate || ObjMachine.Oddstata1)
                {
                    //减半下药
                    DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * (DG.DrugeValue - 1) + listParticlesDetais.NewDose - listParticlesDetais.DeductStockWeight, 2);
                    ObjMachine.Oddstata1 = true;
                }
                else
                {
                    DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * DG.DrugeValue - listParticlesDetais.DeductStockWeight, 2);
                }
                listParticlesDetais.state = 5;

                listParticlesDetais.DrugeValue = DG.DrugeValue;
                if (PresHandle.DeductStockStep(DG.Rfidnumber, NewPresData, DeductStockWeight)) //提前扣除库存
                {
                    listParticlesDetais.DeductStockWeight = listParticlesDetais.DeductStockWeight + DeductStockWeight;

                }
                return true;
            }
            return false;
        }
        private void stopDeductStockWeight()
        {
            foreach (Machine.DetailgG DG in ObjMachine.ParticlesStation)
            {
                if (DG.ParticlesName == null) { continue; }
                var listParticlesDetais = ObjMachine.ParticlesDetailp.Where(d => (d.ParticlesName == DG.ParticlesName)).FirstOrDefault();
                if (listParticlesDetais == null) { continue; }
                listParticlesDetais.DrugeValue = DG.DrugeValue;
            }
            foreach (Machine.DetailM listParticlesDetais in ObjMachine.ParticlesDetailp)
            {

                //本次扣除库存量= 当前下药次数*每格重量*2 -已经扣除的库存量；
                if (listParticlesDetais.DrugeValue == 0) { continue; }
                if (!listParticlesDetais.Deduct)
                {
                    double DeductStockWeight = 0;
                    if (ObjMachine.Oddsate || ObjMachine.Oddstata1)
                    {
                        //减半下药
                        DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * (listParticlesDetais.DrugeValue - 1) + listParticlesDetais.NewDose - listParticlesDetais.DeductStockWeight, 2);
                        ObjMachine.Oddstata1 = true;
                    }
                    else
                    {
                        DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * listParticlesDetais.DrugeValue - listParticlesDetais.DeductStockWeight, 2);
                    }

                    if (PresHandle.DeductStockStep(listParticlesDetais.Rfidnumber, NewPresData, DeductStockWeight)) //提前扣除库存
                    {
                        listParticlesDetais.DeductStockWeight = listParticlesDetais.DeductStockWeight + DeductStockWeight;

                    }
                    listParticlesDetais.Deduct = true;
                }
            }
        }
        /// <summary>
        /// 称重扣库存
        /// </summary>
        /// <param name="DG"></param>
        /// <returns></returns>
        private bool qCheckWeight(Machine.DetailgG DG)
        {
            if (ObjMachine.ParticlesDetailp == null) { return false; };
            var listParticlesDetais = ObjMachine.ParticlesDetailp.Where(d => (d.ParticlesName == DG.ParticlesName)).FirstOrDefault();
            if (listParticlesDetais == null) { return false; };
            if (listParticlesDetais.state == 4) { return false; }
            double DeductStockWeight = 0;
            //本次扣除库存量= 当前下药次数*每格重量*2 -已经扣除的库存量；
            if (ObjMachine.Oddsate || ObjMachine.Oddstata1)
            {
                //减半下药
                DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * (listParticlesDetais.DrugeValue - 1) + listParticlesDetais.NewDose - listParticlesDetais.DeductStockWeight, 2);
                ObjMachine.Oddstata1 = true;
            }
            else
            {
                DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * listParticlesDetais.DrugeValue - listParticlesDetais.DeductStockWeight, 2);
            }
            //   listParticlesDetais.DrugeValue = DG.DrugeValue;
            if (DeductStockWeight <= 0) { return true; }
            if (PresHandle.DeductStockStep(DG.Rfidnumber, NewPresData, DeductStockWeight)) //提前扣除库存
            {
                listParticlesDetais.DeductStockWeight = listParticlesDetais.DeductStockWeight + DeductStockWeight;
            }
            return true;
        }
        /// <summary>
        /// 调剂逻辑
        /// </summary>
        public void State()
        {
            ReadE();//获取设备链接状态

            switch (ObjMachine.Runstate)
            {
                case Machine.Workstate.Write:
                    {
                    }
                    break;

                case Machine.Workstate.Home:
                    {
                        if (ObjMachine.Homefinish)
                        {

                            ObjMachine.Runstate = Machine.Workstate.Work;
                            ObjMachine.HomeExcute = false;
                            ObjMachine.Homefinish = false;
                            ObjMachine.MoveCount = 0;
                        }
                    }
                    break;

                case Machine.Workstate.Rest:
                    {


                        switch (ObjMachine.Restsate)
                        {
                            case 0: //初始化设备
                                {
                                    ObjMachine.HomeExcute = true;
                                    ObjMachine.Restsate = 5;
                                }
                                break;
                            case 5:
                                {
                                    if (ObjMachine.Homefinish)
                                    {
                                        ObjMachine.HomeExcute = false;
                                        ObjMachine.Homefinish = false;

                                        ObjMachine.Zmovenuber = (ObjMachine.MoveCount % ObjMachine.Maxbox) - 1; //计算出之前位移次数

                                        ObjMachine.Restsate = 10;
                                    }
                                }
                                break;
                            case 10: //转盘位移
                                {
                                    ObjMachine.Zmove = true;
                                    ObjMachine.Restsate = 15;

                                }
                                break;
                            case 15:
                                {
                                    if (ObjMachine.Zmovefinsh)
                                    {
                                        ObjMachine.Zmovenuber = 1;
                                        ObjMachine.Zmove = false;
                                        ObjMachine.Restsate = 20;
                                    }

                                }
                                break;
                            case 20://位移完成切换到工作模式
                                {

                                    ObjMachine.Runstate = Machine.Workstate.Work;
                                    ObjMachine.Restsate = 0;

                                }
                                break;



                        }
                        break;

                    }
                case Machine.Workstate.Density:
                    {
                        DensityTest();
                    }
                    break;
                case Machine.Workstate.Set:
                    {
                        Rest();

                    }
                    break;

                case Machine.Workstate.Work:
                    {

                        if (ObjMachine.worksate == 0)
                        {
                            if (MachinePublic.DensityExcule)
                            {
                                ObjMachine.Runstate = Machine.Workstate.Density;
                            }
                            MachinePublic.DensityTestOK = true;
                        }
                        else
                        {
                            MachinePublic.DensityTestOK = false;
                        }

                        if (!ObjMachine.Sealfinshd)
                        {
                            ObjMachine.ResetSealfinshd = false;
                        }
                        if (ObjMachine.Stop)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (ObjMachine.TAxisHomefinish[i])
                                {
                                    ObjMachine.TAxisHomeExcute[i] = false;

                                }
                            }
                        }

                        switch (ObjMachine.worksate)
                        {
                            case 0:
                                {
                                    if (ObjMachine.PrescriptionID != null)
                                    {
                                        double bar = 100.000 / ObjMachine.BoxCount;
                                        ObjMachine.TBox = Math.Round(bar, 4);//每一个盒子的处方占比
                                        ObjMachine.worksate = 1;
                                    }
                                }
                                break;
                            case 1:
                                {
                                    if (ObjMachine.Boxfinish < ObjMachine.BoxCount && ObjMachine.PrescriptionID != null && ObjMachine.iError == 0) //判断是否开始进入调剂流程
                                    {
                                        ObjMachine.Zmovenuber = 1;
                                        ObjMachine.worksate = 5;
                                    }
                                }
                                break;
                            case 5:
                                {
                                    if (Math.Abs(MachinePublic.SetTemperature1 - MachinePublic.ReadTemperature1) < 6 && Math.Abs(MachinePublic.SetTemperature2 - MachinePublic.ReadTemperature2) < 6 && Math.Abs(MachinePublic.SetTemperature3 - MachinePublic.ReadTemperature3) < 6)
                                    {
                                        Lopra(); //判断启动本轮 下药 封口 出盒 计算 
                                        ObjMachine.worksate = 6;
                                    }
                                }
                                break;
                            case 6://判断本轮是否空转
                                {
                                    if (DrugeON())
                                    {
                                        ObjMachine.worksate = 9;
                                    }
                                    else
                                    {
                                        ObjMachine.Zmovenuber = ObjMachine.Zmovenuber + 1;
                                        ObjMachine.MoveCount = ObjMachine.MoveCount + 1;
                                        ObjMachine.yEmoveCount = ObjMachine.EmoveCount % ObjMachine.Maxbox; ;
                                        ObjMachine.EmoveCount = Emove(); //可以位移次数   
                                        if (ObjMachine.MoveCount < Emove())
                                        {
                                            ObjMachine.worksate = 5;
                                        }
                                        else
                                        {
                                            ObjMachine.worksate = 9;
                                        }
                                    }
                                }
                                break;
                            case 9:
                                {
                                    if (ObjMachine.Zmovenuber == 1)
                                    {
                                        ObjMachine.worksate = 10;
                                    }
                                    else
                                    {
                                        ObjMachine.Zmovenuber = ObjMachine.Zmovenuber - 1;
                                        ObjMachine.MoveCount = ObjMachine.MoveCount - 1;
                                        ObjMachine.worksate = 30;
                                    }
                                }
                                break;
                            case 10:
                                {
                                    if (!ObjMachine.Seal && ObjMachine.HCSealex && !ObjMachine.ResetSealfinshd)
                                    {
                                        ObjMachine.Seal = ObjMachine.HCSealex;

                                    }
                                    if (ObjMachine.Seal && ObjMachine.Sealfinsh && !ObjMachine.Sealfinshd && !ObjMachine.ResetSealfinshd)
                                    {
                                        ObjMachine.Seal = false;

                                    }
                                    ObjMachine.Mbox = ObjMachine.HCMbox;
                                    for (int i = 1; i < 9; i++)
                                    {

                                        ObjMachine.ParticlesStation[i].StartDeruge = ObjMachine.ParticlesStation[i].HCStartDeruge;
                                        if (ObjMachine.ParticlesStation[i].StartDeruge && !ObjMachine.ParticlesStation[i].Derugefinish)
                                        {
                                            ObjMachine.ParticlesStation[i].Particlesstate = 3;
                                        }
                                        if (ObjMachine.ParticlesStation[i].Derugefinish)
                                        {
                                            ObjMachine.ParticlesStation[i].Particlesstate = 2;
                                        }
                                    }

                                    if (Drugecheck(ObjMachine)) //判断状态完成
                                    {
                                        ObjMachine.worksate = 15;
                                    }
                                }
                                break;
                            case 15://写入对应完成的状态数据
                                {
                                    ObjMachine.HCSealex = false;
                                    double Boxbar = 0;//药盒进度                                    
                                    if (ObjMachine.Mbox) //下盒
                                    {
                                        Machine.Med TBbox = new Machine.Med();
                                        TBbox.PrescriptionID = ObjMachine.PrescriptionID;
                                        TBbox.Gsealstate = false;
                                        TBbox.Outstate = false;
                                        if (ObjMachine.Oddsate && ObjMachine.NowboxCount == 0)
                                        {
                                            TBbox.Oddsate = true;
                                        }
                                        else
                                        {
                                            TBbox.Oddsate = false;
                                        }
                                        List<Machine.ParticlesDetail> Tblistdetail = new List<Machine.ParticlesDetail>();
                                        int nuberfish = 0;
                                        foreach (Machine.DetailM TBd in ObjMachine.ParticlesDetailp)
                                        {
                                            Machine.ParticlesDetail pd = new Machine.ParticlesDetail();
                                            if (ObjMachine.Oddsate && ObjMachine.NowboxCount == 0)
                                            {
                                                pd.Steper = TBd.Steper1;
                                            }
                                            else
                                            {
                                                pd.Steper = TBd.Steper;
                                            }
                                            pd.ParticlesCode = TBd.ParticlesCode;
                                            if (TBd.setfish)
                                            {
                                                pd.finish = true;
                                                nuberfish = nuberfish + 1;
                                            }
                                            else
                                            {
                                                pd.finish = false;
                                            }
                                            Tblistdetail.Add(pd);
                                        }
                                        TBbox.ParticlesDetail = Tblistdetail;
                                        TBbox.finishValue = nuberfish;
                                        ObjMachine.BoxST[ObjMachine.yMoveCount] = TBbox;
                                        ObjMachine.NowboxCount = ObjMachine.NowboxCount + 1;
                                    }
                                    if (ObjMachine.Sealfinshd) //封口完成
                                    {

                                        ObjMachine.ResetSealfinshd = true; //复位封口第一阶段完成
                                        ObjMachine.BoxST[ObjMachine.HCseal].Gsealstate = true;
                                        ObjMachine.BoxST[ObjMachine.HCseal].Outstate = true;
                                        ObjMachine.BoxST[ObjMachine.HCseal].finishValue = ObjMachine.BoxST[ObjMachine.HCseal].finishValue + 2;

                                    }

                                    for (int i = 1; i < 9; i++) // 根据位移次数选择对位信息写入下药	完成状态		
                                    {
                                        int f = 16 - i;
                                        if (f == 0)
                                        {
                                            f = 16;
                                        }
                                        if (ObjMachine.yMoveCount + f > 16)//判断超出18
                                        {
                                            f = ObjMachine.yMoveCount + f - 16;
                                        }
                                        else
                                        {
                                            f = ObjMachine.yMoveCount + f;

                                        }

                                        if (ObjMachine.BoxST[f] != null && ObjMachine.ParticlesStation[i].Particlesstate > 1) //写出药盒包函要瓶中调剂w完成的状态
                                        {
                                            List<Machine.ParticlesDetail> ST = new List<Machine.ParticlesDetail>();

                                            foreach (Machine.ParticlesDetail tb in ObjMachine.BoxST[f].ParticlesDetail)
                                            {

                                                Machine.ParticlesDetail relust = new Machine.ParticlesDetail();
                                                relust = tb;
                                                if (ObjMachine.ParticlesStation[i].ParticlesCode == tb.ParticlesCode && ObjMachine.ParticlesStation[i].Derugefinish) //如果该工位有该药盒信息写入完成状态
                                                {
                                                    ObjMachine.ParticlesStation[i].DrugeValue = ObjMachine.ParticlesStation[i].DrugeValue + 1;
                                                    ObjMachine.BoxST[f].finishValue = ObjMachine.BoxST[f].finishValue + 1;
                                                    relust.finish = true;
                                                }

                                                ST.Add(relust);
                                            }
                                            ObjMachine.BoxST[f].ParticlesDetail = ST; //刷新药盒调剂的最新状态
                                        }
                                        ObjMachine.ParticlesStation[i].Bar = (int)(Math.Round((Double)(ObjMachine.ParticlesStation[i].DrugeValue / (Double)ObjMachine.BoxCount), 3) * 100);
                                    }
                                    for (int d = 1; d < 17; d++)
                                    {
                                        if (ObjMachine.BoxST[d] != null)
                                        {
                                            int c = (int)(ObjMachine.TBox * Math.Round((Double)(ObjMachine.BoxST[d].finishValue + 1) / (Double)(ObjMachine.ParticlesDetailp.Count + 3), 3));
                                            Boxbar = c + Boxbar;
                                        }
                                    }
                                    ObjMachine.Porbar = (int)(Boxbar + ObjMachine.Boxfinish * ObjMachine.TBox);
                                    ObjMachine.worksate = 20;
                                }
                                break;
                            case 20: //更新调剂工位当前状态判断出是否全部完成 取走药瓶
                                {
                                    bool Cstate = false; //判断是否关闭指示灯
                                    bool tbstate = false; //是否有药盒完成下药
                                    for (int i = 1; i < 9; i++)
                                    {
                                        if (ObjMachine.ParticlesStation[i].ParticlesCode != null)
                                        {


                                            for (int c = 1; c < 17; c++)
                                            {
                                                if (ObjMachine.BoxST[c] != null)
                                                {
                                                    if (ObjMachine.BoxST[c].finishValue == ObjMachine.BoxST[c].ParticlesDetail.Count)
                                                    {
                                                        tbstate = true;
                                                    }
                                                    foreach (Machine.ParticlesDetail tb in ObjMachine.BoxST[c].ParticlesDetail)
                                                    {
                                                        if (tb.ParticlesCode == ObjMachine.ParticlesStation[i].ParticlesCode)
                                                        {
                                                            if (tb.finish == true)
                                                            {
                                                                BoxDfstate.Add(false);

                                                            }
                                                            else
                                                            {
                                                                BoxDfstate.Add(true);
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                            if (!Checkfinish(BoxDfstate))
                                            {
                                                ObjMachine.ParticlesStation[i].Colkstate = false;
                                                if (tbstate)//  摆瓶最后一轮

                                                {
                                                    if (ObjMachine.BoxCount != ObjMachine.NowboxCount)//盒子没有下完
                                                    {

                                                        int b = ObjMachine.ParticlesDetailp.Count % 8; //最后一次插瓶的数量
                                                        int n;
                                                        for (n = 1; n < ObjMachine.ParticlesStation.Length; n++)
                                                        {
                                                            if (ObjMachine.ParticlesStation[n].Particlesstate == 2)
                                                            {
                                                                n = n + 1;
                                                            }
                                                            else
                                                            {
                                                                break;
                                                            }
                                                        }
                                                        if (n > b)//当前插瓶数量
                                                        {
                                                            ObjMachine.ParticlesStation[i].Colkstate = true;
                                                        }
                                                        else
                                                        {

                                                            ObjMachine.ParticlesStation[i].Colkstate = false;
                                                        }
                                                    }
                                                }
                                                if (!ObjMachine.ParticlesStation[i].Colkstate || ObjMachine.ParticlesStation[i].DrugeValue == ObjMachine.BoxCount)
                                                {
                                                    if (ObjMachine.ParticlesStation[i].Particlesstate == 8) { continue; }
                                                    if (ObjMachine.ParticlesStation[i].Particlesstate != 4)
                                                    {
                                                        ObjMachine.ParticlesStation[i].Particlesstate = 4;//工位待取走状态
                                                        sndPlaye(i.ToString() + "号工位待取走", true);
                                                    }
                                                    var listParticlesDetai = ObjMachine.ParticlesDetailp.Where(d => d.ParticlesName == ObjMachine.ParticlesStation[i].ParticlesName).FirstOrDefault();
                                                    if (listParticlesDetai != null)
                                                    {
                                                        if (ObjMachine.BoxCount == ObjMachine.NowboxCount)
                                                        {
                                                            if (listParticlesDetai.state != 4)
                                                            {
                                                                Cstate = true;
                                                                listParticlesDetai.state = 4;    //颗粒设置为调剂完成
                                                                if (!ObjMachine.Startstop)
                                                                {
                                                                    if (PresHandle.DeductStock(listParticlesDetai.Rfidnumber, NewPresData, listParticlesDetai.DeductStockWeight)) //扣除
                                                                    {
                                                                        listParticlesDetai.Deduct = true;
                                                                        sndPlaye(i.ToString() + "号工位调剂完成", true);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {

                                                            listParticlesDetai.state = 2;  //颗粒设置为待放入
                                                            listParticlesDetai.DrugeValue = ObjMachine.ParticlesStation[i].DrugeValue;

                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (BoxDfstate != null)
                                        {
                                            BoxDfstate.Clear();
                                        }
                                    }

                                    if (Cstate)
                                    {
                                        if (!ConfigTB.CheckLEDf)
                                        {
                                            CloseLED(ObjMachine.ParticlesDetailp);
                                        }
                                    }
                                    ObjMachine.worksate = 25;
                                }
                                break;
                            case 25: //判断出盒工位药瓶是否完成， 若完成清除当前药盒的信息
                                {
                                    for (int i = 1; i < ObjMachine.ParticlesStation.Length; i++)
                                    {
                                        if (ObjMachine.ParticlesStation[i].StartDeruge == true)
                                        {
                                            if (CheckWeight(ObjMachine.ParticlesStation[i])) //检查当前余量是否足够调剂使用
                                            {

                                                ObjMachine.ParticlesStation[i].Particlesstate = 8;
                                                sndPlaye(i.ToString() + "号工位余量不足", true);
                                            }
                                            ObjMachine.ParticlesStation[i].StartDeruge = false;
                                            ObjMachine.ParticlesStation[i].HCStartDeruge = false;
                                        }
                                    }
                                    for (int c = 1; c < 17; c++)
                                    {
                                        if (ObjMachine.BoxST[c] == null) { continue; }
                                        if (ObjMachine.BoxST[c].Gsealstate)
                                        {
                                            ObjMachine.Boxfinish = ObjMachine.Boxfinish + 1;
                                            ObjMachine.BoxST[c] = Machine.BoxSTnull;
                                        }
                                    }
                                    ObjMachine.Mbox = false;
                                    ObjMachine.HCMbox = false;
                                    if (!ObjMachine.Sealfinshd)
                                    {
                                        ObjMachine.ResetSealfinshd = false;
                                        ObjMachine.worksate = 26;
                                    }
                                }
                                break;

                            case 26:
                                {

                                    Lopraseal();//判断是否封口
                                    ObjMachine.worksate = 27;

                                }
                                break;
                            case 27://判断本轮是否需要封口
                                {
                                    if (DrugeON())
                                    {

                                        ObjMachine.worksate = 28;
                                    }
                                    else
                                    {
                                        ObjMachine.worksate = 30;
                                    }
                                }
                                break;
                            case 28:
                                {
                                    if (!ObjMachine.Seal && ObjMachine.HCSealex)
                                    {
                                        ObjMachine.Seal = ObjMachine.HCSealex;
                                    }
                                    if (ObjMachine.Seal && ObjMachine.Sealfinsh && !ObjMachine.Sealfinshd)
                                    {
                                        ObjMachine.Seal = false;
                                    }
                                    if (ObjMachine.Sealfinshd)
                                    {
                                        ObjMachine.ResetSealfinshd = true; //复位封口第一阶段完成
                                        ObjMachine.HCSealex = false;
                                        ObjMachine.BoxST[ObjMachine.HCseal].Gsealstate = true;
                                        ObjMachine.BoxST[ObjMachine.HCseal].Outstate = true;
                                        ObjMachine.BoxST[ObjMachine.HCseal].finishValue = ObjMachine.BoxST[ObjMachine.HCseal].finishValue + 2;
                                        ObjMachine.worksate = 29;
                                    }
                                }
                                break;
                            case 29:
                                {
                                    for (int c = 1; c < 17; c++)
                                    {
                                        if (ObjMachine.BoxST[c] == null) { continue; }
                                        if (ObjMachine.BoxST[c].Gsealstate)
                                        {
                                            ObjMachine.Boxfinish = ObjMachine.Boxfinish + 1;
                                            ObjMachine.BoxST[c] = Machine.BoxSTnull;
                                        }
                                    }
                                    if (!ObjMachine.Sealfinshd)//封口第一阶段完成
                                    {
                                        ObjMachine.ResetSealfinshd = false;
                                        ObjMachine.Sealfinshd = false;

                                        ObjMachine.worksate = 30;
                                    }
                                }
                                break;
                            case 30:
                                {

                                    Savemachine(ObjMachine);
                                    ObjMachine.worksate = 31;
                                }
                                break;

                            case 31: //位移次数计算
                                {
                                    fishp();
                                    if (uC_PreFlowList1.prescriptionBinModel.CheckedPreInfos.Any(x=>x.PrescriptionID==ObjMachine.PrescriptionID))
                                    {
                                        //if (Dispensing.PrescriptionDictionary[ObjMachine.PrescriptionID].PresLogObj.TaskState == 8 && !ObjMachine.Startstop)
                                        //{
                                        //    Stopdruge();
                                        //    ObjMachine.Startstop = true;
                                        //    stopDeductStockWeight();
                                        //}
                                    }
                                    if (!ObjMachine.Stop && ObjMachine.AxisHomeStep == 0)
                                    {
                                        ObjMachine.EmoveCount = Emove(); //可以位移次数      
                                        ObjMachine.worksate = 35;
                                    }
                                }
                                break;
                            case 35://可以位移次数
                                {
                                    ObjMachine.yEmoveCount = ObjMachine.EmoveCount % ObjMachine.Maxbox; ;
                                    if (ObjMachine.MoveCount < ObjMachine.EmoveCount)
                                    {
                                        ObjMachine.worksate = 40;
                                    }
                                    else
                                    {
                                        ObjMachine.worksate = 31;
                                    }
                                }
                                break;

                            case 40: //转盘位移
                                {
                                    ObjMachine.Zmove = true;

                                    ObjMachine.worksate = 45;
                                }
                                break;
                            case 45://位移完成
                                {
                                    if (ObjMachine.Zmovefinsh && ObjMachine.iError == 0)
                                    {
                                        ObjMachine.Zmovenuber = 1;
                                        ObjMachine.Zmove = false;
                                        ObjMachine.MoveCount = ObjMachine.MoveCount + 1;
                                        ObjMachine.worksate = 50;
                                    }
                                }
                                break;


                            case 50://判断出盒数量=完成数量 清除当前类
                                {
                                    Savemachine(ObjMachine);
                                    if (ObjMachine.Boxfinish == ObjMachine.BoxCount && ObjMachine.BoxCount > 0)
                                    {
                                        if (ObjMachine.Sealfinsh)
                                        {
                                            ObjMachine.Outbox = true;
                                            ObjMachine.worksate = 60;
                                        }
                                    }
                                    else
                                    {
                                        if (ObjMachine.Boxfinish % MachinePublic.Outboxunber == 0 && ObjMachine.Boxfinish > (MachinePublic.Outboxunber - 1) && ObjMachine.HCBoxfinish != ObjMachine.Boxfinish)
                                        {
                                            if (ObjMachine.Seal)
                                            {
                                                if (ObjMachine.Sealfinsh)
                                                {
                                                    ObjMachine.Outbox = true;
                                                    ObjMachine.worksate = 65;
                                                }
                                            }
                                            else
                                            {
                                                ObjMachine.Outbox = true;
                                                ObjMachine.worksate = 65;
                                            }
                                        }
                                        else
                                        {
                                            if (ObjMachine.Oddsate && ObjMachine.Boxfinish == 1)
                                            {
                                                ObjMachine.Outbox = true;
                                                ObjMachine.Oddsate = false;
                                                ObjMachine.worksate = 80;
                                            }
                                            else
                                            {
                                                ObjMachine.worksate = 1;
                                            }
                                        }
                                    }
                                }
                                break;

                            case 67:
                                {
                                    ObjMachine.Outbox = false;
                                    if (ObjMachine.iError == 0)
                                    {
                                        ObjMachine.HCBoxfinish = ObjMachine.Boxfinish;
                                        ObjMachine.worksate = 1;
                                    }
                                }
                                break;
                            case 70://判断出盒数量=完成数量 清除当前类
                                {
                                    if (ObjMachine.PrescriptionID == null)
                                    {
                                        {
                                            Savemachine(ObjMachine);
                                            ObjMachine.worksate = 0;
                                        }
                                    }

                                }
                                break;
                        }
                    }
                    break;
            }
        }


        /// <summary>
        /// 温湿度保存
        /// </summary>
        //private void SaveTemp(double T, double H)
        //{
        //    string SelectSQL = string.Format(@"select Temperature,Humidity from EnvironmentalInformationTB where DeviceID={0} and RecordTime like '%{1}%' ORDER BY RecordTime", Form1_Mian.DeviceID, DateTime.Now.ToString("yyyy/MM/dd"));
        //    DataTable Read_tb = DAL.DBHelper.ResultTable(SelectSQL);
        //    if (Read_tb.Rows.Count != 0)
        //    {
        //        SelectSQL = string.Format(@"update  EnvironmentalInformationTB set  Temperature={0},Humidity={1}  where DeviceID={2} and RecordTime='{3}'", T.ToString(), H.ToString(), Form1_Mian.DeviceID, DateTime.Now.ToString("yyyy/MM/dd"));

        //    }
        //    else
        //    {
        //        SelectSQL = string.Format(@" insert EnvironmentalInformationTB (RecordTime, Temperature,Humidity ,DeviceID) values('{0}',{1},{2},{3})", DateTime.Now.ToString("yyyy/MM/dd"), T.ToString(), H.ToString(), Form1_Mian.DeviceID);

        //    }

        //    DAL.DBHelper.ExecuteNonQuery(SelectSQL);




        public double ConvertPercentageToDouble(string percentageString)
        {
            // 移除字符串末尾的百分号并转换为double
            if (percentageString.EndsWith("%"))
            {
                percentageString = percentageString.Substring(0, percentageString.Length - 1);
            }
            // 将字符串转换为double并除以100
            return double.Parse(percentageString) / 100;
        }


        public Model[] RotateRightCircular(Model[] arr, int rotations)
        {

            List<Model> Models = new List<Model>();
            Queue<Model> queue = new Queue<Model>(arr);
            if (rotations != 0)
            {
                int n = arr.Length;
                rotations = rotations % n; // 处理多余旋转次数的情况
                for (int i = 0; i < rotations; i++)
                {
                    Model lastElement = queue.Dequeue(); // 移除并获取最后一个元素
                    queue.Enqueue(lastElement); // 将该元素加到队尾（实现右旋转）
                }
            }
            // 将队列中的元素复制回数组
            return queue.ToArray();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F9))
            {
                this.btnStartRun_Click(new object(), new EventArgs());
                return true;
            }
            else if (keyData == Keys.F10)
            {
                btnSuspend_Click(new object(), new EventArgs());
                return true;
            }
            else if (keyData == Keys.F11)
            {
                btnAddParticle_Click(new object(), new EventArgs());
                return true;
            }
            else if (keyData == Keys.F12)
            {
                lblBtnYLTZ_Click(new object(), new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void StateDisplay(Machine ObjUserMachine)
        {
            //if (this.dKeys == Keys.F9)
            //{
            //    this.dKeys = Keys.NumPad1;

            //    btnStartRun.Click();
            //}
            //if (this.dKeys == Keys.F10)
            //{
            //    Dispensing.dKeys = Keys.NumPad1;
            //    menuStrip1.Focus();
            //    暂停继续ToolStripMenuItem.PerformClick();
            //}
            //if (Dispensing.dKeys == Keys.F11)
            //{
            //    Dispensing.dKeys = Keys.NumPad1;
            //    menuStrip1.Focus();
            //    上药ToolStripMenuItem.PerformClick();
            //}
            //if (Dispensing.dKeys == Keys.F12)
            //{
            //    Dispensing.dKeys = Keys.NumPad1;
            //    menuStrip1.Focus();
            //    余量调整ToolStripMenuItem.PerformClick();
            //}

            if (ObjUserMachine.Runstate == Machine.Workstate.Write)
            {
                MachineHCState = "运行状态：等待初始化 ";
            }
            if (ObjUserMachine.Runstate == Machine.Workstate.Home)
            {
                MachineHCState = "运行状态：回零中 ";
            }
            if (ObjUserMachine.Runstate == Machine.Workstate.Density)
            {
                MachineHCState = "运行状态：密度测量中 ";
            }
            if (ObjUserMachine.Runstate == Machine.Workstate.Set)
            {
                MachineHCState = "运行状态：设备调试中 ";
            }
            if (ObjUserMachine.Runstate == Machine.Workstate.Work)
            {

                if (ObjUserMachine.PrescriptionID == null)
                {
                    MachineHCState = "运行状态：等待调剂 ";
                    if (textBox1number.Text != "")
                    {
                        textBox1number.Text = "";
                    }
                }
                else
                {
                    MachineHCState = "运行状态：调剂中 ";
                    if (NewPresData.BreakNumber > 0)
                    {
                        if (textBox1number.Text != "本次调剂:" + ObjUserMachine.Boxfinish * 2 + "/" + NewPresData.BoxNumber * 2 + PrintConfigTB.Box + "(拆分" + NewPresData.BreakNumber.ToString() + "次)--" + "共" + ((ObjUserMachine.Boxfinish / 16) + 1) + "/" + Math.Ceiling((double)NewPresData.BoxNumber / 16).ToString() + "轮")
                        {
                            textBox1number.Text = "本次调剂:" + ObjUserMachine.Boxfinish * 2 + "/" + NewPresData.BoxNumber * 2 + PrintConfigTB.Box + "(拆分" + NewPresData.BreakNumber.ToString() + "次)--" + "共" + ((ObjUserMachine.Boxfinish / 16) + 1) + "/" + Math.Ceiling((double)NewPresData.BoxNumber / 16).ToString() + "轮";
                        }
                    }
                    else
                    {
                        if (textBox1number.Text != "本次调剂:" + ObjUserMachine.Boxfinish * 2 + "/" + NewPresData.BoxNumber * 2 + PrintConfigTB.Box + "--" + "共" + ((ObjUserMachine.Boxfinish / 16) + 1) + "/" + Math.Ceiling((double)NewPresData.BoxNumber / 16).ToString() + "轮")
                        {
                            textBox1number.Text = "本次调剂:" + ObjUserMachine.Boxfinish * 2 + "/" + NewPresData.BoxNumber * 2 + PrintConfigTB.Box + "--" + "共" + ((ObjUserMachine.Boxfinish / 16) + 1) + "/" + Math.Ceiling((double)NewPresData.BoxNumber / 16).ToString() + "轮";
                        }
                    }
                }
                if (ObjMachine.Stop)
                {
                    Stoping = "(设备已暂停)";
                    MachineHCState = newstate.Text + "(设备已暂停)";
                }
                else
                {
                    Stoping = "";
                }
                MachineHCState = MachineHCState + Stoping;
            }
            else
            {
                if (!string.IsNullOrEmpty(textBox1number.Text))
                {
                    textBox1number.Text = " ";
                }
            }
            if (MachineHCState != newstate.Text)
            {
                newstate.Text = MachineHCState;
            }
            if (ObjUserMachine.Porbar < 101 && ObjUserMachine.Porbar >= 0 && roundMachined2.AllBarvalue != ObjUserMachine.Porbar)
            {
                roundMachined2.AllBarvalue = ObjUserMachine.Porbar;
            }

            //修改表格状态 - 扣除库存
            if (ObjUserMachine.ParticlesDetailp != null)
            {
                //复位处方时的方法
                if (dgvPreDetail.Rows.Count == 0)
                {
                    foreach (Machine.DetailM Detail in ObjUserMachine.ParticlesDetailp)
                    {
                        var ParticlesStation = ObjUserMachine.ParticlesStation.Where(x => x.ParticlesName == Detail.ParticlesName).FirstOrDefault();
                        int DrugeValue = 0;
                        DrugeValue = Math.Max(ParticlesStation.DrugeValue, Detail.DrugeValue);
                        DataGridViewRow Row = new DataGridViewRow();
                        Statecolorl date = checkdstate(Detail.state);
                        Row.CreateCells(dgvPreDetail);
                        Row.Cells[0].Value = dgvPreDetail.Rows.Count + 1;
                        Row.Cells[1].Value = Detail.ParticlesName;
                        Row.Cells[2].Value = Detail.Dose;
                        Row.Cells[3].Value = (Math.Round((Double)(DrugeValue / (Double)ObjMachine.BoxCount), 3) * 100);
                        Row.Cells[4].Value = date.name;
                        Row.Cells[5].Value = "列<" + Detail.CoordinateX + ">,行<" + Detail.CoordinateY + ">";
                        Row.DefaultCellStyle.BackColor = date.color;

                        dgvPreDetail.Rows.Add(Row);
                    }
                    this.dgvPreDetail.TopLeftHeaderCell.Value = "共" + dgvPreDetail.Rows.Count.ToString() + "条";
                }
                bool isOrder = false;
                for (int c = 0; c < dgvPreDetail.Rows.Count; c++)
                {

                    foreach (Machine.DetailM relus in ObjUserMachine.ParticlesDetailp)
                    {
                        if (dgvPreDetail.Rows[c].Cells[1].Value.ToString() == relus.ParticlesName)
                        {
                            var ParticlesStation = ObjUserMachine.ParticlesStation.Where(x => x.ParticlesName == relus.ParticlesName).FirstOrDefault();
                            int DrugeValue = 0;
                            if (!ParticlesStation.Equals(default(Machine.DetailgG)))
                            {
                                DrugeValue = Math.Max(ParticlesStation.DrugeValue, relus.DrugeValue);
                            }
                            else
                            {
                                DrugeValue = relus.DrugeValue;
                            }
                            double bar = 0;
                            if (DrugeValue == 0 || ObjMachine.BoxCount == 0)
                            {
                                bar = 0;
                            }
                            else
                            {
                                bar = (Math.Round((Double)(DrugeValue / (Double)ObjMachine.BoxCount), 3) * 100);
                            }
                            if (bar < 0)
                            {
                                bar = 0;
                            }
                            if (bar > 100)
                            {
                                bar = 100;
                            }
                            dgvPreDetail.Rows[c].Cells[3].Value = bar;

                            Statecolorl date = checkdstate(relus.state);
                            if (dgvPreDetail.Rows[c].Cells[4].Value.ToString() != date.name)
                            {
                                dgvPreDetail.Rows[c].Cells[4].Value = date.name;
                                //if (relus.state == 2 && !ParticlesStation.Equals(default(Machine.DetailgG)))
                                //{

                                //}
                                //else
                                //{ 
                                dgvPreDetail.Rows[c].DefaultCellStyle.BackColor = date.color;
                                // }
                                isOrder = true;
                            }
                        }
                    }

                }
                if (isOrder)
                {
                    dgvPreDetail.Sort(dgvPreDetail.Columns[3], ListSortDirection.Ascending);

                }
            }
            double minValue = double.MaxValue; // 初始化一个很大的数作为最小值候选
            foreach (DataGridViewRow row in dgvPreDetail.Rows)
            {
                if (row.Cells[3].Value != null && row.Cells[4].Value.ToString() == "待放入下药工位") // 确保单元格不为空
                {
                    double currentValue = ConvertPercentageToDouble(row.Cells[3].Value.ToString()); // 转换当前单元格的值
                    if (currentValue < minValue) // 如果当前值小于已知的最小值，则更新最小值
                    {
                        minValue = currentValue;
                    }
                }
            }


            // 遍历所有行
            foreach (DataGridViewRow row in dgvPreDetail.Rows)
            {
                // 检查第二列（索引为1）的值是否等于我们要查找的值
                if (row.Cells[3].Value != null && (double)row.Cells[3].Value == minValue * 100 && row.Cells[4].Value.ToString() == "待放入下药工位")
                {
                    // 如果找到，选择这行
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133))))); ;
                }
            }
            MonterEorr(ObjMachine);//获取设备错误信息
            //称重工位显示
            if (MachinePublic.WeightState)
            {

                //if (ObjUserMachine.ParticlesStation[0].ParticlesName + "\r\n" + ObjUserMachine.ParticlesStation[0].Dweight + "g" != roundMachined2.Stationweight.Text)
                string pname = ObjUserMachine.ParticlesStation[0].ParticlesName;
                string sname = roundMachined2.Stationweight.Text.Replace("\r\n", "").ToString();
                if ((pname != null && !sname.StartsWith(pname)) || (pname == null && !string.IsNullOrEmpty(sname) && sname != "无"))
                {
                    if (!string.IsNullOrEmpty(ObjUserMachine.ParticlesStation[0].ParticlesName))
                    {
                        int len = pname.Length;
                        string name = "";
                        if (len >= 5)
                        {
                            name += pname.Substring(0, len / 2);
                            name += "\r\n" + pname.Substring((len / 2));
                        }
                        else
                        {
                            name += pname;
                        }
                        name += "\r\n" + ObjUserMachine.ParticlesStation[0].Dweight + "g";
                        roundMachined2.Stationweight.Text = name;
                    }
                    else
                    {
                        roundMachined2.Stationweight.Text = "无";
                    }


                    // roundMachined2.Stationweight.Text =!string.IsNullOrEmpty(ObjUserMachine.ParticlesStation[0].ParticlesName)?ObjUserMachine.ParticlesStation[0].ParticlesName + "\r\n" + ObjUserMachine.ParticlesStation[0].Dweight + "g":"无";

                    if (ObjUserMachine.ParticlesStation[0].Particlesstate == 2)
                    {
                        roundMachined2.Stationweight.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));

                    }
                    if (ObjUserMachine.ParticlesStation[0].Particlesstate == 0)
                    {
                        roundMachined2.Stationweight.BGColor = Color.White;

                    }
                    if (ObjUserMachine.ParticlesStation[0].Particlesstate == 10 || ObjUserMachine.ParticlesStation[0].Particlesstate == 11)
                    {
                        roundMachined2.Stationweight.BGColor = Color.Red;
                    }
                }
            }
            //调剂工位显示
            for (int i = 0; i < 8; i++)//修改工位状态
            {
                Station station = new Station();
                Btname OBtname = new Btname();
                if (ObjUserMachine != null)
                {
                    string pname = ObjUserMachine.ParticlesStation[i + 1].ParticlesName;
                    if (string.IsNullOrEmpty(pname))
                    {
                        OBtname.name = "无";
                    }
                    else
                    {
                        int len = pname.Length;
                        string name = "";
                        if (len >= 5)
                        {
                            name += pname.Substring(0, len / 2);
                            name += "\r\n" + pname.Substring((len / 2));
                        }
                        else
                        {
                            name += pname;
                        }
                        OBtname.name = name;
                    }

                    //OBtname.name = ObjUserMachine.ParticlesStation[i + 1].ParticlesName;

                    OBtname.state = ObjUserMachine.ParticlesStation[i + 1].Particlesstate;

                    //if (ObjUserMachine.ParticlesStation[i + 1].ParticlesName == null)
                    //{
                    //    OBtname.name = "无";
                    //}
                }
                bool checkgr = false;
                if (OBtname.state == 4)
                {
                    if (OBtname.name != "无")
                    {
                        if (ObjMachine.ParticlesDetailp == null) { return; }
                        var m_ParticlesDetai = ObjMachine.ParticlesDetailp.Where(c => c.ParticlesName == OBtname.name).FirstOrDefault();
                        if (m_ParticlesDetai != null)
                        {
                            if (m_ParticlesDetai.state != 4)
                            {
                                checkgr = true;
                            }
                        }
                    }
                }
                Statecolorl stationwork = checkgstate(OBtname.state, checkgr);
                if (OBtname.state != 0)
                {
                    station.Text = OBtname.name + "\r\n" + stationwork.name;
                }
                else
                {
                    station.Text = "无";
                }
                station.BGColor = stationwork.color;
                if (ObjUserMachine.ParticlesStation[i + 1].Bar < 101)
                {

                    station.Parvalue = ObjUserMachine.ParticlesStation[i + 1].Bar;
                    //station.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));

                }
                liststations[i] = station;
            }
            //袋膜显示
            for (int i = 1; i < 17; i++)
            {
                Model model = new Model();
                int f = ObjMachine.Maxbox - i;
                if (f == 0) { f = 16; }
                if (ObjMachine.yMoveCount + f > ObjMachine.Maxbox) //判断超出16
                {
                    f = ObjMachine.yMoveCount + f - ObjMachine.Maxbox;
                }
                else
                {
                    f = ObjMachine.yMoveCount + f;
                }

                if (ObjMachine.BoxST[f] == null)
                {
                    if (ObjMachine.Mbox && f == ObjMachine.yMoveCount)
                    {
                        model.HaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0))))); ;
                    }
                    else
                    {
                        model.HaveColor = System.Drawing.SystemColors.MenuBar;
                    }
                }
                else
                {
                    if (ObjMachine.Seal && f == ObjMachine.HCseal)
                    {
                        model.HaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0))))); ;
                    }
                    else
                    {
                        model.HaveColor = Color.PaleTurquoise;
                    }


                }
                int S = f;
                if (S > 15)
                {

                    S = 0;
                }
                model.Text = (f).ToString();
                listmodels[S] = model;
            }


            //封口显示
            string sealnuber = "0";
            if (string.IsNullOrEmpty(ObjMachine.PrescriptionID))
            {
                sealnuber = "\r\n0/0";
            }
            else
            {
                sealnuber = "\r\n" + (ObjMachine.BoxCount * 2).ToString() + "/" + (ObjMachine.Boxfinish * 2).ToString();
            }

            if (ObjMachine.Seal)
            {
                if (ObjMachine.SealEorr == 0)
                {
                    showseal.Text = "正在封口" + sealnuber;
                    showseal.BGColor = Color.Orange;
                }
                else
                {
                    showseal.Text = "封口异常" + sealnuber;
                    showseal.BGColor = Color.Red;
                }
            }
            else
            {
                if (ObjMachine.Boxfinish > 0 && ObjMachine.BoxCount * 2 == ObjMachine.Boxfinish * 2)
                {
                    showseal.Text = "封口完成" + sealnuber;
                }
                else
                {
                    showseal.Text = "待封口" + sealnuber;
                }

                showseal.BGColor = SystemColors.MenuBar;
            }
            //制袋显示
            string makenuber = "0";
            if (string.IsNullOrEmpty(ObjMachine.PrescriptionID))
            {
                makenuber = "\r\n0/0";
            }
            else
            {
                makenuber = "\r\n" + (ObjMachine.BoxCount * 2).ToString() + "/" + (ObjMachine.NowboxCount * 2).ToString();
            }
            if (ObjMachine.Mbox)
            {
                if (ObjMachine.MboxEorr == 0)
                {
                    showmakebox.Text = "正在制袋" + makenuber;
                    showmakebox.BGColor = Color.Orange;
                }
                else
                {
                    showmakebox.Text = "制袋异常" + makenuber;
                    showmakebox.BGColor = Color.Red;
                }
            }
            else
            {
                if (ObjMachine.NowboxCount > 0 && ObjMachine.BoxCount * 2 == ObjMachine.NowboxCount * 2)
                {
                    showmakebox.Text = "制袋完成" + makenuber;
                }
                else
                {
                    showmakebox.Text = "待制袋" + makenuber;
                }
                showmakebox.BGColor = SystemColors.MenuBar;
            }
            //温度显示
            if (Math.Abs(MachinePublic.SetTemperature1 - MachinePublic.ReadTemperature1) < 6 && Math.Abs(MachinePublic.SetTemperature2 - MachinePublic.ReadTemperature2) < 6 && Math.Abs(MachinePublic.SetTemperature3 - MachinePublic.ReadTemperature3) < 6)
            {
                showtem.Textcolor = Color.Blue;
            }
            else
            {
                showtem.Textcolor = Color.Orange;
            }

            string Temperature = "";
            Temperature = "竖封:" + MachinePublic.SetTemperature1.ToString() + "/" + MachinePublic.ReadTemperature1.ToString() + "\r\n" +
                          "底封:" + MachinePublic.SetTemperature2.ToString() + "/" + MachinePublic.ReadTemperature2.ToString() + "\r\n" +
                          "顶封:" + MachinePublic.SetTemperature3.ToString() + "/" + MachinePublic.ReadTemperature3.ToString() + "\r\n";
            showtem.Text = Temperature;

            if (ObjUserMachine.Boxfinish == ObjUserMachine.BoxCount && ObjUserMachine.BoxCount > 0 && ObjUserMachine.worksate == 60)
            {
                ObjUserMachine.worksate = 70;
                Machine NUllmachine = new Machine();
                NUllmachine.Error = ObjUserMachine.Error;
                NUllmachine.Runstate = ObjUserMachine.Runstate;
                NUllmachine.worksate = ObjUserMachine.worksate;
                NUllmachine.MoveCount = ObjUserMachine.MoveCount;
                DispensingStateHandles(ObjUserMachine.PrescriptionID);
                ObjMachine = NUllmachine;

            }
            if (ObjUserMachine.worksate == 65)
            {

                ObjUserMachine.worksate = 66;
                sndPlaye("请取走药筐", true);
                //Frm_OutBoxPrompt objFrm_OutBoxPrompt = new Frm_OutBoxPrompt(Dispensing.PrescriptionDictionary[ObjUserMachine.PrescriptionID], 2);
                //objFrm_OutBoxPrompt.ShowDialog();
                //ObjUserMachine.worksate = 67;
            }
            if (ObjUserMachine.worksate == 80)
            {
                ObjUserMachine.worksate = 66;
                if (ConfigTB.AutoPrint)
                {
                    if (PrescriptionPrint.IsOK())
                    {
                        Paper(ObjUserMachine.PrescriptionID, 1, true);
                    }
                }
                sndPlaye("请取走药筐", true);
                //Frm_OutBoxPrompt objFrm_OutBoxPrompt = new Frm_OutBoxPrompt(Dispensing.PrescriptionDictionary[ObjUserMachine.PrescriptionID], 2);
                //objFrm_OutBoxPrompt.ShowDialog();
                //ObjUserMachine.worksate = 67;
            }
            if (ObjUserMachine.AxisHomeStep == 40)
            {
                ObjMachine.AxisHomeStep = 0;
                lbOpterMsg.Items.Insert(0, (8 - ObjUserMachine.AxisHomenuber) + "号工位回零完成|时间" + DateTime.Now.ToString());
            }

            //称重后追溯药柜上架位置
            if (MachinePublic.objCabinetStorageInfoTB != null && particleName != MachinePublic.objCabinetStorageInfoTB.ParticlesName)
            {
                FrmMedicineCabinetManage.StaticVariable = MachinePublic.objCabinetStorageInfoTB.ParticlesName;
                particleName = MachinePublic.objCabinetStorageInfoTB.ParticlesName;
            }

            if (liststations.ToArray() != roundMachined2.StationItems)
            {
                roundMachined2.StationItems = liststations.ToArray();
            }
            if (ObjMachine.yMoveCount < 17 && RotateRightCircular(listmodels.ToArray(), ObjMachine.yMoveCount) != roundMachined2.ModelItems)
            {
                roundMachined2.ModelItems = RotateRightCircular(listmodels.ToArray(), ObjMachine.yMoveCount);
            }
            if (roundMachined2.Seals != showseal)
            {
                roundMachined2.Seals = showseal;
            }
            if (roundMachined2.Makeboxs != showmakebox)
            {
                roundMachined2.Makeboxs = showmakebox;
            }
            if (roundMachined2.Temshows != showtem)
            {
                roundMachined2.Temshows = showtem;
            }
            roundMachined2.Refresh();
            Application.DoEvents();
        }



        public struct Statecolorl
        {
            public string name;
            public Color color;

        }
        private Statecolorl checkdstate(int i)
        {
            Statecolorl colorldate = new Statecolorl(); //表格的状态与颜色
            switch (i)
            {

                case 0:
                    {
                        colorldate.name = "无";
                        colorldate.color = Color.White;
                    }
                    break;
                case 1:
                    {

                        colorldate.name = "待称重";
                        colorldate.color = Color.White;
                    }
                    break;

                case 2:
                    {
                        colorldate.name = "待放入下药工位";
                        colorldate.color = Color.HotPink;
                    }
                    break;
                case 3:
                    {
                        colorldate.name = "调剂";
                        colorldate.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    }
                    break;


                case 4:
                    {
                        colorldate.name = "调剂完成";
                        colorldate.color = Color.Yellow;
                    }
                    break;

                case 5:
                    {
                        colorldate.name = "等待上药";
                        colorldate.color = Color.Red;
                    }
                    break;


            }
            return colorldate;
        }

        private Statecolorl checkgstate(int i, bool Check = false)
        {
            Statecolorl colorlg = new Statecolorl(); //工位的状态与颜色
            switch (i)
            {
                case 0:
                    {
                        colorlg.name = "无";
                        colorlg.color = SystemColors.MenuBar;//System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    }
                    break;

                case 1:
                    {
                        colorlg.name = "待放入";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    }
                    break;

                case 2:
                    {

                        colorlg.name = "待调剂";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    }
                    break;

                case 3:
                    {
                        colorlg.name = "调剂中";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
                    }
                    break;

                case 4:
                    {
                        colorlg.name = "待取走";
                        if (Check)
                        {
                            colorlg.color = Color.LightBlue;
                        }
                        else
                        {
                            colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        }
                    }
                    break;


                case 5:
                    {
                        colorlg.name = "回零中";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(241)))));
                    }
                    break;

                case 6:
                    {
                        colorlg.name = "回零完成";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(241)))));
                    }
                    break;
                case 7:
                    {
                        colorlg.name = "被禁用";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
                    }
                    break;
                case 8:
                    {
                        colorlg.name = "余量不足";
                        colorlg.color = Color.Red;
                    }
                    break;
                case 10:
                    {
                        colorlg.name = "非处方药品";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    }
                    break;
                case 12:
                    {
                        colorlg.name = "该药品未称重";
                        colorlg.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                    }
                    break;



            }
            return colorlg;


        }


        private string checkCabinet(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        return "1";
                    }

                case 2:
                    {
                        return "2";
                    }

                case 3:
                    {
                        return "3";
                    }

                case 4:
                    {
                        return "4";
                    }


            }
            return "";

        }



        //if (ObjUserMachine.Seal)
        //{
        //    if (ObjUserMachine.SealEorr == 0)
        //    {

        //        roundMachined2.HavemodelColor[8] =System.Drawing.Color.Orange;
        //    }
        //    else
        //    {
        //        roundMachined2.HavemodelColor[8] = System.Drawing.Color.Red;
        //    }
        //}
        //if (ObjUserMachine.Mbox)
        //{
        //    if (ObjUserMachine.MboxEorr == 0)
        //    {
        //        roundMachined2.HavemodelColor[8] = System.Drawing.Color.Orange;
        //    }
        //    else
        //    {
        //        roundMachined2.HavemodelColor[0] = System.Drawing.Color.Red;
        //    }

        //}
        //if (Dispensing.PrescriptionDictionary.Count > 0)
        //{
        //    if (Dispensing.PrescriptionDictionary[ObjMachine.PrescriptionID].PresLogObj.TaskState == 7)//终止调剂
        //    {
        //        Stopdruge();
        //    }
        //}


        //objuserControl[1].sname = OBtname[9].name;

        //if (Math.Abs(MachinePublic.SetTemperature3 - MachinePublic.ReadTemperature3) > 5)
        //{
        //    objuserControl[1].sstate = "温度未达到设定值";
        //    objuserControl[1].color = Color.Red;
        //    //objuserControl[1].BackColor = System.Drawing.Color.Orange;
        //}
        //else
        //{
        //    objuserControl[1].sstate = checkgstate(OBtname[9].state).name;
        //    objuserControl[1].color = Color.Blue;
        //}


        //objuserControl[2].sname = OBtname[10].name;
        //colorlg = checkgstate(OBtname[10].state);
        //objuserControl[2].sstate = colorlg.name;


        //objuserControl[0].sname = OBtname[11].name;
        //if (Math.Abs(MachinePublic.SetTemperature1 - MachinePublic.ReadTemperature1) > 5 || Math.Abs(MachinePublic.SetTemperature2 - MachinePublic.ReadTemperature2) > 5)
        //{
        //    objuserControl[0].sstate = "温度未达到设定值";
        //    objuserControl[0].color = Color.Red;
        //    //  objuserControl[0].BackColor = System.Drawing.Color.Orange;
        //}
        //else
        //{
        //    objuserControl[0].sstate = checkgstate(OBtname[11].state).name;
        //    objuserControl[0].color = Color.Blue;
        //}

        //  objuserControl[0].sstate = colorlg.name;


        //if (!GetBitValue(ObjUserMachine.Error, 1))
        //{
        //    colortext1.Text = "环境温湿度：" + Math.Round(((double)ObjUserMachine.Temp[0] / 100), 1).ToString() + "℃_" + Math.Round(((double)ObjUserMachine.Temp[1] / 100), 1).ToString() + "%RH ";
        //    if (ObjUserMachine.Temp[1] > 0 && Oldtemp < ObjUserMachine.Temp[1] - 100)
        //    {
        //        Oldtemp = ObjUserMachine.Temp[1];

        //        SaveTemp(Math.Round((double)ObjUserMachine.Temp[0] / 100, 2), Math.Round((double)ObjUserMachine.Temp[1] / 100, 2));
        //    }
        //}
        //else
        //{
        //    colortext1.Text = "环境温湿度：未连接 ";
        //}
        //if (!GetBitValue(ObjUserMachine.Error, 4))
        //{
        //    //    colortext2.Text = "封口温度：" + ObjUserMachine.SealTemp[0].ToString() + "℃ ";
        //    //}
        //    //else
        //    //{
        //    //    colortext2.Text = "封口温度：未连接 ";
        //    //}
        //    //if (ObjUserMachine.SealTemp[0] < ObjMachine.SealTep - 4)
        //    //{
        //    //    colortext2.Color2 = Color.Red;
        //    //}
        //    //else
        //    //{
        //    //    colortext2.Color2 = Color.Blue;
        //}
        //if (Machine.RFID[0] > 0)
        //{
        //    lbOpterMsg.Items.Insert(0, DateTime.Now + "|" + Machine.RFID[0].ToString() + "|" + Machine.Weightdouble);
        //}





        private int Emove() //可以位移次数
        {

            foreach (Machine.Med BoxST in ObjMachine.BoxST)
            {
                if (BoxST == null)
                {
                    continue;
                }
                foreach (Machine.ParticlesDetail Pa in BoxST.ParticlesDetail)
                {
                    if (!Pa.finish)
                    {

                        if (ObjMachine.ParticlesStation[1].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[1].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[2].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[2].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[3].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[3].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[4].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[4].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[5].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[5].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[6].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[6].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[7].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[7].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                        if (ObjMachine.ParticlesStation[8].ParticlesCode == Pa.ParticlesCode && ObjMachine.ParticlesStation[8].Particlesstate == 2) { return ObjMachine.MoveCount + 1; }
                    }

                }
                if (BoxST.finishValue >= ObjMachine.ParticlesDetailp.Count)
                {
                    return ObjMachine.MoveCount + 1;
                }
            }
            if (ObjMachine.Boxfinish == ObjMachine.BoxCount)
            {
                return ObjMachine.MoveCount + 1;
            }
            if (ObjMachine.Startstop)
            {
                return ObjMachine.MoveCount + 1;
            }

            if (ObjMachine.NowboxCount < ObjMachine.BoxCount)
            {
                for (int c = 1; c < 17; c++)
                {
                    if (ObjMachine.BoxST[c] == null)
                    {
                        return ObjMachine.MoveCount + 1;
                    }

                }

            }
            return ObjMachine.MoveCount;
        }
        /// <summary>
        /// 将调剂数据更新到药盒
        /// </summary>
        private void UpdateBox(Machine.DetailM TBd)
        {

            for (int i = 1; i < 17; i++)
            {
                if (ObjMachine.BoxST[i] == null) { continue; }

                if (ObjMachine.BoxST[i].PrescriptionID == TBd.PrescriptionID)
                {
                    var boxst = ObjMachine.BoxST[i].ParticlesDetail.Where(x => x.ParticlesCode == TBd.ParticlesCode).FirstOrDefault();
                    if (ObjMachine.BoxST[i].Oddsate)
                    {
                        boxst.Steper = TBd.Steper1;
                    }
                    else
                    {
                        boxst.Steper = TBd.Steper;
                    }

                }

            }




        }
        private void Lopra()
        {
            ObjMachine.yMoveCount = ObjMachine.MoveCount % ObjMachine.Maxbox;
            if (ObjMachine.yMoveCount == 0 && ObjMachine.MoveCount < ObjMachine.Maxbox + 1)
            {
                ObjMachine.yMoveCount = ObjMachine.MoveCount;
            }
            if (ObjMachine.yMoveCount == 0 && ObjMachine.MoveCount > ObjMachine.Maxbox)
            {
                ObjMachine.yMoveCount = ObjMachine.Maxbox;
            }
            //下药， 出盒， 封口  , 下盒。计算
            for (int i = 1; i < ObjMachine.Maxbox + 1; i++) //i为工位序号
            {
                int f = ObjMachine.Maxbox - i;
                if (f == 0) { f = 16; }
                if (ObjMachine.yMoveCount + f > ObjMachine.Maxbox) //判断超出16
                {
                    f = ObjMachine.yMoveCount + f - ObjMachine.Maxbox;
                }
                else
                {
                    f = ObjMachine.yMoveCount + f;
                }
                if (i == 16) //制袋
                {
                    if (ObjMachine.NowboxCount < ObjMachine.BoxCount && ObjMachine.BoxST[f] == null) //当前下盒数量<处方需要盒数 执行下盒
                    {

                        ObjMachine.HCMbox = true;
                    }
                }
                if (ObjMachine.BoxST[f] != null && ObjMachine.worksate == 5)
                {
                    if (i < 9)
                    {
                        foreach (Machine.ParticlesDetail Detail in ObjMachine.BoxST[f].ParticlesDetail)
                        {
                            if (ObjMachine.ParticlesStation[i].ParticlesCode == Detail.ParticlesCode && ObjMachine.ParticlesStation[i].Particlesstate == 2 && !Detail.finish)
                            {
                                if (ObjMachine.Oddsate)
                                {
                                    if (ObjMachine.ParticlesStation[i].DrugeValue == 0)
                                    {
                                        var detailM = ObjMachine.ParticlesDetailp.Where(x => x.ParticlesCode == ObjMachine.ParticlesStation[i].ParticlesCode).FirstOrDefault();
                                        if (detailM.Steper1 == Detail.Steper)
                                        {
                                            ObjMachine.ParticlesStation[i].Steper = Detail.Steper;
                                            ObjMachine.ParticlesStation[i].HCStartDeruge = true;
                                        }
                                    }
                                    else
                                    {
                                        ObjMachine.ParticlesStation[i].Steper = Detail.Steper;
                                        ObjMachine.ParticlesStation[i].HCStartDeruge = true;
                                    }
                                }
                                else
                                {
                                    ObjMachine.ParticlesStation[i].Steper = Detail.Steper;
                                    ObjMachine.ParticlesStation[i].HCStartDeruge = true;
                                }

                            }
                        }
                    }

                    if (i == 8)//封口
                    {

                        if (ObjMachine.BoxST[f].Gsealstate == false && bST(ObjMachine.BoxST[f]))
                        {
                            ObjMachine.HCseal = f;
                            ObjMachine.HCSealex = true;
                        }
                    }
                    ////if (i == 12)//出盒
                    ////{
                    ////    if (ObjMachine.BoxST[f].Gsealstate == true)
                    ////    {
                    ////        ObjMachine.HCoutbox = f;
                    ////        ObjMachine.Outbox = true;


                    ////    }
                    ////}

                }
            }

        }
        ////
        private void Lopraseal()
        {
            int yMoveCount = 0;
            int MoveCount = ObjMachine.MoveCount - 1;
            yMoveCount = (MoveCount - 1) % ObjMachine.Maxbox;
            if (yMoveCount == 0 && MoveCount < ObjMachine.Maxbox + 1)
            {
                yMoveCount = MoveCount;
            }
            if (yMoveCount == 0 && MoveCount > ObjMachine.Maxbox)
            {
                yMoveCount = ObjMachine.Maxbox;
            }
            //下药， 出盒， 封口  , 下盒。计算
            for (int i = 1; i < ObjMachine.Maxbox + 1; i++) //i为工位序号
            {
                int f = ObjMachine.Maxbox - i;
                if (f == 0) { f = 16; }
                if (ObjMachine.yMoveCount + f > ObjMachine.Maxbox) //判断超出16
                {
                    f = ObjMachine.yMoveCount + f - ObjMachine.Maxbox;
                }
                else
                {
                    f = ObjMachine.yMoveCount + f;
                }
                if (ObjMachine.BoxST[f] != null)
                {


                    if (i == 8)//封口
                    {

                        if (ObjMachine.BoxST[f].Gsealstate == false && bST(ObjMachine.BoxST[f]))
                        {
                            ObjMachine.HCseal = f;
                            ObjMachine.HCSealex = true;
                        }
                    }


                }
            }

        }
        private bool bST(Machine.Med ST)
        {
            foreach (Machine.ParticlesDetail datai in ST.ParticlesDetail) //下药完成检查
            {
                if (!datai.finish)
                {
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        /// <summary>
        /// 判断是否有下药 封口 下盒 动作没有 直接跳过
        /// </summary>
        /// <param name="OMachine"></param>
        /// <returns></returns>
        private bool DrugeON()
        {

            foreach (Machine.DetailgG datai in ObjMachine.ParticlesStation) //下药完成检查
            {
                if (datai.HCStartDeruge)
                {
                    {
                        return true;
                    }
                }

            }
            if (ObjMachine.HCMbox) //下盒完成检查

            {
                return true;

            }
            if (ObjMachine.HCSealex) //封口完成检查

            {
                return true;
            }


            return false;
        }



        private bool Drugecheck(Machine OMachine)
        {

            foreach (Machine.DetailgG datai in ObjMachine.ParticlesStation) //下药完成检查
            {
                if (datai.StartDeruge)
                {
                    {
                        if (!datai.Derugefinish)
                            return false;
                    }
                }

            }
            if (OMachine.Mbox) //下盒完成检查

            {
                if (!OMachine.Mboxfinsh)
                {
                    return false;
                }

            }
            if (OMachine.HCSealex) //封口完成检查

            {
                if (!OMachine.Sealfinshd)
                {
                    return false;
                }

            }

            return true;
        }





        private bool Checkfinish(List<bool> state)
        {
            foreach (bool re in state)
            {
                if (re)
                {
                    return true;
                }
            }
            return false;
        }
        private void DispensingStateHandles(string PrescriptionID)
        {
            //try
            //{
            //    if (Dispensing.PrescriptionDictionary[PrescriptionID].PresLogObj.TaskState == 8)
            //    {

            //        DataPrescriptionTB.UpdateProcessStatus(PrescriptionID, DataPrescriptionTB.PrescriptionState.作废);
            //        Dispensing.PrescriptionDictionary[PrescriptionID].PresLogObj.InsertRecord(Dispensing.PrescriptionDictionary[PrescriptionID]); //写处方调剂记录
            //        Frm_OutBoxPrompt objFrm_OutBoxPrompt = new Frm_OutBoxPrompt(Dispensing.PrescriptionDictionary[PrescriptionID], 3);
            //        sndPlaye("处方已被终止请勿交与患者");//  AddTotal(Detai); //误差量记录
            //        objFrm_OutBoxPrompt.ShowDialog();
            //        Dispensing.PrescriptionDictionary[PrescriptionID].ProcessStatus = 4;//更新处方调剂状态到已完成   
            //        Dispensing.RefreshPrescriptionDictionary();//
            //        lbOpterMsg.Items.Insert(0, ("处方|" + PrescriptionID + "|被终止调剂--时间" + DateTime.Now.ToString()) + "|");


            //        return;
            //    }

            //    if (DataPrescriptionTB.UpdateProcessStatus(PrescriptionID, DataPrescriptionTB.PrescriptionState.已调剂))
            //    {
            //        NewPresData.PresLogObj.TaskState = 3;
            //        Dispensing.PrescriptionDictionary[PrescriptionID] = NewPresData;//刷新字典数据

            //        if (Dispensing.PrescriptionDictionary[PrescriptionID].PresLogObj.InsertRecord(Dispensing.PrescriptionDictionary[PrescriptionID])) //写处方调剂记录
            //        {
            //            if (!ConfigTB.PrintBeforeAdjustment)
            //            {
            //                if (DAL.ConfigTB.Automainpaper)
            //                {
            //                    Paper(ObjMachine.PrescriptionID, 1, false, true);
            //                }
            //                if (ConfigTB.AutoPrint)
            //                {
            //                    Task.Run(() => Paper(PrescriptionID, ObjMachine.Packboxnumber));
            //                }
            //            }
            //            Frm_OutBoxPrompt objFrm_OutBoxPrompt = new Frm_OutBoxPrompt(Dispensing.PrescriptionDictionary[PrescriptionID], 1);
            //            sndPlaye("处方调剂完成请取走药筐");
            //            objFrm_OutBoxPrompt.ShowDialog();
            //            Dispensing.PrescriptionDictionary[PrescriptionID].ProcessStatus = 3;//更新处方调剂状态到已完成   
            //            Dispensing.RefreshPrescriptionDictionary();//
            //            lbOpterMsg.Items.Insert(0, ("处方|" + PrescriptionID + "|调剂完成|时间" + DateTime.Now.ToString()) + "|");

            //            return;
            //        }
            //        else
            //        {
            //            throw new Exception("处方调剂记录写入失败!");
            //        }

            //    }
            //    else
            //    {
            //        throw new Exception("更新处方完整状态失败!");
            //    }
            //}

            //catch (Exception ex)
            //{
            //    OperateLog.Write_SystemException(ConfigTB.DeviceID.ToString(), Form1_Mian.UserInfo.UserName, "1146", ex.Message);
            //    this.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:1146", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void Paper(string PrescriptionID, int Nuber, bool check = false, bool mianpaper = false)
        {
            //try
            //{
            //    PrescriptionPrint Print = new PrescriptionPrint();
            //    if (PrescriptionID != null)
            //    {
            //        DataPrescriptionTB NewPres = Dispensing.PrescriptionDictionary[PrescriptionID];
            //        Print.PrintData = NewPres;
            //        if (Print.PrintData != null)
            //        {
            //            for (int Nubernow = 0; Nubernow < Nuber; Nubernow++)
            //            {
            //                Print.Print(check, mianpaper);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        this.ShowErrorDialog("处方内容不存在!");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    //  OperateLog.Write_SystemException(Frm_MainUI.DeviceID.ToString(), Frm_MainUI.UserInfo.UserName, "1205", ex.Message);
            //    this.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:1205", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }





        private bool SrartSwapPres(string PresHisID, bool IsStartPrompt = true)
        {
            lbOpterMsg.Controls.Clear();

            //if (Dispensing.PrescriptionDictionary.Count != 0)
            //{
            //    NewPresData = PresHandle.PrescriptionHandles(Dispensing.PrescriptionDictionary[PresHisID]);//讲字典处方类容写入处方数据处理中心
            //    if (NewPresData == null) { return false; }             //判断处方是否异常
            //                                                           // this.PresHandle.PresData = NewPresData;                //赋值处方扣量对象
            //                                                           //处方日志记录
            //    NewPresData.PresLogObj.BoxNumber = NewPresData.BoxNumber;//下药盒数写入日志
            //    NewPresData.PresLogObj.StartTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");//更新处方开始调剂时间
            //    NewPresData.PresLogObj.TaskState = 2;//更新处方状态到调剂中    
            //    Dispensing.PrescriptionDictionary[NewPresData.PrescriptionID] = NewPresData;  //加工厂的处方数据更新到字典);(NewPresData);
            //    SendDateDruge(NewPresData);         //显示到列表筐
            //    Application.DoEvents();
            //}
            //else
            //{
            //    this.ShowErrorDialog("无可调剂处方!");
            //    return false;
            //}
            return true;
        }
        private void SendDateDruge(DataPrescriptionTB Pres)
        {

            //for (int i = 0; i < MachinePublic.WD600.Length; i++)
            //{
            //    MachinePublic.WD600[i] = 0;
            //}
            //Listdetail.Clear();
            //ObjMachine.DetailedCount = Pres.DetailedCount;
            //ObjMachine.BoxCount = Pres.BoxNumber;
            //ObjMachine.Oddsate = Pres.Oddsate;
            //dgvPreDetail.Rows.Clear();
            //foreach (DataPrescriptionTB.DetailStructure Detail in Pres.ParticlesDetail)
            //{
            //    Machine.DetailM Reulst = new Machine.DetailM();
            //    Reulst.PrescriptionID = Detail.PrescriptionID;
            //    Reulst.ParticlesName = Detail.ParticlesName;


            //    Reulst.ParticlesCode = Detail.ParticlesID.ToString();
            //    Reulst.ParticlesNameHIS = Detail.ParticlesNameHIS;//HIS颗粒名称
            //    Reulst.ParticlesCodeHIS = Detail.ParticlesCodeHIS;//HIS码
            //    Reulst.ArkID = Detail.CabinetParticles.ArkID;//颗粒柜号
            //    Reulst.Layer = Detail.CabinetParticles.Layer;//颗粒层号
            //    Reulst.CoordinateX = Detail.CabinetParticles.CoordinateX;//X坐标
            //    Reulst.CoordinateY = Detail.CabinetParticles.CoordinateY;//Y坐标
            //    Reulst.ParticlesStockQuantity = Detail.CabinetParticles.ParticlesStockQuantity;//颗粒库存量
            //    Reulst.Dose = Detail.Dose;
            //    Reulst.NewDose = Detail.NewDose;
            //    Reulst.state = 1;
            //    Listdetail.Add(Reulst);

            //    DataGridViewRow Row = new DataGridViewRow();
            //    Row.CreateCells(dgvPreDetail);
            //    Row.Cells[0].Value = dgvPreDetail.Rows.Count + 1;
            //    Row.Cells[1].Value = Detail.ParticlesName;
            //    Row.Cells[2].Value = Detail.Dose;
            //    Row.Cells[3].Value = "0";
            //    Row.Cells[4].Value = checkdstate(1);
            //    Row.Height = (int)(dgvPreDetail.Font.Height * 1.2);

            //    byte DBit = (byte)((Detail.CabinetParticles.CoordinateX) % 16);
            //    if (DBit == 0)
            //    {
            //        DBit = 16;
            //    }
            //    byte X = (byte)(Math.Ceiling((double)Detail.CabinetParticles.CoordinateX / 16) - 1);
            //    byte Y = (byte)(Convert.ToByte(Detail.CabinetParticles.CoordinateY - 1) * 3);
            //    byte H = (byte)(Convert.ToInt16(ConfigTB.Cy) - (Detail.CabinetParticles.CoordinateY - 1));
            //    int D = (X + Y);
            //    if (DBit < 17 && D < 42)
            //    {
            //        if (H % 2 == 0)
            //        {
            //            MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << (16 - DBit)));

            //        }
            //        else
            //        {
            //            MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << DBit - 1));
            //        }
            //    }
            //    Statecolorl date = checkdstate(Reulst.state);
            //    Row.Cells[5].Value = "列<" + Detail.CabinetParticles.CoordinateX + ">,行<" + Detail.CabinetParticles.CoordinateY + ">";
            //    Row.DefaultCellStyle.BackColor = date.color;
            //    dgvPreDetail.Rows.Add(Row);

            //}
            //int MaxCoordinateX = 48; //灯柜允许最大列
            //int Maxnuber = Convert.ToInt16(ConfigTB.Cn1); //大药柜数量
            //int NowX = 0;
            //if (Maxnuber > 0)
            //{
            //    for (int i = 0; i < Maxnuber; i++)
            //    {
            //        NowX = MachinePublic.WD600[42 + i] + NowX;
            //        if (NowX <= MaxCoordinateX)
            //        {
            //            MachinePublic.WD600[42 + i] = 16;
            //        }
            //    }
            //}
            //int Minnuber = Convert.ToInt16(ConfigTB.Cn2); //小药柜数量

            //if (Minnuber > 0)
            //{
            //    NowX = Maxnuber * 16;
            //    for (int i = 0; i < Minnuber; i++)
            //    {
            //        {
            //            NowX = D600[42 + Maxnuber + i] + NowX;
            //            if (NowX <= MaxCoordinateX)
            //            {
            //                MachinePublic.WD600[42 + Maxnuber + i] = 8;
            //            }
            //        }
            //    }
            //}
            //MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            //MachinePublic.WD600[50] = 1;
            ////  System.Threading.Thread.Sleep(100);
            //ObjMachine.WriteLED = true;
            //this.dgvPreDetail.TopLeftHeaderCell.Value = "共" + dgvPreDetail.Rows.Count.ToString() + "条";
            //if (ObjMachine.MoveCount == 0)
            //{
            //    ObjMachine.MoveCount = 1;
            //}
            //ObjMachine.ParticlesDetailp = Listdetail;
            //ObjMachine.PrescriptionID = Pres.PrescriptionID;
            //lbOpterMsg.Items.Insert(0, ("处方|" + ObjMachine.PrescriptionID + "|开始调剂|时间" + DateTime.Now.ToString()) + "|");
            //switch (PrintConfigTB.Automodepapertype)
            //{
            //    case 0: { ObjMachine.Packboxnumber = 1; } break;
            //    case 1: { ObjMachine.Packboxnumber = ObjMachine.BoxCount * 2; } break;
            //    case 2: { ObjMachine.Packboxnumber = (int)Math.Ceiling((double)(ObjMachine.BoxCount * 2) / (double)MachinePublic.Outboxunber); } break;
            //}
            //if (ConfigTB.PrintBeforeAdjustment)
            //{
            //    if (PrescriptionPrint.IsOK(true))
            //    {
            //        if (ConfigTB.Automainpaper)
            //        {
            //            Paper(ObjMachine.PrescriptionID, 1, false, true);
            //        }
            //    }
            //    if (PrescriptionPrint.IsOK())
            //    {
            //        if (ConfigTB.AutoPrint)
            //        {
            //            Task.Run(() => Paper(ObjMachine.PrescriptionID, ObjMachine.Packboxnumber));
            //        }
            //    }
            //}
        }
        private void CloseLED(List<Machine.DetailM> MD)
        {
            //try
            //{
            //    for (int i = 0; i < MachinePublic.WD600.Length; i++)
            //    {
            //        MachinePublic.WD600[i] = 0;
            //    }
            //    foreach (Machine.DetailM Detail in MD)
            //    {
            //        if (Detail.state != 4)
            //        {
            //            byte DBit = (byte)((Detail.CoordinateX) % 16);
            //            if (DBit == 0)
            //            {
            //                DBit = 16;
            //            }
            //            byte X = (byte)((Detail.CoordinateX) / 17);
            //            byte Y = (byte)(Convert.ToByte(Detail.CoordinateY - 1) * 3);
            //            byte H = (byte)(Convert.ToInt16(ConfigTB.Cy) - (Detail.CoordinateY - 1));
            //            int D = (X + Y);
            //            if (DBit < 17 && D < 42)
            //            {
            //                if (H % 2 == 0)
            //                {
            //                    MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << (16 - DBit)));

            //                }
            //                else
            //                {
            //                    MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << DBit - 1));
            //                }
            //            }
            //        }
            //    }
            //    int MaxCoordinateX = 48; //灯柜允许最大列
            //    int Maxnuber = Convert.ToInt16(ConfigTB.Cn1); //大药柜数量
            //    int NowX = 0;
            //    if (Maxnuber > 0)
            //    {
            //        for (int i = 0; i < Maxnuber; i++)
            //        {
            //            NowX = MachinePublic.WD600[42 + i] + NowX;
            //            if (NowX <= MaxCoordinateX)
            //            {
            //                MachinePublic.WD600[42 + i] = 16;
            //            }
            //        }
            //    }
            //    int Minnuber = Convert.ToInt16(ConfigTB.Cn2); //小药柜数量

            //    if (Minnuber > 0)
            //    {
            //        NowX = Maxnuber * 16;
            //        for (int i = 0; i < Minnuber; i++)
            //        {
            //            {
            //                NowX = D600[42 + Maxnuber + i] + NowX;
            //                if (NowX <= MaxCoordinateX)
            //                {
            //                    MachinePublic.WD600[42 + Maxnuber + i] = 8;
            //                }
            //            }
            //        }
            //    }
            //    MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            //    MachinePublic.WD600[50] = 1;
            //    ObjMachine.WriteLED = true;
            //}
            //catch
            //{

            //}
        }
        private void CloseLED1(List<Machine.DetailM> MD)
        {
            //try
            //{
            //    for (int i = 0; i < MachinePublic.WD600.Length; i++)
            //    {
            //        MachinePublic.WD600[i] = 0;
            //    }
            //    foreach (Machine.DetailM Detail in MD)
            //    {
            //        if (Detail.state == 1)
            //        {
            //            byte DBit = (byte)((Detail.CoordinateX) % 16);
            //            if (DBit == 0)
            //            {
            //                DBit = 16;
            //            }
            //            byte X = (byte)((Detail.CoordinateX) / 17);
            //            byte Y = (byte)(Convert.ToByte(Detail.CoordinateY - 1) * 3);
            //            byte H = (byte)(Convert.ToInt16(ConfigTB.Cy) - (Detail.CoordinateY - 1));
            //            int D = (X + Y);
            //            if (DBit < 17 && D < 42)
            //            {
            //                if (H % 2 == 0)
            //                {
            //                    MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << (16 - DBit)));

            //                }
            //                else
            //                {
            //                    MachinePublic.WD600[D] = (Int16)(MachinePublic.WD600[D] + (1 << DBit - 1));
            //                }
            //            }
            //        }
            //    }
            //    int MaxCoordinateX = 48; //灯柜允许最大列
            //    int Maxnuber = Convert.ToInt16(ConfigTB.Cn1); //大药柜数量
            //    int NowX = 0;
            //    if (Maxnuber > 0)
            //    {
            //        for (int i = 0; i < Maxnuber; i++)
            //        {
            //            NowX = MachinePublic.WD600[42 + i] + NowX;
            //            if (NowX <= MaxCoordinateX)
            //            {
            //                MachinePublic.WD600[42 + i] = 16;
            //            }
            //        }
            //    }
            //    int Minnuber = Convert.ToInt16(ConfigTB.Cn2); //小药柜数量

            //    if (Minnuber > 0)
            //    {
            //        NowX = Maxnuber * 16;
            //        for (int i = 0; i < Minnuber; i++)
            //        {
            //            {
            //                NowX = D600[42 + Maxnuber + i] + NowX;
            //                if (NowX <= MaxCoordinateX)
            //                {
            //                    MachinePublic.WD600[42 + Maxnuber + i] = 8;
            //                }
            //            }
            //        }
            //    }
            //    MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
            //    MachinePublic.WD600[50] = 1;
            //    ObjMachine.WriteLED = true;
            //}
            //catch
            //{

            //}
        }
        private bool CheckDeivce(int value)
        {
            if (GetBitValue(ObjMachine.iError, 3))
            {
                this.ShowErrorDialog("设备气压不足，无法调剂");
                return false;
            }
            if (GetBitValue(ObjMachine.iError, 4))
            {
                this.ShowErrorDialog("设备封口温度未达到设定值，无法调剂");
                return false;
            }
            if (ObjMachine.Runstate == Machine.Workstate.Work && String.IsNullOrEmpty(ObjMachine.PrescriptionID))
            {
                return true;
            }
            else
            {
                this.ShowErrorDialog("设备不处于：等待调剂");
                return false;
            }


        }




        /// <summary>
        /// Bit位转int 回零调用
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="bitValue"></param>
        /// <returns></returns>
        public static int SetBitValue(int value, ushort index, bool bitValue)
        {
            if (index > 63) throw new ArgumentOutOfRangeException("index"); //索引出错
            var val = 1 << index;
            return bitValue ? (value | val) : (value & ~val);
        }
        public void sndPlaye(string name, bool check = false)
        {
            try
            {
                if (!ConfigTB.Autospeak) { return; }
                Task.Run(() =>
                {


                    //string filePath = Application.StartupPath + "\\WAVE\\" + name + ".wav";
                    //string directoryPath = Path.GetDirectoryName(filePath);
                    //bool exists = Directory.Exists(directoryPath) && File.Exists(filePath);
                    //if (exists)
                    //{
                    //    System.Media.SoundPlayer sndPlayer = new System.Media.SoundPlayer(Application.StartupPath + "\\WAVE\\" + name + ".wav");    //wav格式的铃声 

                    //    sndPlayer.PlaySync();
                    //    sndPlayer.Dispose();
                    //}
                    //else
                    //{
                    if (check)
                    {
                        synthesizer.SpeakAsyncCancelAll();
                    }
                    synthesizer.Pause();
                    synthesizer.Resume();
                    synthesizer.Speak(name);

                    // AiSpeak(name);

                    // }
                });
            }
            catch
            {

            }


        }
        public void sndPlaye1(string name, bool check = false)
        {
            try
            {

                Task.Run(() =>
                {


                    //string filePath = Application.StartupPath + "\\WAVE\\" + name + ".wav";
                    //string directoryPath = Path.GetDirectoryName(filePath);
                    //bool exists = Directory.Exists(directoryPath) && File.Exists(filePath);
                    //if (exists)
                    //{
                    //    System.Media.SoundPlayer sndPlayer = new System.Media.SoundPlayer(Application.StartupPath + "\\WAVE\\" + name + ".wav");    //wav格式的铃声 

                    //    sndPlayer.PlaySync();
                    //    sndPlayer.Dispose();
                    //}
                    //else
                    //{
                    if (check)
                    {
                        synthesizer.SpeakAsyncCancelAll();
                    }
                    synthesizer.Pause();
                    synthesizer.Resume();
                    synthesizer.Speak(name);

                    // AiSpeak(name);

                    // }
                });
            }
            catch
            {

            }


        }
        public void sndPEe(bool fish)
        {
            try
            {
                Task.Run(() =>
                {
                    System.Media.SoundPlayer sndPlayer;
                    if (fish)
                    {
                        sndPlayer = new System.Media.SoundPlayer(Application.StartupPath + "\\PrompTone\\901043.wav");    //wav格式的铃声 
                    }
                    else
                    {
                        sndPlayer = new System.Media.SoundPlayer(Application.StartupPath + "\\PrompTone\\901137.wav");    //PrompTone 
                    }
                    if (sndPlayer != null)
                    {
                        sndPlayer.PlaySync();
                        sndPlayer.Dispose();
                    }
                    //    synthesizer.SpeakAsyncCancelAll();

                    //    synthesizer.Pause();
                    //synthesizer.Resume();
                    //    if (fish)
                    //    {
                    //        synthesizer.AddLexicon
                    //    }
                    //    else
                    //    {


                    //    }
                    //    synthesizer.Speak(name);


                });
            }
            catch
            {

            }
        }


        ///2转盘
        /// 
        private void Rest()
        {


            if (ObjMachine.Sealfinsh)
            {
                ObjMachine.Seal = false;

            }

            if (ObjMachine.Mboxfinsh)
            {
                ObjMachine.Mbox = false;

            }
            if (ObjMachine.Zmovefinsh)
            {
                ObjMachine.Zmove = false;

            }
            for (int c = 1; c < 9; c++)
            {
                if (ObjMachine.ParticlesStation[c].Derugefinish)
                {
                    ObjMachine.ParticlesStation[c].StartDeruge = false;

                }
            }


        }


        public static bool GetExtXBit(short nBitIndex)
        {
            int lValue = 0;
            // Form1_Mian.MultiCardCSD.GA_GetExtDiValue(0, ref lValue, 1);
            // int c=1 << nBitIndex-1;
            if (0 == (lValue & (1 << (nBitIndex - 1))))
            {
                return false;
            }
            else
            {
                return true;
            }



        }
        /// <summary>
        /// 1-8下药电机  10送膜 11出盒
        /// </summary>







        /// <summary>
        ///int 位获取
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <returns></returns>

        public static bool GetBitValue(Int64 value, int index)      //  Bit位判断
        {
            if (index > 63) throw new ArgumentOutOfRangeException("index"); //索引出错
            {

                Int64 val = Value(index);
                return (value & val) == val;
            }

        }
        public static Int64 Value(int index)
        {
            Int64 Newvalue = 1;
            for (int i = 1; i < index; i++)
            {
                Newvalue = Newvalue * 2;
            }

            return Newvalue;


        }
        /// 把一个数的指定bit位设置 0 或1 ，
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="bitIndex"></param>
        /// <param name="trueORFalse"></param>
        private Int64 ReverseBit(Int64 tag, byte bitIndex, bool trueORFalse)
        {
            Int64 temp = (int)(0x01 << (bitIndex - 1));
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
        public static Int16 ReverseBit16(ref Int16 tag, byte bitIndex, bool trueORFalse)
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
        public static Int32 ReverseBit32(ref Int32 tag, byte bitIndex, bool trueORFalse)
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

        private bool CheckRfidnumber(int number, ref string name)
        {
            try
            {
                name = NewPresData?.ParticlesDetail?.FirstOrDefault(x => x.RFID == number)?.ParticlesName;//ParticlesDictionaries.GetParticlesParamthere(number, DAL.ParticlesDictionaries.ParticlesParam.ParticlesName)?.ToString();
                return false;

            }
            catch
            {
                return true;
            }
        }

        private bool CheckAdd(DataGridView DGV, DataGridViewRow Result)
        {
            for (c = 0; c < DGV.RowCount; c++)
            {
                if (Result.Cells[0].Value != null)
                {
                    if (DGV.Rows[c].Cells[0].Value == Result.Cells[0].Value)
                    {
                        return false;

                    }
                }
            }

            return true;
        }

        private void MonterEorr(Machine ObjUserMachine)
        {

            ////异常 bit1温湿度未连接；2天平；3RFID未连接 4温控仪表未连接
            int i;
            for (i = 1; i < 17; i++)
            {
                DataGridViewRow Result = new DataGridViewRow();
                Result.CreateCells(dgvDeviceError);
                Result.Cells[2].Value = "复位";
                Result.Height = (int)(dgvDeviceError.Font.Height * 1.2);
                switch (i)
                {
                    //case 1:

                    //    Result.Cells[0].Value = "|推出药袋失败|";
                    //    Result.Cells[1].Value = "|检查推袋位置是否卡药袋|";
                    //    break;
                    case 2:

                        Result.Cells[0].Value = "|推出药袋失败|";
                        Result.Cells[1].Value = "|检查推袋位置是否卡药袋|";
                        break;
                    case 3:

                        Result.Cells[0].Value = "|气压不足|";
                        Result.Cells[1].Value = "|确认空压机是否打开|";
                        break;
                    case 4:

                        Result.Cells[0].Value = "|封口温度未达到设定值|";
                        Result.Cells[1].Value = "|等待升温|";
                        break;

                    case 5:

                        Result.Cells[0].Value = "|制袋工位已有袋|";
                        Result.Cells[1].Value = "|复位后将重新检测后进行制袋|";
                        break;
                    case 6:

                        Result.Cells[0].Value = "|制袋袋膜打开失败|";
                        Result.Cells[1].Value = "|复位后将再次尝试|";
                        break;
                    case 7:

                        Result.Cells[0].Value = "|封口交流电机回零失败|";
                        Result.Cells[1].Value = "|复位后将再次尝试|";
                        break;
                    case 8:

                        Result.Cells[0].Value = "|出盒交流电机回零失败|";
                        Result.Cells[1].Value = "|复位后将再次尝试|";
                        break;
                    case 9:

                        Result.Cells[0].Value = "|制袋失败|";
                        Result.Cells[1].Value = "|复位后将重新检查袋子是否打开|";
                        break;
                    case 10:

                        Result.Cells[0].Value = "|封袋时未检测到袋子|";
                        Result.Cells[1].Value = "|复位后将重新检测|";
                        break;
                    case 11:

                        Result.Cells[0].Value = "|封袋时打开袋膜失败|";
                        Result.Cells[1].Value = "|复位后将再次打开袋膜|";
                        break;
                    case 12:

                        Result.Cells[0].Value = "|封袋时取袋失败|";
                        Result.Cells[1].Value = "|复位后模组将回零，再次尝试取袋|";
                        break;
                    case 13:

                        Result.Cells[0].Value = "|封袋失败|";
                        Result.Cells[1].Value = "|复位后将忽略该错误|";
                        break;
                    case 14:

                        Result.Cells[0].Value = "|出盒超时|";
                        Result.Cells[1].Value = "|出盒电机超时|未收到出盒机构限位信号|";
                        break;
                    case 16:

                        Result.Cells[0].Value = "|未检测到制袋膜|";
                        Result.Cells[1].Value = "|请更换袋膜|";
                        break;
                }
                if (GetBitValue(ObjUserMachine.iError, i))
                {
                    if (CheckAdd(dgvDeviceError, Result))
                    {
                        dgvDeviceError.Rows.Add(Result);
                        sndPlaye("设备异常", true);
                    }
                }
                else
                {
                    if (!CheckAdd(dgvDeviceError, Result))
                    {
                        dgvDeviceError.Rows.RemoveAt(c);
                    }
                }
            }


        }

        private void ReadE()
        {

            D200[34] = (short)(ObjMachine.iRestError >> 16);
            D200[33] = (short)(ObjMachine.iRestError & 0xFFFF);

            for (int i = 1; i < 33; i++)
            {
                if (!GetBitValue(ObjMachine.iError, i))
                {
                    if (i < 33)
                    {

                        ReverseBit32(ref ObjMachine.iRestError, (byte)(i), false);
                    }
                }
            }
        }



        private void ErrorUpdate(DataGridViewRow Row)
        {
            try
            {
                if (Row != null && Row.Cells.Count >= 3)
                {
                    OperateLog.WriteLog(LogTypeEnum.处方调剂, "调剂中复位了错误:" + Row.Cells[1].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                OperateLog.WriteLog(LogTypeEnum.处方调剂, "调剂中复位了错误失败:" + Row.Cells[1].Value.ToString());
                //this.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:1068.3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Savemachine(Machine myObj)
        {
            try
            {
                BinFileHelper.WriteObjectToBinaryFile<Machine>(Application.StartupPath + "\\MyObj.bin", myObj);
            }
            catch
            {
                OperateLog.WriteLog(LogTypeEnum.处方调剂, "保存调剂数据异常，数据" + Json.Serialize(myObj));

            }

        }

        private void Readmachine(ref Machine myObj)
        {
            try
            {
                myObj = BinFileHelper.ReadObjectFromBinaryFile<Machine>(Application.StartupPath + "\\MyObj.bin");
            }
            catch
            {
                OperateLog.WriteLog(LogTypeEnum.处方调剂, "获取恢复数据异常");
            }
        }

        /// <summary>
        /// ///指示柜
        /// </summary>
        #region


        private void oneHome(int nuber)
        {

            if (ObjMachine.Stop && (ObjMachine.worksate == 31 || ObjMachine.worksate == 0))
            {

                //if (this.ShowErrorDialog("是否对:" + nuber + " 调剂头执行回零", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                //{
                //    FrmBagDevice.ObjMachine.TAxisHomeExcute[nuber + 1] = true;
                //    lbOpterMsg.Items.Insert(0, DateTime.Now + "|" + nuber + "号调剂头正在执行回原点...|");
                //}
                //else
                //{
                //    return;
                //}
            }
            else
            {
                this.ShowErrorDialog("请暂停设备后，再执行此操作");
            }
        }



   


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ObjMachine.Runstate == Machine.Workstate.Write)
            {
                ObjMachine.Runstate = Machine.Workstate.Home;
                ObjMachine.HomeExcute = true;
                lbOpterMsg.Items.Insert(0, "|设备正在执行回原点...|" + DateTime.Now.ToString());
            }
            else
            {

                this.ShowErrorDialog("提示：设备不处于等待初始化状态");
            }
        }


        private void Stopdruge()
        {

            for (int i = 1; i < 17; i++)
            {
                if (ObjMachine.BoxST[i] != null)
                {
                    ObjMachine.BoxST[i].finishValue = ObjMachine.BoxST[i].ParticlesDetail.Count;
                    List<Machine.ParticlesDetail> Tblistdetail = new List<Machine.ParticlesDetail>();
                    foreach (Machine.DetailM TBd in ObjMachine.ParticlesDetailp)
                    {
                        Machine.ParticlesDetail pd = new Machine.ParticlesDetail();
                        pd.Steper = TBd.Steper;
                        pd.ParticlesCode = TBd.ParticlesCode;
                        pd.finish = true;
                        Tblistdetail.Add(pd);
                    }
                    ObjMachine.BoxST[i].ParticlesDetail = Tblistdetail;

                }
            }
            ObjMachine.Boxfinish = ObjMachine.BoxCount - ObjMachine.NowboxCount + ObjMachine.Boxfinish;
            ObjMachine.NowboxCount = ObjMachine.BoxCount;

        }
        private void btnStopRun_Click(object sender, EventArgs e)
        {
            //if (ObjMachine.PrescriptionID != null && Dispensing.PrescriptionDictionary.ContainsKey(ObjMachine.PrescriptionID))
            //{
            //    if (this.ShowAskDialog("是否终止调剂？"))
            //    {
            //        Dispensing.PrescriptionDictionary[ObjMachine.PrescriptionID].PresLogObj.TaskState = 8;
            //        OperateLog.WriteLog(LogTypeEnum.用户操作, "终止调剂处方：" + ObjMachine.PrescriptionID);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    this.ShowErrorDialog("无处方信息");
            //}

        }

        private void dgvDeviceError_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex != 0)
            {
                ErrorUpdate(dgvDeviceError.Rows[e.RowIndex]);
                string buttonText = dgvDeviceError.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (buttonText == "复位")
                {
                    string aid = dgvDeviceError.Rows[e.RowIndex].Cells[0].Value.ToString();

                    switch (aid)
                    {
                        case "|推出药袋失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 2, true);
                            break;
                        case "|制袋工位已有袋|":
                            ReverseBit32(ref ObjMachine.iRestError, 5, true);
                            break;

                        case "|制袋袋膜打开失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 6, true);
                            break;
                        case "|封口交流电机回零失败|":

                            ReverseBit32(ref ObjMachine.iRestError, 7, true);
                            break;
                        case "|出盒交流电机回零失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 8, true);
                            break;
                        case "|制袋失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 9, true);
                            break;

                        case "|封袋时未检测到袋子|":
                            ReverseBit32(ref ObjMachine.iRestError, 10, true);
                            break;

                        case "|封袋时打开袋膜失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 11, true);
                            break;
                        case "|封袋时取袋失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 12, true);
                            break;
                        case "|封袋失败|":
                            ReverseBit32(ref ObjMachine.iRestError, 13, true);
                            break;
                        case "|未检测到制袋膜|":
                            ReverseBit32(ref ObjMachine.iRestError, 16, true);
                            break;
                    }
                    OperateLog.WriteLog(LogTypeEnum.用户操作, "复位错误：" + aid);
                }
            }
        }

        #endregion

        #endregion

        #region 密度测量
        private void Speak(string message)
        {
            Task.Run(() =>
            {
                using (var synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.Speak(message);
                }
            });
        }
        private void DensityTest()
        {
            if (MachinePublic.DensityExcule && MachinePublic.DensityState == 0 && !MachinePublic.DensityFinsh)
            {
                if (MachinePublic.objCabinetStorageInfoTB == null)
                {
                    Speak("请将药瓶放入称重工位");
                }

                MachinePublic.DensityState = 5;
            }
            if (!MachinePublic.DensityExcule)
            {
                MachinePublic.DensityFinsh = false;
                MachinePublic.DensityState = 0;
                ObjMachine.Runstate = Machine.Workstate.Work;
            }
            if (MachinePublic.objCabinetStorageInfoTB != null && MachinePublic.DensityState > 35)
            {
                if (MachinePublic.objCabinetStorageInfoTB.ParticlesName == MachinePublic.densityTestModel.DensityParticlesName && MachinePublic.densityTestModel.DensityWeight2 == 0)
                {
                    MachinePublic.densityTestModel.DensityWeight2 = ObjMachine.ParticlesStation[0].Dweight;
                }
            }
            switch (MachinePublic.DensityState)
            {
                case 5: //判断称重工位药品
                    if (MachinePublic.objCabinetStorageInfoTB != null)
                    {
                        MachinePublic.densityTestModel.DensityParticlesID = MachinePublic.objCabinetStorageInfoTB.ParticlesID;
                        MachinePublic.densityTestModel.DensityParticlesName = MachinePublic.objCabinetStorageInfoTB.ParticlesName;
                        MachinePublic.densityTestModel.DensityWeight1 = ObjMachine.ParticlesStation[0].Dweight;
                        MachinePublic.densityTestModel.DensityWeight2 = 0;
                        MachinePublic.densityTestModel.DensityFlishNumber = 0;
                        MachinePublic.DensityState = 10;
                        Speak(MachinePublic.objCabinetStorageInfoTB.ParticlesName + "称重完成，请放入下药工位");
                    }
                    else
                    {
                        if (ObjMachine.ParticlesStation[0].ParticlesName != null && ObjMachine.ParticlesStation[0].ParticlesName != "无")
                        {
                            Speak(ObjMachine.ParticlesStation[0].ParticlesName + "未上架，已取消当前操作");
                            MachinePublic.DensityFinsh = true;
                            MachinePublic.DensityState = 100;

                        }
                    }

                    break;

                case 10: //获取测试工位序号
                    {
                        for (int i = 1; i < ObjMachine.ParticlesStation.Length; i++)
                        {
                            if (ObjMachine.ParticlesStation[i].ParticlesName == MachinePublic.densityTestModel.DensityParticlesName)
                            {
                                MachinePublic.densityTestModel.DensityGnuber = i;
                                ObjMachine.Mbox = true;
                                MachinePublic.DensityState = 15;
                                Speak(MachinePublic.densityTestModel.DensityParticlesName + "正在下药测试，请稍等");
                                break;
                            }
                        }
                    }
                    break;
                case 15:
                    {
                        if (FrmBagDevice.ObjMachine.Mboxfinsh) //下盒完成 开始旋转 
                        {

                            FrmBagDevice.ObjMachine.Zmovenuber = MachinePublic.densityTestModel.DensityGnuber;
                            FrmBagDevice.ObjMachine.Zmove = true;
                            FrmBagDevice.ObjMachine.Mbox = false;
                            MachinePublic.DensityState = 20;
                            break;
                        }
                    }

                    break;
                case 20:
                    {
                        if (FrmBagDevice.ObjMachine.Zmovefinsh)
                        {
                            FrmBagDevice.ObjMachine.Zmove = false;
                            MachinePublic.DensityState = 25;
                        }
                    }
                    break;

                case 25:
                    {
                        FrmBagDevice.ObjMachine.ParticlesStation[MachinePublic.densityTestModel.DensityGnuber].Steper = 500;
                        FrmBagDevice.ObjMachine.ParticlesStation[MachinePublic.densityTestModel.DensityGnuber].StartDeruge = true;
                        MachinePublic.DensityState = 30;
                    }
                    break;

                case 30:
                    {
                        if (FrmBagDevice.ObjMachine.ParticlesStation[MachinePublic.densityTestModel.DensityGnuber].Derugefinish)
                        {
                            FrmBagDevice.ObjMachine.ParticlesStation[MachinePublic.densityTestModel.DensityGnuber].StartDeruge = false;

                            MachinePublic.densityTestModel.DensityFlishNumber++;
                            MachinePublic.DensityState = 35;
                        }
                    }
                    break;

                case 35:
                    {
                        if (MachinePublic.densityTestModel.DensityFlishNumber < MachinePublic.Densitynuber)
                        {
                            if (!FrmBagDevice.ObjMachine.ParticlesStation[MachinePublic.densityTestModel.DensityGnuber].Derugefinish)
                            {

                                MachinePublic.DensityState = 25;
                            }
                        }
                        else
                        {
                            //"调剂完成";
                            FrmBagDevice.ObjMachine.ParticlesStation[MachinePublic.densityTestModel.DensityGnuber].StartDeruge = false;
                            FrmBagDevice.ObjMachine.Zmove = false;
                            Speak(MachinePublic.densityTestModel.DensityParticlesName + "请放入称重工位");
                            MachinePublic.DensityState = 40;
                        }
                    }
                    break;
                case 40:
                    //调剂完成移到封口
                    {
                        FrmBagDevice.ObjMachine.Zmovenuber = 8 - MachinePublic.densityTestModel.DensityGnuber;
                        FrmBagDevice.ObjMachine.Zmove = true;
                        MachinePublic.DensityState = 45;
                    }
                    break;
                case 45:
                    {
                        if (FrmBagDevice.ObjMachine.Zmovefinsh)
                        {
                            FrmBagDevice.ObjMachine.Seal = true;
                            FrmBagDevice.ObjMachine.Zmove = false;
                            FrmBagDevice.ObjMachine.Zmovefinsh = false;
                            MachinePublic.DensityState = 50;
                        }
                    }

                    break;
                case 50:
                    {
                        if (FrmBagDevice.ObjMachine.Sealfinsh)
                        {

                            FrmBagDevice.ObjMachine.Zmovenuber = 8;
                            FrmBagDevice.ObjMachine.Zmove = true;
                            FrmBagDevice.ObjMachine.Seal = false;
                            MachinePublic.DensityState = 60;
                        }
                    }

                    break;
                case 60:
                    {
                        if (FrmBagDevice.ObjMachine.Zmovefinsh)
                        {
                            // FrmBagDevice.ObjMachine.Outbox = true;
                            FrmBagDevice.ObjMachine.Zmove = false;
                            MachinePublic.DensityState = 65;
                        }
                    }
                    break;
                case 65:
                    {
                        if (MachinePublic.densityTestModel.DensityWeight2 > 0)
                        {
                            MachinePublic.DensityFinsh = true;
                            MachinePublic.DensityState = 99;
                            Speak(MachinePublic.densityTestModel.DensityParticlesName + "密度测量已完成");
                        }
                    }
                    break;
            }
        }

        #endregion

        private void dgvPreDetail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right) 
            {
                if (e.RowIndex >= 0)
                {
                    contextMenuStrip1fish.Show(MousePosition.X, MousePosition.Y);
                    MouseRows = e.RowIndex;
                }
            }
        }

        private void fishp()
        {
            if (namefish.Count > 0)
            {
                foreach (var Fristna in namefish)

                    for (int i = 1; i < 17; i++)
                    {
                        if (ObjMachine.BoxST[i] != null)
                        {
                            //    List<Machine.ParticlesDetail> Tblistdetail = new List<Machine.ParticlesDetail>();
                            //    foreach (Machine.DetailM TBd in ObjMachine.ParticlesDetailp)
                            //    {

                            //       Machine.ParticlesDetail pd = newMachine.ParticlesDetail();
                            //        pd.Steper = TBd.Steper;
                            //        pd.ParticlesCode = TBd.ParticlesCode;
                            //        if (TBd.setfish)
                            //        {
                            //            pd.finish = true;
                            //        }
                            //        else
                            //        {
                            //        }
                            //    Tblistdetail.Add(pd);
                            //    }
                            //    ObjMachine.BoxST[i].ParticlesDetail = Tblistdetail;
                            //}
                            var ParticlesDetail = ObjMachine.BoxST[i].ParticlesDetail.Where(X => X.ParticlesCode == Fristna).FirstOrDefault();
                            if (!ParticlesDetail.finish)
                            {
                                ParticlesDetail.finish = true;
                                ObjMachine.BoxST[i].finishValue = ObjMachine.BoxST[i].finishValue + 1;
                            }
                        }
                    }
                namefish.Clear();
            }
        }
        private void remove_Click(object sender, EventArgs e)
        {

            if (dgvPreDetail.CurrentRow != null)
            {
                if (ObjMachine.ParticlesDetailp == null) { return; }
                if (ObjMachine.ParticlesDetailp.Count == 0) { return; }
                string particlesname;
                particlesname = dgvPreDetail.CurrentRow.Cells["Column4"].Value.ToString();
                var ParticlesDetailp = ObjMachine.ParticlesDetailp.Where(x => x.ParticlesName == particlesname).FirstOrDefault();
                if (ParticlesDetailp == null) { this.ShowErrorDialog("处方没有该品种数据信息"); return; }
                if ((double)dgvPreDetail.CurrentRow.Cells["Column8"].Value != 0) { this.ShowErrorDialog("该品种已有调剂记录，不能设置为调剂完成状态"); return; }
                if (this.ShowAskDialog("请确认将颗粒:<" + ParticlesDetailp.ParticlesName + ">,设为调剂完成"))
                {

                    if (PresHandle.setStockStep(ParticlesDetailp.Rfidnumber, NewPresData)) //设置完成扣除库存
                    {
                        namefish.Add(ParticlesDetailp.ParticlesCode);
                        ParticlesDetailp.Deduct = true;
                        ParticlesDetailp.state = 4;
                        ParticlesDetailp.setfish = true;
                    }
                }
            }
        }

        private void dgvPreDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = Color.Blue;

            //        // 检查当前行是否被选中
            //        if (dgvPreDetail.Rows[e.RowIndex].Selected)
            //        {
            //            // 设置选中行的字体颜色为蓝色
            //            dgvPreDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Blue;
            //        }
            //        else
            //        {
            //            // 设置未选中行的字体颜色为黑色
            //            dgvPreDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
            //        }



        }

        private void btnAddPre_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmPrescriptionAdd).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmPrescriptionAdd frmPrescriptionAdd = new FrmPrescriptionAdd("", null, null);
            frmPrescriptionAdd.Text = "录入处方";
            frmPrescriptionAdd.ShowDialog();
            string msg = frmPrescriptionAdd.saveMessage;
            if (msg == "Successed")
            {
                this.ShowSuccessTip("提交处方成功");
            }
            else if (msg != "")
            {
                this.ShowErrorDialog("错误提示", msg);
            }
        }

        private void Zeroweight()
        {
            if (ObjMachine.RFID[0] > 0 && ObjMachine.RFID[0] < 900000)
            {
                this.ShowErrorDialog("当前工位有药品不能进行清零");
                return;
            }
            if (!MachinePublic.WeightState)
            {
                this.ShowErrorDialog("称重未稳定不能进行清零");
                return;
            }


            if (ObjMachine.Runstate == Machine.Workstate.Write || ObjMachine.Runstate == Machine.Workstate.Home)
            {
                this.ShowErrorDialog("设备处于未初始化或回零状态，不能进行清零操作");
                return;
            }
            MachinePublic.ZeroWeight = true;
            lbOpterMsg.Items.Insert(0, "|已发送清零指令:|" + DateTime.Now);

        }

        private void clearbox(int modenumber)

        {
            if (ObjMachine.Stop)
            {
                this.ShowErrorDialog("设备不处于暂停状态，无法清除袋");
            }
            if (ObjMachine.Seal) { this.ShowErrorDialog("设备处于封口状态，无法清除袋"); };
            if (modenumber > 15 || modenumber < 0)
            {
                this.ShowErrorDialog("数据异常，已取消清除药袋数据");
            }
            if (ObjMachine.BoxST[modenumber] == null) { this.ShowErrorDialog("转盘" + modenumber + "位置无袋, 已取清除药袋数据"); return; }
            if (modenumber == 0) { modenumber = 16; }

            if (this.ShowAskDialog("转盘" + modenumber + "位置袋清除,设备将对" + modenumber + "位置重新制袋"))
            {
                if (ObjMachine.BoxST[modenumber] != null)
                {
                    ObjMachine.BoxST[modenumber] = null;
                    ObjMachine.NowboxCount = ObjMachine.NowboxCount - 1;
                }
            }
        }



        private void roundMachined2_MyDoubleClick(object sender, MouseEventArgs e)
        {
            int Homenumber = 10; //调剂工位回零
            for (int i = 0; i < roundMachined2.StationItems.Length; i++)
            {
                if (roundMachined2.StationItems[i].rectangleF.Contains(e.Location))
                {
                    Homenumber = 8 - i;
                }
            }
            if (Homenumber < 9)
            {
                oneHome(Homenumber);
                return;
            }
            if (roundMachined2.Stationweight.rectangleF.Contains(e.Location))
            {
                Zeroweight();
                return;
            }
            int Modenumber = 20; //调剂工位回零
            for (int i = 0; i < roundMachined2.ModelItems.Length; i++)
            {
                if (roundMachined2.ModelItems[i].rectangleF.Contains(e.Location))
                {
                    Modenumber = i;
                }
            }
            if (Modenumber < 15)
            {
                clearbox(Modenumber);
                return;
            }

        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Dispensing.PrescriptionDictionary.ContainsKey(Dispensing.checkPrescriptionid))
            //    {
            //        if (Dispensing.PrescriptionDictionary[Dispensing.checkPrescriptionid].PresLogObj.TaskState == 5)//检查是否处于待调剂
            //        {
            //            if (CheckDeivce(1))
            //            {
            //                string PrescriptionHisID = Dispensing.checkPrescriptionid;   //获取当前选定处方ID号
            //                if (!SrartSwapPres(PrescriptionHisID)) { return; }  //开始加载任务drivcedruge                         
            //                Dispensing.RefreshPrescriptionDictionary();//
            //                OperateLog.WriteLog(LogTypeEnum.用户操作, "开始调剂处方[" + PrescriptionHisID + "]");

            //            }
            //        }
            //        else if (Dispensing.PrescriptionDictionary[Dispensing.checkPrescriptionid].PresLogObj.TaskState == 1)
            //        {
            //           this.ShowErrorDialog("请先核对处方【" + Dispensing.checkPrescriptionid + "】!");
            //        }
            //        else
            //        {
            //            this.ShowErrorDialog("处方在调剂中!");
            //        }

            //    }
            //    else
            //    {
            //        this.ShowErrorDialog("无可调剂的处方!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // OperateLog.Write_SystemException(ConfigTB.DeviceID.ToString(), Form1_Mian.UserInfo.UserName, "1146", ex.Message);
            //    this.ShowErrorDialog("" + ex.Message + "\r\n<" + ex.StackTrace + ">", "错误代码:1146.1");
            //}
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            if (ObjMachine.Stop)
            {
                ObjMachine.Stop = false;
                //newstate.Color2 = Color.Blue;
                lbOpterMsg.Items.Insert(0, "|设备继续当前动作:|" + DateTime.Now);
                return;
            }
            else
            {

                //  newstate.Color2 = Color.Red;
                ObjMachine.Stop = true;
                lbOpterMsg.Items.Insert(0, "|设备已暂停:|" + DateTime.Now);
                return;
            }
        }

        private void btnAddParticle_Click(object sender, EventArgs e)
        {
            FrmParticleStockAdd frmParticleStockAdd = new FrmParticleStockAdd();
            frmParticleStockAdd.ShowDialog();
            bool isSuccessed = frmParticleStockAdd.isSuccess;
            if (isSuccessed)
            {
                this.ShowSuccessTip("上药操作成功");
            }
        }

        private void lblBtnYLTZ_Click(object sender, EventArgs e)
        {
            FrmAdjustmentOfSurplus frmAdjustmentOfSurplus = new FrmAdjustmentOfSurplus();
            frmAdjustmentOfSurplus.ShowDialog();
            bool isSuccessed = frmAdjustmentOfSurplus.isSuccess;
            if (isSuccessed)
            {
                this.ShowSuccessTip("余量校准操作成功");
            }
        }

        private void btnClearDevice_Click(object sender, EventArgs e)
        {
            if (this.ShowAskDialog("是否清除设备状态？会导致当前处方中断 "))
            {
                Machine NUllmachine = new Machine();
                NUllmachine.iError = ObjMachine.iError;
                NUllmachine.Runstate = Machine.Workstate.Write;
                ObjMachine = NUllmachine;
                MachinePublic.DensityExcule = false;
                MachinePublic.DensityState = 0;
                lbOpterMsg.Items.Insert(0, "|已清除设备所有状态:|" + DateTime.Now);
                OperateLog.WriteLog(LogTypeEnum.用户操作, SysLoginUser._currentUser.UserName + "清除设备所有状态");
            }
        }
    }
}
