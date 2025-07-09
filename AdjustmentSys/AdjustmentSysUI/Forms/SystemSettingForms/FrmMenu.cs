using AdjustmentSys.BLL.Common;
using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.User;
using AdjustmentSysUI.UITool;
using NPOI.POIFS.Properties;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdjustmentSysUI.Forms.SystemSettingForms
{
    public partial class FrmMenu : UIPage
    {
        private readonly ComboxDataBLL _comboxDataBLL = new ComboxDataBLL();
        SysPermissionBLL _sysPermissionBLL = new SysPermissionBLL();
        public FrmMenu()
        {

            InitializeComponent();
            ControlOpterUI.SetTitleStyle(this);
        }

        int selectValue=1;

        private void BindTree()
        {

            //MenuInfos.Add(new MenuInfo() { ID = 1, Name = "用户", Level = 1, ParentId = 0 });
            //MenuInfos.Add(new MenuInfo() { ID = 2, Name = "医生", Level = 1, ParentId = 0 });
            //MenuInfos.Add(new MenuInfo() { ID = 3, Name = "用户新增", Level = 2, ParentId = 1 });
            //MenuInfos.Add(new MenuInfo() { ID = 4, Name = "用户编辑", Level = 2, ParentId = 1 });
            //int maxLevel= MenuInfos.Max(m => m.Level);
            //for (int i = 0; i < maxLevel-1; i++) 
            //{ 
            //    TreeNode treeNode = new TreeNode();
            //}

            //创建根节点
            this.menuTreeView.Nodes.Clear();//清空节点
            if (selectValue <= 0)
            {
                return;
            }
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "系统全域";
            rootNode.Tag = 0;
            rootNode.ImageIndex = 0;
            this.menuTreeView.Nodes.Add(rootNode);

            var menuInfos = _sysPermissionBLL.GetAllMenuInfos();
            if (menuInfos == null)
            {
                return;
            }

            var permissions = _sysPermissionBLL.GetPermissionInfosByLevelID(selectValue);

            CreateChildNode(rootNode, menuInfos[0].ParentName, permissions, menuInfos);

            //this.menuTreeView.Nodes[0].Expand();//展开一级菜单
            this.menuTreeView.ExpandAll();//展开所有菜单
        }

        private void CreateChildNode(System.Windows.Forms.TreeNode parentNode, string parentName, List<PermissionInfo> permissions, List<MenuInfo> menuinfos)
        {
            //找到该节点下的子项（父节点值等于该节点编号）
            var nodes = menuinfos.Where(x => x.ParentName == parentName).ToList();
            //创建该节点子节点
            foreach (var item in nodes)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
                node.Tag = item.Level;
                node.Name = item.ID.ToString();
                ////此处可根据节点的parentId来设置图标
                if (item.ParentName == "")
                {
                    node.ImageIndex = 1;
                }
                else
                {
                    node.ImageIndex = 2;
                }
                //设置是否选中
                if (selectValue == 1 || permissions.Any(x => x.MenuID == item.ID && x.LevelID==selectValue))
                {
                    node.Checked = true;
                }
                else 
                {
                    node.Checked = false;
                }
                //父节点添加子节点
                parentNode.Nodes.Add(node);
                //调用自身：递归
                CreateChildNode(node, item.ObjName, permissions, menuinfos);
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;//不自动生成列
            dgvList.AllowUserToAddRows = false;//不自动产生最后的新行
            dgvList.AllowUserToResizeRows = false;
            dgvList.AllowUserToResizeColumns = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGradeViewUi dataGradeViewUi = new DataGradeViewUi();
            //创建列
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "ID", "角色ID", true, true, 10, "");
            dataGradeViewUi.InitDgvTextBoxColumn(this.dgvList, DataGridViewContentAlignment.MiddleLeft, "Name", "角色名称", true, true, 10, "");

            this.dgvList.DataSource = _comboxDataBLL.GetUserLevelComboxData();
        }

        private void menuTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (selectValue<=1 || node.Tag.ToString() == "0")
            {
                return;
            }
           

            int menuId = Convert.ToInt32(node.Name);
            string resMsg = "";
            if (node.Checked)
            {
                resMsg = _sysPermissionBLL.OpterPermission(selectValue, menuId, true);
            }
            else
            {
                resMsg = _sysPermissionBLL.OpterPermission(selectValue, menuId, false);
            }

            if (resMsg == "")
            {
                ShowSuccessTip("操作成功");
            }
            else
            {
                ShowErrorDialog("操作失败" + resMsg);
            }

        }



        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //列头点击不处理
            if (e.RowIndex < 0) { return; }

            selectValue = Convert.ToInt32(this.dgvList.Rows[e.RowIndex].Cells["ID"].Value);

            lblJSName.Text = this.dgvList.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            BindTree();
        }
    }
}
