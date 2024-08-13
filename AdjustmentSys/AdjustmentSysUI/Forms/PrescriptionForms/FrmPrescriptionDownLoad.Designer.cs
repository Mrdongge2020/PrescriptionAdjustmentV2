namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmPrescriptionDownLoad
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            dgvPreDetail = new Sunny.UI.UIDataGridView();
            dtpEnd = new Sunny.UI.UIDatePicker();
            uiLabel6 = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            dtpStart = new Sunny.UI.UIDatePicker();
            cbSource = new Sunny.UI.UIComboBox();
            txtPatentName = new Sunny.UI.UITextBox();
            btnZuoFei = new Sunny.UI.UISymbolButton();
            btnReset = new Sunny.UI.UISymbolButton();
            dgvList = new Sunny.UI.UIDataGridView();
            btnCopyPre = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            txtPrID = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvPreDetail
            // 
            dgvPreDetail.AllowUserToAddRows = false;
            dgvPreDetail.AllowUserToDeleteRows = false;
            dgvPreDetail.AllowUserToResizeColumns = false;
            dgvPreDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPreDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvPreDetail.BackgroundColor = Color.White;
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPreDetail.ColumnHeadersHeight = 32;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(80, 160, 255);
            dgvPreDetail.Location = new Point(1055, 150);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvPreDetail.SelectedIndex = -1;
            dgvPreDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreDetail.Size = new Size(412, 574);
            dgvPreDetail.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.TabIndex = 67;
            // 
            // dtpEnd
            // 
            dtpEnd.FillColor = Color.White;
            dtpEnd.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtpEnd.Location = new Point(866, 56);
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
            dtpEnd.TabIndex = 66;
            dtpEnd.Text = "2024-07-01";
            dtpEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dtpEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dtpEnd.Watermark = "";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(828, 59);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(31, 23);
            uiLabel6.TabIndex = 65;
            uiLabel6.Text = "至";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(572, 59);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(79, 23);
            uiLabel5.TabIndex = 64;
            uiLabel5.Text = "创建时间:";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(-85, 92);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(79, 23);
            uiLabel3.TabIndex = 62;
            uiLabel3.Text = "处方来源:";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(288, 59);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(79, 23);
            uiLabel2.TabIndex = 61;
            uiLabel2.Text = "患者名称:";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(-85, 47);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(79, 23);
            uiLabel1.TabIndex = 60;
            uiLabel1.Text = "处方编号:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpStart
            // 
            dtpStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dtpStart.FillColor = Color.White;
            dtpStart.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtpStart.Location = new Point(662, 56);
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
            dtpStart.TabIndex = 59;
            dtpStart.Text = "2024-07-01";
            dtpStart.TextAlignment = ContentAlignment.MiddleLeft;
            dtpStart.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dtpStart.Watermark = "";
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
            cbSource.Location = new Point(101, 103);
            cbSource.Margin = new Padding(4, 5, 4, 5);
            cbSource.MinimumSize = new Size(63, 0);
            cbSource.Name = "cbSource";
            cbSource.Padding = new Padding(0, 0, 30, 2);
            cbSource.Size = new Size(171, 29);
            cbSource.SymbolSize = 24;
            cbSource.TabIndex = 58;
            cbSource.TextAlignment = ContentAlignment.MiddleLeft;
            cbSource.Watermark = "处方来源";
            // 
            // txtPatentName
            // 
            txtPatentName.Cursor = Cursors.IBeam;
            txtPatentName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPatentName.Location = new Point(374, 55);
            txtPatentName.Margin = new Padding(4, 5, 4, 5);
            txtPatentName.MinimumSize = new Size(1, 16);
            txtPatentName.Name = "txtPatentName";
            txtPatentName.Padding = new Padding(5);
            txtPatentName.ShowText = false;
            txtPatentName.Size = new Size(171, 30);
            txtPatentName.TabIndex = 57;
            txtPatentName.TextAlignment = ContentAlignment.MiddleLeft;
            txtPatentName.TouchPressClick = true;
            txtPatentName.Watermark = "患者名称";
            // 
            // btnZuoFei
            // 
            btnZuoFei.Cursor = Cursors.Hand;
            btnZuoFei.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnZuoFei.Location = new Point(711, 102);
            btnZuoFei.MinimumSize = new Size(1, 1);
            btnZuoFei.Name = "btnZuoFei";
            btnZuoFei.Radius = 1;
            btnZuoFei.Size = new Size(70, 30);
            btnZuoFei.Symbol = 61473;
            btnZuoFei.SymbolColor = SystemColors.Window;
            btnZuoFei.TabIndex = 56;
            btnZuoFei.Text = "作废";
            btnZuoFei.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(455, 99);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(72, 33);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 55;
            btnReset.Text = "重置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // dgvList
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle8;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 150);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(1046, 574);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 53;
            dgvList.CellClick += dgvList_CellClick;
            // 
            // btnCopyPre
            // 
            btnCopyPre.Cursor = Cursors.Hand;
            btnCopyPre.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCopyPre.Location = new Point(572, 102);
            btnCopyPre.MinimumSize = new Size(1, 1);
            btnCopyPre.Name = "btnCopyPre";
            btnCopyPre.Radius = 1;
            btnCopyPre.Size = new Size(113, 30);
            btnCopyPre.Symbol = 361741;
            btnCopyPre.SymbolColor = SystemColors.Window;
            btnCopyPre.TabIndex = 51;
            btnCopyPre.Text = "匹配HIS码";
            btnCopyPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(330, 99);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 33);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 50;
            btnSearch.Text = "查询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // txtPrID
            // 
            txtPrID.Cursor = Cursors.IBeam;
            txtPrID.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPrID.Location = new Point(101, 55);
            txtPrID.Margin = new Padding(4, 5, 4, 5);
            txtPrID.MinimumSize = new Size(1, 16);
            txtPrID.Name = "txtPrID";
            txtPrID.Padding = new Padding(5);
            txtPrID.ShowText = false;
            txtPrID.Size = new Size(171, 30);
            txtPrID.TabIndex = 49;
            txtPrID.TextAlignment = ContentAlignment.MiddleLeft;
            txtPrID.TouchPressClick = true;
            txtPrID.Watermark = "处方编号";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(15, 62);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(79, 23);
            uiLabel4.TabIndex = 68;
            uiLabel4.Text = "处方编号:";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(15, 109);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(79, 23);
            uiLabel7.TabIndex = 69;
            uiLabel7.Text = "处方来源:";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmPrescriptionDownLoad
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1470, 727);
            Controls.Add(uiLabel7);
            Controls.Add(uiLabel4);
            Controls.Add(dgvPreDetail);
            Controls.Add(dtpEnd);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel5);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Controls.Add(dtpStart);
            Controls.Add(cbSource);
            Controls.Add(txtPatentName);
            Controls.Add(btnZuoFei);
            Controls.Add(btnReset);
            Controls.Add(dgvList);
            Controls.Add(btnCopyPre);
            Controls.Add(btnSearch);
            Controls.Add(txtPrID);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPrescriptionDownLoad";
            Text = "下载处方";
            ZoomScaleRect = new Rectangle(15, 15, 1063, 604);
            Load += FrmPrescriptionDownLoad_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDataGridView dgvPreDetail;
        private Sunny.UI.UIDatePicker dtpEnd;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIDatePicker dtpStart;
        private Sunny.UI.UIComboBox cbSource;
        private Sunny.UI.UITextBox txtPatentName;
        private Sunny.UI.UISymbolButton btnZuoFei;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UIComboBox cbPreState;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnAddPre;
        private Sunny.UI.UISymbolButton btnCopyPre;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UITextBox txtPrID;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel7;
    }
}