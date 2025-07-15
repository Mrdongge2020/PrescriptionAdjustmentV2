namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmMedicineCabientLog
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
            uiPage = new Sunny.UI.UIPagination();
            dgvList = new Sunny.UI.UIDataGridView();
            label3 = new Label();
            dateTimeStart = new Sunny.UI.UIDatePicker();
            dateTimeEnd = new Sunny.UI.UIDatePicker();
            cbType = new Sunny.UI.UIComboBox();
            uiLabel4 = new Sunny.UI.UILabel();
            lblNum1 = new Sunny.UI.UILabel();
            lblNum2 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            lblNum3 = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
            uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
            btnQuery = new Sunny.UI.UISymbolButton();
            txtName = new Sunny.UI.UITextBox();
            btnReset = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.FillColor = Color.White;
            uiPage.FillColor2 = Color.White;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(10, 521);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.Radius = 10;
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1000, 35);
            uiPage.Style = Sunny.UI.UIStyle.Custom;
            uiPage.TabIndex = 118;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(10, 122);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersWidth = 80;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.ShowEditingIcon = false;
            dgvList.Size = new Size(1000, 352);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 117;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 10.5F);
            label3.Location = new Point(548, 54);
            label3.Name = "label3";
            label3.Size = new Size(23, 20);
            label3.TabIndex = 115;
            label3.Text = "至";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimeStart
            // 
            dateTimeStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeStart.FillColor = Color.White;
            dateTimeStart.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeStart.Location = new Point(387, 50);
            dateTimeStart.Margin = new Padding(4, 5, 4, 5);
            dateTimeStart.MaxLength = 10;
            dateTimeStart.MinimumSize = new Size(63, 0);
            dateTimeStart.Name = "dateTimeStart";
            dateTimeStart.Padding = new Padding(0, 0, 30, 2);
            dateTimeStart.ShowToday = true;
            dateTimeStart.Size = new Size(150, 29);
            dateTimeStart.SymbolDropDown = 61555;
            dateTimeStart.SymbolNormal = 61555;
            dateTimeStart.SymbolSize = 24;
            dateTimeStart.TabIndex = 114;
            dateTimeStart.Text = "2024-07-01";
            dateTimeStart.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeStart.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeStart.Watermark = "";
            // 
            // dateTimeEnd
            // 
            dateTimeEnd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeEnd.FillColor = Color.White;
            dateTimeEnd.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeEnd.Location = new Point(578, 50);
            dateTimeEnd.Margin = new Padding(4, 5, 4, 5);
            dateTimeEnd.MaxLength = 10;
            dateTimeEnd.MinimumSize = new Size(63, 0);
            dateTimeEnd.Name = "dateTimeEnd";
            dateTimeEnd.Padding = new Padding(0, 0, 30, 2);
            dateTimeEnd.ShowToday = true;
            dateTimeEnd.Size = new Size(150, 29);
            dateTimeEnd.SymbolDropDown = 61555;
            dateTimeEnd.SymbolNormal = 61555;
            dateTimeEnd.SymbolSize = 24;
            dateTimeEnd.TabIndex = 113;
            dateTimeEnd.Text = "2024-07-01";
            dateTimeEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeEnd.Watermark = "";
            // 
            // cbType
            // 
            cbType.DataSource = null;
            cbType.FillColor = Color.White;
            cbType.FilterIgnoreCase = true;
            cbType.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbType.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbType.Items.AddRange(new object[] { "全部", "新增药品", "编辑药品", "删除药品" });
            cbType.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbType.Location = new Point(10, 50);
            cbType.Margin = new Padding(4, 5, 4, 5);
            cbType.MinimumSize = new Size(63, 0);
            cbType.Name = "cbType";
            cbType.Padding = new Padding(0, 0, 30, 2);
            cbType.ShowClearButton = true;
            cbType.ShowFilter = true;
            cbType.Size = new Size(178, 29);
            cbType.SymbolSize = 24;
            cbType.TabIndex = 109;
            cbType.TextAlignment = ContentAlignment.MiddleLeft;
            cbType.TrimFilter = true;
            cbType.Watermark = "请选择日志类型";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 10.5F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(11, 90);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(96, 29);
            uiLabel4.TabIndex = 120;
            uiLabel4.Text = "使用量 :";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNum1
            // 
            lblNum1.Font = new Font("微软雅黑", 10.5F);
            lblNum1.ForeColor = Color.FromArgb(48, 48, 48);
            lblNum1.Location = new Point(113, 90);
            lblNum1.Name = "lblNum1";
            lblNum1.Size = new Size(54, 29);
            lblNum1.TabIndex = 121;
            lblNum1.Text = "0";
            lblNum1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNum2
            // 
            lblNum2.Font = new Font("微软雅黑", 10.5F);
            lblNum2.ForeColor = Color.FromArgb(48, 48, 48);
            lblNum2.Location = new Point(272, 90);
            lblNum2.Name = "lblNum2";
            lblNum2.Size = new Size(55, 29);
            lblNum2.TabIndex = 123;
            lblNum2.Text = "0";
            lblNum2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("微软雅黑", 10.5F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(176, 90);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(90, 29);
            uiLabel6.TabIndex = 122;
            uiLabel6.Text = "上药量 :";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNum3
            // 
            lblNum3.Font = new Font("微软雅黑", 10.5F);
            lblNum3.ForeColor = Color.FromArgb(48, 48, 48);
            lblNum3.Location = new Point(425, 90);
            lblNum3.Name = "lblNum3";
            lblNum3.Size = new Size(61, 29);
            lblNum3.TabIndex = 125;
            lblNum3.Text = "0";
            lblNum3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("微软雅黑", 10.5F);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new Point(338, 90);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(81, 29);
            uiLabel8.TabIndex = 124;
            uiLabel8.Text = "调整量 :";
            uiLabel8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiDataGridViewFooter1
            // 
            uiDataGridViewFooter1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiDataGridViewFooter1.DataGridView = null;
            uiDataGridViewFooter1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDataGridViewFooter1.Location = new Point(10, 486);
            uiDataGridViewFooter1.MinimumSize = new Size(1, 1);
            uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
            uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            uiDataGridViewFooter1.Size = new Size(1000, 29);
            uiDataGridViewFooter1.TabIndex = 126;
            uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
            // 
            // btnQuery
            // 
            btnQuery.Cursor = Cursors.Hand;
            btnQuery.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Location = new Point(754, 47);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Radius = 10;
            btnQuery.Size = new Size(90, 35);
            btnQuery.Symbol = 61442;
            btnQuery.TabIndex = 127;
            btnQuery.Text = "查 询";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Click += btnQuery_Click;
            // 
            // txtName
            // 
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(196, 49);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(183, 30);
            txtName.TabIndex = 128;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.TouchPressClick = true;
            txtName.Watermark = "请输入药品名称";
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(872, 47);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Radius = 10;
            btnReset.Size = new Size(90, 35);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 129;
            btnReset.Text = "重 置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // FrmMedicineCabientLog
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1018, 565);
            Controls.Add(btnReset);
            Controls.Add(txtName);
            Controls.Add(btnQuery);
            Controls.Add(uiDataGridViewFooter1);
            Controls.Add(lblNum3);
            Controls.Add(uiLabel8);
            Controls.Add(lblNum2);
            Controls.Add(uiLabel6);
            Controls.Add(lblNum1);
            Controls.Add(uiLabel4);
            Controls.Add(uiPage);
            Controls.Add(dgvList);
            Controls.Add(label3);
            Controls.Add(dateTimeStart);
            Controls.Add(dateTimeEnd);
            Controls.Add(cbType);
            Name = "FrmMedicineCabientLog";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Style = Sunny.UI.UIStyle.Custom;
            Symbol = 361641;
            Text = "药柜管理>>操作日志";
            TitleFillColor = Color.FromArgb(243, 249, 255);
            TitleForeColor = Color.FromArgb(80, 126, 164);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIDataGridView dgvList;
        private Label label3;
        private Sunny.UI.UIDatePicker dateTimeStart;
        private Sunny.UI.UIDatePicker dateTimeEnd;
        private Sunny.UI.UIComboBox cbType;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel lblNum1;
        private Sunny.UI.UILabel lblNum2;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel lblNum3;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
        private Sunny.UI.UISymbolButton btnQuery;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UISymbolButton btnReset;
    }
}