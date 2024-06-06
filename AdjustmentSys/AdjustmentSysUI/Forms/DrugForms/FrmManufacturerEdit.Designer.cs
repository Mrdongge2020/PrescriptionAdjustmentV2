namespace AdjustmentSysUI.Forms.Drug
{
    partial class FrmManufacturerEdit
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
            uiLabel1 = new Sunny.UI.UILabel();
            txtMC = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            iudSort = new Sunny.UI.UIIntegerUpDown();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 208);
            pnlBtm.Size = new Size(539, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(411, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(296, 12);
            btnOK.Click += btnOK_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(36, 132);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(99, 23);
            uiLabel1.TabIndex = 47;
            uiLabel1.Text = "厂家名称：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMC
            // 
            txtMC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMC.Location = new Point(156, 132);
            txtMC.Margin = new Padding(4, 5, 4, 5);
            txtMC.MaxLength = 50;
            txtMC.MinimumSize = new Size(1, 16);
            txtMC.Name = "txtMC";
            txtMC.Padding = new Padding(5);
            txtMC.ShowText = false;
            txtMC.Size = new Size(287, 29);
            txtMC.TabIndex = 48;
            txtMC.TextAlignment = ContentAlignment.MiddleLeft;
            txtMC.Watermark = "请输入厂家名称";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(36, 76);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(99, 23);
            uiLabel2.TabIndex = 49;
            uiLabel2.Text = "序号：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // iudSort
            // 
            iudSort.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudSort.Location = new Point(156, 76);
            iudSort.Margin = new Padding(4, 5, 4, 5);
            iudSort.MinimumSize = new Size(100, 0);
            iudSort.Name = "iudSort";
            iudSort.ShowText = false;
            iudSort.Size = new Size(116, 29);
            iudSort.TabIndex = 50;
            iudSort.Text = "uiIntegerUpDown1";
            iudSort.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FrmManufacturerEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(541, 266);
            Controls.Add(iudSort);
            Controls.Add(uiLabel2);
            Controls.Add(txtMC);
            Controls.Add(uiLabel1);
            Name = "FrmManufacturerEdit";
            Text = "新增厂家";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(txtMC, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(iudSort, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtMC;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIIntegerUpDown iudSort;
    }
}