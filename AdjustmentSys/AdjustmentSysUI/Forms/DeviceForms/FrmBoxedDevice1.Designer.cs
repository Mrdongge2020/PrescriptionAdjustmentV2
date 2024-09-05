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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvList
            // 
            dgvList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { ParticleOrder, ParCode, ParName, DoseHerb, Dose, Column1, Price, ParticlesNameHIS, ParticlesCodeHIS, BatchNumber });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Red;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.Crimson;
            dgvList.Location = new Point(23, 239);
            dgvList.Name = "dgvList";
            dgvList.RectColor = Color.DodgerBlue;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.Chocolate;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
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
            // FrmBoxedDevice1
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1102, 733);
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
    }
}