namespace AdjustmentSysUI.Forms.DrugForms
{
    partial class FrmParticleDataMate
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParticleDataMate));
            btnConfimImport = new Sunny.UI.UISymbolButton();
            btnOpenExcel = new Sunny.UI.UISymbolButton();
            dgvList = new Sunny.UI.UIDataGridView();
            ParName = new DataGridViewTextBoxColumn();
            HisCode = new DataGridViewTextBoxColumn();
            ManufacturerId = new DataGridViewTextBoxColumn();
            ManufacturerName = new DataGridViewTextBoxColumn();
            Density = new DataGridViewTextBoxColumn();
            Equivalent = new DataGridViewTextBoxColumn();
            PackageNumber = new DataGridViewTextBoxColumn();
            uiCheckBoxGroup1 = new Sunny.UI.UICheckBoxGroup();
            cbBZM = new Sunny.UI.UICheckBox();
            cbDL = new Sunny.UI.UICheckBox();
            cbMD = new Sunny.UI.UICheckBox();
            cbHIS = new Sunny.UI.UICheckBox();
            cbCJ = new Sunny.UI.UICheckBox();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiLabel2 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            uiCheckBoxGroup1.SuspendLayout();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConfimImport
            // 
            btnConfimImport.Enabled = false;
            btnConfimImport.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Location = new Point(1121, 49);
            btnConfimImport.MinimumSize = new Size(1, 1);
            btnConfimImport.Name = "btnConfimImport";
            btnConfimImport.Size = new Size(129, 35);
            btnConfimImport.Symbol = 561595;
            btnConfimImport.TabIndex = 97;
            btnConfimImport.Text = "确认匹配";
            btnConfimImport.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Click += btnConfimImport_Click;
            // 
            // btnOpenExcel
            // 
            btnOpenExcel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpenExcel.Location = new Point(26, 49);
            btnOpenExcel.MinimumSize = new Size(1, 1);
            btnOpenExcel.Name = "btnOpenExcel";
            btnOpenExcel.Size = new Size(153, 35);
            btnOpenExcel.Symbol = 61717;
            btnOpenExcel.TabIndex = 96;
            btnOpenExcel.Text = "打开Excel文件";
            btnOpenExcel.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpenExcel.TipsText = "打开一个excel并在窗口展示数据";
            btnOpenExcel.Click += btnOpenExcel_Click;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { ParName, HisCode, ManufacturerId, ManufacturerName, Density, Equivalent, PackageNumber });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle4;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 90);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(881, 563);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 95;
            // 
            // ParName
            // 
            ParName.DataPropertyName = "ParName";
            dataGridViewCellStyle3.BackColor = Color.Red;
            ParName.DefaultCellStyle = dataGridViewCellStyle3;
            ParName.HeaderText = "药品简称";
            ParName.Name = "ParName";
            ParName.ReadOnly = true;
            ParName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // HisCode
            // 
            HisCode.DataPropertyName = "HisCode";
            HisCode.HeaderText = "HIS编码";
            HisCode.Name = "HisCode";
            HisCode.ReadOnly = true;
            HisCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ManufacturerId
            // 
            ManufacturerId.DataPropertyName = "ManufacturerId";
            ManufacturerId.HeaderText = "厂家id";
            ManufacturerId.Name = "ManufacturerId";
            ManufacturerId.ReadOnly = true;
            ManufacturerId.SortMode = DataGridViewColumnSortMode.NotSortable;
            ManufacturerId.Visible = false;
            // 
            // ManufacturerName
            // 
            ManufacturerName.DataPropertyName = "ManufacturerName";
            ManufacturerName.HeaderText = "厂家名称";
            ManufacturerName.Name = "ManufacturerName";
            ManufacturerName.ReadOnly = true;
            ManufacturerName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Density
            // 
            Density.DataPropertyName = "Density";
            Density.HeaderText = "密度";
            Density.Name = "Density";
            Density.ReadOnly = true;
            Density.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Equivalent
            // 
            Equivalent.DataPropertyName = "Equivalent";
            Equivalent.HeaderText = "当量";
            Equivalent.Name = "Equivalent";
            Equivalent.ReadOnly = true;
            Equivalent.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // PackageNumber
            // 
            PackageNumber.DataPropertyName = "PackageNumber";
            PackageNumber.HeaderText = "包装码";
            PackageNumber.Name = "PackageNumber";
            PackageNumber.ReadOnly = true;
            PackageNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // uiCheckBoxGroup1
            // 
            uiCheckBoxGroup1.Controls.Add(cbBZM);
            uiCheckBoxGroup1.Controls.Add(cbDL);
            uiCheckBoxGroup1.Controls.Add(cbMD);
            uiCheckBoxGroup1.Controls.Add(cbHIS);
            uiCheckBoxGroup1.Controls.Add(cbCJ);
            uiCheckBoxGroup1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiCheckBoxGroup1.HoverColor = Color.FromArgb(220, 236, 255);
            uiCheckBoxGroup1.Location = new Point(891, 92);
            uiCheckBoxGroup1.Margin = new Padding(4, 5, 4, 5);
            uiCheckBoxGroup1.MinimumSize = new Size(1, 1);
            uiCheckBoxGroup1.Name = "uiCheckBoxGroup1";
            uiCheckBoxGroup1.Padding = new Padding(0, 32, 0, 0);
            uiCheckBoxGroup1.SelectedIndexes = (List<int>)resources.GetObject("uiCheckBoxGroup1.SelectedIndexes");
            uiCheckBoxGroup1.Size = new Size(362, 185);
            uiCheckBoxGroup1.TabIndex = 100;
            uiCheckBoxGroup1.Text = "匹配字段";
            uiCheckBoxGroup1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // cbBZM
            // 
            cbBZM.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbBZM.ForeColor = Color.FromArgb(48, 48, 48);
            cbBZM.Location = new Point(20, 134);
            cbBZM.MinimumSize = new Size(1, 1);
            cbBZM.Name = "cbBZM";
            cbBZM.Size = new Size(150, 29);
            cbBZM.TabIndex = 6;
            cbBZM.Text = "包装码";
            // 
            // cbDL
            // 
            cbDL.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbDL.ForeColor = Color.FromArgb(48, 48, 48);
            cbDL.Location = new Point(176, 86);
            cbDL.MinimumSize = new Size(1, 1);
            cbDL.Name = "cbDL";
            cbDL.Size = new Size(150, 29);
            cbDL.TabIndex = 4;
            cbDL.Text = "当量";
            // 
            // cbMD
            // 
            cbMD.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbMD.ForeColor = Color.FromArgb(48, 48, 48);
            cbMD.Location = new Point(20, 86);
            cbMD.MinimumSize = new Size(1, 1);
            cbMD.Name = "cbMD";
            cbMD.Size = new Size(150, 29);
            cbMD.TabIndex = 3;
            cbMD.Text = "密度";
            // 
            // cbHIS
            // 
            cbHIS.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbHIS.ForeColor = Color.FromArgb(48, 48, 48);
            cbHIS.Location = new Point(20, 39);
            cbHIS.MinimumSize = new Size(1, 1);
            cbHIS.Name = "cbHIS";
            cbHIS.Size = new Size(150, 29);
            cbHIS.TabIndex = 2;
            cbHIS.Text = "HIS编码";
            // 
            // cbCJ
            // 
            cbCJ.Font = new Font("微软雅黑", 12F);
            cbCJ.ForeColor = Color.FromArgb(48, 48, 48);
            cbCJ.Location = new Point(176, 39);
            cbCJ.MinimumSize = new Size(1, 1);
            cbCJ.Name = "cbCJ";
            cbCJ.Size = new Size(113, 29);
            cbCJ.TabIndex = 1;
            cbCJ.Text = "厂家";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(uiLabel2);
            uiGroupBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new Point(891, 305);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(362, 348);
            uiGroupBox1.TabIndex = 101;
            uiGroupBox1.Text = "注意";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(10, 32);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(349, 101);
            uiLabel2.TabIndex = 1;
            uiLabel2.Text = "1.导入文件字段名称要与表格一致。\r\n2.导入文件文件后，选择匹配字段，再点击确认匹配。\r\n3.密度，当量两列不能填写非数字数据。\r\n";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmParticleDataMate
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1259, 658);
            Controls.Add(uiGroupBox1);
            Controls.Add(uiCheckBoxGroup1);
            Controls.Add(btnConfimImport);
            Controls.Add(btnOpenExcel);
            Controls.Add(dgvList);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmParticleDataMate";
            Text = "匹配颗粒数据";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            uiCheckBoxGroup1.ResumeLayout(false);
            uiGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UICheckBox cbRuler;
        private Sunny.UI.UISymbolButton btnConfimImport;
        private Sunny.UI.UISymbolButton btnOpenExcel;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UIComboTreeView ctvMateType;
        private Sunny.UI.UICheckBoxGroup uiCheckBoxGroup1;
        private Sunny.UI.UICheckBox cbMD;
        private Sunny.UI.UICheckBox uiCheckBox5;
        private Sunny.UI.UICheckBox uiCheckBox6;
        private Sunny.UI.UICheckBox cbBZM;
        private Sunny.UI.UICheckBox cbCJ;
        private Sunny.UI.UICheckBox cbHIS;
        private Sunny.UI.UICheckBox cbDL;
        private DataGridViewTextBoxColumn ParName;
        private DataGridViewTextBoxColumn HisCode;
        private DataGridViewTextBoxColumn ManufacturerId;
        private DataGridViewTextBoxColumn ManufacturerName;
        private DataGridViewTextBoxColumn Density;
        private DataGridViewTextBoxColumn Equivalent;
        private DataGridViewTextBoxColumn PackageNumber;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel2;
    }
}