namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmUpdateHisCode
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
            cblisDurg = new Sunny.UI.UIComboBox();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 98);
            pnlBtm.Size = new Size(465, 54);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(337, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(222, 12);
            btnOK.Click += btnOK_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(4, 55);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(202, 32);
            uiLabel1.TabIndex = 5;
            uiLabel1.Text = "请选择要更新HIS码的药品:";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cblisDurg
            // 
            cblisDurg.DataSource = null;
            cblisDurg.FillColor = Color.White;
            cblisDurg.FilterIgnoreCase = true;
            cblisDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cblisDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cblisDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cblisDurg.Location = new Point(213, 55);
            cblisDurg.Margin = new Padding(4, 5, 4, 5);
            cblisDurg.MinimumSize = new Size(63, 0);
            cblisDurg.Name = "cblisDurg";
            cblisDurg.Padding = new Padding(0, 0, 30, 2);
            cblisDurg.ShowClearButton = true;
            cblisDurg.ShowFilter = true;
            cblisDurg.Size = new Size(226, 32);
            cblisDurg.SymbolSize = 24;
            cblisDurg.TabIndex = 4;
            cblisDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cblisDurg.Watermark = "";
            // 
            // FrmUpdateHisCode
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(467, 155);
            Controls.Add(uiLabel1);
            Controls.Add(cblisDurg);
            Name = "FrmUpdateHisCode";
            Text = "药品HIS码更新";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(cblisDurg, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cblisDurg;
    }
}