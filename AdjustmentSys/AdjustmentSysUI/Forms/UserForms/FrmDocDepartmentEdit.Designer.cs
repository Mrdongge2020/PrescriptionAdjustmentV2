namespace AdjustmentSysUI.Forms.UserForms
{
    partial class FrmDocDepartmentEdit
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
            txtRemark = new Sunny.UI.UITextBox();
            uiLabel6 = new Sunny.UI.UILabel();
            txtCPhone = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtCname = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            txtAddress = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            txtName = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            SuspendLayout();
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtRemark.Location = new Point(169, 336);
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
            uiLabel6.Location = new Point(29, 336);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(100, 23);
            uiLabel6.TabIndex = 33;
            uiLabel6.Text = "备注：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCPhone
            // 
            txtCPhone.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtCPhone.Location = new Point(169, 168);
            txtCPhone.Margin = new Padding(4, 5, 4, 5);
            txtCPhone.MinimumSize = new Size(1, 16);
            txtCPhone.Name = "txtCPhone";
            txtCPhone.Padding = new Padding(5);
            txtCPhone.ShowText = false;
            txtCPhone.Size = new Size(287, 29);
            txtCPhone.TabIndex = 32;
            txtCPhone.TextAlignment = ContentAlignment.MiddleLeft;
            txtCPhone.Watermark = "请输入联系电话";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 10.5F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(29, 168);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(100, 23);
            uiLabel5.TabIndex = 31;
            uiLabel5.Text = "联系人电话：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCname
            // 
            txtCname.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtCname.Location = new Point(169, 116);
            txtCname.Margin = new Padding(4, 5, 4, 5);
            txtCname.MinimumSize = new Size(1, 16);
            txtCname.Name = "txtCname";
            txtCname.Padding = new Padding(5);
            txtCname.ShowText = false;
            txtCname.Size = new Size(287, 29);
            txtCname.TabIndex = 30;
            txtCname.TextAlignment = ContentAlignment.MiddleLeft;
            txtCname.Watermark = "请输入办公室信息";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 10.5F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(29, 120);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(100, 23);
            uiLabel4.TabIndex = 29;
            uiLabel4.Text = "联系人名称：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtAddress.Location = new Point(169, 219);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.MinimumSize = new Size(1, 16);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new Padding(5);
            txtAddress.ShowText = false;
            txtAddress.Size = new Size(287, 94);
            txtAddress.TabIndex = 26;
            txtAddress.TextAlignment = ContentAlignment.MiddleLeft;
            txtAddress.Watermark = "请输入科室地址信息";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 10.5F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(29, 223);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(100, 23);
            uiLabel2.TabIndex = 25;
            uiLabel2.Text = "地址：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            txtName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtName.Location = new Point(169, 64);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MinimumSize = new Size(1, 16);
            txtName.Name = "txtName";
            txtName.Padding = new Padding(5);
            txtName.ShowText = false;
            txtName.Size = new Size(287, 29);
            txtName.TabIndex = 24;
            txtName.TextAlignment = ContentAlignment.MiddleLeft;
            txtName.Watermark = "请输入科室名称";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 10.5F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(29, 68);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 23;
            uiLabel1.Text = "科室名称：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Location = new Point(373, 477);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 10;
            btnCancel.Size = new Size(90, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 48;
            btnCancel.TabStop = false;
            btnCancel.Text = "取 消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(235, 477);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Radius = 10;
            btnOK.Size = new Size(90, 35);
            btnOK.TabIndex = 47;
            btnOK.Text = "提 交";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(0, 442);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(575, 29);
            uiLine1.TabIndex = 46;
            // 
            // FrmDocDepartmentEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(544, 532);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(txtRemark);
            Controls.Add(uiLabel6);
            Controls.Add(txtCPhone);
            Controls.Add(uiLabel5);
            Controls.Add(txtCname);
            Controls.Add(uiLabel4);
            Controls.Add(txtAddress);
            Controls.Add(uiLabel2);
            Controls.Add(txtName);
            Controls.Add(uiLabel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDocDepartmentEdit";
            Text = "新增科室";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITextBox txtRemark;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtCPhone;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtCname;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtAddress;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
    }
}