namespace AdjustmentSysUI.Forms.UserControlForms
{
    partial class UC_WorkStationButton
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
            pbProcess = new Sunny.UI.UIProcessBar();
            uiLabel24 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            lblParticleName = new Sunny.UI.UILabel();
            lblStatus = new Sunny.UI.UILabel();
            lblStationName = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // pbProcess
            // 
            pbProcess.FillColor = Color.FromArgb(235, 243, 255);
            pbProcess.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            pbProcess.Location = new Point(3, 87);
            pbProcess.MinimumSize = new Size(70, 3);
            pbProcess.Name = "pbProcess";
            pbProcess.Radius = 0;
            pbProcess.Size = new Size(150, 3);
            pbProcess.TabIndex = 6;
            pbProcess.Text = "50%";
            pbProcess.Value = 50;
            // 
            // uiLabel24
            // 
            uiLabel24.BackColor = Color.Transparent;
            uiLabel24.Font = new Font("微软雅黑", 10.5F);
            uiLabel24.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel24.Location = new Point(3, 36);
            uiLabel24.Name = "uiLabel24";
            uiLabel24.Size = new Size(42, 23);
            uiLabel24.TabIndex = 7;
            uiLabel24.Text = "名称:";
            uiLabel24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(3, 58);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(42, 23);
            uiLabel1.TabIndex = 8;
            uiLabel1.Text = "状态:";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblParticleName
            // 
            lblParticleName.BackColor = Color.Transparent;
            lblParticleName.Font = new Font("微软雅黑", 10.5F);
            lblParticleName.ForeColor = Color.FromArgb(48, 48, 48);
            lblParticleName.Location = new Point(43, 36);
            lblParticleName.Name = "lblParticleName";
            lblParticleName.Size = new Size(107, 23);
            lblParticleName.Style = Sunny.UI.UIStyle.Custom;
            lblParticleName.TabIndex = 9;
            lblParticleName.Text = "天江炒王不留行";
            lblParticleName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("微软雅黑", 10.5F);
            lblStatus.ForeColor = Color.FromArgb(48, 48, 48);
            lblStatus.Location = new Point(43, 58);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(107, 23);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "无";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStationName
            // 
            lblStationName.BackColor = Color.Transparent;
            lblStationName.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblStationName.ForeColor = Color.FromArgb(48, 48, 48);
            lblStationName.Location = new Point(43, 6);
            lblStationName.Name = "lblStationName";
            lblStationName.Size = new Size(59, 23);
            lblStationName.TabIndex = 11;
            lblStationName.Text = "工位1";
            lblStationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_WorkStationButton
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(192, 192, 255);
            Controls.Add(lblStationName);
            Controls.Add(lblStatus);
            Controls.Add(lblParticleName);
            Controls.Add(uiLabel1);
            Controls.Add(uiLabel24);
            Controls.Add(pbProcess);
            ForeColor = Color.FromArgb(192, 192, 255);
            Name = "UC_WorkStationButton";
            RectColor = Color.FromArgb(192, 192, 255);
            Size = new Size(155, 95);
            Style = Sunny.UI.UIStyle.Custom;
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIProcessBar pbProcess;
        private Sunny.UI.UILabel uiLabel24;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel lblParticleName;
        private Sunny.UI.UILabel lblStatus;
        private Sunny.UI.UILabel lblStationName;
    }
}
