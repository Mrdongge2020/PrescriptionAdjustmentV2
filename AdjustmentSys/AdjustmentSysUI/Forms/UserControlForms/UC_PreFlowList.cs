using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.UITool;
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
using static AdjustmentSys.Models.Machine.DataPrescriptionTB;

namespace AdjustmentSysUI.Forms.UserControlForms
{
    public partial class UC_PreFlowList : UIUserControl
    {
        public UC_PreFlowList()
        {
            InitializeComponent();
        }
        private UIPage uipage = new UIPage();
        public string? selectPreID;//选中的处方编号
        private string fileUrl = Application.StartupPath + "\\PreLoadfile.bin";
        public PrescriptionBinModel prescriptionBinModel = new PrescriptionBinModel();
        
        //public override void Init()
        //{
        //    base.Init();
        //    uiFlowLayoutPanel1.Clear();
        //    index = 0;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        uiButton1_Click(null, null);
        //    }
        //}

        private void btnPreLoad_Click(object sender, EventArgs e)
        {
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dataGradeViewUi.FormClose("FrmPrescriptionDownLoad");
            FrmPrescriptionDownLoad frmPrescriptionDownLoad = new FrmPrescriptionDownLoad();
            frmPrescriptionDownLoad.ShowDialog();
            List<string> preIdList = frmPrescriptionDownLoad.loadPrescriptionIdList;
            if (preIdList != null && preIdList.Count > 0)
            {
                if (prescriptionBinModel == null)
                {
                    prescriptionBinModel = new PrescriptionBinModel();
                }
                PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
                var preDatas = _prescriptionAdjustmentBLL.GetDownLoadedPres(preIdList);

                if (preDatas == null || preDatas.Count <= 0) { return; }

                foreach (var item in preDatas)
                {
                    //写入文件
                    if (prescriptionBinModel.LoadedPrescriptions != null && prescriptionBinModel.LoadedPrescriptions.Count > 0)
                    {
                        if (!prescriptionBinModel.LoadedPrescriptions.Any(x=>x.PrescriptionID==item.PrescriptionID))
                        {
                            prescriptionBinModel.LoadedPrescriptions.Add(item);
                        }
                    }
                    else
                    {
                        prescriptionBinModel.LoadedPrescriptions = new List<DownLoadedPre>();
                        prescriptionBinModel.LoadedPrescriptions.Add(item);
                    }
                }

                BinFileHelper.WriteObjectToBinaryFile(fileUrl, prescriptionBinModel);
                AddButton();
            } 
        }

        /// <summary>
        /// 处方下载控件
        /// </summary>
        public void AddButton()
        {
            //清除用Clear方法
            flpPreList.Clear();
            prescriptionBinModel = BinFileHelper.ReadObjectFromBinaryFile<PrescriptionBinModel>(fileUrl);
            if (prescriptionBinModel == null || prescriptionBinModel.LoadedPrescriptions.Count <= 0)
            {
                prescriptionBinModel = new PrescriptionBinModel();
                return;
            }

            foreach (var item in prescriptionBinModel.LoadedPrescriptions)
            {
                UC_PreFlowButton btn = new UC_PreFlowButton();
                btn.SetDPIScale();
                btn.Text = item.PrescriptionID;
                btn.Name = btn.Text;
                btn.Content = $"{item.PatientName}  {item.PatientSex}  {item.PatientAge}岁";
                btn.StatusStr = item.ProcessStatusText;
                btn.FSStr = item.Quantity + "付";
                btn.MouseClick += Btn_Click;
                btn.DoubleClick += Btn_DoubleClick;
                //建议用封装的方法Add
                flpPreList.Add(btn);
            }
        }

        /// <summary>
        /// 单击事件
        /// </summary>
        private void Btn_Click(object sender, MouseEventArgs e)
        {
            foreach (Control item in flpPreList.AllControls)
            {
                var buttonItem = (UC_PreFlowButton)item;
                buttonItem.BackColor = Color.LightSteelBlue;
                buttonItem.ContextMenuStrip = null;
            }
            var button = (UC_PreFlowButton)sender;
            button.BackColor = Color.FromArgb(135, 206, 235);
            button.ContextMenuStrip = this.cmsQZ;
            if (e.Button == MouseButtons.Right) // 确保是右键点击
            {
                // 显示ContextMenuStrip在鼠标点击的位置
                button.ContextMenuStrip.Show(button, e.Location); // 或使用MousePosition获取屏幕位置
            }
            selectPreID = button.Text;
        }

        /// <summary>
        /// 双击事件，核对处方
        /// </summary>
        private void Btn_DoubleClick(object sender, System.EventArgs e)
        {
            tsmiHDCF_Click(sender, e);
        }

        /// <summary>
        /// 核对处方
        /// </summary>
        private void tsmiHDCF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectPreID)) 
            {
                uipage.ShowWarningDialog("请先选择要核对的处方");
                return;
            }
            foreach (Control item in flpPreList.AllControls)
            {
                var buttonItem = (UC_PreFlowButton)item;
                if (buttonItem != null && buttonItem.Text == selectPreID)
                {
                    if (buttonItem.StatusStr == "已核对")
                    {
                        uipage.ShowWarningDialog("该处方已核对");
                    }
                    else
                    {
                        if (CheckPre())
                        {
                            buttonItem.StatusStr = "已核对";
                        }
                    }
                    break;
                }
            }
            
            
        }
        private bool CheckPre() 
        {
            bool isPass = false;

            try
            {
                List<string> checkedPreids = null;
                if (prescriptionBinModel != null && prescriptionBinModel.LoadedPrescriptions != null && prescriptionBinModel.LoadedPrescriptions.Count > 0)
                {
                    checkedPreids = prescriptionBinModel.LoadedPrescriptions.Select(x => x.PrescriptionID).ToList();
                }
                DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
                dataGradeViewUi.FormClose("FrmConfirmPrescription");
                FrmConfirmPrescription frmConfirmPrescription = new FrmConfirmPrescription(selectPreID, checkedPreids);
                frmConfirmPrescription.ShowDialog();
                bool isPassed = frmConfirmPrescription.isConfirmOK;
                if (isPassed)
                {
                    uipage.ShowSuccessTip($"处方[{selectPreID}]核对成功");
                    isPass = true;
                    OperateLog.WriteLog(LogTypeEnum.用户操作, SysLoginUser._currentUser.UserName + "成功核对处方["+ selectPreID+"]");

                    //写入到文件
                    if (prescriptionBinModel == null)
                    {
                        prescriptionBinModel = new PrescriptionBinModel();
                    }

                    //写入文件
                    if (prescriptionBinModel.CheckedPreInfos != null && prescriptionBinModel.CheckedPreInfos.Count > 0)
                    {
                        if (!prescriptionBinModel.CheckedPreInfos.Any(x => x.PrescriptionID == frmConfirmPrescription.preModel.PrescriptionID))
                        {
                            var predata= SetData(frmConfirmPrescription.preModel);
                            prescriptionBinModel.CheckedPreInfos.Add(predata);
                        }
                    }
                    else
                    {
                        prescriptionBinModel.CheckedPreInfos = new List<DataPrescriptionTB>();
                        var predata = SetData(frmConfirmPrescription.preModel);
                        prescriptionBinModel.CheckedPreInfos.Add(predata);
                    }

                    BinFileHelper.WriteObjectToBinaryFile(fileUrl, prescriptionBinModel);

                    OperateLog.WriteLog(LogTypeEnum.处方调剂, SysLoginUser._currentUser.UserName + "成功核对处方[" + selectPreID + "]已存入文件");
                }
                
            }
            catch (Exception e)
            {
                OperateLog.WriteLog(LogTypeEnum.系统异常, SysLoginUser._currentUser.UserName + "核对处方[" + selectPreID + "]出现异常，原因:"+e.Message);
            }
            return isPass;
        }

        private DataPrescriptionTB SetData(PreModel preModel) 
        {
            //获取处方
            PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
            var data = prescriptionBLL.GetAllPrescriptionInfo(preModel.PrescriptionID, ProcessStatusEnum.待调剂, false);
            if (data.Item1==null) {
                OperateLog.WriteLog(LogTypeEnum.处方调剂, SysLoginUser._currentUser.UserName + "成功核对处方[" + selectPreID + "]存入文件失败，未获取到处方信息");
            }
            LocalDataPrescriptionInfo preinfo = (LocalDataPrescriptionInfo)data.Item1;
            DataPrescriptionTB dataPrescriptionTB = new DataPrescriptionTB();
            dataPrescriptionTB.PrescriptionID = preModel.PrescriptionID;
            dataPrescriptionTB.PatientName = preModel.PatientName;
            dataPrescriptionTB.PatientSex = preModel.PatientSex == "女" ? SexEnum.女 : (preModel.PatientSex=="男"? SexEnum .男: SexEnum.保密);
            dataPrescriptionTB.PatientAge = preModel.PatientAge.Value;
            dataPrescriptionTB.PatientTel = preinfo.PatientTel;
            dataPrescriptionTB.PatientEmail = preinfo.PatientEmail;
            dataPrescriptionTB.PatientLocation = preinfo.PatientLocation;
            dataPrescriptionTB.DepartmentName= preinfo.DepartmentName;
            dataPrescriptionTB.DoctorName = preinfo.DoctorName;
            dataPrescriptionTB.CreateTime = preinfo.CreateTime;
            dataPrescriptionTB.CreateName = preinfo.CreateName;
            dataPrescriptionTB.ValuationTime = preinfo.ValuationTime;
            dataPrescriptionTB.ValuerName = preinfo.ValuerName;
            dataPrescriptionTB.ValueSn = preinfo.ValueSn;
            dataPrescriptionTB.PrescriptionType = preinfo.PrescriptionType;
            dataPrescriptionTB.BedNumber = preinfo.BedNumber;
            dataPrescriptionTB.PaymentType = preinfo.PaymentType;
            dataPrescriptionTB.ImportTime = preinfo.ImportTime;
            dataPrescriptionTB.Quantity = preinfo.Quantity;
            dataPrescriptionTB.TaskFrequency = preinfo.TaskFrequency;
            dataPrescriptionTB.UnitPrice = preinfo.UnitPrice;
            dataPrescriptionTB.TotalPrice = preinfo.TotalPrice;
            dataPrescriptionTB.DetailedCount = preinfo.DetailedCount;
            dataPrescriptionTB.ProcessStatus = (int)preinfo.ProcessStatus;
            dataPrescriptionTB.PrescriptionSource = preinfo.PrescriptionSource;
            dataPrescriptionTB.Remarks = preinfo.Remarks;
            dataPrescriptionTB.UsageMethod = preinfo.UsageMethod;
            dataPrescriptionTB.RegisterID = preinfo.RegisterID;
            dataPrescriptionTB.BackupField1 = preinfo.BackupField1;
            dataPrescriptionTB.BackupField2 = preinfo.BackupField2;
            dataPrescriptionTB.BackupField3 = preinfo.BackupField3;

            List<DetailStructure> deList = new List<DetailStructure>();
            if (preModel.Details != null && preModel.Details.Count > 0)
            {
                foreach (var item in preModel.Details)
                {
                    DetailStructure detailStructure = new DetailStructure();
                    detailStructure.PrescriptionID = item.PrescriptionID;
                    detailStructure.ParticleOrder = item.ParticleOrder;
                    detailStructure.ParticlesName = item.ParName;
                    detailStructure.ParticlesCodeHIS = item.ParticlesCodeHIS;
                    detailStructure.ParticlesNameHIS = item.ParticlesNameHIS;
                    detailStructure.ParticlesID = item.ParCode;
                    detailStructure.DoseHerb = item.DoseHerb;
                    detailStructure.Dose = item.Dose;
                    detailStructure.Equivalent = item.Equivalent;
                    detailStructure.BatchNumber = item.BatchNumber;
                    detailStructure.Price = item.Price;
                    detailStructure.RFID = item.MedicineCabinetDetail.RFID;

                    if (item.MedicineCabinetDetail!=null) {
                        CabinetStorageInfoTB cabinetStorageInfoTB = new CabinetStorageInfoTB();
                        cabinetStorageInfoTB.CabinetID = item.MedicineCabinetDetail.MedicineCabinetId;
                        cabinetStorageInfoTB.ParticlesID = item.ParCode;
                        cabinetStorageInfoTB.CoordinateX = item.MedicineCabinetDetail.CoordinateX;
                        cabinetStorageInfoTB.CoordinateY = item.MedicineCabinetDetail.CoordinateY;
                        cabinetStorageInfoTB.BatchNumber = item.MedicineCabinetDetail.BatchNumber;
                        cabinetStorageInfoTB.ParticlesStockQuantity = item.MedicineCabinetDetail.Stock.Value;
                        cabinetStorageInfoTB.CoefficientTotalAmountUse = item.MedicineCabinetDetail.TotalErrorAmount.Value;
                        cabinetStorageInfoTB.LastTotalAmountUse = item.MedicineCabinetDetail.BottleHeadAdjustAmount.Value;
                        cabinetStorageInfoTB.LastWeightTotalAmountUse = item.MedicineCabinetDetail.LastCoefficientErrorAmount.Value;
                        cabinetStorageInfoTB.OnyTotalAmountUse = item.MedicineCabinetDetail.CurentAdjustAmount.Value;
                        cabinetStorageInfoTB.TotalAmountUse = item.MedicineCabinetDetail.TotalUsedAmount.Value;
                        cabinetStorageInfoTB.DensityCoefficient = item.MedicineCabinetDetail.DensityCoefficient.Value;
                        cabinetStorageInfoTB.MaturityDate = item.MedicineCabinetDetail.ValidityTime.Value;
                        cabinetStorageInfoTB.EmptyBottleWeigh = item.MedicineCabinetDetail.EmptyBottleWeight.Value;
                        cabinetStorageInfoTB.InPosition = item.MedicineCabinetDetail.LastWeightAmount.Value;
                        cabinetStorageInfoTB.DParticlesID = item.MedicineCabinetDetail.RFID.Value;
                        cabinetStorageInfoTB.ParticlesName = item.ParName;

                        detailStructure.CabinetParticles = cabinetStorageInfoTB;
                    }

                    deList.Add(detailStructure);
                }
            }
            dataPrescriptionTB.ParticlesDetail= deList;

            return dataPrescriptionTB;
        }
        /// <summary>
        /// 复位处方
        /// </summary>
        private void tsmiFWCF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectPreID))
            {
                uipage.ShowWarningDialog("请先选择要复位的处方");
                return;
            }
            PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
            var isSuccess = _prescriptionAdjustmentBLL.ReturnPrescription(selectPreID);
            if (isSuccess)
            {
                OperateLog.WriteLog(LogTypeEnum.用户操作, $"处方[{selectPreID}]已成功复位");
                uipage.ShowSuccessTip($"处方[{selectPreID}]已成功复位");
                int index= prescriptionBinModel.LoadedPrescriptions.RemoveAll(x=>x.PrescriptionID== selectPreID);
                if (index>0) 
                {
                    //写入文件
                    BinFileHelper.WriteObjectToBinaryFile(fileUrl, prescriptionBinModel);
                    //根据名称获取
                    var btn = flpPreList.Get(selectPreID);
                    if (btn != null)
                    {
                        flpPreList.Remove(btn);
                        selectPreID = "";
                    }
                }
            }
            else
            {
                OperateLog.WriteLog(LogTypeEnum.系统异常, $"处方[{selectPreID}]复位失败");
                uipage.ShowErrorDialog("错误提示", $"处方[{selectPreID}]复位失败，请稍后再试");
            }
        }
    }
}
