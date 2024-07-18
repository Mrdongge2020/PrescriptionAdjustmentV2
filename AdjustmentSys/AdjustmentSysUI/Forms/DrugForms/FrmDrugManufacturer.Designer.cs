namespace AdjustmentSysUI.Forms.Drug
{
    partial class FrmDrugManufacturer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dgvList = new Sunny.UI.UIDataGridView();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnEdit = new Sunny.UI.UISymbolButton();
            btnRefc = new Sunny.UI.UISymbolButton();
            uiPage = new Sunny.UI.UIPagination();
            uiLabel1 = new Sunny.UI.UILabel();
            iuCJXH = new Sunny.UI.UIIntegerUpDown();
            uiLabel2 = new Sunny.UI.UILabel();
            cbJXXL = new Sunny.UI.UIComboBox();
            uiLabel3 = new Sunny.UI.UILabel();
            btnStartJX = new Sunny.UI.UIButton();
            btnSave = new Sunny.UI.UIButton();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            lbl7 = new Sunny.UI.UILabel();
            btnreset = new Sunny.UI.UIButton();
            lbl6 = new Sunny.UI.UILabel();
            lbl5 = new Sunny.UI.UILabel();
            lbl4 = new Sunny.UI.UILabel();
            lbl3 = new Sunny.UI.UILabel();
            lbl2 = new Sunny.UI.UILabel();
            lbl1 = new Sunny.UI.UILabel();
            txtJXM = new Sunny.UI.UITextBox();
            txtZL = new Sunny.UI.UITextBox();
            iudSL7 = new Sunny.UI.UIIntegerUpDown();
            iudS7 = new Sunny.UI.UIIntegerUpDown();
            uiLabel13 = new Sunny.UI.UILabel();
            txtMD = new Sunny.UI.UITextBox();
            iudSL6 = new Sunny.UI.UIIntegerUpDown();
            iudS6 = new Sunny.UI.UIIntegerUpDown();
            uiLabel12 = new Sunny.UI.UILabel();
            txtDL = new Sunny.UI.UITextBox();
            iudSL5 = new Sunny.UI.UIIntegerUpDown();
            iudS5 = new Sunny.UI.UIIntegerUpDown();
            uiLabel11 = new Sunny.UI.UILabel();
            txtYXQ = new Sunny.UI.UITextBox();
            iudSL4 = new Sunny.UI.UIIntegerUpDown();
            iudS4 = new Sunny.UI.UIIntegerUpDown();
            uiLabel10 = new Sunny.UI.UILabel();
            txtPH = new Sunny.UI.UITextBox();
            iudSL3 = new Sunny.UI.UIIntegerUpDown();
            iudS3 = new Sunny.UI.UIIntegerUpDown();
            uiLabel9 = new Sunny.UI.UILabel();
            txtBZLX = new Sunny.UI.UITextBox();
            iudSL2 = new Sunny.UI.UIIntegerUpDown();
            iudS2 = new Sunny.UI.UIIntegerUpDown();
            uiLabel8 = new Sunny.UI.UILabel();
            txtDBZM = new Sunny.UI.UITextBox();
            iudSL1 = new Sunny.UI.UIIntegerUpDown();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            iudS1 = new Sunny.UI.UIIntegerUpDown();
            uiLabel4 = new Sunny.UI.UILabel();
            txtCJMC = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(11, 90);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(667, 661);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 0;
            dgvList.CellClick += dgvList_CellClick;
            dgvList.CellContentClick += dgvList_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Location = new Point(11, 50);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 1;
            btnAdd.Size = new Size(70, 30);
            btnAdd.Symbol = 362211;
            btnAdd.TabIndex = 24;
            btnAdd.Text = "新增";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Location = new Point(103, 50);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Radius = 1;
            btnEdit.Size = new Size(70, 30);
            btnEdit.Symbol = 361741;
            btnEdit.SymbolColor = SystemColors.Window;
            btnEdit.TabIndex = 23;
            btnEdit.Text = "修改";
            btnEdit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(202, 50);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 1;
            btnRefc.Size = new Size(70, 30);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 26;
            btnRefc.Text = "刷新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // uiPage
            // 
            uiPage.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(11, 759);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(617, 35);
            uiPage.TabIndex = 27;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.Black;
            uiLabel1.Location = new Point(1168, 78);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(62, 23);
            uiLabel1.TabIndex = 28;
            uiLabel1.Text = "序号:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iuCJXH
            // 
            iuCJXH.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iuCJXH.Location = new Point(1237, 78);
            iuCJXH.Margin = new Padding(4, 5, 4, 5);
            iuCJXH.MinimumSize = new Size(100, 0);
            iuCJXH.Name = "iuCJXH";
            iuCJXH.ReadOnly = true;
            iuCJXH.ShowText = false;
            iuCJXH.Size = new Size(116, 29);
            iuCJXH.TabIndex = 29;
            iuCJXH.Text = "uiIntegerUpDown1";
            iuCJXH.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.Black;
            uiLabel2.Location = new Point(706, 78);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(98, 23);
            uiLabel2.TabIndex = 30;
            uiLabel2.Text = "厂家名称:";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbJXXL
            // 
            cbJXXL.DataSource = null;
            cbJXXL.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbJXXL.FillColor = Color.White;
            cbJXXL.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbJXXL.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbJXXL.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbJXXL.Location = new Point(706, 139);
            cbJXXL.Margin = new Padding(4, 5, 4, 5);
            cbJXXL.MinimumSize = new Size(63, 0);
            cbJXXL.Name = "cbJXXL";
            cbJXXL.Padding = new Padding(0, 0, 30, 2);
            cbJXXL.Size = new Size(399, 29);
            cbJXXL.SymbolSize = 24;
            cbJXXL.TabIndex = 32;
            cbJXXL.TextAlignment = ContentAlignment.MiddleLeft;
            cbJXXL.Watermark = "选择解析码";
            cbJXXL.SelectedValueChanged += cbJXXL_SelectedValueChanged;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.Red;
            uiLabel3.Location = new Point(40, 548);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(83, 23);
            uiLabel3.TabIndex = 33;
            uiLabel3.Text = "解析码:";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnStartJX
            // 
            btnStartJX.Cursor = Cursors.SizeWE;
            btnStartJX.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnStartJX.Location = new Point(470, 536);
            btnStartJX.MinimumSize = new Size(1, 1);
            btnStartJX.Name = "btnStartJX";
            btnStartJX.Size = new Size(75, 35);
            btnStartJX.TabIndex = 35;
            btnStartJX.Text = "开始解析";
            btnStartJX.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnStartJX.Click += btnStartJX_Click;
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.SizeWE;
            btnSave.Enabled = false;
            btnSave.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.Location = new Point(680, 536);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(81, 35);
            btnSave.TabIndex = 36;
            btnSave.Text = "保存规则";
            btnSave.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.Click += btnSave_Click;
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(lbl7);
            uiGroupBox1.Controls.Add(btnreset);
            uiGroupBox1.Controls.Add(lbl6);
            uiGroupBox1.Controls.Add(btnSave);
            uiGroupBox1.Controls.Add(lbl5);
            uiGroupBox1.Controls.Add(lbl4);
            uiGroupBox1.Controls.Add(lbl3);
            uiGroupBox1.Controls.Add(lbl2);
            uiGroupBox1.Controls.Add(lbl1);
            uiGroupBox1.Controls.Add(txtJXM);
            uiGroupBox1.Controls.Add(txtZL);
            uiGroupBox1.Controls.Add(iudSL7);
            uiGroupBox1.Controls.Add(iudS7);
            uiGroupBox1.Controls.Add(btnStartJX);
            uiGroupBox1.Controls.Add(uiLabel13);
            uiGroupBox1.Controls.Add(uiLabel3);
            uiGroupBox1.Controls.Add(txtMD);
            uiGroupBox1.Controls.Add(iudSL6);
            uiGroupBox1.Controls.Add(iudS6);
            uiGroupBox1.Controls.Add(uiLabel12);
            uiGroupBox1.Controls.Add(txtDL);
            uiGroupBox1.Controls.Add(iudSL5);
            uiGroupBox1.Controls.Add(iudS5);
            uiGroupBox1.Controls.Add(uiLabel11);
            uiGroupBox1.Controls.Add(txtYXQ);
            uiGroupBox1.Controls.Add(iudSL4);
            uiGroupBox1.Controls.Add(iudS4);
            uiGroupBox1.Controls.Add(uiLabel10);
            uiGroupBox1.Controls.Add(txtPH);
            uiGroupBox1.Controls.Add(iudSL3);
            uiGroupBox1.Controls.Add(iudS3);
            uiGroupBox1.Controls.Add(uiLabel9);
            uiGroupBox1.Controls.Add(txtBZLX);
            uiGroupBox1.Controls.Add(iudSL2);
            uiGroupBox1.Controls.Add(iudS2);
            uiGroupBox1.Controls.Add(uiLabel8);
            uiGroupBox1.Controls.Add(txtDBZM);
            uiGroupBox1.Controls.Add(iudSL1);
            uiGroupBox1.Controls.Add(uiLabel7);
            uiGroupBox1.Controls.Add(uiLabel6);
            uiGroupBox1.Controls.Add(uiLabel5);
            uiGroupBox1.Controls.Add(iudS1);
            uiGroupBox1.Controls.Add(uiLabel4);
            uiGroupBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new Point(706, 186);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(806, 608);
            uiGroupBox1.TabIndex = 37;
            uiGroupBox1.Text = "解码规则";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lbl7
            // 
            lbl7.Font = new Font("宋体", 10.5F);
            lbl7.ForeColor = Color.Blue;
            lbl7.Location = new Point(727, 447);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(55, 23);
            lbl7.TabIndex = 66;
            lbl7.Text = "失败";
            lbl7.TextAlign = ContentAlignment.MiddleLeft;
            lbl7.Visible = false;
            // 
            // btnreset
            // 
            btnreset.Cursor = Cursors.SizeWE;
            btnreset.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnreset.Location = new Point(576, 536);
            btnreset.MinimumSize = new Size(1, 1);
            btnreset.Name = "btnreset";
            btnreset.Size = new Size(81, 35);
            btnreset.TabIndex = 38;
            btnreset.Text = "重置规则";
            btnreset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnreset.Click += btnreset_Click;
            // 
            // lbl6
            // 
            lbl6.Font = new Font("宋体", 10.5F);
            lbl6.ForeColor = Color.Blue;
            lbl6.Location = new Point(727, 391);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(55, 23);
            lbl6.TabIndex = 65;
            lbl6.Text = "失败";
            lbl6.TextAlign = ContentAlignment.MiddleLeft;
            lbl6.Visible = false;
            // 
            // lbl5
            // 
            lbl5.Font = new Font("宋体", 10.5F);
            lbl5.ForeColor = Color.Blue;
            lbl5.Location = new Point(727, 324);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(55, 23);
            lbl5.TabIndex = 64;
            lbl5.Text = "失败";
            lbl5.TextAlign = ContentAlignment.MiddleLeft;
            lbl5.Visible = false;
            // 
            // lbl4
            // 
            lbl4.Font = new Font("宋体", 10.5F);
            lbl4.ForeColor = Color.Blue;
            lbl4.Location = new Point(727, 261);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(55, 23);
            lbl4.TabIndex = 63;
            lbl4.Text = "失败";
            lbl4.TextAlign = ContentAlignment.MiddleLeft;
            lbl4.Visible = false;
            // 
            // lbl3
            // 
            lbl3.Font = new Font("宋体", 10.5F);
            lbl3.ForeColor = Color.Blue;
            lbl3.Location = new Point(727, 194);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(55, 23);
            lbl3.TabIndex = 62;
            lbl3.Text = "失败";
            lbl3.TextAlign = ContentAlignment.MiddleLeft;
            lbl3.Visible = false;
            // 
            // lbl2
            // 
            lbl2.Font = new Font("宋体", 10.5F);
            lbl2.ForeColor = Color.Blue;
            lbl2.Location = new Point(727, 133);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(55, 23);
            lbl2.TabIndex = 61;
            lbl2.Text = "失败";
            lbl2.TextAlign = ContentAlignment.MiddleLeft;
            lbl2.Visible = false;
            // 
            // lbl1
            // 
            lbl1.Font = new Font("宋体", 10.5F);
            lbl1.ForeColor = Color.Blue;
            lbl1.Location = new Point(727, 72);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(55, 23);
            lbl1.TabIndex = 60;
            lbl1.Text = "失败";
            lbl1.TextAlign = ContentAlignment.MiddleLeft;
            lbl1.Visible = false;
            // 
            // txtJXM
            // 
            txtJXM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtJXM.Location = new Point(147, 542);
            txtJXM.Margin = new Padding(4, 5, 4, 5);
            txtJXM.MaxLength = 50;
            txtJXM.MinimumSize = new Size(1, 16);
            txtJXM.Name = "txtJXM";
            txtJXM.Padding = new Padding(5);
            txtJXM.ShowText = false;
            txtJXM.Size = new Size(287, 29);
            txtJXM.TabIndex = 38;
            txtJXM.TextAlignment = ContentAlignment.MiddleLeft;
            txtJXM.Watermark = "请输入解析码";
            txtJXM.TextChanged += txtJXM_TextChanged;
            // 
            // txtZL
            // 
            txtZL.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtZL.Location = new Point(470, 441);
            txtZL.Margin = new Padding(4, 5, 4, 5);
            txtZL.MinimumSize = new Size(1, 16);
            txtZL.Name = "txtZL";
            txtZL.Padding = new Padding(5);
            txtZL.ShowText = false;
            txtZL.Size = new Size(250, 29);
            txtZL.TabIndex = 59;
            txtZL.TextAlignment = ContentAlignment.MiddleLeft;
            txtZL.Watermark = "";
            // 
            // iudSL7
            // 
            iudSL7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL7.Location = new Point(317, 441);
            iudSL7.Margin = new Padding(4, 5, 4, 5);
            iudSL7.Minimum = 1;
            iudSL7.MinimumSize = new Size(100, 0);
            iudSL7.Name = "iudSL7";
            iudSL7.ShowText = false;
            iudSL7.Size = new Size(116, 29);
            iudSL7.TabIndex = 58;
            iudSL7.Text = "uiIntegerUpDown14";
            iudSL7.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL7.Value = 1;
            iudSL7.ValueChanged += iudSL7_ValueChanged;
            // 
            // iudS7
            // 
            iudS7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS7.Location = new Point(147, 441);
            iudS7.Margin = new Padding(4, 5, 4, 5);
            iudS7.Minimum = 1;
            iudS7.MinimumSize = new Size(100, 0);
            iudS7.Name = "iudS7";
            iudS7.ShowText = false;
            iudS7.Size = new Size(116, 29);
            iudS7.TabIndex = 57;
            iudS7.Text = "uiIntegerUpDown15";
            iudS7.TextAlignment = ContentAlignment.MiddleCenter;
            iudS7.Value = 1;
            iudS7.ValueChanged += iudS7_ValueChanged;
            // 
            // uiLabel13
            // 
            uiLabel13.Font = new Font("宋体", 12F);
            uiLabel13.ForeColor = Color.Red;
            uiLabel13.Location = new Point(21, 447);
            uiLabel13.Name = "uiLabel13";
            uiLabel13.Size = new Size(102, 23);
            uiLabel13.TabIndex = 56;
            uiLabel13.Text = "装量:";
            uiLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMD
            // 
            txtMD.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMD.Location = new Point(470, 385);
            txtMD.Margin = new Padding(4, 5, 4, 5);
            txtMD.MinimumSize = new Size(1, 16);
            txtMD.Name = "txtMD";
            txtMD.Padding = new Padding(5);
            txtMD.ShowText = false;
            txtMD.Size = new Size(250, 29);
            txtMD.TabIndex = 55;
            txtMD.TextAlignment = ContentAlignment.MiddleLeft;
            txtMD.Watermark = "";
            // 
            // iudSL6
            // 
            iudSL6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL6.Location = new Point(317, 385);
            iudSL6.Margin = new Padding(4, 5, 4, 5);
            iudSL6.Minimum = 1;
            iudSL6.MinimumSize = new Size(100, 0);
            iudSL6.Name = "iudSL6";
            iudSL6.ShowText = false;
            iudSL6.Size = new Size(116, 29);
            iudSL6.TabIndex = 54;
            iudSL6.Text = "uiIntegerUpDown12";
            iudSL6.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL6.Value = 1;
            iudSL6.ValueChanged += iudSL6_ValueChanged;
            // 
            // iudS6
            // 
            iudS6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS6.Location = new Point(147, 385);
            iudS6.Margin = new Padding(4, 5, 4, 5);
            iudS6.Minimum = 1;
            iudS6.MinimumSize = new Size(100, 0);
            iudS6.Name = "iudS6";
            iudS6.ShowText = false;
            iudS6.Size = new Size(116, 29);
            iudS6.TabIndex = 53;
            iudS6.Text = "uiIntegerUpDown13";
            iudS6.TextAlignment = ContentAlignment.MiddleCenter;
            iudS6.Value = 1;
            iudS6.ValueChanged += iudS6_ValueChanged;
            // 
            // uiLabel12
            // 
            uiLabel12.Font = new Font("宋体", 12F);
            uiLabel12.ForeColor = Color.Red;
            uiLabel12.Location = new Point(21, 391);
            uiLabel12.Name = "uiLabel12";
            uiLabel12.Size = new Size(102, 23);
            uiLabel12.TabIndex = 52;
            uiLabel12.Text = "密度:";
            uiLabel12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDL
            // 
            txtDL.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtDL.Location = new Point(470, 318);
            txtDL.Margin = new Padding(4, 5, 4, 5);
            txtDL.MinimumSize = new Size(1, 16);
            txtDL.Name = "txtDL";
            txtDL.Padding = new Padding(5);
            txtDL.ShowText = false;
            txtDL.Size = new Size(250, 29);
            txtDL.TabIndex = 51;
            txtDL.TextAlignment = ContentAlignment.MiddleLeft;
            txtDL.Watermark = "";
            // 
            // iudSL5
            // 
            iudSL5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL5.Location = new Point(317, 318);
            iudSL5.Margin = new Padding(4, 5, 4, 5);
            iudSL5.Minimum = 1;
            iudSL5.MinimumSize = new Size(100, 0);
            iudSL5.Name = "iudSL5";
            iudSL5.ShowText = false;
            iudSL5.Size = new Size(116, 29);
            iudSL5.TabIndex = 50;
            iudSL5.Text = "uiIntegerUpDown10";
            iudSL5.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL5.Value = 1;
            iudSL5.ValueChanged += iudSL5_ValueChanged;
            // 
            // iudS5
            // 
            iudS5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS5.Location = new Point(147, 318);
            iudS5.Margin = new Padding(4, 5, 4, 5);
            iudS5.Minimum = 1;
            iudS5.MinimumSize = new Size(100, 0);
            iudS5.Name = "iudS5";
            iudS5.ShowText = false;
            iudS5.Size = new Size(116, 29);
            iudS5.TabIndex = 49;
            iudS5.Text = "uiIntegerUpDown11";
            iudS5.TextAlignment = ContentAlignment.MiddleCenter;
            iudS5.Value = 1;
            iudS5.ValueChanged += iudS5_ValueChanged;
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new Font("宋体", 12F);
            uiLabel11.ForeColor = Color.Black;
            uiLabel11.Location = new Point(21, 324);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new Size(102, 23);
            uiLabel11.TabIndex = 48;
            uiLabel11.Text = "当量:";
            uiLabel11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtYXQ
            // 
            txtYXQ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtYXQ.Location = new Point(470, 255);
            txtYXQ.Margin = new Padding(4, 5, 4, 5);
            txtYXQ.MinimumSize = new Size(1, 16);
            txtYXQ.Name = "txtYXQ";
            txtYXQ.Padding = new Padding(5);
            txtYXQ.ShowText = false;
            txtYXQ.Size = new Size(250, 29);
            txtYXQ.TabIndex = 47;
            txtYXQ.TextAlignment = ContentAlignment.MiddleLeft;
            txtYXQ.Watermark = "";
            // 
            // iudSL4
            // 
            iudSL4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL4.Location = new Point(317, 255);
            iudSL4.Margin = new Padding(4, 5, 4, 5);
            iudSL4.Minimum = 1;
            iudSL4.MinimumSize = new Size(100, 0);
            iudSL4.Name = "iudSL4";
            iudSL4.ShowText = false;
            iudSL4.Size = new Size(116, 29);
            iudSL4.TabIndex = 46;
            iudSL4.Text = "uiIntegerUpDown8";
            iudSL4.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL4.Value = 1;
            iudSL4.ValueChanged += iudSL4_ValueChanged;
            // 
            // iudS4
            // 
            iudS4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS4.Location = new Point(147, 255);
            iudS4.Margin = new Padding(4, 5, 4, 5);
            iudS4.Minimum = 1;
            iudS4.MinimumSize = new Size(100, 0);
            iudS4.Name = "iudS4";
            iudS4.ShowText = false;
            iudS4.Size = new Size(116, 29);
            iudS4.TabIndex = 45;
            iudS4.Text = "uiIntegerUpDown9";
            iudS4.TextAlignment = ContentAlignment.MiddleCenter;
            iudS4.Value = 1;
            iudS4.ValueChanged += iudS4_ValueChanged;
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new Font("宋体", 12F);
            uiLabel10.ForeColor = Color.Black;
            uiLabel10.Location = new Point(21, 261);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new Size(102, 23);
            uiLabel10.TabIndex = 44;
            uiLabel10.Text = "有效期:";
            uiLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPH
            // 
            txtPH.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPH.Location = new Point(470, 188);
            txtPH.Margin = new Padding(4, 5, 4, 5);
            txtPH.MinimumSize = new Size(1, 16);
            txtPH.Name = "txtPH";
            txtPH.Padding = new Padding(5);
            txtPH.ShowText = false;
            txtPH.Size = new Size(250, 29);
            txtPH.TabIndex = 43;
            txtPH.TextAlignment = ContentAlignment.MiddleLeft;
            txtPH.Watermark = "";
            // 
            // iudSL3
            // 
            iudSL3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL3.Location = new Point(317, 188);
            iudSL3.Margin = new Padding(4, 5, 4, 5);
            iudSL3.Minimum = 1;
            iudSL3.MinimumSize = new Size(100, 0);
            iudSL3.Name = "iudSL3";
            iudSL3.ShowText = false;
            iudSL3.Size = new Size(116, 29);
            iudSL3.TabIndex = 42;
            iudSL3.Text = "uiIntegerUpDown6";
            iudSL3.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL3.Value = 1;
            iudSL3.ValueChanged += iudSL3_ValueChanged;
            // 
            // iudS3
            // 
            iudS3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS3.Location = new Point(147, 188);
            iudS3.Margin = new Padding(4, 5, 4, 5);
            iudS3.Minimum = 1;
            iudS3.MinimumSize = new Size(100, 0);
            iudS3.Name = "iudS3";
            iudS3.ShowText = false;
            iudS3.Size = new Size(116, 29);
            iudS3.TabIndex = 41;
            iudS3.Text = "uiIntegerUpDown7";
            iudS3.TextAlignment = ContentAlignment.MiddleCenter;
            iudS3.Value = 1;
            iudS3.ValueChanged += iudS3_ValueChanged;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new Font("宋体", 12F);
            uiLabel9.ForeColor = Color.Black;
            uiLabel9.Location = new Point(21, 194);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(102, 23);
            uiLabel9.TabIndex = 40;
            uiLabel9.Text = "批号:";
            uiLabel9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBZLX
            // 
            txtBZLX.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtBZLX.Location = new Point(470, 127);
            txtBZLX.Margin = new Padding(4, 5, 4, 5);
            txtBZLX.MinimumSize = new Size(1, 16);
            txtBZLX.Name = "txtBZLX";
            txtBZLX.Padding = new Padding(5);
            txtBZLX.ShowText = false;
            txtBZLX.Size = new Size(250, 29);
            txtBZLX.TabIndex = 39;
            txtBZLX.TextAlignment = ContentAlignment.MiddleLeft;
            txtBZLX.Watermark = "";
            // 
            // iudSL2
            // 
            iudSL2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL2.Location = new Point(317, 127);
            iudSL2.Margin = new Padding(4, 5, 4, 5);
            iudSL2.Minimum = 1;
            iudSL2.MinimumSize = new Size(100, 0);
            iudSL2.Name = "iudSL2";
            iudSL2.ShowText = false;
            iudSL2.Size = new Size(116, 29);
            iudSL2.TabIndex = 38;
            iudSL2.Text = "uiIntegerUpDown4";
            iudSL2.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL2.Value = 1;
            iudSL2.ValueChanged += iudSL2_ValueChanged;
            // 
            // iudS2
            // 
            iudS2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS2.Location = new Point(147, 127);
            iudS2.Margin = new Padding(4, 5, 4, 5);
            iudS2.Minimum = 1;
            iudS2.MinimumSize = new Size(100, 0);
            iudS2.Name = "iudS2";
            iudS2.ShowText = false;
            iudS2.Size = new Size(116, 29);
            iudS2.TabIndex = 37;
            iudS2.Text = "uiIntegerUpDown5";
            iudS2.TextAlignment = ContentAlignment.MiddleCenter;
            iudS2.Value = 1;
            iudS2.ValueChanged += iudS2_ValueChanged;
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("宋体", 12F);
            uiLabel8.ForeColor = Color.Black;
            uiLabel8.Location = new Point(21, 133);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(102, 23);
            uiLabel8.TabIndex = 36;
            uiLabel8.Text = "包装类型:";
            uiLabel8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDBZM
            // 
            txtDBZM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtDBZM.Location = new Point(470, 66);
            txtDBZM.Margin = new Padding(4, 5, 4, 5);
            txtDBZM.MinimumSize = new Size(1, 16);
            txtDBZM.Name = "txtDBZM";
            txtDBZM.Padding = new Padding(5);
            txtDBZM.ShowText = false;
            txtDBZM.Size = new Size(250, 29);
            txtDBZM.TabIndex = 35;
            txtDBZM.TextAlignment = ContentAlignment.MiddleLeft;
            txtDBZM.Watermark = "";
            // 
            // iudSL1
            // 
            iudSL1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSL1.Location = new Point(317, 66);
            iudSL1.Margin = new Padding(4, 5, 4, 5);
            iudSL1.Minimum = 1;
            iudSL1.MinimumSize = new Size(100, 0);
            iudSL1.Name = "iudSL1";
            iudSL1.ShowText = false;
            iudSL1.Size = new Size(116, 29);
            iudSL1.TabIndex = 34;
            iudSL1.Text = "uiIntegerUpDown3";
            iudSL1.TextAlignment = ContentAlignment.MiddleCenter;
            iudSL1.Value = 1;
            iudSL1.ValueChanged += iudSL1_ValueChanged;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 12F);
            uiLabel7.ForeColor = Color.Black;
            uiLabel7.Location = new Point(470, 28);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(102, 23);
            uiLabel7.TabIndex = 33;
            uiLabel7.Text = "解析结果";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 12F);
            uiLabel6.ForeColor = Color.Black;
            uiLabel6.Location = new Point(317, 28);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(102, 23);
            uiLabel6.TabIndex = 32;
            uiLabel6.Text = "长度";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F);
            uiLabel5.ForeColor = Color.Black;
            uiLabel5.Location = new Point(147, 28);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(102, 23);
            uiLabel5.TabIndex = 31;
            uiLabel5.Text = "起始位";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iudS1
            // 
            iudS1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudS1.Location = new Point(147, 66);
            iudS1.Margin = new Padding(4, 5, 4, 5);
            iudS1.Minimum = 1;
            iudS1.MinimumSize = new Size(100, 0);
            iudS1.Name = "iudS1";
            iudS1.ShowText = false;
            iudS1.Size = new Size(116, 29);
            iudS1.TabIndex = 30;
            iudS1.Text = "uiIntegerUpDown2";
            iudS1.TextAlignment = ContentAlignment.MiddleCenter;
            iudS1.Value = 1;
            iudS1.ValueChanged += iudS1_ValueChanged;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(21, 72);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(102, 23);
            uiLabel4.TabIndex = 29;
            uiLabel4.Text = "大包装码:";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCJMC
            // 
            txtCJMC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtCJMC.Location = new Point(811, 78);
            txtCJMC.Margin = new Padding(4, 5, 4, 5);
            txtCJMC.MaxLength = 50;
            txtCJMC.MinimumSize = new Size(1, 16);
            txtCJMC.Name = "txtCJMC";
            txtCJMC.Padding = new Padding(5);
            txtCJMC.ReadOnly = true;
            txtCJMC.ShowText = false;
            txtCJMC.Size = new Size(294, 29);
            txtCJMC.TabIndex = 39;
            txtCJMC.TextAlignment = ContentAlignment.MiddleLeft;
            txtCJMC.Watermark = "厂家名称";
            // 
            // FrmDrugManufacturer
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1522, 848);
            Controls.Add(txtCJMC);
            Controls.Add(uiGroupBox1);
            Controls.Add(cbJXXL);
            Controls.Add(uiLabel2);
            Controls.Add(iuCJXH);
            Controls.Add(uiLabel1);
            Controls.Add(uiPage);
            Controls.Add(btnRefc);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(dgvList);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "FrmDrugManufacturer";
            Padding = new Padding(0, 35, 0, 0);
            RectColor = Color.DodgerBlue;
            ShowTitle = true;
            Symbol = 358586;
            Text = "药品厂家";
            Load += FrmDrugManufacturer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            uiGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnRefc;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIIntegerUpDown iuCJXH;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox cbJXXL;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton btnStartJX;
        private Sunny.UI.UIButton btnSave;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox txtDBZM;
        private Sunny.UI.UIIntegerUpDown iudSL1;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIIntegerUpDown iudS1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtZL;
        private Sunny.UI.UIIntegerUpDown iudSL7;
        private Sunny.UI.UIIntegerUpDown iudS7;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UITextBox txtMD;
        private Sunny.UI.UIIntegerUpDown iudSL6;
        private Sunny.UI.UIIntegerUpDown iudS6;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITextBox txtDL;
        private Sunny.UI.UIIntegerUpDown iudSL5;
        private Sunny.UI.UIIntegerUpDown iudS5;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox txtYXQ;
        private Sunny.UI.UIIntegerUpDown iudSL4;
        private Sunny.UI.UIIntegerUpDown iudS4;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITextBox txtPH;
        private Sunny.UI.UIIntegerUpDown iudSL3;
        private Sunny.UI.UIIntegerUpDown iudS3;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox txtBZLX;
        private Sunny.UI.UIIntegerUpDown iudSL2;
        private Sunny.UI.UIIntegerUpDown iudS2;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox txtJXM;
        private Sunny.UI.UIButton btnreset;
        private Sunny.UI.UITextBox txtCJMC;
        private Sunny.UI.UILabel lbl7;
        private Sunny.UI.UILabel lbl6;
        private Sunny.UI.UILabel lbl5;
        private Sunny.UI.UILabel lbl4;
        private Sunny.UI.UILabel lbl3;
        private Sunny.UI.UILabel lbl2;
        private Sunny.UI.UILabel lbl1;
    }
}