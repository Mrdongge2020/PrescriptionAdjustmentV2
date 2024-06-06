namespace AdjustmentSysUI.Forms.UserForms
{
    partial class FrmUser
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
            txtUserKey = new Sunny.UI.UITextBox();
            btnSearch = new Sunny.UI.UISymbolButton();
            btnEditUser = new Sunny.UI.UISymbolButton();
            btnAddUser = new Sunny.UI.UISymbolButton();
            dgvUserList = new Sunny.UI.UIDataGridView();
            uiPage = new Sunny.UI.UIPagination();
            cbUserState = new Sunny.UI.UIComboBox();
            btnReset = new Sunny.UI.UISymbolButton();
            btnRefc = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvUserList).BeginInit();
            SuspendLayout();
            // 
            // txtUserKey
            // 
            txtUserKey.Cursor = Cursors.IBeam;
            txtUserKey.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtUserKey.Location = new Point(13, 53);
            txtUserKey.Margin = new Padding(4, 5, 4, 5);
            txtUserKey.MinimumSize = new Size(1, 16);
            txtUserKey.Name = "txtUserKey";
            txtUserKey.Padding = new Padding(5);
            txtUserKey.ShowText = false;
            txtUserKey.Size = new Size(265, 30);
            txtUserKey.TabIndex = 0;
            txtUserKey.TextAlignment = ContentAlignment.MiddleLeft;
            txtUserKey.TouchPressClick = true;
            txtUserKey.Watermark = "用户名/电话";
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(502, 53);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(72, 33);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 1;
            btnSearch.Text = "查询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Cursor = Cursors.Hand;
            btnEditUser.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEditUser.Location = new Point(114, 102);
            btnEditUser.MinimumSize = new Size(1, 1);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Radius = 1;
            btnEditUser.Size = new Size(70, 30);
            btnEditUser.Symbol = 361741;
            btnEditUser.SymbolColor = SystemColors.Window;
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "修改";
            btnEditUser.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddUser.Location = new Point(13, 102);
            btnAddUser.MinimumSize = new Size(1, 1);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Radius = 1;
            btnAddUser.Size = new Size(70, 30);
            btnAddUser.Symbol = 362211;
            btnAddUser.TabIndex = 3;
            btnAddUser.Text = "新增";
            btnAddUser.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dgvUserList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvUserList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUserList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUserList.BackgroundColor = Color.White;
            dgvUserList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUserList.ColumnHeadersHeight = 32;
            dgvUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvUserList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvUserList.EnableHeadersVisualStyles = false;
            dgvUserList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvUserList.GridColor = Color.FromArgb(80, 160, 255);
            dgvUserList.Location = new Point(13, 138);
            dgvUserList.Name = "dgvUserList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvUserList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvUserList.RowHeadersVisible = false;
            dgvUserList.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvUserList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvUserList.RowTemplate.Height = 27;
            dgvUserList.SelectedIndex = -1;
            dgvUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserList.Size = new Size(1263, 424);
            dgvUserList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvUserList.TabIndex = 5;
            dgvUserList.CellClick += dgvUserList_CellClick;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(27, 580);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1085, 39);
            uiPage.TabIndex = 6;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // cbUserState
            // 
            cbUserState.DataSource = null;
            cbUserState.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbUserState.FillColor = Color.White;
            cbUserState.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbUserState.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbUserState.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbUserState.Location = new Point(311, 53);
            cbUserState.Margin = new Padding(4, 5, 4, 5);
            cbUserState.MinimumSize = new Size(63, 0);
            cbUserState.Name = "cbUserState";
            cbUserState.Padding = new Padding(0, 0, 30, 2);
            cbUserState.Size = new Size(128, 29);
            cbUserState.SymbolSize = 24;
            cbUserState.TabIndex = 7;
            cbUserState.TextAlignment = ContentAlignment.MiddleCenter;
            cbUserState.Watermark = "账号状态";
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(631, 53);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(72, 33);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 8;
            btnReset.Text = "重置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(230, 102);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 1;
            btnRefc.Size = new Size(70, 30);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 28;
            btnRefc.Text = "刷新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // FrmUser
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1287, 638);
            Controls.Add(btnRefc);
            Controls.Add(btnReset);
            Controls.Add(cbUserState);
            Controls.Add(uiPage);
            Controls.Add(dgvUserList);
            Controls.Add(btnAddUser);
            Controls.Add(btnEditUser);
            Controls.Add(btnSearch);
            Controls.Add(txtUserKey);
            Name = "FrmUser";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 559705;
            Text = "用户管理";
            Load += FrmUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUserList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox txtUserKey;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnEditUser;
        private Sunny.UI.UISymbolButton btnAddUser;
        private Sunny.UI.UIDataGridView dgvUserList;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIComboBox cbUserState;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UISymbolButton btnRefc;
    }
}