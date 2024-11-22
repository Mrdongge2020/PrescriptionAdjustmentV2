namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmAdjustmentOfSurplus
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
            lblINFO = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtKCYL = new Sunny.UI.UITextBox();
            txtTPQPZL = new Sunny.UI.UITextBox();
            txtTZL = new Sunny.UI.UITextBox();
            txtJC = new Sunny.UI.UITextBox();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblINFO
            // 
            lblINFO.AutoSize = true;
            lblINFO.Font = new Font("微软雅黑", 12F);
            lblINFO.ForeColor = Color.Blue;
            lblINFO.Location = new Point(72, 60);
            lblINFO.Name = "lblINFO";
            lblINFO.Size = new Size(218, 21);
            lblINFO.TabIndex = 43;
            lblINFO.Text = "提示：请将药瓶放入称重工位";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F);
            label3.Location = new Point(7, 196);
            label3.Name = "label3";
            label3.Size = new Size(122, 21);
            label3.TabIndex = 47;
            label3.Text = "天平去皮重量：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F);
            label2.Location = new Point(39, 152);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 46;
            label2.Text = "库存余量：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 12F);
            label4.Location = new Point(39, 107);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 45;
            label4.Text = "颗粒名称：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 12F);
            label5.Location = new Point(55, 245);
            label5.Name = "label5";
            label5.Size = new Size(74, 21);
            label5.TabIndex = 48;
            label5.Text = "调整量：";
            // 
            // txtKCYL
            // 
            txtKCYL.DecimalPlaces = 4;
            txtKCYL.Font = new Font("微软雅黑", 12F);
            txtKCYL.Location = new Point(136, 148);
            txtKCYL.Margin = new Padding(4, 5, 4, 5);
            txtKCYL.MinimumSize = new Size(1, 16);
            txtKCYL.Name = "txtKCYL";
            txtKCYL.Padding = new Padding(5);
            txtKCYL.ReadOnly = true;
            txtKCYL.ShowText = false;
            txtKCYL.Size = new Size(220, 29);
            txtKCYL.TabIndex = 54;
            txtKCYL.Text = "0.0000";
            txtKCYL.TextAlignment = ContentAlignment.MiddleLeft;
            txtKCYL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtKCYL.Watermark = "请输入颗粒密度";
            // 
            // txtTPQPZL
            // 
            txtTPQPZL.DecimalPlaces = 4;
            txtTPQPZL.Font = new Font("微软雅黑", 12F);
            txtTPQPZL.Location = new Point(136, 192);
            txtTPQPZL.Margin = new Padding(4, 5, 4, 5);
            txtTPQPZL.MinimumSize = new Size(1, 16);
            txtTPQPZL.Name = "txtTPQPZL";
            txtTPQPZL.Padding = new Padding(5);
            txtTPQPZL.ReadOnly = true;
            txtTPQPZL.ShowText = false;
            txtTPQPZL.Size = new Size(220, 29);
            txtTPQPZL.TabIndex = 55;
            txtTPQPZL.Text = "0.0000";
            txtTPQPZL.TextAlignment = ContentAlignment.MiddleLeft;
            txtTPQPZL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtTPQPZL.Watermark = "请输入颗粒密度";
            // 
            // txtTZL
            // 
            txtTZL.DecimalPlaces = 4;
            txtTZL.Font = new Font("微软雅黑", 12F);
            txtTZL.Location = new Point(136, 241);
            txtTZL.Margin = new Padding(4, 5, 4, 5);
            txtTZL.MinimumSize = new Size(1, 16);
            txtTZL.Name = "txtTZL";
            txtTZL.Padding = new Padding(5);
            txtTZL.ReadOnly = true;
            txtTZL.ShowText = false;
            txtTZL.Size = new Size(220, 29);
            txtTZL.TabIndex = 56;
            txtTZL.Text = "0.0000";
            txtTZL.TextAlignment = ContentAlignment.MiddleLeft;
            txtTZL.Type = Sunny.UI.UITextBox.UIEditType.Double;
            txtTZL.Watermark = "请输入颗粒密度";
            // 
            // txtJC
            // 
            txtJC.Font = new Font("微软雅黑", 12F);
            txtJC.Location = new Point(136, 99);
            txtJC.Margin = new Padding(4, 5, 4, 5);
            txtJC.MaxLength = 20;
            txtJC.MinimumSize = new Size(1, 16);
            txtJC.Name = "txtJC";
            txtJC.Padding = new Padding(5);
            txtJC.ReadOnly = true;
            txtJC.ShowText = false;
            txtJC.Size = new Size(220, 29);
            txtJC.TabIndex = 57;
            txtJC.TextAlignment = ContentAlignment.MiddleLeft;
            txtJC.Watermark = "颗粒名称简称";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("微软雅黑", 12F);
            btnCancel.Location = new Point(306, 316);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 89;
            btnCancel.TabStop = false;
            btnCancel.Text = "取 消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("微软雅黑", 12F);
            btnOK.Location = new Point(140, 316);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 88;
            btnOK.Text = "确定调整";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(4, 290);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(489, 20);
            uiLine1.TabIndex = 87;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // FrmAdjustmentOfSurplus
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(454, 379);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(txtJC);
            Controls.Add(txtTZL);
            Controls.Add(txtTPQPZL);
            Controls.Add(txtKCYL);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(lblINFO);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAdjustmentOfSurplus";
            Text = "余量校准";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 636, 379);
            FormClosed += FrmAdjustmentOfSurplus_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblINFO;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private Sunny.UI.UITextBox txtKCYL;
        private Sunny.UI.UITextBox txtTPQPZL;
        private Sunny.UI.UITextBox txtTZL;
        private Sunny.UI.UITextBox txtJC;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.Timer timer1;
    }
}