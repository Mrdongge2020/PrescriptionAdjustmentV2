namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmDataStatistics
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
            cbfp = new Sunny.UI.UIComboBox();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
            dgvUsedList = new Sunny.UI.UIDataGridView();
            ParticleName = new DataGridViewTextBoxColumn();
            UseAmount = new DataGridViewTextBoxColumn();
            UseCount = new DataGridViewTextBoxColumn();
            btnQuery = new Sunny.UI.UISymbolButton();
            dateTimeEnd = new Sunny.UI.UIDatePicker();
            dateTimeStart = new Sunny.UI.UIDatePicker();
            label3 = new Label();
            uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsedList).BeginInit();
            SuspendLayout();
            // 
            // cbfp
            // 
            cbfp.DataSource = null;
            cbfp.FillColor = Color.White;
            cbfp.FilterIgnoreCase = true;
            cbfp.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbfp.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbfp.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbfp.Location = new Point(10, 50);
            cbfp.Margin = new Padding(4, 5, 4, 5);
            cbfp.MinimumSize = new Size(63, 0);
            cbfp.Name = "cbfp";
            cbfp.Padding = new Padding(0, 0, 30, 2);
            cbfp.ShowClearButton = true;
            cbfp.ShowFilter = true;
            cbfp.Size = new Size(170, 29);
            cbfp.SymbolSize = 24;
            cbfp.TabIndex = 106;
            cbfp.TextAlignment = ContentAlignment.MiddleLeft;
            cbfp.TrimFilter = true;
            cbfp.Watermark = "请选择药品";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uiGroupBox1.Controls.Add(uiDataGridViewFooter1);
            uiGroupBox1.Controls.Add(dgvUsedList);
            uiGroupBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new Point(10, 89);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(385, 522);
            uiGroupBox1.TabIndex = 113;
            uiGroupBox1.Text = "药品使用数据统计";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiDataGridViewFooter1
            // 
            uiDataGridViewFooter1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiDataGridViewFooter1.DataGridView = null;
            uiDataGridViewFooter1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDataGridViewFooter1.Location = new Point(5, 480);
            uiDataGridViewFooter1.MinimumSize = new Size(1, 1);
            uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
            uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            uiDataGridViewFooter1.Size = new Size(375, 34);
            uiDataGridViewFooter1.TabIndex = 1;
            uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
            // 
            // dgvUsedList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvUsedList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsedList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsedList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsedList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsedList.BackgroundColor = Color.White;
            dgvUsedList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsedList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsedList.ColumnHeadersHeight = 32;
            dgvUsedList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsedList.Columns.AddRange(new DataGridViewColumn[] { ParticleName, UseAmount, UseCount });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvUsedList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvUsedList.EnableHeadersVisualStyles = false;
            dgvUsedList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvUsedList.GridColor = Color.FromArgb(80, 160, 255);
            dgvUsedList.Location = new Point(5, 35);
            dgvUsedList.Name = "dgvUsedList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvUsedList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvUsedList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvUsedList.SelectedIndex = -1;
            dgvUsedList.Size = new Size(375, 442);
            dgvUsedList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvUsedList.TabIndex = 0;
            dgvUsedList.RowPostPaint += dgvUsedList_RowPostPaint;
            // 
            // ParticleName
            // 
            ParticleName.DataPropertyName = "ParticleName";
            ParticleName.HeaderText = "药品名称";
            ParticleName.Name = "ParticleName";
            ParticleName.ReadOnly = true;
            ParticleName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // UseAmount
            // 
            UseAmount.DataPropertyName = "UseAmount";
            UseAmount.HeaderText = "使用量";
            UseAmount.Name = "UseAmount";
            UseAmount.ReadOnly = true;
            // 
            // UseCount
            // 
            UseCount.DataPropertyName = "UseCount";
            UseCount.HeaderText = "使用次数";
            UseCount.Name = "UseCount";
            UseCount.ReadOnly = true;
            // 
            // btnQuery
            // 
            btnQuery.Cursor = Cursors.Hand;
            btnQuery.Font = new Font("宋体", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Location = new Point(573, 47);
            btnQuery.MinimumSize = new Size(1, 1);
            btnQuery.Name = "btnQuery";
            btnQuery.Radius = 10;
            btnQuery.Size = new Size(90, 35);
            btnQuery.Symbol = 61442;
            btnQuery.TabIndex = 114;
            btnQuery.Text = "查 询";
            btnQuery.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Click += btnQuery_Click;
            // 
            // dateTimeEnd
            // 
            dateTimeEnd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeEnd.FillColor = Color.White;
            dateTimeEnd.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeEnd.Location = new Point(395, 50);
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
            dateTimeEnd.TabIndex = 109;
            dateTimeEnd.Text = "2024-07-01";
            dateTimeEnd.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeEnd.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeEnd.Watermark = "";
            // 
            // dateTimeStart
            // 
            dateTimeStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dateTimeStart.FillColor = Color.White;
            dateTimeStart.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dateTimeStart.Location = new Point(201, 50);
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
            dateTimeStart.TabIndex = 110;
            dateTimeStart.Text = "2024-07-01";
            dateTimeStart.TextAlignment = ContentAlignment.MiddleLeft;
            dateTimeStart.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dateTimeStart.Watermark = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 10.5F);
            label3.Location = new Point(363, 54);
            label3.Name = "label3";
            label3.Size = new Size(23, 20);
            label3.TabIndex = 111;
            label3.Text = "至";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmDataStatistics
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1212, 616);
            Controls.Add(btnQuery);
            Controls.Add(uiGroupBox1);
            Controls.Add(label3);
            Controls.Add(dateTimeStart);
            Controls.Add(dateTimeEnd);
            Controls.Add(cbfp);
            Name = "FrmDataStatistics";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Style = Sunny.UI.UIStyle.Custom;
            Symbol = 361641;
            Text = "药柜管理>>数据统计";
            TitleFillColor = Color.FromArgb(243, 249, 255);
            TitleForeColor = Color.FromArgb(80, 126, 164);
            uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsedList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Sunny.UI.UIComboBox cbfp;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIDataGridView dgvUsedList;
        private DataGridViewTextBoxColumn ParticleName;
        private DataGridViewTextBoxColumn UseAmount;
        private DataGridViewTextBoxColumn UseCount;
        private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
        private Sunny.UI.UISymbolButton btnQuery;
        private Sunny.UI.UIDatePicker dateTimeEnd;
        private Sunny.UI.UIDatePicker dateTimeStart;
        private Label label3;
    }
}