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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.DeviceForms
{
    public partial class FrmBoxedDevice : UIPage
    {
        public static MachineBox machineBox = new MachineBox();//设备类
        public static Int16[] D600 = new Int16[28];
        public byte[] B400 = new byte[40];
        public Int16[] D200 = new Int16[20];
        public byte[] B250 = new byte[24];

        List<bool> BoxDfstate = new List<bool>();
        Thread Jxssend;
        ModBusTCP_Cliect modBusTCP_Cliect = new ModBusTCP_Cliect();
        PrescriptionFactory prescriptionFactory = new PrescriptionFactory();
        private PreModel prescriptionModel = new PreModel();//调剂中的处方
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
                    if (machineBox.Runstate == MachineBox.Workstate.Set)
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
            DataProcessingTool.ReverseBit16(ref D200[0], 1, machineBox.HomeExcute);//整机回零启动
            if (MachineBox.Workstate.Write != machineBox.Runstate)
            {
                DataProcessingTool.ReverseBit16(ref D200[0], 2, machineBox.Zmove);//位移启动
                if (MachineBox.Workstate.Rest != machineBox.Runstate)
                {
                    DataProcessingTool.ReverseBit16(ref D200[0], 3, machineBox.Mbox);//供盒启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 4, machineBox.Seal);//封口启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 5, machineBox.ParticlesStation[1].StartDeruge); //1下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 6, machineBox.ParticlesStation[2].StartDeruge); //2下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 7, machineBox.ParticlesStation[3].StartDeruge); //3下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 8, machineBox.ParticlesStation[4].StartDeruge); //4下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 9, machineBox.ParticlesStation[5].StartDeruge); //5下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 10, machineBox.ParticlesStation[6].StartDeruge); //6下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 11, machineBox.ParticlesStation[7].StartDeruge); //7下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 12, machineBox.ParticlesStation[8].StartDeruge); //8下药启动
                    DataProcessingTool.ReverseBit16(ref D200[0], 13, machineBox.Outbox);//出盒启动
                    //15写如RFID 数据
                }
            }
            DataProcessingTool.ReverseBit16(ref D200[1], 1, machineBox.TAxisHomeExcute[0]);//1#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 2, machineBox.TAxisHomeExcute[1]);//2#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 3, machineBox.TAxisHomeExcute[2]);//3#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 4, machineBox.TAxisHomeExcute[3]);//4#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 5, machineBox.TAxisHomeExcute[4]);//5#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 6, machineBox.TAxisHomeExcute[5]);//6#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 7, machineBox.TAxisHomeExcute[6]);//7#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 8, machineBox.TAxisHomeExcute[7]);//8#下药回零
            DataProcessingTool.ReverseBit16(ref D200[1], 9, machineBox.TAxisHomeExcute[8]);//9#走膜回零
            DataProcessingTool.ReverseBit16(ref D200[1], 10, machineBox.TAxisHomeExcute[9]);//10#转盘
            DataProcessingTool.ReverseBit16(ref D200[1], 11, machineBox.TAxisHomeExcute[10]);//11#供盒

            D200[2] = (short)machineBox.Zmovenuber;
            D200[3] = (short)machineBox.ParticlesStation[1].Steper;
            D200[4] = (short)machineBox.ParticlesStation[2].Steper;
            D200[5] = (short)machineBox.ParticlesStation[3].Steper;
            D200[6] = (short)machineBox.ParticlesStation[4].Steper;
            D200[7] = (short)machineBox.ParticlesStation[5].Steper;
            D200[8] = (short)machineBox.ParticlesStation[6].Steper;
            D200[9] = (short)machineBox.ParticlesStation[7].Steper;
            D200[10] = (short)machineBox.ParticlesStation[8].Steper;
            D200[11] = (short)(machineBox.iRestError >> 16);
            D200[12] = (short)(machineBox.iRestError & 0xFFFF);



            /////上位机读 d250设备 整机  下药 封口 出盒 供盒完成状态   
            ///d251设备单轴回零完成状态   
            /// 称重工位重量D252 D253
            ///称重工位状态 D254
            ///异常状态 256 - D257 
            ///rfid数据D258-D277
            machineBox.Finshstate = DataProcessingTool.ByteCheckU16(B250, 9);//完成状态
            machineBox.Homefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 1);//整机回零完成
            machineBox.Zmovefinsh = DataProcessingTool.GetBitValue(machineBox.Finshstate, 2);//位移完成
            machineBox.Mboxfinsh = DataProcessingTool.GetBitValue(machineBox.Finshstate, 3);//供盒完成
            machineBox.Sealfinsh = DataProcessingTool.GetBitValue(machineBox.Finshstate, 4);//封口完成
            machineBox.ParticlesStation[1].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 5);//下药完成
            machineBox.ParticlesStation[2].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 6);//下药完成
            machineBox.ParticlesStation[3].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 7);//下药完成
            machineBox.ParticlesStation[4].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 8);//下药完成
            machineBox.ParticlesStation[5].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 9);//下药完成
            machineBox.ParticlesStation[6].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 10);//下药完成
            machineBox.ParticlesStation[7].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 11);//下药完成
            machineBox.ParticlesStation[8].Derugefinish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 12);//下药完成
            machineBox.Outboxfinsh = DataProcessingTool.GetBitValue(machineBox.Finshstate, 13);//出盒完成


            machineBox.Finshstate1 = DataProcessingTool.ByteCheckU16(B250, 9 + 2);//1完成状态
            machineBox.TAxisHomefinish[0] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 1);//1#下药回零
            machineBox.TAxisHomefinish[1] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 2);//2#下药回零
            machineBox.TAxisHomefinish[2] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 3);//3#下药回零
            machineBox.TAxisHomefinish[3] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 4);//4#下药回零
            machineBox.TAxisHomefinish[4] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 5);//5#下药回零
            machineBox.TAxisHomefinish[5] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 6);//6#下药回零
            machineBox.TAxisHomefinish[6] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 7);//7#下药回零
            machineBox.TAxisHomefinish[7] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 8);//8#下药回零
            machineBox.TAxisHomefinish[8] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 9);//8#下药回零
            machineBox.TAxisHomefinish[9] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 10);//8#下药回零
            machineBox.TAxisHomefinish[10] = DataProcessingTool.GetBitValue(machineBox.Finshstate1, 11);//8#下药回零
            MachinePublic.Weight = Math.Round((double)(DataProcessingTool.ByteCheck32(B250, 9 + 2 * 2)) / 100, 2); //  称重工位重量D252 D253
            MachinePublic.WeightState = DataProcessingTool.GetBitValue(DataProcessingTool.ByteCheck16(B250, 9 + 2 * 4), 9);//称重工位状态 D254
            machineBox.iError = DataProcessingTool.ByteCheckU16(B250, 9 + 2 * 6);//异常状态 256 - D257      
            machineBox.RFID = DataProcessingTool.RfidByteCheck32(B250, 9 + 2 * 8); //rfid数据D258-D277
            machineBox.InX = DataProcessingTool.ByteCheckU16(B250, 9 + 2 * 28);


            ///异常映射

            /// 调试模式数据映射
            /// 
            if (machineBox.WExcute && !machineBox.WFish)
            {
                modBusTCP_Cliect.Write_Int16((ushort)(400 + machineBox.WDnumber), machineBox.WDate);
                machineBox.WFish = true;
            }
            if (!machineBox.WExcute)
            {
                machineBox.WFish = false;
            }
            DataProcessingTool.ReverseBit16(ref D200[0], 15, MachinePublic.WriteRfidExcule);//RFID写
            MachinePublic.WriteRfidFish = DataProcessingTool.GetBitValue(machineBox.Finshstate, 14);//RFID写入完成
            MachinePublic.WriteRfidError = DataProcessingTool.GetBitValue(machineBox.Finshstate, 15);//RFID写入错误
            if (machineBox.Runstate == MachineBox.Workstate.Set)
            {
                machineBox.WAxisHomeDate[0] = DataProcessingTool.ByteCheck16(B400, 9);
                machineBox.WAxisHomeDate[1] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 1);
                machineBox.WAxisHomeDate[2] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 2);
                machineBox.WAxisHomeDate[3] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 3);
                machineBox.WAxisHomeDate[4] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 4);
                machineBox.WAxisHomeDate[5] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 5);
                machineBox.WAxisHomeDate[6] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 6);
                machineBox.WAxisHomeDate[7] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 7);
                machineBox.WAxisHomeDate[8] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 8);
                machineBox.WAxisHomeDate[9] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 9);
                machineBox.WAxisHomeDate[10] = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 10);
                machineBox.SealPosation1 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 11);//封口膜检测位
                machineBox.SealPosation2 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 12);//封口位
                machineBox.SealPosation3 = DataProcessingTool.ByteCheck16(B400, 9 + 2 * 13);//退膜长度
                machineBox.SealTimeY = DataProcessingTool.ByteCheckU16(B400, 9 + 2 * 14);//封口延时



                D200[13] = machineBox.WoutY;//写输出

                //   MachinePublic.WriteRFIDdate       

                D200[15] = (short)(MachinePublic.WriteRfidData & 0XFFFF);
                D200[14] = (short)(MachinePublic.WriteRfidData >> 16);
            }
        }

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
            if (machineBox.Stop)
            {
                machineBox.Stop = false;
                lbOpterMsg.Items.Insert(0, "|设备继续当前动作:|" + DateTime.Now);
                return;
            }
            else
            {

                machineBox.Stop = true;
                lbOpterMsg.Items.Insert(0, "|设备已暂停:|" + DateTime.Now);
                return;
            }
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
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

            //正在调剂处方信息
            lblPreId.Text = prescriptionModel.PrescriptionID;
            lblPreParticleNum.Text = prescriptionModel.DetailedCount.ToString();
            lblPreQuantity.Text = prescriptionModel.Quantity.ToString();
            lblPreBoxNum.Text = "暂无";

            dgvPreDetail.DataSource = prescriptionModel.Details;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            //AdjustmentSys.Models.Machine myObj = new AdjustmentSys.Models.Machine(); //保存的设备对象
            //Readmachine(ref myObj);
            //if (myObj.PrescriptionID != null)
            //{
            //    try
            //    {
            //        if (MessageBox.Show("|之前处方未完成是否恢复？|", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //        {
            //            //停止设备当前动作
            //            NewPresData = Dispensing.PrescriptionDictionary[myObj.PrescriptionID];

            //            myObj.Zmove = false;
            //            if (!myObj.Mboxfinsh) //如果下盒没成功， 重新下盒
            //            {
            //                myObj.Mbox = false;
            //            }
            //            for (int i = 1; i < 9; i++) //如果当前下药没完成就复位
            //            {
            //                if (!myObj.ParticlesStation[i].Derugefinish)
            //                {
            //                    myObj.ParticlesStation[i].StartDeruge = false;
            //                }
            //            }
            //            if (!myObj.Sealfinsh) //封口没完成， 重新封口
            //            {
            //                myObj.Seal = false;
            //            }
            //            myObj.Restsate = 0;
            //            myObj.Runstate = MachineBox.Workstate.Rest;
            //            machineBox = myObj;
            //        }
            //        else
            //        {

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("恢复数据出现异常:|" + ex.ToString() + "|,已取消恢复");
            //    }

            //}
            while (SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus)
            {
                SysDeviceInfo._currentDeviceInfo.DeviceConnectStatus = ModBusTCP_Cliect.ConnState;
                State();
                RFIDstate();
                backgroundWorker1.ReportProgress(0, machineBox);
                Savemachine(machineBox);

                System.Threading.Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 调剂逻辑
        /// </summary>
        public void State()
        {
            ReadE();//获取设备链接状态

            switch (machineBox.Runstate)
            {
                case MachineBox.Workstate.Write: //待回零
                    {
                    }
                    break;

                case MachineBox.Workstate.Home: //回零中
                    {
                        if (machineBox.Homefinish)//回零完成
                        {

                            machineBox.Runstate = MachineBox.Workstate.Work;
                            machineBox.HomeExcute = false;//回零启动
                            machineBox.Homefinish = false;//回零完成
                            machineBox.MoveCount = 0;
                        }
                    }
                    break;
                case MachineBox.Workstate.Rest: //调剂恢复
                    {
                        switch (machineBox.Restsate)
                        {
                            case 0: //初始化设备
                                {
                                    machineBox.HomeExcute = true;//回零启动
                                    machineBox.Restsate = 5;
                                }
                                break;
                            case 5:
                                {
                                    if (machineBox.Homefinish)//回零完成
                                    {
                                        machineBox.HomeExcute = false;//回零启动
                                        machineBox.Homefinish = false;//回零完成
                                        //计算出之前位移次数
                                        machineBox.Zmovenuber = (machineBox.MoveCount % machineBox.Maxbox) - 1; //位移格数=(当前位移次数%盒子数量(16))-1

                                        machineBox.Restsate = 10;
                                    }
                                }
                                break;
                            case 10: //转盘位移
                                {
                                    machineBox.Zmove = true;//转盘开始位移
                                    machineBox.Restsate = 15;

                                }
                                break;
                            case 15:
                                {
                                    if (machineBox.Zmovefinsh)//位移完成
                                    {
                                        machineBox.Zmovenuber = 1;//位移格数
                                        machineBox.Zmove = false;//转盘开始位移
                                        machineBox.Restsate = 20;
                                    }

                                }
                                break;
                            case 20://位移完成切换到工作模式
                                {

                                    machineBox.Runstate = MachineBox.Workstate.Work;
                                    machineBox.Restsate = 0;

                                }
                                break;
                        }
                        break;
                    }
                case MachineBox.Workstate.Density: //密度测量
                    {
                    }
                    break;
                case MachineBox.Workstate.Set: //调试模式
                    {
                        Rest();
                    }
                    break;

                case MachineBox.Workstate.Work://工作模式
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (machineBox.TAxisHomefinish[i])//单轴回零完成
                            {
                                machineBox.TAxisHomeExcute[i] = false;

                            }
                        }

                        switch (machineBox.worksate)
                        {
                            case 0:
                                {
                                    if (machineBox.PrescriptionID != null)
                                    {
                                        machineBox.TBox = 100 / machineBox.BoxCount;//每一个盒子的处方占比=100/盒子数量
                                        machineBox.worksate = 1;
                                    }
                                }
                                break;
                            case 1:
                                {   //完成药盒的数量<盒子数量 && 
                                    if (machineBox.Boxfinish < machineBox.BoxCount && machineBox.PrescriptionID != null) //判断是否开始进入调剂流程
                                    {
                                        machineBox.Zmovenuber = 1;
                                        machineBox.worksate = 5;
                                    }
                                }
                                break;
                            case 5:
                                {
                                    Lopra(); //判断启动本轮 下药 封口 出盒 计算 
                                    machineBox.worksate = 6;
                                }
                                break;
                            case 6://判断本轮是否空转
                                {
                                    if (DrugeON())
                                    {
                                        machineBox.worksate = 9;
                                    }
                                    else
                                    {
                                        machineBox.Zmovenuber = machineBox.Zmovenuber + 1;// 位移格数
                                        machineBox.MoveCount = machineBox.MoveCount + 1;//当前位移次数
                                        machineBox.yEmoveCount = machineBox.EmoveCount % machineBox.Maxbox; //位移次数(转成1-16)=位移次数(转成1-16)%16 
                                        machineBox.EmoveCount = Emove(); //可以位移次数   
                                        if (machineBox.MoveCount < machineBox.EmoveCount)//Emove())
                                        {
                                            machineBox.worksate = 5;
                                        }
                                        else
                                        {
                                            machineBox.worksate = 9;
                                        }
                                    }
                                }
                                break;
                            case 9:
                                {
                                    if (machineBox.Zmovenuber == 1)//位移格数
                                    {
                                        machineBox.worksate = 10;
                                    }
                                    else
                                    {
                                        machineBox.Zmovenuber = machineBox.Zmovenuber - 1;
                                        machineBox.MoveCount = machineBox.MoveCount - 1;
                                        machineBox.worksate = 30;
                                    }
                                }
                                break;
                            case 10:
                                {
                                    machineBox.Outbox = machineBox.HCOutbox; //写入出盒
                                    machineBox.Seal = machineBox.HCSeal;//写入封口
                                    machineBox.Mbox = machineBox.HCMbox; //写入下盒
                                    for (int i = 1; i < 9; i++)
                                    {
                                        //工位启动调剂赋值
                                        machineBox.ParticlesStation[i].StartDeruge = machineBox.ParticlesStation[i].HCStartDeruge;
                                    }
                                    machineBox.worksate = 11;
                                }
                                break;
                            case 11:
                                {
                                    if (Drugecheck(machineBox)) //判断状态完成
                                    {
                                        machineBox.HCOutbox = false;
                                        machineBox.HCSeal = false;
                                        machineBox.HCMbox = false;
                                        for (int i = 1; i < 9; i++)
                                        {
                                            machineBox.ParticlesStation[i].HCStartDeruge = false;
                                        }
                                        machineBox.worksate = 15;
                                    }
                                }
                                break;

                            case 15://写入对应完成的状态数据
                                {
                                    double Boxbar = 0;//药盒进度                                    
                                    if (machineBox.Mbox) //更新药盒供盒信息
                                    {
                                        AdjustmentSys.Models.Machine.Med TBbox = new AdjustmentSys.Models.Machine.Med();
                                        TBbox.PrescriptionID = machineBox.PrescriptionID;
                                        TBbox.Gsealstate = false;
                                        TBbox.Outstate = false;
                                        List<AdjustmentSys.Models.Machine.ParticlesDetail> Tblistdetail = new List<AdjustmentSys.Models.Machine.ParticlesDetail>();

                                        foreach (AdjustmentSys.Models.Machine.DetailM TBd in machineBox.ParticlesDetailp)
                                        {
                                            AdjustmentSys.Models.Machine.ParticlesDetail pd = new AdjustmentSys.Models.Machine.ParticlesDetail();
                                            pd.Steper = TBd.Steper;
                                            pd.ParticlesCode = TBd.ParticlesCode;
                                            pd.finish = false;
                                            Tblistdetail.Add(pd);
                                        }
                                        TBbox.ParticlesDetail = Tblistdetail;
                                        machineBox.BoxST[machineBox.HCcountmbox] = TBbox;
                                        machineBox.NowboxCount = machineBox.NowboxCount + 1;
                                        machineBox.Mbox = false;
                                    }
                                    for (int i = 1; i < 9; i++) // 更新下药信息 药盒的信息 根据位移次数选择对位信息写入下药	完成状态		
                                    {
                                        int f = 16 - i;
                                        if (f == 0)
                                        {
                                            f = 16;
                                        }
                                        if (machineBox.yMoveCount + f > 16)//判断超出18
                                        {
                                            f = machineBox.yMoveCount + f - 16;
                                        }
                                        else
                                        {
                                            f = machineBox.yMoveCount + f;

                                        }

                                        if (machineBox.BoxST[f].PrescriptionID != null && machineBox.ParticlesStation[i].Particlesstate > StationStatusEnum.待放入) //写出药盒包函要瓶中调剂w完成的状态
                                        {
                                            List<AdjustmentSys.Models.Machine.ParticlesDetail> ST = new List<AdjustmentSys.Models.Machine.ParticlesDetail>();

                                            foreach (AdjustmentSys.Models.Machine.ParticlesDetail tb in machineBox.BoxST[f].ParticlesDetail)
                                            {

                                                AdjustmentSys.Models.Machine.ParticlesDetail relust = new AdjustmentSys.Models.Machine.ParticlesDetail();
                                                relust = tb;
                                                if (machineBox.ParticlesStation[i].ParticlesCode == tb.ParticlesCode && machineBox.ParticlesStation[i].Derugefinish) //如果该工位有该药盒信息写入完成状态
                                                {
                                                    machineBox.ParticlesStation[i].DrugeValue = machineBox.ParticlesStation[i].DrugeValue + 1;
                                                    machineBox.BoxST[f].finishValue = machineBox.BoxST[f].finishValue + 1;
                                                    relust.finish = true;
                                                }
                                                ST.Add(relust);
                                            }
                                            machineBox.BoxST[f].ParticlesDetail = ST; //刷新药盒调剂的最新状态
                                        }
                                        machineBox.ParticlesStation[i].Bar = (int)(Math.Round((Double)(machineBox.ParticlesStation[i].DrugeValue / (Double)machineBox.BoxCount), 3) * 100);
                                    }
                                    //封口
                                    if (machineBox.Seal)
                                    {
                                        machineBox.BoxST[machineBox.HCcountseal].Gsealstate = true;
                                        machineBox.Seal = false;
                                    }
                                    //出盒
                                    if (machineBox.Outbox)
                                    {
                                        machineBox.BoxST[machineBox.HCcountoutbox].Outstate = true;
                                        machineBox.Outbox = false;
                                    }

                                    for (int iv = 1; iv < 9; iv++)
                                    {
                                        if (machineBox.ParticlesStation[iv].StartDeruge)
                                        {
                                            if (CheckWeight(machineBox.ParticlesStation[iv])) //检查当前余量是否足够调剂使用
                                            {
                                                machineBox.ParticlesStation[iv].Particlesstate = StationStatusEnum.余量不足;
                                            }
                                            machineBox.ParticlesStation[iv].StartDeruge = false;
                                        }
                                    }
                                    for (int d = 1; d < 17; d++)//更新进度条
                                    {
                                        if (machineBox.BoxST[d].PrescriptionID != null)
                                        {
                                            int c = (int)(machineBox.TBox * Math.Round((Double)(machineBox.BoxST[d].finishValue + 1) / (Double)(machineBox.ParticlesDetailp.Count + 3), 3));
                                            Boxbar = c + Boxbar;
                                        }
                                    }
                                    machineBox.Porbar = (int)(Boxbar + machineBox.Boxfinish * machineBox.TBox);
                                    machineBox.worksate = 20;
                                }
                                break;
                            case 20: //更新调剂工位当前状态判断出是否全部完成 取走药瓶
                                {
                                    bool Cstate = false; //判断是否关闭指示灯
                                    bool tbstate = false; //是否有药盒完成下药
                                    for (int i = 1; i < 9; i++)
                                    {
                                        if (machineBox.ParticlesStation[i].ParticlesCode != null)
                                        {
                                            for (int c = 1; c < 17; c++)
                                            {
                                                if (machineBox.BoxST[c].PrescriptionID == null)
                                                {
                                                    continue;
                                                }
                                                if (machineBox.BoxST[c].finishValue == machineBox.BoxST[c].ParticlesDetail.Count)
                                                {
                                                    tbstate = true;
                                                }

                                                var pd = machineBox.BoxST[c].ParticlesDetail.FirstOrDefault(x => x.ParticlesCode == machineBox.ParticlesStation[i].ParticlesCode);
                                                if (pd!=null && pd.finish) 
                                                {
                                                    BoxDfstate.Add(false);
                                                }
                                                if (pd != null && !pd.finish)
                                                {
                                                    BoxDfstate.Add(true);
                                                }
                                                //foreach (AdjustmentSys.Models.Machine.ParticlesDetail tb in machineBox.BoxST[c].ParticlesDetail)
                                                //{
                                                //    if (tb.ParticlesCode == machineBox.ParticlesStation[i].ParticlesCode)
                                                //    {
                                                //        if (tb.finish == true)
                                                //        {
                                                //            BoxDfstate.Add(false);
                                                //        }
                                                //        else
                                                //        {
                                                //            BoxDfstate.Add(true);
                                                //        }
                                                //    }
                                                //}
                                            }

                                            if (!Checkfinish(BoxDfstate))
                                            {
                                                machineBox.ParticlesStation[i].Colkstate = false;
                                                if (tbstate)//  摆瓶最后一轮
                                                {
                                                    if (machineBox.BoxCount != machineBox.NowboxCount)//盒子没有下完
                                                    {

                                                        int b = machineBox.ParticlesDetailp.Count % 8; //最后一次插瓶的数量
                                                        int n;
                                                        for (n = 1; n < machineBox.ParticlesStation.Length; n++)
                                                        {
                                                            if (machineBox.ParticlesStation[n].Particlesstate == StationStatusEnum.待调剂)
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
                                                            machineBox.ParticlesStation[i].Colkstate = true;
                                                        }
                                                        else
                                                        {

                                                            machineBox.ParticlesStation[i].Colkstate = false;
                                                        }
                                                    }
                                                }
                                                if (!machineBox.ParticlesStation[i].Colkstate || machineBox.ParticlesStation[i].DrugeValue == machineBox.BoxCount)
                                                {
                                                    machineBox.ParticlesStation[i].Particlesstate = StationStatusEnum.待取走;//工位待取走状态
                                                    var listParticlesDetai = machineBox.ParticlesDetailp.Where(d => d.ParticlesName == machineBox.ParticlesStation[i].ParticlesName).FirstOrDefault();
                                                    if (listParticlesDetai != null)
                                                    {

                                                        if (machineBox.BoxCount == machineBox.NowboxCount)
                                                        {
                                                            if (listParticlesDetai.state != 4)
                                                            {
                                                                Cstate = true;
                                                                listParticlesDetai.state = 4;    //颗粒设置为调剂完成                                        
                                                                prescriptionFactory.DeductStock(SysDeviceInfo._currentDeviceInfo.DeviceId, Convert.ToInt32(listParticlesDetai.ParticlesCode), SysLoginUser._currentUser.UserId, prescriptionModel, listParticlesDetai.DeductStockWeight); //扣除库存
                                                            }

                                                        }
                                                        else
                                                        {
                                                            listParticlesDetai.state = 2;  //颗粒设置为待放入
                                                            listParticlesDetai.DrugeValue = machineBox.ParticlesStation[i].DrugeValue;


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
                                        CloseLED(machineBox.ParticlesDetailp);
                                    }

                                    machineBox.worksate = 25;
                                }
                                break;
                            case 25: //判断出盒工位药瓶是否完成， 若完成清除当前药盒的信息
                                {
                                    //清除下药 清除供盒 清除出盒 清除封口
                                    for (int i = 1; i < machineBox.ParticlesStation.Length; i++)
                                    {
                                        if (machineBox.ParticlesStation[i].StartDeruge == true)
                                        {

                                            machineBox.ParticlesStation[i].StartDeruge = false;

                                        }
                                    }
                                    for (int c = 1; c < 17; c++)
                                    {

                                        if (machineBox.BoxST[c].Outstate)
                                        {
                                            machineBox.Boxfinish = machineBox.Boxfinish + 1;
                                            machineBox.BoxST[c] = AdjustmentSys.Models.Machine.BoxSTnull;
                                        }
                                    }
                                    if (!CheckDrugeRest())
                                    {
                                        machineBox.worksate = 30;
                                    }
                                }
                                break;

                            case 30:
                                {
                                    Savemachine(machineBox);
                                    machineBox.worksate = 31;
                                }
                                break;


                            case 31: //位移次数计算
                                {
                                    if (!machineBox.Stop && machineBox.AxisHomeStep == 0)
                                    {
                                        machineBox.EmoveCount = Emove(); //可以位移次数      
                                        machineBox.worksate = 35;
                                    }
                                }
                                break;
                            case 35://可以位移次数
                                {

                                    machineBox.yEmoveCount = machineBox.EmoveCount % machineBox.Maxbox; ;
                                    if (machineBox.MoveCount < machineBox.EmoveCount)
                                    {
                                        machineBox.worksate = 40;
                                    }
                                    else
                                    {
                                        machineBox.worksate = 31;
                                    }
                                }
                                break;

                            case 40: //转盘位移
                                {

                                    machineBox.Zmove = true;
                                    machineBox.worksate = 45;
                                }
                                break;
                            case 45://位移完成
                                {
                                    if (machineBox.Zmovefinsh)
                                    {
                                        machineBox.Zmovenuber = 1;
                                        machineBox.Zmove = false;
                                        machineBox.MoveCount = machineBox.MoveCount + 1;
                                        machineBox.worksate = 50;
                                    }
                                }
                                break;


                            case 50://判断出盒数量=完成数量 清除当前类
                                {
                                    Savemachine(machineBox);
                                    if (machineBox.Boxfinish == machineBox.BoxCount && machineBox.BoxCount > 0)
                                    {

                                        machineBox.worksate = 60;

                                    }
                                    else
                                    {
                                        if (machineBox.Boxfinish % 8 == 0 && machineBox.Boxfinish > 7 && machineBox.HCBoxfinish != machineBox.Boxfinish)
                                        {

                                            machineBox.worksate = 65;

                                        }
                                        else
                                        {
                                            machineBox.worksate = 1;
                                        }
                                    }
                                }
                                break;

                            case 67:
                                {

                                    if (machineBox.iError == 0)
                                    {
                                        machineBox.HCBoxfinish = machineBox.Boxfinish;
                                        machineBox.worksate = 1;
                                    }
                                }
                                break;
                            case 70://判断出盒数量=完成数量 清除当前类
                                {
                                    if (machineBox.PrescriptionID == null)
                                    {
                                        {
                                            Savemachine(machineBox);
                                            machineBox.worksate = 0;
                                        }
                                    }

                                }
                                break;
                        }
                    }
                    break;
            }
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

        /// <summary>
        /// 检查工位药瓶余量是否不足 记录当前扣除的库存量
        /// </summary>
        /// <param name="DG"></param>
        /// <returns></returns>
        private bool CheckWeight(AdjustmentSys.Models.Machine.DetailgG DG)
        {
            var listParticlesDetais = machineBox.ParticlesDetailp.Where(d => (d.ParticlesName == DG.ParticlesName)).FirstOrDefault();
            if (listParticlesDetais.Dweight < (listParticlesDetais.NewDose * 2 * (Math.Abs(DG.DrugeValue - listParticlesDetais.DrugeValue) + 1) + 10) && listParticlesDetais.state != 4)
            {
                //本次扣除库存量= 当前下药次数*每格重量*2 -已经扣除的库存量；
                double DeductStockWeight = Math.Round(listParticlesDetais.NewDose * 2 * DG.DrugeValue - listParticlesDetais.DeductStockWeight, 2);
                listParticlesDetais.state = 5;
                listParticlesDetais.DrugeValue = DG.DrugeValue;
                if (PresHandle.DeductStockStep(SysDeviceInfo._currentDeviceInfo.DeviceId, Convert.ToInt32(listParticlesDetais.ParticlesCode), SysLoginUser._currentUser.UserId, NewPresData, DeductStockWeight)) //提前扣除库存
                {
                    listParticlesDetais.DeductStockWeight = listParticlesDetais.DeductStockWeight + DeductStockWeight;

                }
                return true;
            }
            return false;
        }

        private bool Drugecheck(MachineBox OMachine)
        {
            foreach (AdjustmentSys.Models.Machine.DetailgG datai in machineBox.ParticlesStation) //下药完成检查
            {
                if (datai.StartDeruge)
                {
                    if (!datai.Derugefinish) 
                    {
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
            if (OMachine.Seal) //封口完成检查
            {
                if (!OMachine.Sealfinsh)
                {
                    return false;
                }
            }
            if (OMachine.Outbox) //封口完成检查
            {
                if (!OMachine.Outboxfinsh)
                {
                    return false;
                }
            }
            return true;
        }
        private int Emove() //可以位移次数
        {
            foreach (AdjustmentSys.Models.Machine.Med BoxST in machineBox.BoxST)
            {
                if (BoxST.ParticlesDetail == null)
                {
                    continue;
                }
                foreach (AdjustmentSys.Models.Machine.ParticlesDetail Pa in BoxST.ParticlesDetail)
                {
                    if (!Pa.finish)
                    {

                        if (machineBox.ParticlesStation[1].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[1].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[2].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[2].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[3].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[3].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[4].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[4].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[5].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[5].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[6].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[6].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[7].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[7].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                        if (machineBox.ParticlesStation[8].ParticlesCode == Pa.ParticlesCode && machineBox.ParticlesStation[8].Particlesstate == StationStatusEnum.待调剂) { return machineBox.MoveCount + 1; }
                    }

                }
                if (BoxST.finishValue >= machineBox.ParticlesDetailp.Count)
                {
                    return machineBox.MoveCount + 1;
                }
            }
            if (machineBox.Boxfinish == machineBox.BoxCount)
            {
                return machineBox.MoveCount + 1;
            }
            if (machineBox.NowboxCount < machineBox.BoxCount)
            {
                for (int c = 1; c < 17; c++)
                {
                    if (machineBox.BoxST[c].ParticlesDetail == null)
                    {
                        return machineBox.MoveCount + 1;
                    }

                }

            }
            return machineBox.MoveCount;
        }

        /// <summary>
        /// 判断是否有下药 封口 下盒 动作没有 直接跳过
        /// </summary>
        /// <param name="OMachine"></param>
        /// <returns></returns>
        private bool DrugeON()
        {
            foreach (AdjustmentSys.Models.Machine.DetailgG datai in machineBox.ParticlesStation) //下药完成检查
            {
                if (datai.HCStartDeruge)//启动调剂缓存
                {
                        return true;
                }
            }
            if (machineBox.HCMbox) //下盒完成检查缓存
            {
                return true;

            }
            if (machineBox.HCSeal) //封口完成检查缓存
            {
                return true;
            }
            if (machineBox.HCOutbox) //出盒完成检查缓存
            {
                return true;
            }
            return false;
        }

        private void Lopra()
        {
            machineBox.yMoveCount = machineBox.MoveCount % machineBox.Maxbox;//位移次数(转成1-16)=当前位移次数%盒子数量(16)；  
            if (machineBox.yMoveCount == 0 && machineBox.MoveCount < machineBox.Maxbox + 1)
            {
                machineBox.yMoveCount = machineBox.MoveCount;
            }
            if (machineBox.yMoveCount == 0 && machineBox.MoveCount > machineBox.Maxbox)
            {
                machineBox.yMoveCount = machineBox.Maxbox;
            }
            //下药， 出盒， 封口  , 下盒。计算
            for (int i = 1; i < machineBox.Maxbox + 1; i++) //i为工位序号
            {
                int f = machineBox.Maxbox - i;//16-i
                if (f == 0) { f = 16; }
                if (machineBox.yMoveCount + f > machineBox.Maxbox) //判断超出16
                {
                    f = machineBox.yMoveCount + f - machineBox.Maxbox;
                }
                else
                {
                    f = machineBox.yMoveCount + f;
                }
                if (i == 14) //下盒
                {
                    //已经下盒数量</盒子数量
                    if (machineBox.NowboxCount < machineBox.BoxCount && machineBox.BoxST[f].PrescriptionID == null) //当前下盒数量<处方需要盒数 执行下盒
                    {
                        machineBox.HCcountmbox = f;
                        machineBox.HCMbox = true;
                    }
                }
                if (machineBox.BoxST[f].ParticlesDetail != null && machineBox.worksate == 5)
                {
                    if (i < 9)//为下药工位
                    {
                        foreach (AdjustmentSys.Models.Machine.ParticlesDetail Detail in machineBox.BoxST[f].ParticlesDetail)
                        {
                            //工位颗粒编号==颗粒编号 && 工位状态为待调剂 && 颗粒完成为false  执行下药
                            if (machineBox.ParticlesStation[i].ParticlesCode == Detail.ParticlesCode && machineBox.ParticlesStation[i].Particlesstate == StationStatusEnum.待调剂 && !Detail.finish)
                            {
                                machineBox.ParticlesStation[i].HCStartDeruge = true;
                            }
                        }
                    }

                    if (i == 10)//封口
                    {
                        //药盒信息的封口状态==false && 颗粒完成状态为true
                        if (machineBox.BoxST[f].Gsealstate == false && CheckParComplete(machineBox.BoxST[f]))
                        {
                            machineBox.HCcountseal = f;
                            machineBox.HCSeal = true;
                        }
                    }
                    if (i == 12)//出盒
                    {
                        if (machineBox.BoxST[f].Gsealstate == true)
                        {
                            machineBox.HCcountoutbox = f;
                            machineBox.HCOutbox = true;
                        }
                    }
                }
            }
        }

        //检查颗粒完成状态，所有完成为true，有其中味未完成为false
        private bool CheckParComplete(AdjustmentSys.Models.Machine.Med med)
        {
            foreach (AdjustmentSys.Models.Machine.ParticlesDetail datai in med.ParticlesDetail) //下药完成检查
            {
                if (!datai.finish) //颗粒完成状态
                {
                        return false;
                }
            }
            return true;
        }
        ///2转盘
        /// 
        private void Rest()
        {
            if (machineBox.Sealfinsh)
            {
                machineBox.Seal = false;

            }

            if (machineBox.Mboxfinsh)
            {
                machineBox.Mbox = false;

            }
            if (machineBox.Zmovefinsh)
            {
                machineBox.Zmove = false;

            }
            for (int c = 1; c < 9; c++)
            {
                if (machineBox.ParticlesStation[c].Derugefinish)
                {
                    machineBox.ParticlesStation[c].StartDeruge = false;

                }
            }


        }
        /// <summary>
        /// 获取设备连接状态
        /// </summary>
        private void ReadE()
        {

            D200[12] = (short)(machineBox.iRestError >> 16);
            D200[11] = (short)(machineBox.iRestError & 0xFFFF);
            if (machineBox.iRestError > 0)
            {
                for (int i = 1; i < 33; i++)
                {
                    if (!DataProcessingTool.GetBitValue(machineBox.iError, i))
                    {
                        DataProcessingTool.ReverseBit32(ref machineBox.iRestError, (byte)i, false);
                    }
                }
            }
        }
    }
}
