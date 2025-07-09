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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            menuTreeView = new Sunny.UI.UITreeView();
            uiLabel7 = new Sunny.UI.UILabel();
            dgvList = new Sunny.UI.UIDataGridView();
            uiLabel1 = new Sunny.UI.UILabel();
            lblJSName = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // menuTreeView
            // 
            menuTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            menuTreeView.CheckBoxes = true;
            menuTreeView.FillColor = Color.White;
            menuTreeView.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            menuTreeView.Location = new Point(468, 84);
            menuTreeView.Margin = new Padding(4, 5, 4, 5);
            menuTreeView.MinimumSize = new Size(1, 1);
            menuTreeView.Name = "menuTreeView";
            menuTreeView.ScrollBarStyleInherited = false;
            menuTreeView.ShowText = false;
            menuTreeView.Size = new Size(591, 661);
            menuTreeView.TabIndex = 0;
            menuTreeView.Text = "uiTreeView1";
            menuTreeView.TextAlignment = ContentAlignment.MiddleCenter;
            menuTreeView.AfterCheck += menuTreeView_AfterCheck;
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel7.ForeColor = Color.Black;
            uiLabel7.Location = new Point(14, 50);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(123, 23);
            uiLabel7.TabIndex = 17;
            uiLabel7.Text = "系统角色：";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 32;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.GridColor = Color.FromArgb(80, 160, 255);
            dgvList.Location = new Point(10, 84);
            dgvList.Name = "dgvList";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvList.RowHeadersVisible = false;
            dgvList.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvList.RowTemplate.Height = 27;
            dgvList.SelectedIndex = -1;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(436, 221);
            dgvList.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvList.TabIndex = 36;
            dgvList.CellClick += dgvList_CellClick;
            // 
            // uiLabel1
            // 
            uiLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uiLabel1.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.Black;
            uiLabel1.Location = new Point(471, 50);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(81, 23);
            uiLabel1.TabIndex = 37;
            uiLabel1.Text = "角色权限：";
            uiLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblJSName
            // 
            lblJSName.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblJSName.ForeColor = Color.Blue;
            lblJSName.Location = new Point(161, 50);
            lblJSName.Name = "lblJSName";
            lblJSName.Size = new Size(137, 23);
            lblJSName.TabIndex = 38;
            lblJSName.Text = "无";
            lblJSName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmMenu
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1131, 755);
            Controls.Add(lblJSName);
            Controls.Add(uiLabel1);
            Controls.Add(dgvList);
            Controls.Add(uiLabel7);
            Controls.Add(menuTreeView);
            Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "FrmMenu";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Text = "系统设置>>角色权限设置";
            TitleFont = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Load += FrmMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITreeView menuTreeView;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIDataGridView dgvList;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel lblJSName;
    }
}