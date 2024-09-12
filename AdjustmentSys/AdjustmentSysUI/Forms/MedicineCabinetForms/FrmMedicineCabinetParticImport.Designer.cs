namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmMedicineCabinetParticImport
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
            btnConfimImport = new Sunny.UI.UISymbolButton();
            btnOpenExcel = new Sunny.UI.UISymbolButton();
            dgvList = new Sunny.UI.UIDataGridView();
            lblRuler = new Sunny.UI.UILinkLabel();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // btnConfimImport
            // 
            btnConfimImport.Enabled = false;
            btnConfimImport.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Location = new Point(809, 38);
            btnConfimImport.MinimumSize = new Size(1, 1);
            btnConfimImport.Name = "btnConfimImport";
            btnConfimImport.Size = new Size(129, 35);
            btnConfimImport.Symbol = 561595;
            btnConfimImport.TabIndex = 100;
            btnConfimImport.Text = "确认导入";
            btnConfimImport.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfimImport.Click += btnConfimImport_Click;
            // 
            // btnOpenExcel
            // 
            btnOpenExcel.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpenExcel.Location = new Point(25, 37);
            btnOpenExcel.MinimumSize = new Size(1, 1);
            btnOpenExcel.Name = "btnOpenExcel";
            btnOpenExcel.Size = new Size(153, 35);
            btnOpenExcel.Symbol = 61717;
            btnOpenExcel.TabIndex = 99;
            btnOpenExcel.Text = "打开Excel文件";
            btnOpenExcel.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOpenExcel.TipsText = "打开一个excel并在窗口展示数据";
            btnOpenExcel.Click += btnOpenExcel_Click;
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
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(3, 78);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.SelectedIndex = -1;
            dgvList.Size = new Size(1067, 489);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 98;
            // 
            // lblRuler
            // 
            lblRuler.ActiveLinkColor = Color.FromArgb(80, 160, 255);
            lblRuler.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblRuler.ForeColor = Color.Blue;
            lblRuler.LinkBehavior = LinkBehavior.AlwaysUnderline;
            lblRuler.LinkColor = Color.FromArgb(0, 0, 192);
            lblRuler.Location = new Point(958, 50);
            lblRuler.Name = "lblRuler";
            lblRuler.Size = new Size(104, 23);
            lblRuler.TabIndex = 101;
            lblRuler.TabStop = true;
            lblRuler.Text = "查看导入规则";
            lblRuler.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            lblRuler.Click += lblRuler_Click;
            // 
            // FrmMedicineCabinetParticImport
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1073, 570);
            Controls.Add(lblRuler);
            Controls.Add(btnConfimImport);
            Controls.Add(btnOpenExcel);
            Controls.Add(dgvList);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMedicineCabinetParticImport";
            Text = "颗粒位置信息导入";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISymbolButton btnConfimImport;
        private Sunny.UI.UISymbolButton btnOpenExcel;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UILinkLabel lblRuler;
    }
}