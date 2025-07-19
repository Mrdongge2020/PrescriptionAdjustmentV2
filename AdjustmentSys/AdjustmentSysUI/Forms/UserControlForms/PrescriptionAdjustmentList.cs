using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.UITool;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class PrescriptionAdjustmentList : UserControl
    {
        DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
        string fileUrl = Application.StartupPath + "\\testbinfile.bin";
        private List<string> DownLoadPreIdList = new List<string>();
        string selectPreId = "";//选中的处方编号

        public PrescriptionAdjustmentList()
        {
            InitializeComponent();
        }

        private void InitDownLoadPre()
        {
            //从文件拿取

            DownLoadPreModel downLoadPreModel = new DownLoadPreModel();
            //downLoadPreModel.LoadedPreIds = new List<string>() { "60722445406002" };
            //BinFileHelper.WriteObjectToBinaryFile(fileUrl, downLoadPreModel);

            var readedDownLoadPreModel = BinFileHelper.ReadObjectFromBinaryFile<DownLoadPreModel>(fileUrl);
            if (readedDownLoadPreModel != null && readedDownLoadPreModel.LoadedPreIds.Count > 0)
            {
                AddButton(readedDownLoadPreModel.LoadedPreIds);
            }
        }
        private void AddButton(List<string> preIdList)
        {
            //获取数据
            var preDatas = _prescriptionAdjustmentBLL.GetDownLoadedPres(preIdList);
            if (preDatas == null || preDatas.Count <= 0) { return; }

            UC_PreButton btn;
            foreach (var item in preDatas)
            {
                //已有此处方，就不在加载button
                if (DownLoadPreIdList.Contains(item.PrescriptionID)) { continue; }

                btn = new UC_PreButton();
                //btn.SetDPIScale();
                string btnText = "处方编号：" + item.PrescriptionID + "\r\n" + $@"患者姓名：" + item.PatientName + "\r\n" + "患者性别：" + item.PatientSex + "\r\n"
                    + "处方付数：" + item.Quantity + "\r\n" + "处方状态：" + item.ProcessStatusText;
                btn.Text = btnText;
                btn.Name = item.PrescriptionID;
                btn.BackColor = Color.White;
                btn.Click += Btn_Click;
                if (item.ProcessStatus == ProcessStatusEnum.待核对)
                {
                    btn.FillColor = Color.Red;
                }
                //用封装的方法Add
                //uiFlowLayoutPanel1.Add(btn);
                //放到已下载列表
                DownLoadPreIdList.Add(item.PrescriptionID);
            }
            //this.Render();
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            //foreach (Control item in uiFlowLayoutPanel1.AllControls)
            //{
            //    item.BackColor = Color.White;
            //}
            var button = (UC_PreButton)sender;
            button.BackColor = Color.DarkGreen;
            selectPreId = button.Name;
            //MessageBox.Show(button.Name);
        }

        private void FrmBoxedDevice_Load(object sender, EventArgs e)
        {
            InitDownLoadPre();
        }
        private void UC_PrescriptionAdjustmentList_Load(object sender, EventArgs e)
        {
            //List<DownLoadedPre> dlist = new List<DownLoadedPre>();
            //for (int i = 0; i < 5; i++)
            //{
            //    DownLoadedPre model = new DownLoadedPre();
            //    model.PrescriptionID = "xt20240810" + i;
            //    model.PatientName = "患者" + i;
            //    model.Quantity = 10;
            //    model.PatientAge = 20;
            //    model.PatientSex= SexEnum.女.ToString();
            //    model.ProcessStatus = "已下载";
            //}
            //UC_PreButton btn;
            //foreach (var item in dlist)
            //{
            //    btn = new UC_PreButton();
            //    //btn.SetDPIScale();
            //    string btnText = btn.Name+"\r\n"+ $@"患者姓名:" + item.PatientName + "\r\n" + "患者性别:" + item.PatientSex + "\r\n"
            //        + "处方付数:" + item.Quantity + "\r\n" + "处方状态:" + item.ProcessStatus;
            //    btn.Text = btnText;
            //    btn.Name ="处方编号:"+item.PrescriptionID;
            //    //btn.Click += Btn_Click;
            //    btn.BackColor = Color.Blue;
            //    //建议用封装的方法Add
            //    uiFlowLayoutPanel1.Add(btn);
            //}

            //lblDownLoadCount.Text = "已下载列表(" + dlist.Count + ")";
            //this.Render();
        }

        private void lblDownLoad_Click(object sender, EventArgs e)
        {
            dataGradeViewUi.FormClose("FrmPrescriptionDownLoad");
            FrmPrescriptionDownLoad frmPrescriptionDownLoad = new FrmPrescriptionDownLoad();
            frmPrescriptionDownLoad.ShowDialog();
            List<string> preIdList = frmPrescriptionDownLoad.loadPrescriptionIdList;
            if (preIdList != null && preIdList.Count > 0)
            {
                AddButton(preIdList);
            }
        }

        //private void 复位处方ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (selectPreId == "")
        //    {
        //        //UIMessageDialog.this.ShowWarningDialog("异常提示", "请先选择要复位的处方");
        //        return;
        //    }
        //    PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
        //    var errorMsg = prescriptionBLL.UpdatePrescriptionStatus(new List<string> { selectPreId }, ProcessStatusEnum.待下载);
        //    if (errorMsg == "")
        //    {
        //        MessageBox.Show($"处方[{selectPreId}]已成功复位");
        //        DownLoadPreIdList.Remove(selectPreId);
        //        //var btn = uiFlowLayoutPanel1.Get(selectPreId);
        //        //if (btn != null)
        //        //{
        //        //    uiFlowLayoutPanel1.Remove(btn);
        //        //}
        //    }
        //    else
        //    {
        //        //this.ShowErrorDialog("错误提示", errorMsg);
        //    }
        //}
    }
}
