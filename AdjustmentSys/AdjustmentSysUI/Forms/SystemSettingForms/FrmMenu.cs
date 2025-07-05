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

        List<MenuInfo> menuInfos = new List<MenuInfo>();
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

            var permissions = _sysPermissionBLL.GetPermissionInfosByLevelID(SysLoginUser.currentUser.UserLevelId);



            CreateChildNode(rootNode, 0, permissions);

            //this.menuTreeView.Nodes[0].Expand();//展开一级菜单
            this.menuTreeView.ExpandAll();//展开所有菜单
        }

        private void CreateChildNode(System.Windows.Forms.TreeNode parentNode, int parentId,List<PermissionInfo> permissions)
        {
            //找到该节点下的子项（父节点值等于该节点编号）
            var nodes = from list in menuInfos
                        where list.ParentId.Equals(parentId)
                        select list;
            //创建该节点子节点
            foreach (var item in nodes)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
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
                //设置是否选中
                if (SysLoginUser.currentUser.UserLevelId==1 || permissions.Any(x=>x.MenuID==item.ID))
                { 
                    node.Checked = true;
                }
                //父节点添加子节点
                parentNode.Nodes.Add(node);
                //调用自身：递归
                CreateChildNode(node, item.ID, permissions);
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
