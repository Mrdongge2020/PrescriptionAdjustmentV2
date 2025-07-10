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
            cblisDurg = new Sunny.UI.UIComboBox();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 98);
            pnlBtm.Size = new Size(377, 54);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(249, 12);
            btnCancel.Radius = 10;
            btnCancel.Size = new Size(90, 35);
            btnCancel.Text = "取 消";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(134, 12);
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
            cblisDurg.Location = new Point(25, 56);
            cblisDurg.Margin = new Padding(4, 5, 4, 5);
            cblisDurg.MinimumSize = new Size(63, 0);
            cblisDurg.Name = "cblisDurg";
            cblisDurg.Padding = new Padding(0, 0, 30, 2);
            cblisDurg.ShowClearButton = true;
            cblisDurg.ShowFilter = true;
            cblisDurg.Size = new Size(302, 32);
            cblisDurg.SymbolSize = 24;
            cblisDurg.TabIndex = 4;
            cblisDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cblisDurg.Watermark = "请选择要更新HIS码的药品";
            // 
            // FrmUpdateHisCode
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(379, 155);
            Controls.Add(cblisDurg);
            Name = "FrmUpdateHisCode";
            Text = "药品HIS码更新";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(cblisDurg, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cblisDurg;
    }
}