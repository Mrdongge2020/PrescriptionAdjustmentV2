namespace AdjustmentSysUI.Forms.UserForms
{
    partial class FrmUserEdit
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
            txtName = new Sunny.UI.UITextBox();
            txtPassword = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            txtConfimPassword = new Sunny.UI.UITextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            txtOffic = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            txtPhone = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtRemark = new Sunny.UI.UITextBox();
            uiLabel6 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            cbLevel = new Sunny.UI.UIComboBox();
            uiLabel12 = new Sunny.UI.UILabel();
            rbTrue = new Sunny.UI.UIRadioButton();
            rbFalse = new Sunny.UI.UIRadioButton();
            uiLine1 = new Sunny.UI.UILine();
            btnOK = new Sunny.UI.UISymbolButton();
            btnCancel = new Sunny.UI.UISymbolButton();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 10.5F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(25, 61);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "用户名：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(165, 57);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(287, 29);
            txtName.TabIndex = 3;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入用户名";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPassword.Location = new Point(165, 108);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.MinimumSize = new Size(1, 16);
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(5);
            txtPassword.PasswordChar = '*';
            txtPassword.ShowText = false;
            txtPassword.Size = new Size(287, 29);
            txtPassword.TabIndex = 5;
            txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtPassword.Watermark = "请输入密码";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 10.5F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(25, 112);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 4;
            uiLabel2.Text = "密码：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtConfimPassword
            // 
            txtConfimPassword.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtConfimPassword.Location = new Point(165, 161);
            txtConfimPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfimPassword.MinimumSize = new Size(1, 16);
            txtConfimPassword.Name = "txtConfimPassword";
            txtConfimPassword.Padding = new Padding(5);
            txtConfimPassword.PasswordChar = '*';
            txtConfimPassword.ShowText = false;
            txtConfimPassword.Size = new Size(287, 29);
            txtConfimPassword.TabIndex = 7;
            txtConfimPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtConfimPassword.Watermark = "请输入确认密码";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 10.5F);
            uiLabel3.ForeColor = Color.Red;
            uiLabel3.Location = new Point(25, 165);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(100, 23);
            uiLabel3.TabIndex = 6;
            uiLabel3.Text = "确认密码：";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtOffic
            // 
            txtOffic.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtOffic.Location = new Point(165, 306);
            txtOffic.Margin = new Padding(4, 5, 4, 5);
            txtOffic.MinimumSize = new Size(1, 16);
            txtOffic.Name = "txtOffic";
            txtOffic.Padding = new Padding(5);
            txtOffic.ShowText = false;
            txtOffic.Size = new Size(287, 29);
            txtOffic.TabIndex = 9;
            txtOffic.TextAlignment = ContentAlignment.MiddleLeft;
            txtOffic.Watermark = "请输入办公室信息";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 10.5F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(25, 310);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(100, 23);
            uiLabel4.TabIndex = 8;
            uiLabel4.Text = "办公室：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPhone.Location = new Point(165, 354);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.MinimumSize = new Size(1, 16);
            txtPhone.Name = "txtPhone";
            txtPhone.Padding = new Padding(5);
            txtPhone.ShowText = false;
            txtPhone.Size = new Size(287, 29);
            txtPhone.TabIndex = 11;
            txtPhone.TextAlignment = ContentAlignment.MiddleLeft;
            txtPhone.Watermark = "请输入联系电话";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 10.5F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(25, 354);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(100, 23);
            uiLabel5.TabIndex = 10;
            uiLabel5.Text = "联系电话：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtRemark.Location = new Point(165, 403);
            txtRemark.Margin = new Padding(4, 5, 4, 5);
            txtRemark.MinimumSize = new Size(1, 16);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Padding = new Padding(5);
            txtRemark.ShowText = false;
            txtRemark.Size = new Size(287, 98);
            txtRemark.TabIndex = 13;
            txtRemark.TextAlignment = ContentAlignment.MiddleLeft;
            txtRemark.Watermark = "请输入备注信息";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 10.5F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(25, 403);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(100, 23);
            uiLabel6.TabIndex = 12;
            uiLabel6.Text = "备注：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 10.5F);
            uiLabel7.ForeColor = Color.Red;
            uiLabel7.Location = new Point(25, 213);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(100, 23);
            uiLabel7.TabIndex = 14;
            uiLabel7.Text = "权限等级：";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbLevel
            // 
            cbLevel.DataSource = null;
            cbLevel.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbLevel.FillColor = Color.White;
            cbLevel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbLevel.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbLevel.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbLevel.Location = new Point(163, 214);
            cbLevel.Margin = new Padding(4, 5, 4, 5);
            cbLevel.MinimumSize = new Size(63, 0);
            cbLevel.Name = "cbLevel";
            cbLevel.Padding = new Padding(0, 0, 30, 2);
            cbLevel.Size = new Size(289, 29);
            cbLevel.SymbolSize = 24;
            cbLevel.TabIndex = 15;
            cbLevel.TextAlignment = ContentAlignment.MiddleLeft;
            cbLevel.Watermark = "请选择权限等级";
            // 
            // uiLabel12
            // 
            uiLabel12.Font = new Font("宋体", 10.5F);
            uiLabel12.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel12.Location = new Point(25, 269);
            uiLabel12.Name = "uiLabel12";
            uiLabel12.Size = new Size(100, 23);
            uiLabel12.TabIndex = 20;
            uiLabel12.Text = "账号状态：";
            uiLabel12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rbTrue
            // 
            rbTrue.Checked = true;
            rbTrue.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rbTrue.Location = new Point(168, 266);
            rbTrue.MinimumSize = new Size(1, 1);
            rbTrue.Name = "rbTrue";
            rbTrue.Size = new Size(74, 29);
            rbTrue.TabIndex = 21;
            rbTrue.Text = "启用";
            // 
            // rbFalse
            // 
            rbFalse.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rbFalse.Location = new Point(272, 266);
            rbFalse.MinimumSize = new Size(1, 1);
            rbFalse.Name = "rbFalse";
            rbFalse.Size = new Size(86, 29);
            rbFalse.TabIndex = 22;
            rbFalse.Text = "禁用";
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(-1, 511);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(531, 29);
            uiLine1.TabIndex = 33;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(228, 546);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(85, 35);
            btnOK.TabIndex = 34;
            btnOK.Text = "提交";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Location = new Point(366, 546);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 35;
            btnCancel.TabStop = false;
            btnCancel.Text = "取消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmUserEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(527, 604);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(rbFalse);
            Controls.Add(rbTrue);
            Controls.Add(uiLabel12);
            Controls.Add(cbLevel);
            Controls.Add(uiLabel7);
            Controls.Add(txtRemark);
            Controls.Add(uiLabel6);
            Controls.Add(txtPhone);
            Controls.Add(uiLabel5);
            Controls.Add(txtOffic);
            Controls.Add(uiLabel4);
            Controls.Add(txtConfimPassword);
            Controls.Add(uiLabel3);
            Controls.Add(txtPassword);
            Controls.Add(uiLabel2);
            Controls.Add(txtName);
            Controls.Add(uiLabel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserEdit";
            Text = "新增用户";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UITextBox txtPassword;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtConfimPassword;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtOffic;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtPhone;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtRemark;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox cbLevel;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIRadioButton rbTrue;
        private Sunny.UI.UIRadioButton rbFalse;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UISymbolButton btnCancel;
    }
}