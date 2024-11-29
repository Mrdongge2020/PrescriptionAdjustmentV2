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
            btnHis = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            txtPrID = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
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
            dataGridViewCellStyle11.BackColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvPreDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvPreDetail.BackgroundColor = Color.White;
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle12.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle12.ForeColor = Color.White;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvPreDetail.ColumnHeadersHeight = 35;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle13.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle13;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(80, 160, 255);
            dgvPreDetail.Location = new Point(1022, 150);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle14.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle14.SelectionForeColor = Color.White;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = Color.White;
            dataGridViewCellStyle15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle15;
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
            dtpEnd.Location = new Point(904, 59);
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
            uiLabel6.Font = new Font("微软雅黑", 12F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(866, 62);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(31, 23);
            uiLabel6.TabIndex = 65;
            uiLabel6.Text = "至";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 12F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(610, 62);
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
            uiLabel2.Font = new Font("微软雅黑", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(300, 62);
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
            dtpStart.Font = new Font("微软雅黑", 12F);
            dtpStart.Location = new Point(700, 59);
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
            cbSource.Font = new Font("微软雅黑", 12F);
            cbSource.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbSource.Items.AddRange(new object[] { "所有来源", "HIS系统", "TCM系统" });
            cbSource.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbSource.Location = new Point(101, 112);
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
            txtPatentName.Font = new Font("微软雅黑", 12F);
            txtPatentName.Location = new Point(386, 58);
            txtPatentName.Margin = new Padding(4, 5, 4, 5);
            txtPatentName.MinimumSize = new Size(1, 16);
            txtPatentName.Name = "txtPatentName";
            txtPatentName.Padding = new Padding(5);
            txtPatentName.ShowText = false;
            txtPatentName.Size = new Size(183, 30);
            txtPatentName.TabIndex = 57;
            txtPatentName.TextAlignment = ContentAlignment.MiddleLeft;
            txtPatentName.TouchPressClick = true;
            txtPatentName.Watermark = "患者名称";
            // 
            // btnZuoFei
            // 
            btnZuoFei.Cursor = Cursors.Hand;
            btnZuoFei.Font = new Font("微软雅黑", 12F);
            btnZuoFei.Location = new Point(768, 109);
            btnZuoFei.MinimumSize = new Size(1, 1);
            btnZuoFei.Name = "btnZuoFei";
            btnZuoFei.Radius = 1;
            btnZuoFei.Size = new Size(110, 35);
            btnZuoFei.Symbol = 0;
            btnZuoFei.SymbolColor = SystemColors.Window;
            btnZuoFei.TabIndex = 56;
            btnZuoFei.Text = "作  废";
            btnZuoFei.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnZuoFei.Click += btnZuoFei_Click;
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("微软雅黑", 12F);
            btnReset.Location = new Point(459, 109);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(110, 35);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 55;
            btnReset.Text = "重 置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // dgvList
            // 
            dataGridViewCellStyle16.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle17.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle17.ForeColor = Color.White;
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle17.SelectionForeColor = Color.White;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvList.ColumnHeadersHeight = 35;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle18.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle18;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 150);
            dgvList.MultiSelect = false;
            dgvList.Name = "dgvList";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle19.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle19.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle19.SelectionForeColor = Color.White;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvList.RowHeadersWidth = 70;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle20;
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
            btnHis.Location = new Point(609, 109);
            btnHis.MinimumSize = new Size(1, 1);
            btnHis.Name = "btnHis";
            btnHis.Radius = 1;
            btnHis.Size = new Size(110, 35);
            btnHis.Symbol = 0;
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
            btnSearch.Location = new Point(300, 109);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 35);
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
            txtPrID.Location = new Point(101, 58);
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
            uiLabel4.Font = new Font("微软雅黑", 12F);
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
            uiLabel7.Font = new Font("微软雅黑", 12F);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(15, 115);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(79, 23);
            uiLabel7.TabIndex = 69;
            uiLabel7.Text = "处方来源:";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDownLoad
            // 
            btnDownLoad.Cursor = Cursors.Hand;
            btnDownLoad.Font = new Font("微软雅黑", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDownLoad.Location = new Point(1260, 62);
            btnDownLoad.MinimumSize = new Size(1, 1);
            btnDownLoad.Name = "btnDownLoad";
            btnDownLoad.Radius = 1;
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
            btnUpdateHis.Radius = 1;
            btnUpdateHis.Size = new Size(110, 35);
            btnUpdateHis.Symbol = 0;
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
        private Sunny.UI.UISymbolButton btnHis;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UITextBox txtPrID;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UISymbolButton btnDownLoad;
        private Sunny.UI.UISymbolButton btnUpdateHis;
    }
}