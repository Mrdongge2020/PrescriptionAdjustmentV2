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
            btnOpterDropDown = new Sunny.UI.UISymbolLabel();
            brnDrugExport = new Sunny.UI.UISymbolLabel();
            cmsOpterDurgData = new Sunny.UI.UIContextMenuStrip();
            药品系数调整ToolStripMenuItem = new ToolStripMenuItem();
            cmsDurgExcelOpter = new Sunny.UI.UIContextMenuStrip();
            药品数据导出ToolStripMenuItem = new ToolStripMenuItem();
            药品数据导入ToolStripMenuItem = new ToolStripMenuItem();
            匹配数据导入ToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            cmsOpterDurgData.SuspendLayout();
            cmsDurgExcelOpter.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Location = new Point(216, 89);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Radius = 1;
            btnDelete.Size = new Size(70, 30);
            btnDelete.Symbol = 559691;
            btnDelete.SymbolColor = SystemColors.Window;
            btnDelete.TabIndex = 26;
            btnDelete.Text = "删除";
            btnDelete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Location = new Point(422, 46);
            btnReset.MinimumSize = new Size(1, 1);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(72, 33);
            btnReset.Symbol = 561695;
            btnReset.TabIndex = 25;
            btnReset.Text = "重置";
            btnReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnReset.Click += btnReset_Click;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Location = new Point(6, 89);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 1;
            btnAdd.Size = new Size(70, 30);
            btnAdd.Symbol = 362211;
            btnAdd.TabIndex = 22;
            btnAdd.Text = "新增";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Location = new Point(107, 89);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Radius = 1;
            btnEdit.Size = new Size(70, 30);
            btnEdit.Symbol = 361741;
            btnEdit.SymbolColor = SystemColors.Window;
            btnEdit.TabIndex = 21;
            btnEdit.Text = "修改";
            btnEdit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Location = new Point(320, 46);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(72, 33);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 20;
            btnSearch.Text = "查询";
            btnSearch.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeywords
            // 
            txtKeywords.Cursor = Cursors.IBeam;
            txtKeywords.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtKeywords.Location = new Point(6, 46);
            txtKeywords.Margin = new Padding(4, 5, 4, 5);
            txtKeywords.MinimumSize = new Size(1, 16);
            txtKeywords.Name = "txtKeywords";
            txtKeywords.Padding = new Padding(5);
            txtKeywords.ShowText = false;
            txtKeywords.Size = new Size(265, 30);
            txtKeywords.TabIndex = 19;
            txtKeywords.TextAlignment = ContentAlignment.MiddleLeft;
            txtKeywords.TouchPressClick = true;
            txtKeywords.Watermark = "药品名称/拼音码简称";
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
            dgvList.Location = new Point(5, 125);
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
            dgvList.Size = new Size(1317, 476);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 27;
            dgvList.ZoomScaleDisabled = true;
            dgvList.CellClick += dgvList_CellClick;
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(320, 89);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 1;
            btnRefc.Size = new Size(70, 30);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 30;
            btnRefc.Text = "刷新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(6, 609);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(591, 46);
            uiPage.TabIndex = 31;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // btnOpterDropDown
            // 
            btnOpterDropDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpterDropDown.Font = new Font("微软雅黑", 12F);
            btnOpterDropDown.Location = new Point(991, 84);
            btnOpterDropDown.MinimumSize = new Size(1, 1);
            btnOpterDropDown.Name = "btnOpterDropDown";
            btnOpterDropDown.Size = new Size(151, 35);
            btnOpterDropDown.Symbol = 560112;
            btnOpterDropDown.SymbolColor = Color.Blue;
            btnOpterDropDown.TabIndex = 35;
            btnOpterDropDown.Text = "操作药品数据";
            btnOpterDropDown.Click += btnOpterDropDown_Click;
            // 
            // brnDrugExport
            // 
            brnDrugExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            brnDrugExport.Font = new Font("微软雅黑", 12F);
            brnDrugExport.Location = new Point(1163, 84);
            brnDrugExport.MinimumSize = new Size(1, 1);
            brnDrugExport.Name = "brnDrugExport";
            brnDrugExport.Size = new Size(151, 35);
            brnDrugExport.Symbol = 560112;
            brnDrugExport.SymbolColor = Color.Blue;
            brnDrugExport.TabIndex = 36;
            brnDrugExport.Text = "导入导出药品数据";
            brnDrugExport.Click += brnDrugExport_Click;
            // 
            // cmsOpterDurgData
            // 
            cmsOpterDurgData.BackColor = Color.FromArgb(243, 249, 255);
            cmsOpterDurgData.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsOpterDurgData.Items.AddRange(new ToolStripItem[] { 药品系数调整ToolStripMenuItem });
            cmsOpterDurgData.Name = "cmsOpterDurgData";
            cmsOpterDurgData.Size = new Size(174, 30);
            // 
            // 药品系数调整ToolStripMenuItem
            // 
            药品系数调整ToolStripMenuItem.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            药品系数调整ToolStripMenuItem.Name = "药品系数调整ToolStripMenuItem";
            药品系数调整ToolStripMenuItem.Size = new Size(173, 26);
            药品系数调整ToolStripMenuItem.Text = "药品系数调整";
            // 
            // cmsDurgExcelOpter
            // 
            cmsDurgExcelOpter.BackColor = Color.FromArgb(243, 249, 255);
            cmsDurgExcelOpter.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsDurgExcelOpter.Items.AddRange(new ToolStripItem[] { 药品数据导出ToolStripMenuItem, 药品数据导入ToolStripMenuItem, 匹配数据导入ToolStripMenuItem });
            cmsDurgExcelOpter.Name = "cmsDurgExcelOpter";
            cmsDurgExcelOpter.Size = new Size(177, 82);
            // 
            // 药品数据导出ToolStripMenuItem
            // 
            药品数据导出ToolStripMenuItem.Name = "药品数据导出ToolStripMenuItem";
            药品数据导出ToolStripMenuItem.Size = new Size(176, 26);
            药品数据导出ToolStripMenuItem.Text = "药品数据导出";
            药品数据导出ToolStripMenuItem.Click += 药品数据导出ToolStripMenuItem_Click;
            // 
            // 药品数据导入ToolStripMenuItem
            // 
            药品数据导入ToolStripMenuItem.Name = "药品数据导入ToolStripMenuItem";
            药品数据导入ToolStripMenuItem.Size = new Size(176, 26);
            药品数据导入ToolStripMenuItem.Text = "药品数据导入";
            药品数据导入ToolStripMenuItem.Click += 药品数据导入ToolStripMenuItem_Click;
            // 
            // 匹配数据导入ToolStripMenuItem
            // 
            匹配数据导入ToolStripMenuItem.Name = "匹配数据导入ToolStripMenuItem";
            匹配数据导入ToolStripMenuItem.Size = new Size(176, 26);
            匹配数据导入ToolStripMenuItem.Text = "匹配数据导入";
            匹配数据导入ToolStripMenuItem.Click += 匹配数据导入ToolStripMenuItem_Click;
            // 
            // FrmDrugManagement
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1326, 656);
            Controls.Add(brnDrugExport);
            Controls.Add(btnOpterDropDown);
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
            Symbol = 363462;
            Text = "药品信息";
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
        private Sunny.UI.UISymbolLabel btnOpterDropDown;
        private Sunny.UI.UISymbolLabel brnDrugExport;
        private Sunny.UI.UIContextMenuStrip cmsOpterDurgData;
        private ToolStripMenuItem 药品系数调整ToolStripMenuItem;
        private Sunny.UI.UIContextMenuStrip cmsDurgExcelOpter;
        private ToolStripMenuItem 药品数据导出ToolStripMenuItem;
        private ToolStripMenuItem 药品数据导入ToolStripMenuItem;
        private ToolStripMenuItem 匹配数据导入ToolStripMenuItem;
    }
}