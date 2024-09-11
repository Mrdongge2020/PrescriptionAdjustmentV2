using AdjustmentSys.BLL.Common;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
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
        public FrmMenu()
        {
            InitializeComponent();
        }

        List<MenuInfo> MenuInfos = new List<MenuInfo>();
        private void BindTree()
        {

            MenuInfos.Add(new MenuInfo() { ID = 1, MenuName = "用户", Level = 1, ParentId = 0 });
            MenuInfos.Add(new MenuInfo() { ID = 2, MenuName = "医生", Level = 1, ParentId = 0 });
            MenuInfos.Add(new MenuInfo() { ID = 3, MenuName = "用户新增", Level = 2, ParentId = 1 });
            MenuInfos.Add(new MenuInfo() { ID = 4, MenuName = "用户编辑", Level = 2, ParentId = 1 });
            //int maxLevel= MenuInfos.Max(m => m.Level);
            //for (int i = 0; i < maxLevel-1; i++) 
            //{ 
            //    TreeNode treeNode = new TreeNode();
            //}

            //创建根节点
            this.menuTreeView.Nodes.Clear();//清空节点
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "调剂系统V2";
            rootNode.Tag = 0;
            rootNode.ImageIndex = 0;
            this.menuTreeView.Nodes.Add(rootNode);

            CreateChildNode(rootNode, 0);

            //this.menuTreeView.Nodes[0].Expand();//展开一级菜单
            this.menuTreeView.ExpandAll();//展开所有菜单
        }

        private void CreateChildNode(System.Windows.Forms.TreeNode parentNode, int parentId)
        {
            //找到该节点下的子项（父节点值等于该节点编号）
            var nodes = from list in this.MenuInfos
                        where list.ParentId.Equals(parentId)
                        select list;
            //创建该节点子节点
            foreach (var item in nodes)
            {
                TreeNode node = new TreeNode();
                node.Text = item.MenuName;
                node.Tag = item.Level;
                node.Name = item.ID.ToString();
                ////此处可根据节点的parentId来设置图标
                if (item.ParentId == 0)
                {
                    node.ImageIndex = 1;
                }
                else
                {
                    node.ImageIndex = 2;
                }
                //父节点添加子节点
                parentNode.Nodes.Add(node);
                //调用自身：递归
                CreateChildNode(node, item.ID);
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            List<ComboxModel> levelDatas = _comboxDataBLL.GetUserLevelComboxData();
            cbLevel.ValueMember = "Id";
            cbLevel.DisplayMember = "Name";
            cbLevel.DataSource = levelDatas;
            cbLevel.SelectedIndex = -1;
            BindTree();
        }
    }
}
