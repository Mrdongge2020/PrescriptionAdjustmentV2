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

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmBoxedDevice : UIPage
    {
        //public static MachineBox machineBox = new MachineBox();//设备类
        public static Int16[] D600 = new Int16[28];
        public byte[] B400 = new byte[40];
        public Int16[] D200 = new Int16[20];
        public byte[] B250 = new byte[24];

        List<bool> BoxDfstate = new List<bool>();
        Thread Jxssend;
        ModBusTCP_Cliect modBusTCP_Cliect = new ModBusTCP_Cliect();
        PrescriptionFactory prescriptionFactory = new PrescriptionFactory();
        public static PreModel prescriptionModel = new PreModel();//调剂中的处方
        public static BoxedDeviceModel boxedDeviceModel = new BoxedDeviceModel();

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
                    if (boxedDeviceModel.RunState == WorkStateEnum.Set)
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
            DataProcessingTool.ReverseBit16(ref D200[0], 1, boxedDeviceModel.HomeExcute);//整机回零启动
            if (boxedDeviceModel.RunState != WorkStateEnum.Write)
            {
                DataProcessingTool.ReverseBit16(ref D200[0], 2, boxedDeviceModel.Turntable.Excute);//转盘位移启动
                if (boxedDeviceModel.RunState != WorkStateEnum.Rest)
                {
                    DataProcessingTool.ReverseBit16(ref D200[0], 3, boxedDeviceModel.Supplyboxs.Excute);//供盒启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 4, boxedDeviceModel.Sealbox.Excute);//封口启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 5, boxedDeviceModel.AdjustmentStations[0].Excute); //1下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 6, boxedDeviceModel.AdjustmentStations[1].Excute); //2下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 7, boxedDeviceModel.AdjustmentStations[2].Excute); //3下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 8, boxedDeviceModel.AdjustmentStations[3].Excute); //4下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 9, boxedDeviceModel.AdjustmentStations[4].Excute); //5下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 10, boxedDeviceModel.AdjustmentStations[5].Excute); //6下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 11, boxedDeviceModel.AdjustmentStations[6].Excute); //7下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 12, boxedDeviceModel.AdjustmentStations[7].Excute); //8下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 13, boxedDeviceModel.Outboxs.Excute);//出盒启动
                    //15写如RFID 数据
                }
            }
            DataProcessingTool.ReverseBit16(ref D200[1], 1, boxedDeviceModel.AdjustmentStations[0].HomeExcute);//1#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 2, boxedDeviceModel.AdjustmentStations[1].HomeExcute);//2#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 3, boxedDeviceModel.AdjustmentStations[2].HomeExcute);//3#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 4, boxedDeviceModel.AdjustmentStations[3].HomeExcute);//4#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 5, boxedDeviceModel.AdjustmentStations[4].HomeExcute);//5#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 6, boxedDeviceModel.AdjustmentStations[5].HomeExcute);//6#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 7, boxedDeviceModel.AdjustmentStations[6].HomeExcute);//7#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 8, boxedDeviceModel.AdjustmentStations[7].HomeExcute);//8#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 9, boxedDeviceModel.Sealbox.HomeExcute);//9#走膜回零
            DataProcessingTool.ReverseBit16(ref D200[1], 10, boxedDeviceModel.Turntable.HomeExcute);//10#转盘回零
            DataProcessingTool.ReverseBit16(ref D200[1], 11, boxedDeviceModel.Supplyboxs.HomeExcute);//11#供盒回零

            D200[2] = (short)boxedDeviceModel.ZmoveNumber;
            D200[3] = (short)boxedDeviceModel.AdjustmentStations[0].Data1;
            D200[4] = (short)boxedDeviceModel.AdjustmentStations[1].Data1;
            D200[5] = (short)boxedDeviceModel.AdjustmentStations[2].Data1;
            D200[6] = (short)boxedDeviceModel.AdjustmentStations[3].Data1;
            D200[7] = (short)boxedDeviceModel.AdjustmentStations[4].Data1;
            D200[8] = (short)boxedDeviceModel.AdjustmentStations[5].Data1;
            D200[9] = (short)boxedDeviceModel.AdjustmentStations[6].Data1;
            D200[10] = (short)boxedDeviceModel.AdjustmentStations[7].Data1;
            D200[11] = (short)(boxedDeviceModel.RestError >> 16);
            D200[12] = (short)(boxedDeviceModel.RestError & 0xFFFF);

            /////上位机读 d250设备 整机  下药 封口 出盒 供盒完成状态   
            ///d251设备单轴回零完成状态   
            /// 称重工位重量D252 D253
            ///称重工位状态 D254
            ///异常状态 256 - D257 
            ///rfid数据D258-D277
            boxedDeviceModel.ExcuteFishState = DataProcessingTool.ByteCheckU16(B250, 9);//完成状态
            boxedDeviceModel.HomeFish = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 1);//整机回零完成
            boxedDeviceModel.Turntable.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 2);//位移完成
            boxedDeviceModel.Supplyboxs.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 3);//供盒完成
            boxedDeviceModel.Sealbox.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 4);//封口完成
            boxedDeviceModel.AdjustmentStations[0].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 5);//下药完成
            boxedDeviceModel.AdjustmentStations[1].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 6);//下药完成
            boxedDeviceModel.AdjustmentStations[2].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 7);//下药完成
            boxedDeviceModel.AdjustmentStations[3].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 8);//下药完成
            boxedDeviceModel.AdjustmentStations[4].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 9);//下药完成
            boxedDeviceModel.AdjustmentStations[5].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 10);//下药完成
            boxedDeviceModel.AdjustmentStations[6].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 11);//下药完成
            boxedDeviceModel.AdjustmentStations[7].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.ExcuteFishState, 12);//下药完成
            boxedDeviceModel.Outboxs.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 13);//出盒完成


            boxedDeviceModel.HomeFishState = DataProcessingTool.ByteCheckU16(B250, 9 + 2);//单个回零完成状态
            boxedDeviceModel.AdjustmentStations[0].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 1);//1#下药回零完成
            boxedDeviceModel.AdjustmentStations[1].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 2);//2#下药回零完成
            boxedDeviceModel.AdjustmentStations[2].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 3);//3#下药回零完成
            boxedDeviceModel.AdjustmentStations[3].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 4);//4#下药回零完成
            boxedDeviceModel.AdjustmentStations[4].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 5);//5#下药回零完成
            boxedDeviceModel.AdjustmentStations[5].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 6);//6#下药回零完成
            boxedDeviceModel.AdjustmentStations[6].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 7);//7#下药回零完成
            boxedDeviceModel.AdjustmentStations[7].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 8);//8#下药回零完成
            boxedDeviceModel.Sealbox.HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 9);//9#走膜回零完成
            boxedDeviceModel.Turntable.HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 10);//10#转盘回零完成
            boxedDeviceModel.Supplyboxs.HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 11);//11#供盒回零完成
            MachinePublic.Weight = Math.Round((double)(DataProcessingTool.ByteCheck32(B250, 9 + 2 * 2)) / 100, 2); //  称重工位重量D252 D253
            MachinePublic.WeightState = DataProcessingTool.GetBitValue(DataProcessingTool.ByteCheck16(B250, 9 + 2 * 4), 9);//称重工位状态 D254
            boxedDeviceModel.DeviceError = DataProcessingTool.ByteCheckU16(B250, 9 + 2 * 6);//异常状态 256 - D257
            //异常映射
            //DataProcessingTool.ReverseBit16(ref boxedDeviceModel.Sealbox.Error, 1, DataProcessingTool.GetBitValue(boxedDeviceModel.DeviceError, 0));
            //DataProcessingTool.ReverseBit16(ref boxedDeviceModel.Sealbox.Error, 2, DataProcessingTool.GetBitValue(boxedDeviceModel.DeviceError, 0));
            //boxedDeviceModel.Sealbox.Error = DataProcessingTool.GetBitValue(boxedDeviceModel.DeviceError,0);
            //machineBox.RFID = DataProcessingTool.RfidByteCheck32(B250, 9 + 2 * 8); //rfid数据D258-D277
            boxedDeviceModel.RFID = DataProcessingTool.RfidByteCheck32(B250, 9 + 2 * 8);
            for (int i = 0; i < 8; i++)
            {
                boxedDeviceModel.AdjustmentStations[i].RfidData = boxedDeviceModel.RFID[i];
            }
            boxedDeviceModel.WeighingStation.ReadRfidData = boxedDeviceModel.RFID[8];
            boxedDeviceModel.InX = DataProcessingTool.ByteCheckU16(B250, 9 + 2 * 28);
            boxedDeviceModel.Sealbox.InX1 = DataProcessingTool.GetBitValue(boxedDeviceModel.InX, 0);
            boxedDeviceModel.Sealbox.InX2 = DataProcessingTool.GetBitValue(boxedDeviceModel.InX, 1);
            boxedDeviceModel.Sealbox.InX3 = DataProcessingTool.GetBitValue(boxedDeviceModel.InX, 3);
            boxedDeviceModel.Supplyboxs.InX1 = DataProcessingTool.GetBitValue(boxedDeviceModel.InX, 4);
            boxedDeviceModel.Outboxs.InX = DataProcessingTool.GetBitValue(boxedDeviceModel.InX, 5);
            boxedDeviceModel.Outboxs.HomeX = DataProcessingTool.GetBitValue(boxedDeviceModel.InX, 6);


            ///异常映射

            /// 调试模式数据映射
            if (boxedDeviceModel.WExcute && !boxedDeviceModel.WFish)
            {
                modBusTCP_Cliect.Write_Int16((ushort)(400 + boxedDeviceModel.WDnumber), boxedDeviceModel.WDate);
                boxedDeviceModel.WFish = true;
            }
            if (!boxedDeviceModel.WExcute)
            {
                boxedDeviceModel.WFish = false;
            }
            DataProcessingTool.ReverseBit16(ref D200[0], 15, MachinePublic.WriteRfidExcule);//RFID写
            MachinePublic.WriteRfidFish = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 14);//RFID写入完成
            MachinePublic.WriteRfidError = DataProcessingTool.GetBitValue(boxedDeviceModel.HomeFishState, 15);//RFID写入错误
            if (boxedDeviceModel.RunState == WorkStateEnum.Set)
            {
                boxedDeviceModel.AdjustmentStations[0].HomeData = DataProcessingTool.ByteCheck16(B400, 9);
                boxedDeviceModel.AdjustmentStations[1].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 1);
                boxedDeviceModel.AdjustmentStations[2].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 2);
                boxedDeviceModel.AdjustmentStations[3].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 3);
                boxedDeviceModel.AdjustmentStations[4].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 4);
                boxedDeviceModel.AdjustmentStations[5].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 5);
                boxedDeviceModel.AdjustmentStations[6].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 6);
                boxedDeviceModel.AdjustmentStations[7].HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 7);
                boxedDeviceModel.Sealbox.HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 8);
                boxedDeviceModel.Turntable.HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 9);
                boxedDeviceModel.Supplyboxs.HomeData = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 10);
                boxedDeviceModel.Sealbox.Data1 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 11);//封口膜检测位
                boxedDeviceModel.Sealbox.Data2 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 12);//封口位
                boxedDeviceModel.Sealbox.Data3 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 13);//退膜长度
                boxedDeviceModel.Sealbox.SealTime = DataProcessingTool.ByteCheckU16(B400, 9 + 2 * 14);//封口延时



                D200[13] = boxedDeviceModel.WoutY;//写输出

                //   MachinePublic.WriteRFIDdate       

                D200[15] = (short)(MachinePublic.WriteRfidData & 0XFFFF);
                D200[14] = (short)(MachinePublic.WriteRfidData >> 16);
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
            prescriptionModel = downLoadPreModel.CheckedPreInfos.FirstOrDefault(x => x.PrescriptionID == selectPreId);
            if (prescriptionModel.Details == null || prescriptionModel.Details.Count <= 0)
            {
                ShowWarningDialog("异常提示", "未找到处方颗粒详情信息");
                return;
            }
            //处理处方信息,分盒计算，剂量计算等
            string errorMsg = "";
            prescriptionModel = prescriptionFactory.PrescriptionHandles(prescriptionModel, out errorMsg);
            if (prescriptionModel == null)
            {
                ShowWarningDialog("异常提示", "处方信息检查不通过," + errorMsg);
                return;
            }
            //加载将要调剂处方信息
            lblPreId.Text = prescriptionModel.PrescriptionID;
            lblPreParticleNum.Text = prescriptionModel.DetailedCount.ToString();
            lblPreQuantity.Text = prescriptionModel.Quantity.ToString();
            lblPreBoxNum.Text = prescriptionModel.BoxNumber.ToString();

            boxedDeviceModel.MakePrescriptionParticles= prescriptionModel.Details.Select(x =>new MakePrescriptionParticle() 
            { 
                ParticlesName=x.ParName,
                ParticlesCode=x.ParCode,
                Rfid=x.MedicineCabinetDetail.RFID.Value,
                Dose=x.Dose,
                StationX=x.StationX,
                StationY=x.StationY,
                FishDrugeCount=0,
                Steper=0,
                Deduct=false,
                MakeParticleState= MakeParticleStateEnum.待称重,
                CurrentWeightQuantity=0,
                NewDose=0
            }).ToList();

            dgvPreDetail.DataSource = boxedDeviceModel.MakePrescriptionParticles;

            //亮灯


        }

        /// <summary>
        /// 检查设备状态
        /// </summary>
        private bool CheckDeivce()
        {
            if (boxedDeviceModel.RunState != WorkStateEnum.Work)
            {
                ShowErrorDialog("异常提示", $"设备正处于{StringHelper.GetEnumDescription(boxedDeviceModel.RunState)}状态，无法开始立即调剂");
                return false;
            }
            if (DataProcessingTool.GetBitValue(boxedDeviceModel.DeviceError, 3))
            {
                MessageBox.Show("设备气压不足，无法调剂");
                return false;
            }
            if (DataProcessingTool.GetBitValue(boxedDeviceModel.DeviceError, 4))
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
            if (boxedDeviceModel.RunState == WorkStateEnum.Write)
            {
                boxedDeviceModel.RunState = WorkStateEnum.Home;
                boxedDeviceModel.HomeExcute = true;
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

                System.Threading.Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 调剂步骤逻辑
        /// </summary>
        private void AdjustmentSteps() 
        {
            switch (boxedDeviceModel.RunState) 
            {
                case WorkStateEnum.Home:
                    if (boxedDeviceModel.HomeFish)
                    {
                        boxedDeviceModel.RunState = WorkStateEnum.Work;
                        boxedDeviceModel.HomeExcute = false;
                        boxedDeviceModel.HomeFish = false;
                        //boxedDeviceModel.Turntable.MoveCount = 0;
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
            if (boxedDeviceModel.Supplyboxs.HomeFinsh && boxedDeviceModel.Supplyboxs.HomeExcute)
            {
                boxedDeviceModel.Supplyboxs.HomeExcute = false;
            }
            if (boxedDeviceModel.Turntable.HomeFinsh && boxedDeviceModel.Turntable.HomeExcute)
            {
                boxedDeviceModel.Turntable.HomeExcute = false;
            }
            if (boxedDeviceModel.Sealbox.HomeFinsh && boxedDeviceModel.Sealbox.HomeExcute)
            {
                boxedDeviceModel.Sealbox.HomeExcute = false;
            }
            if (boxedDeviceModel.Outboxs.HomeFinsh && boxedDeviceModel.Outboxs.HomeExcute)
            {
                boxedDeviceModel.Outboxs.HomeExcute = false;
            }
            for (int i = 0; i < 8; i++)
            {
                if (boxedDeviceModel.AdjustmentStations[i].HomeFinsh && boxedDeviceModel.AdjustmentStations[i].HomeExcute)
                {
                    boxedDeviceModel.AdjustmentStations[i].HomeExcute = false;
                }
            }
            #endregion

            if (prescriptionModel==null)
            {
                return;
            }
            if (boxedDeviceModel.Extend.BoxProportionInPre == 0) 
            {
                boxedDeviceModel.Extend.BoxProportionInPre = 100 / prescriptionModel.BoxNumber.Value; //ObjMachine.BoxCount;//每一个盒子的处方占比
            }
            if (boxedDeviceModel.Extend.BoxFishCount < prescriptionModel.BoxNumber.Value) //判断是否开始进入调剂流程
            {
                boxedDeviceModel.ZmoveNumber = 1;
            }

            switch (boxedDeviceModel.Extend.WorkStep) 
            {
                case 0://转盘位移后执行下盒，下药，封口，出盒等动作
                    {
                        DisplacementExecutionAction();
                        boxedDeviceModel.Extend.WorkStep = 5;
                    }
                    break;
                case 5://判断是否跳转
                    {
                        if (CheckIsHaveHCExcute())
                        {
                            boxedDeviceModel.Extend.WorkStep = 10;
                        }
                        else 
                        {
                            boxedDeviceModel.ZmoveNumber++;
                            boxedDeviceModel.Extend.CurrentMoveCount++;
                            boxedDeviceModel.Extend.CanMoveCount1 = boxedDeviceModel.Extend.CanMoveCount % boxedDeviceModel.Extend.MaxBoxCount;
                            boxedDeviceModel.Extend.CanMoveCount = CalculateMoveTimes(); //可以位移次数   
                            if (boxedDeviceModel.Extend.CurrentMoveCount < CalculateMoveTimes())
                            {
                                boxedDeviceModel.Extend.WorkStep = 0;
                            }
                            else
                            {
                                boxedDeviceModel.Extend.WorkStep = 10;
                            }
                        }
                       
                    }
                    break;
                case 10:
                    {
                        if (boxedDeviceModel.ZmoveNumber == 1)
                        {
                            boxedDeviceModel.Extend.WorkStep = 15;
                        }
                        else
                        {
                            boxedDeviceModel.ZmoveNumber--;
                            boxedDeviceModel.Extend.CurrentMoveCount--;
                            boxedDeviceModel.Extend.WorkStep = 40;
                        }
                    }
                    break;
                case 15:
                    {
                        boxedDeviceModel.Outboxs.Excute = boxedDeviceModel.Outboxs.HCExcute; //写入出盒
                        boxedDeviceModel.Sealbox.Excute = boxedDeviceModel.Sealbox.HCExcute;//写入封口
                        boxedDeviceModel.Supplyboxs.Excute = boxedDeviceModel.Supplyboxs.HCExcute; //写入下盒
                        for (int i =0; i < 8; i++)
                        {
                            boxedDeviceModel.AdjustmentStations[i].Excute = boxedDeviceModel.AdjustmentStations[i].HCExcute;
                        }
                        boxedDeviceModel.Extend.WorkStep = 20;
                    }
                    break;
                case 20:
                    {
                        if (CheckStationFishState()) //判断状态完成
                        {
                            boxedDeviceModel.Outboxs.HCExcute = false;
                            boxedDeviceModel.Sealbox.HCExcute = false;
                            boxedDeviceModel.Supplyboxs.HCExcute = false;
                            for (int i = 0; i < 8; i++)
                            {
                                boxedDeviceModel.AdjustmentStations[i].HCExcute = false;
                            }
                            boxedDeviceModel.Extend.WorkStep = 25;
                        }
                    }
                    break;
                case 25://绑定药盒，计算开仓量
                    {
                        WorkStep25();
                        boxedDeviceModel.Extend.WorkStep = 30;
                    }
                    break;
                case 30://更新调剂工位当前状态判断出是否全部完成 取走药瓶
                    {
                        WorkStep30();
                        boxedDeviceModel.Extend.WorkStep = 35;
                    }
                    break;
                case 35://判断出盒工位药瓶是否完成， 若完成清除当前药盒的信息
                    {
                        //清除下药 清除供盒 清除出盒 清除封口
                        for (int i=0; i < 8; i++)
                        {
                            if (boxedDeviceModel.AdjustmentStations[i].Excute == true)
                            {
                                boxedDeviceModel.AdjustmentStations[i].Excute = false;
                            }
                        }
                        for (int j = 0; j < 16; j++)
                        {
                            if (boxedDeviceModel.Medboxs[j].OutState)
                            {
                                boxedDeviceModel.Extend.BoxFishCount++;
                                boxedDeviceModel.Medboxs[j] = null;
                            }
                        }
                        if (!CheckDrugeRest())
                        {
                            boxedDeviceModel.Extend.WorkStep = 40;
                        }
                    }
                    break;
                case 40:
                    {
                        //保存
                        //Savemachine(ObjMachine);

                        boxedDeviceModel.Extend.WorkStep = 45;
                    }
                    break;
                case 45://可以位移次数计算
                    {
                        if (!boxedDeviceModel.Stop && boxedDeviceModel.AxisHomeStep == 0)
                        {
                            boxedDeviceModel.Extend.CanMoveCount = CalculateMoveTimes(); //可以位移次数      
                            boxedDeviceModel.Extend.WorkStep = 50;
                        }
                    }
                    break;
                case 50://可以位移次数计算
                    {
                        boxedDeviceModel.Extend.CanMoveCount1 = boxedDeviceModel.Extend.CanMoveCount % boxedDeviceModel.Extend.MaxBoxCount; 
                        if (boxedDeviceModel.Extend.CurrentMoveCount < boxedDeviceModel.Extend.CanMoveCount)
                        {
                            boxedDeviceModel.Extend.WorkStep = 55;
                        }
                        else
                        {
                            boxedDeviceModel.Extend.WorkStep = 45;
                        }
                    }
                    break;
                case 55://转盘开始位移
                    {
                        boxedDeviceModel.Turntable.Excute = true;
                        boxedDeviceModel.Extend.WorkStep = 60;
                    }
                    break;
                case 60://转盘位移完成
                    {
                        if (boxedDeviceModel.Turntable.Finsh)
                        {
                            boxedDeviceModel.ZmoveNumber = 1;
                            boxedDeviceModel.Turntable.Excute = false;
                            boxedDeviceModel.Extend.CurrentMoveCount ++;
                            boxedDeviceModel.Extend.WorkStep = 65;
                        }
                    }
                    break;
                case 65://判断出盒数量=完成数量 清除当前类
                    {
                        //Savemachine(ObjMachine);
                        if (boxedDeviceModel.Extend.BoxFishCount == prescriptionModel.BoxNumber && prescriptionModel.BoxNumber > 0)
                        {
                            this.Invoke(new Action(() => {
                                //全部完成，弹出药框
                                Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "FrmOutBox").FirstOrDefault();
                                if (existingForm == null)
                                {
                                    FrmOutBox frmOutBox = new FrmOutBox(prescriptionModel.PrescriptionID, prescriptionModel.BoxNumber.Value, false, true,boxedDeviceModel.Extend.StartTime);
                                    frmOutBox.Show();
                                }
                            }));
                        }
                        else
                        {
                            if (boxedDeviceModel.Extend.BoxFishCount % 8 == 0 && boxedDeviceModel.Extend.BoxFishCount > 7 && boxedDeviceModel.Extend.HCBoxFishCount != boxedDeviceModel.Extend.BoxFishCount)
                            {
                                this.Invoke(new Action(() => {
                                    //全部完成，弹出药框
                                    Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "FrmOutBox").FirstOrDefault();
                                    if (existingForm == null)
                                    {
                                        FrmOutBox frmOutBox = new FrmOutBox(prescriptionModel.PrescriptionID, prescriptionModel.BoxNumber.Value, false, false,null);
                                        frmOutBox.Show();
                                    }
                                }));
                               // ObjMachine.worksate = 65;
                            }
                            else
                            {
                               // ObjMachine.worksate = 1;
                            }
                        }
                    }
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
            boxedDeviceModel.Extend.WheelPositionIndex = boxedDeviceModel.Extend.CurrentMoveCount+1 % boxedDeviceModel.Extend.MaxBoxCount;
            
            //下药， 出盒， 封口  , 下盒。计算
            for (int i = 0; i < boxedDeviceModel.Extend.MaxBoxCount; i++) //i为工位序号
            {
                int stationBoxIndex = boxedDeviceModel.AdjustmentStations[i].ExitBoxIndex;
                if (stationBoxIndex < 0)
                {
                    stationBoxIndex = i;
                }
                else
                {
                    stationBoxIndex = 16 - Math.Abs(stationBoxIndex - boxedDeviceModel.Extend.CurrentMoveCount) % 16;
                }
                ////计算的工位对应盒子序号赋值
                boxedDeviceModel.AdjustmentStations[i].ExitBoxIndex = stationBoxIndex;
                if (i == 13) //下盒
                {
                    if (boxedDeviceModel.Extend.BoxSupplyCount < prescriptionModel.BoxNumber.Value && boxedDeviceModel.Medboxs[stationBoxIndex].PrescriptionID == null) //当前下盒数量<处方需要盒数 执行下盒
                    {
                        boxedDeviceModel.Supplyboxs.HCboxIndex = stationBoxIndex;
                        boxedDeviceModel.Supplyboxs.HCExcute = true;
                    }
                }
                if (boxedDeviceModel.Medboxs[stationBoxIndex].ParticlesDetails != null) { continue; }
                if (i < 8)
                {
                    foreach (BoxParticlesDetail detail in boxedDeviceModel.Medboxs[stationBoxIndex].ParticlesDetails)
                    {
                        if (boxedDeviceModel.AdjustmentStations[i].Rfid == detail.Rfid && boxedDeviceModel.AdjustmentStations[i].StationState == StationStatusEnum.待调剂 && !detail.Fish)
                        {
                            boxedDeviceModel.AdjustmentStations[i].HCExcute = true;
                        }
                    }
                }
                if (i == 9)//封口
                {
                    if (boxedDeviceModel.Medboxs[stationBoxIndex].SealState == false && CheckXiaYaoFish(boxedDeviceModel.Medboxs[stationBoxIndex]))
                    {
                        boxedDeviceModel.Sealbox.HCboxIndex = stationBoxIndex;
                        boxedDeviceModel.Sealbox.HCExcute = true;
                    }
                }
                if (i == 11)//出盒
                {
                    if (boxedDeviceModel.Medboxs[stationBoxIndex].OutState == true)
                    {
                        boxedDeviceModel.Outboxs.HCboxIndex = stationBoxIndex;
                        boxedDeviceModel.Outboxs.HCExcute = true;
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
            if (boxedDeviceModel.Supplyboxs.HCExcute) //下盒完成检查
            {
                return true;
            }
            if (boxedDeviceModel.Sealbox.HCExcute) //封口完成检查
            {
                return true;
            }
            if (boxedDeviceModel.Outboxs.HCExcute) //出盒完成检查
            {
                return true;
            }
            foreach (AdjustmentStation station in boxedDeviceModel.AdjustmentStations) //下药完成检查
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
            foreach (Medbox medbox in boxedDeviceModel.Medboxs)
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
                            if (boxedDeviceModel.AdjustmentStations[i].Rfid == pd.Rfid && boxedDeviceModel.AdjustmentStations[i].StationState == StationStatusEnum.待调剂)
                            {
                                return boxedDeviceModel.Extend.CurrentMoveCount + 1;
                            }
                        }
                    }
                }

                if (medbox.FinishValue >= prescriptionModel.Details.Count)
                {
                    return boxedDeviceModel.Extend.CurrentMoveCount + 1;
                }
            }
            if (boxedDeviceModel.Extend.BoxFishCount == prescriptionModel.BoxNumber)
            {
                return boxedDeviceModel.Extend.CurrentMoveCount + 1;
            }
            if (boxedDeviceModel.Extend.BoxSupplyCount < prescriptionModel.BoxNumber)
            {
                for (int c = 0; c < 16; c++)
                {
                    if (boxedDeviceModel.Medboxs[c].ParticlesDetails == null)
                    {
                        return boxedDeviceModel.Extend.CurrentMoveCount + 1;
                    }
                }
            }

            return boxedDeviceModel.Extend.CurrentMoveCount;
        }

        /// <summary>
        /// 判断所有工位完成状态
        /// </summary>
        /// <returns></returns>
        private bool CheckStationFishState()
        {
            if ((boxedDeviceModel.Supplyboxs.Excute && !boxedDeviceModel.Supplyboxs.Finsh)//下盒完成检查
                || boxedDeviceModel.Sealbox.Excute && !boxedDeviceModel.Sealbox.Finsh //封口完成检查
                || boxedDeviceModel.Outboxs.Excute && !boxedDeviceModel.Outboxs.Finsh) //出盒完成检查 
            {
                return false;
            }
            foreach (AdjustmentStation station in boxedDeviceModel.AdjustmentStations) //下药完成检查
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
            if (boxedDeviceModel.Supplyboxs.Excute) //更新药盒供盒信息
            {
                Medbox medbox = new Medbox();
                medbox.PrescriptionID = prescriptionModel.PrescriptionID;
                medbox.SealState = false;
                medbox.OutState = false;
                
                medbox.ParticlesDetails = prescriptionModel.Details.Select(x=>new BoxParticlesDetail() { Steper=x.Steper, Rfid=x.MedicineCabinetDetail.RFID.Value, Fish=false }).ToList();
                boxedDeviceModel.Medboxs[boxedDeviceModel.Supplyboxs.HCboxIndex] = medbox;
                boxedDeviceModel.Extend.BoxSupplyCount++;
                boxedDeviceModel.Supplyboxs.Excute = false;
            }
            for (int i = 0; i < 8; i++) // 更新下药信息 药盒的信息 根据位移次数选择对位信息写入下药	完成状态		
            {
                int index = boxedDeviceModel.AdjustmentStations[i].ExitBoxIndex;
                if (boxedDeviceModel.Medboxs[index].PrescriptionID != null && boxedDeviceModel.AdjustmentStations[i].StationState==StationStatusEnum.待调剂) 
                {
                    boxedDeviceModel.Medboxs[index].ParticlesDetails.ForEach(pd => 
                    {
                        if (boxedDeviceModel.AdjustmentStations[i].Rfid == pd.Rfid && boxedDeviceModel.AdjustmentStations[i].Finsh) //如果该工位有该药盒信息写入完成状态
                        {
                            boxedDeviceModel.AdjustmentStations[i].FishDrugeCount++;
                            boxedDeviceModel.Medboxs[index].FinishValue++;
                            pd.Fish = true;
                        }
                    });
                   
                }
                boxedDeviceModel.AdjustmentStations[i-1].Bar = (int)(Math.Round((Double)(boxedDeviceModel.AdjustmentStations[i-1].FishDrugeCount / (Double)prescriptionModel.BoxNumber), 3) * 100);
            }
            //封口
            if (boxedDeviceModel.Sealbox.Excute)
            {
                boxedDeviceModel.Medboxs[boxedDeviceModel.Sealbox.HCboxIndex].SealState = true;
                boxedDeviceModel.Sealbox.Excute = false;
            }
            //出盒
            if (boxedDeviceModel.Outboxs.Excute)
            {
                boxedDeviceModel.Medboxs[boxedDeviceModel.Outboxs.HCboxIndex].OutState = true;
                boxedDeviceModel.Outboxs.Excute = false;
            }

            for (int iv = 0; iv < 8; iv++)
            {
                if (boxedDeviceModel.AdjustmentStations[iv].Excute)
                {
                    if (!CheckWeight(boxedDeviceModel.AdjustmentStations[iv])) //检查当前余量是否足够调剂使用
                    {
                        boxedDeviceModel.AdjustmentStations[iv].StationState = StationStatusEnum.药品余量不足;
                    }
                    boxedDeviceModel.AdjustmentStations[iv].Excute = false;
                }
            }
            for (int d = 1; d < 17; d++)//更新进度条
            {
                if (boxedDeviceModel.Medboxs[d].PrescriptionID != null)
                {
                    int c = (int)(boxedDeviceModel.Extend.BoxProportionInPre * Math.Round((Double)(boxedDeviceModel.Medboxs[d].FinishValue + 1) / (Double)(prescriptionModel.Details.Count + 3), 3));
                    Boxbar = c + Boxbar;
                }
            }
            boxedDeviceModel.Extend.ProcessBar = (int)(Boxbar + boxedDeviceModel.Extend.BoxFishCount * boxedDeviceModel.Extend.BoxProportionInPre);
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
            var particlesDetail = boxedDeviceModel.MakePrescriptionParticles.Where(d => (d.Rfid == station.Rfid)).FirstOrDefault();
            if (particlesDetail.CurrentWeightQuantity < (float)(particlesDetail.NewDose * 2 * (prescriptionModel.BoxNumber.Value- station.FishDrugeCount))+ dxValue && particlesDetail.MakeParticleState!= MakeParticleStateEnum.调剂完成)
            {
                particlesDetail.MakeParticleState = MakeParticleStateEnum.待上药;
                particlesDetail.FishDrugeCount= station.FishDrugeCount;

                //本次扣除库存量= 当前下药次数*每格重量*2 -已经扣除的库存量；
                float deductStockWeight = (float)Math.Round(particlesDetail.NewDose * 2 * station.FishDrugeCount - particlesDetail.EarlyDeductionStock, 2);

                string msg = prescriptionFactory.DeductStockStep(particlesDetail.Rfid, prescriptionModel, deductStockWeight);//提前扣除库存
                if (msg=="") 
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
                if (boxedDeviceModel.AdjustmentStations[i].Rfid==0) { continue; }

                bool isHaveParNoComplete= false;//是否存在还未接完药的药盒
                for (int j = 0; j < 16; j++)
                {
                    if (boxedDeviceModel.Medboxs[j].PrescriptionID==null) { continue; }

                    if (boxedDeviceModel.Medboxs[j].FinishValue== boxedDeviceModel.Medboxs[j].ParticlesDetails.Count) { isExitBoxFish = true; }

                    isHaveParNoComplete = boxedDeviceModel.Medboxs[j].ParticlesDetails.Any(x => x.Rfid== boxedDeviceModel.AdjustmentStations[i].Rfid && !x.Fish);
                    if (isHaveParNoComplete) { break; }
                }

                if (!isHaveParNoComplete) 
                {
                    continue;
                }
                boxedDeviceModel.AdjustmentStations[i].LockState = false;
                if (isExitBoxFish && boxedDeviceModel.MakePrescriptionParticles.Count!= boxedDeviceModel.Extend.BoxSupplyCount)//  摆瓶最后一轮
                {
                    int durgBottleNum = boxedDeviceModel.MakePrescriptionParticles.Count % 8;
                    int a ;
                    for (a =1;a < 9; a++) 
                    {
                        if (boxedDeviceModel.AdjustmentStations[a - 1].StationState == StationStatusEnum.待调剂)
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
                        boxedDeviceModel.AdjustmentStations[i].LockState = true;
                    }
                    else
                    {

                        boxedDeviceModel.AdjustmentStations[i].LockState = false;
                    }

                }

                if (!boxedDeviceModel.AdjustmentStations[i].LockState || boxedDeviceModel.AdjustmentStations[i].FishDrugeCount==prescriptionModel.BoxNumber) 
                {
                    boxedDeviceModel.AdjustmentStations[i].StationState = StationStatusEnum.待取走;
                    var particle= boxedDeviceModel.MakePrescriptionParticles.FirstOrDefault(x => x.Rfid == boxedDeviceModel.AdjustmentStations[i].Rfid);
                    if (particle==null) { continue; }

                    if (prescriptionModel.BoxNumber == boxedDeviceModel.Extend.BoxSupplyCount)
                    {
                        if (particle.MakeParticleState!= MakeParticleStateEnum.调剂完成) 
                        {
                            isCloseLed = true;//关闭指示灯
                            particle.MakeParticleState = MakeParticleStateEnum.调剂完成;    //颗粒设置为调剂完成
                            //扣除库存，写入日志
                            prescriptionFactory.DeductStock(particle.Rfid,prescriptionModel, particle.EarlyDeductionStock);
                        }
                    }
                    else 
                    {
                        particle.MakeParticleState = MakeParticleStateEnum.待放入;
                        particle.FishDrugeCount = boxedDeviceModel.AdjustmentStations[i].FishDrugeCount;
                    }
                }
            }

            if (isCloseLed)
            {
                CloseLED(boxedDeviceModel.MakePrescriptionParticles);
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
                boxedDeviceModel.WriteLed = true;
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
            if (boxedDeviceModel.AdjustmentStations.Any(x=>x.Excute || x.Finsh))//下药完成检查
            {
                return true;
            }
            
            if (boxedDeviceModel.Supplyboxs.Excute || boxedDeviceModel.Supplyboxs.Finsh//下盒完成检查
                || boxedDeviceModel.Sealbox.Excute || boxedDeviceModel.Sealbox.Finsh//封口完成检查
                || boxedDeviceModel.Outboxs.Excute || boxedDeviceModel.Outboxs.Finsh)  //出盒完成检查
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
            if (boxedDeviceModel.Sealbox.Finsh && boxedDeviceModel.Sealbox.Excute)
            {
                boxedDeviceModel.Sealbox.Excute = false;
            }
            if (boxedDeviceModel.Supplyboxs.Finsh && boxedDeviceModel.Supplyboxs.Excute)
            {
                boxedDeviceModel.Supplyboxs.Excute = false;
            }
            if (boxedDeviceModel.Turntable.Finsh  && boxedDeviceModel.Turntable.Excute)
            {
                boxedDeviceModel.Turntable.Excute = false;
            }
            if (boxedDeviceModel.Outboxs.Finsh && boxedDeviceModel.Outboxs.Excute)
            {
                boxedDeviceModel.Outboxs.Excute = false;
            }
            for (int c = 0; c < 8; c++)
            {
                if (boxedDeviceModel.AdjustmentStations[c].Finsh && boxedDeviceModel.AdjustmentStations[c].Excute)
                {
                    boxedDeviceModel.AdjustmentStations[c].Excute = false;
                }
            }
        }
    }
}
