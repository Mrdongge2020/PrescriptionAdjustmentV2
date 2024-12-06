namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmPeriodOfValidity
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
            label1 = new Label();
            dateTimeEnd = new Sunny.UI.UIDatePicker();
            btnQuery = new Sunny.UI.UIButton();
            dgvList = new Sunny.UI.UIDataGridView();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            btnSave = new Sunny.UI.UIButton();
            dpSetDateEnd = new Sunny.UI.UIDatePicker();
            label2 = new Label();
            uiLabel1 = new Sunny.UI.UILabel();
            cblisDurg = new Sunny.UI.UIComboBox();
            lblCount = new Sunny.UI.UILabel();
            dateTimeStart = new Sunny.UI.UIDatePicker();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 10.5F);
            label1.Location = new Point(7, 53);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 61;
            label1.Text = "效期 :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimeEnd
            // 
            dateTimeEnd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeEnd.FillColor = Color.White;
            dateTimeEnd.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeEnd.Location = new Point(251, 49);
            dateTimeEnd.Margin = new Padding(4, 5, 4, 5);
            dateTimeEnd.MaxLength = 10;
            dateTimeEnd.MinimumSize = new Size(63, 0);
            dateTimeEnd.Name = "dateTimeEnd";
            dateTimeEnd.Padding = new Padding(0, 0, 30, 2);
            dateTimeEnd.ShowToday = true;
            dateTimeEnd.Size = new Size(150, 29);
            dateTimeEnd.SymbolDropDown = 61555;
            dateTimeEnd.SymbolNormal = 61555;
            dateTimeEnd.SymbolSize = 24;
            dateTimeEnd.TabIndex = 82;
            dateTimeEnd.Text = "2024-07-01";
            dateTimeEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeEnd.Watermark = "";
            // 
            // btnQuery
            // 
            btnQuery.Font = new Font("微软雅黑", 12F);
            btnQuery.Location = new Point(426, 49);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(77, 29);
            btnQuery.TabIndex = 83;
            btnQuery.Text = "查 询";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Click += btnQuery_Click;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(5, 87);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersWidth = 80;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.ShowEditingIcon = false;
            dgvList.Size = new Size(676, 297);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 84;
            dgvList.RowPostPaint += dgvList_RowPostPaint;
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(btnSave);
            uiGroupBox1.Controls.Add(dpSetDateEnd);
            uiGroupBox1.Controls.Add(label2);
            uiGroupBox1.Controls.Add(uiLabel1);
            uiGroupBox1.Controls.Add(cblisDurg);
            uiGroupBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new Point(7, 419);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(676, 87);
            uiGroupBox1.TabIndex = 85;
            uiGroupBox1.Text = "效期调整(不选颗粒默认调整药柜全部颗粒效期)";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.Location = new Point(550, 42);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(77, 29);
            btnSave.TabIndex = 85;
            btnSave.Text = "保 存";
            btnSave.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.Click += btnSave_Click;
            // 
            // dpSetDateEnd
            // 
            dpSetDateEnd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dpSetDateEnd.FillColor = Color.White;
            dpSetDateEnd.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dpSetDateEnd.Location = new Point(371, 42);
            dpSetDateEnd.Margin = new Padding(4, 5, 4, 5);
            dpSetDateEnd.MaxLength = 10;
            dpSetDateEnd.MinimumSize = new Size(63, 0);
            dpSetDateEnd.Name = "dpSetDateEnd";
            dpSetDateEnd.Padding = new Padding(0, 0, 30, 2);
            dpSetDateEnd.ShowToday = true;
            dpSetDateEnd.Size = new Size(150, 29);
            dpSetDateEnd.SymbolDropDown = 61555;
            dpSetDateEnd.SymbolNormal = 61555;
            dpSetDateEnd.SymbolSize = 24;
            dpSetDateEnd.TabIndex = 84;
            dpSetDateEnd.Text = "2024-07-01";
            dpSetDateEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dpSetDateEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dpSetDateEnd.Watermark = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 10.5F);
            label2.Location = new Point(295, 46);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 83;
            label2.Text = "效期至：";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 10.5F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(28, 39);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(68, 32);
            uiLabel1.TabIndex = 5;
            uiLabel1.Text = "颗粒：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cblisDurg
            // 
            cblisDurg.DataSource = null;
            cblisDurg.FillColor = Color.White;
            cblisDurg.FilterIgnoreCase = true;
            cblisDurg.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cblisDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cblisDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cblisDurg.Location = new Point(103, 42);
            cblisDurg.Margin = new Padding(4, 5, 4, 5);
            cblisDurg.MinimumSize = new Size(63, 0);
            cblisDurg.Name = "cblisDurg";
            cblisDurg.Padding = new Padding(0, 0, 30, 2);
            cblisDurg.ShowClearButton = true;
            cblisDurg.ShowFilter = true;
            cblisDurg.Size = new Size(169, 32);
            cblisDurg.SymbolSize = 24;
            cblisDurg.TabIndex = 4;
            cblisDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cblisDurg.Watermark = "";
            // 
            // lblCount
            // 
            lblCount.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCount.ForeColor = Color.FromArgb(48, 48, 48);
            lblCount.Location = new Point(539, 387);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(144, 32);
            lblCount.TabIndex = 86;
            lblCount.Text = "共50条数据";
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimeStart
            // 
            dateTimeStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeStart.FillColor = Color.White;
            dateTimeStart.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeStart.Location = new Point(62, 49);
            dateTimeStart.Margin = new Padding(4, 5, 4, 5);
            dateTimeStart.MaxLength = 10;
            dateTimeStart.MinimumSize = new Size(63, 0);
            dateTimeStart.Name = "dateTimeStart";
            dateTimeStart.Padding = new Padding(0, 0, 30, 2);
            dateTimeStart.ShowToday = true;
            dateTimeStart.Size = new Size(150, 29);
            dateTimeStart.SymbolDropDown = 61555;
            dateTimeStart.SymbolNormal = 61555;
            dateTimeStart.SymbolSize = 24;
            dateTimeStart.TabIndex = 87;
            dateTimeStart.Text = "2024-07-01";
            dateTimeStart.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeStart.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeStart.Watermark = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 10.5F);
            label3.Location = new Point(223, 53);
            label3.Name = "label3";
            label3.Size = new Size(23, 20);
            label3.TabIndex = 88;
            label3.Text = "至";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmPeriodOfValidity
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(687, 516);
            Controls.Add(label3);
            Controls.Add(dateTimeStart);
            Controls.Add(dateTimeEnd);
            Controls.Add(lblCount);
            Controls.Add(uiGroupBox1);
            Controls.Add(dgvList);
            Controls.Add(btnQuery);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPeriodOfValidity";
            Text = "药品效期";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmPeriodOfValidity_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Sunny.UI.UIDatePicker dateTimeEnd;
        private Sunny.UI.UIButton btnQuery;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cblisDurg;
        private Sunny.UI.UIDatePicker dpSetDateEnd;
        private Label label2;
        private Sunny.UI.UIButton btnSave;
        private Sunny.UI.UILabel lblCount;
        private Sunny.UI.UIDatePicker dateTimeStart;
        private Label label3;
    }
}