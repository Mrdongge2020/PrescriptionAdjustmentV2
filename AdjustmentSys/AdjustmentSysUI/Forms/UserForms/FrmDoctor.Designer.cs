namespace AdjustmentSysUI.Forms.UserForms
{
    partial class FrmDoctor
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
            btnReset = new Sunny.UI.UISymbolButton();
            uiPage = new Sunny.UI.UIPagination();
            dgvList = new Sunny.UI.UIDataGridView();
            btnAddDoctor = new Sunny.UI.UISymbolButton();
            btnEditDoctor = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            txtDocKey = new Sunny.UI.UITextBox();
            btnDelete = new Sunny.UI.UISymbolButton();
            cbDepartment = new Sunny.UI.UIComboBox();
            btnRefc = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(670, 48);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Radius = 10;
            btnReset.Size = new Size(90, 35);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 16;
            btnReset.Text = "重 置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.FillColor = Color.White;
            uiPage.FillColor2 = Color.White;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(10, 580);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.Radius = 10;
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1263, 35);
            uiPage.TabIndex = 14;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(10, 133);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(1263, 424);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 13;
            dgvList.CellClick += dgvList_CellClick;
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.Cursor = Cursors.Hand;
            btnAddDoctor.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddDoctor.Location = new Point(10, 92);
            btnAddDoctor.MinimumSize = new Size(1, 1);
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.Radius = 10;
            btnAddDoctor.Size = new Size(90, 35);
            btnAddDoctor.Symbol = 557672;
            btnAddDoctor.TabIndex = 12;
            btnAddDoctor.Text = "新 增";
            btnAddDoctor.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddDoctor.Click += btnAddDoctor_Click;
            // 
            // btnEditDoctor
            // 
            btnEditDoctor.Cursor = Cursors.Hand;
            btnEditDoctor.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEditDoctor.Location = new Point(117, 92);
            btnEditDoctor.MinimumSize = new Size(1, 1);
            btnEditDoctor.Name = "btnEditDoctor";
            btnEditDoctor.Radius = 10;
            btnEditDoctor.Size = new Size(90, 35);
            btnEditDoctor.Symbol = 61508;
            btnEditDoctor.SymbolColor = SystemColors.Window;
            btnEditDoctor.TabIndex = 11;
            btnEditDoctor.Text = "修 改";
            btnEditDoctor.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEditDoctor.Click += btnEditDoctor_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(547, 48);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 10;
            btnSearch.Size = new Size(90, 35);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 10;
            btnSearch.Text = "查 询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtDocKey
            // 
            txtDocKey.Cursor = Cursors.IBeam;
            txtDocKey.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtDocKey.Location = new Point(10, 50);
            txtDocKey.Margin = new Padding(4, 5, 4, 5);
            txtDocKey.MinimumSize = new Size(1, 16);
            txtDocKey.Name = "txtDocKey";
            txtDocKey.Padding = new Padding(5);
            txtDocKey.ShowText = false;
            txtDocKey.Size = new Size(240, 30);
            txtDocKey.TabIndex = 9;
            txtDocKey.TextAlignment = ContentAlignment.MiddleLeft;
            txtDocKey.TouchPressClick = true;
            txtDocKey.Watermark = "医生名称/拼音码/电话";
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Location = new Point(228, 92);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Radius = 10;
            btnDelete.Size = new Size(90, 35);
            btnDelete.Symbol = 559691;
            btnDelete.SymbolColor = SystemColors.Window;
            btnDelete.TabIndex = 17;
            btnDelete.Text = "删 除";
            btnDelete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Click += btnDelete_Click;
            // 
            // cbDepartment
            // 
            cbDepartment.DataSource = null;
            cbDepartment.FillColor = Color.White;
            cbDepartment.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbDepartment.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDepartment.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDepartment.Location = new Point(280, 50);
            cbDepartment.Margin = new Padding(4, 5, 4, 5);
            cbDepartment.MinimumSize = new Size(63, 0);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Padding = new Padding(0, 0, 30, 2);
            cbDepartment.Size = new Size(243, 30);
            cbDepartment.SymbolSize = 24;
            cbDepartment.TabIndex = 18;
            cbDepartment.TextAlignment = ContentAlignment.MiddleLeft;
            cbDepartment.Watermark = "医生科室";
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(338, 92);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 10;
            btnRefc.Size = new Size(90, 35);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 28;
            btnRefc.Text = "刷 新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // FrmDoctor
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1287, 638);
            Controls.Add(btnRefc);
            Controls.Add(cbDepartment);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(uiPage);
            Controls.Add(dgvList);
            Controls.Add(btnAddDoctor);
            Controls.Add(btnEditDoctor);
            Controls.Add(btnSearch);
            Controls.Add(txtDocKey);
            Name = "FrmDoctor";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "人员管理>>医生管理";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Load += FrmDoctor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnAddDoctor;
        private Sunny.UI.UISymbolButton btnEditDoctor;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UITextBox txtDocKey;
        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UIComboBox cbDepartment;
        private Sunny.UI.UISymbolButton btnRefc;
    }
}