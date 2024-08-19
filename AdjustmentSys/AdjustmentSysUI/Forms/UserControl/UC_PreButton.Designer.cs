namespace AdjustmentSysUI.Forms.UserControl
{
    partial class UC_PreButton
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
            SuspendLayout();
            // 
            // UC_PreButton
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "UC_PreButton";
            Size = new Size(276, 118);
            Paint += UC_PreButton_Paint;
            ResumeLayout(false);
        }

        #endregion
    }
}
