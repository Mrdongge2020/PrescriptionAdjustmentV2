namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmStockSet
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
            components = new System.ComponentModel.Container();
            txtKCYL = new Sunny.UI.UITextBox();
            label2 = new Label();
            label4 = new Label();
            lblINFO = new Label();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            timer1 = new System.Windows.Forms.Timer(components);
            lblDQCZ = new LinkLabel();
            label5 = new Label();
            lblName = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // txtKCYL
            // 
            txtKCYL.DecimalPlaces = 4;
            txtKCYL.Font = new Font("微软雅黑", 12F);
            txtKCYL.Location = new Point(115, 163);
            txtKCYL.Margin = new Padding(4, 5, 4, 5);
            txtKCYL.MinimumSize = new Size(1, 16);
            txtKCYL.Name = "txtKCYL";
            txtKCYL.Padding = new Padding(5);
            txtKCYL.ShowText = false;
            txtKCYL.Size = new Size(152, 29);
            txtKCYL.TabIndex = 60;
            txtKCYL.Text = "0.0000";
            txtKCYL.TextAlignment = ContentAlignment.MiddleLeft;
            txtKCYL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtKCYL.Watermark = "请输入颗粒密度";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F);
            label2.Location = new Point(18, 167);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 59;
            label2.Text = "库存余量：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 12F);
            label4.Location = new Point(18, 100);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 58;
            label4.Text = "颗粒名称：";
            // 
            // lblINFO
            // 
            lblINFO.AutoSize = true;
            lblINFO.Font = new Font("微软雅黑", 12F);
            lblINFO.ForeColor = Color.Blue;
            lblINFO.Location = new Point(18, 56);
            lblINFO.Name = "lblINFO";
            lblINFO.Size = new Size(218, 21);
            lblINFO.TabIndex = 62;
            lblINFO.Text = "提示：请将药瓶放入称重工位";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("微软雅黑", 12F);
            btnCancel.Location = new Point(272, 221);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Radius = 10;
            btnCancel.Size = new Size(90, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 92;
            btnCancel.TabStop = false;
            btnCancel.Text = "取 消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("微软雅黑", 12F);
            btnOK.Location = new Point(127, 221);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Radius = 10;
            btnOK.Size = new Size(90, 35);
            btnOK.TabIndex = 91;
            btnOK.Text = "确 定";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(3, 195);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(373, 20);
            uiLine1.TabIndex = 90;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // lblDQCZ
            // 
            lblDQCZ.ActiveLinkColor = Color.Black;
            lblDQCZ.AutoSize = true;
            lblDQCZ.Enabled = false;
            lblDQCZ.Font = new Font("微软雅黑", 12F);
            lblDQCZ.LinkColor = Color.FromArgb(64, 64, 64);
            lblDQCZ.Location = new Point(115, 132);
            lblDQCZ.Name = "lblDQCZ";
            lblDQCZ.Size = new Size(19, 21);
            lblDQCZ.TabIndex = 98;
            lblDQCZ.TabStop = true;
            lblDQCZ.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 12F);
            label5.Location = new Point(18, 132);
            label5.Name = "label5";
            label5.Size = new Size(90, 21);
            label5.TabIndex = 97;
            label5.Text = "当前称重：";
            // 
            // lblName
            // 
            lblName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblName.ForeColor = Color.FromArgb(48, 48, 48);
            lblName.Location = new Point(115, 100);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 100;
            lblName.Text = "当归";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmStockSet
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(379, 275);
            Controls.Add(lblName);
            Controls.Add(lblDQCZ);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(lblINFO);
            Controls.Add(txtKCYL);
            Controls.Add(label2);
            Controls.Add(label4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmStockSet";
            Text = "库存设置";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            FormClosed += FrmStockSet_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Sunny.UI.UITextBox txtKCYL;
        private Label label2;
        private Label label4;
        private Label lblINFO;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.Timer timer1;
        private LinkLabel lblDQCZ;
        private Label label5;
        private Sunny.UI.UILabel lblName;
    }
}