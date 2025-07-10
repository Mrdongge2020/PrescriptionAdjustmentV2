namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmAgreementPrescriptionAdd
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
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            dgvFooter = new Sunny.UI.UIDataGridViewFooter();
            dgvDurgList = new Sunny.UI.UIDataGridView();
            ID = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            ParName = new DataGridViewTextBoxColumn();
            ParticlesCodeHIS = new DataGridViewTextBoxColumn();
            DoseHerb = new DataGridViewTextBoxColumn();
            Equivalent = new DataGridViewTextBoxColumn();
            Dose = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            cmsDurg = new Sunny.UI.UIContextMenuStrip();
            removeDurg = new ToolStripMenuItem();
            uiLabel15 = new Sunny.UI.UILabel();
            lbCheckResult = new Sunny.UI.UIListBox();
            dudJL = new Sunny.UI.UIDoubleUpDown();
            uiLabel14 = new Sunny.UI.UILabel();
            uiLabel13 = new Sunny.UI.UILabel();
            cbJLFS = new Sunny.UI.UIComboBox();
            cbDurg = new Sunny.UI.UIComboBox();
            txtRemark = new Sunny.UI.UITextBox();
            txtName = new Sunny.UI.UITextBox();
            btnSaveAggPre = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDurgList).BeginInit();
            cmsDurg.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(btnAdd);
            uiGroupBox2.Controls.Add(dgvFooter);
            uiGroupBox2.Controls.Add(uiLabel15);
            uiGroupBox2.Controls.Add(lbCheckResult);
            uiGroupBox2.Controls.Add(dgvDurgList);
            uiGroupBox2.Controls.Add(dudJL);
            uiGroupBox2.Controls.Add(uiLabel14);
            uiGroupBox2.Controls.Add(uiLabel13);
            uiGroupBox2.Controls.Add(cbJLFS);
            uiGroupBox2.Controls.Add(cbDurg);
            uiGroupBox2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox2.Location = new Point(15, 115);
            uiGroupBox2.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox2.MinimumSize = new Size(1, 1);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox2.Size = new Size(1362, 483);
            uiGroupBox2.TabIndex = 25;
            uiGroupBox2.Text = "添加药品";
            uiGroupBox2.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // dgvFooter
            // 
            dgvFooter.DataGridView = dgvDurgList;
            dgvFooter.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvFooter.Location = new Point(3, 448);
            dgvFooter.MinimumSize = new Size(1, 1);
            dgvFooter.Name = "dgvFooter";
            dgvFooter.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            dgvFooter.Size = new Size(950, 29);
            dgvFooter.TabIndex = 18;
            // 
            // dgvDurgList
            // 
            dgvDurgList.AllowUserToAddRows = false;
            dgvDurgList.AllowUserToDeleteRows = false;
            dgvDurgList.AllowUserToResizeColumns = false;
            dgvDurgList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvDurgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDurgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDurgList.BackgroundColor = Color.White;
            dgvDurgList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDurgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDurgList.ColumnHeadersHeight = 32;
            dgvDurgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDurgList.Columns.AddRange(new DataGridViewColumn[] { ID, Code, ParName, ParticlesCodeHIS, DoseHerb, Equivalent, Dose, Stock, Price, TotalPrice });
            dgvDurgList.ContextMenuStrip = cmsDurg;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDurgList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDurgList.EnableHeadersVisualStyles = false;
            dgvDurgList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDurgList.GridColor = Color.FromArgb(80, 160, 255);
            dgvDurgList.Location = new Point(3, 68);
            dgvDurgList.Name = "dgvDurgList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDurgList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDurgList.RowHeadersWidth = 60;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDurgList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvDurgList.SelectedIndex = -1;
            dgvDurgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDurgList.Size = new Size(950, 380);
            dgvDurgList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvDurgList.TabIndex = 15;
            dgvDurgList.RowPostPaint += dgvDurgList_RowPostPaint;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "主键id";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.SortMode = DataGridViewColumnSortMode.NotSortable;
            ID.Visible = false;
            // 
            // Code
            // 
            Code.DataPropertyName = "Code";
            Code.HeaderText = "颗粒编码";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParName
            // 
            ParName.DataPropertyName = "ParName";
            ParName.HeaderText = "颗粒名称";
            ParName.Name = "ParName";
            ParName.ReadOnly = true;
            ParName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParticlesCodeHIS
            // 
            ParticlesCodeHIS.DataPropertyName = "ParticlesCodeHIS";
            ParticlesCodeHIS.HeaderText = "HIS编码";
            ParticlesCodeHIS.Name = "ParticlesCodeHIS";
            ParticlesCodeHIS.ReadOnly = true;
            ParticlesCodeHIS.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // DoseHerb
            // 
            DoseHerb.DataPropertyName = "DoseHerb";
            DoseHerb.HeaderText = "饮片剂量";
            DoseHerb.Name = "DoseHerb";
            DoseHerb.ReadOnly = true;
            DoseHerb.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Equivalent
            // 
            Equivalent.DataPropertyName = "Equivalent";
            Equivalent.HeaderText = "当量";
            Equivalent.Name = "Equivalent";
            Equivalent.ReadOnly = true;
            Equivalent.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Dose
            // 
            Dose.DataPropertyName = "Dose";
            Dose.HeaderText = "颗粒剂量";
            Dose.Name = "Dose";
            Dose.ReadOnly = true;
            Dose.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Stock
            // 
            Stock.DataPropertyName = "Stock";
            Stock.HeaderText = "库存";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "饮片单价";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalPrice
            // 
            TotalPrice.DataPropertyName = "TotalPrice";
            TotalPrice.HeaderText = "饮片总价";
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            TotalPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsDurg
            // 
            cmsDurg.BackColor = Color.FromArgb(243, 249, 255);
            cmsDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsDurg.Items.AddRange(new ToolStripItem[] { removeDurg });
            cmsDurg.Name = "cmsDurg";
            cmsDurg.Size = new Size(107, 26);
            // 
            // removeDurg
            // 
            removeDurg.Name = "removeDurg";
            removeDurg.Size = new Size(106, 22);
            removeDurg.Text = "移除";
            removeDurg.Click += removeDurg_Click;
            // 
            // uiLabel15
            // 
            uiLabel15.Font = new Font("微软雅黑", 12F);
            uiLabel15.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel15.Location = new Point(960, 37);
            uiLabel15.Name = "uiLabel15";
            uiLabel15.Size = new Size(133, 23);
            uiLabel15.TabIndex = 17;
            uiLabel15.Text = "处方分析:";
            uiLabel15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCheckResult
            // 
            lbCheckResult.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbCheckResult.HoverColor = Color.FromArgb(155, 200, 255);
            lbCheckResult.ItemSelectForeColor = Color.White;
            lbCheckResult.Location = new Point(960, 68);
            lbCheckResult.Margin = new Padding(4, 5, 4, 5);
            lbCheckResult.MinimumSize = new Size(1, 1);
            lbCheckResult.Name = "lbCheckResult";
            lbCheckResult.Padding = new Padding(2);
            lbCheckResult.ShowText = false;
            lbCheckResult.Size = new Size(398, 410);
            lbCheckResult.TabIndex = 16;
            lbCheckResult.Text = "uiListBox1";
            // 
            // dudJL
            // 
            dudJL.DecimalPlaces = 2;
            dudJL.Font = new Font("微软雅黑", 12F);
            dudJL.Location = new Point(612, 31);
            dudJL.Margin = new Padding(4, 5, 4, 5);
            dudJL.Maximum = 100000D;
            dudJL.Minimum = 0D;
            dudJL.MinimumSize = new Size(100, 0);
            dudJL.Name = "dudJL";
            dudJL.ShowText = false;
            dudJL.Size = new Size(116, 29);
            dudJL.TabIndex = 13;
            dudJL.Text = null;
            dudJL.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel14
            // 
            uiLabel14.Font = new Font("微软雅黑", 12F);
            uiLabel14.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel14.Location = new Point(531, 34);
            uiLabel14.Name = "uiLabel14";
            uiLabel14.Size = new Size(77, 23);
            uiLabel14.TabIndex = 12;
            uiLabel14.Text = "剂量:";
            uiLabel14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel13
            // 
            uiLabel13.Font = new Font("微软雅黑", 12F);
            uiLabel13.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel13.Location = new Point(224, 34);
            uiLabel13.Name = "uiLabel13";
            uiLabel13.Size = new Size(113, 23);
            uiLabel13.TabIndex = 10;
            uiLabel13.Text = "剂量方式:";
            uiLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbJLFS
            // 
            cbJLFS.DataSource = null;
            cbJLFS.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbJLFS.FillColor = Color.White;
            cbJLFS.Font = new Font("微软雅黑", 12F);
            cbJLFS.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbJLFS.Items.AddRange(new object[] { "饮片剂量", "颗粒剂量" });
            cbJLFS.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbJLFS.Location = new Point(350, 31);
            cbJLFS.Margin = new Padding(4, 5, 4, 5);
            cbJLFS.MinimumSize = new Size(63, 0);
            cbJLFS.Name = "cbJLFS";
            cbJLFS.Padding = new Padding(0, 0, 30, 2);
            cbJLFS.Size = new Size(126, 29);
            cbJLFS.SymbolSize = 24;
            cbJLFS.TabIndex = 11;
            cbJLFS.Text = "饮片剂量";
            cbJLFS.TextAlignment = ContentAlignment.MiddleLeft;
            cbJLFS.Watermark = "";
            // 
            // cbDurg
            // 
            cbDurg.DataSource = null;
            cbDurg.FillColor = Color.White;
            cbDurg.FilterIgnoreCase = true;
            cbDurg.Font = new Font("微软雅黑", 12F);
            cbDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDurg.Location = new Point(15, 31);
            cbDurg.Margin = new Padding(4, 5, 4, 5);
            cbDurg.MinimumSize = new Size(63, 0);
            cbDurg.Name = "cbDurg";
            cbDurg.Padding = new Padding(0, 0, 30, 2);
            cbDurg.ShowClearButton = true;
            cbDurg.ShowFilter = true;
            cbDurg.Size = new Size(190, 29);
            cbDurg.SymbolSize = 24;
            cbDurg.TabIndex = 2;
            cbDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cbDurg.Watermark = "请选择药品";
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("微软雅黑", 12F);
            txtRemark.Location = new Point(330, 60);
            txtRemark.Margin = new Padding(4, 5, 4, 5);
            txtRemark.MaxLength = 200;
            txtRemark.MinimumSize = new Size(1, 16);
            txtRemark.Name = "txtRemark";
            txtRemark.Padding = new Padding(5);
            txtRemark.ShowText = false;
            txtRemark.Size = new Size(411, 29);
            txtRemark.TabIndex = 29;
            txtRemark.TextAlignment = ContentAlignment.MiddleLeft;
            txtRemark.Watermark = "请输入备注";
            // 
            // txtName
            // 
            txtName.Font = new Font("微软雅黑", 12F);
            txtName.Location = new Point(13, 63);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 20;
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(290, 29);
            txtName.TabIndex = 27;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入协定方名称";
            // 
            // btnSaveAggPre
            // 
            btnSaveAggPre.Cursor = Cursors.Hand;
            btnSaveAggPre.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSaveAggPre.Location = new Point(770, 54);
            btnSaveAggPre.MinimumSize = new Size(1, 1);
            btnSaveAggPre.Name = "btnSaveAggPre";
            btnSaveAggPre.Radius = 10;
            btnSaveAggPre.Size = new Size(130, 35);
            btnSaveAggPre.Symbol = 557713;
            btnSaveAggPre.TabIndex = 117;
            btnSaveAggPre.Text = "提交协定方";
            btnSaveAggPre.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSaveAggPre.Click += btnSaveAggPre_Click;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Location = new Point(755, 28);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Radius = 10;
            btnAdd.Size = new Size(130, 35);
            btnAdd.Symbol = 557672;
            btnAdd.TabIndex = 118;
            btnAdd.Text = "添加药品";
            btnAdd.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnAdd.Click += btnAdd_Click;
            // 
            // FrmAgreementPrescriptionAdd
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1394, 610);
            Controls.Add(btnSaveAggPre);
            Controls.Add(txtRemark);
            Controls.Add(txtName);
            Controls.Add(uiGroupBox2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAgreementPrescriptionAdd";
            Text = "新建协定方";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmAgreementPrescriptionAdd_Load;
            uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDurgList).EndInit();
            cmsDurg.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIDataGridViewFooter dgvFooter;
        private Sunny.UI.UIDataGridView dgvDurgList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ParName;
        private DataGridViewTextBoxColumn ParticlesCodeHIS;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn DoseHerb;
        private DataGridViewTextBoxColumn Equivalent;
        private DataGridViewTextBoxColumn Dose;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn TotalPrice;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UIListBox lbCheckResult;
        private Sunny.UI.UIDoubleUpDown dudJL;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UIComboBox cbJLFS;
        private Sunny.UI.UIComboBox cbDurg;
        private Sunny.UI.UITextBox txtRemark;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UIContextMenuStrip cmsDurg;
        private ToolStripMenuItem removeDurg;
        private Sunny.UI.UISymbolButton btnSaveAggPre;
        private Sunny.UI.UISymbolButton btnAdd;
    }
}