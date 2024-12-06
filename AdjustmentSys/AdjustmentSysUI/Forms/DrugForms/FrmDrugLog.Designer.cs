namespace AdjustmentSysUI.Forms.DrugForms
{
    partial class FrmDrugLog
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
            cbfp = new Sunny.UI.UIComboBox();
            cbType = new Sunny.UI.UIComboBox();
            uiLabel13 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            label3 = new Label();
            dateTimeStart = new Sunny.UI.UIDatePicker();
            dateTimeEnd = new Sunny.UI.UIDatePicker();
            btnQuery = new Sunny.UI.UIButton();
            dgvList = new Sunny.UI.UIDataGridView();
            uiPage = new Sunny.UI.UIPagination();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // cbfp
            // 
            cbfp.DataSource = null;
            cbfp.FillColor = Color.White;
            cbfp.FilterIgnoreCase = true;
            cbfp.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbfp.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbfp.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbfp.Location = new Point(290, 48);
            cbfp.Margin = new Padding(4, 5, 4, 5);
            cbfp.MinimumSize = new Size(63, 0);
            cbfp.Name = "cbfp";
            cbfp.Padding = new Padding(0, 0, 30, 2);
            cbfp.ShowClearButton = true;
            cbfp.ShowFilter = true;
            cbfp.Size = new Size(163, 29);
            cbfp.SymbolSize = 24;
            cbfp.TabIndex = 97;
            cbfp.TextAlignment = ContentAlignment.MiddleLeft;
            cbfp.TrimFilter = true;
            cbfp.Watermark = "";
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
            cbType.Location = new Point(51, 48);
            cbType.Margin = new Padding(4, 5, 4, 5);
            cbType.MinimumSize = new Size(63, 0);
            cbType.Name = "cbType";
            cbType.Padding = new Padding(0, 0, 30, 2);
            cbType.ShowClearButton = true;
            cbType.ShowFilter = true;
            cbType.Size = new Size(178, 29);
            cbType.SymbolSize = 24;
            cbType.TabIndex = 98;
            cbType.TextAlignment = ContentAlignment.MiddleLeft;
            cbType.TrimFilter = true;
            cbType.Watermark = "";
            // 
            // uiLabel13
            // 
            uiLabel13.Font = new Font("微软雅黑", 10.5F);
            uiLabel13.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel13.Location = new Point(3, 48);
            uiLabel13.Name = "uiLabel13";
            uiLabel13.Size = new Size(47, 29);
            uiLabel13.TabIndex = 99;
            uiLabel13.Text = "类型:";
            uiLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 10.5F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(238, 48);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(47, 29);
            uiLabel1.TabIndex = 100;
            uiLabel1.Text = "药品:";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 10.5F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(475, 48);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(47, 29);
            uiLabel2.TabIndex = 101;
            uiLabel2.Text = "日期:";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 10.5F);
            label3.Location = new Point(690, 52);
            label3.Name = "label3";
            label3.Size = new Size(23, 20);
            label3.TabIndex = 104;
            label3.Text = "至";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimeStart
            // 
            dateTimeStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeStart.FillColor = Color.White;
            dateTimeStart.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeStart.Location = new Point(529, 48);
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
            dateTimeStart.TabIndex = 103;
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
            dateTimeEnd.Location = new Point(720, 48);
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
            dateTimeEnd.TabIndex = 102;
            dateTimeEnd.Text = "2024-07-01";
            dateTimeEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeEnd.Watermark = "";
            // 
            // btnQuery
            // 
            btnQuery.Font = new Font("微软雅黑", 12F);
            btnQuery.Location = new Point(889, 48);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(77, 29);
            btnQuery.TabIndex = 105;
            btnQuery.Text = "查 询";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Click += btnQuery_Click;
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
            dgvList.Location = new Point(3, 85);
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
            dgvList.Size = new Size(1009, 349);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 106;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(7, 444);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(849, 39);
            uiPage.TabIndex = 107;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // FrmDrugLog
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1015, 490);
            Controls.Add(uiPage);
            Controls.Add(dgvList);
            Controls.Add(btnQuery);
            Controls.Add(label3);
            Controls.Add(dateTimeStart);
            Controls.Add(dateTimeEnd);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(uiLabel13);
            Controls.Add(cbType);
            Controls.Add(cbfp);
            Name = "FrmDrugLog";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "药品管理>>操作日志";
            Load += FrmDrugLog_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIComboBox cbfp;
        private Sunny.UI.UIComboBox cbType;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Label label3;
        private Sunny.UI.UIDatePicker dateTimeStart;
        private Sunny.UI.UIDatePicker dateTimeEnd;
        private Sunny.UI.UIButton btnQuery;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UIPagination uiPage;
    }
}