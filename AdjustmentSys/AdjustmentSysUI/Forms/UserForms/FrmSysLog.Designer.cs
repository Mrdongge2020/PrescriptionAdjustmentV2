namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    partial class FrmSysLog
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
            cbLogType = new Sunny.UI.UIComboBox();
            cbCheckLog = new Sunny.UI.UIComboBox();
            uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            SuspendLayout();
            // 
            // cbLogType
            // 
            cbLogType.DataSource = null;
            cbLogType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbLogType.FillColor = Color.White;
            cbLogType.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbLogType.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbLogType.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbLogType.Location = new Point(10, 50);
            cbLogType.Margin = new Padding(4, 5, 4, 5);
            cbLogType.MinimumSize = new Size(63, 0);
            cbLogType.Name = "cbLogType";
            cbLogType.Padding = new Padding(0, 0, 30, 2);
            cbLogType.Size = new Size(243, 30);
            cbLogType.SymbolSize = 24;
            cbLogType.TabIndex = 19;
            cbLogType.TextAlignment = ContentAlignment.MiddleLeft;
            cbLogType.Watermark = "请选择日志类型";
            cbLogType.SelectedIndexChanged += cbLogType_SelectedIndexChanged;
            // 
            // cbCheckLog
            // 
            cbCheckLog.DataSource = null;
            cbCheckLog.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbCheckLog.FillColor = Color.White;
            cbCheckLog.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbCheckLog.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbCheckLog.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbCheckLog.Location = new Point(275, 51);
            cbCheckLog.Margin = new Padding(4, 5, 4, 5);
            cbCheckLog.MinimumSize = new Size(63, 0);
            cbCheckLog.Name = "cbCheckLog";
            cbCheckLog.Padding = new Padding(0, 0, 30, 2);
            cbCheckLog.Size = new Size(313, 30);
            cbCheckLog.SymbolSize = 24;
            cbCheckLog.TabIndex = 21;
            cbCheckLog.TextAlignment = ContentAlignment.MiddleLeft;
            cbCheckLog.Watermark = "请选择日志文件";
            cbCheckLog.SelectedIndexChanged += cbCheckLog_SelectedIndexChanged;
            // 
            // uiRichTextBox1
            // 
            uiRichTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiRichTextBox1.FillColor = Color.White;
            uiRichTextBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiRichTextBox1.Location = new Point(10, 91);
            uiRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiRichTextBox1.MinimumSize = new Size(1, 1);
            uiRichTextBox1.Name = "uiRichTextBox1";
            uiRichTextBox1.Padding = new Padding(2);
            uiRichTextBox1.ScrollBarStyleInherited = false;
            uiRichTextBox1.ShowText = false;
            uiRichTextBox1.Size = new Size(1111, 577);
            uiRichTextBox1.TabIndex = 22;
            uiRichTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FrmSysLog
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1136, 699);
            Controls.Add(uiRichTextBox1);
            Controls.Add(cbCheckLog);
            Controls.Add(cbLogType);
            Name = "FrmSysLog";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "系统管理>>系统日志查询";
            Load += FrmSysLog_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIComboBox cbLogType;
        private Sunny.UI.UIComboBox cbCheckLog;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
    }
}