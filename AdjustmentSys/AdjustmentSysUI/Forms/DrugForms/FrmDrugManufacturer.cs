using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.Drug;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
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

namespace AdjustmentSysUI.Forms.Drug
{
    public partial class FrmDrugManufacturer : UIPage
    {
        DrugManufacturerBLL _drugManufacturerBLL = new DrugManufacturerBLL();
        private int _Id;//厂家id
        private ManufacturerInfo _manufacturerInfo = new ManufacturerInfo();
        public FrmDrugManufacturer()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// 设置列表
        /// </summary>
        private void InitDgvFormat()
        {
            //分页列表
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.RowHeadersVisible = false;
            //初始化当前页
            uiPage.ActivePage = 1;
            //设置分页控件每页数量
            uiPage.PageSize = 15;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();

            //创建列
            dataGradeViewUi.InitDgvCheckBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "IsDelete", "是否启用", false, true, 13);
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "id", true, false, 2, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Sort", "序号", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "厂家名称", true, true, 30, "");
            //dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateName", "创建人", true, true, 18, "");
            //dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "CreateTime", "创建时间", true, true, 35, "yyyy-MM-dd HH:mm:ss");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateName", "更新人", true, true, 18, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "UpdateTime", "更新时间", true, true, 27, "yyyy-MM-dd HH:mm:ss");

        }

        /// <summary>
        /// 查询颗粒信息
        /// </summary>
        public void QueryPageList()
        {
            int allCount = 0;//总条数
            //dgvList.Rows.Clear();
            var datas = _drugManufacturerBLL.GetManufacturerByPage(uiPage.ActivePage, uiPage.PageSize, out allCount);
            //设置分页控件总数
            uiPage.TotalCount = allCount;

            dgvList.DataSource = datas;
            //if (datas != null)
            //{
            //    if (dgvList.ColumnCount==0) 
            //    {
            //        InitDgvFormat();
            //    }
            //    for (int i = 0; i < datas.Count; i++)
            //    {
            //        dgvList.Rows.Add();
            //        dgvList.Rows[i].Cells[0].Value = datas[i].IsDelete;
            //        dgvList.Rows[i].Cells[1].Value = datas[i].ID;
            //        dgvList.Rows[i].Cells[2].Value = datas[i].Sort;
            //        dgvList.Rows[i].Cells[3].Value = datas[i].Name;
            //        dgvList.Rows[i].Cells[4].Value = datas[i].UpdateName;
            //        dgvList.Rows[i].Cells[5].Value = datas[i].UpdateTime;
            //    }
            //}
            //foreach (ManufacturerPageListModel model in datas)
            //{
            //    DataGridViewRow Result = new DataGridViewRow();
            //    Result.CreateCells(dgvList);
            //    Result.Height = 30;
            //    Result.Cells[0].Value = model.IsDelete;
            //    Result.Cells[1].Value = model.ID;
            //    Result.Cells[2].Value = model.Sort;
            //    Result.Cells[3].Value = model.Name;
            //    Result.Cells[4].Value = model.UpdateName;
            //    Result.Cells[5].Value = model.UpdateTime;
            //    dgvList.Rows.Add(Result);
            //}
            //清除默认选中的行
            dgvList.ClearSelection();
            _Id = 0;
            _manufacturerInfo = new ManufacturerInfo() { ID = 0, Name = "", Sort = 0 };
        }



        private void uiPage_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            QueryPageList();
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            QueryPageList();
        }

        /// <summary>
        /// 根据code设置规则参数
        /// </summary>
        /// <param name="code">code</param>
        private void LoadRuleData(ManufacturerResolutionCode code)
        {
            txtJXM.Text = code.ExampleCode;
            //起始位置
            iudS1.Value = code.LargePackagingCodeIndex;
            iudS2.Value = code.PackagingTypeIndex ?? 0;
            iudS3.Value = code.BatchNumberIndex ?? 0;
            iudS4.Value = code.ValidityPeriodIndex ?? 0;
            iudS5.Value = code.EquivalentIndex ?? 0;
            iudS6.Value = code.DensityIndex;
            iudS7.Value = code.LoadingCapacityIndex;
            //长度
            iudSL1.Value = code.LargePackagingCodeLength;
            iudSL2.Value = code.PackagingTypeLength ?? 0;
            iudSL3.Value = code.BatchNumberLength ?? 0;
            iudSL4.Value = code.ValidityPeriodLength ?? 0;
            iudSL5.Value = code.EquivalentLength ?? 0;
            iudSL6.Value = code.DensityLength;
            iudSL7.Value = code.LoadingCapacityLength;
        }

        /// <summary>
        /// 初始化编号规则数据
        /// </summary>
        private void EmptyRuleCode()
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            lbl1.Text = "失败";
            lbl2.Text = "失败";
            lbl3.Text = "失败";
            lbl4.Text = "失败";
            lbl5.Text = "失败";
            lbl6.Text = "失败";
            lbl7.Text = "失败";

            lbl1.ForeColor = Color.Blue;
            lbl2.ForeColor = Color.Blue;
            lbl3.ForeColor = Color.Blue;
            lbl4.ForeColor = Color.Blue;
            lbl5.ForeColor = Color.Blue;
            lbl6.ForeColor = Color.Blue;
            lbl7.ForeColor = Color.Blue;

            txtJXM.Text = string.Empty;
            //起始位置
            iudS1.Value = 0;
            iudS2.Value = 0;
            iudS3.Value = 0;
            iudS4.Value = 0;
            iudS5.Value = 0;
            iudS6.Value = 0;
            iudS7.Value = 0;
            //长度
            iudSL1.Value = 0;
            iudSL2.Value = 0;
            iudSL3.Value = 0;
            iudSL4.Value = 0;
            iudSL5.Value = 0;
            iudSL6.Value = 0;
            iudSL7.Value = 0;
            //解析结果
            txtDBZM.Text = string.Empty;
            txtBZLX.Text = string.Empty;
            txtPH.Text = string.Empty;
            txtYXQ.Text = string.Empty;
            txtDL.Text = string.Empty;
            txtMD.Text = string.Empty;
            txtZL.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmManufacturerEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmManufacturerEdit frmEdit = new FrmManufacturerEdit(null);
            frmEdit.Text = "新增厂家";
            frmEdit.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_Id == 0)
            {
                ShowWarningDialog("异常提示", "请先选择要编辑的厂家");
                return;
            }

            Form existingForm = Application.OpenForms.Cast<Form>().Where(x => x is FrmManufacturerEdit).FirstOrDefault();
            if (existingForm != null)
            {
                // 窗体已打开，关闭旧窗体
                existingForm.Close();
            }
            FrmManufacturerEdit frmEdit = new FrmManufacturerEdit(_manufacturerInfo);
            frmEdit.Text = "编辑厂家";
            frmEdit.Show();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            EmptyRuleCode();
            cbJXXL.SelectedIndex = -1;
            //cbJXXL.Text = "";
        }

        private void cbJXXL_SelectedValueChanged(object sender, EventArgs e)
        {
            //获取code数据
            var code = _drugManufacturerBLL.GetCodesById(Convert.ToInt32(cbJXXL.SelectedValue));
            if (code == null)
            {
                EmptyRuleCode();
                return;
            }
            //加载规则数据
            LoadRuleData(code);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = GetSetRuleModel();
            if (model == null)
            {
                return;
            }
            string message = _drugManufacturerBLL.AddOrEditManufacturerResolutionCode(model);
            if (message == "")
            {
                ShowSuccessTip((model.ID > 0 ? "编辑" : "新增") + "解析规则成功");

            }
            else
            {
                ShowErrorDialog("错误提示", message);
            }
        }

        /// <summary>
        /// 获取设置的规则信息
        /// </summary>
        /// <returns></returns>
        private ManufacturerResolutionCode GetSetRuleModel()
        {
            //校验
            if (!RulerCheck()) { return null; }

            ManufacturerResolutionCode code = new ManufacturerResolutionCode();
            code.ID = Convert.ToInt32(cbJXXL.SelectedIndex == -1 ? 0 : cbJXXL.SelectedValue);
            code.ManufacturerId = _Id;
            code.ExampleCode = txtJXM.Text;
            //起始位置
            code.LargePackagingCodeIndex = iudS1.Value;
            code.PackagingTypeIndex = iudS2.Value;
            code.BatchNumberIndex = iudS3.Value;
            code.ValidityPeriodIndex = iudS4.Value;
            code.EquivalentIndex = iudS5.Value;
            code.DensityIndex = iudS6.Value;
            code.LoadingCapacityIndex = iudS7.Value;
            //长度
            code.LargePackagingCodeLength = iudSL1.Value;
            code.PackagingTypeLength = iudSL2.Value;
            code.BatchNumberLength = iudSL3.Value;
            code.ValidityPeriodLength = iudSL4.Value;
            code.EquivalentLength = iudSL5.Value;
            code.DensityLength = iudSL6.Value;
            code.LoadingCapacityLength = iudSL7.Value;
            return code;
        }
        /// <summary>
        /// 保存解析码规则校验
        /// </summary>
        private bool RulerCheck()
        {
            if (string.IsNullOrEmpty(txtJXM.Text))
            {
                ShowWarningDialog("异常提示", "规则里解析码不能为空");
                txtJXM.Focus();
                return false;
            }

            if (iudS1.Value == 0)
            {
                ShowWarningDialog("异常提示", "规则里大包装码起始位数字不能为0");
                iudS1.Focus();
                return false;
            }
            if (iudSL1.Value == 0)
            {
                ShowWarningDialog("异常提示", "规则里大包装码长度数字不能为0");
                iudSL1.Focus();
                return false;
            }

            if (iudS6.Value == 0)
            {
                ShowWarningDialog("异常提示", "规则里密度起始位数字不能为0");
                iudS6.Focus();
                return false;
            }
            if (iudSL6.Value == 0)
            {
                ShowWarningDialog("异常提示", "规则里密度长度数字不能为0");
                iudSL6.Focus();
                return false;
            }

            if (iudS7.Value == 0)
            {
                ShowWarningDialog("异常提示", "规则里装量起始位数字不能为0");
                iudS7.Focus();
                return false;
            }
            if (iudSL7.Value == 0)
            {
                ShowWarningDialog("异常提示", "规则里装量长度数字不能为0");
                iudSL7.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartJX_Click(object sender, EventArgs e)
        {
            var model = GetSetRuleModel();
            if (model == null)
            {
                btnSave.Enabled = false;
                return;
            }

            txtDBZM.Text = _drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Packaging, model.ExampleCode, model.LargePackagingCodeIndex, model.LargePackagingCodeLength);
            txtBZLX.Text = _drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.PackagingType, model.ExampleCode, (int)model.PackagingTypeIndex, (int)model.PackagingTypeLength);
            txtYXQ.Text = _drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.VaildUntil, model.ExampleCode, (int)model.ValidityPeriodIndex, (int)model.ValidityPeriodLength);
            txtMD.Text = _drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Density, model.ExampleCode, model.DensityIndex, model.DensityLength);
            txtDL.Text = _drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Equivalent, model.ExampleCode, (int)model.EquivalentIndex, (int)model.EquivalentLength);
            txtZL.Text = _drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.LoadingCapacity, model.ExampleCode, model.LoadingCapacityIndex, model.LoadingCapacityLength);
            if (RuleResultCheck())
            {
                TextCheck();
                //解析完成
                ShowSuccessTip("解析完成");
                btnSave.Enabled = true;
            }

        }
        private void TextCheck()
        {
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = true;
            lbl7.Visible = true;
            if (txtDBZM.Text.Length < 10)
            {

                lbl1.Text = "成功";
                lbl1.ForeColor = Color.Blue;

            }
            else
            {
                lbl1.Text = "失败";
                lbl1.ForeColor = Color.Red;

            }
            if (txtBZLX.Text.Length == 1)
            {

                lbl2.Text = "成功";
                lbl2.ForeColor = Color.Blue;

            }
            else
            {
                lbl2.Text = "失败";
                lbl2.ForeColor = Color.Red;

            }
            if (txtPH.Text.Length < 10)
            {

                lbl3.Text = "成功";
                lbl3.ForeColor = Color.Blue;

            }
            else
            {
                lbl3.Text = "失败";
                lbl3.ForeColor = Color.Red;

            }
            if (txtYXQ.Text.Length == 6)
            {
                lbl4.Text = "成功";
                lbl4.ForeColor = Color.Blue;

            }
            else
            {
                lbl4.Text = "失败";
                lbl4.ForeColor = Color.Red;

            }

            if (Convert.ToDouble(txtDL.Text) < 100)
            {
                lbl5.Text = "成功";
                lbl5.ForeColor = Color.Blue;

            }
            else
            {
                lbl5.Text = "失败";
                lbl5.ForeColor = Color.Red;

            }
            if (Convert.ToDouble(txtMD.Text) < 1)
            {
                lbl6.Text = "成功";
                lbl6.ForeColor = Color.Blue;

            }
            else
            {
                lbl6.Text = "失败";
                lbl6.ForeColor = Color.Red;

            }
            if (int.Parse(txtZL.Text) < 600)
            {
                lbl7.Text = "成功";
                lbl7.ForeColor = Color.Blue;

            }
            else
            {
                lbl7.Text = "失败";
                lbl7.ForeColor = Color.Red;
            }
        }
        private bool RuleResultCheck()
        {
            string errorMsg = "";
            if (txtDBZM.Text == "-1")
            {
                errorMsg += ("<大包装>起始位不能超出条码长度。");
            }

            if (txtYXQ.Text == "-1")
            {
                errorMsg += ("<有效期>起始位不能超出条码长度。");
            }
            if (txtDL.Text == "-1")
            {
                errorMsg += ("<当量>起始位不能超出条码长度。");
            }

            if (txtMD.Text == "-1")
            {
                errorMsg += ("<密度>起始位不能超出条码长度。");
            }

            if (txtZL.Text == "-1")
            {
                errorMsg += ("<装量>起始位不能超出条码长度。");
            }
            if (txtDBZM.Text == "-2")
            {
                errorMsg += ("<大包装>解析有误。");
            }

            if (txtYXQ.Text == "-2")
            {
                errorMsg += ("<有效期>解析有误。");
            }
            if (txtDL.Text == "-2")
            {
                errorMsg += ("<当量>解析有误。");
            }

            if (txtMD.Text == "-2")
            {
                errorMsg += ("<密度>解析有误。");
            }

            if (txtZL.Text == "-2")
            {
                errorMsg += ("<装量>解析有误。");
            }
            if (errorMsg != "")
            {
                ShowErrorDialog(errorMsg);
            }
            return true;
        }

        private void iudS1_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL1_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudS2_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL2_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudS3_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL3_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudS4_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL4_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudS5_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL5_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudS6_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL6_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudS7_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void iudSL7_ValueChanged(object sender, int value)
        {
            btnSave.Enabled = false;
        }

        private void txtJXM_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            _Id = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);
            //加载厂家信息
            _manufacturerInfo = new ManufacturerInfo();
            _manufacturerInfo.ID = _Id;
            _manufacturerInfo.Name = this.dgvList.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            _manufacturerInfo.Sort = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["Sort"].Value);
            //设置显示值
            txtCJMC.Text = _manufacturerInfo.Name;
            iuCJXH.Value = _manufacturerInfo.Sort;

            //根据厂商获取规则
            List<ComboxModel> cbData = _drugManufacturerBLL.GetCodesByManufacturerId(_Id);


            if (cbData == null || cbData.Count == 0)
            {
                cbJXXL.SelectedIndex = -1;
                cbJXXL.DataSource = cbData;
                EmptyRuleCode();
                return;
            }

            cbJXXL.ValueMember = "Id";
            cbJXXL.DisplayMember = "Name";
            cbJXXL.DataSource = cbData;

            //默认加载最早创建的一个
            var firstData = cbData.OrderBy(x => x.Id).FirstOrDefault();
            cbJXXL.SelectedValue = firstData.Id;

            //获取code数据
            var code = _drugManufacturerBLL.GetCodesById(firstData.Id);
            if (code == null)
            {
                EmptyRuleCode();
                return;
            }
            //加载规则数据
            LoadRuleData(code);
        }

        private void FrmDrugManufacturer_Load(object sender, EventArgs e)
        {
            InitDgvFormat();
            //清除默认选中的行
            dgvList.ClearSelection();
            _Id = 0;
            _manufacturerInfo = new ManufacturerInfo() { ID = 0, Name = "", Sort = 0 };
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保改变的是Checkbox列
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {

                //获取DataGridView中CheckBox的Cell
                DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(this.dgvList.Rows[this.dgvList.CurrentCell.RowIndex].Cells[0]);

                //获取被选中列的相关信息

                int id = Int32.Parse(dgvList.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                bool isChecked = Convert.ToBoolean(dgvCheck.EditedFormattedValue);
                string msg = _drugManufacturerBLL.DeleteManufacturerInfo(id, isChecked);
                if (msg == "")
                {
                    ShowSuccessTip((isChecked ? "启用" : "禁用") + "厂家成功");
                    //dgvList.Rows[e.RowIndex].Cells[0].Value = !isChecked;
                    QueryPageList();
                }
                else
                {
                    ShowErrorDialog("错误提示", msg);
                }

            }
        }
    }
}
