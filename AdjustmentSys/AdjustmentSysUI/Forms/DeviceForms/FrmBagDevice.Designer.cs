namespace AdjustmentSysUI.Forms.DeviceForms
{
    partial class FrmBagDevice
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
            SuspendLayout();
            // 
            // FrmBagDevice
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1064, 660);
            Name = "FrmBagDevice";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 361641;
            Text = "调剂管理>>处方调剂";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmBagDevice_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}