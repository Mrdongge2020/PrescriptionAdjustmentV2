namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmAgreementPrescriptionManager
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
            txtName = new Sunny.UI.UITextBox();
            btnQuery = new Sunny.UI.UISymbolButton();
            btnDelete = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnEdit = new Sunny.UI.UISymbolButton();
            dgvPreDetail = new Sunny.UI.UIDataGridView();
            uiPage = new Sunny.UI.UIPagination();
            dgvList = new Sunny.UI.UIDataGridView();
            btnSetPre = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("微软雅黑", 12F);
            txtName.Location = new Point(10, 50);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(213, 30);
            txtName.TabIndex = 36;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入协定方名称";
            // 
            // btnQuery
            // 
            btnQuery.Cursor = Cursors.Hand;
            btnQuery.Font = new Font("微软雅黑", 10.5F);
            btnQuery.Location = new Point(249, 48);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Radius = 10;
            btnQuery.Size = new Size(90, 35);
            btnQuery.Symbol = 61442;
            btnQuery.SymbolColor = SystemColors.Window;
            btnQuery.TabIndex = 34;
            btnQuery.Text = "查 询";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Click += btnQuery_Click;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("微软雅黑", 10.5F);
            btnDelete.Location = new Point(597, 48);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Radius = 10;
            btnDelete.Size = new Size(90, 35);
            btnDelete.Symbol = 559691;
            btnDelete.SymbolColor = SystemColors.Window;
            btnDelete.TabIndex = 33;
            btnDelete.Text = "删 除";
            btnDelete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("微软雅黑", 10.5F);
            btnAdd.Location = new Point(365, 48);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 10;
            btnAdd.Size = new Size(90, 35);
            btnAdd.Symbol = 557672;
            btnAdd.TabIndex = 32;
            btnAdd.Text = "新 增";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("微软雅黑", 10.5F);
            btnEdit.Location = new Point(482, 48);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Radius = 10;
            btnEdit.Size = new Size(90, 35);
            btnEdit.Symbol = 61508;
            btnEdit.SymbolColor = SystemColors.Window;
            btnEdit.TabIndex = 31;
            btnEdit.Text = "修 改";
            btnEdit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Click += btnEdit_Click;
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
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvPreDetail.ColumnHeadersHeight = 32;
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
            dgvPreDetail.Location = new Point(572, 98);
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
            dgvPreDetail.Size = new Size(557, 447);
            dgvPreDetail.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.TabIndex = 51;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.FillColor = Color.White;
            uiPage.FillColor2 = Color.White;
            uiPage.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(10, 552);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.Radius = 10;
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(1119, 35);
            uiPage.Style = Sunny.UI.UIStyle.Custom;
            uiPage.TabIndex = 50;
            uiPage.Text = "uiPagination1";
            uiPage.TextAlignment = ContentAlignment.MiddleCenter;
            uiPage.PageChanged += uiPage_PageChanged;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
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
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            dgvList.Location = new Point(10, 98);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle19.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle19.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle19.SelectionForeColor = Color.White;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle20;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(560, 447);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 49;
            dgvList.CellClick += dgvList_CellClick;
            dgvList.RowPostPaint += dgvList_RowPostPaint;
            // 
            // btnSetPre
            // 
            btnSetPre.Cursor = Cursors.Hand;
            btnSetPre.Font = new Font("微软雅黑", 10.5F);
            btnSetPre.Location = new Point(713, 48);
            btnSetPre.MinimumSize = new Size(1, 1);
            btnSetPre.Name = "btnSetPre";
            btnSetPre.Radius = 10;
            btnSetPre.Size = new Size(120, 35);
            btnSetPre.Symbol = 557713;
            btnSetPre.SymbolColor = SystemColors.Window;
            btnSetPre.TabIndex = 52;
            btnSetPre.Text = "生成处方";
            btnSetPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetPre.Click += btnSetPre_Click;
            // 
            // FrmAgreementPrescriptionManager
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1135, 602);
            Controls.Add(btnSetPre);
            Controls.Add(txtName);
            Controls.Add(dgvPreDetail);
            Controls.Add(uiPage);
            Controls.Add(btnQuery);
            Controls.Add(dgvList);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Name = "FrmAgreementPrescriptionManager";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "处方管理>>协定方管理";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Load += FrmAgreementPrescriptionManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIDataGridView dgvPreDetail;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UISymbolButton btnQuery;
        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UISymbolButton btnSetPre;
    }
}