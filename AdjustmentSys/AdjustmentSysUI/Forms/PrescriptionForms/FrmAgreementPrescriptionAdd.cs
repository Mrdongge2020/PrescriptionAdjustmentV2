using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Prescription;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Prescription;
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
    public partial class FrmAgreementPrescriptionAdd : UIForm
    {
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        PrescriptionBLL _prescriptionBLL = new PrescriptionBLL();
        List<int> parIdList = new List<int>();//已添加的药品id
        List<ComboxModel> durgDLData = new List<ComboxModel>();//药柜药品数据
        public string saveMessage = "";
        public int? agreementPrescriptionId;
        public FrmAgreementPrescriptionAdd(int? agreementPrescriptionId)
        {
            InitializeComponent();
            this.agreementPrescriptionId = agreementPrescriptionId;
        }
        private void FrmAgreementPrescriptionAdd_Load(object sender, EventArgs e)
        {
            InitData();
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

            //药品数据
            cbDurg.SelectedIndex = -1;
            cbJLFS.SelectedIndex = 0;
            dudJL.Value = 0;
            dgvDurgList.Rows.Clear();
            parIdList = new List<int>();
            //分析数据
            lbCheckResult.Items.Clear();
            if (agreementPrescriptionId.HasValue)
            {
                BindDurg();
            }

        }
        private void BindDurg()
        {
            txtName.Text = _prescriptionBLL.GetAgreementPrescriptionName(agreementPrescriptionId.Value);
            var details = _prescriptionBLL.GetAgreementPrescriptionDetailsV1(agreementPrescriptionId.Value);
            List<ParticlesInfoModel> particleList = new List<ParticlesInfoModel>();
            dgvDurgList.Rows.Clear();
            if (details == null) { return; }

            foreach (var parinfo in details)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvDurgList);
                row.Cells[0].Value = parinfo.ParticlesID;
                row.Cells[1].Value = parinfo.ParName;
                row.Cells[2].Value = parinfo.ParticlesCodeHIS;
                row.Cells[3].Value = parinfo.ParCode;
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

            lbCheckResult.Items.Clear();
            foreach (var parinfo in particleList)
            {
                //校验
                AddDurgCheck(parinfo, false);
            }
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
            row.Cells[1].Value = durgInfo.ParName;
            row.Cells[2].Value = durgInfo.HisCode;
            row.Cells[3].Value = durgInfo.Code;
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

        private void btnSaveAggPre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                ShowWarningDialog("异常提示", "协定方名称不能为空");
                txtName.Focus();
                return;
            }
            if (dgvDurgList.Rows.Count == 0)
            {
                ShowWarningDialog("异常提示", "处方药品不能为空");
                cbDurg.Focus();
                return;
            }
            AgreementPrescriptionInfo agreementPrescriptionInfo = new AgreementPrescriptionInfo();
            agreementPrescriptionInfo.Name = txtName.Text;
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
                saveMessage = "Successed";
                this.Close();
            }
            else
            {
                saveMessage = message;
            }
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

       
    }
}
