namespace AdjustmentSysUI.Forms
{
    partial class FrmHomePage
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
            panel1 = new Panel();
            label1 = new Label();
            lblLoadingPreCount = new Label();
            panel2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            label4 = new Label();
            label5 = new Label();
            panel4 = new Panel();
            label6 = new Label();
            label7 = new Label();
            uiBarChart1 = new Sunny.UI.UIBarChart();
            uiLineChart1 = new Sunny.UI.UILineChart();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SkyBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblLoadingPreCount);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(36, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 120);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(32, 80);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "待下载处方";
            // 
            // lblLoadingPreCount
            // 
            lblLoadingPreCount.AutoSize = true;
            lblLoadingPreCount.Font = new Font("宋体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblLoadingPreCount.Location = new Point(61, 29);
            lblLoadingPreCount.Name = "lblLoadingPreCount";
            lblLoadingPreCount.Size = new Size(45, 29);
            lblLoadingPreCount.TabIndex = 1;
            lblLoadingPreCount.Text = "20";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SkyBlue;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(260, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(172, 120);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("宋体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(61, 29);
            label2.Name = "label2";
            label2.Size = new Size(45, 29);
            label2.TabIndex = 1;
            label2.Text = "20";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(30, 80);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 0;
            label3.Text = "待核对处方";
            // 
            // panel3
            // 
            panel3.BackColor = Color.SkyBlue;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(472, 65);
            panel3.Name = "panel3";
            panel3.Size = new Size(172, 120);
            panel3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("宋体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(61, 35);
            label4.Name = "label4";
            label4.Size = new Size(45, 29);
            label4.TabIndex = 1;
            label4.Text = "20";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.Location = new Point(32, 80);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 0;
            label5.Text = "调剂中处方";
            // 
            // panel4
            // 
            panel4.BackColor = Color.SkyBlue;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(702, 65);
            panel4.Name = "panel4";
            panel4.Size = new Size(172, 120);
            panel4.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("宋体", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label6.Location = new Point(61, 35);
            label6.Name = "label6";
            label6.Size = new Size(45, 29);
            label6.TabIndex = 1;
            label6.Text = "20";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label7.Location = new Point(23, 80);
            label7.Name = "label7";
            label7.Size = new Size(129, 20);
            label7.TabIndex = 0;
            label7.Text = "调剂完成处方";
            // 
            // uiBarChart1
            // 
            uiBarChart1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiBarChart1.LegendFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiBarChart1.Location = new Point(36, 263);
            uiBarChart1.MinimumSize = new Size(1, 1);
            uiBarChart1.Name = "uiBarChart1";
            uiBarChart1.Size = new Size(400, 300);
            uiBarChart1.SubFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiBarChart1.TabIndex = 5;
            uiBarChart1.Text = "uiBarChart1";
            // 
            // uiLineChart1
            // 
            uiLineChart1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLineChart1.LegendFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLineChart1.Location = new Point(469, 263);
            uiLineChart1.MinimumSize = new Size(1, 1);
            uiLineChart1.MouseDownType = Sunny.UI.UILineChartMouseDownType.Zoom;
            uiLineChart1.Name = "uiLineChart1";
            uiLineChart1.Size = new Size(405, 294);
            uiLineChart1.SubFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLineChart1.TabIndex = 7;
            uiLineChart1.Text = "uiLineChart1";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiGroupBox1.Location = new Point(36, 613);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(831, 186);
            uiGroupBox1.TabIndex = 8;
            uiGroupBox1.Text = "设备异常信息";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // FrmHomePage
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(913, 823);
            ControlBoxCloseFillHoverColor = Color.Transparent;
            Controls.Add(uiGroupBox1);
            Controls.Add(uiLineChart1);
            Controls.Add(uiBarChart1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmHomePage";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 61461;
            Text = "首页";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblLoadingPreCount;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private Label label5;
        private Panel panel4;
        private Label label6;
        private Label label7;
        private Sunny.UI.UIBarChart uiBarChart1;
        private Sunny.UI.UILineChart uiLineChart1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
    }
}