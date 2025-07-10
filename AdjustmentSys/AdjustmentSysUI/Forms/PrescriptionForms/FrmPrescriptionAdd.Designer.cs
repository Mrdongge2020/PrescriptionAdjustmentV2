namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmPrescriptionAdd
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
            uiLabel1 = new Sunny.UI.UILabel();
            txtPrID = new Sunny.UI.UITextBox();
            txtPatName = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            txtPatPhone = new Sunny.UI.UITextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            cbSex = new Sunny.UI.UIComboBox();
            iudAgeYear = new Sunny.UI.UIIntegerUpDown();
            iupAgeMonth = new Sunny.UI.UIIntegerUpDown();
            iudFFCS = new Sunny.UI.UIIntegerUpDown();
            iudFS = new Sunny.UI.UIIntegerUpDown();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
            uiLabel9 = new Sunny.UI.UILabel();
            cbDoctorName = new Sunny.UI.UIComboBox();
            txtDocDepartment = new Sunny.UI.UITextBox();
            uiLabel10 = new Sunny.UI.UILabel();
            uiLabel11 = new Sunny.UI.UILabel();
            txtRemark = new Sunny.UI.UITextBox();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            btnAdd = new Sunny.UI.UISymbolButton();
            dgvFooter = new Sunny.UI.UIDataGridViewFooter();
            dgvDurgList = new Sunny.UI.UIDataGridView();
            ID = new DataGridViewTextBoxColumn();
            ParCode = new DataGridViewTextBoxColumn();
            ParName = new DataGridViewTextBoxColumn();
            ParticlesCodeHIS = new DataGridViewTextBoxColumn();
            DoseHerb = new DataGridViewTextBoxColumn();
            Equivalent = new DataGridViewTextBoxColumn();
            Dose = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            cmsDurg = new Sunny.UI.UIContextMenuStrip();
            removeDurg = new ToolStripMenuItem();
            uiLabel15 = new Sunny.UI.UILabel();
            lbCheckResult = new Sunny.UI.UIListBox();
            dudJL = new Sunny.UI.UIDoubleUpDown();
            uiLabel14 = new Sunny.UI.UILabel();
            uiLabel13 = new Sunny.UI.UILabel();
            cbJLFS = new Sunny.UI.UIComboBox();
            cbDurg = new Sunny.UI.UIComboBox();
            uiLabel16 = new Sunny.UI.UILabel();
            txtXDFMC = new Sunny.UI.UITextBox();
            btnSavePre = new Sunny.UI.UISymbolButton();
            btnSaveXDF = new Sunny.UI.UISymbolButton();
            uiGroupBox1.SuspendLayout();
            uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDurgList).BeginInit();
            cmsDurg.SuspendLayout();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(3, 46);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(130, 23);
            uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "处方编号:";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPrID
            // 
            txtPrID.ButtonSymbol = 362193;
            txtPrID.Cursor = Cursors.IBeam;
            txtPrID.Font = new Font("微软雅黑", 12F);
            txtPrID.Location = new Point(147, 43);
            txtPrID.Margin = new Padding(4, 5, 4, 5);
            txtPrID.MinimumSize = new Size(1, 16);
            txtPrID.Name = "txtPrID";
            txtPrID.Padding = new Padding(5);
            txtPrID.ShowButton = true;
            txtPrID.ShowText = false;
            txtPrID.Size = new Size(222, 29);
            txtPrID.TabIndex = 1;
            txtPrID.TextAlignment = ContentAlignment.MiddleLeft;
            txtPrID.Watermark = "";
            txtPrID.ButtonClick += txtPrID_ButtonClick;
            txtPrID.KeyPress += txtPrID_KeyPress;
            // 
            // txtPatName
            // 
            txtPatName.Font = new Font("微软雅黑", 12F);
            txtPatName.Location = new Point(480, 43);
            txtPatName.Margin = new Padding(4, 5, 4, 5);
            txtPatName.MaxLength = 20;
            txtPatName.MinimumSize = new Size(1, 16);
            txtPatName.Name = "txtPatName";
            txtPatName.Padding = new Padding(5);
            txtPatName.ShowText = false;
            txtPatName.Size = new Size(126, 29);
            txtPatName.TabIndex = 3;
            txtPatName.TextAlignment = ContentAlignment.MiddleLeft;
            txtPatName.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(373, 46);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(102, 23);
            uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            uiLabel2.TabIndex = 2;
            uiLabel2.Text = "患者姓名:";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPatPhone
            // 
            txtPatPhone.Font = new Font("微软雅黑", 12F);
            txtPatPhone.Location = new Point(722, 43);
            txtPatPhone.Margin = new Padding(4, 5, 4, 5);
            txtPatPhone.MaxLength = 20;
            txtPatPhone.MinimumSize = new Size(1, 16);
            txtPatPhone.Name = "txtPatPhone";
            txtPatPhone.Padding = new Padding(5);
            txtPatPhone.ShowText = false;
            txtPatPhone.Size = new Size(127, 29);
            txtPatPhone.TabIndex = 5;
            txtPatPhone.TextAlignment = ContentAlignment.MiddleLeft;
            txtPatPhone.Watermark = "";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(616, 46);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(102, 23);
            uiLabel3.TabIndex = 4;
            uiLabel3.Text = "患者电话:";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 12F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(853, 46);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(68, 23);
            uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            uiLabel4.TabIndex = 6;
            uiLabel4.Text = "性别:";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 12F);
            uiLabel5.ForeColor = Color.Red;
            uiLabel5.Location = new Point(1011, 46);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(69, 23);
            uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            uiLabel5.TabIndex = 7;
            uiLabel5.Text = "年龄:";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("微软雅黑", 12F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(1192, 46);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(57, 23);
            uiLabel6.TabIndex = 8;
            uiLabel6.Text = "月份:";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbSex
            // 
            cbSex.DataSource = null;
            cbSex.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbSex.FillColor = Color.White;
            cbSex.Font = new Font("微软雅黑", 12F);
            cbSex.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbSex.Items.AddRange(new object[] { "女", "男", "保密" });
            cbSex.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbSex.Location = new Point(927, 43);
            cbSex.Margin = new Padding(4, 5, 4, 5);
            cbSex.MinimumSize = new Size(63, 0);
            cbSex.Name = "cbSex";
            cbSex.Padding = new Padding(0, 0, 30, 2);
            cbSex.Size = new Size(66, 29);
            cbSex.SymbolSize = 24;
            cbSex.TabIndex = 9;
            cbSex.Text = "女";
            cbSex.TextAlignment = ContentAlignment.MiddleLeft;
            cbSex.Watermark = "";
            // 
            // iudAgeYear
            // 
            iudAgeYear.Font = new Font("微软雅黑", 12F);
            iudAgeYear.Location = new Point(1087, 43);
            iudAgeYear.Margin = new Padding(4, 5, 4, 5);
            iudAgeYear.MinimumSize = new Size(100, 0);
            iudAgeYear.Name = "iudAgeYear";
            iudAgeYear.ShowText = false;
            iudAgeYear.Size = new Size(100, 29);
            iudAgeYear.TabIndex = 10;
            iudAgeYear.Text = null;
            iudAgeYear.TextAlignment = ContentAlignment.MiddleCenter;
            iudAgeYear.Value = 20;
            // 
            // iupAgeMonth
            // 
            iupAgeMonth.Font = new Font("微软雅黑", 12F);
            iupAgeMonth.Location = new Point(1256, 43);
            iupAgeMonth.Margin = new Padding(4, 5, 4, 5);
            iupAgeMonth.MinimumSize = new Size(100, 0);
            iupAgeMonth.Name = "iupAgeMonth";
            iupAgeMonth.ShowText = false;
            iupAgeMonth.Size = new Size(100, 29);
            iupAgeMonth.TabIndex = 11;
            iupAgeMonth.Text = "uiIntegerUpDown2";
            iupAgeMonth.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // iudFFCS
            // 
            iudFFCS.Font = new Font("微软雅黑", 12F);
            iudFFCS.Location = new Point(267, 97);
            iudFFCS.Margin = new Padding(4, 5, 4, 5);
            iudFFCS.Minimum = 0;
            iudFFCS.MinimumSize = new Size(100, 0);
            iudFFCS.Name = "iudFFCS";
            iudFFCS.ShowText = false;
            iudFFCS.Size = new Size(100, 29);
            iudFFCS.TabIndex = 15;
            iudFFCS.Text = "uiIntegerUpDown3";
            iudFFCS.TextAlignment = ContentAlignment.MiddleCenter;
            iudFFCS.Value = 2;
            // 
            // iudFS
            // 
            iudFS.Font = new Font("微软雅黑", 12F);
            iudFS.Location = new Point(147, 97);
            iudFS.Margin = new Padding(4, 5, 4, 5);
            iudFS.Minimum = 0;
            iudFS.MinimumSize = new Size(100, 0);
            iudFS.Name = "iudFS";
            iudFS.ShowText = false;
            iudFS.Size = new Size(100, 29);
            iudFS.TabIndex = 14;
            iudFS.Text = "uiIntegerUpDown4";
            iudFS.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(250, 100);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(10, 23);
            uiLabel7.TabIndex = 13;
            uiLabel7.Text = "/";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("微软雅黑", 12F);
            uiLabel8.ForeColor = Color.Red;
            uiLabel8.Location = new Point(3, 100);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(140, 23);
            uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            uiLabel8.TabIndex = 12;
            uiLabel8.Text = "付数/分服次数:";
            uiLabel8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new Font("微软雅黑", 12F);
            uiLabel9.ForeColor = Color.Red;
            uiLabel9.Location = new Point(371, 100);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(102, 23);
            uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            uiLabel9.TabIndex = 16;
            uiLabel9.Text = "医生姓名:";
            uiLabel9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbDoctorName
            // 
            cbDoctorName.DataSource = null;
            cbDoctorName.FillColor = Color.White;
            cbDoctorName.FilterIgnoreCase = true;
            cbDoctorName.Font = new Font("微软雅黑", 12F);
            cbDoctorName.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDoctorName.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDoctorName.Location = new Point(480, 97);
            cbDoctorName.Margin = new Padding(4, 5, 4, 5);
            cbDoctorName.MinimumSize = new Size(63, 0);
            cbDoctorName.Name = "cbDoctorName";
            cbDoctorName.Padding = new Padding(0, 0, 30, 2);
            cbDoctorName.ShowClearButton = true;
            cbDoctorName.ShowFilter = true;
            cbDoctorName.Size = new Size(126, 29);
            cbDoctorName.SymbolSize = 24;
            cbDoctorName.TabIndex = 17;
            cbDoctorName.TextAlignment = ContentAlignment.MiddleLeft;
            cbDoctorName.Watermark = "";
            cbDoctorName.SelectedValueChanged += cbDoctorName_SelectedValueChanged;
            // 
            // txtDocDepartment
            // 
            txtDocDepartment.Font = new Font("微软雅黑", 12F);
            txtDocDepartment.Location = new Point(722, 97);
            txtDocDepartment.Margin = new Padding(4, 5, 4, 5);
            txtDocDepartment.MaxLength = 20;
            txtDocDepartment.MinimumSize = new Size(1, 16);
            txtDocDepartment.Name = "txtDocDepartment";
            txtDocDepartment.Padding = new Padding(5);
            txtDocDepartment.ShowText = false;
            txtDocDepartment.Size = new Size(127, 29);
            txtDocDepartment.TabIndex = 19;
            txtDocDepartment.TextAlignment = ContentAlignment.MiddleLeft;
            txtDocDepartment.Watermark = "";
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new Font("微软雅黑", 12F);
            uiLabel10.ForeColor = Color.Red;
            uiLabel10.Location = new Point(616, 100);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new Size(102, 23);
            uiLabel10.Style = Sunny.UI.UIStyle.Custom;
            uiLabel10.TabIndex = 18;
            uiLabel10.Text = "医生科室:";
            uiLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new Font("微软雅黑", 12F);
            uiLabel11.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new Point(853, 100);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new Size(68, 23);
            uiLabel11.TabIndex = 20;
            uiLabel11.Text = "备注:";
            uiLabel11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("微软雅黑", 12F);
            txtRemark.Location = new Point(927, 97);
            txtRemark.Margin = new Padding(4, 5, 4, 5);
            txtRemark.MaxLength = 200;
            txtRemark.MinimumSize = new Size(1, 16);
            txtRemark.Name = "txtRemark";
            txtRemark.Padding = new Padding(5);
            txtRemark.ShowText = false;
            txtRemark.Size = new Size(429, 29);
            txtRemark.TabIndex = 21;
            txtRemark.TextAlignment = ContentAlignment.MiddleLeft;
            txtRemark.Watermark = "";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(uiLabel1);
            uiGroupBox1.Controls.Add(txtPrID);
            uiGroupBox1.Controls.Add(txtRemark);
            uiGroupBox1.Controls.Add(uiLabel2);
            uiGroupBox1.Controls.Add(uiLabel11);
            uiGroupBox1.Controls.Add(txtPatName);
            uiGroupBox1.Controls.Add(txtDocDepartment);
            uiGroupBox1.Controls.Add(uiLabel3);
            uiGroupBox1.Controls.Add(uiLabel10);
            uiGroupBox1.Controls.Add(txtPatPhone);
            uiGroupBox1.Controls.Add(cbDoctorName);
            uiGroupBox1.Controls.Add(uiLabel4);
            uiGroupBox1.Controls.Add(uiLabel9);
            uiGroupBox1.Controls.Add(uiLabel5);
            uiGroupBox1.Controls.Add(iudFFCS);
            uiGroupBox1.Controls.Add(uiLabel6);
            uiGroupBox1.Controls.Add(iudFS);
            uiGroupBox1.Controls.Add(cbSex);
            uiGroupBox1.Controls.Add(uiLabel7);
            uiGroupBox1.Controls.Add(iudAgeYear);
            uiGroupBox1.Controls.Add(uiLabel8);
            uiGroupBox1.Controls.Add(iupAgeMonth);
            uiGroupBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new Point(4, 40);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(1362, 152);
            uiGroupBox1.TabIndex = 23;
            uiGroupBox1.Text = "处方信息";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(btnAdd);
            uiGroupBox2.Controls.Add(dgvFooter);
            uiGroupBox2.Controls.Add(uiLabel15);
            uiGroupBox2.Controls.Add(lbCheckResult);
            uiGroupBox2.Controls.Add(dgvDurgList);
            uiGroupBox2.Controls.Add(dudJL);
            uiGroupBox2.Controls.Add(uiLabel14);
            uiGroupBox2.Controls.Add(uiLabel13);
            uiGroupBox2.Controls.Add(cbJLFS);
            uiGroupBox2.Controls.Add(cbDurg);
            uiGroupBox2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox2.Location = new Point(4, 193);
            uiGroupBox2.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox2.MinimumSize = new Size(1, 1);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox2.Size = new Size(1362, 483);
            uiGroupBox2.TabIndex = 24;
            uiGroupBox2.Text = "添加药品";
            uiGroupBox2.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Location = new Point(704, 28);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 10;
            btnAdd.Size = new Size(110, 35);
            btnAdd.Symbol = 557672;
            btnAdd.TabIndex = 19;
            btnAdd.Text = "添加药品";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvFooter
            // 
            dgvFooter.DataGridView = dgvDurgList;
            dgvFooter.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvFooter.Location = new Point(3, 448);
            dgvFooter.MinimumSize = new Size(1, 1);
            dgvFooter.Name = "dgvFooter";
            dgvFooter.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            dgvFooter.Size = new Size(950, 29);
            dgvFooter.TabIndex = 18;
            // 
            // dgvDurgList
            // 
            dgvDurgList.AllowUserToAddRows = false;
            dgvDurgList.AllowUserToDeleteRows = false;
            dgvDurgList.AllowUserToResizeColumns = false;
            dgvDurgList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvDurgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDurgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDurgList.BackgroundColor = Color.White;
            dgvDurgList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDurgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDurgList.ColumnHeadersHeight = 32;
            dgvDurgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDurgList.Columns.AddRange(new DataGridViewColumn[] { ID, ParCode, ParName, ParticlesCodeHIS, DoseHerb, Equivalent, Dose, Stock, Price, TotalPrice });
            dgvDurgList.ContextMenuStrip = cmsDurg;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDurgList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDurgList.EnableHeadersVisualStyles = false;
            dgvDurgList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDurgList.GridColor = Color.FromArgb(80, 160, 255);
            dgvDurgList.Location = new Point(3, 68);
            dgvDurgList.Name = "dgvDurgList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDurgList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDurgList.RowHeadersWidth = 60;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDurgList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvDurgList.SelectedIndex = -1;
            dgvDurgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDurgList.Size = new Size(950, 380);
            dgvDurgList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvDurgList.TabIndex = 15;
            dgvDurgList.CellClick += dgvDurgList_CellClick;
            dgvDurgList.RowPostPaint += dgvDurgList_RowPostPaint;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "主键id";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.SortMode = DataGridViewColumnSortMode.NotSortable;
            ID.Visible = false;
            // 
            // ParCode
            // 
            ParCode.DataPropertyName = "ParCode";
            ParCode.HeaderText = "颗粒编码";
            ParCode.Name = "ParCode";
            ParCode.ReadOnly = true;
            ParCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParName
            // 
            ParName.DataPropertyName = "ParName";
            ParName.HeaderText = "颗粒名称";
            ParName.Name = "ParName";
            ParName.ReadOnly = true;
            ParName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParticlesCodeHIS
            // 
            ParticlesCodeHIS.DataPropertyName = "ParticlesCodeHIS";
            ParticlesCodeHIS.HeaderText = "HIS编码";
            ParticlesCodeHIS.Name = "ParticlesCodeHIS";
            ParticlesCodeHIS.ReadOnly = true;
            ParticlesCodeHIS.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // DoseHerb
            // 
            DoseHerb.DataPropertyName = "DoseHerb";
            DoseHerb.HeaderText = "饮片剂量";
            DoseHerb.Name = "DoseHerb";
            DoseHerb.ReadOnly = true;
            DoseHerb.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Equivalent
            // 
            Equivalent.DataPropertyName = "Equivalent";
            Equivalent.HeaderText = "当量";
            Equivalent.Name = "Equivalent";
            Equivalent.ReadOnly = true;
            Equivalent.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Dose
            // 
            Dose.DataPropertyName = "Dose";
            Dose.HeaderText = "颗粒剂量";
            Dose.Name = "Dose";
            Dose.ReadOnly = true;
            Dose.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Stock
            // 
            Stock.DataPropertyName = "Stock";
            Stock.HeaderText = "库存";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "饮片单价";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalPrice
            // 
            TotalPrice.DataPropertyName = "TotalPrice";
            TotalPrice.HeaderText = "饮片总价";
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            TotalPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsDurg
            // 
            cmsDurg.BackColor = Color.FromArgb(243, 249, 255);
            cmsDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsDurg.Items.AddRange(new ToolStripItem[] { removeDurg });
            cmsDurg.Name = "cmsDurg";
            cmsDurg.Size = new Size(107, 26);
            // 
            // removeDurg
            // 
            removeDurg.Name = "removeDurg";
            removeDurg.Size = new Size(106, 22);
            removeDurg.Text = "移除";
            removeDurg.Click += removeDurg_Click;
            // 
            // uiLabel15
            // 
            uiLabel15.Font = new Font("微软雅黑", 12F);
            uiLabel15.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel15.Location = new Point(960, 40);
            uiLabel15.Name = "uiLabel15";
            uiLabel15.Size = new Size(137, 23);
            uiLabel15.TabIndex = 17;
            uiLabel15.Text = "处方分析:";
            uiLabel15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCheckResult
            // 
            lbCheckResult.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbCheckResult.HoverColor = Color.FromArgb(155, 200, 255);
            lbCheckResult.ItemSelectForeColor = Color.White;
            lbCheckResult.Location = new Point(960, 68);
            lbCheckResult.Margin = new Padding(4, 5, 4, 5);
            lbCheckResult.MinimumSize = new Size(1, 1);
            lbCheckResult.Name = "lbCheckResult";
            lbCheckResult.Padding = new Padding(2);
            lbCheckResult.ShowText = false;
            lbCheckResult.Size = new Size(398, 410);
            lbCheckResult.TabIndex = 16;
            lbCheckResult.Text = "uiListBox1";
            // 
            // dudJL
            // 
            dudJL.DecimalPlaces = 2;
            dudJL.Font = new Font("微软雅黑", 12F);
            dudJL.Location = new Point(553, 31);
            dudJL.Margin = new Padding(4, 5, 4, 5);
            dudJL.Maximum = 100000D;
            dudJL.Minimum = 0D;
            dudJL.MinimumSize = new Size(100, 0);
            dudJL.Name = "dudJL";
            dudJL.ShowText = false;
            dudJL.Size = new Size(116, 29);
            dudJL.TabIndex = 13;
            dudJL.Text = null;
            dudJL.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel14
            // 
            uiLabel14.Font = new Font("微软雅黑", 12F);
            uiLabel14.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel14.Location = new Point(477, 34);
            uiLabel14.Name = "uiLabel14";
            uiLabel14.Size = new Size(72, 23);
            uiLabel14.TabIndex = 12;
            uiLabel14.Text = "剂量:";
            uiLabel14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel13
            // 
            uiLabel13.Font = new Font("微软雅黑", 12F);
            uiLabel13.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel13.Location = new Point(217, 34);
            uiLabel13.Name = "uiLabel13";
            uiLabel13.Size = new Size(113, 23);
            uiLabel13.TabIndex = 10;
            uiLabel13.Text = "剂量方式:";
            uiLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbJLFS
            // 
            cbJLFS.DataSource = null;
            cbJLFS.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbJLFS.FillColor = Color.White;
            cbJLFS.Font = new Font("微软雅黑", 12F);
            cbJLFS.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbJLFS.Items.AddRange(new object[] { "饮片剂量", "颗粒剂量" });
            cbJLFS.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbJLFS.Location = new Point(337, 31);
            cbJLFS.Margin = new Padding(4, 5, 4, 5);
            cbJLFS.MinimumSize = new Size(63, 0);
            cbJLFS.Name = "cbJLFS";
            cbJLFS.Padding = new Padding(0, 0, 30, 2);
            cbJLFS.Size = new Size(126, 29);
            cbJLFS.SymbolSize = 24;
            cbJLFS.TabIndex = 11;
            cbJLFS.Text = "饮片剂量";
            cbJLFS.TextAlignment = ContentAlignment.MiddleLeft;
            cbJLFS.Watermark = "";
            // 
            // cbDurg
            // 
            cbDurg.DataSource = null;
            cbDurg.FillColor = Color.White;
            cbDurg.FilterIgnoreCase = true;
            cbDurg.Font = new Font("微软雅黑", 12F);
            cbDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDurg.Location = new Point(15, 31);
            cbDurg.Margin = new Padding(4, 5, 4, 5);
            cbDurg.MinimumSize = new Size(63, 0);
            cbDurg.Name = "cbDurg";
            cbDurg.Padding = new Padding(0, 0, 30, 2);
            cbDurg.ShowClearButton = true;
            cbDurg.ShowFilter = true;
            cbDurg.Size = new Size(190, 29);
            cbDurg.SymbolSize = 24;
            cbDurg.TabIndex = 2;
            cbDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cbDurg.Watermark = "请选择药品";
            // 
            // uiLabel16
            // 
            uiLabel16.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel16.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel16.Location = new Point(17, 689);
            uiLabel16.Name = "uiLabel16";
            uiLabel16.Size = new Size(139, 23);
            uiLabel16.TabIndex = 26;
            uiLabel16.Text = "协定方名称:";
            uiLabel16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtXDFMC
            // 
            txtXDFMC.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtXDFMC.Location = new Point(163, 686);
            txtXDFMC.Margin = new Padding(4, 5, 4, 5);
            txtXDFMC.MinimumSize = new Size(1, 16);
            txtXDFMC.Name = "txtXDFMC";
            txtXDFMC.Padding = new Padding(5);
            txtXDFMC.ShowText = false;
            txtXDFMC.Size = new Size(259, 29);
            txtXDFMC.TabIndex = 27;
            txtXDFMC.TextAlignment = ContentAlignment.MiddleLeft;
            txtXDFMC.Watermark = "";
            // 
            // btnSavePre
            // 
            btnSavePre.Cursor = Cursors.Hand;
            btnSavePre.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSavePre.Location = new Point(1187, 680);
            btnSavePre.MinimumSize = new Size(1, 1);
            btnSavePre.Name = "btnSavePre";
            btnSavePre.Radius = 10;
            btnSavePre.Size = new Size(120, 40);
            btnSavePre.TabIndex = 29;
            btnSavePre.Text = "提交处方";
            btnSavePre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSavePre.Click += btnSavePre_Click;
            // 
            // btnSaveXDF
            // 
            btnSaveXDF.Cursor = Cursors.Hand;
            btnSaveXDF.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSaveXDF.Location = new Point(435, 683);
            btnSaveXDF.MinimumSize = new Size(1, 1);
            btnSaveXDF.Name = "btnSaveXDF";
            btnSaveXDF.Radius = 10;
            btnSaveXDF.Size = new Size(130, 35);
            btnSaveXDF.TabIndex = 30;
            btnSaveXDF.Text = "存为协定方";
            btnSaveXDF.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSaveXDF.Click += btnSaveXDF_Click;
            // 
            // FrmPrescriptionAdd
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1370, 726);
            Controls.Add(btnSaveXDF);
            Controls.Add(btnSavePre);
            Controls.Add(uiLabel16);
            Controls.Add(txtXDFMC);
            Controls.Add(uiGroupBox2);
            Controls.Add(uiGroupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPrescriptionAdd";
            Text = "处方录入";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 1370, 726);
            Load += FrmPrescriptionAdd_Load;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDurgList).EndInit();
            cmsDurg.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtPrID;
        private Sunny.UI.UITextBox txtPatName;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtPatPhone;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIComboBox cbSex;
        private Sunny.UI.UIIntegerUpDown iudAgeYear;
        private Sunny.UI.UIIntegerUpDown iupAgeMonth;
        private Sunny.UI.UIIntegerUpDown iudFFCS;
        private Sunny.UI.UIIntegerUpDown iudFS;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIComboBox cbDoctorName;
        private Sunny.UI.UITextBox txtDocDepartment;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox txtRemark;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UIComboBox cbJLFS;
        private Sunny.UI.UIComboBox cbDurg;
        private Sunny.UI.UIDoubleUpDown dudJL;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UIListBox lbCheckResult;
        private Sunny.UI.UIDataGridView dgvDurgList;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UITextBox txtXDFMC;
        private Sunny.UI.UIDataGridViewFooter dgvFooter;
        private Sunny.UI.UIContextMenuStrip cmsDurg;
        private ToolStripMenuItem removeDurg;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ParName;
        private DataGridViewTextBoxColumn ParticlesCodeHIS;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn DoseHerb;
        private DataGridViewTextBoxColumn Equivalent;
        private DataGridViewTextBoxColumn Dose;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn TotalPrice;
        private DataGridViewTextBoxColumn ParCode;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnSavePre;
        private Sunny.UI.UISymbolButton btnSaveXDF;
    }
}