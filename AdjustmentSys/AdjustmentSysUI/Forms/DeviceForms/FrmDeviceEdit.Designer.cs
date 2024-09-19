namespace AdjustmentSysUI.Forms.DeviceForms
{
    partial class FrmDeviceEdit
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
            uiLabel5 = new Sunny.UI.UILabel();
            txtSBMC = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            txtSBBZ = new Sunny.UI.UITextBox();
            cbLX = new Sunny.UI.UIComboBox();
            uiLabel2 = new Sunny.UI.UILabel();
            txtSBIP = new Sunny.UI.UIIPTextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            txtMECode = new Sunny.UI.UITextBox();
            uiLabel6 = new Sunny.UI.UILabel();
            rbQY = new Sunny.UI.UIRadioButton();
            rbJY = new Sunny.UI.UIRadioButton();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            SuspendLayout();
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F);
            uiLabel5.ForeColor = Color.Red;
            uiLabel5.Location = new Point(27, 132);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(99, 29);
            uiLabel5.TabIndex = 51;
            uiLabel5.Text = "设备类型：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSBMC
            // 
            txtSBMC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtSBMC.Location = new Point(131, 74);
            txtSBMC.Margin = new Padding(4, 5, 4, 5);
            txtSBMC.MaxLength = 20;
            txtSBMC.MinimumSize = new Size(1, 16);
            txtSBMC.Name = "txtSBMC";
            txtSBMC.Padding = new Padding(5);
            txtSBMC.ShowText = false;
            txtSBMC.Size = new Size(287, 29);
            txtSBMC.TabIndex = 50;
            txtSBMC.TextAlignment = ContentAlignment.MiddleLeft;
            txtSBMC.Watermark = "请输入设备名称";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(27, 74);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(99, 29);
            uiLabel4.TabIndex = 49;
            uiLabel4.Text = "设备名称：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(27, 191);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(99, 29);
            uiLabel1.TabIndex = 53;
            uiLabel1.Text = "设备编组：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSBBZ
            // 
            txtSBBZ.DoubleValue = 80000D;
            txtSBBZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtSBBZ.IntValue = 80000;
            txtSBBZ.Location = new Point(131, 191);
            txtSBBZ.Margin = new Padding(4, 5, 4, 5);
            txtSBBZ.MaxLength = 50;
            txtSBBZ.MinimumSize = new Size(1, 16);
            txtSBBZ.Name = "txtSBBZ";
            txtSBBZ.Padding = new Padding(5);
            txtSBBZ.ShowText = false;
            txtSBBZ.Size = new Size(287, 29);
            txtSBBZ.TabIndex = 54;
            txtSBBZ.Text = "80000";
            txtSBBZ.TextAlignment = ContentAlignment.MiddleLeft;
            txtSBBZ.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            txtSBBZ.Watermark = "设备编组";
            // 
            // cbLX
            // 
            cbLX.DataSource = null;
            cbLX.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbLX.FillColor = Color.White;
            cbLX.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbLX.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbLX.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbLX.Location = new Point(131, 132);
            cbLX.Margin = new Padding(4, 5, 4, 5);
            cbLX.MinimumSize = new Size(63, 0);
            cbLX.Name = "cbLX";
            cbLX.Padding = new Padding(0, 0, 30, 2);
            cbLX.Size = new Size(287, 29);
            cbLX.SymbolSize = 24;
            cbLX.TabIndex = 55;
            cbLX.TextAlignment = ContentAlignment.MiddleLeft;
            cbLX.Watermark = "请选择设备类型";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F);
            uiLabel2.ForeColor = Color.Black;
            uiLabel2.Location = new Point(27, 303);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(99, 29);
            uiLabel2.TabIndex = 56;
            uiLabel2.Text = "设备IP：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSBIP
            // 
            txtSBIP.FillColor2 = Color.FromArgb(235, 243, 255);
            txtSBIP.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtSBIP.Location = new Point(131, 303);
            txtSBIP.Margin = new Padding(4, 5, 4, 5);
            txtSBIP.MinimumSize = new Size(1, 1);
            txtSBIP.Name = "txtSBIP";
            txtSBIP.Padding = new Padding(1);
            txtSBIP.ShowText = false;
            txtSBIP.Size = new Size(287, 29);
            txtSBIP.TabIndex = 57;
            txtSBIP.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F);
            uiLabel3.ForeColor = Color.Red;
            uiLabel3.Location = new Point(27, 248);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(99, 29);
            uiLabel3.TabIndex = 58;
            uiLabel3.Text = "药柜编组：";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMECode
            // 
            txtMECode.DoubleValue = 2000D;
            txtMECode.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMECode.IntValue = 2000;
            txtMECode.Location = new Point(131, 246);
            txtMECode.Margin = new Padding(4, 5, 4, 5);
            txtMECode.MaxLength = 50;
            txtMECode.MinimumSize = new Size(1, 16);
            txtMECode.Name = "txtMECode";
            txtMECode.Padding = new Padding(5);
            txtMECode.ShowText = false;
            txtMECode.Size = new Size(287, 29);
            txtMECode.TabIndex = 59;
            txtMECode.Text = "2000";
            txtMECode.TextAlignment = ContentAlignment.MiddleLeft;
            txtMECode.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            txtMECode.Watermark = "设备编组";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 12F);
            uiLabel6.ForeColor = Color.Black;
            uiLabel6.Location = new Point(27, 355);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(99, 29);
            uiLabel6.TabIndex = 60;
            uiLabel6.Text = "是否启用：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rbQY
            // 
            rbQY.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rbQY.Location = new Point(141, 355);
            rbQY.MinimumSize = new Size(1, 1);
            rbQY.Name = "rbQY";
            rbQY.Size = new Size(105, 29);
            rbQY.TabIndex = 61;
            rbQY.Text = "启用";
            // 
            // rbJY
            // 
            rbJY.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rbJY.Location = new Point(262, 355);
            rbJY.MinimumSize = new Size(1, 1);
            rbJY.Name = "rbJY";
            rbJY.Size = new Size(105, 29);
            rbJY.TabIndex = 62;
            rbJY.Text = "禁用";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Location = new Point(353, 444);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 65;
            btnCancel.TabStop = false;
            btnCancel.Text = "取消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(215, 444);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(85, 35);
            btnOK.TabIndex = 64;
            btnOK.Text = "提交";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(3, 409);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(498, 29);
            uiLine1.TabIndex = 63;
            // 
            // FrmDeviceEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(504, 499);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(rbJY);
            Controls.Add(rbQY);
            Controls.Add(uiLabel6);
            Controls.Add(txtMECode);
            Controls.Add(uiLabel3);
            Controls.Add(txtSBIP);
            Controls.Add(uiLabel2);
            Controls.Add(cbLX);
            Controls.Add(txtSBBZ);
            Controls.Add(uiLabel1);
            Controls.Add(uiLabel5);
            Controls.Add(txtSBMC);
            Controls.Add(uiLabel4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDeviceEdit";
            Text = "新增设备";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtSBMC;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtSBBZ;
        private Sunny.UI.UIComboBox cbLX;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIIPTextBox txtSBIP;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtMECode;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIRadioButton rbQY;
        private Sunny.UI.UIRadioButton rbJY;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
    }
}