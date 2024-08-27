namespace AdjustmentSysUI.Forms.UserControlForms
{
    partial class PrescriptionAdjustmentList
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
            panel1 = new Panel();
            cbZDJJ = new CheckBox();
            cmsDownLoad = new Sunny.UI.UIContextMenuStrip();
            核对处方ToolStripMenuItem = new ToolStripMenuItem();
            复位处方ToolStripMenuItem = new ToolStripMenuItem();
            开始调剂ToolStripMenuItem = new ToolStripMenuItem();
            终止调剂ToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            cmsDownLoad.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(cbZDJJ);
            panel1.Location = new Point(1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(289, 39);
            panel1.TabIndex = 4;
            // 
            // cbZDJJ
            // 
            cbZDJJ.AutoSize = true;
            cbZDJJ.BackColor = SystemColors.Control;
            cbZDJJ.Enabled = false;
            cbZDJJ.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbZDJJ.Location = new Point(170, 6);
            cbZDJJ.Name = "cbZDJJ";
            cbZDJJ.Size = new Size(93, 25);
            cbZDJJ.TabIndex = 1;
            cbZDJJ.Text = "自动进给";
            cbZDJJ.UseVisualStyleBackColor = false;
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
            复位处方ToolStripMenuItem.Text = "复位处方";            // 
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
            // UC_PrescriptionAdjustmentList
            // 
            Controls.Add(panel1);
            Name = "UC_PrescriptionAdjustmentList";
            Size = new Size(293, 803);
            Load += UC_PrescriptionAdjustmentList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            cmsDownLoad.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private CheckBox cbZDJJ;
        private Sunny.UI.UIContextMenuStrip cmsDownLoad;
        private ToolStripMenuItem 核对处方ToolStripMenuItem;
        private ToolStripMenuItem 复位处方ToolStripMenuItem;
        private ToolStripMenuItem 开始调剂ToolStripMenuItem;
        private ToolStripMenuItem 终止调剂ToolStripMenuItem;
    }
}
