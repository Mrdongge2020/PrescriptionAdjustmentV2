namespace AdjustmentSysUI.Forms.Drug
{
    partial class FrmDrugEdit
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
            txtJC = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            cbCJ = new Sunny.UI.UIComboBox();
            txtQC = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtKLM = new Sunny.UI.UITextBox();
            uiLabel6 = new Sunny.UI.UILabel();
            txtMD = new Sunny.UI.UITextBox();
            uiLabel9 = new Sunny.UI.UILabel();
            txtDL = new Sunny.UI.UITextBox();
            uiLabel11 = new Sunny.UI.UILabel();
            txtHISM = new Sunny.UI.UITextBox();
            uiLabel12 = new Sunny.UI.UILabel();
            txtLSJ = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            txtGHJ = new Sunny.UI.UITextBox();
            uiLabel3 = new Sunny.UI.UILabel();
            txtJLSX = new Sunny.UI.UITextBox();
            uiLabel7 = new Sunny.UI.UILabel();
            txtDBZM = new Sunny.UI.UITextBox();
            uiLabel8 = new Sunny.UI.UILabel();
            txtSSBH = new Sunny.UI.UITextBox();
            uiLabel10 = new Sunny.UI.UILabel();
            txtMCQP = new Sunny.UI.UITextBox();
            uiLabel13 = new Sunny.UI.UILabel();
            txtMCJP = new Sunny.UI.UITextBox();
            uiLabel14 = new Sunny.UI.UILabel();
            lblTM = new Sunny.UI.UILabel();
            txtBZTM = new Sunny.UI.UITextBox();
            btnSB = new Sunny.UI.UIButton();
            txtBZ = new Sunny.UI.UITextBox();
            uiLabel16 = new Sunny.UI.UILabel();
            txtXQZ = new Sunny.UI.UITextBox();
            uiLabel17 = new Sunny.UI.UILabel();
            txtPH = new Sunny.UI.UITextBox();
            uiLabel18 = new Sunny.UI.UILabel();
            txtHISMC = new Sunny.UI.UITextBox();
            uiLabel15 = new Sunny.UI.UILabel();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 637);
            pnlBtm.Size = new Size(889, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(761, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(646, 12);
            btnOK.Click += btnOK_Click;
            // 
            // txtJC
            // 
            txtJC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtJC.Location = new Point(113, 113);
            txtJC.Margin = new Padding(4, 5, 4, 5);
            txtJC.MaxLength = 20;
            txtJC.MinimumSize = new Size(1, 16);
            txtJC.Name = "txtJC";
            txtJC.Padding = new Padding(5);
            txtJC.ShowText = false;
            txtJC.Size = new Size(287, 29);
            txtJC.TabIndex = 43;
            txtJC.TextAlignment = ContentAlignment.MiddleLeft;
            txtJC.Watermark = "请输入颗粒名称简称";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(9, 113);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(99, 29);
            uiLabel4.TabIndex = 42;
            uiLabel4.Text = "颗粒简称：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F);
            uiLabel1.ForeColor = Color.Red;
            uiLabel1.Location = new Point(9, 52);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(99, 29);
            uiLabel1.TabIndex = 40;
            uiLabel1.Text = "颗粒厂家：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbCJ
            // 
            cbCJ.DataSource = null;
            cbCJ.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbCJ.FillColor = Color.White;
            cbCJ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbCJ.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbCJ.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbCJ.Location = new Point(113, 52);
            cbCJ.Margin = new Padding(4, 5, 4, 5);
            cbCJ.MinimumSize = new Size(63, 0);
            cbCJ.Name = "cbCJ";
            cbCJ.Padding = new Padding(0, 0, 30, 2);
            cbCJ.Size = new Size(287, 29);
            cbCJ.SymbolSize = 24;
            cbCJ.TabIndex = 46;
            cbCJ.TextAlignment = ContentAlignment.MiddleLeft;
            cbCJ.Watermark = "请选择颗粒厂家";
            // 
            // txtQC
            // 
            txtQC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtQC.Location = new Point(113, 171);
            txtQC.Margin = new Padding(4, 5, 4, 5);
            txtQC.MaxLength = 50;
            txtQC.MinimumSize = new Size(1, 16);
            txtQC.Name = "txtQC";
            txtQC.Padding = new Padding(5);
            txtQC.ShowText = false;
            txtQC.Size = new Size(287, 29);
            txtQC.TabIndex = 48;
            txtQC.TextAlignment = ContentAlignment.MiddleLeft;
            txtQC.Watermark = "请输入颗粒名称全称";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F);
            uiLabel5.ForeColor = Color.Black;
            uiLabel5.Location = new Point(9, 171);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(99, 29);
            uiLabel5.TabIndex = 47;
            uiLabel5.Text = "颗粒全称：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtKLM
            // 
            txtKLM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtKLM.Location = new Point(113, 229);
            txtKLM.Margin = new Padding(4, 5, 4, 5);
            txtKLM.MaxLength = 20;
            txtKLM.MinimumSize = new Size(1, 16);
            txtKLM.Name = "txtKLM";
            txtKLM.Padding = new Padding(5);
            txtKLM.ShowText = false;
            txtKLM.Size = new Size(287, 29);
            txtKLM.TabIndex = 50;
            txtKLM.TextAlignment = ContentAlignment.MiddleLeft;
            txtKLM.Watermark = "请输入颗粒码";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 12F);
            uiLabel6.ForeColor = Color.Red;
            uiLabel6.Location = new Point(9, 229);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(99, 29);
            uiLabel6.TabIndex = 49;
            uiLabel6.Text = "颗粒码：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMD
            // 
            txtMD.DecimalPlaces = 4;
            txtMD.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMD.Location = new Point(113, 282);
            txtMD.Margin = new Padding(4, 5, 4, 5);
            txtMD.MinimumSize = new Size(1, 16);
            txtMD.Name = "txtMD";
            txtMD.Padding = new Padding(5);
            txtMD.ShowText = false;
            txtMD.Size = new Size(287, 29);
            txtMD.TabIndex = 53;
            txtMD.Text = "0.0000";
            txtMD.TextAlignment = ContentAlignment.MiddleLeft;
            txtMD.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtMD.Watermark = "请输入颗粒密度";
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new Font("宋体", 12F);
            uiLabel9.ForeColor = Color.Red;
            uiLabel9.Location = new Point(9, 282);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(99, 29);
            uiLabel9.TabIndex = 52;
            uiLabel9.Text = "密度：";
            uiLabel9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDL
            // 
            txtDL.DecimalPlaces = 4;
            txtDL.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtDL.Location = new Point(113, 338);
            txtDL.Margin = new Padding(4, 5, 4, 5);
            txtDL.MinimumSize = new Size(1, 16);
            txtDL.Name = "txtDL";
            txtDL.Padding = new Padding(5);
            txtDL.ShowText = false;
            txtDL.Size = new Size(287, 29);
            txtDL.TabIndex = 56;
            txtDL.Text = "0.0000";
            txtDL.TextAlignment = ContentAlignment.MiddleLeft;
            txtDL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtDL.Watermark = "请输入颗粒当量";
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new Font("宋体", 12F);
            uiLabel11.ForeColor = Color.Red;
            uiLabel11.Location = new Point(9, 338);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new Size(99, 29);
            uiLabel11.TabIndex = 55;
            uiLabel11.Text = "当量：";
            uiLabel11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHISM
            // 
            txtHISM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtHISM.Location = new Point(562, 411);
            txtHISM.Margin = new Padding(4, 5, 4, 5);
            txtHISM.MaxLength = 50;
            txtHISM.MinimumSize = new Size(1, 16);
            txtHISM.Name = "txtHISM";
            txtHISM.Padding = new Padding(5);
            txtHISM.ShowText = false;
            txtHISM.Size = new Size(287, 29);
            txtHISM.TabIndex = 59;
            txtHISM.TextAlignment = ContentAlignment.MiddleLeft;
            txtHISM.Watermark = "请输入颗粒HIS码";
            // 
            // uiLabel12
            // 
            uiLabel12.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel12.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel12.Location = new Point(456, 411);
            uiLabel12.Name = "uiLabel12";
            uiLabel12.Size = new Size(99, 29);
            uiLabel12.TabIndex = 58;
            uiLabel12.Text = "HIS码：";
            uiLabel12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtLSJ
            // 
            txtLSJ.DecimalPlaces = 4;
            txtLSJ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtLSJ.Location = new Point(562, 52);
            txtLSJ.Margin = new Padding(4, 5, 4, 5);
            txtLSJ.MinimumSize = new Size(1, 16);
            txtLSJ.Name = "txtLSJ";
            txtLSJ.Padding = new Padding(5);
            txtLSJ.ShowText = false;
            txtLSJ.Size = new Size(287, 29);
            txtLSJ.TabIndex = 61;
            txtLSJ.Text = "0.0000";
            txtLSJ.TextAlignment = ContentAlignment.MiddleLeft;
            txtLSJ.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtLSJ.Watermark = "请输入颗粒零售价";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(456, 52);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(99, 29);
            uiLabel2.TabIndex = 60;
            uiLabel2.Text = "零售价：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtGHJ
            // 
            txtGHJ.DecimalPlaces = 4;
            txtGHJ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtGHJ.Location = new Point(562, 113);
            txtGHJ.Margin = new Padding(4, 5, 4, 5);
            txtGHJ.MinimumSize = new Size(1, 16);
            txtGHJ.Name = "txtGHJ";
            txtGHJ.Padding = new Padding(5);
            txtGHJ.ShowText = false;
            txtGHJ.Size = new Size(287, 29);
            txtGHJ.TabIndex = 63;
            txtGHJ.Text = "0.0000";
            txtGHJ.TextAlignment = ContentAlignment.MiddleLeft;
            txtGHJ.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtGHJ.Watermark = "请输入颗粒供货价";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(456, 113);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(99, 29);
            uiLabel3.TabIndex = 62;
            uiLabel3.Text = "供货价：";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtJLSX
            // 
            txtJLSX.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtJLSX.Location = new Point(562, 171);
            txtJLSX.Margin = new Padding(4, 5, 4, 5);
            txtJLSX.MinimumSize = new Size(1, 16);
            txtJLSX.Name = "txtJLSX";
            txtJLSX.Padding = new Padding(5);
            txtJLSX.ShowText = false;
            txtJLSX.Size = new Size(287, 29);
            txtJLSX.TabIndex = 65;
            txtJLSX.Text = "0.00";
            txtJLSX.TextAlignment = ContentAlignment.MiddleLeft;
            txtJLSX.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtJLSX.Watermark = "请输入颗粒剂量上限";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(456, 171);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(99, 29);
            uiLabel7.TabIndex = 64;
            uiLabel7.Text = "剂量上限：";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDBZM
            // 
            txtDBZM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtDBZM.Location = new Point(562, 229);
            txtDBZM.Margin = new Padding(4, 5, 4, 5);
            txtDBZM.MaxLength = 20;
            txtDBZM.MinimumSize = new Size(1, 16);
            txtDBZM.Name = "txtDBZM";
            txtDBZM.Padding = new Padding(5);
            txtDBZM.ShowText = false;
            txtDBZM.Size = new Size(287, 29);
            txtDBZM.TabIndex = 67;
            txtDBZM.TextAlignment = ContentAlignment.MiddleLeft;
            txtDBZM.Watermark = "请输入颗粒大包装码";
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new Point(456, 229);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(99, 29);
            uiLabel8.TabIndex = 66;
            uiLabel8.Text = "大包装码：";
            uiLabel8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSSBH
            // 
            txtSSBH.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtSSBH.Location = new Point(113, 527);
            txtSSBH.Margin = new Padding(4, 5, 4, 5);
            txtSSBH.MaxLength = 50;
            txtSSBH.MinimumSize = new Size(1, 16);
            txtSSBH.Name = "txtSSBH";
            txtSSBH.Padding = new Padding(5);
            txtSSBH.ShowText = false;
            txtSSBH.Size = new Size(287, 29);
            txtSSBH.TabIndex = 69;
            txtSSBH.TextAlignment = ContentAlignment.MiddleLeft;
            txtSSBH.Watermark = "请输入颗粒上市编号";
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel10.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel10.Location = new Point(9, 527);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new Size(99, 29);
            uiLabel10.TabIndex = 68;
            uiLabel10.Text = "上市编号：";
            uiLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMCQP
            // 
            txtMCQP.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMCQP.Location = new Point(113, 411);
            txtMCQP.Margin = new Padding(4, 5, 4, 5);
            txtMCQP.MaxLength = 500;
            txtMCQP.MinimumSize = new Size(1, 16);
            txtMCQP.Name = "txtMCQP";
            txtMCQP.Padding = new Padding(5);
            txtMCQP.ShowText = false;
            txtMCQP.Size = new Size(287, 29);
            txtMCQP.TabIndex = 71;
            txtMCQP.TextAlignment = ContentAlignment.MiddleLeft;
            txtMCQP.Watermark = "请输入颗粒名称全拼";
            // 
            // uiLabel13
            // 
            uiLabel13.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel13.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel13.Location = new Point(9, 411);
            uiLabel13.Name = "uiLabel13";
            uiLabel13.Size = new Size(99, 29);
            uiLabel13.TabIndex = 70;
            uiLabel13.Text = "名称全拼：";
            uiLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMCJP
            // 
            txtMCJP.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtMCJP.Location = new Point(113, 465);
            txtMCJP.Margin = new Padding(4, 5, 4, 5);
            txtMCJP.MaxLength = 500;
            txtMCJP.MinimumSize = new Size(1, 16);
            txtMCJP.Name = "txtMCJP";
            txtMCJP.Padding = new Padding(5);
            txtMCJP.ShowText = false;
            txtMCJP.Size = new Size(287, 29);
            txtMCJP.TabIndex = 73;
            txtMCJP.TextAlignment = ContentAlignment.MiddleLeft;
            txtMCJP.Watermark = "请输入颗粒名称简拼";
            // 
            // uiLabel14
            // 
            uiLabel14.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel14.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel14.Location = new Point(9, 465);
            uiLabel14.Name = "uiLabel14";
            uiLabel14.Size = new Size(99, 29);
            uiLabel14.TabIndex = 72;
            uiLabel14.Text = "名称简拼：";
            uiLabel14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTM
            // 
            lblTM.Enabled = false;
            lblTM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblTM.ForeColor = Color.FromArgb(48, 48, 48);
            lblTM.Location = new Point(9, 592);
            lblTM.Name = "lblTM";
            lblTM.Size = new Size(99, 23);
            lblTM.TabIndex = 74;
            lblTM.Text = "包装条码：";
            lblTM.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBZTM
            // 
            txtBZTM.Enabled = false;
            txtBZTM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtBZTM.Location = new Point(113, 586);
            txtBZTM.Margin = new Padding(4, 5, 4, 5);
            txtBZTM.MinimumSize = new Size(1, 16);
            txtBZTM.Name = "txtBZTM";
            txtBZTM.Padding = new Padding(5);
            txtBZTM.ShowText = false;
            txtBZTM.Size = new Size(287, 29);
            txtBZTM.TabIndex = 75;
            txtBZTM.TextAlignment = ContentAlignment.MiddleLeft;
            txtBZTM.Watermark = "请扫描包装条码";
            // 
            // btnSB
            // 
            btnSB.Enabled = false;
            btnSB.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSB.Location = new Point(430, 586);
            btnSB.MinimumSize = new Size(1, 1);
            btnSB.Name = "btnSB";
            btnSB.Size = new Size(96, 29);
            btnSB.TabIndex = 76;
            btnSB.Text = "识别条码";
            btnSB.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSB.Click += btnSB_Click;
            // 
            // txtBZ
            // 
            txtBZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtBZ.Location = new Point(562, 527);
            txtBZ.Margin = new Padding(4, 5, 4, 5);
            txtBZ.MaxLength = 200;
            txtBZ.MinimumSize = new Size(1, 16);
            txtBZ.Multiline = true;
            txtBZ.Name = "txtBZ";
            txtBZ.Padding = new Padding(5);
            txtBZ.ShowText = false;
            txtBZ.Size = new Size(287, 45);
            txtBZ.TabIndex = 78;
            txtBZ.TextAlignment = ContentAlignment.MiddleLeft;
            txtBZ.Watermark = "请输入颗粒备注";
            // 
            // uiLabel16
            // 
            uiLabel16.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel16.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel16.Location = new Point(456, 527);
            uiLabel16.Name = "uiLabel16";
            uiLabel16.Size = new Size(99, 29);
            uiLabel16.TabIndex = 77;
            uiLabel16.Text = "备注：";
            uiLabel16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtXQZ
            // 
            txtXQZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtXQZ.Location = new Point(562, 338);
            txtXQZ.Margin = new Padding(4, 5, 4, 5);
            txtXQZ.MaxLength = 500;
            txtXQZ.MinimumSize = new Size(1, 16);
            txtXQZ.Name = "txtXQZ";
            txtXQZ.Padding = new Padding(5);
            txtXQZ.ShowText = false;
            txtXQZ.Size = new Size(287, 29);
            txtXQZ.TabIndex = 82;
            txtXQZ.TextAlignment = ContentAlignment.MiddleLeft;
            txtXQZ.Watermark = "请输入颗粒有效期截止时间";
            // 
            // uiLabel17
            // 
            uiLabel17.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel17.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel17.Location = new Point(456, 338);
            uiLabel17.Name = "uiLabel17";
            uiLabel17.Size = new Size(99, 29);
            uiLabel17.TabIndex = 81;
            uiLabel17.Text = "有效期至：";
            uiLabel17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtPH
            // 
            txtPH.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPH.Location = new Point(562, 282);
            txtPH.Margin = new Padding(4, 5, 4, 5);
            txtPH.MaxLength = 50;
            txtPH.MinimumSize = new Size(1, 16);
            txtPH.Name = "txtPH";
            txtPH.Padding = new Padding(5);
            txtPH.ShowText = false;
            txtPH.Size = new Size(287, 29);
            txtPH.TabIndex = 80;
            txtPH.TextAlignment = ContentAlignment.MiddleLeft;
            txtPH.Watermark = "请输入颗粒批号";
            // 
            // uiLabel18
            // 
            uiLabel18.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel18.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel18.Location = new Point(456, 282);
            uiLabel18.Name = "uiLabel18";
            uiLabel18.Size = new Size(99, 29);
            uiLabel18.TabIndex = 79;
            uiLabel18.Text = "批号：";
            uiLabel18.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHISMC
            // 
            txtHISMC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtHISMC.Location = new Point(562, 465);
            txtHISMC.Margin = new Padding(4, 5, 4, 5);
            txtHISMC.MaxLength = 50;
            txtHISMC.MinimumSize = new Size(1, 16);
            txtHISMC.Name = "txtHISMC";
            txtHISMC.Padding = new Padding(5);
            txtHISMC.ShowText = false;
            txtHISMC.Size = new Size(287, 29);
            txtHISMC.TabIndex = 84;
            txtHISMC.TextAlignment = ContentAlignment.MiddleLeft;
            txtHISMC.Watermark = "请输入颗粒HIS名称";
            // 
            // uiLabel15
            // 
            uiLabel15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel15.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel15.Location = new Point(456, 465);
            uiLabel15.Name = "uiLabel15";
            uiLabel15.Size = new Size(99, 29);
            uiLabel15.TabIndex = 83;
            uiLabel15.Text = "HI名称：";
            uiLabel15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmDrugEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(891, 695);
            Controls.Add(txtHISMC);
            Controls.Add(uiLabel15);
            Controls.Add(txtXQZ);
            Controls.Add(uiLabel17);
            Controls.Add(txtPH);
            Controls.Add(uiLabel18);
            Controls.Add(txtBZ);
            Controls.Add(uiLabel16);
            Controls.Add(btnSB);
            Controls.Add(txtBZTM);
            Controls.Add(lblTM);
            Controls.Add(txtMCJP);
            Controls.Add(uiLabel14);
            Controls.Add(txtMCQP);
            Controls.Add(uiLabel13);
            Controls.Add(txtSSBH);
            Controls.Add(uiLabel10);
            Controls.Add(txtDBZM);
            Controls.Add(uiLabel8);
            Controls.Add(txtJLSX);
            Controls.Add(uiLabel7);
            Controls.Add(txtGHJ);
            Controls.Add(uiLabel3);
            Controls.Add(txtLSJ);
            Controls.Add(uiLabel2);
            Controls.Add(txtHISM);
            Controls.Add(uiLabel12);
            Controls.Add(txtDL);
            Controls.Add(uiLabel11);
            Controls.Add(txtMD);
            Controls.Add(uiLabel9);
            Controls.Add(txtKLM);
            Controls.Add(uiLabel6);
            Controls.Add(txtQC);
            Controls.Add(uiLabel5);
            Controls.Add(cbCJ);
            Controls.Add(txtJC);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel1);
            Name = "FrmDrugEdit";
            Text = "新增药品";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtJC, 0);
            Controls.SetChildIndex(cbCJ, 0);
            Controls.SetChildIndex(uiLabel5, 0);
            Controls.SetChildIndex(txtQC, 0);
            Controls.SetChildIndex(uiLabel6, 0);
            Controls.SetChildIndex(txtKLM, 0);
            Controls.SetChildIndex(uiLabel9, 0);
            Controls.SetChildIndex(txtMD, 0);
            Controls.SetChildIndex(uiLabel11, 0);
            Controls.SetChildIndex(txtDL, 0);
            Controls.SetChildIndex(uiLabel12, 0);
            Controls.SetChildIndex(txtHISM, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(txtLSJ, 0);
            Controls.SetChildIndex(uiLabel3, 0);
            Controls.SetChildIndex(txtGHJ, 0);
            Controls.SetChildIndex(uiLabel7, 0);
            Controls.SetChildIndex(txtJLSX, 0);
            Controls.SetChildIndex(uiLabel8, 0);
            Controls.SetChildIndex(txtDBZM, 0);
            Controls.SetChildIndex(uiLabel10, 0);
            Controls.SetChildIndex(txtSSBH, 0);
            Controls.SetChildIndex(uiLabel13, 0);
            Controls.SetChildIndex(txtMCQP, 0);
            Controls.SetChildIndex(uiLabel14, 0);
            Controls.SetChildIndex(txtMCJP, 0);
            Controls.SetChildIndex(lblTM, 0);
            Controls.SetChildIndex(txtBZTM, 0);
            Controls.SetChildIndex(btnSB, 0);
            Controls.SetChildIndex(uiLabel16, 0);
            Controls.SetChildIndex(txtBZ, 0);
            Controls.SetChildIndex(uiLabel18, 0);
            Controls.SetChildIndex(txtPH, 0);
            Controls.SetChildIndex(uiLabel17, 0);
            Controls.SetChildIndex(txtXQZ, 0);
            Controls.SetChildIndex(uiLabel15, 0);
            Controls.SetChildIndex(txtHISMC, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITextBox txtJC;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cbCJ;
        private Sunny.UI.UITextBox txtQC;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtKLM;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtMD;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox txtDL;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UITextBox txtHISM;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITextBox txtLSJ;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtGHJ;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtJLSX;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txtDBZM;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox txtSSBH;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITextBox txtMCQP;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UITextBox txtMCJP;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UILabel lblTM;
        private Sunny.UI.UITextBox txtBZTM;
        private Sunny.UI.UIButton btnSB;
        private Sunny.UI.UITextBox txtBZ;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UITextBox txtXQZ;
        private Sunny.UI.UILabel uiLabel17;
        private Sunny.UI.UITextBox txtPH;
        private Sunny.UI.UILabel uiLabel18;
        private Sunny.UI.UITextBox txtHISMC;
        private Sunny.UI.UILabel uiLabel15;
    }
}