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
            uiLabel9 = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
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
            uiLabel3 = new Sunny.UI.UILabel();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 474);
            pnlBtm.Size = new Size(569, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(441, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(326, 12);
            btnOK.Click += btnOK_Click;
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel9.ForeColor = Color.Red;
            uiLabel9.Location = new Point(472, 232);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(70, 23);
            uiLabel9.TabIndex = 38;
            uiLabel9.Text = "必填";
            uiLabel9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = Color.Red;
            uiLabel8.Location = new Point(472, 68);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(70, 23);
            uiLabel8.TabIndex = 37;
            uiLabel8.Text = "必填";
            uiLabel8.TextAlign = ContentAlignment.MiddleLeft;
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
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
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
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
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
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(29, 68);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(100, 23);
            uiLabel1.TabIndex = 23;
            uiLabel1.Text = "科室名称：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.Red;
            uiLabel3.Location = new Point(472, 122);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(70, 23);
            uiLabel3.TabIndex = 39;
            uiLabel3.Text = "必填";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmDocDepartmentEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(571, 532);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel9);
            Controls.Add(uiLabel8);
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
            Name = "FrmDocDepartmentEdit";
            Text = "新增科室";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(txtAddress, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtCname, 0);
            Controls.SetChildIndex(uiLabel5, 0);
            Controls.SetChildIndex(txtCPhone, 0);
            Controls.SetChildIndex(uiLabel6, 0);
            Controls.SetChildIndex(txtRemark, 0);
            Controls.SetChildIndex(uiLabel8, 0);
            Controls.SetChildIndex(uiLabel9, 0);
            Controls.SetChildIndex(uiLabel3, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel8;
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
        private Sunny.UI.UILabel uiLabel3;
    }
}