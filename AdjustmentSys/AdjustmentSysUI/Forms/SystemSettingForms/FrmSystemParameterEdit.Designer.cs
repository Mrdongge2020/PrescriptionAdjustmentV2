namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    partial class FrmSystemParameterEdit
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
            cbType = new Sunny.UI.UIComboBox();
            uiLabel7 = new Sunny.UI.UILabel();
            txtParaValue = new Sunny.UI.UITextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            txtDecribe = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            txtName = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            SuspendLayout();
            // 
            // cbType
            // 
            cbType.DataSource = null;
            cbType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbType.FillColor = Color.White;
            cbType.Font = new Font("微软雅黑", 10.5F);
            cbType.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbType.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbType.Location = new Point(161, 264);
            cbType.Margin = new Padding(4, 5, 4, 5);
            cbType.MinimumSize = new Size(63, 0);
            cbType.Name = "cbType";
            cbType.Padding = new Padding(0, 0, 30, 2);
            cbType.Size = new Size(289, 29);
            cbType.SymbolSize = 24;
            cbType.TabIndex = 23;
            cbType.TextAlignment = ContentAlignment.MiddleLeft;
            cbType.Watermark = "请选择参数类型";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("微软雅黑", 10.5F);
            uiLabel7.ForeColor = Color.Red;
            uiLabel7.Location = new Point(23, 263);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(100, 23);
            uiLabel7.TabIndex = 22;
            uiLabel7.Text = "参数类型：";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtParaValue
            // 
            txtParaValue.Font = new Font("微软雅黑", 10.5F);
            txtParaValue.Location = new Point(163, 159);
            txtParaValue.Margin = new Padding(4, 5, 4, 5);
            txtParaValue.MaxLength = 200;
            txtParaValue.MinimumSize = new Size(1, 16);
            txtParaValue.Multiline = true;
            txtParaValue.Name = "txtParaValue";
            txtParaValue.Padding = new Padding(5);
            txtParaValue.ShowText = false;
            txtParaValue.Size = new Size(287, 93);
            txtParaValue.TabIndex = 21;
            txtParaValue.TextAlignment = ContentAlignment.MiddleLeft;
            txtParaValue.Watermark = "请输入参数值";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("微软雅黑", 10.5F);
            uiLabel3.ForeColor = Color.Red;
            uiLabel3.Location = new Point(23, 163);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(100, 23);
            uiLabel3.TabIndex = 20;
            uiLabel3.Text = "参数值：";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDecribe
            // 
            txtDecribe.Font = new Font("微软雅黑", 10.5F);
            txtDecribe.Location = new Point(163, 108);
            txtDecribe.Margin = new Padding(4, 5, 4, 5);
            txtDecribe.MaxLength = 50;
            txtDecribe.MinimumSize = new Size(1, 16);
            txtDecribe.Name = "txtDecribe";
            txtDecribe.Padding = new Padding(5);
            txtDecribe.ShowText = false;
            txtDecribe.Size = new Size(287, 29);
            txtDecribe.TabIndex = 19;
            txtDecribe.TextAlignment = ContentAlignment.MiddleLeft;
            txtDecribe.Watermark = "请输入参数描述";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 10.5F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(23, 112);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 18;
            uiLabel2.Text = "参数描述：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Font = new Font("微软雅黑", 10.5F);
            txtName.Location = new Point(163, 57);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 20;
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(287, 29);
            txtName.TabIndex = 17;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入参数名称";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("微软雅黑", 10.5F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(23, 61);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 16;
            uiLabel1.Text = "参数名称：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Location = new Point(370, 332);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 38;
            btnCancel.TabStop = false;
            btnCancel.Text = "取消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(232, 332);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(85, 35);
            btnOK.TabIndex = 37;
            btnOK.Text = "提交";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(3, 297);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(531, 29);
            uiLine1.TabIndex = 36;
            // 
            // FrmSystemParameterEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(536, 380);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(cbType);
            Controls.Add(uiLabel7);
            Controls.Add(txtParaValue);
            Controls.Add(uiLabel3);
            Controls.Add(txtDecribe);
            Controls.Add(uiLabel2);
            Controls.Add(txtName);
            Controls.Add(uiLabel1);
            Font = new Font("微软雅黑", 10.5F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSystemParameterEdit";
            Text = "新增系统参数";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmSystemParameterEdit_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox cbType;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txtParaValue;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtDecribe;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
    }
}