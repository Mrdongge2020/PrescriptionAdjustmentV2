using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSysUI.UITool
{
    /// <summary>
    /// 表格ui
    /// </summary>
    public class DataGradeViewUi
    {
        /// <summary>
        /// 创建DataGridView的TextBox列
        /// </summary>
        /// <param name="dgv">要创建列的DataGridView</param>
        /// <param name="_alignmeng">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">显示的标题名</param>
        /// <param name="_readOnly">设置列是否只读 true只读 false 读写</param>
        /// <param name="_visible">设置列是否可见 true 可见 false 不可见</param>
        /// <param name="_width">设置列宽度</param>
        /// <param name="_format">设置列显示数据格式,时间传“yyyy-MM-dd HH:mm:ss”，价格数字传“N2”</param>
        public void InitDgvTextBoxColumn(DataGridView dgv, DataGridViewContentAlignment _alignmeng,
            string _columnName, string _headerText, bool _readOnly, bool _visible, int _width, string _format)
        {
            //实例化一个DataGridViewTextBoxColumn列
            DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
            //设置对齐方式
            tbc.HeaderCell.Style.Alignment = _alignmeng;
            //设置列名
            tbc.Name = _columnName;
            //设置标题
            tbc.HeaderText = _headerText;

            //设置是否只读
            tbc.ReadOnly = _readOnly;
            //设置是否可见
            tbc.Visible = _visible;
            //设置绑定的字段
            tbc.DataPropertyName = _columnName;
            //设置列宽
            if (_width > 100)
            {
                tbc.Width = _width;
            }
            else if (_width > 0)
            {
                tbc.FillWeight = _width;
            }


            //设置格式
            if (_format != "")
            {
                tbc.DefaultCellStyle.Format =_format;
            }
            
            //将创建的列添加到DataGridView中
            dgv.Columns.Add(tbc);
        }

        /// <summary>
        /// 创建DataGridView的CheckBox列
        /// </summary>
        /// <param name="dgv">要创建列的DataGridView</param>
        /// <param name="_alignmeng">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">显示的标题名</param>
        /// <param name="_readOnly">设置列是否只读 true只读 false 读写</param>
        /// <param name="_visible">设置列是否可见 true 可见 false 不可见</param>
        public void InitDgvCheckBoxColumn(DataGridView dgv, DataGridViewContentAlignment _alignmeng,
            string _columnName, string _headerText, bool _readOnly, bool _visible, int _width)
        {
            //实例化一个DataGridViewTextBoxColumn列
            DataGridViewCheckBoxColumn cbc = new DataGridViewCheckBoxColumn();
            //设置对齐方式
            cbc.HeaderCell.Style.Alignment = _alignmeng;

            cbc.ValueType=typeof(bool);
            //设置列名
            cbc.Name = _columnName;
            //设置标题
            cbc.HeaderText = _headerText;
            //绑定字段值
            cbc.DataPropertyName = _columnName;
            //设置是否默认选中
            //cbc.Selected = _selected.Equals("男") ? true : false;
            //设置是否只读
            cbc.ReadOnly = _readOnly;
            //设置是否可见
            cbc.Visible = _visible;

            cbc.FillWeight = _width;
            //将创建的列添加到DataGridView中
            dgv.Columns.Add(cbc);
        }

        /// <summary>
        /// 计算dgv列的值的总和
        /// </summary>
        /// <param name="dataGrid">dgv对象</param>
        /// <param name="colNname">列名</param>
        /// <returns></returns>
        public double ComputeColumnSum(DataGridView dataGrid, string colNname)
        {
            double sum = 0;        //计算合计  
            for (int i = 0; i < dataGrid.Rows.Count; i++) //获取dataGridView1表格的数据集
            {
                if (dataGrid.Rows[i].Cells[colNname].Value != null)
                {
                    sum += Convert.ToDouble(dataGrid.Rows[i].Cells[colNname].Value.ToString());
                }
            }
            return sum;
        }
    }
}
