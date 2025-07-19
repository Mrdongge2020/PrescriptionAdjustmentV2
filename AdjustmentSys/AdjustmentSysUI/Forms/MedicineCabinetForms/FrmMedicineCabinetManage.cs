using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.DAL.Common;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSysUI.UITool;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.VisualBasic.Devices;
using NPOI.XSSF.Model;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdjustmentSysUI.Forms.MedicineCabinetForms
{
    public partial class FrmMedicineCabinetManage : UIPage
    {
        MedicineCabinetDrugManageBLL _medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
        ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        private string code = "20000";
        List<MedicineCabinetDetailListModel> cabinetDrugList = new List<MedicineCabinetDetailListModel>();
        List<MedicineCabinetInfo> cabinetsList = new List<MedicineCabinetInfo>();
        MedicineCabinetDetailListModel selectDurgModel = new MedicineCabinetDetailListModel();
        int Rowindex = 0;
        int Colindex = 0;
        public FrmMedicineCabinetManage()
        {

            InitializeComponent();
            InitData();
            ControlOpterUI.SetTitleStyle(this);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            List<ComboxModel> pDatas = _comboxDataBLL.GetParticlesInfoComboxData();
            cbDurg.ValueMember = "Id";
            cbDurg.DisplayMember = "Name";
            cbDurg.DataSource = pDatas;
            cbDurg.SelectedIndex = -1;

            CreateCabinetDGV();
        }

        /// <summary>
        /// 创建药柜
        /// </summary>
        private void CreateCabinetDGV()
        {
            cabinetDrugList = GetCabinetDetails(code);
            cabinetsList = GetCabinets(code);
            if (cabinetDrugList.Count == 0 || cabinetsList.Count == 0)
            {
                return;
            }
            //添加所有列
            foreach (var item in cabinetsList)
            {
                //获取有多少列
                int colcount = item.ColCount + 1;
                for (int i = 0; i < colcount; i++)
                {
                    if (i == 0) //序号列
                    {
                        AddSortColumn(item.ID);
                        continue;
                    }
                    DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                    //设置对齐方式
                    dataGridViewTextBoxColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //设置列名
                    dataGridViewTextBoxColumn.Name = item.ID + "" + i;
                    //设置标题
                    dataGridViewTextBoxColumn.HeaderText = "1:" + i;

                    //设置是否只读
                    dataGridViewTextBoxColumn.ReadOnly = true;
                    //设置是否可见
                    dataGridViewTextBoxColumn.Visible = true;
                    //设置不可排序
                    dataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    //设置绑定的字段
                    dataGridViewTextBoxColumn.DataPropertyName = item.ID + "" + i;
                    //设置列宽
                    dataGridViewTextBoxColumn.Width = 80;
                    //将创建的列添加到DataGridView中
                    dgvList.Columns.Add(dataGridViewTextBoxColumn);
                }
            }

            dgvList.RowTemplate.Height = 70;

            //添加所有行
            for (int i = 0; i < cabinetsList.Max(x => x.RowCount); i++)
            {
                //DataGridViewRow row = new DataGridViewRow();
                //row.DefaultCellStyle.BackColor = Color.White;
                //dgvList.Rows.Add(row);
                dgvList.Rows.Add();//添加行
            }

            #region 插入药品数据
            int sortIndex = 0;
            int cabinetId = 0;
            foreach (var item in cabinetDrugList)
            {
                int rowIndex = item.CoordinateX - 1;
                if (item.MedicineCabinetId > cabinetId)
                {
                    sortIndex++;
                    for (int i = 0; i < cabinetsList.Max(x => x.RowCount); i++)
                    {
                        this.dgvList.Rows[i].Cells[sortIndex == 1 ? item.CoordinateY - 1 : item.CoordinateY].Value = i + 1;//序号填充
                    }
                    cabinetId = item.MedicineCabinetId;
                }
                int columnIndex = item.CoordinateY + (sortIndex - 1);
                string valueText = "";
                if (item.ParticlesID > 0)
                {
                    valueText = item.ParticlesName + "\r\n" + (item.Stock ?? 0) + "克";
                    this.dgvList.Rows[rowIndex].Cells[columnIndex].Value = valueText;
                    this.dgvList.Rows[rowIndex].Cells[columnIndex].Style = CellStyleSet(item.Stock);
                }
            }
            #endregion

        }

        /// <summary>
        /// 设置单元格格式
        /// </summary>
        /// <param name="nameLength">药品名称长度</param>
        /// <param name="stock">药品库存</param>
        /// <returns></returns>
        private DataGridViewCellStyle CellStyleSet(float? stock)
        {
            // 创建一个Font对象，设置字体大小
            Font newFont = new Font("微软雅黑", 12);
            // 更新单元格样式中的字体
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = newFont;
            style.BackColor = BackColor(stock ?? 0);
            return style;
        }
        /// <summary>
        /// 药柜单元格背景颜色设置
        /// </summary>
        /// <param name="stock">库存</param>
        /// <returns></returns>
        private Color BackColor(float stock)
        {

            if (stock >= 100)
            {
                return Color.DarkSeaGreen;
            }
            if (stock > 50 && stock < 100)
            {
                //return Color.Blue;
                return Color.Wheat;
            }
            if (stock > 50 && stock <= 50)
            {
                return Color.Pink;
            }
            else
            {
                return Color.DimGray;
            }
        }

        /// <summary>
        /// 添加序号列
        /// </summary>
        /// <param name="meId">药柜id</param>
        private void AddSortColumn(int meId)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            //设置对齐方式
            dataGridViewTextBoxColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //设置列名
            dataGridViewTextBoxColumn.Name = "Sort" + meId; ;
            //设置标题
            dataGridViewTextBoxColumn.HeaderText = "序号";
            //设置是否只读
            dataGridViewTextBoxColumn.ReadOnly = true;
            //设置是否可见
            dataGridViewTextBoxColumn.Visible = true;
            //设置绑定的字段
            dataGridViewTextBoxColumn.DataPropertyName = "Sort" + meId;
            //设置列宽
            dataGridViewTextBoxColumn.Width = 55;

            //将创建的列添加到DataGridView中
            dgvList.Columns.Add(dataGridViewTextBoxColumn);

        }
        /// <summary>
        /// 根据分组编号获取药柜药品数据
        /// </summary>
        /// <param name="code">分组code</param>
        /// <returns></returns>
        private List<MedicineCabinetDetailListModel> GetCabinetDetails(string code)
        {
            return _medicineCabinetDrugManageBLL.GetCabinetDrugDetails(code);
        }

        /// <summary>
        /// 根据分组编号获取药柜信息
        /// </summary>
        /// <param name="code">分组code</param>
        /// <returns></returns>
        public List<MedicineCabinetInfo> GetCabinets(string code)
        {
            return _medicineCabinetDrugManageBLL.GetCabinets(code);
        }

        private void dgvList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                Rowindex = e.RowIndex;
                Colindex = e.ColumnIndex;
                CalculateXY(e.RowIndex, e.ColumnIndex);
            }
        }

        public void CalculateXY(int rowIndex, int columnIndex)
        {
            rowIndex = rowIndex + 1;
            int allColumnIndex = 0;
            for (int i = 0; i < cabinetsList.Count; i++)
            {
                allColumnIndex = allColumnIndex + cabinetsList[i].ColCount;
                if (columnIndex < allColumnIndex)
                {
                    columnIndex = columnIndex - i;
                    break;
                }
            }

            selectDurgModel = cabinetDrugList.FirstOrDefault(x => x.CoordinateX == rowIndex && x.CoordinateY == columnIndex);
            cbDurg.Text = selectDurgModel.ParticlesName;
        }

        /// <summary>
        /// 上架颗粒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListingParticles_Click(object sender, EventArgs e)
        {
            if (selectDurgModel == null)
            {
                this.ShowWarningDialog("请选择药柜信息");
                return;
            }
            Point startPoint = new Point(MousePosition.X - 70, MousePosition.Y - 20);
            FrmListingParticles frmListingParticles = new FrmListingParticles();
            frmListingParticles.StartPosition = FormStartPosition.Manual;
            frmListingParticles.Location = startPoint;
            DialogResult Result = frmListingParticles.ShowDialog();
            if (Result == DialogResult.OK)
            {
                string msg = _medicineCabinetDrugManageBLL.ListingParticle(selectDurgModel.ID, code, frmListingParticles._Id);
                if (msg == "")
                {
                    this.ShowSuccessTip("上架颗粒成功");
                    int index = frmListingParticles._Name.IndexOf('(');
                    string valueText = frmListingParticles._Name.Substring(0, index) + "\r\n" + "0克";
                    dgvList.Rows[Rowindex].Cells[Colindex].Style = CellStyleSet(0);
                    dgvList.Rows[Rowindex].Cells[Colindex].Value = valueText;
                }
                else
                {
                    this.ShowErrorDialog("错误提示", msg);
                }
            }
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            Refc();
        }
        /// <summary>
        /// 刷新药柜数据
        /// </summary>
        private void Refc()
        {
            dgvList.Columns.Clear();
            dgvList.Rows.Clear();
            InitData();
        }

        private void FrmMedicineCabinetManage_Load(object sender, EventArgs e)
        {

        }

        private void RemoveParticles_Click(object sender, EventArgs e)
        {
            if (selectDurgModel == null)
            {
                this.ShowWarningDialog("请选择药柜信息");
                return;
            }
            string msg = _medicineCabinetDrugManageBLL.RemoveParticle(selectDurgModel.ID);
            if (msg == "")
            {
                this.ShowSuccessTip("下架颗粒成功");

                dgvList.Rows[Rowindex].Cells[Colindex].Style = CellStyleSet(0);
                dgvList.Rows[Rowindex].Cells[Colindex].Value = "";
            }
            else
            {
                this.ShowErrorDialog("错误提示", msg);
            }
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 检查是否为某些特定单元格，比如标题单元格
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                // 使用自定义背景色绘制单元格
                using (Brush gridBrush = new SolidBrush(Color.LightBlue))
                {
                    e.Graphics.FillRectangle(gridBrush, e.CellBounds);
                }

                // 使用自定义字体绘制文本
                using (Brush textBrush = new SolidBrush(Color.MidnightBlue))
                {
                    StringFormat format = new StringFormat()
                    {
                        // 水平或垂直方向文本对齐
                        Alignment = StringAlignment.Center,
                        // 对齐行内的文本
                        LineAlignment = StringAlignment.Center
                    };

                    //e.Graphics.DrawArrow(e.CellStyle.BackColor, e., textBrush, e.CellBounds, format);
                }

                // 阻止默认绘制
                e.Handled = true;
            }
        }

        private void RedRfid_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectDurgModel == null)
                {
                    this.ShowWarningDialog("写入失败!请选择药柜颗粒信息");
                    return;
                }
                if (!MachinePublic.ConnectionState)
                {
                    this.ShowWarningDialog("写入失败!未连接到设备,无法使用RFID写入功能");
                    return;
                }
                CommonStaticDataBLL commonStaticDataBLL = new CommonStaticDataBLL();
                var emptyBottleWeightStr = CommonStaticDataBLL.GetSystemParameterValue("KongPingZhongLiang");
                double emptyBottleWeight = 200;
                if (double.TryParse(emptyBottleWeightStr, out double w))
                {
                    emptyBottleWeight = w;
                }
                if (Math.Abs(MachinePublic.Weight - emptyBottleWeight) > 5)  //|当前重量-空瓶重量|<5
                {
                    this.ShowWarningDialog("写入失败!空瓶重量异常， 请确认药瓶是否为空瓶");
                    return;
                }

                if (MachinePublic.Weight <= 200 || !MachinePublic.WeightState)
                {
                    this.ShowWarningDialog("写入失败!请等待数称重据稳定后再写入");
                    return;
                }
                MedicineCabinetDrugManageBLL medicineCabinetDrugManageBLL = new MedicineCabinetDrugManageBLL();
                var mcd = medicineCabinetDrugManageBLL.GetMedicineCabinetDetail(selectDurgModel.ID);
                if (mcd == null)
                {
                    this.ShowWarningDialog("写入失败!未找到药柜颗粒信息");
                    return;
                }

                mcd.EmptyBottleWeight = (float)MachinePublic.Weight;
                //拼写rfid数据
                mcd.RFID = CreateRfidNum(mcd.ParticlesID.Value);
                string msg = medicineCabinetDrugManageBLL.AddParticleNum(null, mcd, null);
                if (msg == "")
                {
                    MachinePublic.WriteRfidData = mcd.RFID.Value;
                    MachinePublic.WriteRfidExcule = true;
                    timer1.Interval = 200;
                    timer1.Start();
                    //CheckRow();
                }
                else
                {
                    this.ShowWarningDialog("写入失败!" + msg);
                }
            }
            catch (Exception ex)
            {
                this.ShowWarningDialog("写入失败!" + ex.Message);
            }
        }
        /// <summary>
        /// 生成rfid数字
        /// </summary>
        /// <param name="particId">颗粒id</param>
        /// <returns>返回rfid编号，如10001，后四位是颗粒id，前1到2位数是种类多瓶序号/returns>
        private int CreateRfidNum(int particId)
        {
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            var allMedicineCabinetDetails = commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            string rfidString = particId.ToString();
            while (rfidString.Length < 4)
            {
                rfidString = "0" + rfidString;
            }

            bool isExit = true;
            int index = 1;
            while (isExit)
            {
                var str = index + rfidString;
                if (allMedicineCabinetDetails.Any(x => x.RFID.ToString() == str))
                {
                    index++;
                    continue;
                }
                else
                {
                    rfidString = str;
                    isExit = false;
                }
            }
            return int.Parse(rfidString);
        }
        //private void btnOpterDropDown_Click(object sender, EventArgs e)
        //{
        //    btnOpterDropDown.ShowContextMenuStrip(cmsOpterData, 0, btnOpterDropDown.Height);
        //}

        private void btnExportOpter_Click(object sender, EventArgs e)
        {
            //btnExportOpter.ShowContextMenuStrip(cmsExcelOpter, 0, btnExportOpter.Height);
        }

        private void 有效期查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPeriodOfValidity frmPeriodOfValidity = new FrmPeriodOfValidity();
            frmPeriodOfValidity.ShowDialog();
        }

        private void 上药ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParticleStockAdd frmParticleStockAdd = new FrmParticleStockAdd();
            frmParticleStockAdd.ShowDialog();
            bool isSuccessed = frmParticleStockAdd.isSuccess;
            if (isSuccessed)
            {
                this.ShowSuccessTip("上药操作成功");
                Refc();
            }

        }

        private void 余量调整ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdjustmentOfSurplus frmAdjustmentOfSurplus = new FrmAdjustmentOfSurplus();
            frmAdjustmentOfSurplus.ShowDialog();
            bool isSuccessed = frmAdjustmentOfSurplus.isSuccess;
            if (isSuccessed)
            {
                this.ShowSuccessTip("余量校准操作成功");
                Refc();
            }
        }

        private void 库存设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStockSet frmStockSet = new FrmStockSet();
            frmStockSet.ShowDialog();
            bool isSuccessed = frmStockSet.isSuccess;
            if (isSuccessed)
            {
                this.ShowSuccessTip("库存设置操作成功");
                Refc();
            }
        }

        private void 导出颗粒位置Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var positionInfos = _medicineCabinetDrugManageBLL.GetParticlesPosition();
            if (positionInfos == null || positionInfos.Count <= 0)
            {
                this.ShowWarningDialog("需要导出的颗粒位置信息不存在");
                return;
            }

            ExcelOpterUI excelOpterUI = new ExcelOpterUI();
            excelOpterUI.ExportSinglePage(positionInfos.ToList<object>(), "药柜颗粒位置");
        }

        private void 导出颗粒余量Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stockInfos = _medicineCabinetDrugManageBLL.GetParticlesStock();
            if (stockInfos == null || stockInfos.Count <= 0)
            {
                this.ShowWarningDialog("需要导出的颗粒库存信息不存在");
                return;
            }

            ExcelOpterUI excelOpterUI = new ExcelOpterUI();
            excelOpterUI.ExportSinglePage(stockInfos.ToList<object>(), "药柜颗粒库存");
        }

        private void 导入颗粒余量Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicineCabinetParticImport frmMedicineCabinetParticImport = new FrmMedicineCabinetParticImport(1);
            frmMedicineCabinetParticImport.ShowDialog();
        }

        private void 导入颗粒位置Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicineCabinetParticImport frmMedicineCabinetParticImport = new FrmMedicineCabinetParticImport(2);
            frmMedicineCabinetParticImport.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MachinePublic.WriteRfidFish)
            {
                MachinePublic.WriteRfidExcule = false;
                this.ShowSuccessTip("数据写入成功");
                MachinePublic.WriteRfidFish = false;
                timer1.Stop();

            }
            if (MachinePublic.WriteRfidError)
            {
                MachinePublic.WriteRfidExcule = false;
                MachinePublic.WriteRfidError = false;
                MessageBox.Show("数据写入失败");
                timer1.Stop();
            }
        }

        private void btnOpterCabinets_Click(object sender, EventArgs e)
        {
            btnOpterCabinets.ShowContextMenuStrip(cmsOpterData, 0, btnOpterCabinets.Height);
        }

        private void brnCabinetsExport_Click(object sender, EventArgs e)
        {
            btnCabinetsExport.ShowContextMenuStrip(cmsExcelOpter, 0, btnCabinetsExport.Height);
        }
    }
}
