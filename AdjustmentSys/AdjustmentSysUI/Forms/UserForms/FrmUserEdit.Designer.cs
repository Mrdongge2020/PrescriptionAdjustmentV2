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
            uiLabel8 = new Sunny.UI.UILabel();
            uiLabel9 = new Sunny.UI.UILabel();
            uiLabel10 = new Sunny.UI.UILabel();
            uiLabel11 = new Sunny.UI.UILabel();
            uiLabel12 = new Sunny.UI.UILabel();
            rbTrue = new Sunny.UI.UIRadioButton();
            rbFalse = new Sunny.UI.UIRadioButton();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 546);
            pnlBtm.Size = new Size(651, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(523, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(408, 12);
            btnOK.Click += btnOK_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 10.5F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(43, 63);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "用户名：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(183, 59);
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
            txtPassword.Location = new Point(183, 110);
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
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(43, 114);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 4;
            uiLabel2.Text = "密码：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtConfimPassword
            // 
            txtConfimPassword.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtConfimPassword.Location = new Point(183, 163);
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
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(43, 167);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(100, 23);
            uiLabel3.TabIndex = 6;
            uiLabel3.Text = "确认密码：";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtOffic
            // 
            txtOffic.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtOffic.Location = new Point(183, 308);
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
            uiLabel4.Location = new Point(43, 312);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(100, 23);
            uiLabel4.TabIndex = 8;
            uiLabel4.Text = "办公室：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPhone.Location = new Point(183, 356);
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
            uiLabel5.Location = new Point(43, 356);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(100, 23);
            uiLabel5.TabIndex = 10;
            uiLabel5.Text = "联系电话：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtRemark.Location = new Point(183, 405);
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
            uiLabel6.Location = new Point(43, 405);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(100, 23);
            uiLabel6.TabIndex = 12;
            uiLabel6.Text = "备注：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 10.5F);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(43, 215);
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
            cbLevel.Location = new Point(181, 216);
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
            // uiLabel8
            // 
            uiLabel8.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = Color.Red;
            uiLabel8.Location = new Point(486, 63);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(100, 23);
            uiLabel8.TabIndex = 16;
            uiLabel8.Text = "必填";
            uiLabel8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = Color.Red;
            uiLabel9.Location = new Point(486, 110);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(100, 23);
            uiLabel9.TabIndex = 17;
            uiLabel9.Text = "必填";
            uiLabel9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel10.ForeColor = Color.Red;
            uiLabel10.Location = new Point(486, 167);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new Size(100, 23);
            uiLabel10.TabIndex = 18;
            uiLabel10.Text = "必填";
            uiLabel10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel11.ForeColor = Color.Red;
            uiLabel11.Location = new Point(486, 216);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new Size(100, 23);
            uiLabel11.TabIndex = 19;
            uiLabel11.Text = "必填";
            uiLabel11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel12
            // 
            uiLabel12.Font = new Font("宋体", 10.5F);
            uiLabel12.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel12.Location = new Point(43, 271);
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
            rbTrue.Location = new Point(186, 268);
            rbTrue.MinimumSize = new Size(1, 1);
            rbTrue.Name = "rbTrue";
            rbTrue.Size = new Size(74, 29);
            rbTrue.TabIndex = 21;
            rbTrue.Text = "启用";
            // 
            // rbFalse
            // 
            rbFalse.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rbFalse.Location = new Point(290, 268);
            rbFalse.MinimumSize = new Size(1, 1);
            rbFalse.Name = "rbFalse";
            rbFalse.Size = new Size(86, 29);
            rbFalse.TabIndex = 22;
            rbFalse.Text = "禁用";
            // 
            // FrmUserEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(653, 604);
            Controls.Add(rbFalse);
            Controls.Add(rbTrue);
            Controls.Add(uiLabel12);
            Controls.Add(uiLabel11);
            Controls.Add(uiLabel10);
            Controls.Add(uiLabel9);
            Controls.Add(uiLabel8);
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
            Name = "FrmUserEdit";
            Text = "新增用户";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(uiLabel3, 0);
            Controls.SetChildIndex(txtConfimPassword, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtOffic, 0);
            Controls.SetChildIndex(uiLabel5, 0);
            Controls.SetChildIndex(txtPhone, 0);
            Controls.SetChildIndex(uiLabel6, 0);
            Controls.SetChildIndex(txtRemark, 0);
            Controls.SetChildIndex(uiLabel7, 0);
            Controls.SetChildIndex(cbLevel, 0);
            Controls.SetChildIndex(uiLabel8, 0);
            Controls.SetChildIndex(uiLabel9, 0);
            Controls.SetChildIndex(uiLabel10, 0);
            Controls.SetChildIndex(uiLabel11, 0);
            Controls.SetChildIndex(uiLabel12, 0);
            Controls.SetChildIndex(rbTrue, 0);
            Controls.SetChildIndex(rbFalse, 0);
            pnlBtm.ResumeLayout(false);
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
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UIRadioButton rbTrue;
        private Sunny.UI.UIRadioButton rbFalse;
    }
}