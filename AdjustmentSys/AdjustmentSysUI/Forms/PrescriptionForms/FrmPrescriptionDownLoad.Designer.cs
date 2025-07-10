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
            uiLabel1 = new Sunny.UI.UILabel();
            dtpStart = new Sunny.UI.UIDatePicker();
            cbSource = new Sunny.UI.UIComboBox();
            txtPatentName = new Sunny.UI.UITextBox();
            btnZuoFei = new Sunny.UI.UISymbolButton();
            btnReset = new Sunny.UI.UISymbolButton();
            dgvList = new Sunny.UI.UIDataGridView();
            btnHis = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            txtPrID = new Sunny.UI.UITextBox();
            btnDownLoad = new Sunny.UI.UISymbolButton();
            btnUpdateHis = new Sunny.UI.UISymbolButton();
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
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPreDetail.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(80, 160, 255);
            dgvPreDetail.Location = new Point(1022, 150);
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
            dgvPreDetail.Size = new Size(445, 574);
            dgvPreDetail.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.TabIndex = 67;
            // 
            // dtpEnd
            // 
            dtpEnd.FillColor = Color.White;
            dtpEnd.Font = new Font("微软雅黑", 12F);
            dtpEnd.Location = new Point(761, 59);
            dtpEnd.Margin = new Padding(4, 5, 4, 5);
            dtpEnd.MaxLength = 10;
            dtpEnd.MinimumSize = new Size(63, 0);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Padding = new Padding(0, 0, 30, 2);
            dtpEnd.ShowToday = true;
            dtpEnd.Size = new Size(146, 29);
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
            uiLabel6.Font = new Font("微软雅黑", 12F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(711, 62);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(40, 23);
            uiLabel6.TabIndex = 65;
            uiLabel6.Text = "至";
            uiLabel6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 12F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(425, 62);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(122, 23);
            uiLabel5.TabIndex = 64;
            uiLabel5.Text = "创建时间:";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
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
            dtpStart.Font = new Font("微软雅黑", 12F);
            dtpStart.Location = new Point(554, 59);
            dtpStart.Margin = new Padding(4, 5, 4, 5);
            dtpStart.MaxLength = 10;
            dtpStart.MinimumSize = new Size(63, 0);
            dtpStart.Name = "dtpStart";
            dtpStart.Padding = new Padding(0, 0, 30, 2);
            dtpStart.ShowToday = true;
            dtpStart.Size = new Size(146, 29);
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
            cbSource.Font = new Font("微软雅黑", 12F);
            cbSource.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbSource.Items.AddRange(new object[] { "所有来源", "HIS系统", "TCM系统" });
            cbSource.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbSource.Location = new Point(7, 109);
            cbSource.Margin = new Padding(4, 5, 4, 5);
            cbSource.MinimumSize = new Size(63, 0);
            cbSource.Name = "cbSource";
            cbSource.Padding = new Padding(0, 0, 30, 2);
            cbSource.Size = new Size(171, 29);
            cbSource.SymbolSize = 24;
            cbSource.TabIndex = 58;
            cbSource.TextAlignment = ContentAlignment.MiddleLeft;
            cbSource.Watermark = "请选择处方来源";
            // 
            // txtPatentName
            // 
            txtPatentName.Cursor = Cursors.IBeam;
            txtPatentName.Font = new Font("微软雅黑", 12F);
            txtPatentName.Location = new Point(206, 58);
            txtPatentName.Margin = new Padding(4, 5, 4, 5);
            txtPatentName.MinimumSize = new Size(1, 16);
            txtPatentName.Name = "txtPatentName";
            txtPatentName.Padding = new Padding(5);
            txtPatentName.ShowText = false;
            txtPatentName.Size = new Size(207, 30);
            txtPatentName.TabIndex = 57;
            txtPatentName.TextAlignment = ContentAlignment.MiddleLeft;
            txtPatentName.TouchPressClick = true;
            txtPatentName.Watermark = "请输入患者名称";
            // 
            // btnZuoFei
            // 
            btnZuoFei.Cursor = Cursors.Hand;
            btnZuoFei.Font = new Font("微软雅黑", 12F);
            btnZuoFei.Location = new Point(598, 106);
            btnZuoFei.MinimumSize = new Size(1, 1);
            btnZuoFei.Name = "btnZuoFei";
            btnZuoFei.Radius = 10;
            btnZuoFei.Size = new Size(90, 35);
            btnZuoFei.Symbol = 558825;
            btnZuoFei.SymbolColor = SystemColors.Window;
            btnZuoFei.TabIndex = 56;
            btnZuoFei.Text = "作 废";
            btnZuoFei.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnZuoFei.Click += btnZuoFei_Click;
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("微软雅黑", 12F);
            btnReset.Location = new Point(323, 106);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Radius = 10;
            btnReset.Size = new Size(90, 35);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 55;
            btnReset.Text = "重 置";
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
            dataGridViewCellStyle7.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvList.ColumnHeadersHeight = 35;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle8;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 150);
            dgvList.MultiSelect = false;
            dgvList.Name = "dgvList";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvList.RowHeadersWidth = 70;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(1013, 574);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 53;
            dgvList.CellClick += dgvList_CellClick;
            dgvList.CellDoubleClick += dgvList_CellDoubleClick;
            dgvList.RowPostPaint += dgvList_RowPostPaint;
            // 
            // btnHis
            // 
            btnHis.Cursor = Cursors.Hand;
            btnHis.Font = new Font("微软雅黑", 12F);
            btnHis.Location = new Point(459, 106);
            btnHis.MinimumSize = new Size(1, 1);
            btnHis.Name = "btnHis";
            btnHis.Radius = 10;
            btnHis.Size = new Size(120, 35);
            btnHis.Symbol = 61508;
            btnHis.SymbolColor = SystemColors.Window;
            btnHis.TabIndex = 51;
            btnHis.Text = "匹配HIS码";
            btnHis.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnHis.Click += btnHis_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("微软雅黑", 12F);
            btnSearch.Location = new Point(206, 106);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 10;
            btnSearch.Size = new Size(90, 35);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 50;
            btnSearch.Text = "查 询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtPrID
            // 
            txtPrID.Cursor = Cursors.IBeam;
            txtPrID.Font = new Font("微软雅黑", 12F);
            txtPrID.Location = new Point(7, 58);
            txtPrID.Margin = new Padding(4, 5, 4, 5);
            txtPrID.MinimumSize = new Size(1, 16);
            txtPrID.Name = "txtPrID";
            txtPrID.Padding = new Padding(5);
            txtPrID.ShowText = false;
            txtPrID.Size = new Size(171, 30);
            txtPrID.TabIndex = 49;
            txtPrID.TextAlignment = ContentAlignment.MiddleLeft;
            txtPrID.TouchPressClick = true;
            txtPrID.Watermark = "请输入处方编号";
            // 
            // btnDownLoad
            // 
            btnDownLoad.Cursor = Cursors.Hand;
            btnDownLoad.Font = new Font("微软雅黑", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDownLoad.Location = new Point(1260, 62);
            btnDownLoad.MinimumSize = new Size(1, 1);
            btnDownLoad.Name = "btnDownLoad";
            btnDownLoad.Radius = 10;
            btnDownLoad.Size = new Size(143, 52);
            btnDownLoad.Symbol = 558052;
            btnDownLoad.SymbolColor = SystemColors.Window;
            btnDownLoad.TabIndex = 70;
            btnDownLoad.Text = "下载处方";
            btnDownLoad.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDownLoad.Click += btnDownLoad_Click;
            // 
            // btnUpdateHis
            // 
            btnUpdateHis.Cursor = Cursors.Hand;
            btnUpdateHis.Font = new Font("微软雅黑", 12F);
            btnUpdateHis.Location = new Point(1035, 106);
            btnUpdateHis.MinimumSize = new Size(1, 1);
            btnUpdateHis.Name = "btnUpdateHis";
            btnUpdateHis.Radius = 10;
            btnUpdateHis.Size = new Size(120, 35);
            btnUpdateHis.Symbol = 61508;
            btnUpdateHis.SymbolColor = SystemColors.Window;
            btnUpdateHis.TabIndex = 71;
            btnUpdateHis.Text = "更新HIS码";
            btnUpdateHis.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnUpdateHis.Click += btnUpdateHis_Click;
            // 
            // FrmPrescriptionDownLoad
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1470, 727);
            Controls.Add(btnUpdateHis);
            Controls.Add(btnDownLoad);
            Controls.Add(dgvPreDetail);
            Controls.Add(dtpEnd);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel5);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel1);
            Controls.Add(dtpStart);
            Controls.Add(cbSource);
            Controls.Add(txtPatentName);
            Controls.Add(btnZuoFei);
            Controls.Add(btnReset);
            Controls.Add(dgvList);
            Controls.Add(btnHis);
            Controls.Add(btnSearch);
            Controls.Add(txtPrID);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPrescriptionDownLoad";
            Text = "下载处方";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
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
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIDatePicker dtpStart;
        private Sunny.UI.UIComboBox cbSource;
        private Sunny.UI.UITextBox txtPatentName;
        private Sunny.UI.UISymbolButton btnZuoFei;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UIComboBox cbPreState;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnAddPre;
        private Sunny.UI.UISymbolButton btnHis;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UITextBox txtPrID;
        private Sunny.UI.UISymbolButton btnDownLoad;
        private Sunny.UI.UISymbolButton btnUpdateHis;
    }
}