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
            boxedDeviceModel.AllFishState = DataProcessingTool.ByteCheckU16(B250, 9);//完成状态
            boxedDeviceModel.HomeExcute = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 1);//整机回零完成
            boxedDeviceModel.Turntable.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 2);//位移完成
            boxedDeviceModel.Supplyboxs.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 3);//供盒完成
            boxedDeviceModel.Sealbox.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 4);//封口完成
            boxedDeviceModel.AdjustmentStations[0].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 5);//下药完成
            boxedDeviceModel.AdjustmentStations[1].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 6);//下药完成
            boxedDeviceModel.AdjustmentStations[2].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 7);//下药完成
            boxedDeviceModel.AdjustmentStations[3].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 8);//下药完成
            boxedDeviceModel.AdjustmentStations[4].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 9);//下药完成
            boxedDeviceModel.AdjustmentStations[5].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 10);//下药完成
            boxedDeviceModel.AdjustmentStations[6].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 11);//下药完成
            boxedDeviceModel.AdjustmentStations[7].Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 12);//下药完成
            boxedDeviceModel.Outboxs.Finsh = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 13);//出盒完成


            boxedDeviceModel.SingleFinshState = DataProcessingTool.ByteCheckU16(B250, 9 + 2);//单个回零完成状态
            boxedDeviceModel.AdjustmentStations[0].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 1);//1#下药回零完成
            boxedDeviceModel.AdjustmentStations[1].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 2);//2#下药回零完成
            boxedDeviceModel.AdjustmentStations[2].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 3);//3#下药回零完成
            boxedDeviceModel.AdjustmentStations[3].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 4);//4#下药回零完成
            boxedDeviceModel.AdjustmentStations[4].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 5);//5#下药回零完成
            boxedDeviceModel.AdjustmentStations[5].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 6);//6#下药回零完成
            boxedDeviceModel.AdjustmentStations[6].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 7);//7#下药回零完成
            boxedDeviceModel.AdjustmentStations[7].HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 8);//8#下药回零完成
            boxedDeviceModel.Sealbox.HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 9);//9#走膜回零完成
            boxedDeviceModel.Turntable.HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 10);//10#转盘回零完成
            boxedDeviceModel.Supplyboxs.HomeFinsh = DataProcessingTool.GetBitValue(boxedDeviceModel.SingleFinshState, 11);//11#供盒回零完成
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
            MachinePublic.WriteRfidFish = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 14);//RFID写入完成
            MachinePublic.WriteRfidError = DataProcessingTool.GetBitValue(boxedDeviceModel.AllFishState, 15);//RFID写入错误
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
            var allParams = CommonStaticDataBLL.GetSystemParameterValue();
            if (allParams == null)
            {
                return "未找到该设备调剂参数信息";
            }
            string paramStr = allParams.FirstOrDefault(x => x.ParameterName == "YaoHeDanGeTiJi")?.ParameterValue;
            if (paramStr != null && double.TryParse(paramStr, out double value1))
            {
                prescriptionFactory.BoxCellVolume = value1;
            }
            else 
            {
                return "药盒单格体积参数信息缺失或值无效";
            }
            paramStr = allParams.FirstOrDefault(x => x.ParameterName == "YaoHeLeiXing")?.ParameterValue;
            if (paramStr != null && short.TryParse(paramStr, out short value2))
            {
                prescriptionFactory.BoxType = value2;
            }
            else 
            {
                return "药盒类型参数信息缺失或值无效";
            }

            paramStr = allParams.FirstOrDefault(x => x.ParameterName == "TiaoJiFangShi")?.ParameterValue;
            if (paramStr != null && int.TryParse(paramStr, out int value3))
            {
                prescriptionFactory.AdjustWay = value3;
            }
            else
            {
                return "调剂方式参数信息缺失或值无效";
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
            if (paramError!=null) 
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

            
            //加载将要调剂处方信息
            lblPreId.Text = prescriptionModel.PrescriptionID;
            lblPreParticleNum.Text = prescriptionModel.DetailedCount.ToString();
            lblPreQuantity.Text = prescriptionModel.Quantity.ToString();
            lblPreBoxNum.Text = "暂无";

            dgvPreDetail.DataSource = prescriptionModel.Details;

        }

        private bool CheckDeivce()
        {
            if (boxedDeviceModel.RunState!= WorkStateEnum.Work)
            {
                ShowErrorDialog("异常提示",$"设备正处于{boxedDeviceModel.RunState.ToString()}状态，无法开始立即调剂");
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
            //if (ObjMachine.Runstate == MachineBox.Workstate.Work && newstate.Text == "运行状态：等待调剂 ")
            //{
            //    return true;
            //}
            //else
            //{
            //    MessageBox.Show("设备不处于：等待调剂");
            //    return false;
            //}


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
    }
}
