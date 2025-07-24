using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Prescription;
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
                        buttonItem.StatusStr = "已核对";
                    }
                    break;
                }
            }
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
