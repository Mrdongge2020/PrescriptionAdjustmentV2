namespace AdjustmentSysUI.Forms.UserControl
{
    partial class UC_PrescriptionAdjustmentList
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
            lblDownLoadCount = new Label();
            cbZDJJ = new CheckBox();
            panel1 = new Panel();
            uiFlowLayoutPanel1 = new Sunny.UI.UIFlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblDownLoadCount
            // 
            lblDownLoadCount.AutoSize = true;
            lblDownLoadCount.BackColor = SystemColors.Control;
            lblDownLoadCount.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblDownLoadCount.Location = new Point(12, 11);
            lblDownLoadCount.Name = "lblDownLoadCount";
            lblDownLoadCount.Size = new Size(140, 21);
            lblDownLoadCount.TabIndex = 0;
            lblDownLoadCount.Text = "已下载列表（10）";
            // 
            // cbZDJJ
            // 
            cbZDJJ.AutoSize = true;
            cbZDJJ.BackColor = SystemColors.Control;
            cbZDJJ.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbZDJJ.Location = new Point(170, 10);
            cbZDJJ.Name = "cbZDJJ";
            cbZDJJ.Size = new Size(93, 25);
            cbZDJJ.TabIndex = 1;
            cbZDJJ.Text = "自动进给";
            cbZDJJ.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDownLoadCount);
            panel1.Controls.Add(cbZDJJ);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 53);
            panel1.TabIndex = 2;
            // 
            // uiFlowLayoutPanel1
            // 
            uiFlowLayoutPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiFlowLayoutPanel1.Location = new Point(0, 50);
            uiFlowLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            uiFlowLayoutPanel1.MinimumSize = new Size(1, 1);
            uiFlowLayoutPanel1.Name = "uiFlowLayoutPanel1";
            uiFlowLayoutPanel1.Padding = new Padding(2);
            uiFlowLayoutPanel1.ShowText = false;
            uiFlowLayoutPanel1.Size = new Size(290, 780);
            uiFlowLayoutPanel1.TabIndex = 3;
            uiFlowLayoutPanel1.Text = "uiFlowLayoutPanel1";
            uiFlowLayoutPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // UC_PrescriptionAdjustmentList
            // 
            Controls.Add(uiFlowLayoutPanel1);
            Controls.Add(panel1);
            Name = "UC_PrescriptionAdjustmentList";
            Size = new Size(293, 844);
            Load += UC_PrescriptionAdjustmentList_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblDownLoadCount;
        private CheckBox cbZDJJ;
        private Panel panel1;
        private Sunny.UI.UIFlowLayoutPanel uiFlowLayoutPanel1;
    }
}
