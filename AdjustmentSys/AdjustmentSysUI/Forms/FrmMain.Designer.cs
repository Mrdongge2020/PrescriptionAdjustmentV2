namespace AdjustmentSysUI.Forms
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            navMenuMainLeft = new Sunny.UI.UINavMenu();
            uiNavBar1 = new Sunny.UI.UINavBar();
            uiTabControl1 = new Sunny.UI.UITabControl();
            timerRight = new System.Windows.Forms.Timer(components);
            pannelBottom = new Sunny.UI.UIPanel();
            lbltime = new Sunny.UI.UILabel();
            lblLoginUser = new Sunny.UI.UILabel();
            pannelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // navMenuMainLeft
            // 
            navMenuMainLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            navMenuMainLeft.BorderStyle = BorderStyle.None;
            navMenuMainLeft.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            navMenuMainLeft.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            navMenuMainLeft.FullRowSelect = true;
            navMenuMainLeft.ItemHeight = 50;
            navMenuMainLeft.Location = new Point(0, 160);
            navMenuMainLeft.Name = "navMenuMainLeft";
            navMenuMainLeft.ShowLines = false;
            navMenuMainLeft.Size = new Size(286, 745);
            navMenuMainLeft.TabIndex = 2;
            navMenuMainLeft.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // uiNavBar1
            // 
            uiNavBar1.BackColor = Color.FromArgb(240, 240, 240);
            uiNavBar1.Dock = DockStyle.Top;
            uiNavBar1.DropMenuFont = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiNavBar1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiNavBar1.Location = new Point(0, 35);
            uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            uiNavBar1.Name = "uiNavBar1";
            uiNavBar1.Size = new Size(1168, 125);
            uiNavBar1.TabIndex = 3;
            // 
            // uiTabControl1
            // 
            uiTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            uiTabControl1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTabControl1.ItemSize = new Size(0, 1);
            uiTabControl1.Location = new Point(286, 160);
            uiTabControl1.MainPage = "";
            uiTabControl1.Name = "uiTabControl1";
            uiTabControl1.SelectedIndex = 0;
            uiTabControl1.Size = new Size(882, 745);
            uiTabControl1.SizeMode = TabSizeMode.Fixed;
            uiTabControl1.TabIndex = 4;
            uiTabControl1.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
            uiTabControl1.TabVisible = false;
            uiTabControl1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // timerRight
            // 
            timerRight.Enabled = true;
            timerRight.Tick += timerRight_Tick;
            // 
            // pannelBottom
            // 
            pannelBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pannelBottom.Controls.Add(lbltime);
            pannelBottom.Controls.Add(lblLoginUser);
            pannelBottom.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            pannelBottom.Location = new Point(0, 905);
            pannelBottom.Margin = new Padding(4, 5, 4, 5);
            pannelBottom.MinimumSize = new Size(1, 1);
            pannelBottom.Name = "pannelBottom";
            pannelBottom.Size = new Size(1168, 34);
            pannelBottom.TabIndex = 10;
            pannelBottom.Text = null;
            pannelBottom.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lbltime
            // 
            lbltime.Anchor = AnchorStyles.Right;
            lbltime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbltime.ForeColor = Color.FromArgb(48, 48, 48);
            lbltime.Location = new Point(872, 1);
            lbltime.Name = "lbltime";
            lbltime.Size = new Size(296, 34);
            lbltime.TabIndex = 1;
            lbltime.Text = "时间";
            lbltime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLoginUser
            // 
            lblLoginUser.Anchor = AnchorStyles.Left;
            lblLoginUser.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblLoginUser.ForeColor = Color.FromArgb(48, 48, 48);
            lblLoginUser.Location = new Point(10, 1);
            lblLoginUser.Name = "lblLoginUser";
            lblLoginUser.Size = new Size(276, 34);
            lblLoginUser.TabIndex = 0;
            lblLoginUser.Text = "用户";
            lblLoginUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1168, 940);
            Controls.Add(pannelBottom);
            Controls.Add(uiTabControl1);
            Controls.Add(uiNavBar1);
            Controls.Add(navMenuMainLeft);
            Name = "FrmMain";
            Text = "家施德中医颗粒调剂系统";
            WindowState = FormWindowState.Maximized;
            ZoomScaleRect = new Rectangle(19, 19, 800, 450);
            pannelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UINavMenu navMenuMainLeft;
        private Sunny.UI.UINavBar uiNavBar1;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.Timer timerRight;
        private Sunny.UI.UIPanel pannelBottom;
        private Sunny.UI.UILabel lblLoginUser;
        private Sunny.UI.UILabel lbltime;
    }
}