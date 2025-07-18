﻿namespace AdjustmentSysUI.Forms.PrescriptionForms
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
            btnPrint = new Sunny.UI.UISymbolButton();
            btnMainPrint = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).BeginInit();
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("微软雅黑", 12F);
            btnReset.Location = new Point(802, 84);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Radius = 10;
            btnReset.Size = new Size(90, 35);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 36;
            btnReset.Text = "重 置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // cbPreState
            // 
            cbPreState.DataSource = null;
            cbPreState.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbPreState.FillColor = Color.White;
            cbPreState.Font = new Font("微软雅黑", 12F);
            cbPreState.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbPreState.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbPreState.Location = new Point(445, 93);
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
            uiPage.FillColor = Color.White;
            uiPage.FillColor2 = Color.White;
            uiPage.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(10, 619);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1252, 35);
            uiPage.Style = Sunny.UI.UIStyle.Custom;
            uiPage.TabIndex = 34;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // dgvList
            // 
            dgvList.AllowUserToOrderColumns = true;
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
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(10, 171);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(781, 445);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 33;
            dgvList.CellClick += dgvList_CellClick;
            dgvList.ColumnHeaderMouseClick += dgvList_ColumnHeaderMouseClick;
            dgvList.RowPostPaint += dgvList_RowPostPaint;
            // 
            // btnAddPre
            // 
            btnAddPre.Cursor = Cursors.Hand;
            btnAddPre.Font = new Font("微软雅黑", 12F);
            btnAddPre.Location = new Point(16, 130);
            btnAddPre.MinimumSize = new Size(1, 1);
            btnAddPre.Name = "btnAddPre";
            btnAddPre.Radius = 10;
            btnAddPre.Size = new Size(120, 35);
            btnAddPre.Symbol = 557672;
            btnAddPre.TabIndex = 32;
            btnAddPre.Text = "录入处方";
            btnAddPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddPre.Click += btnAddPre_Click;
            // 
            // btnCopyPre
            // 
            btnCopyPre.Cursor = Cursors.Hand;
            btnCopyPre.Font = new Font("微软雅黑", 12F);
            btnCopyPre.Location = new Point(170, 130);
            btnCopyPre.MinimumSize = new Size(1, 1);
            btnCopyPre.Name = "btnCopyPre";
            btnCopyPre.Radius = 10;
            btnCopyPre.Size = new Size(120, 35);
            btnCopyPre.Symbol = 61637;
            btnCopyPre.SymbolColor = SystemColors.Window;
            btnCopyPre.TabIndex = 31;
            btnCopyPre.Text = "复制处方";
            btnCopyPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCopyPre.Click += btnCopyPre_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("微软雅黑", 12F);
            btnSearch.Location = new Point(673, 84);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 10;
            btnSearch.Size = new Size(90, 35);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 30;
            btnSearch.Text = "查 询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtPrID
            // 
            txtPrID.Cursor = Cursors.IBeam;
            txtPrID.Font = new Font("微软雅黑", 12F);
            txtPrID.Location = new Point(147, 46);
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
            txtPatentName.Font = new Font("微软雅黑", 12F);
            txtPatentName.Location = new Point(445, 46);
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
            cbSource.Font = new Font("微软雅黑", 12F);
            cbSource.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbSource.Items.AddRange(new object[] { "所有来源", "HIS系统", "TCM系统" });
            cbSource.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbSource.Location = new Point(147, 93);
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
            dtpStart.Font = new Font("微软雅黑", 12F);
            dtpStart.Location = new Point(770, 47);
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
            dtpStart.Text = "2024-07-01";
            dtpStart.TextAlignment = ContentAlignment.MiddleLeft;
            dtpStart.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dtpStart.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(16, 50);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(119, 23);
            uiLabel1.TabIndex = 41;
            uiLabel1.Text = "处方编号:";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(325, 50);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(113, 23);
            uiLabel2.TabIndex = 42;
            uiLabel2.Text = "患者名称:";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(16, 96);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(119, 23);
            uiLabel3.TabIndex = 43;
            uiLabel3.Text = "处方来源:";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("微软雅黑", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(325, 96);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(113, 23);
            uiLabel4.TabIndex = 44;
            uiLabel4.Text = "处方状态:";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("微软雅黑", 12F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(623, 50);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(127, 23);
            uiLabel5.TabIndex = 45;
            uiLabel5.Text = "创建时间:";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("微软雅黑", 12F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(927, 50);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(55, 23);
            uiLabel6.TabIndex = 46;
            uiLabel6.Text = "至";
            uiLabel6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpEnd
            // 
            dtpEnd.FillColor = Color.White;
            dtpEnd.Font = new Font("微软雅黑", 12F);
            dtpEnd.Location = new Point(989, 47);
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
            dtpEnd.Text = "2024-07-01";
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
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvPreDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvPreDetail.BackgroundColor = Color.White;
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvPreDetail.ColumnHeadersHeight = 32;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle8;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(80, 160, 255);
            dgvPreDetail.Location = new Point(797, 170);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvPreDetail.SelectedIndex = -1;
            dgvPreDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreDetail.Size = new Size(465, 446);
            dgvPreDetail.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.TabIndex = 48;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Font = new Font("微软雅黑", 12F);
            btnPrint.Location = new Point(987, 130);
            btnPrint.MinimumSize = new Size(1, 1);
            btnPrint.Name = "btnPrint";
            btnPrint.Radius = 10;
            btnPrint.Size = new Size(120, 35);
            btnPrint.Symbol = 361487;
            btnPrint.SymbolColor = SystemColors.Window;
            btnPrint.TabIndex = 49;
            btnPrint.Text = "打  印";
            btnPrint.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnPrint.Click += btnPrint_Click;
            // 
            // btnMainPrint
            // 
            btnMainPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMainPrint.Cursor = Cursors.Hand;
            btnMainPrint.Font = new Font("微软雅黑", 12F);
            btnMainPrint.Location = new Point(1128, 130);
            btnMainPrint.MinimumSize = new Size(1, 1);
            btnMainPrint.Name = "btnMainPrint";
            btnMainPrint.Radius = 10;
            btnMainPrint.Size = new Size(120, 35);
            btnMainPrint.Symbol = 361487;
            btnMainPrint.SymbolColor = SystemColors.Window;
            btnMainPrint.TabIndex = 50;
            btnMainPrint.Text = "主打印";
            btnMainPrint.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnMainPrint.Click += btnMainPrint_Click;
            // 
            // FrmPrescriptionList
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1268, 660);
            Controls.Add(btnMainPrint);
            Controls.Add(btnPrint);
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
            Controls.Add(btnReset);
            Controls.Add(cbPreState);
            Controls.Add(uiPage);
            Controls.Add(dgvList);
            Controls.Add(btnAddPre);
            Controls.Add(btnCopyPre);
            Controls.Add(btnSearch);
            Controls.Add(txtPrID);
            Font = new Font("微软雅黑", 12F);
            Name = "FrmPrescriptionList";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "处方管理>>处方列表";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
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
        private Sunny.UI.UISymbolButton btnPrint;
        private Sunny.UI.UISymbolButton btnMainPrint;
    }
}