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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            AdjustmentSys.Models.Machine.ShowsItem showsItem1 = new AdjustmentSys.Models.Machine.ShowsItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBagDevice));
            AdjustmentSys.Models.Machine.Model model1 = new AdjustmentSys.Models.Machine.Model();
            AdjustmentSys.Models.Machine.Station station1 = new AdjustmentSys.Models.Machine.Station();
            AdjustmentSys.Models.Machine.Station station2 = new AdjustmentSys.Models.Machine.Station();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            uC_PreFlowList1 = new UserControlForms.UC_PreFlowList();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvDeviceError = new Sunny.UI.UIDataGridView();
            ErrorType = new DataGridViewTextBoxColumn();
            ErrorDecript = new DataGridViewTextBoxColumn();
            Opter = new DataGridViewButtonColumn();
            roundMachined2 = new YD.RewritingControl.RoundMachineD();
            lbOpterMsg = new Sunny.UI.UIListBox();
            dgvPreDetail = new Sunny.UI.UIDataGridView();
            ParticleOrder = new DataGridViewTextBoxColumn();
            ParticlesName = new DataGridViewTextBoxColumn();
            Dose = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            StatusText = new DataGridViewTextBoxColumn();
            StationText = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            lblPrescriptionPaper = new Sunny.UI.UISymbolLabel();
            lblRunStatus = new Sunny.UI.UILabel();
            btnAddParticle = new Sunny.UI.UISymbolLabel();
            btnStopRun = new Sunny.UI.UISymbolLabel();
            btnRefresh = new Sunny.UI.UISymbolLabel();
            btnSuspend = new Sunny.UI.UISymbolLabel();
            btnStartRun = new Sunny.UI.UISymbolLabel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeviceError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).BeginInit();
            panel2.SuspendLayout();
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
            tableLayoutPanel1.Controls.Add(dgvDeviceError, 1, 1);
            tableLayoutPanel1.Controls.Add(roundMachined2, 0, 0);
            tableLayoutPanel1.Controls.Add(lbOpterMsg, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvPreDetail, 1, 0);
            tableLayoutPanel1.Location = new Point(281, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 84.30851F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15.6914892F));
            tableLayoutPanel1.Size = new Size(1206, 752);
            tableLayoutPanel1.TabIndex = 33;
            // 
            // dgvDeviceError
            // 
            dgvDeviceError.AllowUserToAddRows = false;
            dgvDeviceError.AllowUserToDeleteRows = false;
            dgvDeviceError.AllowUserToResizeColumns = false;
            dgvDeviceError.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvDeviceError.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDeviceError.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeviceError.BackgroundColor = Color.White;
            dgvDeviceError.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDeviceError.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDeviceError.ColumnHeadersHeight = 32;
            dgvDeviceError.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDeviceError.Columns.AddRange(new DataGridViewColumn[] { ErrorType, ErrorDecript, Opter });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvDeviceError.DefaultCellStyle = dataGridViewCellStyle4;
            dgvDeviceError.Dock = DockStyle.Fill;
            dgvDeviceError.EnableHeadersVisualStyles = false;
            dgvDeviceError.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDeviceError.GridColor = Color.FromArgb(80, 160, 255);
            dgvDeviceError.Location = new Point(783, 637);
            dgvDeviceError.Name = "dgvDeviceError";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvDeviceError.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvDeviceError.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvDeviceError.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvDeviceError.SelectedIndex = -1;
            dgvDeviceError.Size = new Size(420, 112);
            dgvDeviceError.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvDeviceError.TabIndex = 42;
            // 
            // ErrorType
            // 
            ErrorType.DataPropertyName = "ErrorType";
            ErrorType.HeaderText = "异常类型";
            ErrorType.Name = "ErrorType";
            ErrorType.SortMode = DataGridViewColumnSortMode.NotSortable;
            ErrorType.Visible = false;
            // 
            // ErrorDecript
            // 
            ErrorDecript.DataPropertyName = "ErrorDecript";
            ErrorDecript.HeaderText = "异常信息";
            ErrorDecript.Name = "ErrorDecript";
            ErrorDecript.ReadOnly = true;
            ErrorDecript.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Opter
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "复位";
            Opter.DefaultCellStyle = dataGridViewCellStyle3;
            Opter.FillWeight = 35F;
            Opter.HeaderText = "操作";
            Opter.Name = "Opter";
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
            roundMachined2.Size = new Size(774, 628);
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
            // 
            // lbOpterMsg
            // 
            lbOpterMsg.Dock = DockStyle.Fill;
            lbOpterMsg.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbOpterMsg.HoverColor = Color.FromArgb(155, 200, 255);
            lbOpterMsg.ItemSelectForeColor = Color.White;
            lbOpterMsg.Location = new Point(4, 639);
            lbOpterMsg.Margin = new Padding(4, 5, 4, 5);
            lbOpterMsg.MinimumSize = new Size(1, 1);
            lbOpterMsg.Name = "lbOpterMsg";
            lbOpterMsg.Padding = new Padding(2);
            lbOpterMsg.Radius = 1;
            lbOpterMsg.ShowText = false;
            lbOpterMsg.Size = new Size(772, 108);
            lbOpterMsg.TabIndex = 40;
            lbOpterMsg.Text = null;
            // 
            // dgvPreDetail
            // 
            dgvPreDetail.AllowUserToAddRows = false;
            dgvPreDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(243, 249, 255);
            dgvPreDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvPreDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPreDetail.BackgroundColor = Color.FromArgb(243, 249, 255);
            dgvPreDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle8.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvPreDetail.ColumnHeadersHeight = 32;
            dgvPreDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPreDetail.Columns.AddRange(new DataGridViewColumn[] { ParticleOrder, ParticlesName, Dose, Column1, StatusText, StationText });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(220, 236, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvPreDetail.DefaultCellStyle = dataGridViewCellStyle9;
            dgvPreDetail.Dock = DockStyle.Fill;
            dgvPreDetail.EnableHeadersVisualStyles = false;
            dgvPreDetail.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvPreDetail.GridColor = Color.FromArgb(104, 173, 255);
            dgvPreDetail.Location = new Point(783, 3);
            dgvPreDetail.Name = "dgvPreDetail";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(243, 249, 255);
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvPreDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvPreDetail.RowHeadersVisible = false;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(220, 236, 255);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dgvPreDetail.RowsDefaultCellStyle = dataGridViewCellStyle11;
            dgvPreDetail.SelectedIndex = -1;
            dgvPreDetail.Size = new Size(420, 628);
            dgvPreDetail.TabIndex = 41;
            dgvPreDetail.ZoomScaleDisabled = true;
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
            ParticlesName.HeaderText = "颗粒名称";
            ParticlesName.Name = "ParticlesName";
            ParticlesName.ReadOnly = true;
            ParticlesName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Dose
            // 
            Dose.DataPropertyName = "Dose";
            Dose.HeaderText = "颗粒剂量";
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
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(lblPrescriptionPaper);
            panel2.Controls.Add(lblRunStatus);
            panel2.Controls.Add(btnAddParticle);
            panel2.Controls.Add(btnStopRun);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(btnSuspend);
            panel2.Controls.Add(btnStartRun);
            panel2.Location = new Point(280, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(1207, 40);
            panel2.TabIndex = 32;
            // 
            // lblPrescriptionPaper
            // 
            lblPrescriptionPaper.Font = new Font("微软雅黑", 10.5F);
            lblPrescriptionPaper.Location = new Point(687, 3);
            lblPrescriptionPaper.Margin = new Padding(5, 3, 3, 3);
            lblPrescriptionPaper.MinimumSize = new Size(1, 1);
            lblPrescriptionPaper.Name = "lblPrescriptionPaper";
            lblPrescriptionPaper.Size = new Size(110, 32);
            lblPrescriptionPaper.Symbol = 361508;
            lblPrescriptionPaper.SymbolColor = Color.MediumSlateBlue;
            lblPrescriptionPaper.TabIndex = 14;
            lblPrescriptionPaper.Text = "处方笺";
            // 
            // lblRunStatus
            // 
            lblRunStatus.Anchor = AnchorStyles.Right;
            lblRunStatus.Font = new Font("微软雅黑", 10.5F);
            lblRunStatus.ForeColor = Color.FromArgb(128, 128, 255);
            lblRunStatus.Location = new Point(2871, -49);
            lblRunStatus.Name = "lblRunStatus";
            lblRunStatus.Size = new Size(323, 20);
            lblRunStatus.TabIndex = 13;
            lblRunStatus.Text = "运行状态:等待初始化";
            lblRunStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAddParticle
            // 
            btnAddParticle.Font = new Font("微软雅黑", 10.5F);
            btnAddParticle.Location = new Point(550, 4);
            btnAddParticle.Margin = new Padding(5, 3, 3, 3);
            btnAddParticle.MinimumSize = new Size(1, 1);
            btnAddParticle.Name = "btnAddParticle";
            btnAddParticle.Size = new Size(110, 32);
            btnAddParticle.Symbol = 557671;
            btnAddParticle.SymbolColor = Color.MediumSlateBlue;
            btnAddParticle.TabIndex = 4;
            btnAddParticle.Text = "上药";
            // 
            // btnStopRun
            // 
            btnStopRun.Font = new Font("微软雅黑", 10.5F);
            btnStopRun.Location = new Point(413, 4);
            btnStopRun.Margin = new Padding(5, 3, 3, 3);
            btnStopRun.MinimumSize = new Size(1, 1);
            btnStopRun.Name = "btnStopRun";
            btnStopRun.Size = new Size(110, 32);
            btnStopRun.Symbol = 361534;
            btnStopRun.SymbolColor = Color.MediumSlateBlue;
            btnStopRun.TabIndex = 3;
            btnStopRun.Text = "终止调剂";
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("微软雅黑", 10.5F);
            btnRefresh.Location = new Point(274, 4);
            btnRefresh.Margin = new Padding(5, 3, 3, 3);
            btnRefresh.MinimumSize = new Size(1, 1);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 32);
            btnRefresh.Symbol = 61473;
            btnRefresh.SymbolColor = Color.MediumSlateBlue;
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "设备初始化";
            // 
            // btnSuspend
            // 
            btnSuspend.Font = new Font("微软雅黑", 10.5F);
            btnSuspend.Location = new Point(139, 4);
            btnSuspend.Margin = new Padding(5, 3, 3, 3);
            btnSuspend.MinimumSize = new Size(1, 1);
            btnSuspend.Name = "btnSuspend";
            btnSuspend.Size = new Size(110, 32);
            btnSuspend.Symbol = 93;
            btnSuspend.SymbolColor = Color.MediumSlateBlue;
            btnSuspend.TabIndex = 1;
            btnSuspend.Text = "暂停/继续";
            // 
            // btnStartRun
            // 
            btnStartRun.Font = new Font("微软雅黑", 10.5F);
            btnStartRun.Location = new Point(8, 4);
            btnStartRun.Margin = new Padding(5, 3, 3, 3);
            btnStartRun.MinimumSize = new Size(1, 1);
            btnStartRun.Name = "btnStartRun";
            btnStartRun.Size = new Size(110, 32);
            btnStartRun.Symbol = 361764;
            btnStartRun.SymbolColor = Color.MediumSlateBlue;
            btnStartRun.TabIndex = 0;
            btnStartRun.Text = "开始调剂";
            // 
            // FrmBagDevice
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1490, 840);
            Controls.Add(panel1);
            Name = "FrmBagDevice";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 361641;
            Text = "调剂管理>>处方调剂";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += FrmBagDevice_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDeviceError).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPreDetail).EndInit();
            panel2.ResumeLayout(false);
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
        private Sunny.UI.UILabel uiLabel1;
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
        private Sunny.UI.UILabel lblRunStatus;
        private Sunny.UI.UISymbolLabel btnAddParticle;
        private Sunny.UI.UISymbolLabel btnStopRun;
        private Sunny.UI.UISymbolLabel btnRefresh;
        private Sunny.UI.UISymbolLabel btnSuspend;
        private Sunny.UI.UISymbolLabel btnStartRun;
        private TableLayoutPanel tableLayoutPanel1;
        private YD.RewritingControl.RoundMachineD roundMachined2;
        private Sunny.UI.UIListBox lbOpterMsg;
        private Sunny.UI.UIDataGridView dgvPreDetail;
        private DataGridViewTextBoxColumn ParticleOrder;
        private DataGridViewTextBoxColumn ParticlesName;
        private DataGridViewTextBoxColumn Dose;
        private DataGridViewTextBoxColumn StatusText;
        private DataGridViewTextBoxColumn StationText;
        private Sunny.UI.UIDataGridView dgvDeviceError;
        private DataGridViewTextBoxColumn ErrorType;
        private DataGridViewTextBoxColumn ErrorDecript;
        private DataGridViewButtonColumn Opter;
        private DataGridViewTextBoxColumn Column1;
    }
}