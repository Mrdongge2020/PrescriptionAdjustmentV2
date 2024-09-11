namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    partial class FrmMenu
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
            menuTreeView = new Sunny.UI.UITreeView();
            cbLevel = new Sunny.UI.UIComboBox();
            uiLabel7 = new Sunny.UI.UILabel();
            btnOK = new Sunny.UI.UISymbolButton();
            SuspendLayout();
            // 
            // menuTreeView
            // 
            menuTreeView.CheckBoxes = true;
            menuTreeView.FillColor = Color.White;
            menuTreeView.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            menuTreeView.Location = new Point(4, 88);
            menuTreeView.Margin = new Padding(4, 5, 4, 5);
            menuTreeView.MinimumSize = new Size(1, 1);
            menuTreeView.Name = "menuTreeView";
            menuTreeView.ScrollBarStyleInherited = false;
            menuTreeView.ShowText = false;
            menuTreeView.Size = new Size(411, 661);
            menuTreeView.TabIndex = 0;
            menuTreeView.Text = "uiTreeView1";
            menuTreeView.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cbLevel
            // 
            cbLevel.DataSource = null;
            cbLevel.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbLevel.FillColor = Color.White;
            cbLevel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cbLevel.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbLevel.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbLevel.Location = new Point(106, 48);
            cbLevel.Margin = new Padding(4, 5, 4, 5);
            cbLevel.MinimumSize = new Size(63, 0);
            cbLevel.Name = "cbLevel";
            cbLevel.Padding = new Padding(0, 0, 30, 2);
            cbLevel.Size = new Size(188, 29);
            cbLevel.SymbolSize = 24;
            cbLevel.TabIndex = 16;
            cbLevel.TextAlignment = ContentAlignment.MiddleLeft;
            cbLevel.Watermark = "请选择权限等级";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = Color.Black;
            uiLabel7.Location = new Point(14, 51);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(81, 23);
            uiLabel7.TabIndex = 17;
            uiLabel7.Text = "权限等级：";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnOK.Location = new Point(318, 45);
            btnOK.MinimumSize = new Size(1, 1);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(85, 32);
            btnOK.TabIndex = 35;
            btnOK.Text = "保 存";
            btnOK.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // FrmMenu
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1131, 755);
            Controls.Add(btnOK);
            Controls.Add(uiLabel7);
            Controls.Add(cbLevel);
            Controls.Add(menuTreeView);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "FrmMenu";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "系统设置>>系统权限设置";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Load += FrmMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITreeView menuTreeView;
        private Sunny.UI.UIComboBox cbLevel;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UISymbolButton btnOK;
    }
}