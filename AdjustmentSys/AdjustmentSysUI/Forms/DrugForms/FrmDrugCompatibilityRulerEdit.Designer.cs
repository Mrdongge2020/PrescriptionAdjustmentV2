namespace AdjustmentSysUI.Forms.Drug
{
    partial class FrmDrugCompatibilityRulerEdit
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
            txtBZ = new Sunny.UI.UITextBox();
            uiLabel16 = new Sunny.UI.UILabel();
            txtName = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            cbfp = new Sunny.UI.UIComboBox();
            uiLabel1 = new Sunny.UI.UILabel();
            cbSp = new Sunny.UI.UIComboBox();
            uiLabel2 = new Sunny.UI.UILabel();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 348);
            pnlBtm.Size = new Size(565, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(437, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(322, 12);
            btnOK.Click += btnOK_Click;
            // 
            // txtBZ
            // 
            txtBZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtBZ.Location = new Point(178, 247);
            txtBZ.Margin = new Padding(4, 5, 4, 5);
            txtBZ.MaxLength = 200;
            txtBZ.MinimumSize = new Size(1, 16);
            txtBZ.Multiline = true;
            txtBZ.Name = "txtBZ";
            txtBZ.Padding = new Padding(5);
            txtBZ.ShowText = false;
            txtBZ.Size = new Size(287, 56);
            txtBZ.TabIndex = 94;
            txtBZ.TextAlignment = ContentAlignment.MiddleLeft;
            txtBZ.Watermark = "请输入规则备注";
            // 
            // uiLabel16
            // 
            uiLabel16.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel16.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel16.Location = new Point(26, 242);
            uiLabel16.Name = "uiLabel16";
            uiLabel16.Size = new Size(116, 23);
            uiLabel16.TabIndex = 93;
            uiLabel16.Text = "备注：";
            uiLabel16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(178, 65);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 50;
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(287, 29);
            txtName.TabIndex = 81;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入规则名称";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(26, 69);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(116, 23);
            uiLabel4.TabIndex = 80;
            uiLabel4.Text = "规则名称：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbfp
            // 
            cbfp.DataSource = null;
            cbfp.FillColor = Color.White;
            cbfp.FilterIgnoreCase = true;
            cbfp.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbfp.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbfp.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbfp.Location = new Point(178, 124);
            cbfp.Margin = new Padding(4, 5, 4, 5);
            cbfp.MinimumSize = new Size(63, 0);
            cbfp.Name = "cbfp";
            cbfp.Padding = new Padding(0, 0, 30, 2);
            cbfp.ShowClearButton = true;
            cbfp.ShowFilter = true;
            cbfp.Size = new Size(287, 29);
            cbfp.SymbolSize = 24;
            cbfp.TabIndex = 96;
            cbfp.TextAlignment = ContentAlignment.MiddleLeft;
            cbfp.TrimFilter = true;
            cbfp.Watermark = "请选择第一味颗粒";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(26, 128);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(116, 23);
            uiLabel1.TabIndex = 95;
            uiLabel1.Text = "第一味颗粒：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbSp
            // 
            cbSp.DataSource = null;
            cbSp.FillColor = Color.White;
            cbSp.FilterIgnoreCase = true;
            cbSp.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbSp.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbSp.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbSp.Location = new Point(178, 183);
            cbSp.Margin = new Padding(4, 5, 4, 5);
            cbSp.MinimumSize = new Size(63, 0);
            cbSp.Name = "cbSp";
            cbSp.Padding = new Padding(0, 0, 30, 2);
            cbSp.ShowClearButton = true;
            cbSp.ShowFilter = true;
            cbSp.Size = new Size(287, 29);
            cbSp.SymbolSize = 24;
            cbSp.TabIndex = 98;
            cbSp.TextAlignment = ContentAlignment.MiddleLeft;
            cbSp.Watermark = "请选择第二味颗粒";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(26, 187);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(116, 23);
            uiLabel2.TabIndex = 97;
            uiLabel2.Text = "第二味颗粒：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmDrugCompatibilityRulerEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(567, 406);
            Controls.Add(cbSp);
            Controls.Add(uiLabel2);
            Controls.Add(cbfp);
            Controls.Add(uiLabel1);
            Controls.Add(txtBZ);
            Controls.Add(uiLabel16);
            Controls.Add(txtName);
            Controls.Add(uiLabel4);
            Name = "FrmDrugCompatibilityRulerEdit";
            Text = "新增药品相容规则";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmDrugCompatibilityRulerEdit_Load;
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(uiLabel16, 0);
            Controls.SetChildIndex(txtBZ, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(cbfp, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(cbSp, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox txtBZ;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UITextBox txtMCQP;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UITextBox txtKLM;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox cbfp;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cbSp;
        private Sunny.UI.UILabel uiLabel2;
    }
}