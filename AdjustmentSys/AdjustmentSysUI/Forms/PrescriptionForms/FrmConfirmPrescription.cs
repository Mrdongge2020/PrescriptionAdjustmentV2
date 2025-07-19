using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.FileModel;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
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

namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    public partial class FrmConfirmPrescription : UIForm
    {
        PrescriptionBLL prescriptionBLL = new PrescriptionBLL();
        PrescriptionAdjustmentBLL _prescriptionAdjustmentBLL = new PrescriptionAdjustmentBLL();
        private string _preId = "";
        private List<string> _preIds = null;
        List<CheckPrescriptionResultModel> errorList = null;
        ///List<ConfirmLocalDataPrescriptionDetail> details = new List<ConfirmLocalDataPrescriptionDetail>();
        ///
        public PreModel preModel = null;
        private int clickErrorType = 0;//错误列表显示的错误类型
        public bool isConfirmOK = false;//确认是否通过

        public FrmConfirmPrescription(string preId, List<string> preIds)
        {
            _preId = preId;
            _preIds = preIds;
            InitializeComponent();
        }
        private void FrmConfirmPrescription_Load(object sender, EventArgs e)
        {
            InitDgv();
            BindPreInfo();
        }
        private void BindPreInfo()
        {

            var data = prescriptionBLL.GetAllPrescriptionInfo(_preId, ProcessStatusEnum.待核对, true);
            if (data.Item1 == null)
            {
                ClearPreInfo();
                return;
            }

            //处方主信息
            LocalDataPrescriptionInfo localDataPrescriptionInfo = (LocalDataPrescriptionInfo)data.Item1;
            lblCFBH.Text = localDataPrescriptionInfo.PrescriptionID;
            lblXM.Text = localDataPrescriptionInfo.PatientName;
            lblXB.Text = localDataPrescriptionInfo.PatientSex.ToString();
            lblNLYF.Text = localDataPrescriptionInfo.PatientAge + "岁/" + localDataPrescriptionInfo.PatientBirthMonth + "月";
            lblKFYS.Text = localDataPrescriptionInfo.DoctorName;
            lblKS.Text = localDataPrescriptionInfo.DepartmentName;
            lblFSFFCS.Text = localDataPrescriptionInfo.Quantity + "/" + localDataPrescriptionInfo.TaskFrequency;
            lblBZ.Text = localDataPrescriptionInfo.Remarks;
            lblXDFMC.Text = localDataPrescriptionInfo.PrescriptionName;
            lblLRY.Text = localDataPrescriptionInfo.CreateName;
            lblCFLY.Text = localDataPrescriptionInfo.PrescriptionSource == 0 ? "HIS系统" : "TMS系统";
            lblDFJG.Text = localDataPrescriptionInfo.UnitPrice.ToString();
            lblCFZJ.Text = localDataPrescriptionInfo.TotalPrice.ToString();

            preModel = new PreModel();
            preModel.PrescriptionID = localDataPrescriptionInfo.PrescriptionID;
            preModel.PatientName= localDataPrescriptionInfo.PatientName;
            preModel.PatientSex = localDataPrescriptionInfo.PatientSex.ToString();
            preModel.PatientAge = localDataPrescriptionInfo.PatientAge;
            preModel.Quantity = localDataPrescriptionInfo.Quantity;
            preModel.TaskFrequency = localDataPrescriptionInfo.TaskFrequency;
            preModel.DetailedCount = localDataPrescriptionInfo.DetailedCount;
            preModel.CreateTime = localDataPrescriptionInfo.CreateTime;
            preModel.UsageMethod = localDataPrescriptionInfo.UsageMethod;
            preModel.ProcessStatus = localDataPrescriptionInfo.ProcessStatus;

            //详情绑定
            dgvList.DataSource = data.Item2;

            //规则检查
            PreCheck(localDataPrescriptionInfo, data.Item2);
        }

        private void InitDgv()
        {
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "主键", true, false, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticleOrder", "序号", true, true, 50, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParCode", "颗粒编号", true, true, 90, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParName", "颗粒名称", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoseHerb", "饮片剂量", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Equivalent", "当量", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Dose", "颗粒剂量", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Price", "单价", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticlesNameHIS", "HIS名称", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ParticlesCodeHIS", "HIS码", true, true, 80, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "BatchNumber", "批号", true, true, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Stock", "库存", true, false, 100, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "DoseLimit", "剂量上限", true, false, 100, "");
        }
        private void ClearPreInfo()
        {
            lblCFBH.Text = string.Empty;
            lblXM.Text = string.Empty;
            lblXB.Text = string.Empty;
            lblNLYF.Text = string.Empty;
            lblKFYS.Text = string.Empty;
            lblKS.Text = string.Empty;
            lblFSFFCS.Text = string.Empty;
            lblBZ.Text = string.Empty;
            lblXDFMC.Text = string.Empty;
            lblLRY.Text = string.Empty;
            lblCFLY.Text = string.Empty;
            lblDFJG.Text = string.Empty;
            lblCFZJ.Text = string.Empty;

            dgvList.Rows.Clear();

            lbResultMsg.Items.Clear();

        }
        private void PreCheck(LocalDataPrescriptionInfo localDataPrescriptionInfo, List<PrescriptionDetailModel> prescriptionDetails)
        {
            var result = _prescriptionAdjustmentBLL.CheckPrescription(localDataPrescriptionInfo, prescriptionDetails, _preIds);
            //校验信息
            errorList = result.Item1;
            //处方详情
            preModel.Details= result.Item2;

            if (errorList == null || errorList.Count(x => !x.IsPass) <= 0)
            {
                lblCheckResult1.Text = "通过";
                lblCheckResult1.LinkColor = Color.Green;
                lblCheckResult4.Text = "通过";
                lblCheckResult4.LinkColor = Color.Green;
                lblCheckResult3.Text = "通过";
                lblCheckResult3.LinkColor = Color.Green;
                lblCheckResult2.Text = "通过";
                lblCheckResult2.LinkColor = Color.Green;
                btnOK.Enabled = true;
                return;
            }

            lbResultMsg.Items.Clear();
            for (int i = 1; i <= 4; i++)
            {
                LinkLabel LinkLabel = FindControlByName<LinkLabel>("lblCheckResult" + i);
                var errors = errorList.Where(x => x.ErrorType == i && !x.IsPass).ToList();
                if (errors != null && errors.Count > 0)
                {
                    if (LinkLabel != null)
                    {
                        LinkLabel.Text = "未通过，查看详情";
                        LinkLabel.LinkColor = Color.Red;
                    }
                    if (lbResultMsg.Items.Count <= 0)
                    {
                        foreach (CheckPrescriptionResultModel item in errors)
                        {
                            lbResultMsg.Items.Add(item.ErrorMessage);
                        }
                        clickErrorType = i;
                    }
                    btnOK.Enabled = false;
                    btnSayOK.Enabled = i == 4 ? false : true;
                }
                else
                {
                    if (LinkLabel != null)
                    {
                        LinkLabel.Text = "通过";
                        LinkLabel.LinkColor = Color.Green;
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSayOK_Click(object sender, EventArgs e)
        {
            if (!this.ShowAskDialog("忽略提示", "确定要忽略列表中展示的相关异常信息吗", UIStyle.Blue, false, UIMessageDialogButtons.Ok))
            {
                return;
            }
            foreach (var item in errorList)
            {
                if (item.ErrorType == clickErrorType && !item.IsPass)
                {
                    item.IsPass = true;
                }
            }

            lbResultMsg.Items.Clear();
            btnSayOK.Enabled=false;
            LinkLabel LinkLabel = FindControlByName<LinkLabel>("lblCheckResult" + clickErrorType);
            if (LinkLabel != null)
            {
                LinkLabel.Text = "通过";
                LinkLabel.LinkColor = Color.Green;
            }

            if (!errorList.Any(x => !x.IsPass))
            {
                btnOK.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isSuccess = _prescriptionAdjustmentBLL.ConfirmPrescription(_preId);
            if (isSuccess)
            {
                isConfirmOK = true;
                this.Close();
            }
            else
            {
                this.ShowErrorDialog("确认处方失败，请稍后再试");
            }
        }

        private void lblCheckResult1_Click(object sender, EventArgs e)
        {
            BindError(1);
            clickErrorType = 1;
        }

        private void lblCheckResult4_Click(object sender, EventArgs e)
        {
            BindError(4);
            clickErrorType = 4;
        }

        private void lblCheckResult3_Click(object sender, EventArgs e)
        {
            BindError(3);
            clickErrorType = 3;
        }

        private void lblCheckResult2_Click(object sender, EventArgs e)
        {
            BindError(2);
            clickErrorType = 2;
        }
        private void BindError(int errortype)
        {
            lbResultMsg.Items.Clear();
            var errordatas = errorList.Where(x => x.ErrorType == errortype && !x.IsPass).ToList();
            if (errordatas != null && errordatas.Count > 0)
            {
                foreach (CheckPrescriptionResultModel item in errordatas)
                {
                    lbResultMsg.Items.Add(item.ErrorMessage);
                }
                if (errortype != 4)
                {//非法调剂数据不能忽略哦
                    btnSayOK.Enabled = true;
                }
                else
                {
                    btnSayOK.Enabled = false;
                }

            }
            if (!errorList.Any(x => !x.IsPass))
            {
                btnOK.Enabled = true;
            }
        }

        // 通用方法来按名称查找控件
        private T FindControlByName<T>(string name) where T : Control
        {
            // 调用Controls.Find方法查找控件
            T control = this.Controls.Find(name, true).FirstOrDefault() as T;
            return control;
        }

    }
}
