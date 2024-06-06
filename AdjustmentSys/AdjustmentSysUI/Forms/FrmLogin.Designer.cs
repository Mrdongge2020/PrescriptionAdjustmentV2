namespace AdjustmentSysUI
{
    partial class FrmLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(21, 22);
            this.lblTitle.Text = "家施德中医颗粒调剂系统";
            // 
            // uiPanel1
            // 
            this.uiPanel1.Location = new System.Drawing.Point(432, 131);
            this.uiPanel1.Size = new System.Drawing.Size(191, 240);
            // 
            // lblSubText
            // 
            this.lblSubText.Location = new System.Drawing.Point(405, 421);
            this.lblSubText.Text = "v2.0.1";
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Name = "FrmLogin";
            this.SubText = "v2.0.1";
            this.Text = "Form1";
            this.Title = "家施德中医颗粒调剂系统";
            this.ButtonLoginClick += new System.EventHandler(this.FrmLogin_ButtonLoginClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

