namespace AdjustmentSysUI.Forms.PrescriptionForms
{
    partial class FrmEditHisCode
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
            uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            lblHisCode2 = new Sunny.UI.UILabel();
            lblHisCode1 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            cbOldDurg = new Sunny.UI.UIComboBox();
            uiLabel2 = new Sunny.UI.UILabel();
            cblisDurg = new Sunny.UI.UIComboBox();
            uiLine1 = new Sunny.UI.UILine();
            SuspendLayout();
            // 
            // uiSymbolButton1
            // 
            uiSymbolButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiSymbolButton1.Location = new Point(23, 296);
            uiSymbolButton1.MinimumSize = new Size(1, 1);
            uiSymbolButton1.Name = "uiSymbolButton1";
            uiSymbolButton1.Radius = 10;
            uiSymbolButton1.Size = new Size(118, 35);
            uiSymbolButton1.TabIndex = 22;
            uiSymbolButton1.Text = "确认更新";
            uiSymbolButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // lblHisCode2
            // 
            lblHisCode2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblHisCode2.ForeColor = Color.FromArgb(48, 48, 48);
            lblHisCode2.Location = new Point(391, 224);
            lblHisCode2.Name = "lblHisCode2";
            lblHisCode2.Size = new Size(192, 23);
            lblHisCode2.TabIndex = 21;
            lblHisCode2.Text = "无";
            lblHisCode2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHisCode1
            // 
            lblHisCode1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblHisCode1.ForeColor = Color.FromArgb(48, 48, 48);
            lblHisCode1.Location = new Point(391, 92);
            lblHisCode1.Name = "lblHisCode1";
            lblHisCode1.Size = new Size(192, 23);
            lblHisCode1.TabIndex = 20;
            lblHisCode1.Text = "无";
            lblHisCode1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(14, 183);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(248, 23);
            uiLabel4.TabIndex = 19;
            uiLabel4.Text = "本地药品信息：";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(14, 55);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(248, 23);
            uiLabel3.TabIndex = 18;
            uiLabel3.Text = "HIS端药品信息：";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(283, 92);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 17;
            uiLabel1.Text = "HIS码:";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbOldDurg
            // 
            cbOldDurg.DataSource = null;
            cbOldDurg.FillColor = Color.White;
            cbOldDurg.FilterIgnoreCase = true;
            cbOldDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbOldDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbOldDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbOldDurg.Location = new Point(14, 87);
            cbOldDurg.Margin = new Padding(4, 5, 4, 5);
            cbOldDurg.MinimumSize = new Size(63, 0);
            cbOldDurg.Name = "cbOldDurg";
            cbOldDurg.Padding = new Padding(0, 0, 30, 2);
            cbOldDurg.ShowClearButton = true;
            cbOldDurg.ShowFilter = true;
            cbOldDurg.Size = new Size(248, 32);
            cbOldDurg.SymbolSize = 24;
            cbOldDurg.TabIndex = 16;
            cbOldDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cbOldDurg.Watermark = "请选择HIS药品";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(283, 224);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 15;
            uiLabel2.Text = "HIS码:";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cblisDurg
            // 
            cblisDurg.DataSource = null;
            cblisDurg.FillColor = Color.White;
            cblisDurg.FilterIgnoreCase = true;
            cblisDurg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cblisDurg.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cblisDurg.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cblisDurg.Location = new Point(14, 219);
            cblisDurg.Margin = new Padding(4, 5, 4, 5);
            cblisDurg.MinimumSize = new Size(63, 0);
            cblisDurg.Name = "cblisDurg";
            cblisDurg.Padding = new Padding(0, 0, 30, 2);
            cblisDurg.ShowClearButton = true;
            cblisDurg.ShowFilter = true;
            cblisDurg.Size = new Size(248, 32);
            cblisDurg.SymbolSize = 24;
            cblisDurg.TabIndex = 14;
            cblisDurg.TextAlignment = ContentAlignment.MiddleLeft;
            cblisDurg.Watermark = "请选择本地药品";
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(3, 140);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(645, 29);
            uiLine1.TabIndex = 44;
            // 
            // FrmEditHisCode
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(651, 450);
            Controls.Add(uiLine1);
            Controls.Add(uiSymbolButton1);
            Controls.Add(lblHisCode2);
            Controls.Add(lblHisCode1);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel1);
            Controls.Add(cbOldDurg);
            Controls.Add(uiLabel2);
            Controls.Add(cblisDurg);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEditHisCode";
            Text = "更新药品HIS码";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmEditHisCode_Load;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UILabel lblHisCode2;
        private Sunny.UI.UILabel lblHisCode1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cbOldDurg;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox cblisDurg;
        private Sunny.UI.UILine uiLine1;
    }
}