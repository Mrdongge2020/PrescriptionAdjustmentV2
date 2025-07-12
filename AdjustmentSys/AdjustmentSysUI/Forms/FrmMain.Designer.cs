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
            Sunny.UI.UIPanel uiPanel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            uiSymbolLabel3 = new Sunny.UI.UISymbolLabel();
            uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            lblCloseSys = new Sunny.UI.UISymbolButton();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            lblLoginUser = new Sunny.UI.UISymbolLabel();
            uiTabControl1 = new Sunny.UI.UITabControl();
            timerRight = new System.Windows.Forms.Timer(components);
            pannelBottom = new Sunny.UI.UIPanel();
            lblDeviceConnectText = new Sunny.UI.UISymbolLabel();
            lblDeviceName = new Sunny.UI.UILabel();
            navMenuMainLeft = new Sunny.UI.UINavMenu();
            uiLabel4 = new Sunny.UI.UILabel();
            uiPanel4 = new Sunny.UI.UIPanel();
            uiPanel2 = new Sunny.UI.UIPanel();
            uiPanel2.SuspendLayout();
            pannelBottom.SuspendLayout();
            uiPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // uiPanel2
            // 
            uiPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            uiPanel2.BackColor = Color.FromArgb(80, 126, 164);
            uiPanel2.Controls.Add(uiSymbolLabel3);
            uiPanel2.Controls.Add(uiSymbolLabel2);
            uiPanel2.Controls.Add(uiSymbolLabel1);
            uiPanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel2.ForeColor = Color.FromArgb(80, 126, 164);
            uiPanel2.Location = new Point(650, 1);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.RectColor = Color.FromArgb(243, 249, 255);
            uiPanel2.Size = new Size(520, 28);
            uiPanel2.Style = Sunny.UI.UIStyle.Custom;
            uiPanel2.TabIndex = 6;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel3
            // 
            uiSymbolLabel3.BackColor = Color.FromArgb(243, 249, 255);
            uiSymbolLabel3.Font = new Font("宋体", 10.5F);
            uiSymbolLabel3.Location = new Point(360, 4);
            uiSymbolLabel3.MinimumSize = new Size(1, 1);
            uiSymbolLabel3.Name = "uiSymbolLabel3";
            uiSymbolLabel3.Size = new Size(170, 23);
            uiSymbolLabel3.Symbol = 362152;
            uiSymbolLabel3.TabIndex = 2;
            uiSymbolLabel3.Text = "顶封温度:105.5 ℃";
            uiSymbolLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel2
            // 
            uiSymbolLabel2.BackColor = Color.FromArgb(243, 249, 255);
            uiSymbolLabel2.Font = new Font("宋体", 10.5F);
            uiSymbolLabel2.Location = new Point(185, 4);
            uiSymbolLabel2.MinimumSize = new Size(1, 1);
            uiSymbolLabel2.Name = "uiSymbolLabel2";
            uiSymbolLabel2.Size = new Size(170, 23);
            uiSymbolLabel2.Symbol = 362152;
            uiSymbolLabel2.TabIndex = 1;
            uiSymbolLabel2.Text = "底封温度:100.5 ℃";
            uiSymbolLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel1
            // 
            uiSymbolLabel1.BackColor = Color.FromArgb(243, 249, 255);
            uiSymbolLabel1.Font = new Font("宋体", 10.5F);
            uiSymbolLabel1.Location = new Point(10, 4);
            uiSymbolLabel1.MinimumSize = new Size(1, 1);
            uiSymbolLabel1.Name = "uiSymbolLabel1";
            uiSymbolLabel1.Size = new Size(170, 23);
            uiSymbolLabel1.Symbol = 362152;
            uiSymbolLabel1.TabIndex = 0;
            uiSymbolLabel1.Text = "竖封温度:95.5 ℃";
            uiSymbolLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCloseSys
            // 
            lblCloseSys.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCloseSys.Font = new Font("宋体", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCloseSys.Location = new Point(1044, 5);
            lblCloseSys.MinimumSize = new Size(1, 1);
            lblCloseSys.Name = "lblCloseSys";
            lblCloseSys.Radius = 25;
            lblCloseSys.Size = new Size(79, 41);
            lblCloseSys.Symbol = 361457;
            lblCloseSys.SymbolOffset = new Point(3, 0);
            lblCloseSys.SymbolSize = 25;
            lblCloseSys.TabIndex = 11;
            lblCloseSys.Text = "退出";
            lblCloseSys.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCloseSys.Click += lblCloseSys_Click;
            // 
            // uiLabel5
            // 
            uiLabel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            uiLabel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Image = (Image)resources.GetObject("uiLabel5.Image");
            uiLabel5.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel5.Location = new Point(170, 10);
            uiLabel5.Margin = new Padding(0);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(39, 30);
            uiLabel5.TabIndex = 13;
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            uiLabel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(67, 13);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(100, 25);
            uiLabel3.TabIndex = 12;
            uiLabel3.Text = "255.85g";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Image = (Image)resources.GetObject("uiLabel2.Image");
            uiLabel2.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel2.Location = new Point(18, 10);
            uiLabel2.Margin = new Padding(0);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(39, 30);
            uiLabel2.TabIndex = 0;
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLoginUser
            // 
            lblLoginUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLoginUser.Font = new Font("宋体", 10.5F);
            lblLoginUser.Location = new Point(6, 4);
            lblLoginUser.MinimumSize = new Size(1, 1);
            lblLoginUser.Name = "lblLoginUser";
            lblLoginUser.Size = new Size(282, 23);
            lblLoginUser.Symbol = 362470;
            lblLoginUser.TabIndex = 4;
            lblLoginUser.Text = "用户";
            lblLoginUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiTabControl1
            // 
            uiTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uiTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            uiTabControl1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTabControl1.ItemSize = new Size(0, 1);
            uiTabControl1.Location = new Point(337, 97);
            uiTabControl1.MainPage = "";
            uiTabControl1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            uiTabControl1.Name = "uiTabControl1";
            uiTabControl1.SelectedIndex = 0;
            uiTabControl1.Size = new Size(831, 632);
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
            pannelBottom.Controls.Add(uiPanel2);
            pannelBottom.Controls.Add(lblDeviceConnectText);
            pannelBottom.Controls.Add(lblDeviceName);
            pannelBottom.Controls.Add(lblLoginUser);
            pannelBottom.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            pannelBottom.ForeColor = Color.White;
            pannelBottom.Location = new Point(-2, 729);
            pannelBottom.Margin = new Padding(4, 5, 4, 5);
            pannelBottom.MinimumSize = new Size(1, 1);
            pannelBottom.Name = "pannelBottom";
            pannelBottom.RectColor = Color.FromArgb(243, 249, 255);
            pannelBottom.Size = new Size(1178, 33);
            pannelBottom.Style = Sunny.UI.UIStyle.Custom;
            pannelBottom.TabIndex = 10;
            pannelBottom.Text = null;
            pannelBottom.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblDeviceConnectText
            // 
            lblDeviceConnectText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDeviceConnectText.Font = new Font("宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblDeviceConnectText.Location = new Point(288, 4);
            lblDeviceConnectText.MinimumSize = new Size(1, 1);
            lblDeviceConnectText.Name = "lblDeviceConnectText";
            lblDeviceConnectText.Size = new Size(130, 23);
            lblDeviceConnectText.Symbol = 361931;
            lblDeviceConnectText.TabIndex = 5;
            lblDeviceConnectText.Text = "未连接";
            lblDeviceConnectText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDeviceName
            // 
            lblDeviceName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDeviceName.Font = new Font("宋体", 10.5F);
            lblDeviceName.ForeColor = Color.FromArgb(48, 48, 48);
            lblDeviceName.Location = new Point(424, 4);
            lblDeviceName.Name = "lblDeviceName";
            lblDeviceName.Padding = new Padding(0, 0, 10, 0);
            lblDeviceName.Size = new Size(204, 23);
            lblDeviceName.TabIndex = 3;
            lblDeviceName.Text = "设备名称：家施德半自动盒装";
            lblDeviceName.TextAlign = ContentAlignment.MiddleRight;
            lblDeviceName.Visible = false;
            // 
            // navMenuMainLeft
            // 
            navMenuMainLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            navMenuMainLeft.BorderStyle = BorderStyle.None;
            navMenuMainLeft.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            navMenuMainLeft.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            navMenuMainLeft.ForeColor = Color.White;
            navMenuMainLeft.FullRowSelect = true;
            navMenuMainLeft.ItemHeight = 50;
            navMenuMainLeft.Location = new Point(1, 97);
            navMenuMainLeft.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            navMenuMainLeft.Name = "navMenuMainLeft";
            navMenuMainLeft.ShowLines = false;
            navMenuMainLeft.ShowOneNode = true;
            navMenuMainLeft.Size = new Size(338, 632);
            navMenuMainLeft.TabIndex = 15;
            navMenuMainLeft.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // uiLabel4
            // 
            uiLabel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            uiLabel4.Font = new Font("宋体", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(219, 13);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(161, 25);
            uiLabel4.TabIndex = 14;
            uiLabel4.Text = "枸杞(255.85g)";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiPanel4
            // 
            uiPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uiPanel4.Controls.Add(uiLabel2);
            uiPanel4.Controls.Add(lblCloseSys);
            uiPanel4.Controls.Add(uiLabel4);
            uiPanel4.Controls.Add(uiLabel3);
            uiPanel4.Controls.Add(uiLabel5);
            uiPanel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel4.Location = new Point(4, 41);
            uiPanel4.Margin = new Padding(4, 5, 4, 5);
            uiPanel4.MinimumSize = new Size(1, 1);
            uiPanel4.Name = "uiPanel4";
            uiPanel4.RectColor = Color.FromArgb(243, 249, 255);
            uiPanel4.Size = new Size(1164, 55);
            uiPanel4.Style = Sunny.UI.UIStyle.Custom;
            uiPanel4.TabIndex = 16;
            uiPanel4.Text = null;
            uiPanel4.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1168, 758);
            ControlBox = false;
            Controls.Add(uiPanel4);
            Controls.Add(navMenuMainLeft);
            Controls.Add(pannelBottom);
            Controls.Add(uiTabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Padding = new Padding(0, 40, 0, 0);
            Text = "四川家施德颗粒调剂系统V2.0";
            TitleHeight = 40;
            WindowState = FormWindowState.Maximized;
            ZoomScaleRect = new Rectangle(19, 19, 800, 450);
            Load += FrmMain_Load;
            uiPanel2.ResumeLayout(false);
            pannelBottom.ResumeLayout(false);
            uiPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.Timer timerRight;
        private Sunny.UI.UIPanel pannelBottom;
        private Sunny.UI.UILabel lblDeviceName;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolLabel lblLoginUser;
        private Sunny.UI.UISymbolLabel lblDeviceConnectText;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UISymbolLabel uiSymbolLabel3;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UISymbolButton lblCloseSys;
        protected internal Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel4;
        protected internal Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIPanel uiPanel3;
        private Sunny.UI.UINavMenu navMenuMainLeft;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIPanel uiPanel4;
    }
}