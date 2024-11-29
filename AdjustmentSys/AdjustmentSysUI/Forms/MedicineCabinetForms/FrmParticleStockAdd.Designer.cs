namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    partial class FrmParticleStockAdd
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
            lblSYZL = new LinkLabel();
            lblKCYL = new LinkLabel();
            lblParticleName = new LinkLabel();
            lblTZZL = new LinkLabel();
            lblDQCZ = new LinkLabel();
            label4 = new Label();
            label5 = new Label();
            cbCJ = new Sunny.UI.UIComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            btnSBTM = new Sunny.UI.UIButton();
            txtBZTM = new Sunny.UI.UITextBox();
            label7 = new Label();
            dtpDQRQ = new Sunny.UI.UIDatePicker();
            label8 = new Label();
            lbErroe = new Sunny.UI.UIListBox();
            btnCancel = new Sunny.UI.UISymbolButton();
            btnOK = new Sunny.UI.UISymbolButton();
            uiLine1 = new Sunny.UI.UILine();
            timerParticleStockAdd = new System.Windows.Forms.Timer(components);
            label13 = new Label();
            lblBatch = new Sunny.UI.UITextBox();
            SuspendLayout();
            // 
            // lblSYZL
            // 
            lblSYZL.ActiveLinkColor = Color.Black;
            lblSYZL.AutoSize = true;
            lblSYZL.Enabled = false;
            lblSYZL.Font = new Font("微软雅黑", 12F);
            lblSYZL.ForeColor = Color.Red;
            lblSYZL.LinkColor = Color.Red;
            lblSYZL.Location = new Point(126, 146);
            lblSYZL.Name = "lblSYZL";
            lblSYZL.Size = new Size(19, 21);
            lblSYZL.TabIndex = 47;
            lblSYZL.TabStop = true;
            lblSYZL.Text = "0";
            // 
            // lblKCYL
            // 
            lblKCYL.ActiveLinkColor = Color.Black;
            lblKCYL.AutoSize = true;
            lblKCYL.Enabled = false;
            lblKCYL.Font = new Font("微软雅黑", 12F);
            lblKCYL.LinkColor = Color.FromArgb(64, 64, 64);
            lblKCYL.Location = new Point(126, 102);
            lblKCYL.Name = "lblKCYL";
            lblKCYL.Size = new Size(19, 21);
            lblKCYL.TabIndex = 46;
            lblKCYL.TabStop = true;
            lblKCYL.Text = "0";
            // 
            // lblParticleName
            // 
            lblParticleName.ActiveLinkColor = Color.Black;
            lblParticleName.AutoSize = true;
            lblParticleName.Enabled = false;
            lblParticleName.Font = new Font("微软雅黑", 12F);
            lblParticleName.LinkColor = Color.FromArgb(64, 64, 64);
            lblParticleName.Location = new Point(126, 57);
            lblParticleName.Name = "lblParticleName";
            lblParticleName.Size = new Size(26, 21);
            lblParticleName.TabIndex = 45;
            lblParticleName.TabStop = true;
            lblParticleName.Text = "无";
            // 
            // lblTZZL
            // 
            lblTZZL.ActiveLinkColor = Color.Black;
            lblTZZL.AutoSize = true;
            lblTZZL.Enabled = false;
            lblTZZL.Font = new Font("微软雅黑", 12F);
            lblTZZL.LinkColor = Color.FromArgb(64, 64, 64);
            lblTZZL.Location = new Point(367, 146);
            lblTZZL.Name = "lblTZZL";
            lblTZZL.Size = new Size(19, 21);
            lblTZZL.TabIndex = 51;
            lblTZZL.TabStop = true;
            lblTZZL.Text = "0";
            // 
            // lblDQCZ
            // 
            lblDQCZ.ActiveLinkColor = Color.Black;
            lblDQCZ.AutoSize = true;
            lblDQCZ.Enabled = false;
            lblDQCZ.Font = new Font("微软雅黑", 12F);
            lblDQCZ.LinkColor = Color.FromArgb(64, 64, 64);
            lblDQCZ.Location = new Point(367, 102);
            lblDQCZ.Name = "lblDQCZ";
            lblDQCZ.Size = new Size(19, 21);
            lblDQCZ.TabIndex = 50;
            lblDQCZ.TabStop = true;
            lblDQCZ.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 12F);
            label4.Location = new Point(271, 146);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 49;
            label4.Text = "调整重量：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微软雅黑", 12F);
            label5.Location = new Point(271, 102);
            label5.Name = "label5";
            label5.Size = new Size(90, 21);
            label5.TabIndex = 48;
            label5.Text = "当前称重：";
            // 
            // cbCJ
            // 
            cbCJ.DataSource = null;
            cbCJ.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbCJ.FillColor = Color.White;
            cbCJ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbCJ.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbCJ.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbCJ.Location = new Point(126, 187);
            cbCJ.Margin = new Padding(4, 5, 4, 5);
            cbCJ.MinimumSize = new Size(63, 0);
            cbCJ.Name = "cbCJ";
            cbCJ.Padding = new Padding(0, 0, 30, 2);
            cbCJ.Size = new Size(327, 29);
            cbCJ.SymbolSize = 24;
            cbCJ.TabIndex = 53;
            cbCJ.TextAlignment = ContentAlignment.MiddleLeft;
            cbCJ.Watermark = "请选择颗粒厂家";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F);
            label1.Location = new Point(24, 57);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 42;
            label1.Text = "颗粒名称：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F);
            label2.Location = new Point(24, 102);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 43;
            label2.Text = "库存余量：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F);
            label3.Location = new Point(24, 146);
            label3.Name = "label3";
            label3.Size = new Size(90, 21);
            label3.TabIndex = 44;
            label3.Text = "上药重量：";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("微软雅黑", 12F);
            label6.Location = new Point(24, 187);
            label6.Name = "label6";
            label6.Size = new Size(90, 21);
            label6.TabIndex = 54;
            label6.Text = "颗粒厂家：";
            // 
            // btnSBTM
            // 
            btnSBTM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSBTM.Location = new Point(471, 229);
            btnSBTM.MinimumSize = new Size(1, 1);
            btnSBTM.Name = "btnSBTM";
            btnSBTM.Size = new Size(96, 29);
            btnSBTM.TabIndex = 79;
            btnSBTM.Text = "识别条码";
            btnSBTM.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSBTM.Click += btnSBTM_Click;
            // 
            // txtBZTM
            // 
            txtBZTM.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtBZTM.Location = new Point(126, 229);
            txtBZTM.Margin = new Padding(4, 5, 4, 5);
            txtBZTM.MinimumSize = new Size(1, 16);
            txtBZTM.Name = "txtBZTM";
            txtBZTM.Padding = new Padding(5);
            txtBZTM.ShowText = false;
            txtBZTM.Size = new Size(327, 29);
            txtBZTM.TabIndex = 78;
            txtBZTM.TextAlignment = ContentAlignment.MiddleLeft;
            txtBZTM.Watermark = "请扫描包装条码";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("微软雅黑", 12F);
            label7.Location = new Point(24, 233);
            label7.Name = "label7";
            label7.Size = new Size(90, 21);
            label7.TabIndex = 80;
            label7.Text = "包装条码：";
            // 
            // dtpDQRQ
            // 
            dtpDQRQ.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            dtpDQRQ.FillColor = Color.White;
            dtpDQRQ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtpDQRQ.Location = new Point(126, 277);
            dtpDQRQ.Margin = new Padding(4, 5, 4, 5);
            dtpDQRQ.MaxLength = 10;
            dtpDQRQ.MinimumSize = new Size(63, 0);
            dtpDQRQ.Name = "dtpDQRQ";
            dtpDQRQ.Padding = new Padding(0, 0, 30, 2);
            dtpDQRQ.ShowToday = true;
            dtpDQRQ.Size = new Size(112, 29);
            dtpDQRQ.SymbolDropDown = 61555;
            dtpDQRQ.SymbolNormal = 61555;
            dtpDQRQ.SymbolSize = 24;
            dtpDQRQ.TabIndex = 81;
            dtpDQRQ.Text = "2024-07-01";
            dtpDQRQ.TextAlignment = ContentAlignment.MiddleLeft;
            dtpDQRQ.Value = new DateTime(2024, 7, 1, 16, 18, 24, 274);
            dtpDQRQ.Watermark = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("微软雅黑", 12F);
            label8.Location = new Point(24, 281);
            label8.Name = "label8";
            label8.Size = new Size(90, 21);
            label8.TabIndex = 82;
            label8.Text = "到期日期：";
            // 
            // lbErroe
            // 
            lbErroe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbErroe.HoverColor = Color.FromArgb(155, 200, 255);
            lbErroe.ItemSelectForeColor = Color.White;
            lbErroe.Location = new Point(24, 316);
            lbErroe.Margin = new Padding(4, 5, 4, 5);
            lbErroe.MinimumSize = new Size(1, 1);
            lbErroe.Name = "lbErroe";
            lbErroe.Padding = new Padding(2);
            lbErroe.ShowText = false;
            lbErroe.Size = new Size(543, 121);
            lbErroe.TabIndex = 83;
            lbErroe.Text = "uiListBox1";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Location = new Point(471, 470);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Symbol = 361453;
            btnCancel.TabIndex = 86;
            btnCancel.TabStop = false;
            btnCancel.Text = "取 消";
            btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(305, 470);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 85;
            btnOK.Text = "确定添加";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Click += btnOK_Click;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(3, 444);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(588, 29);
            uiLine1.TabIndex = 84;
            // 
            // timerParticleStockAdd
            // 
            timerParticleStockAdd.Interval = 500;
            timerParticleStockAdd.Tick += timerParticleStockAdd_Tick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("微软雅黑", 12F);
            label13.Location = new Point(303, 281);
            label13.Name = "label13";
            label13.Size = new Size(58, 21);
            label13.TabIndex = 98;
            label13.Text = "批号：";
            // 
            // lblBatch
            // 
            lblBatch.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblBatch.Location = new Point(367, 277);
            lblBatch.Margin = new Padding(4, 5, 4, 5);
            lblBatch.MinimumSize = new Size(1, 16);
            lblBatch.Name = "lblBatch";
            lblBatch.Padding = new Padding(5);
            lblBatch.ShowText = false;
            lblBatch.Size = new Size(200, 29);
            lblBatch.TabIndex = 99;
            lblBatch.TextAlignment = ContentAlignment.MiddleLeft;
            lblBatch.Watermark = "";
            // 
            // FrmParticleStockAdd
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(592, 533);
            Controls.Add(lblBatch);
            Controls.Add(label13);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(uiLine1);
            Controls.Add(lbErroe);
            Controls.Add(label8);
            Controls.Add(dtpDQRQ);
            Controls.Add(label7);
            Controls.Add(btnSBTM);
            Controls.Add(txtBZTM);
            Controls.Add(label6);
            Controls.Add(cbCJ);
            Controls.Add(lblTZZL);
            Controls.Add(lblDQCZ);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(lblSYZL);
            Controls.Add(lblKCYL);
            Controls.Add(lblParticleName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmParticleStockAdd";
            Text = "颗粒库存添加";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            FormClosed += FrmParticleStockAdd_FormClosed;
            Load += FrmParticleStockAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel lblSYZL;
        private LinkLabel lblKCYL;
        private LinkLabel lblParticleName;
        private LinkLabel lblTZZL;
        private LinkLabel lblDQCZ;
        private Label label4;
        private Label label5;
        private Sunny.UI.UIComboBox cbCJ;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label6;
        private Sunny.UI.UIButton btnSBTM;
        private Sunny.UI.UITextBox txtBZTM;
        private Label label7;
        private Sunny.UI.UIDatePicker dtpDQRQ;
        private Label label8;
        private Sunny.UI.UIListBox lbErroe;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.Timer timerParticleStockAdd;
        private Label label13;
        private Sunny.UI.UITextBox lblBatch;
    }
}