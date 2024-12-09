using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSys.Tool.TCP;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.Forms.UserControlForms;
using AdjustmentSysUI.Forms.UserForms;
using AdjustmentSysUI.UITool;
using NPOI.SS.UserModel;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Assembiy;
using AdjustmentSys.BLL.Common;
using AdjustmentSys.Tool;
using System.CodeDom.Compiler;
using Azure.Core;
using NPOI.SS.Formula.Functions;
using AdjustmentSys.Models.MakeUp;
using static System.Windows.Forms.AxHost;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.IdentityModel.Tokens;
using System.Speech.Synthesis;


namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmBoxedDevice : UIPage
    {
        public static Int16[] D600 = new Int16[28];
        public byte[] B400 = new byte[40];
        public Int16[] D200 = new Int16[20];
        public byte[] B250 = new byte[24];

        List<bool> BoxDfstate = new List<bool>();
        Thread Jxssend;
        ModBusTCP_Cliect modBusTCP_Cliect = new ModBusTCP_Cliect();
        PrescriptionFactory prescriptionFactory = new PrescriptionFactory();
        //public static PreModel deviceMaching.PrescriptionInfo = new PreModel();//调剂中的处方
        public static BoxedDeviceModel deviceMaching = new BoxedDeviceModel();
        CommonDataBLL commonDataBLL = new CommonDataBLL();

        List<SystemParameterInfo> systemParameterList = null;
        public FrmBoxedDevice()
        {
            InitializeComponent();
            dgvPreDetail.AutoGenerateColumns = false;
        }
        UC_WorkStationButton[] uC_WorkStationButtons = new UC_WorkStationButton[8]; //调剂工位控件
        private void Jxs()
        {
            try
            {
                while (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
                {
                    if (!modBusTCP_Cliect.Write_Intall(600, D600))
                    {
                        SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                        return;
                    }

                    if (!modBusTCP_Cliect.Write_Intall(200, D200))
                    {
                        SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                        return;
                    }

                    var D250 = modBusTCP_Cliect.Read_Intall(250, 100);
                    if (D250 != null)
                    {
                        B250 = D250;
                    }
                    else
                    {
                        SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                        return;
                    }
                    if (deviceMaching.RunState == WorkStateEnum.Set)
                    {
                        var D400 = modBusTCP_Cliect.Read_Intall(400, 20);
                        if (D400 != null)
                        {

                            B400 = D400;
                        }
                        else
                        {
                            SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                            return;
                        }
                    }

                    SetPLC();
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog("错误提示", ex.Message);
            }
        }

        private void SetPLC()
        {
            ///上位机写 D200  d201 写动作 ;D202 写位移格数，
            /// D203-211写1-8下药数据，  D200[13]  写入输出数据 D214-D215RFID写入数据
            /// 
            if (B250 == null)
            {
                return;
            }
            DataProcessingTool.ReverseBit16(ref D200[0], 1, deviceMaching.HomeExcute);//整机回零启动
            if (deviceMaching.RunState != WorkStateEnum.Write)
            {
                DataProcessingTool.ReverseBit16(ref D200[0], 2, deviceMaching.Turntable.Excute);//转盘位移启动
                if (deviceMaching.RunState != WorkStateEnum.Rest)
                {
                    DataProcessingTool.ReverseBit16(ref D200[0], 3, deviceMaching.Supplyboxs.Excute);//供盒启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 4, deviceMaching.Sealbox.Excute);//封口启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 5, deviceMaching.AdjustmentStations[0].Excute); //1下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 6, deviceMaching.AdjustmentStations[1].Excute); //2下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 7, deviceMaching.AdjustmentStations[2].Excute); //3下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 8, deviceMaching.AdjustmentStations[3].Excute); //4下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 9, deviceMaching.AdjustmentStations[4].Excute); //5下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 10, deviceMaching.AdjustmentStations[5].Excute); //6下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 11, deviceMaching.AdjustmentStations[6].Excute); //7下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 12, deviceMaching.AdjustmentStations[7].Excute); //8下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 13, deviceMaching.Outboxs.Excute);//出盒启动
                    //15写如RFID 数据
                }
            }
            DataProcessingTool.ReverseBit16(ref D200[1], 1, deviceMaching.AdjustmentStations[0].HomeExcute);//1#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 2, deviceMaching.AdjustmentStations[1].HomeExcute);//2#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 3, deviceMaching.AdjustmentStations[2].HomeExcute);//3#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 4, deviceMaching.AdjustmentStations[3].HomeExcute);//4#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 5, deviceMaching.AdjustmentStations[4].HomeExcute);//5#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 6, deviceMaching.AdjustmentStations[5].HomeExcute);//6#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 7, deviceMaching.AdjustmentStations[6].HomeExcute);//7#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 8, deviceMaching.AdjustmentStations[7].HomeExcute);//8#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 9, deviceMaching.Sealbox.HomeExcute);//9#走膜回零
            DataProcessingTool.ReverseBit16(ref D200[1], 10, deviceMaching.Turntable.HomeExcute);//10#转盘回零
            DataProcessingTool.ReverseBit16(ref D200[1], 11, deviceMaching.Supplyboxs.HomeExcute);//11#供盒回零

            D200[2] = (short)deviceMaching.ZmoveNumber;
            D200[3] = (short)deviceMaching.AdjustmentStations[0].Steper;
            D200[4] = (short)deviceMaching.AdjustmentStations[1].Steper;
            D200[5] = (short)deviceMaching.AdjustmentStations[2].Steper;
            D200[6] = (short)deviceMaching.AdjustmentStations[3].Steper;
            D200[7] = (short)deviceMaching.AdjustmentStations[4].Steper;
            D200[8] = (short)deviceMaching.AdjustmentStations[5].Steper;
            D200[9] = (short)deviceMaching.AdjustmentStations[6].Steper;
            D200[10] = (short)deviceMaching.AdjustmentStations[7].Steper;
            D200[11] = (short)(deviceMaching.RestError >> 16);
            D200[12] = (short)(deviceMaching.RestError & 0xFFFF);

            /////上位机读 d250设备 整机  下药 封口 出盒 供盒完成状态   
            ///d251设备单轴回零完成状态   
            /// 称重工位重量D252 D253
            ///称重工位状态 D254
            ///异常状态 256 - D257 
            ///rfid数据D258-D277
            deviceMaching.ExcuteFishState = DataProcessingTool.ByteCheckU16(B250, 9);//完成状态
            deviceMaching.HomeFish = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 1);//整机回零完成
            deviceMaching.Turntable.Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 2);//位移完成
            deviceMaching.Supplyboxs.Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 3);//供盒完成
            deviceMaching.Sealbox.Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 4);//封口完成
            deviceMaching.AdjustmentStations[0].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 5);//下药完成
            deviceMaching.AdjustmentStations[1].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 6);//下药完成
            deviceMaching.AdjustmentStations[2].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 7);//下药完成
            deviceMaching.AdjustmentStations[3].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 8);//下药完成
            deviceMaching.AdjustmentStations[4].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 9);//下药完成
            deviceMaching.AdjustmentStations[5].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 10);//下药完成
            deviceMaching.AdjustmentStations[6].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 11);//下药完成
            deviceMaching.AdjustmentStations[7].Finsh = DataProcessingTool.GetBitValue(deviceMaching.ExcuteFishState, 12);//下药完成
            deviceMaching.Outboxs.Finsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 13);//出盒完成


            deviceMaching.HomeFishState = DataProcessingTool.ByteCheckU16(B250, 9 + 2);//单个回零完成状态
            deviceMaching.AdjustmentStations[0].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 1);//1#下药回零完成
            deviceMaching.AdjustmentStations[1].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 2);//2#下药回零完成
            deviceMaching.AdjustmentStations[2].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 3);//3#下药回零完成
            deviceMaching.AdjustmentStations[3].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 4);//4#下药回零完成
            deviceMaching.AdjustmentStations[4].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 5);//5#下药回零完成
            deviceMaching.AdjustmentStations[5].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 6);//6#下药回零完成
            deviceMaching.AdjustmentStations[6].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 7);//7#下药回零完成
            deviceMaching.AdjustmentStations[7].HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 8);//8#下药回零完成
            deviceMaching.Sealbox.HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 9);//9#走膜回零完成
            deviceMaching.Turntable.HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 10);//10#转盘回零完成
            deviceMaching.Supplyboxs.HomeFinsh = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 11);//11#供盒回零完成
            MachinePublic.Weight = Math.Round((double)(DataProcessingTool.ByteCheck32(B250, 9 + 2 * 2)) / 100, 2); //  称重工位重量D252 D253
            MachinePublic.WeightState = DataProcessingTool.GetBitValue(DataProcessingTool.ByteCheck16(B250, 9 + 2 * 4), 9);//称重工位状态 D254
            deviceMaching.WeighingStation.Weight = MachinePublic.Weight;//  称重工位重量D252 D253

            //异常映射
            deviceMaching.DeviceError = DataProcessingTool.ByteCheckU16(B250, 9 + 2 * 6);//异常状态 256 - D257
            SetError();

            //machineBox.RFID = DataProcessingTool.RfidByteCheck32(B250, 9 + 2 * 8); //rfid数据D258-D277
            deviceMaching.RFID = DataProcessingTool.RfidByteCheck32(B250, 9 + 2 * 8);
            for (int i = 0; i < 8; i++)
            {
                deviceMaching.AdjustmentStations[i].Rfid = deviceMaching.RFID[i];
            }
            deviceMaching.WeighingStation.ReadRfidData = deviceMaching.RFID[8];

            deviceMaching.InX = DataProcessingTool.ByteCheckU16(B250, 9 + 2 * 28);
            deviceMaching.Sealbox.InX1 = DataProcessingTool.GetBitValue(deviceMaching.InX, 0);
            deviceMaching.Sealbox.InX2 = DataProcessingTool.GetBitValue(deviceMaching.InX, 1);
            deviceMaching.Sealbox.InX3 = DataProcessingTool.GetBitValue(deviceMaching.InX, 3);
            deviceMaching.Supplyboxs.InX1 = DataProcessingTool.GetBitValue(deviceMaching.InX, 4);
            deviceMaching.Outboxs.InX = DataProcessingTool.GetBitValue(deviceMaching.InX, 5);
            deviceMaching.Outboxs.HomeX = DataProcessingTool.GetBitValue(deviceMaching.InX, 6);


            ///异常映射

            /// 调试模式数据映射
            if (deviceMaching.WExcute && !deviceMaching.WFish)
            {
                modBusTCP_Cliect.Write_Int16((ushort)(400 + deviceMaching.WDnumber), deviceMaching.WDate);
                deviceMaching.WFish = true;
            }
            if (!deviceMaching.WExcute)
            {
                deviceMaching.WFish = false;
            }
            DataProcessingTool.ReverseBit16(ref D200[0], 15, MachinePublic.WriteRfidExcule);//RFID写
            MachinePublic.WriteRfidFish = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 14);//RFID写入完成
            MachinePublic.WriteRfidError = DataProcessingTool.GetBitValue(deviceMaching.HomeFishState, 15);//RFID写入错误
            if (deviceMaching.RunState == WorkStateEnum.Set)
            {
                deviceMaching.AdjustmentStations[0].HomeData = DataProcessingTool.ByteCheck16(B400, 9);
                deviceMaching.AdjustmentStations[1].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 1);
                deviceMaching.AdjustmentStations[2].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 2);
                deviceMaching.AdjustmentStations[3].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 3);
                deviceMaching.AdjustmentStations[4].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 4);
                deviceMaching.AdjustmentStations[5].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 5);
                deviceMaching.AdjustmentStations[6].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 6);
                deviceMaching.AdjustmentStations[7].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 7);
                deviceMaching.Sealbox.HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 8);
                deviceMaching.Turntable.HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 9);
                deviceMaching.Supplyboxs.HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 10);
                deviceMaching.Sealbox.Data1 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 11);//封口膜检测位
                deviceMaching.Sealbox.Data2 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 12);//封口位
                deviceMaching.Sealbox.Data3 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 13);//退膜长度
                deviceMaching.Sealbox.SealTime = DataProcessingTool.ByteCheckU16(B400, 9 + 2 * 14);//封口延时



                D200[13] = deviceMaching.WoutY;//写输出

                //   MachinePublic.WriteRFIDdate       

                D200[15] = (short)(MachinePublic.WriteRfidData & 0XFFFF);
                D200[14] = (short)(MachinePublic.WriteRfidData >> 16);
            }
        }

        private void SetError() 
        {
            for (int i = 0; i < 16; i++)
            {
                if (DataProcessingTool.GetBitValue(deviceMaching.DeviceError, i) && !deviceMaching.DeviceErrors.Any(x=>x.ErrorType==(DeviceErrorEnum)i))
                {
                    deviceMaching.DeviceErrors.Add(new DeviceError() { ErrorType= (DeviceErrorEnum)i });
                }
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            for (int i = 0; i < 8; i++)
            {
                var btn = FindControlByName<UC_WorkStationButton>($"uC_WorkStationButton{i + 1}");
                if (btn == null) { continue; }
                uC_WorkStationButtons[i] = btn;//FindControlByName<UC_WorkStationButton>($"uC_WorkStationButton{i + 1}");//(UC_WorkStationButton)(Controls.Find($"uC_WorkStationButton1[{i + 1}]", true)[0]);
                uC_WorkStationButtons[i].StationName = $"工位{i + 1}";
                uC_WorkStationButtons[i].ParticName = "无";
                uC_WorkStationButtons[i].Status = StationStatusEnum.无;
                uC_WorkStationButtons[i].ProcessValue = 20;
                uC_WorkStationButtons[i].SetControlValue();
            }

            //供盒
            lblGHZT.Text = "无";
            lblGHYC.Text = "无";
            //封口
            lblFKZT.Text = "无";
            lblFKYC.Text = "无";
            //出盒
            lblCHZT.Text = "无";
            lblCHYC.Text = "无";

            //称重
            stationWeightPaticleName.Text = "无";
            stationWeightStatus.Text = "";
            stationWeightNumber.Text = "0g";
            //正在调剂处方信息
            lblPreId.Text = "无";
            lblPreParticleNum.Text = "0";
            lblPreQuantity.Text = "0";
            lblPreBoxNum.Text = "0";
            //正在调剂处方详情
            if (dgvPreDetail.Rows.Count > 0)
            {
                dgvPreDetail.Rows.Clear();
            }
            //调剂异常信息
            lbOpterMsg.Items.Clear();
            //查询配置信息
            systemParameterList = CommonStaticDataBLL.GetSystemParameterValue();
            //设备异常信息

            try
            {
                Jxssend = new Thread(Jxs);
                Jxssend.IsBackground = true;
                Jxssend.Start();
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }

        /// <summary>
        /// 系统参数校验
        /// </summary>
        /// <returns></returns>
        private string ParamCheck()
        {
            //设备参数信息

            if (systemParameterList == null)
            {
                return "未找到该设备调剂参数信息";
            }
            string paramStr = systemParameterList.FirstOrDefault(x => x.ParameterName == "YaoHeDanGeTiJi")?.ParameterValue;
            if (paramStr != null && double.TryParse(paramStr, out double value1))
            {
                prescriptionFactory.BoxCellVolume = value1;
            }
            else
            {
                return "药盒单格体积参数信息缺失或值无效";
            }
            paramStr = systemParameterList.FirstOrDefault(x => x.ParameterName == "YaoHeLeiXing")?.ParameterValue;
            if (paramStr != null && short.TryParse(paramStr, out short value2))
            {
                prescriptionFactory.BoxType = value2;
            }
            else
            {
                return "药盒类型参数信息缺失或值无效";
            }

            paramStr = systemParameterList.FirstOrDefault(x => x.ParameterName == "TiaoJiFangShi")?.ParameterValue;
            if (paramStr != null && int.TryParse(paramStr, out int value3))
            {
                prescriptionFactory.AdjustWay = value3;
            }
            else
            {
                return "调剂方式参数信息缺失或值无效";
            }
            paramStr = systemParameterList.FirstOrDefault(x => x.ParameterName == "JiLiangDiXian")?.ParameterValue;
            if (paramStr != null && int.TryParse(paramStr, out int value4))
            {
                prescriptionFactory.DoseLimitDown = value4;
            }
            else
            {
                return "剂量底限参数信息缺失或值无效";
            }

            return "";
        }

        // 通用方法来按名称查找控件
        private T FindControlByName<T>(string name) where T : Control
        {
            // 调用Controls.Find方法查找控件
            T control = this.Controls.Find(name, true).FirstOrDefault() as T;
            return control;
        }

        DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
        string fileUrl = Application.StartupPath + "\\testbinfile.bin";

        string selectPreId = "";//选中的处方编号
        private DownLoadPreModel downLoadPreModel { get; set; }//已下载处方文件实体

        /// <summary>
        /// 处方下载控件
        /// </summary>
        private void AddButton()
        {
            //从文件拿取
            //downLoadPreModel.LoadedPreIds = new List<string>() { "60722445406002" };
            //BinFileHelper.WriteObjectToBinaryFile(fileUrl, downLoadPreModel);

            //清除用Clear方法
            uiFlowLayoutPanel1.Clear();
            downLoadPreModel = BinFileHelper.ReadObjectFromBinaryFile<DownLoadPreModel>(fileUrl);
            if (downLoadPreModel == null || downLoadPreModel.LoadedPreIds.Count <= 0)
            {
                downLoadPreModel = new DownLoadPreModel();
                return;
            }
            //获取数据
            var preDatas = _prescriptionAdjustmentBLL.GetDownLoadedPres(downLoadPreModel.LoadedPreIds);
            if (preDatas == null || preDatas.Count <= 0) { return; }

            UC_PreButton btn;
            foreach (var item in preDatas)
            {
                btn = new UC_PreButton();
                string btnText = "处方编号：" + item.PrescriptionID + "\r\n" + $@"患者姓名：" + item.PatientName + "\r\n" + "患者性别：" + item.PatientSex + "\r\n"
                    + "处方付数：" + item.Quantity + "\r\n" + "处方状态：" + item.ProcessStatusText;
                btn.Text = btnText;
                btn.Name = item.PrescriptionID;
                btn.FillEllipseColor = Color.Green;
                btn.FillColor = Color.WhiteSmoke;
                btn.Click += Btn_Click;
                if (item.ProcessStatus == ProcessStatusEnum.待核对)
                {
                    btn.FillEllipseColor = Color.Red;
                }
                //用封装的方法Add
                uiFlowLayoutPanel1.Add(btn);
            }
            this.Render();
        }

        //处方列表处方控件点击事件
        private void Btn_Click(object sender, System.EventArgs e)
        {
            foreach (UC_PreButton item in uiFlowLayoutPanel1.AllControls)
            {
                item.FillColor = Color.WhiteSmoke;
            }
            var button = (UC_PreButton)sender;
            button.FillColor = Color.Silver;
            selectPreId = button.Name;
            //MessageBox.Show(button.Name);
        }

        private void FrmBoxedDevice_Load(object sender, EventArgs e)
        {
            AddButton();
            InitData();

        }

        /// <summary>
        /// 处方下载点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDownLoad_Click(object sender, EventArgs e)
        {
            dataGradeViewUi.FormClose("FrmPrescriptionDownLoad");
            FrmPrescriptionDownLoad frmPrescriptionDownLoad = new FrmPrescriptionDownLoad();
            frmPrescriptionDownLoad.ShowDialog();
            List<string> preIdList = frmPrescriptionDownLoad.loadPrescriptionIdList;
            if (preIdList != null && preIdList.Count > 0)
            {
                if (downLoadPreModel == null)
                {
                    downLoadPreModel = new DownLoadPreModel();
                }

                foreach (var item in preIdList)
                {
                    //写入文件
                    if (downLoadPreModel.LoadedPreIds != null && downLoadPreModel.LoadedPreIds.Count > 0)
                    {
                        if (!downLoadPreModel.LoadedPreIds.Contains(item))
                        {
                            downLoadPreModel.LoadedPreIds.Add(item);
                        }
                    }
                    else
                    {
                        downLoadPreModel.LoadedPreIds = new List<string>();
                        downLoadPreModel.LoadedPreIds.Add(item);
                    }
                }

                //downLoadPreModel.LoadedPreIds.AddRange(downLoadPreModel.LoadedPreIds.Distinct().ToList());
                BinFileHelper.WriteObjectToBinaryFile(fileUrl, downLoadPreModel);
                AddButton();
            }

        }

        /// <summary>
        /// 复位处方事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 复位处方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectPreId == "")
            {
                ShowWarningDialog("异常提示", "请先选择要复位的处方");
                return;
            }
            var isSuccess = _prescriptionAdjustmentBLL.ReturnPrescription(selectPreId);
            if (isSuccess)
            {
                ShowSuccessTip($"处方[{selectPreId}]已成功复位");
                downLoadPreModel.LoadedPreIds.Remove(selectPreId);
                //downLoadPreModel.LoadedPreIds = downLoadPreModel.LoadedPreIds.Distinct().ToList();
                var curCheckPre = downLoadPreModel.CheckedPreInfos.FirstOrDefault(x => x.PrescriptionID == selectPreId);
                if (curCheckPre != null)
                {
                    downLoadPreModel.CheckedPreInfos.Remove(curCheckPre);
                }
                //写入文件
                BinFileHelper.WriteObjectToBinaryFile(fileUrl, downLoadPreModel);

                var btn = uiFlowLayoutPanel1.Get(selectPreId);
                if (btn != null)
                {
                    uiFlowLayoutPanel1.Remove(btn);
                    selectPreId = "";
                }
            }
            else
            {
                ShowErrorDialog("错误提示", $"处方[{selectPreId}]复位失败，请稍后再试");
            }
        }
        /// <summary>
        /// 查看处方签点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPrescriptionPaper_Click(object sender, EventArgs e)
        {
            if (selectPreId == "")
            {
                ShowWarningDialog("异常提示", "请先选择要查看的处方");
                return;
            }
            dataGradeViewUi.FormClose("FrmPrescriptionPaper");
            FrmPrescriptionPaper frmPrescriptionPaper = new FrmPrescriptionPaper(selectPreId);
            frmPrescriptionPaper.Show();
        }
        /// <summary>
        /// 核对处方事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 核对处方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectPreId == "")
            {
                ShowWarningDialog("异常提示", "请先选择要核对的处方");
                return;
            }
            List<string> checkedPreids = _prescriptionAdjustmentBLL.GetConfirmedPrescriptions(downLoadPreModel.LoadedPreIds);
            if (checkedPreids != null && checkedPreids.Contains(selectPreId))
            {
                ShowWarningDialog("异常提示", "该处方已核对，无需再次核对");
                return;
            }
            dataGradeViewUi.FormClose("FrmConfirmPrescription");
            FrmConfirmPrescription frmConfirmPrescription = new FrmConfirmPrescription(selectPreId, checkedPreids);
            frmConfirmPrescription.ShowDialog();
            bool isPassed = frmConfirmPrescription.isConfirmOK;
            if (isPassed)
            {
                ShowSuccessTip($"处方[{selectPreId}]核对成功");
                AddButton();
                //写入到文件
                if (downLoadPreModel == null)
                {
                    downLoadPreModel = new DownLoadPreModel();
                }

                //写入文件
                if (downLoadPreModel.CheckedPreInfos != null && downLoadPreModel.CheckedPreInfos.Count > 0)
                {
                    if (!downLoadPreModel.CheckedPreInfos.Any(x => x.PrescriptionID == frmConfirmPrescription.preModel.PrescriptionID))
                    {
                        downLoadPreModel.CheckedPreInfos.Add(frmConfirmPrescription.preModel);
                    }
                }
                else
                {
                    downLoadPreModel.CheckedPreInfos = new List<PreModel>();
                    downLoadPreModel.CheckedPreInfos.Add(frmConfirmPrescription.preModel);
                }

                BinFileHelper.WriteObjectToBinaryFile(fileUrl, downLoadPreModel);

            }
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 开始调剂事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartRun_Click(object sender, EventArgs e)
        {
            //检查机器可调？
            if (!CheckDeivce())
            {
                return;
            }
            //系统参数校验
            string paramError = ParamCheck();
            if (paramError != null)
            {
                ShowWarningDialog("异常提示", paramError);
                return;
            }
            if (selectPreId == "")
            {
                ShowWarningDialog("异常提示", "请先选择要调剂的处方");
                return;
            }

            if (downLoadPreModel == null)
            {
                downLoadPreModel = BinFileHelper.ReadObjectFromBinaryFile<DownLoadPreModel>(fileUrl);
            }
            if (downLoadPreModel == null || downLoadPreModel.CheckedPreInfos == null || downLoadPreModel.CheckedPreInfos.Count <= 0
                || !downLoadPreModel.CheckedPreInfos.Any(x => x.PrescriptionID == selectPreId))
            {
                ShowWarningDialog("异常提示", "该处方还未核对通过");
                return;
            }

            //获取处方信息
            deviceMaching.PrescriptionInfo = downLoadPreModel.CheckedPreInfos.FirstOrDefault(x => x.PrescriptionID == selectPreId);
            if (deviceMaching.PrescriptionInfo.Details == null || deviceMaching.PrescriptionInfo.Details.Count <= 0)
            {
                ShowWarningDialog("异常提示", "未找到处方颗粒详情信息");
                return;
            }
            //处理处方信息,分盒计算，剂量计算等
            string errorMsg = "";
            deviceMaching.PrescriptionInfo = prescriptionFactory.PrescriptionHandles(deviceMaching.PrescriptionInfo, out errorMsg);
            if (deviceMaching.PrescriptionInfo == null)
            {
                ShowWarningDialog("异常提示", "处方信息检查不通过," + errorMsg);
                return;
            }
            //加载将要调剂处方信息
            lblPreId.Text = deviceMaching.PrescriptionInfo.PrescriptionID;
            lblPreParticleNum.Text = deviceMaching.PrescriptionInfo.DetailedCount.ToString();
            lblPreQuantity.Text = deviceMaching.PrescriptionInfo.Quantity.ToString();
            lblPreBoxNum.Text = deviceMaching.PrescriptionInfo.BoxNumber.ToString();

            deviceMaching.MakePrescriptionParticles = deviceMaching.PrescriptionInfo.Details.Select(x => new MakePrescriptionParticle()
            {
                ParticlesName = x.ParName,
                ParticlesCode = x.ParCode,
                Rfid = x.MedicineCabinetDetail.RFID.Value,
                Dose = x.Dose,
                StationX = x.StationX,
                StationY = x.StationY,
                FishDrugeCount = 0,
                Steper = 0,
                Deduct = false,
                MakeParticleState = MakeParticleStateEnum.待称重,
                CurrentWeightQuantity = 0,
                NewDose = 0,
                Density=x.Density,
                DensityCoefficient=x.DensityCoefficient.Value
            }).ToList();

            dgvPreDetail.DataSource = deviceMaching.MakePrescriptionParticles;

            //亮灯


        }

        /// <summary>
        /// 检查设备状态
        /// </summary>
        private bool CheckDeivce()
        {
            if (deviceMaching.RunState != WorkStateEnum.Work)
            {
                ShowErrorDialog("异常提示", $"设备正处于{StringHelper.GetEnumDescription(deviceMaching.RunState)}状态，无法开始立即调剂");
                return false;
            }
            if (DataProcessingTool.GetBitValue(deviceMaching.DeviceError, 3))
            {
                MessageBox.Show("设备气压不足，无法调剂");
                return false;
            }
            if (DataProcessingTool.GetBitValue(deviceMaching.DeviceError, 4))
            {
                MessageBox.Show("设备封口温度未达到设定值，无法调剂");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设备初始化
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (deviceMaching.RunState == WorkStateEnum.Write)
            {
                deviceMaching.RunState = WorkStateEnum.Home;
                deviceMaching.HomeExcute = true;
                ShowSuccessTip("|设备正在执行初始化...|");
            }
            else
            {
                ShowErrorDialog("错误提示", "设备不处于等待初始化状态");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
            {
                //Form1_Mian.DeviceConnentionState = ModBusTCP_Cliect.ConnState;
                AdjustmentSteps();
                //RFIDstate();
                //backgroundWorker1.ReportProgress(0, ObjMachine);
                //Savemachine(ObjMachine);
                Rfid();
                System.Threading.Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 调剂步骤逻辑
        /// </summary>
        private void AdjustmentSteps()
        {
            switch (deviceMaching.RunState)
            {
                case WorkStateEnum.Home:
                    if (deviceMaching.HomeFish)
                    {
                        deviceMaching.RunState = WorkStateEnum.Work;
                        deviceMaching.HomeExcute = false;
                        deviceMaching.HomeFish = false;
                        //deviceMaching.Turntable.MoveCount = 0;
                    }
                    break;
                case WorkStateEnum.Write:
                    break;
                case WorkStateEnum.Work:
                    AdjustmentStepsWork();
                    break;
                case WorkStateEnum.Density:
                    break;
                case WorkStateEnum.Set://调试
                    AdjustmentStepsSet();
                    break;
                case WorkStateEnum.Rest://恢复
                    break;
            }
        }
        /// <summary>
        /// 调剂逻辑之工作模式
        /// </summary>
        private void AdjustmentStepsWork()
        {
            #region 回零启动重置
            if (deviceMaching.Supplyboxs.HomeFinsh && deviceMaching.Supplyboxs.HomeExcute)
            {
                deviceMaching.Supplyboxs.HomeExcute = false;
            }
            if (deviceMaching.Turntable.HomeFinsh && deviceMaching.Turntable.HomeExcute)
            {
                deviceMaching.Turntable.HomeExcute = false;
            }
            if (deviceMaching.Sealbox.HomeFinsh && deviceMaching.Sealbox.HomeExcute)
            {
                deviceMaching.Sealbox.HomeExcute = false;
            }
            if (deviceMaching.Outboxs.HomeFinsh && deviceMaching.Outboxs.HomeExcute)
            {
                deviceMaching.Outboxs.HomeExcute = false;
            }
            for (int i = 0; i < 8; i++)
            {
                if (deviceMaching.AdjustmentStations[i].HomeFinsh && deviceMaching.AdjustmentStations[i].HomeExcute)
                {
                    deviceMaching.AdjustmentStations[i].HomeExcute = false;
                }
            }
            #endregion

            if (deviceMaching.PrescriptionInfo == null)
            {
                return;
            }
            if (deviceMaching.Extend.BoxProportionInPre == 0)
            {
                deviceMaching.Extend.BoxProportionInPre = 100 / deviceMaching.PrescriptionInfo.BoxNumber.Value; //ObjMachine.BoxCount;//每一个盒子的处方占比
            }
            if (deviceMaching.Extend.BoxFishCount < deviceMaching.PrescriptionInfo.BoxNumber.Value) //判断是否开始进入调剂流程
            {
                deviceMaching.ZmoveNumber = 1;
            }
            if (!deviceMaching.Extend.StartTime.HasValue)
            {
                deviceMaching.Extend.StartTime = DateTime.Now;
            }
            switch (deviceMaching.Extend.WorkStep)
            {
                case 0://转盘位移后执行下盒，下药，封口，出盒等动作
                    {
                        DisplacementExecutionAction();
                        deviceMaching.Extend.WorkStep = 5;
                    }
                    break;
                case 5://判断是否跳转
                    {
                        if (CheckIsHaveHCExcute())
                        {
                            deviceMaching.Extend.WorkStep = 10;
                        }
                        else
                        {
                            deviceMaching.ZmoveNumber++;
                            deviceMaching.Extend.CurrentMoveCount++;
                            deviceMaching.Extend.CanMoveCount1 = deviceMaching.Extend.CanMoveCount % deviceMaching.Extend.MaxBoxCount;
                            deviceMaching.Extend.CanMoveCount = CalculateMoveTimes(); //可以位移次数   
                            if (deviceMaching.Extend.CurrentMoveCount < CalculateMoveTimes())
                            {
                                deviceMaching.Extend.WorkStep = 0;
                            }
                            else
                            {
                                deviceMaching.Extend.WorkStep = 10;
                            }
                        }

                    }
                    break;
                case 10:
                    {
                        if (deviceMaching.ZmoveNumber == 1)
                        {
                            deviceMaching.Extend.WorkStep = 15;
                        }
                        else
                        {
                            deviceMaching.ZmoveNumber--;
                            deviceMaching.Extend.CurrentMoveCount--;
                            deviceMaching.Extend.WorkStep = 40;
                        }
                    }
                    break;
                case 15:
                    {
                        deviceMaching.Outboxs.Excute = deviceMaching.Outboxs.HCExcute; //写入出盒
                        deviceMaching.Sealbox.Excute = deviceMaching.Sealbox.HCExcute;//写入封口
                        deviceMaching.Supplyboxs.Excute = deviceMaching.Supplyboxs.HCExcute; //写入下盒
                        for (int i = 0; i < 8; i++)
                        {
                            deviceMaching.AdjustmentStations[i].Excute = deviceMaching.AdjustmentStations[i].HCExcute;
                        }
                        deviceMaching.Extend.WorkStep = 20;
                    }
                    break;
                case 20:
                    {
                        if (CheckStationFishState()) //判断状态完成
                        {
                            deviceMaching.Outboxs.HCExcute = false;
                            deviceMaching.Sealbox.HCExcute = false;
                            deviceMaching.Supplyboxs.HCExcute = false;
                            for (int i = 0; i < 8; i++)
                            {
                                deviceMaching.AdjustmentStations[i].HCExcute = false;
                            }
                            deviceMaching.Extend.WorkStep = 25;
                        }
                    }
                    break;
                case 25://绑定药盒，计算开仓量
                    {
                        WorkStep25();
                        deviceMaching.Extend.WorkStep = 30;
                    }
                    break;
                case 30://更新调剂工位当前状态判断出是否全部完成 取走药瓶
                    {
                        WorkStep30();
                        deviceMaching.Extend.WorkStep = 35;
                    }
                    break;
                case 35://判断出盒工位药瓶是否完成， 若完成清除当前药盒的信息
                    {
                        //清除下药 清除供盒 清除出盒 清除封口
                        for (int i = 0; i < 8; i++)
                        {
                            if (deviceMaching.AdjustmentStations[i].Excute == true)
                            {
                                deviceMaching.AdjustmentStations[i].Excute = false;
                            }
                        }
                        for (int j = 0; j < 16; j++)
                        {
                            if (deviceMaching.Medboxs[j].OutState)
                            {
                                deviceMaching.Extend.BoxFishCount++;
                                deviceMaching.Medboxs[j] = null;
                            }
                        }
                        if (!CheckDrugeRest())
                        {
                            deviceMaching.Extend.WorkStep = 40;
                        }
                    }
                    break;
                case 40:
                    {
                        //保存
                        //Savemachine(ObjMachine);

                        deviceMaching.Extend.WorkStep = 45;
                    }
                    break;
                case 45://可以位移次数计算
                    {
                        if (!deviceMaching.Stop && deviceMaching.AxisHomeStep == 0)
                        {
                            deviceMaching.Extend.CanMoveCount = CalculateMoveTimes(); //可以位移次数      
                            deviceMaching.Extend.WorkStep = 50;
                        }
                    }
                    break;
                case 50://可以位移次数计算
                    {
                        deviceMaching.Extend.CanMoveCount1 = deviceMaching.Extend.CanMoveCount % deviceMaching.Extend.MaxBoxCount;
                        if (deviceMaching.Extend.CurrentMoveCount < deviceMaching.Extend.CanMoveCount)
                        {
                            deviceMaching.Extend.WorkStep = 55;
                        }
                        else
                        {
                            deviceMaching.Extend.WorkStep = 45;
                        }
                    }
                    break;
                case 55://转盘开始位移
                    {
                        deviceMaching.Turntable.Excute = true;
                        deviceMaching.Extend.WorkStep = 60;
                    }
                    break;
                case 60://转盘位移完成
                    {
                        if (deviceMaching.Turntable.Finsh)
                        {
                            deviceMaching.ZmoveNumber = 1;
                            deviceMaching.Turntable.Excute = false;
                            deviceMaching.Extend.CurrentMoveCount++;
                            deviceMaching.Extend.WorkStep = 65;
                        }
                    }
                    break;
                case 65://判断出盒数量=完成数量 清除当前类
                    {
                        //Savemachine(ObjMachine);
                        if (deviceMaching.Extend.BoxFishCount == deviceMaching.PrescriptionInfo.BoxNumber && deviceMaching.PrescriptionInfo.BoxNumber > 0)
                        {
                            this.Invoke(new Action(() =>
                            {
                                //全部完成，弹出药框
                                Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "FrmOutBox").FirstOrDefault();
                                if (existingForm == null)
                                {
                                    FrmOutBox frmOutBox = new FrmOutBox(deviceMaching.PrescriptionInfo.PrescriptionID, deviceMaching.PrescriptionInfo.BoxNumber.Value, false, true, deviceMaching.Extend.StartTime);
                                    frmOutBox.Show();
                                }
                            }));
                            deviceMaching.Extend.WorkStep = 70;
                        }
                        else
                        {
                            if (deviceMaching.Extend.BoxFishCount % 8 == 0 && deviceMaching.Extend.BoxFishCount > 7 && deviceMaching.Extend.HCBoxFishCount != deviceMaching.Extend.BoxFishCount)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    //全部完成，弹出药框
                                    Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "FrmOutBox").FirstOrDefault();
                                    if (existingForm == null)
                                    {
                                        FrmOutBox frmOutBox = new FrmOutBox(deviceMaching.PrescriptionInfo.PrescriptionID, deviceMaching.PrescriptionInfo.BoxNumber.Value, false, false, null);
                                        frmOutBox.Show();
                                    }
                                }));

                            }
                            else
                            {
                                deviceMaching.Extend.WorkStep = 0;
                            }
                        }
                    }
                    break;
                case 70://清理药盒信息

                    break;
            }
        }

        #region 调剂逻辑方法
        /// <summary>
        /// 转盘位移执行动作
        /// </summary>
        private void DisplacementExecutionAction()
        {
            //转盘位置=当前位移次数+1%16
            deviceMaching.Extend.WheelPositionIndex = deviceMaching.Extend.CurrentMoveCount + 1 % deviceMaching.Extend.MaxBoxCount;

            //下药， 出盒， 封口  , 下盒。计算
            for (int i = 0; i < deviceMaching.Extend.MaxBoxCount; i++) //i为工位序号
            {
                int stationBoxIndex = deviceMaching.AdjustmentStations[i].ExitBoxIndex;
                if (stationBoxIndex < 0)
                {
                    stationBoxIndex = i;
                }
                else
                {
                    stationBoxIndex = 16 - Math.Abs(stationBoxIndex - deviceMaching.Extend.CurrentMoveCount) % 16;
                }
                ////计算的工位对应盒子序号赋值
                deviceMaching.AdjustmentStations[i].ExitBoxIndex = stationBoxIndex;
                if (i == 13) //下盒
                {
                    if (deviceMaching.Extend.BoxSupplyCount < deviceMaching.PrescriptionInfo.BoxNumber.Value && deviceMaching.Medboxs[stationBoxIndex].PrescriptionID == null) //当前下盒数量<处方需要盒数 执行下盒
                    {
                        deviceMaching.Supplyboxs.HCboxIndex = stationBoxIndex;
                        deviceMaching.Supplyboxs.HCExcute = true;
                    }
                }
                if (deviceMaching.Medboxs[stationBoxIndex].ParticlesDetails != null) { continue; }
                if (i < 8)
                {
                    foreach (BoxParticlesDetail detail in deviceMaching.Medboxs[stationBoxIndex].ParticlesDetails)
                    {
                        if (deviceMaching.AdjustmentStations[i].Rfid == detail.Rfid && deviceMaching.AdjustmentStations[i].StationState == StationStatusEnum.待调剂 && !detail.Fish)
                        {
                            deviceMaching.AdjustmentStations[i].HCExcute = true;
                        }
                    }
                }
                if (i == 9)//封口
                {
                    if (deviceMaching.Medboxs[stationBoxIndex].SealState == false && CheckXiaYaoFish(deviceMaching.Medboxs[stationBoxIndex]))
                    {
                        deviceMaching.Sealbox.HCboxIndex = stationBoxIndex;
                        deviceMaching.Sealbox.HCExcute = true;
                    }
                }
                if (i == 11)//出盒
                {
                    if (deviceMaching.Medboxs[stationBoxIndex].OutState == true)
                    {
                        deviceMaching.Outboxs.HCboxIndex = stationBoxIndex;
                        deviceMaching.Outboxs.HCExcute = true;
                    }
                }
            }
        }

        /// <summary>
        /// 下药完成检查
        /// </summary>
        /// <param name="mb">盒子对象</param>
        /// <returns></returns>
        private bool CheckXiaYaoFish(Medbox mb)
        {
            foreach (BoxParticlesDetail detail in mb.ParticlesDetails) //下药完成检查
            {
                if (!detail.Fish)
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
        private bool CheckIsHaveHCExcute()
        {
            if (deviceMaching.Supplyboxs.HCExcute) //下盒完成检查
            {
                return true;
            }
            if (deviceMaching.Sealbox.HCExcute) //封口完成检查
            {
                return true;
            }
            if (deviceMaching.Outboxs.HCExcute) //出盒完成检查
            {
                return true;
            }
            foreach (AdjustmentStation station in deviceMaching.AdjustmentStations) //下药完成检查
            {
                if (station.HCExcute)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 计算可以位移次数
        /// </summary>
        /// <returns></returns>
        private int CalculateMoveTimes() //可以位移次数
        {
            foreach (Medbox medbox in deviceMaching.Medboxs)
            {
                if (medbox.ParticlesDetails == null)
                {
                    continue;
                }
                foreach (BoxParticlesDetail pd in medbox.ParticlesDetails)
                {
                    if (!pd.Fish)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (deviceMaching.AdjustmentStations[i].Rfid == pd.Rfid && deviceMaching.AdjustmentStations[i].StationState == StationStatusEnum.待调剂)
                            {
                                return deviceMaching.Extend.CurrentMoveCount + 1;
                            }
                        }
                    }
                }

                if (medbox.FinishValue >= deviceMaching.PrescriptionInfo.Details.Count)
                {
                    return deviceMaching.Extend.CurrentMoveCount + 1;
                }
            }
            if (deviceMaching.Extend.BoxFishCount == deviceMaching.PrescriptionInfo.BoxNumber)
            {
                return deviceMaching.Extend.CurrentMoveCount + 1;
            }
            if (deviceMaching.Extend.BoxSupplyCount < deviceMaching.PrescriptionInfo.BoxNumber)
            {
                for (int c = 0; c < 16; c++)
                {
                    if (deviceMaching.Medboxs[c].ParticlesDetails == null)
                    {
                        return deviceMaching.Extend.CurrentMoveCount + 1;
                    }
                }
            }

            return deviceMaching.Extend.CurrentMoveCount;
        }

        /// <summary>
        /// 判断所有工位完成状态
        /// </summary>
        /// <returns></returns>
        private bool CheckStationFishState()
        {
            if ((deviceMaching.Supplyboxs.Excute && !deviceMaching.Supplyboxs.Finsh)//下盒完成检查
                || deviceMaching.Sealbox.Excute && !deviceMaching.Sealbox.Finsh //封口完成检查
                || deviceMaching.Outboxs.Excute && !deviceMaching.Outboxs.Finsh) //出盒完成检查 
            {
                return false;
            }
            foreach (AdjustmentStation station in deviceMaching.AdjustmentStations) //下药完成检查
            {
                if (station.Excute && !station.Finsh)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 刷新工位,颗粒状态相关数据
        /// </summary>
        private void WorkStep25()
        {
            double Boxbar = 0;//药盒进度                                    
            if (deviceMaching.Supplyboxs.Excute) //更新药盒供盒信息
            {
                Medbox medbox = new Medbox();
                medbox.PrescriptionID = deviceMaching.PrescriptionInfo.PrescriptionID;
                medbox.SealState = false;
                medbox.OutState = false;

                medbox.ParticlesDetails = deviceMaching.PrescriptionInfo.Details.Select(x => new BoxParticlesDetail() { Steper = x.Steper, Rfid = x.MedicineCabinetDetail.RFID.Value, Fish = false }).ToList();
                deviceMaching.Medboxs[deviceMaching.Supplyboxs.HCboxIndex] = medbox;
                deviceMaching.Extend.BoxSupplyCount++;
                deviceMaching.Supplyboxs.Excute = false;
            }
            for (int i = 0; i < 8; i++) // 更新下药信息 药盒的信息 根据位移次数选择对位信息写入下药	完成状态		
            {
                int index = deviceMaching.AdjustmentStations[i].ExitBoxIndex;
                if (deviceMaching.Medboxs[index].PrescriptionID != null && deviceMaching.AdjustmentStations[i].StationState == StationStatusEnum.待调剂)
                {
                    deviceMaching.Medboxs[index].ParticlesDetails.ForEach(pd =>
                    {
                        if (deviceMaching.AdjustmentStations[i].Rfid == pd.Rfid && deviceMaching.AdjustmentStations[i].Finsh) //如果该工位有该药盒信息写入完成状态
                        {
                            deviceMaching.AdjustmentStations[i].FishDrugeCount++;
                            deviceMaching.Medboxs[index].FinishValue++;
                            pd.Fish = true;
                        }
                    });

                }
                deviceMaching.AdjustmentStations[i - 1].Bar = (int)(Math.Round((Double)(deviceMaching.AdjustmentStations[i - 1].FishDrugeCount / (Double)deviceMaching.PrescriptionInfo.BoxNumber), 3) * 100);
            }
            //封口
            if (deviceMaching.Sealbox.Excute)
            {
                deviceMaching.Medboxs[deviceMaching.Sealbox.HCboxIndex].SealState = true;
                deviceMaching.Sealbox.Excute = false;
            }
            //出盒
            if (deviceMaching.Outboxs.Excute)
            {
                deviceMaching.Medboxs[deviceMaching.Outboxs.HCboxIndex].OutState = true;
                deviceMaching.Outboxs.Excute = false;
            }

            for (int iv = 0; iv < 8; iv++)
            {
                if (deviceMaching.AdjustmentStations[iv].Excute)
                {
                    if (!CheckWeight(deviceMaching.AdjustmentStations[iv])) //检查当前余量是否足够调剂使用
                    {
                        deviceMaching.AdjustmentStations[iv].StationState = StationStatusEnum.药品余量不足;
                    }
                    deviceMaching.AdjustmentStations[iv].Excute = false;
                }
            }
            for (int d = 1; d < 17; d++)//更新进度条
            {
                if (deviceMaching.Medboxs[d].PrescriptionID != null)
                {
                    int c = (int)(deviceMaching.Extend.BoxProportionInPre * Math.Round((Double)(deviceMaching.Medboxs[d].FinishValue + 1) / (Double)(deviceMaching.PrescriptionInfo.Details.Count + 3), 3));
                    Boxbar = c + Boxbar;
                }
            }
            deviceMaching.Extend.ProcessBar = (int)(Boxbar + deviceMaching.Extend.BoxFishCount * deviceMaching.Extend.BoxProportionInPre);
        }

        /// <summary>
        /// 检查工位药瓶余量是否不足
        /// </summary>
        private bool CheckWeight(AdjustmentStation station)
        {
            var dxValueString = systemParameterList.FirstOrDefault(x => x.ParameterName == "KeLiYuLiangXiaXian")?.ParameterValue;
            int dxValue = 0;
            if (dxValue != null && int.TryParse(dxValueString, out int v))
            {
                dxValue = v;
            }
            var particlesDetail = deviceMaching.MakePrescriptionParticles.Where(d => (d.Rfid == station.Rfid)).FirstOrDefault();
            if (particlesDetail.CurrentWeightQuantity < (float)(particlesDetail.NewDose * 2 * (deviceMaching.PrescriptionInfo.BoxNumber.Value - station.FishDrugeCount)) + dxValue && particlesDetail.MakeParticleState != MakeParticleStateEnum.调剂完成)
            {
                particlesDetail.MakeParticleState = MakeParticleStateEnum.待上药;
                particlesDetail.FishDrugeCount = station.FishDrugeCount;

                //本次扣除库存量= 当前下药次数*每格重量*2 -已经扣除的库存量；
                float deductStockWeight = (float)Math.Round(particlesDetail.NewDose * 2 * station.FishDrugeCount - particlesDetail.EarlyDeductionStock, 2);

                string msg = prescriptionFactory.DeductStockStep(particlesDetail.Rfid, deviceMaching.PrescriptionInfo, deductStockWeight);//提前扣除库存
                if (msg == "")
                {
                    particlesDetail.EarlyDeductionStock += deductStockWeight;
                }
                return false;
            }
            return true;
        }


        private void WorkStep30()
        {
            bool isCloseLed = false; //判断是否关闭指示灯
            bool isExitBoxFish = false; //是否有药盒完成下药
            for (int i = 0; i < 8; i++)
            {
                if (deviceMaching.AdjustmentStations[i].Rfid == 0) { continue; }

                bool isHaveParNoComplete = false;//是否存在还未接完药的药盒
                for (int j = 0; j < 16; j++)
                {
                    if (deviceMaching.Medboxs[j].PrescriptionID == null) { continue; }

                    if (deviceMaching.Medboxs[j].FinishValue == deviceMaching.Medboxs[j].ParticlesDetails.Count) { isExitBoxFish = true; }

                    isHaveParNoComplete = deviceMaching.Medboxs[j].ParticlesDetails.Any(x => x.Rfid == deviceMaching.AdjustmentStations[i].Rfid && !x.Fish);
                    if (isHaveParNoComplete) { break; }
                }

                if (!isHaveParNoComplete)
                {
                    continue;
                }
                deviceMaching.AdjustmentStations[i].LockState = false;
                if (isExitBoxFish && deviceMaching.MakePrescriptionParticles.Count != deviceMaching.Extend.BoxSupplyCount)//  摆瓶最后一轮
                {
                    int durgBottleNum = deviceMaching.MakePrescriptionParticles.Count % 8;
                    int a;
                    for (a = 1; a < 9; a++)
                    {
                        if (deviceMaching.AdjustmentStations[a - 1].StationState == StationStatusEnum.待调剂)
                        {
                            a++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (a > durgBottleNum)//当前插瓶数量
                    {
                        deviceMaching.AdjustmentStations[i].LockState = true;
                    }
                    else
                    {

                        deviceMaching.AdjustmentStations[i].LockState = false;
                    }

                }

                if (!deviceMaching.AdjustmentStations[i].LockState || deviceMaching.AdjustmentStations[i].FishDrugeCount == deviceMaching.PrescriptionInfo.BoxNumber)
                {
                    deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.待取走;
                    var particle = deviceMaching.MakePrescriptionParticles.FirstOrDefault(x => x.Rfid == deviceMaching.AdjustmentStations[i].Rfid);
                    if (particle == null) { continue; }

                    if (deviceMaching.PrescriptionInfo.BoxNumber == deviceMaching.Extend.BoxSupplyCount)
                    {
                        if (particle.MakeParticleState != MakeParticleStateEnum.调剂完成)
                        {
                            isCloseLed = true;//关闭指示灯
                            particle.MakeParticleState = MakeParticleStateEnum.调剂完成;    //颗粒设置为调剂完成
                            //扣除库存，写入日志
                            prescriptionFactory.DeductStock(particle.Rfid, deviceMaching.PrescriptionInfo, particle.EarlyDeductionStock);
                        }
                    }
                    else
                    {
                        particle.MakeParticleState = MakeParticleStateEnum.已称重;
                        particle.FishDrugeCount = deviceMaching.AdjustmentStations[i].FishDrugeCount;
                    }
                }
            }

            if (isCloseLed)
            {
                CloseLED(deviceMaching.MakePrescriptionParticles);
            }
        }
        /// <summary>
        /// 关闭灯光
        /// </summary>
        private void CloseLED(List<MakePrescriptionParticle> particles)
        {
            try
            {
                for (int i = 0; i < MachinePublic.WD600.Length; i++)
                {
                    MachinePublic.WD600[i] = 0;
                }
                foreach (MakePrescriptionParticle detail in particles)
                {
                    if (detail.MakeParticleState != MakeParticleStateEnum.调剂完成)
                    {
                        byte DBit = (byte)((detail.StationX) % 16);
                        if (DBit == 0)
                        {
                            DBit = 16;
                        }
                        byte X = (byte)((detail.StationX) / 17);
                        byte Y = (byte)(Convert.ToByte(detail.StationY - 1) * 3);
                        byte H = (byte)(Convert.ToInt16(SysDeviceInfo._currentDeviceInfo.CabinetRowCount) - (detail.StationY - 1));
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
                    }
                }
                int MaxCoordinateX = 48; //灯柜允许最大列
                int Maxnuber = Convert.ToInt16(SysDeviceInfo._currentDeviceInfo.LargeCabinetCount); //大药柜数量
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
                int Minnuber = Convert.ToInt16(SysDeviceInfo._currentDeviceInfo.SmallCabinetCount); //小药柜数量

                if (Minnuber > 0)
                {
                    NowX = Maxnuber * 16;
                    for (int i = 0; i < Minnuber; i++)
                    {
                        {
                            NowX = D600[42 + Maxnuber + i] + NowX;
                            if (NowX <= MaxCoordinateX)
                            {
                                MachinePublic.WD600[42 + Maxnuber + i] = 8;
                            }
                        }
                    }
                }
                MachinePublic.WD600[49] = Convert.ToInt16(MachinePublic.LEDgr);
                MachinePublic.WD600[50] = 1;
                deviceMaching.WriteLed = true;
            }
            catch
            {

            }
        }

        /// <summary>
        /// 检查是否都处于复位状态
        /// </summary>
        /// <returns></returns>
        private bool CheckDrugeRest()
        {
            if (deviceMaching.AdjustmentStations.Any(x => x.Excute || x.Finsh))//下药完成检查
            {
                return true;
            }

            if (deviceMaching.Supplyboxs.Excute || deviceMaching.Supplyboxs.Finsh//下盒完成检查
                || deviceMaching.Sealbox.Excute || deviceMaching.Sealbox.Finsh//封口完成检查
                || deviceMaching.Outboxs.Excute || deviceMaching.Outboxs.Finsh)  //出盒完成检查
            {
                return true;
            }

            return false;
        }
        #endregion


        /// <summary>
        ///  调剂逻辑之调试模式
        /// </summary>
        private void AdjustmentStepsSet()
        {
            if (deviceMaching.Sealbox.Finsh && deviceMaching.Sealbox.Excute)
            {
                deviceMaching.Sealbox.Excute = false;
            }
            if (deviceMaching.Supplyboxs.Finsh && deviceMaching.Supplyboxs.Excute)
            {
                deviceMaching.Supplyboxs.Excute = false;
            }
            if (deviceMaching.Turntable.Finsh && deviceMaching.Turntable.Excute)
            {
                deviceMaching.Turntable.Excute = false;
            }
            if (deviceMaching.Outboxs.Finsh && deviceMaching.Outboxs.Excute)
            {
                deviceMaching.Outboxs.Excute = false;
            }
            for (int c = 0; c < 8; c++)
            {
                if (deviceMaching.AdjustmentStations[c].Finsh && deviceMaching.AdjustmentStations[c].Excute)
                {
                    deviceMaching.AdjustmentStations[c].Excute = false;
                }
            }
        }

        #region 界面刷新
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FrmRash();
        }

        private void FrmRash()
        {
            if (deviceMaching==null) { return; }

            #region 运行状态
            string hcDeviceState = "";
            if (deviceMaching.RunState == WorkStateEnum.Write)
            {
                hcDeviceState = "运行状态：等待初始化 ";
            }
            if (deviceMaching.RunState == WorkStateEnum.Home)
            {
                hcDeviceState = "运行状态：回零中 ";
            }
            if (deviceMaching.RunState == WorkStateEnum.Density)
            {
                hcDeviceState = "运行状态：密度测量中 ";
            }
            if (deviceMaching.RunState == WorkStateEnum.Set)
            {
                hcDeviceState = "运行状态：设备调试中 ";
            }
            if (deviceMaching.RunState == WorkStateEnum.Work)
            {
                if (deviceMaching.PrescriptionInfo == null)
                {
                    hcDeviceState = "运行状态：等待调剂 ";
                }
                else
                {
                    hcDeviceState = "运行状态：调剂中 ";
                    lblPreBoxNum.Text = deviceMaching.PrescriptionInfo.BoxNumber * 2 + "盒";
                }

                if (deviceMaching.Stop)
                {
                    hcDeviceState += "(设备已暂停)";
                }
            }
            if (hcDeviceState != lblRunStatus.Text)
            {
                lblRunStatus.Text = hcDeviceState;
            }
            #endregion

            #region 总进度
            //总进度
            if (deviceMaching.Extend.ProcessBar < 101 && deviceMaching.Extend.ProcessBar >= 0)
            {
                preRoundProcess.Value = deviceMaching.Extend.ProcessBar;

            }
            #endregion

            #region 表格状态
            //修改表格状态
            if (deviceMaching.MakePrescriptionParticles != null && deviceMaching.MakePrescriptionParticles.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPreDetail.Rows)
                {
                    var partic = deviceMaching.MakePrescriptionParticles.FirstOrDefault(x => x.ParticlesName == row.Cells["ParticlesName"].Value.ToString());
                    if (partic == null || partic.StatusText == row.Cells["StatusText"].Value.ToString()) { continue; }

                    Color color = GetRowColor(partic.MakeParticleState);
                    row.Cells["ParticlesName"].Value = partic.StatusText;
                    row.DefaultCellStyle.BackColor = color;
                }
            }
            #endregion

            #region 工位信息
            for (int i = 0; i < 8; i++)//修改工位状态
            {
                //MonterEorr(ObjMachine);//获取设备错误信息
                if (!string.IsNullOrEmpty(deviceMaching.AdjustmentStations[i].ParticlesName) && deviceMaching.AdjustmentStations[i].ParticlesName != uC_WorkStationButtons[i].ParticName)
                {
                    uC_WorkStationButtons[i].ParticName = deviceMaching.AdjustmentStations[i].ParticlesName;
                }
                if (string.IsNullOrEmpty(deviceMaching.AdjustmentStations[i].ParticlesName) && uC_WorkStationButtons[i].ParticName != "无")
                {
                    uC_WorkStationButtons[i].ParticName = "无";
                }
                if (deviceMaching.AdjustmentStations[i].StationState != uC_WorkStationButtons[i].Status)
                {
                    uC_WorkStationButtons[i].Status = deviceMaching.AdjustmentStations[i].StationState;
                }
                if (deviceMaching.AdjustmentStations[i].Bar < 101 && uC_WorkStationButtons[i].ProcessValue != deviceMaching.AdjustmentStations[i].Bar)
                {
                    uC_WorkStationButtons[i].ProcessValue = deviceMaching.AdjustmentStations[i].Bar;
                }
            }

            //总进度信息
            if (deviceMaching.Extend.ProcessBar<101 && preRoundProcess.Value!= deviceMaching.Extend.ProcessBar) 
            {
                preRoundProcess.Value = deviceMaching.Extend.ProcessBar;

            }
            #endregion

            #region 异常信息
            if (deviceMaching.DeviceErrors!=null && deviceMaching.DeviceErrors.Count>0) 
            {
                List<string> strings = new List<string>();
                if (dgvDeviceError.Rows.Count>0) {
                    foreach (DataGridViewRow row in dgvDeviceError.Rows)
                    {
                        strings.Add(row.Cells["ErrorDecript"].Value.ToString());
                    }
                }
                foreach (DeviceError item in deviceMaching.DeviceErrors)
                {
                    if (strings==null || strings.Count<=0  || !strings.Contains(item.ErrorDecript)) 
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        int j = dgvDeviceError.Rows.Add(row);
                        dgvDeviceError.Rows[j].Cells[0].Value = item.ErrorType;
                        dgvDeviceError.Rows[j].Cells[1].Value = item.ErrorDecript;
                    }
                }
            }
            #endregion

            #region 供盒，封口，出盒，称重工位
            if (deviceMaching.Supplyboxs.Excute)
            {
                List<DeviceErrorEnum> xiaHe = new List<DeviceErrorEnum>() { DeviceErrorEnum.下盒位有药盒, DeviceErrorEnum.下盒失败 };
                if (deviceMaching.DeviceErrors.Any(x => xiaHe.Contains(x.ErrorType)))
                {
                    if (lblGHZT.Text != "供盒异常") { lblGHZT.Text = "供盒异常"; }
                    string errorText = string.Join(",", deviceMaching.DeviceErrors.Where(x => xiaHe.Contains(x.ErrorType)).Select(x => x.ErrorDecript).ToList());
                    if (lblGHYC.Text != errorText) { lblGHYC.Text = errorText; }
                }
                else 
                {
                    if (lblGHZT.Text != "正在供盒") { lblGHZT.Text = "正在供盒"; }
                    if (lblGHYC.Text != "无") { lblGHYC.Text = "无"; }
                }
            }
            else 
            {
                if (lblGHZT.Text!="等待供盒") { lblGHZT.Text = "等待供盒";}
            }

            if (deviceMaching.Sealbox.Excute)
            {
                List<DeviceErrorEnum> fengKou = new List<DeviceErrorEnum>() { DeviceErrorEnum.封口交流电机回零超时, DeviceErrorEnum.封口位没药盒, DeviceErrorEnum.封口未达到封口温度, DeviceErrorEnum.封口机膜到位信号异常 };
                if (deviceMaching.DeviceErrors.Any(x => fengKou.Contains(x.ErrorType)))
                {
                    if (lblGHZT.Text != "封口异常") { lblGHZT.Text = "封口异常"; }
                    string errorText = string.Join(",", deviceMaching.DeviceErrors.Where(x => fengKou.Contains(x.ErrorType)).Select(x => x.ErrorDecript).ToList());
                    if (lblGHYC.Text != errorText) { lblGHYC.Text = errorText; }
                }
                else
                {
                    if (lblGHZT.Text != "正在封口") { lblGHZT.Text = "正在封口"; }
                    if (lblGHYC.Text != "无") { lblGHYC.Text = "无"; }
                }
            }
            else
            {
                if (lblGHZT.Text != "等待封口"){ lblGHZT.Text = "等待封口"; }
            }

            if (deviceMaching.Outboxs.Excute)
            {
                List<DeviceErrorEnum> chuHe = new List<DeviceErrorEnum>() { DeviceErrorEnum.出盒交流电机回零超时, DeviceErrorEnum.出盒失败, DeviceErrorEnum.出盒电机超时};
                if (deviceMaching.DeviceErrors.Any(x => chuHe.Contains(x.ErrorType)))
                {
                    if (lblGHZT.Text != "出盒异常") { lblGHZT.Text = "出盒异常"; }
                    string errorText = string.Join(",", deviceMaching.DeviceErrors.Where(x => chuHe.Contains(x.ErrorType)).Select(x => x.ErrorDecript).ToList());
                    if (lblGHYC.Text != errorText) { lblGHYC.Text = errorText; }
                }
                else
                {
                    if (lblGHZT.Text != "正在出盒") { lblGHZT.Text = "正在出盒"; }
                    if (lblGHYC.Text != "无") { lblGHYC.Text = "无"; }
                }
            }
            else
            {
                if (lblGHZT.Text != "等待出盒") { lblGHZT.Text = "等待出盒"; }
            }

            if (deviceMaching.WeighingStation!=null) 
            {
                if (stationWeightPaticleName.Text != deviceMaching.WeighingStation.ParticlesName) { stationWeightPaticleName.Text = deviceMaching.WeighingStation.ParticlesName; }

                if (stationWeightStatus.Text != deviceMaching.WeighingStation.StateText) { stationWeightStatus.Text = deviceMaching.WeighingStation.StateText; }
                
                if (stationWeightNumber.Text != deviceMaching.WeighingStation.Weight + "g") { stationWeightNumber.Text = deviceMaching.WeighingStation.Weight + "g"; }
            }

            #endregion


        }

        /// <summary>
        /// 获取行状态
        /// </summary>
        private Color GetRowColor(MakeParticleStateEnum state)
        {
            Color color = new Color(); //表格行颜色
            switch (state)
            {
                case MakeParticleStateEnum.无:
                    {
                        color = Color.White;
                    }
                    break;
                case MakeParticleStateEnum.待称重:
                    {
                        color = Color.White;
                    }
                    break;

                case MakeParticleStateEnum.已称重:
                    {
                      color = Color.HotPink;
                    }
                    break;
                case MakeParticleStateEnum.调剂中:
                    {
                       color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
                    }
                    break;


                case MakeParticleStateEnum.调剂完成:
                    {
                        color = Color.Yellow;
                    }
                    break;

                case MakeParticleStateEnum.待上药:
                    {
                        color = Color.Red;
                    }
                    break;
            }
            return color;
        }

        #endregion

        #region rfid读取
        private void Rfid() 
        {
            MachinePublic.ReadRfidData = deviceMaching.WeighingStation.ReadRfidData;

            #region 下药工位
            for (int i = 0; i < 8; i++) //RFID数据的获取
            {
                if (deviceMaching.AdjustmentStations[i].Rfid == -1) //调剂工位数据清除
                {
                    deviceMaching.AdjustmentStations[i] = new AdjustmentStation();
                }
                else 
                {
                    string pname = "";
                    if (deviceMaching.PrescriptionInfo == null)
                    {
                        deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.无;
                    }
                    else 
                    {
                        var  partic = deviceMaching.MakePrescriptionParticles.FirstOrDefault(x => x.Rfid == deviceMaching.AdjustmentStations[i].Rfid);
                        if (partic == null)
                        {
                            deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.非处方药品;
                            var partic1 = commonDataBLL.GetParticlesInfo(deviceMaching.WeighingStation.ReadRfidData);
                            pname = partic1.Name;
                        }
                        else 
                        {
                            deviceMaching.AdjustmentStations[i].Steper = partic.Steper;
                            pname = partic.ParticlesName;

                            if (partic.MakeParticleState== MakeParticleStateEnum.已称重) 
                            {
                                partic.MakeParticleState = MakeParticleStateEnum.待调剂;
                                deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.待调剂;
                            }
                            if (deviceMaching.AdjustmentStations[i].FishDrugeCount>0 && deviceMaching.AdjustmentStations[i].FishDrugeCount!=deviceMaching.PrescriptionInfo.BoxNumber)
                            {
                                if (CheckBoxsDurgFinish(deviceMaching.AdjustmentStations[i].Rfid))
                                {
                                    partic.MakeParticleState = MakeParticleStateEnum.待取出;
                                    deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.待取走;
                                }
                                else
                                {
                                    partic.MakeParticleState = MakeParticleStateEnum.调剂中;
                                    deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.调剂中;
                                }
                            }

                            if (deviceMaching.AdjustmentStations[i].FishDrugeCount != deviceMaching.PrescriptionInfo.BoxNumber) 
                            {
                                partic.MakeParticleState = MakeParticleStateEnum.调剂完成;
                                deviceMaching.AdjustmentStations[i].StationState = StationStatusEnum.调剂完成;
                            }

                        }
                    }
                    deviceMaching.AdjustmentStations[i].ParticlesName = pname;
                }
            }
            #endregion

            #region 称重工位
            if (!MachinePublic.WeightState && MachinePublic.Weight <200) { return; }

            if (deviceMaching.WeighingStation.ReadRfidData == -1)
            {
                deviceMaching.WeighingStation = new WeighingStation();
                return;
            }

            //没有处方？如下操作
            if (deviceMaching.PrescriptionInfo==null)
            {
                var partic = commonDataBLL.GetParticlesInfo(deviceMaching.WeighingStation.ReadRfidData);
                if (partic != null)
                {
                    Speak(partic.Name);
                }
                else 
                {
                    Speak("该药品不存在");
                }
                //获取药柜信息，用于亮灯
                var mcDetailInfo = commonDataBLL.GetMedicineCabinetDetail(deviceMaching.WeighingStation.ReadRfidData);
                if (mcDetailInfo != null) 
                {
                    LEDlight(mcDetailInfo.CoordinateX, mcDetailInfo.CoordinateY);
                }
                return;
            }

            //有处方，如下操作
            string parName = "";//颗粒名称
            //处方中查找颗粒,是否存在?
            var particlesDetail = deviceMaching.MakePrescriptionParticles.FirstOrDefault(d => d.Rfid == deviceMaching.WeighingStation.ReadRfidData);

            if (particlesDetail != null)
            {
                parName = particlesDetail.ParticlesName;
            }
            else 
            {
                var partic = commonDataBLL.GetParticlesInfo(deviceMaching.WeighingStation.ReadRfidData);
                if (partic != null) { parName = partic.Name; }

                deviceMaching.WeighingStation.State = WeighingStationStatueEnum.非处方药品;
            }
            if (string.IsNullOrEmpty(parName))
            {
                Speak("该药品不存在");
                return;
            }
            Speak(parName);
            if (deviceMaching.WeighingStation.State == WeighingStationStatueEnum.非处方药品) 
            {
                Speak("非处方药品");
                return;
            }

            if (particlesDetail.MakeParticleState != MakeParticleStateEnum.待称重)
            {
                Speak("该药品已称重");
                return;
            }

            particlesDetail.MakeParticleState = MakeParticleStateEnum.已称重;

            //获取药柜信息
            var mcDetail1 = commonDataBLL.GetMedicineCabinetDetail(deviceMaching.WeighingStation.ReadRfidData);

            #region 计算当前称重
            if (mcDetail1 != null)
            {
                deviceMaching.WeighingStation.Weight = Convert.ToSingle(Math.Round(MachinePublic.Weight - mcDetail1.EmptyBottleWeight.Value, 1));
            }
            else
            {
                var kongPingZhongLiangStr = systemParameterList.FirstOrDefault(x => x.ParameterName == "KongPingZhongLiang")?.ParameterValue;
                double kongPingZhongLiang = 200;
                if (string.IsNullOrEmpty(kongPingZhongLiangStr) && double.TryParse(kongPingZhongLiangStr, out double s))
                {
                    kongPingZhongLiang = s;
                }
                deviceMaching.WeighingStation.Weight = Convert.ToSingle(Math.Round(MachinePublic.Weight - kongPingZhongLiang, 1));
            }
            #endregion

            particlesDetail.CurrentWeightQuantity = (float)deviceMaching.WeighingStation.Weight;

            //数据检查
            if (!CheckParticlesDetail(ref mcDetail1, particlesDetail))
            {
                return;
            }

            int steper =prescriptionFactory.DataHandles(ref mcDetail1, particlesDetail,deviceMaching.PrescriptionInfo.BoxNumber.Value);
            if (steper==0) { return; }

            particlesDetail.Steper=steper;


            #endregion
        }

        /// <summary>
        /// 判断工位颗粒的本次所有药盒颗粒是否调剂完成
        /// </summary>
        /// <param name="Station"></param>
        /// <returns></returns>
        private bool CheckBoxsDurgFinish(int rfid) //判断工位颗粒的本次所有药盒颗粒是否调剂完成
        {
            var boxs= deviceMaching.Medboxs.Where(x => x.PrescriptionID == deviceMaching.PrescriptionInfo.PrescriptionID).ToList();
            foreach (var item in boxs)
            {
                if (item.ParticlesDetails.Any(x=>x.Rfid== rfid && !x.Fish)) 
                { 
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// 放入称重工位数据检查
        /// </summary>
        /// <param name="Detai"></param>
        /// <returns></returns>
        private bool CheckParticlesDetail(ref MedicineCabinetDetail mcDetail, MakePrescriptionParticle preParticle)
        {
            if (mcDetail.Stock - preParticle.CurrentWeightQuantity > 15 || preParticle.CurrentWeightQuantity - mcDetail.Stock > 10) //用量=0 ，误差量
            {
                string strMsg = $"检测到颗粒{preParticle.ParticlesName}有未倒入药品操作，是否将库存校准到{preParticle.CurrentWeightQuantity}g?";
                if (preParticle.CurrentWeightQuantity - mcDetail.Stock > 10) 
                {
                    strMsg = $"检测到颗粒{preParticle.ParticlesName}有倒入药品后未更新库存操作，是否库将存校准到{preParticle.CurrentWeightQuantity}g?";
                }
                var anster= ShowAskDialog("警告!", strMsg, UIStyle.Blue, false, UIMessageDialogButtons.Ok);
                if (!anster) { return false; }

                double labAddWeight = Math.Round(preParticle.CurrentWeightQuantity - mcDetail.Stock.Value, 2);//上药量，此时是负数

                MedicineCabinetOperationLogInfo parLog = new MedicineCabinetOperationLogInfo();
                //写上药日志信息
                parLog.DeviceName = SysDeviceInfo._currentDeviceInfo.DeviceName;
                parLog.MedicineCabinetCode = SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode;
                parLog.CreateTime = DateTime.Now;
                parLog.ParticleCode = preParticle.ParticlesCode;
                parLog.ParticleId = mcDetail.RFID.Value;
                parLog.ParticleName = preParticle.ParticlesName;//item.ParName + (int)item.MedicineCabinetDetail?.RFID % 10000;
                parLog.InitialQuantity = mcDetail.Stock.Value;
                parLog.CurrentWeightQuantity = preParticle.CurrentWeightQuantity;
                parLog.MedicineCabinetOperationLogType = MedicineCabinetOperationLogTypeEnum.添加药品;
                parLog.UsedQuantity = 0;
                parLog.AddQuantity = (float)labAddWeight;
                parLog.AdjustmentQuantity = 0;
                parLog.OperationLogDecribe = strMsg;

                mcDetail.Stock = preParticle.CurrentWeightQuantity;

                //扣除库存
                var result = _prescriptionAdjustmentBLL.UpdateMedicineAndLog(new List<MedicineCabinetDetail>() { mcDetail }, new List<MedicineCabinetOperationLogInfo>() { parLog });
                if (result == "")
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            //调整范围
            if (Math.Abs(1 - mcDetail.DensityCoefficient.Value) > 0.2)
            {
                ShowInfoDialog("重要提示!", $"当前颗粒偏差较大,请重新测密度或更换瓶头!");
                return false;

            }
            //设置当前状态已称重 并将计算步数
            if (preParticle.CurrentWeightQuantity < preParticle.NewDose * 2)
            {
                ShowInfoDialog("警告!", $"颗粒" + preParticle.ParticlesName + "当前重量已经不足以调剂一剂药，无法进行调剂!");
                return false;
            }
            
            //判断称重量
            if (preParticle.CurrentWeightQuantity < 10)
            {
                ShowInfoDialog("警告!", $"颗粒" + preParticle.ParticlesName + "当前重量已经低于10克，无法进行调剂!");
                return false;              
            }

            return true;

        }
        /// <summary>
        /// 语音播报
        /// </summary>
        /// <param name="message">语音文字</param>
        private void Speak(string message)
        {
            using (var synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Speak(message);
            }
        }

        /// <summary>
        /// 药柜等点亮 或熄灭
        /// </summary>
        /// <param name="Cab"></param>
        public static void LEDlight(int x,int y)
        {
            for (int i = 0; i < MachinePublic.WD600.Length; i++)
            {
                MachinePublic.WD600[i] = 0;
            }


            byte DBit = (byte)((x) % 16);
            if (DBit == 0)
            {
                DBit = 16;
            }
            byte X = (byte)((x) / 17);
            byte Y = (byte)(Convert.ToByte(y - 1) * 3);
            byte H = (byte)(Convert.ToInt16(14) - (y - 1));
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
            int Maxnuber = Convert.ToInt16(SysDeviceInfo._currentDeviceInfo.LargeCabinetCount); //大药柜数量
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
            int Minnuber = Convert.ToInt16(SysDeviceInfo._currentDeviceInfo.SmallCabinetCount); //小药柜数量

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
        }
        #endregion

    }
}
