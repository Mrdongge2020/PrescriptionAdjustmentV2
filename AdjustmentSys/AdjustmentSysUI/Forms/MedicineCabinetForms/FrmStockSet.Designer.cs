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
            txtJC = new Sunny.UI.UITextBox();
            txtKCYL = new Sunny.UI.UITextBox();
            label2 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtJC
            // 
            txtJC.Font = new Font("微软雅黑", 12F);
            txtJC.Location = new Point(115, 92);
            txtJC.Margin = new Padding(4, 5, 4, 5);
            txtJC.MaxLength = 20;
            txtJC.MinimumSize = new Size(1, 16);
            txtJC.Name = "txtJC";
            txtJC.Padding = new Padding(5);
            txtJC.ReadOnly = true;
            txtJC.ShowText = false;
            txtJC.Size = new Size(220, 29);
            txtJC.TabIndex = 61;
            txtJC.TextAlignment = ContentAlignment.MiddleLeft;
            txtJC.Watermark = "颗粒名称简称";
            // 
            // txtKCYL
            // 
            txtKCYL.DecimalPlaces = 4;
            txtKCYL.Font = new Font("微软雅黑", 12F);
            txtKCYL.Location = new Point(115, 145);
            txtKCYL.Margin = new Padding(4, 5, 4, 5);
            txtKCYL.MinimumSize = new Size(1, 16);
            txtKCYL.Name = "txtKCYL";
            txtKCYL.Padding = new Padding(5);
            txtKCYL.ShowText = false;
            txtKCYL.Size = new Size(220, 29);
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
            label2.Location = new Point(18, 145);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(18, 56);
            label1.Name = "label1";
            label1.Size = new Size(218, 21);
            label1.TabIndex = 62;
            label1.Text = "提示：请将药瓶放入称重工位";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("微软雅黑", 12F);
            btnCancel.Location = new Point(236, 232);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 92;
            btnCancel.TabStop = false;
            btnCancel.Text = "取 消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btnOK
            // 
            btnOK.Font = new Font("微软雅黑", 12F);
            btnOK.Location = new Point(70, 232);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(99, 35);
            btnOK.TabIndex = 91;
            btnOK.Text = "确定调整";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F);
            label3.Location = new Point(339, 149);
            label3.Name = "label3";
            label3.Size = new Size(20, 21);
            label3.TabIndex = 93;
            label3.Text = "g";
            // 
            // FrmStockSet
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(379, 293);
            Controls.Add(label3);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(label1);
            Controls.Add(txtJC);
            Controls.Add(txtKCYL);
            Controls.Add(label2);
            Controls.Add(label4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmStockSet";
            Text = "库存设置";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UITextBox txtJC;
        private Sunny.UI.UITextBox txtKCYL;
        private Label label2;
        private Label label4;
        private Label label1;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
        private Label label3;
    }
}