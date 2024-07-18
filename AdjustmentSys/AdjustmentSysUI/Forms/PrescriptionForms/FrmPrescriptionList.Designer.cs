namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmPrescriptionList
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            btnRefc = new Sunny.UI.UISymbolButton();
            btnReset = new Sunny.UI.UISymbolButton();
            cbPreState = new Sunny.UI.UIComboBox();
            uiPage = new Sunny.UI.UIPagination();
            dgvList = new Sunny.UI.UIDataGridView();
            btnAddPre = new Sunny.UI.UISymbolButton();
            btnCopyPre = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            txtPrID = new Sunny.UI.UITextBox();
            txtPatentName = new Sunny.UI.UITextBox();
            cbSource = new Sunny.UI.UIComboBox();
            dtpStart = new Sunny.UI.UIDatePicker();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            dtpEnd = new Sunny.UI.UIDatePicker();
            dgvPreDetail = new Sunny.UI.UIDataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).BeginInit();
            SuspendLayout();
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(459, 134);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 1;
            btnRefc.Size = new Size(70, 30);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 37;
            btnRefc.Text = "刷新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(760, 86);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(72, 33);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 36;
            btnReset.Text = "重置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // cbPreState
            // 
            cbPreState.DataSource = null;
            cbPreState.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbPreState.FillColor = Color.White;
            cbPreState.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbPreState.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbPreState.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbPreState.Location = new Point(390, 90);
            cbPreState.Margin = new Padding(4, 5, 4, 5);
            cbPreState.MinimumSize = new Size(63, 0);
            cbPreState.Name = "cbPreState";
            cbPreState.Padding = new Padding(0, 0, 30, 2);
            cbPreState.Size = new Size(171, 29);
            cbPreState.SymbolSize = 24;
            cbPreState.TabIndex = 35;
            cbPreState.TextAlignment = ContentAlignment.MiddleLeft;
            cbPreState.Watermark = "处方状态";
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(89, 619);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(586, 39);
            uiPage.TabIndex = 34;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // dgvList
            // 
            dataGridViewCellStyle11.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle12.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle12.ForeColor = Color.White;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle13.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle13;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 170);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle14.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle14.SelectionForeColor = Color.White;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle15.BackColor = Color.White;
            dataGridViewCellStyle15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(781, 446);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 33;
            dgvList.CellClick += dgvList_CellClick;
            dgvList.RowPostPaint += dgvList_RowPostPaint;
            // 
            // btnAddPre
            // 
            btnAddPre.Cursor = Cursors.Hand;
            btnAddPre.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddPre.Location = new Point(16, 134);
            btnAddPre.MinimumSize = new Size(1, 1);
            btnAddPre.Name = "btnAddPre";
            btnAddPre.Radius = 1;
            btnAddPre.Size = new Size(100, 30);
            btnAddPre.Symbol = 362211;
            btnAddPre.TabIndex = 32;
            btnAddPre.Text = "录入处方";
            btnAddPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddPre.Click += btnAddPre_Click;
            // 
            // btnCopyPre
            // 
            btnCopyPre.Cursor = Cursors.Hand;
            btnCopyPre.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCopyPre.Location = new Point(138, 134);
            btnCopyPre.MinimumSize = new Size(1, 1);
            btnCopyPre.Name = "btnCopyPre";
            btnCopyPre.Radius = 1;
            btnCopyPre.Size = new Size(100, 30);
            btnCopyPre.Symbol = 361741;
            btnCopyPre.SymbolColor = SystemColors.Window;
            btnCopyPre.TabIndex = 31;
            btnCopyPre.Text = "复制处方";
            btnCopyPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCopyPre.Click += btnCopyPre_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(631, 86);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(72, 33);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 30;
            btnSearch.Text = "查询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtPrID
            // 
            txtPrID.Cursor = Cursors.IBeam;
            txtPrID.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPrID.Location = new Point(95, 44);
            txtPrID.Margin = new Padding(4, 5, 4, 5);
            txtPrID.MinimumSize = new Size(1, 16);
            txtPrID.Name = "txtPrID";
            txtPrID.Padding = new Padding(5);
            txtPrID.ShowText = false;
            txtPrID.Size = new Size(171, 30);
            txtPrID.TabIndex = 29;
            txtPrID.TextAlignment = ContentAlignment.MiddleLeft;
            txtPrID.TouchPressClick = true;
            txtPrID.Watermark = "处方编号";
            // 
            // txtPatentName
            // 
            txtPatentName.Cursor = Cursors.IBeam;
            txtPatentName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPatentName.Location = new Point(390, 44);
            txtPatentName.Margin = new Padding(4, 5, 4, 5);
            txtPatentName.MinimumSize = new Size(1, 16);
            txtPatentName.Name = "txtPatentName";
            txtPatentName.Padding = new Padding(5);
            txtPatentName.ShowText = false;
            txtPatentName.Size = new Size(171, 30);
            txtPatentName.TabIndex = 38;
            txtPatentName.TextAlignment = ContentAlignment.MiddleLeft;
            txtPatentName.TouchPressClick = true;
            txtPatentName.Watermark = "患者名称";
            // 
            // cbSource
            // 
            cbSource.DataSource = null;
            cbSource.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbSource.FillColor = Color.White;
            cbSource.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbSource.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbSource.Items.AddRange(new object[] { "所有来源", "HIS系统", "TCM系统" });
            cbSource.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbSource.Location = new Point(95, 90);
            cbSource.Margin = new Padding(4, 5, 4, 5);
            cbSource.MinimumSize = new Size(63, 0);
            cbSource.Name = "cbSource";
            cbSource.Padding = new Padding(0, 0, 30, 2);
            cbSource.Size = new Size(171, 29);
            cbSource.SymbolSize = 24;
            cbSource.TabIndex = 39;
            cbSource.TextAlignment = ContentAlignment.MiddleLeft;
            cbSource.Watermark = "处方来源";
            // 
            // dtpStart
            // 
            dtpStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dtpStart.FillColor = Color.White;
            dtpStart.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtpStart.Location = new Point(723, 45);
            dtpStart.Margin = new Padding(4, 5, 4, 5);
            dtpStart.MaxLength = 10;
            dtpStart.MinimumSize = new Size(63, 0);
            dtpStart.Name = "dtpStart";
            dtpStart.Padding = new Padding(0, 0, 30, 2);
            dtpStart.ShowToday = true;
            dtpStart.Size = new Size(150, 29);
            dtpStart.SymbolDropDown = 61555;
            dtpStart.SymbolNormal = 61555;
            dtpStart.SymbolSize = 24;
            dtpStart.TabIndex = 40;
            dtpStart.TextAlignment = ContentAlignment.MiddleLeft;
            dtpStart.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dtpStart.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(16, 51);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(79, 23);
            uiLabel1.TabIndex = 41;
            uiLabel1.Text = "处方编号:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(304, 51);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(79, 23);
            uiLabel2.TabIndex = 42;
            uiLabel2.Text = "患者名称:";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(16, 96);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(79, 23);
            uiLabel3.TabIndex = 43;
            uiLabel3.Text = "处方来源:";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(304, 96);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(79, 23);
            uiLabel4.TabIndex = 44;
            uiLabel4.Text = "处方状态:";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(624, 51);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(79, 23);
            uiLabel5.TabIndex = 45;
            uiLabel5.Text = "创建时间:";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(889, 51);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(31, 23);
            uiLabel6.TabIndex = 46;
            uiLabel6.Text = "至";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpEnd
            // 
            dtpEnd.FillColor = Color.White;
            dtpEnd.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtpEnd.Location = new Point(927, 45);
            dtpEnd.Margin = new Padding(4, 5, 4, 5);
            dtpEnd.MaxLength = 10;
            dtpEnd.MinimumSize = new Size(63, 0);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Padding = new Padding(0, 0, 30, 2);
            dtpEnd.ShowToday = true;
            dtpEnd.Size = new Size(150, 29);
            dtpEnd.SymbolDropDown = 61555;
            dtpEnd.SymbolNormal = 61555;
            dtpEnd.SymbolSize = 24;
            dtpEnd.TabIndex = 47;
            dtpEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dtpEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dtpEnd.Watermark = "";
            // 
            // dgvPreDetail
            // 
            dgvPreDetail.AllowUserToAddRows = false;
            dgvPreDetail.AllowUserToDeleteRows = false;
            dgvPreDetail.AllowUserToResizeColumns = false;
            dgvPreDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dgvPreDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvPreDetail.BackgroundColor = Color.White;
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle17.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle17.ForeColor = Color.White;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvPreDetail.ColumnHeadersHeight = 32;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle18.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle18;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(80, 160, 255);
            dgvPreDetail.Location = new Point(787, 170);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle19.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle19.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle19.SelectionForeColor = Color.White;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle20;
            dgvPreDetail.SelectedIndex = -1;
            dgvPreDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreDetail.Size = new Size(475, 446);
            dgvPreDetail.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.TabIndex = 48;
            // 
            // FrmPrescriptionList
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1268, 660);
            Controls.Add(dgvPreDetail);
            Controls.Add(dtpEnd);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel5);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(dtpStart);
            Controls.Add(cbSource);
            Controls.Add(txtPatentName);
            Controls.Add(btnRefc);
            Controls.Add(btnReset);
            Controls.Add(cbPreState);
            Controls.Add(uiPage);
            Controls.Add(dgvList);
            Controls.Add(btnAddPre);
            Controls.Add(btnCopyPre);
            Controls.Add(btnSearch);
            Controls.Add(txtPrID);
            Name = "FrmPrescriptionList";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 261474;
            Text = "处方列表";
            Load += FrmPrescriptionList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISymbolButton btnRefc;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UIComboBox cbPreState;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnAddPre;
        private Sunny.UI.UISymbolButton btnCopyPre;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UITextBox txtPrID;
        private Sunny.UI.UITextBox txtPatentName;
        private Sunny.UI.UIComboBox cbSource;
        private Sunny.UI.UIDatePicker dtpStart;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIDatePicker dtpEnd;
        private Sunny.UI.UIDataGridView dgvPreDetail;
    }
}