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
            AdjustmentSys.Models.Machine.ShowsItem showsItem1 = new AdjustmentSys.Models.Machine.ShowsItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBagDevice));
            AdjustmentSys.Models.Machine.Model model1 = new AdjustmentSys.Models.Machine.Model();
            AdjustmentSys.Models.Machine.Station station1 = new AdjustmentSys.Models.Machine.Station();
            AdjustmentSys.Models.Machine.Station station2 = new AdjustmentSys.Models.Machine.Station();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            uC_PreFlowList1 = new UserControlForms.UC_PreFlowList();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            newstate = new Sunny.UI.UILabel();
            textBox1number = new Sunny.UI.UILabel();
            roundMachined2 = new YD.RewritingControl.RoundMachineD();
            dgvPreDetail = new Sunny.UI.UIDataGridView();
            ParticleOrder = new DataGridViewTextBoxColumn();
            ParticlesName = new DataGridViewTextBoxColumn();
            Dose = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            StatusText = new DataGridViewTextBoxColumn();
            StationText = new DataGridViewTextBoxColumn();
            dgvDeviceError = new Sunny.UI.UIDataGridView();
            ErrorMsg = new DataGridViewTextBoxColumn();
            ErrorDecript = new DataGridViewTextBoxColumn();
            Opter = new DataGridViewButtonColumn();
            lbOpterMsg = new Sunny.UI.UIListBox();
            panel2 = new Panel();
            btnAddPre = new Sunny.UI.UISymbolLabel();
            btnClearDevice = new Sunny.UI.UISymbolLabel();
            btnStartRun = new Sunny.UI.UISymbolLabel();
            lblBtnYLTZ = new Sunny.UI.UISymbolLabel();
            btnRefresh = new Sunny.UI.UISymbolLabel();
            lblPrescriptionPaper = new Sunny.UI.UISymbolLabel();
            btnStopRun = new Sunny.UI.UISymbolLabel();
            btnSuspend = new Sunny.UI.UISymbolLabel();
            btnAddParticle = new Sunny.UI.UISymbolLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            contextMenuStrip1fish = new Sunny.UI.UIContextMenuStrip();
            设为调剂完成ToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeviceError).BeginInit();
            panel2.SuspendLayout();
            contextMenuStrip1fish.SuspendLayout();
            SuspendLayout();
            // 
            // uC_PreFlowList1
            // 
            uC_PreFlowList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uC_PreFlowList1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uC_PreFlowList1.Location = new Point(3, 7);
            uC_PreFlowList1.MinimumSize = new Size(1, 1);
            uC_PreFlowList1.Name = "uC_PreFlowList1";
            uC_PreFlowList1.Size = new Size(270, 795);
            uC_PreFlowList1.TabIndex = 0;
            uC_PreFlowList1.Text = "uC_PreFlowList1";
            uC_PreFlowList1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(uC_PreFlowList1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1490, 805);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.67662F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.3233833F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(roundMachined2, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvPreDetail, 1, 0);
            tableLayoutPanel1.Controls.Add(dgvDeviceError, 1, 2);
            tableLayoutPanel1.Controls.Add(lbOpterMsg, 0, 2);
            tableLayoutPanel1.Location = new Point(281, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.41142F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.58857965F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tableLayoutPanel1.Size = new Size(1206, 752);
            tableLayoutPanel1.TabIndex = 33;
            // 
            // panel3
            // 
            panel3.Controls.Add(newstate);
            panel3.Controls.Add(textBox1number);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 641);
            panel3.Name = "panel3";
            panel3.Size = new Size(774, 39);
            panel3.TabIndex = 2;
            // 
            // newstate
            // 
            newstate.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            newstate.ForeColor = Color.FromArgb(48, 48, 48);
            newstate.Location = new Point(5, 4);
            newstate.Name = "newstate";
            newstate.Size = new Size(228, 32);
            newstate.TabIndex = 49;
            newstate.Text = "设备状态：等待回零";
            newstate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1number
            // 
            textBox1number.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1number.ForeColor = Color.FromArgb(48, 48, 48);
            textBox1number.Location = new Point(265, 6);
            textBox1number.Name = "textBox1number";
            textBox1number.Size = new Size(504, 29);
            textBox1number.TabIndex = 48;
            textBox1number.Text = "调剂1000/1-拆分10次-共16/2轮";
            textBox1number.TextAlign = ContentAlignment.MiddleRight;
            // 
            // roundMachined2
            // 
            roundMachined2.AllBarvalue = 0F;
            roundMachined2.BackColor = Color.Transparent;
            roundMachined2.Dock = DockStyle.Fill;
            roundMachined2.Location = new Point(3, 3);
            showsItem1.BGColor = SystemColors.MenuBar;
            showsItem1.MGColor = Color.CadetBlue;
            showsItem1.MText = "名称";
            showsItem1.rectangleF = (RectangleF)resources.GetObject("showsItem1.rectangleF");
            showsItem1.Text = "内容";
            showsItem1.Textcolor = Color.Blue;
            roundMachined2.Makeboxs = showsItem1;
            roundMachined2.ModelColor = Color.CadetBlue;
            model1.BGColor = Color.CadetBlue;
            model1.HaveColor = SystemColors.MenuBar;
            model1.rectangleF = (RectangleF)resources.GetObject("model1.rectangleF");
            model1.Text = null;
            roundMachined2.ModelItems = new AdjustmentSys.Models.Machine.Model[]
    {
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1,
    model1
    };
            roundMachined2.Name = "roundMachined2";
            roundMachined2.Seals = showsItem1;
            roundMachined2.Size = new Size(774, 632);
            station1.BGColor = SystemColors.MenuBar;
            station1.Parvalue = 0F;
            station1.rectangleF = (RectangleF)resources.GetObject("station1.rectangleF");
            station1.Text = null;
            roundMachined2.StationItems = new AdjustmentSys.Models.Machine.Station[]
    {
    station1,
    station1,
    station1,
    station1,
    station1,
    station1,
    station1,
    station1
    };
            roundMachined2.StationnameColor = Color.WhiteSmoke;
            roundMachined2.StationnoColor = Color.CadetBlue;
            roundMachined2.Stationparcolor = Color.CadetBlue;
            roundMachined2.Stationrestparcolor = SystemColors.MenuBar;
            station2.BGColor = SystemColors.MenuBar;
            station2.Parvalue = 0F;
            station2.rectangleF = (RectangleF)resources.GetObject("station2.rectangleF");
            station2.Text = "无";
            roundMachined2.Stationweight = station2;
            roundMachined2.TabIndex = 39;
            roundMachined2.Temshows = showsItem1;
            roundMachined2.Text = "roundMachined2";
            roundMachined2.TextmodelColor = Color.Black;
            roundMachined2.TurntableColor = Color.FromArgb(204, 206, 219);
            roundMachined2.MyDoubleClick += roundMachined2_MyDoubleClick;
            // 
            // dgvPreDetail
            // 
            dgvPreDetail.AllowUserToAddRows = false;
            dgvPreDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 249, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPreDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreDetail.BackgroundColor = Color.FromArgb(243, 249, 255);
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPreDetail.ColumnHeadersHeight = 32;
            dgvPreDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPreDetail.Columns.AddRange(new DataGridViewColumn[] { ParticleOrder, ParticlesName, Dose, Column1, StatusText, StationText });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 236, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPreDetail.Dock = DockStyle.Fill;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(104, 173, 255);
            dgvPreDetail.Location = new Point(783, 3);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(243, 249, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(220, 236, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvPreDetail.SelectedIndex = -1;
            dgvPreDetail.Size = new Size(420, 632);
            dgvPreDetail.TabIndex = 41;
            dgvPreDetail.ZoomScaleDisabled = true;
            dgvPreDetail.CellMouseDown += dgvPreDetail_CellMouseDown;
            // 
            // ParticleOrder
            // 
            ParticleOrder.DataPropertyName = "ParticleOrder";
            ParticleOrder.FillWeight = 60F;
            ParticleOrder.HeaderText = "序号";
            ParticleOrder.Name = "ParticleOrder";
            ParticleOrder.ReadOnly = true;
            ParticleOrder.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ParticlesName
            // 
            ParticlesName.DataPropertyName = "ParticlesName";
            ParticlesName.HeaderText = "名称";
            ParticlesName.Name = "ParticlesName";
            ParticlesName.ReadOnly = true;
            ParticlesName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Dose
            // 
            Dose.DataPropertyName = "Dose";
            Dose.HeaderText = "剂量";
            Dose.Name = "Dose";
            Dose.ReadOnly = true;
            Dose.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            Column1.HeaderText = "进度(%)";
            Column1.Name = "Column1";
            // 
            // StatusText
            // 
            StatusText.DataPropertyName = "StatusText";
            StatusText.HeaderText = "状态";
            StatusText.Name = "StatusText";
            StatusText.ReadOnly = true;
            StatusText.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // StationText
            // 
            StationText.DataPropertyName = "StationText";
            StationText.HeaderText = "坐标";
            StationText.Name = "StationText";
            StationText.ReadOnly = true;
            StationText.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvDeviceError
            // 
            dgvDeviceError.AllowUserToAddRows = false;
            dgvDeviceError.AllowUserToDeleteRows = false;
            dgvDeviceError.AllowUserToResizeColumns = false;
            dgvDeviceError.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvDeviceError.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvDeviceError.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeviceError.BackgroundColor = Color.White;
            dgvDeviceError.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvDeviceError.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvDeviceError.ColumnHeadersHeight = 32;
            dgvDeviceError.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDeviceError.Columns.AddRange(new DataGridViewColumn[] { ErrorMsg, ErrorDecript, Opter });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvDeviceError.DefaultCellStyle = dataGridViewCellStyle9;
            dgvDeviceError.EnableHeadersVisualStyles = false;
            dgvDeviceError.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDeviceError.GridColor = Color.FromArgb(80, 160, 255);
            dgvDeviceError.Location = new Point(783, 686);
            dgvDeviceError.Name = "dgvDeviceError";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvDeviceError.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvDeviceError.RowHeadersVisible = false;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDeviceError.RowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvDeviceError.SelectedIndex = -1;
            dgvDeviceError.Size = new Size(420, 63);
            dgvDeviceError.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvDeviceError.TabIndex = 52;
            // 
            // ErrorMsg
            // 
            ErrorMsg.HeaderText = "异常原因";
            ErrorMsg.Name = "ErrorMsg";
            ErrorMsg.SortMode = DataGridViewColumnSortMode.NotSortable;
            ErrorMsg.Visible = false;
            // 
            // ErrorDecript
            // 
            ErrorDecript.DataPropertyName = "ErrorDecript";
            ErrorDecript.HeaderText = "异常检查";
            ErrorDecript.Name = "ErrorDecript";
            ErrorDecript.ReadOnly = true;
            ErrorDecript.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Opter
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "复位";
            Opter.DefaultCellStyle = dataGridViewCellStyle8;
            Opter.FillWeight = 35F;
            Opter.HeaderText = "操作";
            Opter.Name = "Opter";
            // 
            // lbOpterMsg
            // 
            lbOpterMsg.Dock = DockStyle.Fill;
            lbOpterMsg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbOpterMsg.HoverColor = Color.FromArgb(155, 200, 255);
            lbOpterMsg.ItemSelectForeColor = Color.White;
            lbOpterMsg.Location = new Point(4, 688);
            lbOpterMsg.Margin = new Padding(4, 5, 4, 5);
            lbOpterMsg.MinimumSize = new Size(1, 1);
            lbOpterMsg.Name = "lbOpterMsg";
            lbOpterMsg.Padding = new Padding(2);
            lbOpterMsg.Radius = 1;
            lbOpterMsg.ShowText = false;
            lbOpterMsg.Size = new Size(772, 59);
            lbOpterMsg.TabIndex = 53;
            lbOpterMsg.Text = null;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(btnAddPre);
            panel2.Controls.Add(btnClearDevice);
            panel2.Controls.Add(btnStartRun);
            panel2.Controls.Add(lblBtnYLTZ);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(lblPrescriptionPaper);
            panel2.Controls.Add(btnStopRun);
            panel2.Controls.Add(btnSuspend);
            panel2.Controls.Add(btnAddParticle);
            panel2.Location = new Point(280, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(1207, 40);
            panel2.TabIndex = 32;
            // 
            // btnAddPre
            // 
            btnAddPre.Font = new Font("微软雅黑", 10.5F);
            btnAddPre.Location = new Point(1039, 5);
            btnAddPre.Margin = new Padding(5, 3, 3, 3);
            btnAddPre.MinimumSize = new Size(1, 1);
            btnAddPre.Name = "btnAddPre";
            btnAddPre.Size = new Size(110, 32);
            btnAddPre.Symbol = 557672;
            btnAddPre.SymbolColor = Color.MediumSlateBlue;
            btnAddPre.TabIndex = 17;
            btnAddPre.Text = "新建处方";
            btnAddPre.Click += btnAddPre_Click;
            // 
            // btnClearDevice
            // 
            btnClearDevice.Font = new Font("微软雅黑", 10.5F);
            btnClearDevice.Location = new Point(528, 5);
            btnClearDevice.Margin = new Padding(5, 3, 3, 3);
            btnClearDevice.MinimumSize = new Size(1, 1);
            btnClearDevice.Name = "btnClearDevice";
            btnClearDevice.Size = new Size(141, 32);
            btnClearDevice.Symbol = 557671;
            btnClearDevice.SymbolColor = Color.MediumSlateBlue;
            btnClearDevice.TabIndex = 16;
            btnClearDevice.Text = "清除设备状态";
            btnClearDevice.Click += btnClearDevice_Click;
            // 
            // btnStartRun
            // 
            btnStartRun.Font = new Font("微软雅黑", 10.5F);
            btnStartRun.Location = new Point(5, 5);
            btnStartRun.Margin = new Padding(5, 3, 3, 3);
            btnStartRun.MinimumSize = new Size(1, 1);
            btnStartRun.Name = "btnStartRun";
            btnStartRun.Size = new Size(123, 32);
            btnStartRun.Symbol = 361764;
            btnStartRun.SymbolColor = Color.MediumSlateBlue;
            btnStartRun.TabIndex = 0;
            btnStartRun.Text = "开始调剂(F9)";
            btnStartRun.Click += btnStartRun_Click;
            // 
            // lblBtnYLTZ
            // 
            lblBtnYLTZ.Font = new Font("微软雅黑", 10.5F);
            lblBtnYLTZ.Location = new Point(792, 5);
            lblBtnYLTZ.Margin = new Padding(5, 3, 3, 3);
            lblBtnYLTZ.MinimumSize = new Size(1, 1);
            lblBtnYLTZ.Name = "lblBtnYLTZ";
            lblBtnYLTZ.Size = new Size(119, 32);
            lblBtnYLTZ.Symbol = 557671;
            lblBtnYLTZ.SymbolColor = Color.MediumSlateBlue;
            lblBtnYLTZ.TabIndex = 15;
            lblBtnYLTZ.Text = "余量调整(F12)";
            lblBtnYLTZ.Click += lblBtnYLTZ_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("微软雅黑", 10.5F);
            btnRefresh.Location = new Point(271, 5);
            btnRefresh.Margin = new Padding(5, 3, 3, 3);
            btnRefresh.MinimumSize = new Size(1, 1);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 32);
            btnRefresh.Symbol = 61473;
            btnRefresh.SymbolColor = Color.MediumSlateBlue;
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "设备初始化";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblPrescriptionPaper
            // 
            lblPrescriptionPaper.Font = new Font("微软雅黑", 10.5F);
            lblPrescriptionPaper.Location = new Point(921, 5);
            lblPrescriptionPaper.Margin = new Padding(5, 3, 3, 3);
            lblPrescriptionPaper.MinimumSize = new Size(1, 1);
            lblPrescriptionPaper.Name = "lblPrescriptionPaper";
            lblPrescriptionPaper.Size = new Size(110, 32);
            lblPrescriptionPaper.Symbol = 361508;
            lblPrescriptionPaper.SymbolColor = Color.MediumSlateBlue;
            lblPrescriptionPaper.TabIndex = 14;
            lblPrescriptionPaper.Text = "处方笺";
            // 
            // btnStopRun
            // 
            btnStopRun.Font = new Font("微软雅黑", 10.5F);
            btnStopRun.Location = new Point(398, 5);
            btnStopRun.Margin = new Padding(5, 3, 3, 3);
            btnStopRun.MinimumSize = new Size(1, 1);
            btnStopRun.Name = "btnStopRun";
            btnStopRun.Size = new Size(122, 32);
            btnStopRun.Symbol = 361534;
            btnStopRun.SymbolColor = Color.MediumSlateBlue;
            btnStopRun.TabIndex = 3;
            btnStopRun.Text = "终止调剂";
            btnStopRun.Click += btnStopRun_Click;
            // 
            // btnSuspend
            // 
            btnSuspend.Font = new Font("微软雅黑", 10.5F);
            btnSuspend.Location = new Point(136, 5);
            btnSuspend.Margin = new Padding(5, 3, 3, 3);
            btnSuspend.MinimumSize = new Size(1, 1);
            btnSuspend.Name = "btnSuspend";
            btnSuspend.Size = new Size(127, 32);
            btnSuspend.Symbol = 93;
            btnSuspend.SymbolColor = Color.MediumSlateBlue;
            btnSuspend.TabIndex = 1;
            btnSuspend.Text = "暂停/继续(F10)";
            btnSuspend.Click += btnSuspend_Click;
            // 
            // btnAddParticle
            // 
            btnAddParticle.Font = new Font("微软雅黑", 10.5F);
            btnAddParticle.Location = new Point(667, 5);
            btnAddParticle.Margin = new Padding(5, 3, 3, 3);
            btnAddParticle.MinimumSize = new Size(1, 1);
            btnAddParticle.Name = "btnAddParticle";
            btnAddParticle.Size = new Size(110, 32);
            btnAddParticle.Symbol = 557671;
            btnAddParticle.SymbolColor = Color.MediumSlateBlue;
            btnAddParticle.TabIndex = 4;
            btnAddParticle.Text = "上药(F11)";
            btnAddParticle.Click += btnAddParticle_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            // 
            // contextMenuStrip1fish
            // 
            contextMenuStrip1fish.BackColor = Color.FromArgb(243, 249, 255);
            contextMenuStrip1fish.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            contextMenuStrip1fish.Items.AddRange(new ToolStripItem[] { 设为调剂完成ToolStripMenuItem });
            contextMenuStrip1fish.Name = "contextMenuStrip1fish";
            contextMenuStrip1fish.Size = new Size(171, 26);
            // 
            // 设为调剂完成ToolStripMenuItem
            // 
            设为调剂完成ToolStripMenuItem.Name = "设为调剂完成ToolStripMenuItem";
            设为调剂完成ToolStripMenuItem.Size = new Size(170, 22);
            设为调剂完成ToolStripMenuItem.Text = "设为调剂完成";
            // 
            // FrmBagDevice
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1490, 840);
            Controls.Add(panel1);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "FrmBagDevice";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 361641;
            Text = "调剂管理>>处方调剂";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmBagDevice_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeviceError).EndInit();
            panel2.ResumeLayout(false);
            contextMenuStrip1fish.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private UserControlForms.UC_PreFlowList uC_PreFlowList1;
        private YD.RewritingControl.RoundMachineD roundMachined1;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UILabel lblCHYC;
        private Sunny.UI.UILabel lblCHZT;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UILabel lblFKYC;
        private Sunny.UI.UILabel lblFKZT;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UILabel lblGHYC;
        private Sunny.UI.UILabel lblGHZT;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIPanel uiPanel1;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton1;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton5;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton6;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton7;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton8;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton4;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton3;
        private UserControlForms.UC_WorkStationButton uC_WorkStationButton2;
        private Sunny.UI.UIUserControl uiUserControl8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel stationWeightNumber;
        private Sunny.UI.UILabel stationWeightPaticleName;
        private Sunny.UI.UILabel stationWeightStatus;
        private Sunny.UI.UILabel uiLabel46;
        private Sunny.UI.UILabel lblPreBoxNum;
        private Sunny.UI.UILabel uiLabel43;
        private Sunny.UI.UILabel lblPreQuantity;
        private Sunny.UI.UILabel uiLabel41;
        private Sunny.UI.UILabel lblPreParticleNum;
        private Sunny.UI.UILabel uiLabel39;
        private Sunny.UI.UILabel lblPreId;
        private Sunny.UI.UILabel uiLabel37;
        private Sunny.UI.UIRoundProcess preRoundProcess;
        private Panel panel1;
        private Panel panel2;
        private Sunny.UI.UISymbolLabel lblPrescriptionPaper;
        private Sunny.UI.UISymbolLabel btnAddParticle;
        private Sunny.UI.UISymbolLabel btnStopRun;
        private Sunny.UI.UISymbolLabel btnRefresh;
        private Sunny.UI.UISymbolLabel btnSuspend;
        private Sunny.UI.UISymbolLabel btnStartRun;
        private TableLayoutPanel tableLayoutPanel1;
        private YD.RewritingControl.RoundMachineD roundMachined2;
        private Sunny.UI.UIDataGridView dgvPreDetail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Sunny.UI.UISymbolLabel btnClearDevice;
        private Sunny.UI.UISymbolLabel lblBtnYLTZ;
        private Sunny.UI.UILabel textBox1number;
        private Sunny.UI.UIDataGridView dgvDeviceError;
        private Sunny.UI.UIListBox lbOpterMsg;
        private Panel panel3;
        private Sunny.UI.UILabel newstate;
        private DataGridViewTextBoxColumn ParticleOrder;
        private DataGridViewTextBoxColumn ParticlesName;
        private DataGridViewTextBoxColumn Dose;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn StatusText;
        private DataGridViewTextBoxColumn StationText;
        private DataGridViewTextBoxColumn ErrorMsg;
        private DataGridViewTextBoxColumn ErrorDecript;
        private DataGridViewButtonColumn Opter;
        private Sunny.UI.UIContextMenuStrip contextMenuStrip1fish;
        private ToolStripMenuItem 设为调剂完成ToolStripMenuItem;
        private Sunny.UI.UISymbolLabel btnAddPre;
    }
}