using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Tool.Enums;
using AdjustmentSysUI.Forms.PrescriptionForms;
using AdjustmentSysUI.UITool;
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
    public partial class UC_PreLoadedList1 : UserControl
    {
        DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
        string fileUrl = Application.StartupPath + "\\testbinfile.bin";
        private List<string> DownLoadPreIdList = new List<string>();
        string selectPreId = "";//选中的处方编号
        public UC_PreLoadedList1()
        {
            InitializeComponent();
        }

        //private void lblDownLoad_Click(object sender, EventArgs e)
        //{
        //    dataGradeViewUi.FormClose("FrmPrescriptionDownLoad");
        //    FrmPrescriptionDownLoad frmPrescriptionDownLoad = new FrmPrescriptionDownLoad();
        //    frmPrescriptionDownLoad.ShowDialog();
        //    List<string> preIdList = frmPrescriptionDownLoad.loadPrescriptionIdList;
        //    if (preIdList != null && preIdList.Count > 0)
        //    {
        //        AddButton(preIdList);
        //    }
        //}
        //private void AddButton(List<string> preIdList)
        //{
        //    //获取数据
        //    var preDatas = _prescriptionAdjustmentBLL.GetDownLoadedPres(preIdList);
        //    if (preDatas == null || preDatas.Count <= 0) { return; }

        //    UC_PreButton btn;
        //    foreach (var item in preDatas)
        //    {
        //        //已有此处方，就不在加载button
        //        if (DownLoadPreIdList.Contains(item.PrescriptionID)) { continue; }

        //        btn = new UC_PreButton();
        //        //btn.SetDPIScale();
        //        string btnText = "处方编号：" + item.PrescriptionID + "\r\n" + $@"患者姓名：" + item.PatientName + "\r\n" + "患者性别：" + item.PatientSex + "\r\n"
        //            + "处方付数：" + item.Quantity + "\r\n" + "处方状态：" + item.ProcessStatusText;
        //        btn.Text = btnText;
        //        btn.Name = item.PrescriptionID;
        //        btn.BackColor = Color.White;
        //        btn.Click += Btn_Click;
        //        if (item.ProcessStatus == ProcessStatusEnum.待核对)
        //        {
        //            btn.FillColor = Color.Red;
        //        }
        //        //用封装的方法Add
        //        FLPpreLoad.Add(btn);
        //        //放到已下载列表
        //        DownLoadPreIdList.Add(item.PrescriptionID);
        //    }
        //    //this.Render();
        //}
        //private void Btn_Click(object sender, System.EventArgs e)
        //{
        //    foreach (Control item in FLPpreLoad.AllControls)
        //    {
        //        item.BackColor = Color.White;
        //    }
        //    var button = (UC_PreButton)sender;
        //    button.BackColor = Color.DarkGreen;
        //    selectPreId = button.Name;
        //    //MessageBox.Show(button.Name);
        //}

        //private void 复位处方ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (selectPreId == "")
        //    {
        //        //UIMessageDialog.ShowWarningDialog("异常提示", "请先选择要复位的处方");
        //        return;
        //    }
        //    PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
        //    var errorMsg = prescriptionBLL.UpdatePrescriptionStatus(new List<string> { selectPreId }, ProcessStatusEnum.待下载);
        //    if (errorMsg == "")
        //    {
        //        MessageBox.Show($"处方[{selectPreId}]已成功复位");
        //        DownLoadPreIdList.Remove(selectPreId);
        //        var btn = FLPpreLoad.Get(selectPreId);
        //        if (btn != null)
        //        {
        //            FLPpreLoad.Remove(btn);
        //        }
        //    }
        //    else
        //    {
        //        //ShowErrorDialog("错误提示", errorMsg);
        //    }
        //}
    }
}
