namespace AdjustmentSysUI.Forms.DeviceForms
{
    partial class FrmBoxedDevice1
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
            dgvList = new Sunny.UI.UIDataGridView();
            ParticleOrder = new DataGridViewTextBoxColumn();
            ParCode = new DataGridViewTextBoxColumn();
            ParName = new DataGridViewTextBoxColumn();
            DoseHerb = new DataGridViewTextBoxColumn();
            Dose = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            ParticlesNameHIS = new DataGridViewTextBoxColumn();
            ParticlesCodeHIS = new DataGridViewTextBoxColumn();
            BatchNumber = new DataGridViewTextBoxColumn();
            uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            uiNavBar1 = new Sunny.UI.UINavBar();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvList
            // 
            dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = Color.White;
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle12.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = Color.Black;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { ParticleOrder, ParCode, ParName, DoseHerb, Dose, Column1, Price, ParticlesNameHIS, ParticlesCodeHIS, BatchNumber });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.Red;
            dataGridViewCellStyle13.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle13.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle13.SelectionBackColor = Color.White;
            dataGridViewCellStyle13.SelectionForeColor = Color.Black;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle13;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.Crimson;
            dgvList.Location = new Point(23, 239);
            dgvList.Name = "dgvList";
            dgvList.RectColor = Color.DodgerBlue;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle14.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle14.SelectionForeColor = Color.White;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = Color.Chocolate;
            dataGridViewCellStyle15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dgvList.RowTemplate.DefaultCellStyle.BackColor = Color.BurlyWood;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(973, 259);
            dgvList.StripeEvenColor = Color.Chocolate;
            dgvList.StripeOddColor = Color.White;
            dgvList.TabIndex = 27;
            // 
            // ParticleOrder
            // 
            ParticleOrder.FillWeight = 60F;
            ParticleOrder.HeaderText = "序号";
            ParticleOrder.Name = "ParticleOrder";
            ParticleOrder.ReadOnly = true;
            ParticleOrder.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParCode
            // 
            ParCode.HeaderText = "颗粒编码";
            ParCode.Name = "ParCode";
            ParCode.ReadOnly = true;
            ParCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParName
            // 
            ParName.HeaderText = "颗粒名称";
            ParName.Name = "ParName";
            ParName.ReadOnly = true;
            ParName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // DoseHerb
            // 
            DoseHerb.HeaderText = "饮片剂量";
            DoseHerb.Name = "DoseHerb";
            DoseHerb.ReadOnly = true;
            DoseHerb.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Dose
            // 
            Dose.HeaderText = "颗粒剂量";
            Dose.Name = "Dose";
            Dose.ReadOnly = true;
            Dose.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            Column1.HeaderText = "当量";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            Price.HeaderText = "单价";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParticlesNameHIS
            // 
            ParticlesNameHIS.HeaderText = "HIS颗粒名称";
            ParticlesNameHIS.Name = "ParticlesNameHIS";
            ParticlesNameHIS.ReadOnly = true;
            ParticlesNameHIS.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParticlesCodeHIS
            // 
            ParticlesCodeHIS.HeaderText = "HIS颗粒编码";
            ParticlesCodeHIS.Name = "ParticlesCodeHIS";
            ParticlesCodeHIS.ReadOnly = true;
            ParticlesCodeHIS.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // BatchNumber
            // 
            BatchNumber.HeaderText = "批号";
            BatchNumber.Name = "BatchNumber";
            BatchNumber.ReadOnly = true;
            BatchNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // uiContextMenuStrip1
            // 
            uiContextMenuStrip1.BackColor = Color.FromArgb(243, 249, 255);
            uiContextMenuStrip1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            uiContextMenuStrip1.Size = new Size(61, 4);
            // 
            // uiNavBar1
            // 
            uiNavBar1.Dock = DockStyle.Top;
            uiNavBar1.DropMenuFont = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiNavBar1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiNavBar1.Location = new Point(0, 35);
            uiNavBar1.Name = "uiNavBar1";
            uiNavBar1.Size = new Size(1102, 54);
            uiNavBar1.TabIndex = 29;
            uiNavBar1.Text = "uiNavBar1";
            // 
            // FrmBoxedDevice1
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1102, 733);
            Controls.Add(uiNavBar1);
            Controls.Add(dgvList);
            Name = "FrmBoxedDevice1";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "FrmBoxedDevice1";
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDataGridView dgvList;
        private DataGridViewTextBoxColumn ParticleOrder;
        private DataGridViewTextBoxColumn ParCode;
        private DataGridViewTextBoxColumn ParName;
        private DataGridViewTextBoxColumn DoseHerb;
        private DataGridViewTextBoxColumn Dose;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn ParticlesNameHIS;
        private DataGridViewTextBoxColumn ParticlesCodeHIS;
        private DataGridViewTextBoxColumn BatchNumber;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UINavBar uiNavBar1;
    }
}