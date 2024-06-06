namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmMedicineCabinetEdit
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
            cbGG = new Sunny.UI.UIComboBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txtYGMC = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            txtYGBZ = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            iupHXGS = new Sunny.UI.UIIntegerUpDown();
            iudZXGS = new Sunny.UI.UIIntegerUpDown();
            uiLabel6 = new Sunny.UI.UILabel();
            txtBZ = new Sunny.UI.UITextBox();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 489);
            pnlBtm.Size = new Size(645, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(517, 12);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(402, 12);
            btnOK.Click += btnOK_Click;
            // 
            // cbGG
            // 
            cbGG.DataSource = null;
            cbGG.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbGG.FillColor = Color.White;
            cbGG.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbGG.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbGG.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbGG.Location = new Point(183, 185);
            cbGG.Margin = new Padding(4, 5, 4, 5);
            cbGG.MinimumSize = new Size(63, 0);
            cbGG.Name = "cbGG";
            cbGG.Padding = new Padding(0, 0, 30, 2);
            cbGG.Size = new Size(287, 29);
            cbGG.SymbolSize = 24;
            cbGG.TabIndex = 59;
            cbGG.TextAlignment = ContentAlignment.MiddleLeft;
            cbGG.Watermark = "请选择药柜规格";
            cbGG.SelectedValueChanged += cbGG_SelectedValueChanged;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F);
            uiLabel5.ForeColor = Color.Red;
            uiLabel5.Location = new Point(77, 127);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(99, 29);
            uiLabel5.TabIndex = 58;
            uiLabel5.Text = "柜组编号：";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtYGMC
            // 
            txtYGMC.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtYGMC.Location = new Point(183, 69);
            txtYGMC.Margin = new Padding(4, 5, 4, 5);
            txtYGMC.MaxLength = 20;
            txtYGMC.MinimumSize = new Size(1, 16);
            txtYGMC.Name = "txtYGMC";
            txtYGMC.Padding = new Padding(5);
            txtYGMC.ShowText = false;
            txtYGMC.Size = new Size(287, 29);
            txtYGMC.TabIndex = 57;
            txtYGMC.TextAlignment = ContentAlignment.MiddleLeft;
            txtYGMC.Watermark = "请输入药柜名称";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F);
            uiLabel4.ForeColor = Color.Red;
            uiLabel4.Location = new Point(77, 69);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(99, 29);
            uiLabel4.TabIndex = 56;
            uiLabel4.Text = "药柜名称：";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F);
            uiLabel1.ForeColor = Color.Black;
            uiLabel1.Location = new Point(77, 185);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(99, 29);
            uiLabel1.TabIndex = 60;
            uiLabel1.Text = "规格：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtYGBZ
            // 
            txtYGBZ.DoubleValue = 20000D;
            txtYGBZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtYGBZ.IntValue = 20000;
            txtYGBZ.Location = new Point(183, 127);
            txtYGBZ.Margin = new Padding(4, 5, 4, 5);
            txtYGBZ.MaxLength = 50;
            txtYGBZ.MinimumSize = new Size(1, 16);
            txtYGBZ.Name = "txtYGBZ";
            txtYGBZ.Padding = new Padding(5);
            txtYGBZ.ShowText = false;
            txtYGBZ.Size = new Size(287, 29);
            txtYGBZ.TabIndex = 61;
            txtYGBZ.Text = "20000";
            txtYGBZ.TextAlignment = ContentAlignment.MiddleLeft;
            txtYGBZ.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            txtYGBZ.Watermark = "设备编组";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F);
            uiLabel2.ForeColor = Color.Red;
            uiLabel2.Location = new Point(77, 303);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(99, 29);
            uiLabel2.TabIndex = 63;
            uiLabel2.Text = "单层个数：";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F);
            uiLabel3.ForeColor = Color.Red;
            uiLabel3.Location = new Point(77, 241);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(99, 29);
            uiLabel3.TabIndex = 62;
            uiLabel3.Text = "药柜层数：";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // iupHXGS
            // 
            iupHXGS.Enabled = false;
            iupHXGS.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iupHXGS.Location = new Point(183, 241);
            iupHXGS.Margin = new Padding(4, 5, 4, 5);
            iupHXGS.Minimum = 0;
            iupHXGS.MinimumSize = new Size(100, 0);
            iupHXGS.Name = "iupHXGS";
            iupHXGS.ShowText = false;
            iupHXGS.Size = new Size(129, 29);
            iupHXGS.TabIndex = 64;
            iupHXGS.Text = "uiIntegerUpDown1";
            iupHXGS.TextAlignment = ContentAlignment.MiddleCenter;
            iupHXGS.Value = 14;
            // 
            // iudZXGS
            // 
            iudZXGS.Enabled = false;
            iudZXGS.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            iudZXGS.Location = new Point(183, 303);
            iudZXGS.Margin = new Padding(4, 5, 4, 5);
            iudZXGS.Maximum = 100000;
            iudZXGS.Minimum = 0;
            iudZXGS.MinimumSize = new Size(100, 0);
            iudZXGS.Name = "iudZXGS";
            iudZXGS.ShowText = false;
            iudZXGS.Size = new Size(129, 29);
            iudZXGS.TabIndex = 65;
            iudZXGS.Text = null;
            iudZXGS.TextAlignment = ContentAlignment.MiddleCenter;
            iudZXGS.Value = 16;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 12F);
            uiLabel6.ForeColor = Color.Black;
            uiLabel6.Location = new Point(77, 366);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(99, 29);
            uiLabel6.TabIndex = 66;
            uiLabel6.Text = "备注：";
            uiLabel6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtBZ
            // 
            txtBZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtBZ.Location = new Point(183, 366);
            txtBZ.Margin = new Padding(4, 5, 4, 5);
            txtBZ.MaxLength = 200;
            txtBZ.MinimumSize = new Size(1, 16);
            txtBZ.Multiline = true;
            txtBZ.Name = "txtBZ";
            txtBZ.Padding = new Padding(5);
            txtBZ.ShowText = false;
            txtBZ.Size = new Size(287, 90);
            txtBZ.TabIndex = 67;
            txtBZ.TextAlignment = ContentAlignment.MiddleLeft;
            txtBZ.Watermark = "";
            // 
            // FrmMedicineCabinetEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(647, 547);
            Controls.Add(txtBZ);
            Controls.Add(uiLabel6);
            Controls.Add(iudZXGS);
            Controls.Add(iupHXGS);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel3);
            Controls.Add(txtYGBZ);
            Controls.Add(uiLabel1);
            Controls.Add(cbGG);
            Controls.Add(uiLabel5);
            Controls.Add(txtYGMC);
            Controls.Add(uiLabel4);
            Name = "FrmMedicineCabinetEdit";
            Text = "新增药柜";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmMedicineCabinetEdit_Load;
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtYGMC, 0);
            Controls.SetChildIndex(uiLabel5, 0);
            Controls.SetChildIndex(cbGG, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(txtYGBZ, 0);
            Controls.SetChildIndex(uiLabel3, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(iupHXGS, 0);
            Controls.SetChildIndex(iudZXGS, 0);
            Controls.SetChildIndex(uiLabel6, 0);
            Controls.SetChildIndex(txtBZ, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox cbGG;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtYGMC;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtYGBZ;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIIntegerUpDown iupHXGS;
        private Sunny.UI.UIIntegerUpDown iudZXGS;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtBZ;
    }
}