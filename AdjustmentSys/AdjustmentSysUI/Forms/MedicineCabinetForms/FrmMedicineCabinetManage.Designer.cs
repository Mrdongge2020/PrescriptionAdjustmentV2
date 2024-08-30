namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmMedicineCabinetManage
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
            uiPanelTop = new Sunny.UI.UIPanel();
            btnRefc = new Sunny.UI.UISymbolButton();
            uiLabel1 = new Sunny.UI.UILabel();
            cbDurg = new Sunny.UI.UIComboBox();
            cmsRightKeyMenu = new Sunny.UI.UIContextMenuStrip();
            ListingParticles = new ToolStripMenuItem();
            RemoveParticles = new ToolStripMenuItem();
            RedRfid = new ToolStripMenuItem();
            dgvList = new Sunny.UI.UIDataGridView();
            uiPanelTop.SuspendLayout();
            cmsRightKeyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // uiPanelTop
            // 
            uiPanelTop.Controls.Add(btnRefc);
            uiPanelTop.Controls.Add(uiLabel1);
            uiPanelTop.Controls.Add(cbDurg);
            uiPanelTop.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanelTop.Location = new Point(-1, 35);
            uiPanelTop.Margin = new Padding(4, 5, 4, 5);
            uiPanelTop.MinimumSize = new Size(1, 1);
            uiPanelTop.Name = "uiPanelTop";
            uiPanelTop.Size = new Size(1637, 47);
            uiPanelTop.TabIndex = 0;
            uiPanelTop.Text = null;
            uiPanelTop.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(335, 7);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 1;
            btnRefc.Size = new Size(73, 30);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 33;
            btnRefc.Text = "刷新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(11, 7);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "药品搜索:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbDurg
            // 
            cbDurg.DataSource = null;
            cbDurg.FillColor = Color.White;
            cbDurg.FilterIgnoreCase = true;
            cbDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDurg.Location = new Point(116, 7);
            cbDurg.Margin = new Padding(4, 5, 4, 5);
            cbDurg.MinimumSize = new Size(63, 0);
            cbDurg.Name = "cbDurg";
            cbDurg.Padding = new Padding(0, 0, 30, 2);
            cbDurg.ShowClearButton = true;
            cbDurg.ShowFilter = true;
            cbDurg.Size = new Size(190, 29);
            cbDurg.SymbolSize = 24;
            cbDurg.TabIndex = 0;
            cbDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cbDurg.Watermark = "";
            // 
            // cmsRightKeyMenu
            // 
            cmsRightKeyMenu.BackColor = Color.FromArgb(243, 249, 255);
            cmsRightKeyMenu.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsRightKeyMenu.Items.AddRange(new ToolStripItem[] { ListingParticles, RemoveParticles, RedRfid });
            cmsRightKeyMenu.Name = "cmsRightKeyMenu";
            cmsRightKeyMenu.Size = new Size(181, 92);
            // 
            // ListingParticles
            // 
            ListingParticles.Name = "ListingParticles";
            ListingParticles.Size = new Size(180, 22);
            ListingParticles.Text = "上架颗粒";
            ListingParticles.Click += ListingParticles_Click;
            // 
            // RemoveParticles
            // 
            RemoveParticles.Name = "RemoveParticles";
            RemoveParticles.Size = new Size(180, 22);
            RemoveParticles.Text = "下架颗粒";
            RemoveParticles.Click += RemoveParticles_Click;
            // 
            // RedRfid
            // 
            RedRfid.Name = "RedRfid";
            RedRfid.Size = new Size(180, 22);
            RedRfid.Text = "写入RFID";
            RedRfid.Click += RedRfid_Click;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.BackgroundColor = Color.White;
            dgvList.BorderStyle = BorderStyle.Fixed3D;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.ContextMenuStrip = cmsRightKeyMenu;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EditMode = DataGridViewEditMode.EditOnF2;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.EnterAsTab = true;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(1, 79);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(1635, 767);
            dgvList.StripeEvenColor = Color.Empty;
            dgvList.StripeOddColor = SystemColors.Control;
            dgvList.TabIndex = 2;
            dgvList.CellEnter += dgvList_CellEnter;
            dgvList.CellPainting += dgvList_CellPainting;
            // 
            // FrmMedicineCabinetManage
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1636, 849);
            Controls.Add(dgvList);
            Controls.Add(uiPanelTop);
            Name = "FrmMedicineCabinetManage";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 361451;
            Text = "药柜管理";
            Load += FrmMedicineCabinetManage_Load;
            uiPanelTop.ResumeLayout(false);
            cmsRightKeyMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanelTop;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cbDurg;
        private Sunny.UI.UIContextMenuStrip cmsRightKeyMenu;
        private ToolStripMenuItem ListingParticles;
        private ToolStripMenuItem RemoveParticles;
        private ToolStripMenuItem RedRfid;
        private Sunny.UI.UISymbolButton btnRefc;
        private Sunny.UI.UIDataGridView dgvList;
    }
}