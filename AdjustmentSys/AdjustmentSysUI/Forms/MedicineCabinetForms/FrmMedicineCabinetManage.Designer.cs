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
            btnRefc = new Sunny.UI.UISymbolButton();
            uiLabel1 = new Sunny.UI.UILabel();
            cbDurg = new Sunny.UI.UIComboBox();
            cmsRightKeyMenu = new Sunny.UI.UIContextMenuStrip();
            ListingParticles = new ToolStripMenuItem();
            RemoveParticles = new ToolStripMenuItem();
            RedRfid = new ToolStripMenuItem();
            btnOpterDropDown = new Sunny.UI.UISymbolLabel();
            btnExportOpter = new Sunny.UI.UISymbolLabel();
            cmsOpterData = new Sunny.UI.UIContextMenuStrip();
            上药ToolStripMenuItem = new ToolStripMenuItem();
            余量调整ToolStripMenuItem = new ToolStripMenuItem();
            库存设置ToolStripMenuItem = new ToolStripMenuItem();
            有效期查询ToolStripMenuItem = new ToolStripMenuItem();
            cmsExcelOpter = new Sunny.UI.UIContextMenuStrip();
            导出颗粒余量Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            导出颗粒位置Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            导入颗粒余量Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            导入颗粒位置Excel文件ToolStripMenuItem = new ToolStripMenuItem();
            dgvList = new Sunny.UI.UIDataGridView();
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
            btnRefc.Location = new Point(345, 48);
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
            uiLabel1.Font = new Font("微软雅黑", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(19, 52);
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
            cbDurg.Font = new Font("微软雅黑", 12F);
            cbDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDurg.Location = new Point(126, 49);
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
            // btnOpterDropDown
            // 
            btnOpterDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpterDropDown.Font = new Font("微软雅黑", 12F);
            btnOpterDropDown.Location = new Point(814, 46);
            btnOpterDropDown.MinimumSize = new Size(1, 1);
            btnOpterDropDown.Name = "btnOpterDropDown";
            btnOpterDropDown.Size = new Size(151, 35);
            btnOpterDropDown.Symbol = 560112;
            btnOpterDropDown.SymbolColor = Color.Blue;
            btnOpterDropDown.TabIndex = 34;
            btnOpterDropDown.Text = "操作药柜数据";
            btnOpterDropDown.Click += btnOpterDropDown_Click;
            // 
            // btnExportOpter
            // 
            btnExportOpter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportOpter.Font = new Font("微软雅黑", 12F);
            btnExportOpter.Location = new Point(971, 46);
            btnExportOpter.MinimumSize = new Size(1, 1);
            btnExportOpter.Name = "btnExportOpter";
            btnExportOpter.Size = new Size(151, 35);
            btnExportOpter.Symbol = 560112;
            btnExportOpter.SymbolColor = Color.Blue;
            btnExportOpter.TabIndex = 35;
            btnExportOpter.Text = "导入导出数据";
            btnExportOpter.Click += btnExportOpter_Click;
            // 
            // cmsOpterData
            // 
            cmsOpterData.BackColor = Color.FromArgb(243, 249, 255);
            cmsOpterData.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsOpterData.Items.AddRange(new ToolStripItem[] { 上药ToolStripMenuItem, 余量调整ToolStripMenuItem, 库存设置ToolStripMenuItem, 有效期查询ToolStripMenuItem });
            cmsOpterData.Name = "cmsOpterData";
            cmsOpterData.Size = new Size(161, 108);
            // 
            // 上药ToolStripMenuItem
            // 
            上药ToolStripMenuItem.Name = "上药ToolStripMenuItem";
            上药ToolStripMenuItem.Size = new Size(160, 26);
            上药ToolStripMenuItem.Text = "上药";
            上药ToolStripMenuItem.Click += 上药ToolStripMenuItem_Click;
            // 
            // 余量调整ToolStripMenuItem
            // 
            余量调整ToolStripMenuItem.Name = "余量调整ToolStripMenuItem";
            余量调整ToolStripMenuItem.Size = new Size(160, 26);
            余量调整ToolStripMenuItem.Text = "余量校准";
            余量调整ToolStripMenuItem.Click += 余量调整ToolStripMenuItem_Click;
            // 
            // 库存设置ToolStripMenuItem
            // 
            库存设置ToolStripMenuItem.Name = "库存设置ToolStripMenuItem";
            库存设置ToolStripMenuItem.Size = new Size(160, 26);
            库存设置ToolStripMenuItem.Text = "库存设置";
            库存设置ToolStripMenuItem.Click += 库存设置ToolStripMenuItem_Click;
            // 
            // 有效期查询ToolStripMenuItem
            // 
            有效期查询ToolStripMenuItem.Name = "有效期查询ToolStripMenuItem";
            有效期查询ToolStripMenuItem.Size = new Size(160, 26);
            有效期查询ToolStripMenuItem.Text = "查看有效期";
            有效期查询ToolStripMenuItem.Click += 有效期查询ToolStripMenuItem_Click;
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.ContextMenuStrip = cmsRightKeyMenu;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 84);
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
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(1134, 747);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 36;
            // 
            // FrmMedicineCabinetManage
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1140, 834);
            Controls.Add(dgvList);
            Controls.Add(btnExportOpter);
            Controls.Add(btnOpterDropDown);
            Controls.Add(btnRefc);
            Controls.Add(uiLabel1);
            Controls.Add(cbDurg);
            Name = "FrmMedicineCabinetManage";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "药柜管理>>药柜颗粒管理";
            TitleFillColor = Color.FromArgb(80, 160, 255);
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
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
        private Sunny.UI.UISymbolLabel btnOpterDropDown;
        private Sunny.UI.UISymbolLabel btnExportOpter;
        private Sunny.UI.UIContextMenuStrip cmsOpterData;
        private ToolStripMenuItem 上药ToolStripMenuItem;
        private ToolStripMenuItem 余量调整ToolStripMenuItem;
        private ToolStripMenuItem 库存设置ToolStripMenuItem;
        private ToolStripMenuItem 有效期查询ToolStripMenuItem;
        private Sunny.UI.UIContextMenuStrip cmsExcelOpter;
        private ToolStripMenuItem 导出颗粒余量Excel文件ToolStripMenuItem;
        private ToolStripMenuItem 导出颗粒位置Excel文件ToolStripMenuItem;
        private ToolStripMenuItem 导入颗粒余量Excel文件ToolStripMenuItem;
        private ToolStripMenuItem 导入颗粒位置Excel文件ToolStripMenuItem;
        private Sunny.UI.UIDataGridView dgvList;
    }
}