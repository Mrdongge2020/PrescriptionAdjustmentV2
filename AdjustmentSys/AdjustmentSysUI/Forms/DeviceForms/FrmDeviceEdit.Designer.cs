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
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 329);
            pnlBtm.Size = new Size(546, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(418, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(303, 12);
            btnOK.Click += btnOK_Click;
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
            uiLabel2.Location = new Point(27, 246);
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
            txtSBIP.Location = new Point(131, 246);
            txtSBIP.Margin = new Padding(4, 5, 4, 5);
            txtSBIP.MinimumSize = new Size(1, 1);
            txtSBIP.Name = "txtSBIP";
            txtSBIP.Padding = new Padding(1);
            txtSBIP.ShowText = false;
            txtSBIP.Size = new Size(287, 29);
            txtSBIP.TabIndex = 57;
            txtSBIP.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FrmDeviceEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(548, 387);
            Controls.Add(txtSBIP);
            Controls.Add(uiLabel2);
            Controls.Add(cbLX);
            Controls.Add(txtSBBZ);
            Controls.Add(uiLabel1);
            Controls.Add(uiLabel5);
            Controls.Add(txtSBMC);
            Controls.Add(uiLabel4);
            Name = "FrmDeviceEdit";
            Text = "新增设备";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtSBMC, 0);
            Controls.SetChildIndex(uiLabel5, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(txtSBBZ, 0);
            Controls.SetChildIndex(cbLX, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(txtSBIP, 0);
            pnlBtm.ResumeLayout(false);
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
    }
}