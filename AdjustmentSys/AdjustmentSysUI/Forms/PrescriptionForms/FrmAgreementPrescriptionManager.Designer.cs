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
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            txtName = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
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
            txtName.Location = new Point(121, 48);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(171, 30);
            txtName.TabIndex = 36;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "协定方名称";
            txtName.WatermarkColor = Color.DimGray;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(17, 52);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(97, 23);
            uiLabel1.TabIndex = 35;
            uiLabel1.Text = "协定方名称:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnQuery
            // 
            btnQuery.Cursor = Cursors.Hand;
            btnQuery.Font = new Font("微软雅黑", 10.5F);
            btnQuery.Location = new Point(312, 48);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Radius = 1;
            btnQuery.Size = new Size(70, 30);
            btnQuery.Symbol = 61473;
            btnQuery.SymbolColor = SystemColors.Window;
            btnQuery.TabIndex = 34;
            btnQuery.Text = "刷新";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Click += btnQuery_Click;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Font = new Font("微软雅黑", 10.5F);
            btnDelete.Location = new Point(598, 48);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.Radius = 1;
            btnDelete.Size = new Size(70, 30);
            btnDelete.Symbol = 559691;
            btnDelete.SymbolColor = SystemColors.Window;
            btnDelete.TabIndex = 33;
            btnDelete.Text = "删除";
            btnDelete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("微软雅黑", 10.5F);
            btnAdd.Location = new Point(400, 48);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 1;
            btnAdd.Size = new Size(70, 30);
            btnAdd.Symbol = 362211;
            btnAdd.TabIndex = 32;
            btnAdd.Text = "新增";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Font = new Font("微软雅黑", 10.5F);
            btnEdit.Location = new Point(503, 48);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Radius = 1;
            btnEdit.Size = new Size(70, 30);
            btnEdit.Symbol = 361741;
            btnEdit.SymbolColor = SystemColors.Window;
            btnEdit.TabIndex = 31;
            btnEdit.Text = "修改";
            btnEdit.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnEdit.Click += btnEdit_Click;
            // 
            // dgvPreDetail
            // 
            dgvPreDetail.AllowUserToAddRows = false;
            dgvPreDetail.AllowUserToDeleteRows = false;
            dgvPreDetail.AllowUserToResizeColumns = false;
            dgvPreDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            dgvPreDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvPreDetail.BackgroundColor = Color.White;
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle22.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle22.ForeColor = Color.White;
            dataGridViewCellStyle22.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle22.SelectionForeColor = Color.White;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            dgvPreDetail.ColumnHeadersHeight = 32;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = SystemColors.Window;
            dataGridViewCellStyle23.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle23.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle23;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(80, 160, 255);
            dgvPreDetail.Location = new Point(575, 84);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle24.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle24.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle24.SelectionForeColor = Color.White;
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle25.BackColor = Color.White;
            dataGridViewCellStyle25.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle25;
            dgvPreDetail.SelectedIndex = -1;
            dgvPreDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreDetail.Size = new Size(557, 461);
            dgvPreDetail.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvPreDetail.TabIndex = 51;
            // 
            // uiPage
            // 
            uiPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiPage.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPage.Location = new Point(2, 552);
            uiPage.Margin = new Padding(4, 5, 4, 5);
            uiPage.MinimumSize = new Size(1, 1);
            uiPage.Name = "uiPage";
            uiPage.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPage.ShowText = false;
            uiPage.Size = new Size(581, 39);
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
            dataGridViewCellStyle26.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle27.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle27.ForeColor = Color.White;
            dataGridViewCellStyle27.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle27.SelectionForeColor = Color.White;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = SystemColors.Window;
            dataGridViewCellStyle28.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle28.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle28.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle28;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 84);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle29.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle29.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle29.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle29.SelectionForeColor = Color.White;
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle30.BackColor = Color.White;
            dataGridViewCellStyle30.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle30;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(570, 461);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 49;
            dgvList.CellClick += dgvList_CellClick;
            dgvList.RowPostPaint += dgvList_RowPostPaint;
            // 
            // btnSetPre
            // 
            btnSetPre.Cursor = Cursors.Hand;
            btnSetPre.Font = new Font("微软雅黑", 10.5F);
            btnSetPre.Location = new Point(695, 48);
            btnSetPre.MinimumSize = new Size(1, 1);
            btnSetPre.Name = "btnSetPre";
            btnSetPre.Radius = 1;
            btnSetPre.Size = new Size(104, 30);
            btnSetPre.Symbol = 361741;
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
            Controls.Add(uiLabel1);
            Controls.Add(btnQuery);
            Controls.Add(dgvList);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Name = "FrmAgreementPrescriptionManager";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 557582;
            Text = "协定方";
            Load += FrmAgreementPrescriptionManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIDataGridView dgvPreDetail;
        private Sunny.UI.UIPagination uiPage;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton btnQuery;
        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UISymbolButton btnSetPre;
    }
}