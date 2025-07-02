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
            lblDeviceName = new Sunny.UI.UILabel();
            lblDeviceConnectText = new Sunny.UI.UILabel();
            lbltime = new Sunny.UI.UILabel();
            lblLoginUser = new Sunny.UI.UILabel();
            pannelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // navMenuMainLeft
            // 
            navMenuMainLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            navMenuMainLeft.BackColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.BorderStyle = BorderStyle.FixedSingle;
            navMenuMainLeft.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            navMenuMainLeft.FillColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            navMenuMainLeft.ForeColor = Color.White;
            navMenuMainLeft.FullRowSelect = true;
            navMenuMainLeft.HoverColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.Indent = 200;
            navMenuMainLeft.ItemHeight = 50;
            navMenuMainLeft.LineColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.Location = new Point(0, 165);
            navMenuMainLeft.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            navMenuMainLeft.Name = "navMenuMainLeft";
            navMenuMainLeft.ScrollBarColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.ScrollBarHoverColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.ScrollBarPressColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.ScrollFillColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.SecondBackColor = Color.FromArgb(80, 126, 164);
            navMenuMainLeft.SelectedColor = Color.SteelBlue;
            navMenuMainLeft.SelectedColor2 = Color.SteelBlue;
            navMenuMainLeft.SelectedForeColor = Color.White;
            navMenuMainLeft.SelectedHighColor = Color.White;
            navMenuMainLeft.ShowItemsArrow = false;
            navMenuMainLeft.ShowLines = false;
            navMenuMainLeft.ShowOneNode = true;
            navMenuMainLeft.ShowPlusMinus = false;
            navMenuMainLeft.ShowRootLines = false;
            navMenuMainLeft.Size = new Size(286, 564);
            navMenuMainLeft.Style = Sunny.UI.UIStyle.Custom;
            navMenuMainLeft.TabIndex = 2;
            navMenuMainLeft.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // uiNavBar1
            // 
            uiNavBar1.BackColor = Color.FromArgb(243, 249, 255);
            uiNavBar1.Dock = DockStyle.Top;
            uiNavBar1.DropMenuFont = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiNavBar1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiNavBar1.ForeColor = Color.Black;
            uiNavBar1.Location = new Point(0, 40);
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
            uiTabControl1.Location = new Point(286, 165);
            uiTabControl1.MainPage = "";
            uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            uiTabControl1.Name = "uiTabControl1";
            uiTabControl1.SelectedIndex = 0;
            uiTabControl1.Size = new Size(882, 564);
            uiTabControl1.SizeMode = TabSizeMode.Fixed;
            uiTabControl1.TabBackColor = Color.FromArgb(243, 249, 255);
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
            pannelBottom.Controls.Add(lblDeviceName);
            pannelBottom.Controls.Add(lblDeviceConnectText);
            pannelBottom.Controls.Add(lbltime);
            pannelBottom.Controls.Add(lblLoginUser);
            pannelBottom.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            pannelBottom.Location = new Point(-2, 730);
            pannelBottom.Margin = new Padding(4, 5, 4, 5);
            pannelBottom.MinimumSize = new Size(1, 1);
            pannelBottom.Name = "pannelBottom";
            pannelBottom.RectColor = Color.FromArgb(128, 128, 255);
            pannelBottom.Size = new Size(1178, 32);
            pannelBottom.TabIndex = 10;
            pannelBottom.Text = null;
            pannelBottom.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblDeviceName
            // 
            lblDeviceName.Anchor = AnchorStyles.Left;
            lblDeviceName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblDeviceName.ForeColor = Color.FromArgb(48, 48, 48);
            lblDeviceName.Location = new Point(159, 3);
            lblDeviceName.Name = "lblDeviceName";
            lblDeviceName.Padding = new Padding(0, 0, 10, 0);
            lblDeviceName.Size = new Size(247, 23);
            lblDeviceName.TabIndex = 3;
            lblDeviceName.Text = "设备名称：家施德半自动盒装";
            lblDeviceName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDeviceConnectText
            // 
            lblDeviceConnectText.Anchor = AnchorStyles.Left;
            lblDeviceConnectText.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblDeviceConnectText.ForeColor = Color.FromArgb(48, 48, 48);
            lblDeviceConnectText.Location = new Point(412, 3);
            lblDeviceConnectText.Name = "lblDeviceConnectText";
            lblDeviceConnectText.Size = new Size(68, 23);
            lblDeviceConnectText.TabIndex = 2;
            lblDeviceConnectText.Text = "未连接";
            lblDeviceConnectText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbltime
            // 
            lbltime.Anchor = AnchorStyles.Right;
            lbltime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbltime.ForeColor = Color.FromArgb(48, 48, 48);
            lbltime.Location = new Point(896, 3);
            lbltime.Name = "lbltime";
            lbltime.Size = new Size(274, 23);
            lbltime.TabIndex = 1;
            lbltime.Text = "时间";
            lbltime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLoginUser
            // 
            lblLoginUser.Anchor = AnchorStyles.Left;
            lblLoginUser.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblLoginUser.ForeColor = Color.FromArgb(48, 48, 48);
            lblLoginUser.Location = new Point(2, 3);
            lblLoginUser.Name = "lblLoginUser";
            lblLoginUser.Size = new Size(126, 23);
            lblLoginUser.TabIndex = 0;
            lblLoginUser.Text = "用户";
            lblLoginUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1168, 758);
            ControlBox = false;
            Controls.Add(pannelBottom);
            Controls.Add(uiTabControl1);
            Controls.Add(uiNavBar1);
            Controls.Add(navMenuMainLeft);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Padding = new Padding(0, 40, 0, 0);
            RectColor = Color.FromArgb(80, 126, 164);
            Style = Sunny.UI.UIStyle.Custom;
            Text = "颗粒调剂系统";
            TitleColor = Color.FromArgb(80, 126, 164);
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            TitleHeight = 40;
            WindowState = FormWindowState.Maximized;
            ZoomScaleRect = new Rectangle(19, 19, 800, 450);
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
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
        private Sunny.UI.UILabel lblDeviceConnectText;
        private Sunny.UI.UILabel lblDeviceName;
    }
}