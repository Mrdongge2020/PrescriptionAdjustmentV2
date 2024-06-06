using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.MedicineCabinet;
using Microsoft.Identity.Client.NativeInterop;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //InitData();
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
                    DataGridViewButtonColumn dataGridViewTextBoxColumn = new DataGridViewButtonColumn();
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
                    //设置绑定的字段
                    dataGridViewTextBoxColumn.DataPropertyName = item.ID + "" + i;
                    //设置列宽
                    dataGridViewTextBoxColumn.Width = 80;
                    //将创建的列添加到DataGridView中
                    dgvList.Columns.Add(dataGridViewTextBoxColumn);
                }
            }
            dgvList.RowTemplate.Height = 55;

            //添加所有行
            for (int i = 0; i < cabinetsList.Max(x => x.RowCount); i++)
            {
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
                        this.dgvList.Rows[i].Cells[sortIndex == 1 ? item.CoordinateY - 1 : item.CoordinateY].Value = i + 1;
                    }
                    cabinetId = item.MedicineCabinetId;
                }
                int columnIndex = item.CoordinateY + (sortIndex - 1);
                string valueText = "";
                if (item.ParticlesID > 0)
                {
                    valueText = item.ParticlesName + "\r\n" + (item.Stock ?? 0) + "克";
                    this.dgvList.Rows[rowIndex].Cells[columnIndex].Style.BackColor = BackColor(item.Stock ?? 0);
                }

                this.dgvList.Rows[rowIndex].Cells[columnIndex].Value = valueText;
            }
            #endregion

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
            dataGridViewTextBoxColumn.Width = 45;

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
            cbDurg.Text =selectDurgModel.ParticlesName;
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
                ShowWarningDialog("请选择药柜信息");
                return;
            }
            Point startPoint = new Point(MousePosition.X - 70, MousePosition.Y - 20);
            FrmListingParticles frmListingParticles = new FrmListingParticles();
            frmListingParticles.StartPosition = FormStartPosition.Manual;
            frmListingParticles.Location = startPoint;
            DialogResult Result =frmListingParticles.ShowDialog();
            if (Result == DialogResult.OK) 
            {
                string msg = _medicineCabinetDrugManageBLL.ListingParticle(selectDurgModel.ID, code, frmListingParticles._Id);
                if (msg == "")
                {
                    ShowSuccessTip("上架颗粒成功");
                    dgvList.Rows[Rowindex].Cells[Colindex].Value = frmListingParticles._Name;
                }
                else
                {
                    ShowErrorDialog("错误提示", msg);
                }
            }
        }

        private void btnRefc_Click(object sender, EventArgs e)
        {
            dgvList.Columns.Clear();
            dgvList.Rows.Clear();
            InitData();
        }

        private void FrmMedicineCabinetManage_Load(object sender, EventArgs e)
        {
            InitData();
        }

        //private void cbDurg_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    cbDurg.SelectedValue.WriteConsole();
        //    cbDurg.SelectedItem.WriteConsole();
        //    cbDurg.Text.WriteConsole();
        //}

        //private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.Right) 
        //    {
        //        return;
        //    }
        //    if (dgvList.Columns[e.ColumnIndex].Name.Contains("Sort"))
        //    {
        //        return;
        //    }


        //}
    }
}
