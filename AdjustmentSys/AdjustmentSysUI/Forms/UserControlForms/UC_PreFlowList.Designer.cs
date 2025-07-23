namespace AdjustmentSysUI.Forms.UserControlForms
{
    partial class UC_PreFlowList
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
            flpPreList = new Sunny.UI.UIFlowLayoutPanel();
            btnPreLoad = new Sunny.UI.UISymbolButton();
            cmsQZ = new Sunny.UI.UIContextMenuStrip();
            tsmiHDCF = new ToolStripMenuItem();
            tsmiFWCF = new ToolStripMenuItem();
            tsmiTJCF = new ToolStripMenuItem();
            cmsQZ.SuspendLayout();
            SuspendLayout();
            // 
            // flpPreList
            // 
            flpPreList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flpPreList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            flpPreList.Location = new Point(4, 46);
            flpPreList.Margin = new Padding(4, 5, 4, 5);
            flpPreList.MinimumSize = new Size(1, 1);
            flpPreList.Name = "flpPreList";
            flpPreList.Padding = new Padding(2);
            flpPreList.ShowText = false;
            flpPreList.Size = new Size(262, 629);
            flpPreList.TabIndex = 0;
            flpPreList.Text = "uiFlowLayoutPanel1";
            flpPreList.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnPreLoad
            // 
            btnPreLoad.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnPreLoad.Location = new Point(4, 3);
            btnPreLoad.MinimumSize = new Size(1, 1);
            btnPreLoad.Name = "btnPreLoad";
            btnPreLoad.Size = new Size(263, 35);
            btnPreLoad.Symbol = 57490;
            btnPreLoad.SymbolOffset = new Point(-10, 0);
            btnPreLoad.TabIndex = 1;
            btnPreLoad.Text = "下 载 处 方（F1）";
            btnPreLoad.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnPreLoad.Click += btnPreLoad_Click;
            // 
            // cmsQZ
            // 
            cmsQZ.BackColor = Color.FromArgb(243, 249, 255);
            cmsQZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmsQZ.Items.AddRange(new ToolStripItem[] { tsmiHDCF, tsmiFWCF, tsmiTJCF });
            cmsQZ.Name = "cmsQZ";
            cmsQZ.Size = new Size(139, 70);
            cmsQZ.Text = "核对处方";
            // 
            // tsmiHDCF
            // 
            tsmiHDCF.Name = "tsmiHDCF";
            tsmiHDCF.Size = new Size(138, 22);
            tsmiHDCF.Text = "核对处方";
            tsmiHDCF.Click += tsmiHDCF_Click;
            // 
            // tsmiFWCF
            // 
            tsmiFWCF.Name = "tsmiFWCF";
            tsmiFWCF.Size = new Size(138, 22);
            tsmiFWCF.Text = "复位处方";
            tsmiFWCF.Click += tsmiFWCF_Click;
            // 
            // tsmiTJCF
            // 
            tsmiTJCF.Name = "tsmiTJCF";
            tsmiTJCF.Size = new Size(138, 22);
            tsmiTJCF.Text = "调剂处方";
            // 
            // UC_PreFlowList
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(btnPreLoad);
            Controls.Add(flpPreList);
            Name = "UC_PreFlowList";
            Size = new Size(270, 680);
            cmsQZ.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel flpPreList;
        private Sunny.UI.UISymbolButton btnPreLoad;
        private Sunny.UI.UIContextMenuStrip cmsQZ;
        private ToolStripMenuItem tsmiHDCF;
        private ToolStripMenuItem tsmiFWCF;
        private ToolStripMenuItem tsmiTJCF;
    }
}
