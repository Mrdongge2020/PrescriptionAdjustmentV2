namespace AdjustmentSysUI.Forms.UserForms
{
    partial class FrmDoctorEdit
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
            cbDepartment = new Sunny.UI.UIComboBox();
            uiLabel7 = new Sunny.UI.UILabel();
            txtRemark = new Sunny.UI.UITextBox();
            uiLabel6 = new Sunny.UI.UILabel();
            txtPhone = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtOffic = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            txtName = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            txtEmail = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            SuspendLayout();
            // 
            // cbDepartment
            // 
            cbDepartment.DataSource = null;
            cbDepartment.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbDepartment.FillColor = Color.White;
            cbDepartment.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbDepartment.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbDepartment.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbDepartment.Location = new Point(166, 116);
            cbDepartment.Margin = new Padding(4, 5, 4, 5);
            cbDepartment.MinimumSize = new Size(63, 0);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Padding = new Padding(0, 0, 30, 2);
            cbDepartment.Size = new Size(289, 29);
            cbDepartment.SymbolSize = 24;
            cbDepartment.TabIndex = 36;
            cbDepartment.TextAlignment = ContentAlignment.MiddleLeft;
            cbDepartment.Watermark = "请选择所属科室";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 10.5F);
            uiLabel7.ForeColor = Color.Red;
            uiLabel7.Location = new Point(3, 115);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(158, 23);
            uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            uiLabel7.TabIndex = 35;
            uiLabel7.Text = "所属科室：";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtRemark.Location = new Point(168, 331);
            txtRemark.Margin = new Padding(4, 5, 4, 5);
            txtRemark.MinimumSize = new Size(1, 16);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Padding = new Padding(5);
            txtRemark.ShowText = false;
            txtRemark.Size = new Size(287, 98);
            txtRemark.TabIndex = 34;
            txtRemark.TextAlignment = ContentAlignment.MiddleLeft;
            txtRemark.Watermark = "请输入备注信息";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 10.5F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(3, 331);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(158, 23);
            uiLabel6.TabIndex = 33;
            uiLabel6.Text = "备注：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPhone.Location = new Point(168, 224);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.MinimumSize = new Size(1, 16);
            txtPhone.Name = "txtPhone";
            txtPhone.Padding = new Padding(5);
            txtPhone.ShowText = false;
            txtPhone.Size = new Size(287, 29);
            txtPhone.TabIndex = 32;
            txtPhone.TextAlignment = ContentAlignment.MiddleLeft;
            txtPhone.Watermark = "请输入联系电话";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 10.5F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(3, 224);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(158, 23);
            uiLabel5.TabIndex = 31;
            uiLabel5.Text = "联系电话：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtOffic
            // 
            txtOffic.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtOffic.Location = new Point(168, 171);
            txtOffic.Margin = new Padding(4, 5, 4, 5);
            txtOffic.MinimumSize = new Size(1, 16);
            txtOffic.Name = "txtOffic";
            txtOffic.Padding = new Padding(5);
            txtOffic.ShowText = false;
            txtOffic.Size = new Size(287, 29);
            txtOffic.TabIndex = 30;
            txtOffic.TextAlignment = ContentAlignment.MiddleLeft;
            txtOffic.Watermark = "请输入办公室信息";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 10.5F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(3, 175);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(158, 23);
            uiLabel4.TabIndex = 29;
            uiLabel4.Text = "办公室：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(166, 56);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(287, 29);
            txtName.TabIndex = 24;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入医生名称";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 10.5F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(1, 60);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(158, 23);
            uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            uiLabel1.TabIndex = 23;
            uiLabel1.Text = "医生名称：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtEmail.Location = new Point(168, 276);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.MinimumSize = new Size(1, 16);
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(5);
            txtEmail.ShowText = false;
            txtEmail.Size = new Size(287, 29);
            txtEmail.TabIndex = 42;
            txtEmail.TextAlignment = ContentAlignment.MiddleLeft;
            txtEmail.Watermark = "请输入Email地址";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 10.5F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(3, 276);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(158, 23);
            uiLabel2.TabIndex = 41;
            uiLabel2.Text = "Email地址：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Location = new Point(370, 491);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 10;
            btnCancel.Size = new Size(90, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 45;
            btnCancel.TabStop = false;
            btnCancel.Text = "取 消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(232, 491);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Radius = 10;
            btnOK.Size = new Size(90, 35);
            btnOK.TabIndex = 44;
            btnOK.Text = "提 交";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(0, 456);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(599, 29);
            uiLine1.TabIndex = 43;
            // 
            // FrmDoctorEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(555, 540);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(txtEmail);
            Controls.Add(uiLabel2);
            Controls.Add(cbDepartment);
            Controls.Add(uiLabel7);
            Controls.Add(txtRemark);
            Controls.Add(uiLabel6);
            Controls.Add(txtPhone);
            Controls.Add(uiLabel5);
            Controls.Add(txtOffic);
            Controls.Add(uiLabel4);
            Controls.Add(txtName);
            Controls.Add(uiLabel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDoctorEdit";
            Text = "新增医生";
            ZoomScaleRect = new Rectangle(15, 15, 595, 556);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIComboBox cbDepartment;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txtRemark;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtPhone;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtOffic;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtEmail;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
    }
}