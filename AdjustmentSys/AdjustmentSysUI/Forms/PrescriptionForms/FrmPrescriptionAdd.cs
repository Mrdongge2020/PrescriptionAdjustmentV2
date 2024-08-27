using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Prescription;
using AdjustmentSys.Tool.Enums;
using AdjustmentSysUI.UITool;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    public partial class FrmPrescriptionAdd : UIForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        PrescriptionBLL _prescriptionBLL = new PrescriptionBLL();
        List<int> parIdList = new List<int>();//已添加的药品id
        List<ComboxModel> durgDLData = new List<ComboxModel>();//药柜药品数据
        private string PreId = "";//复制的处方编号
        private int? PreStatus;//复制的处方状态
        private int? agreementPrescriptionId;//要生成的协定方id
        public string saveMessage = "";
        public FrmPrescriptionAdd(string preId, int? preStatus, int? agreementPrescriptionId)
        {
            InitializeComponent();
            PreId = preId;
            PreStatus = preStatus;
            this.agreementPrescriptionId = agreementPrescriptionId;

        }

        private void FrmPrescriptionAdd_Load(object sender, EventArgs e)
        {
            saveMessage = "";
            InitData();
            InitPreData(PreId);
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            durgDLData = _comboxDataBLL.GetCabinetParticlesComboxData();
            cbDurg.ValueMember = "Id";
            cbDurg.DisplayMember = "Name";
            cbDurg.DataSource = durgDLData;
            cbDurg.SelectedIndex = -1;

            List<ComboxModel> docDatas = _comboxDataBLL.GetDoctorComboxData();
            cbDoctorName.ValueMember = "Id";
            cbDoctorName.DisplayMember = "Name";
            cbDoctorName.DataSource = docDatas;
            cbDoctorName.SelectedIndex = -1;
        }

        private void cbDoctorName_SelectedValueChanged(object sender, EventArgs e)
        {
            int docId = cbDoctorName.SelectedValue == null ? 0 : (int)cbDoctorName.SelectedValue;
            if (docId == 0)
            {
                txtDocDepartment.Text = string.Empty;
                return;
            }

            string depName = _prescriptionBLL.GetDoctorDepartment(docId);
            txtDocDepartment.Text = depName;
        }

        private void InitPreData(string preId)
        {
            txtPrID.Text = (Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")) * 3).ToString();
            if (agreementPrescriptionId.HasValue) //协定方录入处方，清空处方数据
            {
                InitAddPreData();

            }
            else if (preId == "") //新增处方，清空处方数据
            {
                InitAddPreData();
            }
            else //展示复制的处方
            {
                InitCopyPreData();
            }
        }

        /// <summary>
        /// 清空所有控件值
        /// </summary>
        private void InitAddPreData()
        {
            //处方数据
            txtPatName.Text = string.Empty;
            txtPatPhone.Text = string.Empty;
            cbSex.SelectedIndex = -1;
            iudAgeYear.Value = 20;
            iupAgeMonth.Value = 6;
            iudFS.Value = 0;
            iudFFCS.Value = 2;
            cbDoctorName.SelectedIndex = -1;
            txtDocDepartment.Text = string.Empty;
            txtRemark.Text = string.Empty;
            //药品数据
            cbDurg.SelectedIndex = -1;
            cbJLFS.SelectedIndex = 0;
            dudJL.Value = 0;
            dgvDurgList.Rows.Clear();
            parIdList = new List<int>();
            //分析数据
            lbCheckResult.Items.Clear();
            txtXDFMC.Text = string.Empty;
            if (agreementPrescriptionId.HasValue) 
            {
                InitCopyPreData();
            }
            
        }

        private void InitCopyPreData()
        {
            List<PrescriptionDetailModel> delist = new List<PrescriptionDetailModel>();
            if (!agreementPrescriptionId.HasValue)//编辑 
            {
                var preInfo = _prescriptionBLL.GetPrescriptionInfo(PreId, (ProcessStatusEnum)PreStatus);
                if (preInfo == null) { return; }
                //处方数据
                txtPatName.Text = preInfo.PatientName;
                txtPatPhone.Text = preInfo.PatientTel;
                cbSex.SelectedIndex = (int)preInfo.PatientSex;
                iudAgeYear.Value = preInfo.PatientAge ?? 20;
                iupAgeMonth.Value = preInfo.PatientBirthMonth ?? 6;
                iudFS.Value = preInfo.Quantity;
                iudFFCS.Value = preInfo.TaskFrequency;
                cbDoctorName.Text = preInfo.DoctorName;
                txtDocDepartment.Text = preInfo.DepartmentName;
                txtRemark.Text = preInfo.Remarks;

                dgvDurgList.Rows.Clear();
                parIdList = new List<int>();
                lbCheckResult.Items.Clear();
                txtXDFMC.Text = string.Empty;

                delist = preInfo.Details;
            }
            else
            {
                delist = _prescriptionBLL.GetAgreementPrescriptionDetailsV1((int)agreementPrescriptionId);
            }

            if (delist == null || delist.Count <= 0) { return; }

            List<ParticlesInfoModel> particleList = new List<ParticlesInfoModel>();
            foreach (var parinfo in delist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvDurgList);
                // 设置新添加的行的单元格值
                //row.Cells["ID"].Value = parinfo.ParticlesID;
                //row.Cells["ParName"].Value = parinfo.ParName;
                //row.Cells["HisCode"].Value = parinfo.ParticlesCodeHIS;
                //row.Cells["Code"].Value = parinfo.ParCode;
                //row.Cells["DoseHerb"].Value = parinfo.DoseHerb;
                //row.Cells["Equivalent"].Value = parinfo.Equivalent;
                //row.Cells["Dose"].Value = parinfo.Dose;
                //row.Cells["Stock"].Value = parinfo.Stock;
                //row.Cells["RetailPrice"].Value = parinfo.Price;
                //row.Cells["TotalPrice"].Value = Math.Round(parinfo.Price * (decimal)parinfo.DoseHerb, 3);

                row.Cells[0].Value = parinfo.ParticlesID;
                row.Cells[1].Value = parinfo.ParCode;
                row.Cells[2].Value = parinfo.ParName;
                row.Cells[3].Value = parinfo.ParticlesCodeHIS;
                row.Cells[4].Value = parinfo.DoseHerb;
                row.Cells[5].Value = parinfo.Equivalent;
                row.Cells[6].Value = parinfo.Dose;
                row.Cells[7].Value = parinfo.Stock;
                row.Cells[8].Value = parinfo.Price;
                row.Cells[9].Value = Math.Round(parinfo.Price * (decimal)parinfo.DoseHerb, 3);
                dgvDurgList.Rows.Insert(0, row);
                parIdList.Add(parinfo.ParticlesID);
                particleList.Add(new ParticlesInfoModel()
                {
                    ID = parinfo.ParticlesID,
                    ParName = parinfo.ParName,
                    HisCode = parinfo.ParticlesCodeHIS,
                    Code = parinfo.ParCode,
                    Equivalent = parinfo.Equivalent,
                    DoseHerb = parinfo.DoseHerb,
                    Dose = parinfo.Dose,
                    DoseLimit = parinfo.DoseLimit,
                    RetailPrice = parinfo.Price,
                    Stock = parinfo.Stock
                });
            }

            //加合计行
            dgvFooter.Clear();
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dgvFooter["ParName"] = "合计：";
            dgvFooter["DoseHerb"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "DoseHerb").ToString();
            dgvFooter["Dose"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "Dose").ToString();
            dgvFooter["Price"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "Price").ToString();
            dgvFooter["TotalPrice"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "TotalPrice").ToString();

            this.dgvDurgList.TopLeftHeaderCell.Value = "共" + parIdList.Count.ToString() + "条";
            dgvDurgList.ClearSelection();

            foreach (var parinfo in particleList)
            {
                //校验
                AddDurgCheck(parinfo, false);
            }

        }

        private void txtPrID_ButtonClick(object sender, EventArgs e)
        {
            txtPrID.Text = (Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")) * 3).ToString();
        }

        private void txtPrID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //使用户的输入失效
        }

        /// <summary>
        /// 提交处方校验
        /// </summary>
        private bool SubmitPreCheck()
        {
            if (string.IsNullOrEmpty(txtPrID.Text))
            {
                ShowWarningDialog("异常提示", "处方编号不能为空");
                txtPrID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPatName.Text))
            {
                ShowWarningDialog("异常提示", "患者姓名不能为空");
                txtPatName.Focus();
                return false;
            }

            if (iudFS.Value <= 0)
            {
                ShowWarningDialog("异常提示", "付数必须大于0");
                iudFS.Focus();
                return false;
            }
            if (iudFFCS.Value <= 0)
            {
                ShowWarningDialog("异常提示", "分服次数必须大于0");
                iudFFCS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbDoctorName.Text))
            {
                ShowWarningDialog("异常提示", "医生姓名不能为空");
                cbDoctorName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDocDepartment.Text))
            {
                ShowWarningDialog("异常提示", "医生科室不能为空");
                txtDocDepartment.Focus();
                return false;
            }
            if (dgvDurgList.Rows.Count == 0)
            {
                ShowWarningDialog("异常提示", "处方药品不能为空");
                cbDurg.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbDurg.SelectedValue == null || (int)cbDurg.SelectedValue == 0)
            {
                ShowWarningDialog("异常提示", "请先选择药品");
                cbDurg.Focus();
                return;
            }
            if (dudJL.Value == 0)
            {
                ShowWarningDialog("异常提示", "请输入药品剂量");
                dudJL.Focus();
                return;
            }
            if (parIdList != null && parIdList.Contains((int)cbDurg.SelectedValue))
            {
                ShowWarningDialog("异常提示", "该药品已在列表存在，请勿重复添加");
                return;
            }
            var durgInfo = _prescriptionBLL.GetParticlesInfo((int)cbDurg.SelectedValue);
            if (durgInfo == null)
            {
                ShowWarningDialog("异常提示", "未找到该药品信息");
                return;
            }
            if (durgInfo.Equivalent == 0)
            {
                ShowWarningDialog("异常提示", "该药品当量为0，无法添加");
                return;
            }

            if (cbJLFS.SelectedIndex == 0)
            {
                durgInfo.DoseHerb = (float)dudJL.Value;
                durgInfo.Dose = (float)Math.Round(dudJL.Value / durgInfo.Equivalent, 2);
            }
            else
            {
                durgInfo.Dose = (float)dudJL.Value;
                durgInfo.DoseHerb = (float)Math.Round(dudJL.Value * durgInfo.Equivalent);
            }

            if (!AddDurgCheck(durgInfo))
            {
                ShowWarningDialog("异常提示", "该药品未通过检查，无法添加");
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvDurgList);
            // 设置新添加的行的单元格值
            row.Cells[0].Value = durgInfo.ID;
            row.Cells[1].Value = durgInfo.Code;
            row.Cells[2].Value = durgInfo.ParName;
            row.Cells[3].Value = durgInfo.HisCode;
            row.Cells[4].Value = durgInfo.DoseHerb;
            row.Cells[5].Value = durgInfo.Equivalent;
            row.Cells[6].Value = durgInfo.Dose;
            row.Cells[7].Value = durgInfo.Stock;
            row.Cells[8].Value = durgInfo.RetailPrice;
            row.Cells[9].Value = Math.Round(durgInfo.RetailPrice * (decimal)durgInfo.DoseHerb, 3);

            dgvDurgList.Rows.Insert(0, row);

            parIdList.Add(durgInfo.ID);

            this.dgvDurgList.TopLeftHeaderCell.Value = "共" + parIdList.Count.ToString() + "条";
            dgvDurgList.ClearSelection();

            cbDurg.SelectedIndex = -1;
            cbJLFS.SelectedIndex = 0;
            dudJL.Value = 0;
            //加合计行
            dgvFooter.Clear();
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dgvFooter["ParName"] = "合计：";
            dgvFooter["DoseHerb"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "DoseHerb").ToString();
            dgvFooter["Dose"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "Dose").ToString();
            dgvFooter["Price"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "Price").ToString();
            dgvFooter["TotalPrice"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "TotalPrice").ToString();
        }

        private double ComputeColumnSum(DataGridView dataGrid, string colNname)
        {
            double sum = 0;        //计算合计  
            for (int i = 0; i < dataGrid.Rows.Count; i++) //获取dataGridView1表格的数据集
            {
                if (dataGrid.Rows[i].Cells[colNname].Value != null)
                {
                    sum += Convert.ToDouble(dataGrid.Rows[i].Cells[colNname].Value.ToString());
                }
            }
            return sum;
        }

        /// <summary>
        /// 保存药品检查
        /// </summary>
        /// <param name="particlesInfoModel"></param>
        /// <returns></returns>
        private bool AddDurgCheck(ParticlesInfoModel particlesInfoModel, bool isCheckRuler = true)
        {
            //库存校验，相容校验，上限，his碼
            if (isCheckRuler && parIdList != null && parIdList.Count > 0)
            {
                var rulercheckList = _prescriptionBLL.CheckRuler(particlesInfoModel.ID, parIdList, durgDLData);
                if (rulercheckList != null && rulercheckList.Count > 0)
                {
                    string allStr = string.Join("\r\n", rulercheckList);
                    if (!ShowAskDialog("是否忽略?", allStr, UIStyle.Blue, false, UIMessageDialogButtons.Ok))
                    {
                        return false;
                    }
                    else
                    {
                        lbCheckResult.Items.Insert(0, particlesInfoModel.ParName + "相容性检查失败,被忽略!");
                    }
                }
            }

            if (particlesInfoModel.Stock == null || particlesInfoModel.Stock == 0)
            {
                lbCheckResult.Items.Insert(0, particlesInfoModel.ParName + "没有库存!");
            }
            if (particlesInfoModel.Stock != null && particlesInfoModel.Stock > 0 && particlesInfoModel.Stock < particlesInfoModel.Dose)
            {
                lbCheckResult.Items.Insert(0, particlesInfoModel.ParName + "余量不足!");
            }
            if (particlesInfoModel.Dose > particlesInfoModel.DoseLimit)
            {
                lbCheckResult.Items.Insert(0, particlesInfoModel.ParName + "剂量超出上限!");
            }
            if (string.IsNullOrEmpty(particlesInfoModel.HisCode))
            {
                lbCheckResult.Items.Insert(0, particlesInfoModel.ParName + "无对应HIS码!");
            }
            return true;
        }

        private void dgvDurgList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dgvDurgList.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgvDurgList.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dgvDurgList.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnSavePre_Click(object sender, EventArgs e)
        {
            if (!SubmitPreCheck()) { return; }

            DataPrescription dataPrescription = new DataPrescription();
            List<DataPrescriptionDetail> dataPrescriptionDetails = new List<DataPrescriptionDetail>();
            dataPrescription.PrescriptionID = txtPrID.Text;
            dataPrescription.PatientName = txtPatName.Text;
            dataPrescription.PatientTel = txtPatPhone.Text;
            dataPrescription.PatientSex = (SexEnum)cbSex.SelectedIndex;
            dataPrescription.PatientAge = iudAgeYear.Value;
            dataPrescription.PatientBirthMonth = iupAgeMonth.Value;
            dataPrescription.Quantity = iudFS.Value;
            dataPrescription.TaskFrequency = iudFFCS.Value;
            dataPrescription.DoctorName = cbDoctorName.Text;
            dataPrescription.DepartmentName = txtDocDepartment.Text;
            dataPrescription.PrescriptionSource =1;
            dataPrescription.Remarks = txtRemark.Text;
            dataPrescription.UsageMethod = string.IsNullOrEmpty(txtRemark.Text) ? "无" : txtRemark.Text;
            if (agreementPrescriptionId.HasValue)
            {
                dataPrescription.PrescriptionName = _prescriptionBLL.GetAgreementPrescriptionName(agreementPrescriptionId.Value);
            }
            int ordernum = 1;
            foreach (DataGridViewRow row in dgvDurgList.Rows)
            {
                DataPrescriptionDetail dmodel = new DataPrescriptionDetail();
                dmodel.PrescriptionID = txtPrID.Text;
                dmodel.ParticleOrder = ordernum;
                dmodel.ParticlesNameHIS = "无";
                dmodel.ParticlesCodeHIS = row.Cells["ParticlesCodeHIS"].Value.ToString();
                dmodel.ParticlesID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                dmodel.DoseHerb = float.Parse(row.Cells["DoseHerb"].Value.ToString());
                dmodel.Equivalent = float.Parse(row.Cells["Equivalent"].Value.ToString());
                dmodel.Dose = float.Parse(row.Cells["Dose"].Value.ToString());
                dmodel.BatchNumber = null; //row.Cells["BatchNumber"].Value.ToString();
                dmodel.Price = Convert.ToDecimal(row.Cells["Price"].Value.ToString());
                dataPrescriptionDetails.Add(dmodel);
                ordernum++;
            }
            var message = _prescriptionBLL.AddPrescription(dataPrescription, dataPrescriptionDetails);
            if (message == "")
            {
                saveMessage = "Successed";
                this.Close();
            }
            else
            {
                saveMessage = message;
            }
        }

        private void removeDurg_Click(object sender, EventArgs e)
        {
            if (dgvDurgList.SelectedRows.Count == 0)
            {
                ShowWarningDialog("异常提示", "请选中要移除的药品信息");
                return;
            }

            parIdList.Remove((int)dgvDurgList.SelectedRows[0].Cells[0].Value);
            dgvDurgList.Rows.RemoveAt(dgvDurgList.SelectedRows[0].Index);

            this.dgvDurgList.TopLeftHeaderCell.Value = "共" + parIdList.Count.ToString() + "条";
            dgvDurgList.ClearSelection();

            //加合计行
            dgvFooter.Clear();
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            dgvFooter["ParName"] = "合计：";
            dgvFooter["DoseHerb"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "DoseHerb").ToString();
            dgvFooter["Dose"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "Dose").ToString();
            dgvFooter["Price"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "Price").ToString();
            dgvFooter["TotalPrice"] = dataGradeViewUi.ComputeColumnSum(dgvDurgList, "TotalPrice").ToString();
        }

        private void dgvDurgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDurgList.SelectedRows)
            {
                if (row.Index != e.RowIndex)
                {
                    dgvDurgList.Rows[row.Index].Selected = false;
                }
            }
        }

        private void btnSaveXDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXDFMC.Text))
            {
                ShowWarningDialog("异常提示", "协定方名称不能为空");
                txtXDFMC.Focus();
                return;
            }
            if (dgvDurgList.Rows.Count == 0)
            {
                ShowWarningDialog("异常提示", "处方药品不能为空");
                cbDurg.Focus();
                return;
            }
            AgreementPrescriptionInfo agreementPrescriptionInfo = new AgreementPrescriptionInfo();
            agreementPrescriptionInfo.Name = txtXDFMC.Text;
            agreementPrescriptionInfo.Description = txtRemark.Text;

            List<AgreementPrescriptionDetail> agreementPrescriptionDetails = new List<AgreementPrescriptionDetail>();
            foreach (DataGridViewRow row in dgvDurgList.Rows)
            {
                AgreementPrescriptionDetail dmodel = new AgreementPrescriptionDetail();
                if (agreementPrescriptionId.HasValue)
                {
                    dmodel.AgreementPrescriptionId = (int)agreementPrescriptionId;
                }
                dmodel.ParticlesID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                dmodel.DoseHerb = float.Parse(row.Cells["DoseHerb"].Value.ToString());
                dmodel.Equivalent = float.Parse(row.Cells["Equivalent"].Value.ToString());
                dmodel.Dose = float.Parse(row.Cells["Dose"].Value.ToString());
                dmodel.Price = Convert.ToDecimal(row.Cells["Price"].Value.ToString());
                agreementPrescriptionDetails.Add(dmodel);
            }
            var message = _prescriptionBLL.AddOrEditAgreementPrescriptionInfo(agreementPrescriptionId, agreementPrescriptionInfo, agreementPrescriptionDetails);
            if (message == "")
            {
                ShowSuccessTip("存为协定方成功");
                txtXDFMC.Text=string.Empty;
            }
            else
            {
                ShowSuccessTip("存为协定方失败，原因:"+message);
            }
        }
    }
}
