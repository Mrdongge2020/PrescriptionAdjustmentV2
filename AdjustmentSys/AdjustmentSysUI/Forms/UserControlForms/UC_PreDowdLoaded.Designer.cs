namespace AdjustmentSysUI.Forms.UserControlForms
{
    partial class UC_PreDowdLoaded
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
            uiPanel1 = new Sunny.UI.UIPanel();
            cbZDJJ = new CheckBox();
            lblDownLoad = new Sunny.UI.UISymbolLabel();
            FLPpreLoad = new Sunny.UI.UIFlowLayoutPanel();
            cmsDownLoad = new Sunny.UI.UIContextMenuStrip();
            核对处方ToolStripMenuItem = new ToolStripMenuItem();
            复位处方ToolStripMenuItem = new ToolStripMenuItem();
            开始调剂ToolStripMenuItem = new ToolStripMenuItem();
            终止调剂ToolStripMenuItem = new ToolStripMenuItem();
            uiPanel1.SuspendLayout();
            cmsDownLoad.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.BackColor = SystemColors.Control;
            uiPanel1.Controls.Add(cbZDJJ);
            uiPanel1.Controls.Add(lblDownLoad);
            uiPanel1.FillColor = SystemColors.Control;
            uiPanel1.FillColor2 = SystemColors.Control;
            uiPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel1.Location = new Point(0, 0);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(325, 40);
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cbZDJJ
            // 
            cbZDJJ.AutoSize = true;
            cbZDJJ.BackColor = SystemColors.Control;
            cbZDJJ.Enabled = false;
            cbZDJJ.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbZDJJ.Location = new Point(217, 8);
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
            lblDownLoad.Click += lblDownLoad_Click;
            // 
            // FLPpreLoad
            // 
            FLPpreLoad.ContextMenuStrip = cmsDownLoad;
            FLPpreLoad.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FLPpreLoad.Location = new Point(0, 41);
            FLPpreLoad.Margin = new Padding(4, 5, 4, 5);
            FLPpreLoad.MinimumSize = new Size(1, 1);
            FLPpreLoad.Name = "FLPpreLoad";
            FLPpreLoad.Padding = new Padding(2);
            FLPpreLoad.ShowText = false;
            FLPpreLoad.Size = new Size(325, 639);
            FLPpreLoad.TabIndex = 1;
            FLPpreLoad.Text = "uiFlowLayoutPanel1";
            FLPpreLoad.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cmsDownLoad
            // 
            cmsDownLoad.BackColor = Color.FromArgb(243, 249, 255);
            cmsDownLoad.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsDownLoad.Items.AddRange(new ToolStripItem[] { 核对处方ToolStripMenuItem, 复位处方ToolStripMenuItem, 开始调剂ToolStripMenuItem, 终止调剂ToolStripMenuItem });
            cmsDownLoad.Name = "cmsDownLoad";
            cmsDownLoad.Size = new Size(145, 108);
            // 
            // 核对处方ToolStripMenuItem
            // 
            核对处方ToolStripMenuItem.Name = "核对处方ToolStripMenuItem";
            核对处方ToolStripMenuItem.Size = new Size(144, 26);
            核对处方ToolStripMenuItem.Text = "核对处方";
            // 
            // 复位处方ToolStripMenuItem
            // 
            复位处方ToolStripMenuItem.Name = "复位处方ToolStripMenuItem";
            复位处方ToolStripMenuItem.Size = new Size(144, 26);
            复位处方ToolStripMenuItem.Text = "复位处方";
            复位处方ToolStripMenuItem.Click += 复位处方ToolStripMenuItem_Click;
            // 
            // 开始调剂ToolStripMenuItem
            // 
            开始调剂ToolStripMenuItem.Name = "开始调剂ToolStripMenuItem";
            开始调剂ToolStripMenuItem.Size = new Size(144, 26);
            开始调剂ToolStripMenuItem.Text = "开始调剂";
            // 
            // 终止调剂ToolStripMenuItem
            // 
            终止调剂ToolStripMenuItem.Name = "终止调剂ToolStripMenuItem";
            终止调剂ToolStripMenuItem.Size = new Size(144, 26);
            终止调剂ToolStripMenuItem.Text = "终止调剂";
            // 
            // UC_PreDowdLoaded
            // 
            Controls.Add(FLPpreLoad);
            Controls.Add(uiPanel1);
            Name = "UC_PreDowdLoaded";
            Size = new Size(326, 680);
            uiPanel1.ResumeLayout(false);
            uiPanel1.PerformLayout();
            cmsDownLoad.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolLabel lblDownLoad;
        private CheckBox cbZDJJ;
        private Sunny.UI.UIFlowLayoutPanel FLPpreLoad;
        private Sunny.UI.UIContextMenuStrip cmsDownLoad;
        private ToolStripMenuItem 核对处方ToolStripMenuItem;
        private ToolStripMenuItem 复位处方ToolStripMenuItem;
        private ToolStripMenuItem 开始调剂ToolStripMenuItem;
        private ToolStripMenuItem 终止调剂ToolStripMenuItem;
    }
}
