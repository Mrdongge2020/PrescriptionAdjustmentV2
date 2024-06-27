namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmListingParticles
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
            cblisDurg = new Sunny.UI.UIComboBox();
            uiLabel1 = new Sunny.UI.UILabel();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 116);
            pnlBtm.Size = new Size(454, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(326, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(211, 12);
            btnOK.Click += btnOK_Click;
            // 
            // cblisDurg
            // 
            cblisDurg.DataSource = null;
            cblisDurg.FillColor = Color.White;
            cblisDurg.FilterIgnoreCase = true;
            cblisDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cblisDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cblisDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cblisDurg.Location = new Point(201, 56);
            cblisDurg.Margin = new Padding(4, 5, 4, 5);
            cblisDurg.MinimumSize = new Size(63, 0);
            cblisDurg.Name = "cblisDurg";
            cblisDurg.Padding = new Padding(0, 0, 30, 2);
            cblisDurg.ShowClearButton = true;
            cblisDurg.ShowFilter = true;
            cblisDurg.Size = new Size(226, 32);
            cblisDurg.SymbolSize = 24;
            cblisDurg.TabIndex = 2;
            cblisDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cblisDurg.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(15, 56);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(179, 32);
            uiLabel1.TabIndex = 3;
            uiLabel1.Text = "请选择要上架的颗粒：";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmListingParticles
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(456, 174);
            Controls.Add(uiLabel1);
            Controls.Add(cblisDurg);
            Name = "FrmListingParticles";
            Text = "上架颗粒";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(cblisDurg, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox cblisDurg;
        private Sunny.UI.UILabel uiLabel1;
    }
}