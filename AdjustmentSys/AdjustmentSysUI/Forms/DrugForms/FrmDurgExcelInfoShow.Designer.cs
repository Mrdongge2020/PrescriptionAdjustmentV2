namespace AdjustmentSysUI.Forms.DrugForms
{
    partial class FrmDurgExcelInfoShow
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
            dgvList = new Sunny.UI.UIDataGridView();
            Code = new DataGridViewTextBoxColumn();
            ParName = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            NameSimplifiedPinyin = new DataGridViewTextBoxColumn();
            NameFullPinyin = new DataGridViewTextBoxColumn();
            ManufacturerId = new DataGridViewTextBoxColumn();
            ManufacturerName = new DataGridViewTextBoxColumn();
            HisCode = new DataGridViewTextBoxColumn();
            HisName = new DataGridViewTextBoxColumn();
            Density = new DataGridViewTextBoxColumn();
            Equivalent = new DataGridViewTextBoxColumn();
            DoseLimit = new DataGridViewTextBoxColumn();
            PackageNumber = new DataGridViewTextBoxColumn();
            WholesalePrice = new DataGridViewTextBoxColumn();
            RetailPrice = new DataGridViewTextBoxColumn();
            ListingNumber = new DataGridViewTextBoxColumn();
            Remark = new DataGridViewTextBoxColumn();
            btnOpenExcel = new Sunny.UI.UISymbolButton();
            btnConfimImport = new Sunny.UI.UISymbolButton();
            btnLoadErroeData = new Sunny.UI.UISymbolButton();
            btnCheckData = new Sunny.UI.UISymbolButton();
            lblCheckResult = new Sunny.UI.UILabel();
            lblRuler = new Sunny.UI.UILinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            dgvList.Columns.AddRange(new DataGridViewColumn[] { Code, ParName, FullName, NameSimplifiedPinyin, NameFullPinyin, ManufacturerId, ManufacturerName, HisCode, HisName, Density, Equivalent, DoseLimit, PackageNumber, WholesalePrice, RetailPrice, ListingNumber, Remark });
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
            dgvList.Location = new Point(3, 92);
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
            dgvList.Size = new Size(1297, 593);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 0;
            // 
            // Code
            // 
            Code.DataPropertyName = "Code";
            Code.HeaderText = "药品编码";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            // FullName
            // 
            FullName.DataPropertyName = "FullName";
            FullName.HeaderText = "药品全称";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            FullName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // NameSimplifiedPinyin
            // 
            NameSimplifiedPinyin.DataPropertyName = "NameSimplifiedPinyin";
            NameSimplifiedPinyin.HeaderText = "简称首拼";
            NameSimplifiedPinyin.Name = "NameSimplifiedPinyin";
            NameSimplifiedPinyin.ReadOnly = true;
            NameSimplifiedPinyin.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // NameFullPinyin
            // 
            NameFullPinyin.DataPropertyName = "NameFullPinyin";
            NameFullPinyin.HeaderText = "简称全拼";
            NameFullPinyin.Name = "NameFullPinyin";
            NameFullPinyin.ReadOnly = true;
            NameFullPinyin.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            // HisCode
            // 
            HisCode.DataPropertyName = "HisCode";
            HisCode.HeaderText = "HIS编码";
            HisCode.Name = "HisCode";
            HisCode.ReadOnly = true;
            HisCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // HisName
            // 
            HisName.DataPropertyName = "HisName";
            HisName.HeaderText = "HIS名称";
            HisName.Name = "HisName";
            HisName.ReadOnly = true;
            HisName.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            // DoseLimit
            // 
            DoseLimit.DataPropertyName = "DoseLimit";
            DoseLimit.HeaderText = "剂量上限";
            DoseLimit.Name = "DoseLimit";
            DoseLimit.ReadOnly = true;
            DoseLimit.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // PackageNumber
            // 
            PackageNumber.DataPropertyName = "PackageNumber";
            PackageNumber.HeaderText = "包装码";
            PackageNumber.Name = "PackageNumber";
            PackageNumber.ReadOnly = true;
            PackageNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // WholesalePrice
            // 
            WholesalePrice.DataPropertyName = "WholesalePrice";
            WholesalePrice.HeaderText = "供货价";
            WholesalePrice.Name = "WholesalePrice";
            WholesalePrice.ReadOnly = true;
            WholesalePrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // RetailPrice
            // 
            RetailPrice.DataPropertyName = "RetailPrice";
            RetailPrice.HeaderText = "零售价";
            RetailPrice.Name = "RetailPrice";
            RetailPrice.ReadOnly = true;
            RetailPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ListingNumber
            // 
            ListingNumber.DataPropertyName = "ListingNumber";
            ListingNumber.HeaderText = "上市编号";
            ListingNumber.Name = "ListingNumber";
            ListingNumber.ReadOnly = true;
            ListingNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Remark
            // 
            Remark.DataPropertyName = "Remark";
            Remark.HeaderText = "备注";
            Remark.Name = "Remark";
            Remark.ReadOnly = true;
            Remark.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // btnOpenExcel
            // 
            btnOpenExcel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpenExcel.Location = new Point(3, 51);
            btnOpenExcel.MinimumSize = new Size(1, 1);
            btnOpenExcel.Name = "btnOpenExcel";
            btnOpenExcel.Size = new Size(153, 35);
            btnOpenExcel.Symbol = 61717;
            btnOpenExcel.TabIndex = 1;
            btnOpenExcel.Text = "打开Excel文件";
            btnOpenExcel.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpenExcel.TipsText = "打开一个excel并在窗口展示数据";
            btnOpenExcel.Click += btnOpenExcel_Click;
            // 
            // btnConfimImport
            // 
            btnConfimImport.Enabled = false;
            btnConfimImport.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Location = new Point(1031, 51);
            btnConfimImport.MinimumSize = new Size(1, 1);
            btnConfimImport.Name = "btnConfimImport";
            btnConfimImport.Size = new Size(129, 35);
            btnConfimImport.Symbol = 561595;
            btnConfimImport.TabIndex = 3;
            btnConfimImport.Text = "确认导入";
            btnConfimImport.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Click += btnConfimImport_Click;
            // 
            // btnLoadErroeData
            // 
            btnLoadErroeData.Enabled = false;
            btnLoadErroeData.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnLoadErroeData.Location = new Point(350, 51);
            btnLoadErroeData.MinimumSize = new Size(1, 1);
            btnLoadErroeData.Name = "btnLoadErroeData";
            btnLoadErroeData.Size = new Size(153, 35);
            btnLoadErroeData.Symbol = 57490;
            btnLoadErroeData.TabIndex = 5;
            btnLoadErroeData.Text = "导出异常数据";
            btnLoadErroeData.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnLoadErroeData.Click += btnLoadErroeData_Click;
            // 
            // btnCheckData
            // 
            btnCheckData.Enabled = false;
            btnCheckData.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCheckData.Location = new Point(201, 51);
            btnCheckData.MinimumSize = new Size(1, 1);
            btnCheckData.Name = "btnCheckData";
            btnCheckData.Size = new Size(129, 35);
            btnCheckData.Symbol = 90;
            btnCheckData.TabIndex = 6;
            btnCheckData.Text = "异常校验";
            btnCheckData.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCheckData.Click += btnCheckData_Click;
            // 
            // lblCheckResult
            // 
            lblCheckResult.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCheckResult.ForeColor = Color.Red;
            lblCheckResult.Location = new Point(539, 61);
            lblCheckResult.Name = "lblCheckResult";
            lblCheckResult.Size = new Size(486, 23);
            lblCheckResult.TabIndex = 94;
            lblCheckResult.Text = "校验结果：";
            lblCheckResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRuler
            // 
            lblRuler.ActiveLinkColor = Color.FromArgb(80, 160, 255);
            lblRuler.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblRuler.ForeColor = Color.Blue;
            lblRuler.LinkBehavior = LinkBehavior.AlwaysUnderline;
            lblRuler.LinkColor = Color.FromArgb(0, 0, 192);
            lblRuler.Location = new Point(1196, 63);
            lblRuler.Name = "lblRuler";
            lblRuler.Size = new Size(104, 23);
            lblRuler.TabIndex = 95;
            lblRuler.TabStop = true;
            lblRuler.Text = "查看导入规则";
            lblRuler.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            // 
            // FrmDurgExcelInfoShow
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1303, 688);
            Controls.Add(lblRuler);
            Controls.Add(lblCheckResult);
            Controls.Add(btnCheckData);
            Controls.Add(btnLoadErroeData);
            Controls.Add(btnConfimImport);
            Controls.Add(btnOpenExcel);
            Controls.Add(dgvList);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDurgExcelInfoShow";
            Text = "药品导入";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnOpenExcel;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn ParName;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn NameSimplifiedPinyin;
        private DataGridViewTextBoxColumn NameFullPinyin;
        private DataGridViewTextBoxColumn ManufacturerId;
        private DataGridViewTextBoxColumn ManufacturerName;
        private DataGridViewTextBoxColumn HisCode;
        private DataGridViewTextBoxColumn HisName;
        private DataGridViewTextBoxColumn Density;
        private DataGridViewTextBoxColumn Equivalent;
        private DataGridViewTextBoxColumn DoseLimit;
        private DataGridViewTextBoxColumn PackageNumber;
        private DataGridViewTextBoxColumn WholesalePrice;
        private DataGridViewTextBoxColumn RetailPrice;
        private DataGridViewTextBoxColumn ListingNumber;
        private DataGridViewTextBoxColumn Remark;
        private Sunny.UI.UISymbolButton btnConfimImport;
        private Sunny.UI.UISymbolButton btnLoadErroeData;
        private Sunny.UI.UISymbolButton btnCheckData;
        private Sunny.UI.UILabel lblCheckResult;
        private Sunny.UI.UILinkLabel lblRuler;
    }
}