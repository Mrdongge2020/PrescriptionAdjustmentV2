namespace AdjustmentSysUI.Forms.DrugForms
{
    partial class FrmDurgDensityCoefficientSet
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
            cbCJ = new Sunny.UI.UIComboBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiDoubleUpDown1 = new Sunny.UI.UIDoubleUpDown();
            btnCJXG = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            txtName = new Sunny.UI.UITextBox();
            btnQuery = new Sunny.UI.UIButton();
            btnReset = new Sunny.UI.UIButton();
            dgvList = new Sunny.UI.UIDataGridView();
            CheckCol = new DataGridViewCheckBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            ParName = new DataGridViewTextBoxColumn();
            Density = new DataGridViewTextBoxColumn();
            DensityCoefficient = new DataGridViewTextBoxColumn();
            OpterCol = new DataGridViewButtonColumn();
            cbSelectAll = new Sunny.UI.UICheckBox();
            uiLabel4 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // cbCJ
            // 
            cbCJ.DataSource = null;
            cbCJ.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbCJ.FillColor = Color.White;
            cbCJ.Font = new Font("微软雅黑", 10.5F);
            cbCJ.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbCJ.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbCJ.Location = new Point(102, 48);
            cbCJ.Margin = new Padding(4, 5, 4, 5);
            cbCJ.MinimumSize = new Size(63, 0);
            cbCJ.Name = "cbCJ";
            cbCJ.Padding = new Padding(0, 0, 30, 2);
            cbCJ.Size = new Size(249, 29);
            cbCJ.SymbolSize = 24;
            cbCJ.TabIndex = 48;
            cbCJ.TextAlignment = ContentAlignment.MiddleLeft;
            cbCJ.Watermark = "请选择颗粒厂家";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 10.5F);
            uiLabel1.ForeColor = Color.Black;
            uiLabel1.Location = new Point(19, 48);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(83, 29);
            uiLabel1.TabIndex = 47;
            uiLabel1.Text = "颗粒厂家：";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(438, 51);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(94, 23);
            uiLabel2.TabIndex = 49;
            uiLabel2.Text = "系数调整至";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiDoubleUpDown1
            // 
            uiDoubleUpDown1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDoubleUpDown1.Location = new Point(543, 48);
            uiDoubleUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiDoubleUpDown1.MinimumSize = new Size(100, 0);
            uiDoubleUpDown1.Name = "uiDoubleUpDown1";
            uiDoubleUpDown1.ShowText = false;
            uiDoubleUpDown1.Size = new Size(116, 29);
            uiDoubleUpDown1.TabIndex = 50;
            uiDoubleUpDown1.Text = "uiDoubleUpDown1";
            uiDoubleUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnCJXG
            // 
            btnCJXG.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCJXG.Location = new Point(695, 45);
            btnCJXG.MinimumSize = new Size(1, 1);
            btnCJXG.Name = "btnCJXG";
            btnCJXG.Size = new Size(100, 35);
            btnCJXG.TabIndex = 51;
            btnCJXG.Text = "批量修改";
            btnCJXG.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 10.5F);
            uiLabel3.ForeColor = Color.Black;
            uiLabel3.Location = new Point(19, 101);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(83, 29);
            uiLabel3.TabIndex = 52;
            uiLabel3.Text = "颗粒名称：";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(104, 101);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(247, 29);
            txtName.TabIndex = 53;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "";
            // 
            // btnQuery
            // 
            btnQuery.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Location = new Point(438, 98);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(100, 35);
            btnQuery.TabIndex = 54;
            btnQuery.Text = "查 找";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btnReset
            // 
            btnReset.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(559, 98);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 35);
            btnReset.TabIndex = 55;
            btnReset.Text = "刷 新";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
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
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { CheckCol, ID, Code, ParName, Density, DensityCoefficient, OpterCol });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle4;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(8, 169);
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
            dgvList.Size = new Size(822, 429);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 56;
            // 
            // CheckCol
            // 
            CheckCol.HeaderText = "选择";
            CheckCol.Name = "CheckCol";
            CheckCol.Width = 137;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "id";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.SortMode = DataGridViewColumnSortMode.NotSortable;
            ID.Visible = false;
            ID.Width = 30;
            // 
            // Code
            // 
            Code.DataPropertyName = "Code";
            Code.HeaderText = "药品编号";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.SortMode = DataGridViewColumnSortMode.NotSortable;
            Code.Width = 136;
            // 
            // ParName
            // 
            ParName.DataPropertyName = "ParName";
            ParName.HeaderText = "药品名称";
            ParName.Name = "ParName";
            ParName.ReadOnly = true;
            ParName.SortMode = DataGridViewColumnSortMode.NotSortable;
            ParName.Width = 137;
            // 
            // Density
            // 
            Density.DataPropertyName = "Density";
            Density.HeaderText = "密度";
            Density.Name = "Density";
            Density.ReadOnly = true;
            Density.SortMode = DataGridViewColumnSortMode.NotSortable;
            Density.Width = 136;
            // 
            // DensityCoefficient
            // 
            DensityCoefficient.DataPropertyName = "DensityCoefficient";
            DensityCoefficient.HeaderText = "密度系数";
            DensityCoefficient.Name = "DensityCoefficient";
            DensityCoefficient.SortMode = DataGridViewColumnSortMode.NotSortable;
            DensityCoefficient.Width = 137;
            // 
            // OpterCol
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "修改";
            OpterCol.DefaultCellStyle = dataGridViewCellStyle3;
            OpterCol.HeaderText = "操作";
            OpterCol.Name = "OpterCol";
            OpterCol.Width = 136;
            // 
            // cbSelectAll
            // 
            cbSelectAll.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbSelectAll.ForeColor = Color.FromArgb(48, 48, 48);
            cbSelectAll.Location = new Point(19, 138);
            cbSelectAll.MinimumSize = new Size(1, 1);
            cbSelectAll.Name = "cbSelectAll";
            cbSelectAll.Size = new Size(150, 29);
            cbSelectAll.TabIndex = 57;
            cbSelectAll.Text = "是否全选";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 10.5F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(132, 138);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(511, 29);
            uiLabel4.TabIndex = 58;
            uiLabel4.Text = "根据厂家批量修改时，未勾选中的数据将不会被修改，切记！";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmDurgDensityCoefficientSet
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(835, 624);
            Controls.Add(uiLabel4);
            Controls.Add(cbSelectAll);
            Controls.Add(dgvList);
            Controls.Add(btnReset);
            Controls.Add(btnQuery);
            Controls.Add(txtName);
            Controls.Add(uiLabel3);
            Controls.Add(btnCJXG);
            Controls.Add(uiDoubleUpDown1);
            Controls.Add(uiLabel2);
            Controls.Add(cbCJ);
            Controls.Add(uiLabel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDurgDensityCoefficientSet";
            Text = "药品密度系数调整";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmDurgDensityCoefficientSet_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox cbCJ;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIDoubleUpDown uiDoubleUpDown1;
        private Sunny.UI.UIButton btnCJXG;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UIButton btnQuery;
        private Sunny.UI.UIButton btnReset;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UICheckBox cbSelectAll;
        private Sunny.UI.UILabel uiLabel4;
        private DataGridViewCheckBoxColumn CheckCol;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn ParName;
        private DataGridViewTextBoxColumn Density;
        private DataGridViewTextBoxColumn DensityCoefficient;
        private DataGridViewButtonColumn OpterCol;
    }
}