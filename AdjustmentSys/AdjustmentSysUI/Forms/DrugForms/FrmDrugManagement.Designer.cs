namespace AdjustmentSysUI.Forms.Pharmacopoeia
{
    partial class FrmDrugManagement
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
            btnDelete = new Sunny.UI.UISymbolButton();
            btnReset = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnEdit = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            txtKeywords = new Sunny.UI.UITextBox();
            dgvList = new Sunny.UI.UIDataGridView();
            btnRefc = new Sunny.UI.UISymbolButton();
            uiPage = new Sunny.UI.UIPagination();
            cmsOpterDurgData = new Sunny.UI.UIContextMenuStrip();
            药品系数调整 = new ToolStripMenuItem();
            cmsDurgExcelOpter = new Sunny.UI.UIContextMenuStrip();
            药品数据导出 = new ToolStripMenuItem();
            药品数据导入 = new ToolStripMenuItem();
            匹配数据导入 = new ToolStripMenuItem();
            btnOpterDurg = new Sunny.UI.UISymbolButton();
            btnDrugExport = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            cmsOpterDurgData.SuspendLayout();
            cmsDurgExcelOpter.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Location = new Point(227, 90);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Radius = 10;
            btnDelete.Size = new Size(90, 35);
            btnDelete.Symbol = 559691;
            btnDelete.SymbolColor = SystemColors.Window;
            btnDelete.TabIndex = 26;
            btnDelete.Text = "删 除";
            btnDelete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(447, 48);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Radius = 10;
            btnReset.Size = new Size(90, 35);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 25;
            btnReset.Text = "重 置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Location = new Point(10, 90);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 10;
            btnAdd.Size = new Size(90, 35);
            btnAdd.Symbol = 557672;
            btnAdd.TabIndex = 22;
            btnAdd.Text = "新 增";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Location = new Point(116, 90);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Radius = 10;
            btnEdit.Size = new Size(90, 35);
            btnEdit.Symbol = 61508;
            btnEdit.SymbolColor = SystemColors.Window;
            btnEdit.TabIndex = 21;
            btnEdit.Text = "修 改";
            btnEdit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(337, 48);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Radius = 10;
            btnSearch.Size = new Size(90, 35);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 20;
            btnSearch.Text = "查 询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeywords
            // 
            txtKeywords.ButtonSymbol = 557676;
            txtKeywords.Cursor = Cursors.IBeam;
            txtKeywords.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtKeywords.Location = new Point(10, 50);
            txtKeywords.Margin = new Padding(4, 5, 4, 5);
            txtKeywords.MinimumSize = new Size(1, 16);
            txtKeywords.Name = "txtKeywords";
            txtKeywords.Padding = new Padding(5);
            txtKeywords.ShowButton = true;
            txtKeywords.ShowText = false;
            txtKeywords.Size = new Size(307, 30);
            txtKeywords.TabIndex = 19;
            txtKeywords.TextAlignment = ContentAlignment.MiddleLeft;
            txtKeywords.TouchPressClick = true;
            txtKeywords.Watermark = "药品名称/拼音码简称";
            txtKeywords.ButtonClick += txtKeywords_ButtonClick;
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
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
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
            dgvList.Location = new Point(10, 134);
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
            dgvList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvList.Size = new Size(1310, 467);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 27;
            dgvList.ZoomScaleDisabled = true;
            dgvList.CellClick += dgvList_CellClick;
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(337, 90);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 10;
            btnRefc.Size = new Size(90, 35);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 30;
            btnRefc.Text = "刷 新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.FillColor = Color.White;
            uiPage.FillColor2 = Color.White;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(10, 609);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.Radius = 10;
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1310, 35);
            uiPage.Style = Sunny.UI.UIStyle.Custom;
            uiPage.TabIndex = 31;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // cmsOpterDurgData
            // 
            cmsOpterDurgData.BackColor = Color.FromArgb(243, 249, 255);
            cmsOpterDurgData.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsOpterDurgData.Items.AddRange(new ToolStripItem[] { 药品系数调整 });
            cmsOpterDurgData.Name = "cmsOpterDurgData";
            cmsOpterDurgData.Size = new Size(174, 30);
            // 
            // 药品系数调整
            // 
            药品系数调整.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            药品系数调整.Name = "药品系数调整";
            药品系数调整.Size = new Size(173, 26);
            药品系数调整.Text = "药品系数调整";
            药品系数调整.Click += 药品系数调整ToolStripMenuItem_Click;
            // 
            // cmsDurgExcelOpter
            // 
            cmsDurgExcelOpter.BackColor = Color.FromArgb(243, 249, 255);
            cmsDurgExcelOpter.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsDurgExcelOpter.Items.AddRange(new ToolStripItem[] { 药品数据导出, 药品数据导入, 匹配数据导入 });
            cmsDurgExcelOpter.Name = "cmsDurgExcelOpter";
            cmsDurgExcelOpter.Size = new Size(177, 82);
            // 
            // 药品数据导出
            // 
            药品数据导出.Name = "药品数据导出";
            药品数据导出.Size = new Size(176, 26);
            药品数据导出.Text = "药品数据导出";
            药品数据导出.Click += 药品数据导出ToolStripMenuItem_Click;
            // 
            // 药品数据导入
            // 
            药品数据导入.Name = "药品数据导入";
            药品数据导入.Size = new Size(176, 26);
            药品数据导入.Text = "药品数据导入";
            药品数据导入.Click += 药品数据导入ToolStripMenuItem_Click;
            // 
            // 匹配数据导入
            // 
            匹配数据导入.Name = "匹配数据导入";
            匹配数据导入.Size = new Size(176, 26);
            匹配数据导入.Text = "匹配数据导入";
            匹配数据导入.Click += 匹配数据导入ToolStripMenuItem_Click;
            // 
            // btnOpterDurg
            // 
            btnOpterDurg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpterDurg.ContextMenuStrip = cmsOpterDurgData;
            btnOpterDurg.Cursor = Cursors.Hand;
            btnOpterDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpterDurg.Location = new Point(922, 90);
            btnOpterDurg.MinimumSize = new Size(1, 1);
            btnOpterDurg.Name = "btnOpterDurg";
            btnOpterDurg.Radius = 10;
            btnOpterDurg.Size = new Size(180, 35);
            btnOpterDurg.Symbol = 560112;
            btnOpterDurg.TabIndex = 37;
            btnOpterDurg.Text = "操作药品数据";
            btnOpterDurg.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpterDurg.Click += btnOpterDurg_Click;
            // 
            // btnDrugExport
            // 
            btnDrugExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDrugExport.ContextMenuStrip = cmsDurgExcelOpter;
            btnDrugExport.Cursor = Cursors.Hand;
            btnDrugExport.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDrugExport.Location = new Point(1123, 90);
            btnDrugExport.MinimumSize = new Size(1, 1);
            btnDrugExport.Name = "btnDrugExport";
            btnDrugExport.Radius = 10;
            btnDrugExport.Size = new Size(180, 35);
            btnDrugExport.Symbol = 560112;
            btnDrugExport.TabIndex = 38;
            btnDrugExport.Text = "导入导出药品数据";
            btnDrugExport.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDrugExport.Click += brnDrugExport_Click;
            // 
            // FrmDrugManagement
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1326, 656);
            Controls.Add(btnDrugExport);
            Controls.Add(btnOpterDurg);
            Controls.Add(uiPage);
            Controls.Add(btnRefc);
            Controls.Add(dgvList);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(txtKeywords);
            Name = "FrmDrugManagement";
            Padding = new Padding(0, 35, 0, 0);
            RightToLeft = RightToLeft.No;
            ShowTitle = true;
            Style = Sunny.UI.UIStyle.Custom;
            Symbol = 361641;
            Text = "药品管理>>药品信息管理";
            TitleFillColor = SystemColors.GradientInactiveCaption;
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            TitleForeColor = Color.FromArgb(80, 126, 164);
            Load += FrmDrugManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            cmsOpterDurgData.ResumeLayout(false);
            cmsDurgExcelOpter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UITextBox txtKeywords;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnRefc;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIContextMenuStrip cmsOpterDurgData;
        private ToolStripMenuItem 药品系数调整;
        private Sunny.UI.UIContextMenuStrip cmsDurgExcelOpter;
        private ToolStripMenuItem 药品数据导出;
        private ToolStripMenuItem 药品数据导入;
        private ToolStripMenuItem 匹配数据导入;
        private Sunny.UI.UISymbolButton btnOpterDurg;
        private Sunny.UI.UISymbolButton btnDrugExport;
    }
}