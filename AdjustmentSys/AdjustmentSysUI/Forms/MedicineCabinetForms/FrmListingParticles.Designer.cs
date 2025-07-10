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
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 94);
            pnlBtm.Size = new Size(375, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(247, 12);
            btnCancel.Radius = 10;
            btnCancel.Size = new Size(90, 35);
            btnCancel.Text = "取 消";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(132, 12);
            btnOK.Radius = 10;
            btnOK.Size = new Size(90, 35);
            btnOK.Text = "确 定";
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
            cblisDurg.Location = new Point(31, 52);
            cblisDurg.Margin = new Padding(4, 5, 4, 5);
            cblisDurg.MinimumSize = new Size(63, 0);
            cblisDurg.Name = "cblisDurg";
            cblisDurg.Padding = new Padding(0, 0, 30, 2);
            cblisDurg.ShowClearButton = true;
            cblisDurg.ShowFilter = true;
            cblisDurg.Size = new Size(290, 32);
            cblisDurg.SymbolSize = 24;
            cblisDurg.TabIndex = 2;
            cblisDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cblisDurg.Watermark = "请选择要上架的颗粒";
            // 
            // FrmListingParticles
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(377, 152);
            Controls.Add(cblisDurg);
            Name = "FrmListingParticles";
            Text = "上架颗粒";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(cblisDurg, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox cblisDurg;
        private Sunny.UI.UILabel uiLabel1;
    }
}