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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
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
            cbRuler = new Sunny.UI.UICheckBox();
            btnLoadErroeData = new Sunny.UI.UISymbolButton();
            btnCheckData = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle14.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle14.ForeColor = Color.White;
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { Code, ParName, FullName, NameSimplifiedPinyin, NameFullPinyin, ManufacturerId, ManufacturerName, HisCode, HisName, Density, Equivalent, DoseLimit, PackageNumber, WholesalePrice, RetailPrice, ListingNumber, Remark });
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = SystemColors.Window;
            dataGridViewCellStyle16.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle16.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle16;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 92);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle17.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle17.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle17.SelectionForeColor = Color.White;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.BackColor = Color.White;
            dataGridViewCellStyle18.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle18;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(1297, 563);
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
            dataGridViewCellStyle15.BackColor = Color.Red;
            ParName.DefaultCellStyle = dataGridViewCellStyle15;
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
            btnOpenExcel.Location = new Point(22, 51);
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
            btnConfimImport.Location = new Point(797, 51);
            btnConfimImport.MinimumSize = new Size(1, 1);
            btnConfimImport.Name = "btnConfimImport";
            btnConfimImport.Size = new Size(129, 35);
            btnConfimImport.Symbol = 561595;
            btnConfimImport.TabIndex = 3;
            btnConfimImport.Text = "确认导入";
            btnConfimImport.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Click += btnConfimImport_Click;
            // 
            // cbRuler
            // 
            cbRuler.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbRuler.ForeColor = Color.FromArgb(48, 48, 48);
            cbRuler.Location = new Point(956, 57);
            cbRuler.MinimumSize = new Size(1, 1);
            cbRuler.Name = "cbRuler";
            cbRuler.Size = new Size(150, 29);
            cbRuler.TabIndex = 4;
            cbRuler.Text = "查看导入规则";
            // 
            // btnLoadErroeData
            // 
            btnLoadErroeData.Enabled = false;
            btnLoadErroeData.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnLoadErroeData.Location = new Point(1114, 51);
            btnLoadErroeData.MinimumSize = new Size(1, 1);
            btnLoadErroeData.Name = "btnLoadErroeData";
            btnLoadErroeData.Size = new Size(153, 35);
            btnLoadErroeData.Symbol = 57490;
            btnLoadErroeData.TabIndex = 5;
            btnLoadErroeData.Text = "导出异常数据";
            btnLoadErroeData.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btnCheckData
            // 
            btnCheckData.Enabled = false;
            btnCheckData.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCheckData.Location = new Point(234, 51);
            btnCheckData.MinimumSize = new Size(1, 1);
            btnCheckData.Name = "btnCheckData";
            btnCheckData.Size = new Size(129, 35);
            btnCheckData.Symbol = 90;
            btnCheckData.TabIndex = 6;
            btnCheckData.Text = "异常校验";
            btnCheckData.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCheckData.Click += btnCheckData_Click;
            // 
            // FrmDurgExcelInfoShow
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1303, 688);
            Controls.Add(btnCheckData);
            Controls.Add(btnLoadErroeData);
            Controls.Add(cbRuler);
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
        private Sunny.UI.UICheckBox cbRuler;
        private Sunny.UI.UISymbolButton btnLoadErroeData;
        private Sunny.UI.UISymbolButton btnCheckData;
    }
}