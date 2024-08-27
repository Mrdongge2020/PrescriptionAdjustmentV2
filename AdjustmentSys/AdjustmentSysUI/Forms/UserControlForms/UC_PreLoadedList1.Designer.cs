namespace AdjustmentSysUI.Forms.UserControlForms
{
    partial class UC_PreLoadedList1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            FLPpreLoad = new Sunny.UI.UIFlowLayoutPanel();
            uiPanel1 = new Sunny.UI.UIPanel();
            cbZDJJ = new CheckBox();
            lblDownLoad = new Sunny.UI.UISymbolLabel();
            btnCheck = new Sunny.UI.UIButton();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // FLPpreLoad
            // 
            FLPpreLoad.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FLPpreLoad.Location = new Point(4, 45);
            FLPpreLoad.Margin = new Padding(4, 5, 4, 5);
            FLPpreLoad.MinimumSize = new Size(1, 1);
            FLPpreLoad.Name = "FLPpreLoad";
            FLPpreLoad.Padding = new Padding(2);
            FLPpreLoad.ShowText = false;
            FLPpreLoad.Size = new Size(289, 573);
            FLPpreLoad.TabIndex = 8;
            FLPpreLoad.Text = "uiFlowLayoutPanel1";
            FLPpreLoad.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiPanel1
            // 
            uiPanel1.BackColor = SystemColors.Control;
            uiPanel1.Controls.Add(cbZDJJ);
            uiPanel1.Controls.Add(lblDownLoad);
            uiPanel1.FillColor = SystemColors.Control;
            uiPanel1.FillColor2 = SystemColors.Control;
            uiPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel1.Location = new Point(4, 4);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(289, 40);
            uiPanel1.TabIndex = 7;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cbZDJJ
            // 
            cbZDJJ.AutoSize = true;
            cbZDJJ.BackColor = SystemColors.Control;
            cbZDJJ.Enabled = false;
            cbZDJJ.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbZDJJ.Location = new Point(189, 8);
            cbZDJJ.Name = "cbZDJJ";
            cbZDJJ.Size = new Size(93, 25);
            cbZDJJ.TabIndex = 4;
            cbZDJJ.Text = "自动进给";
            cbZDJJ.UseVisualStyleBackColor = false;
            // 
            // lblDownLoad
            // 
            lblDownLoad.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblDownLoad.Location = new Point(2, 5);
            lblDownLoad.MinimumSize = new Size(1, 1);
            lblDownLoad.Name = "lblDownLoad";
            lblDownLoad.RectSize = 2;
            lblDownLoad.Size = new Size(150, 31);
            lblDownLoad.Symbol = 57490;
            lblDownLoad.SymbolColor = Color.MediumSlateBlue;
            lblDownLoad.TabIndex = 3;
            lblDownLoad.Text = "下载处方(F1)";
            //lblDownLoad.Click += lblDownLoad_Click;
            // 
            // btnCheck
            // 
            btnCheck.FillColor = SystemColors.Control;
            btnCheck.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCheck.ForeColor = Color.Black;
            btnCheck.Location = new Point(4, 621);
            btnCheck.MinimumSize = new Size(1, 1);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(289, 35);
            btnCheck.TabIndex = 9;
            btnCheck.Text = "核对处方";
            btnCheck.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // UC_PreLoadedList1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(FLPpreLoad);
            Controls.Add(uiPanel1);
            Controls.Add(btnCheck);
            Name = "UC_PreLoadedList1";
            Size = new Size(299, 663);
            uiPanel1.ResumeLayout(false);
            uiPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel FLPpreLoad;
        private Sunny.UI.UIPanel uiPanel1;
        private CheckBox cbZDJJ;
        private Sunny.UI.UISymbolLabel lblDownLoad;
        private Sunny.UI.UIButton btnCheck;
    }
}
