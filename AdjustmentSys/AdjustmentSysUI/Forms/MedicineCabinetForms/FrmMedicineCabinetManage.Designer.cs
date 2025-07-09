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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            btnRefc = new Sunny.UI.UISymbolButton();
            uiLabel1 = new Sunny.UI.UILabel();
            cbDurg = new Sunny.UI.UIComboBox();
            cmsRightKeyMenu = new Sunny.UI.UIContextMenuStrip();
            ListingParticles = new ToolStripMenuItem();
            RemoveParticles = new ToolStripMenuItem();
            RedRfid = new ToolStripMenuItem();
            cmsOpterData = new Sunny.UI.UIContextMenuStrip();
            上药 = new ToolStripMenuItem();
            余量调整 = new ToolStripMenuItem();
            库存设置 = new ToolStripMenuItem();
            有效期查询 = new ToolStripMenuItem();
            cmsExcelOpter = new Sunny.UI.UIContextMenuStrip();
            导出颗粒余量Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            导出颗粒位置Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            导入颗粒余量Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            导入颗粒位置Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            dgvList = new Sunny.UI.UIDataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            btnCabinetsExport = new Sunny.UI.UISymbolButton();
            btnOpterCabinets = new Sunny.UI.UISymbolButton();
            cmsRightKeyMenu.SuspendLayout();
            cmsOpterData.SuspendLayout();
            cmsExcelOpter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("微软雅黑", 12F);
            btnRefc.Location = new Point(327, 38);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 10;
            btnRefc.Size = new Size(90, 35);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 33;
            btnRefc.Text = "刷 新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(3, 44);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(94, 23);
            uiLabel1.TabIndex = 1;
            uiLabel1.Text = "药品搜索:";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbDurg
            // 
            cbDurg.DataSource = null;
            cbDurg.FillColor = Color.White;
            cbDurg.FilterIgnoreCase = true;
            cbDurg.Font = new Font("微软雅黑", 12F);
            cbDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDurg.Location = new Point(112, 40);
            cbDurg.Margin = new Padding(4, 5, 4, 5);
            cbDurg.MinimumSize = new Size(63, 0);
            cbDurg.Name = "cbDurg";
            cbDurg.Padding = new Padding(0, 0, 30, 2);
            cbDurg.ShowClearButton = true;
            cbDurg.ShowFilter = true;
            cbDurg.Size = new Size(190, 30);
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
            cmsRightKeyMenu.Size = new Size(139, 70);
            // 
            // ListingParticles
            // 
            ListingParticles.Name = "ListingParticles";
            ListingParticles.Size = new Size(138, 22);
            ListingParticles.Text = "上架颗粒";
            ListingParticles.Click += ListingParticles_Click;
            // 
            // RemoveParticles
            // 
            RemoveParticles.Name = "RemoveParticles";
            RemoveParticles.Size = new Size(138, 22);
            RemoveParticles.Text = "下架颗粒";
            RemoveParticles.Click += RemoveParticles_Click;
            // 
            // RedRfid
            // 
            RedRfid.Name = "RedRfid";
            RedRfid.Size = new Size(138, 22);
            RedRfid.Text = "写入RFID";
            RedRfid.Click += RedRfid_Click;
            // 
            // cmsOpterData
            // 
            cmsOpterData.BackColor = Color.FromArgb(243, 249, 255);
            cmsOpterData.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsOpterData.Items.AddRange(new ToolStripItem[] { 上药, 余量调整, 库存设置, 有效期查询 });
            cmsOpterData.Name = "cmsOpterData";
            cmsOpterData.Size = new Size(161, 108);
            // 
            // 上药
            // 
            上药.Name = "上药";
            上药.Size = new Size(160, 26);
            上药.Text = "上药";
            上药.Click += 上药ToolStripMenuItem_Click;
            // 
            // 余量调整
            // 
            余量调整.Name = "余量调整";
            余量调整.Size = new Size(160, 26);
            余量调整.Text = "余量校准";
            余量调整.Click += 余量调整ToolStripMenuItem_Click;
            // 
            // 库存设置
            // 
            库存设置.Name = "库存设置";
            库存设置.Size = new Size(160, 26);
            库存设置.Text = "库存设置";
            库存设置.Click += 库存设置ToolStripMenuItem_Click;
            // 
            // 有效期查询
            // 
            有效期查询.Name = "有效期查询";
            有效期查询.Size = new Size(160, 26);
            有效期查询.Text = "查看有效期";
            有效期查询.Click += 有效期查询ToolStripMenuItem_Click;
            // 
            // cmsExcelOpter
            // 
            cmsExcelOpter.BackColor = Color.FromArgb(243, 249, 255);
            cmsExcelOpter.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsExcelOpter.Items.AddRange(new ToolStripItem[] { 导出颗粒余量Excel文件ToolStripMenuItem, 导出颗粒位置Excel文件ToolStripMenuItem, 导入颗粒余量Excel文件ToolStripMenuItem, 导入颗粒位置Excel文件ToolStripMenuItem });
            cmsExcelOpter.Name = "uiContextMenuStrip1";
            cmsExcelOpter.Size = new Size(257, 108);
            // 
            // 导出颗粒余量Excel文件ToolStripMenuItem
            // 
            导出颗粒余量Excel文件ToolStripMenuItem.Name = "导出颗粒余量Excel文件ToolStripMenuItem";
            导出颗粒余量Excel文件ToolStripMenuItem.Size = new Size(256, 26);
            导出颗粒余量Excel文件ToolStripMenuItem.Text = "导出颗粒库存(Excel文件)";
            导出颗粒余量Excel文件ToolStripMenuItem.Click += 导出颗粒余量Excel文件ToolStripMenuItem_Click;
            // 
            // 导出颗粒位置Excel文件ToolStripMenuItem
            // 
            导出颗粒位置Excel文件ToolStripMenuItem.Name = "导出颗粒位置Excel文件ToolStripMenuItem";
            导出颗粒位置Excel文件ToolStripMenuItem.Size = new Size(256, 26);
            导出颗粒位置Excel文件ToolStripMenuItem.Text = "导出颗粒位置(Excel文件)";
            导出颗粒位置Excel文件ToolStripMenuItem.Click += 导出颗粒位置Excel文件ToolStripMenuItem_Click;
            // 
            // 导入颗粒余量Excel文件ToolStripMenuItem
            // 
            导入颗粒余量Excel文件ToolStripMenuItem.Name = "导入颗粒余量Excel文件ToolStripMenuItem";
            导入颗粒余量Excel文件ToolStripMenuItem.Size = new Size(256, 26);
            导入颗粒余量Excel文件ToolStripMenuItem.Text = "导入颗粒库存(Excel文件)";
            导入颗粒余量Excel文件ToolStripMenuItem.Click += 导入颗粒余量Excel文件ToolStripMenuItem_Click;
            // 
            // 导入颗粒位置Excel文件ToolStripMenuItem
            // 
            导入颗粒位置Excel文件ToolStripMenuItem.Name = "导入颗粒位置Excel文件ToolStripMenuItem";
            导入颗粒位置Excel文件ToolStripMenuItem.Size = new Size(256, 26);
            导入颗粒位置Excel文件ToolStripMenuItem.Text = "导入颗粒位置(Excel文件)";
            导入颗粒位置Excel文件ToolStripMenuItem.Click += 导入颗粒位置Excel文件ToolStripMenuItem_Click;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 249, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.BackgroundColor = Color.FromArgb(243, 249, 255);
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 126, 164);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 126, 164);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.ContextMenuStrip = cmsRightKeyMenu;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 236, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(104, 173, 255);
            dgvList.Location = new Point(3, 84);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(243, 249, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(220, 236, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(1134, 747);
            dgvList.TabIndex = 36;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btnCabinetsExport
            // 
            btnCabinetsExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCabinetsExport.ContextMenuStrip = cmsExcelOpter;
            btnCabinetsExport.Cursor = Cursors.Hand;
            btnCabinetsExport.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCabinetsExport.Location = new Point(923, 38);
            btnCabinetsExport.MinimumSize = new Size(1, 1);
            btnCabinetsExport.Name = "btnCabinetsExport";
            btnCabinetsExport.Radius = 10;
            btnCabinetsExport.Size = new Size(180, 35);
            btnCabinetsExport.Symbol = 560112;
            btnCabinetsExport.TabIndex = 39;
            btnCabinetsExport.Text = "导入导出数据";
            btnCabinetsExport.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCabinetsExport.Click += brnCabinetsExport_Click;
            // 
            // btnOpterCabinets
            // 
            btnOpterCabinets.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpterCabinets.ContextMenuStrip = cmsOpterData;
            btnOpterCabinets.Cursor = Cursors.Hand;
            btnOpterCabinets.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpterCabinets.Location = new Point(713, 38);
            btnOpterCabinets.MinimumSize = new Size(1, 1);
            btnOpterCabinets.Name = "btnOpterCabinets";
            btnOpterCabinets.Radius = 10;
            btnOpterCabinets.Size = new Size(180, 35);
            btnOpterCabinets.Symbol = 560112;
            btnOpterCabinets.TabIndex = 40;
            btnOpterCabinets.Text = "操作药柜数据";
            btnOpterCabinets.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpterCabinets.Click += btnOpterCabinets_Click;
            // 
            // FrmMedicineCabinetManage
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1140, 834);
            Controls.Add(btnOpterCabinets);
            Controls.Add(btnCabinetsExport);
            Controls.Add(dgvList);
            Controls.Add(btnRefc);
            Controls.Add(uiLabel1);
            Controls.Add(cbDurg);
            Name = "FrmMedicineCabinetManage";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 361641;
            Text = "药柜管理>>药柜颗粒管理";
            TitleFillColor = Color.FromArgb(243, 249, 255);
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            TitleForeColor = Color.FromArgb(80, 126, 164);
            Load += FrmMedicineCabinetManage_Load;
            cmsRightKeyMenu.ResumeLayout(false);
            cmsOpterData.ResumeLayout(false);
            cmsExcelOpter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cbDurg;
        private Sunny.UI.UIContextMenuStrip cmsRightKeyMenu;
        private ToolStripMenuItem ListingParticles;
        private ToolStripMenuItem RemoveParticles;
        private ToolStripMenuItem RedRfid;
        private Sunny.UI.UISymbolButton btnRefc;
        private Sunny.UI.UIContextMenuStrip cmsOpterData;
        private ToolStripMenuItem 上药;
        private ToolStripMenuItem 余量调整;
        private ToolStripMenuItem 库存设置;
        private ToolStripMenuItem 有效期查询;
        private Sunny.UI.UIContextMenuStrip cmsExcelOpter;
        private ToolStripMenuItem 导出颗粒余量Excel文件ToolStripMenuItem;
        private ToolStripMenuItem 导出颗粒位置Excel文件ToolStripMenuItem;
        private ToolStripMenuItem 导入颗粒余量Excel文件ToolStripMenuItem;
        private ToolStripMenuItem 导入颗粒位置Excel文件ToolStripMenuItem;
        private Sunny.UI.UIDataGridView dgvList;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UISymbolButton btnCabinetsExport;
        private Sunny.UI.UISymbolButton btnOpterCabinets;
    }
}