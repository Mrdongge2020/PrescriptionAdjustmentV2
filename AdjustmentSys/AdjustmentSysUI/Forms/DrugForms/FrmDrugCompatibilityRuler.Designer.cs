﻿namespace AdjustmentSysUI.Forms.Drug
{
    partial class FrmDrugCompatibilityRuler
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            btnDelete = new Sunny.UI.UISymbolButton();
            uiPage = new Sunny.UI.UIPagination();
            dgvList = new Sunny.UI.UIDataGridView();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnEdit = new Sunny.UI.UISymbolButton();
            btnRefc = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Location = new Point(227, 50);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Radius = 10;
            btnDelete.Size = new Size(90, 35);
            btnDelete.Symbol = 559691;
            btnDelete.SymbolColor = SystemColors.Window;
            btnDelete.TabIndex = 22;
            btnDelete.Text = "删 除";
            btnDelete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Click += btnDelete_Click;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.FillColor = Color.White;
            uiPage.FillColor2 = Color.White;
            uiPage.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(10, 554);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.Radius = 10;
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1077, 35);
            uiPage.Style = Sunny.UI.UIStyle.Custom;
            uiPage.TabIndex = 21;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
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
            dataGridViewCellStyle7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle8;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(10, 91);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvList.RowHeadersVisible = false;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(1077, 455);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 20;
            dgvList.CellClick += dgvList_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Location = new Point(10, 50);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 10;
            btnAdd.Size = new Size(90, 35);
            btnAdd.Symbol = 557672;
            btnAdd.TabIndex = 19;
            btnAdd.Text = "新 增";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Location = new Point(116, 50);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Radius = 10;
            btnEdit.Size = new Size(90, 35);
            btnEdit.Symbol = 61508;
            btnEdit.SymbolColor = SystemColors.Window;
            btnEdit.TabIndex = 18;
            btnEdit.Text = "修 改";
            btnEdit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRefc
            // 
            btnRefc.Cursor = Cursors.Hand;
            btnRefc.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Location = new Point(337, 50);
            btnRefc.MinimumSize = new Size(1, 1);
            btnRefc.Name = "btnRefc";
            btnRefc.Radius = 10;
            btnRefc.Size = new Size(90, 35);
            btnRefc.Symbol = 61473;
            btnRefc.SymbolColor = SystemColors.Window;
            btnRefc.TabIndex = 27;
            btnRefc.Text = "刷 新";
            btnRefc.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnRefc.Click += btnRefc_Click;
            // 
            // FrmDrugCompatibilityRuler
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1095, 616);
            Controls.Add(btnRefc);
            Controls.Add(btnDelete);
            Controls.Add(uiPage);
            Controls.Add(dgvList);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Name = "FrmDrugCompatibilityRuler";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Style = Sunny.UI.UIStyle.Custom;
            Symbol = 361641;
            Text = "药品管理>>药品相容规则管理";
            TitleFillColor = Color.FromArgb(243, 249, 255);
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            TitleForeColor = Color.FromArgb(80, 126, 164);
            Load += FrmDrugCompatibilityRuler_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnRefc;
    }
}