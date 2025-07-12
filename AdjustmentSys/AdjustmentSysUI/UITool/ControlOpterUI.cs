using AdjustmentSys.BLL.SystemSetting;
using AdjustmentSys.DAL.Common;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSysUI.UITool
{
    public class ControlOpterUI
    {
        //// 通用方法来按名称查找控件
        //private T FindControlByName<T>(string name) where T : Control
        //{
        //    // 调用Controls.Find方法查找控件
        //    T control = this.Controls.Find(name, true).FirstOrDefault() as T;
        //    return control;
        //}
        

        public static void SetTitleStyle(UIPage uIPage) 
        {
            //设置样式
            uIPage.Style = UIStyle.Custom;
            uIPage.Symbol = 361641;
            uIPage.TitleForeColor = Color.Black;//Color.FromArgb(80, 126, 164);
            uIPage.TitleFillColor = Color.FromArgb(250, 250, 250);//Color.White;//SystemColors.GradientInactiveCaption;
            uIPage.BackColor= Color.White;
            //添加菜单
            ControlOpterUI.FindAllMenuByButtons(uIPage, uIPage.Name);
            //设置菜单权限
            ControlOpterUI.FindButtonSetPermission(uIPage, uIPage.Name);
        }

        public static void FindAllMenuByButtons(Control control,string parentName)
        {
            if (!ConfigTB.IsInitMenu) 
            {
                return;
            }
            List<MenuInfo> menus = new List<MenuInfo>();
            if (control.Name.StartsWith("Frm"))
            {
                //添加主菜单项
                MenuInfo menuInfo = new MenuInfo();
                menuInfo.Name = control.Text;
                menuInfo.ParentName = "";
                menuInfo.Level = 1;
                menuInfo.ObjName = control.Name;
                menus.Add(menuInfo);
            }
            else 
            {
                return;
            }

            //添加button项
            foreach (Control c in control.Controls)
            {
                string typename = c.GetType().Name;
                if ((typename == "UISymbolButton" || typename == "UIButton") && c.Name.StartsWith("btn"))//(c is Button)
                {
                    MenuInfo menuInfo1 = new MenuInfo();
                    menuInfo1.Name = c.Text;
                    menuInfo1.ParentName = parentName;
                    menuInfo1.Level = 2;
                    menuInfo1.ObjName = c.Name;
                    menus.Add(menuInfo1); // 按钮的名称
                    if (c.ContextMenuStrip is not null) 
                    {
                        foreach (ToolStripItem item in c.ContextMenuStrip.Items)
                        {
                            MenuInfo menuInfo2 = new MenuInfo();
                            menuInfo2.Name = item.Text;
                            menuInfo2.ParentName = c.Name;
                            menuInfo2.Level = 3;
                            menuInfo2.ObjName = item.Name;
                            menus.Add(menuInfo2); // 按钮的名称
                        }
                    }
                }
                if (typename == "UIDataGridView" && c.ContextMenuStrip is not null) 
                {
                    MenuInfo menuInfo1 = new MenuInfo();
                    menuInfo1.Name = "表格右键操作";
                    menuInfo1.ParentName = parentName;
                    menuInfo1.Level = 2;
                    menuInfo1.ObjName = c.Name;
                    menus.Add(menuInfo1); // 按钮的名称
                    foreach (ToolStripItem item in c.ContextMenuStrip.Items)
                    {
                        MenuInfo menuInfo2 = new MenuInfo();
                        menuInfo2.Name = item.Text;
                        menuInfo2.ParentName = c.Name;
                        menuInfo2.Level = 3;
                        menuInfo2.ObjName = item.Name;
                        menus.Add(menuInfo2); // 按钮的名称
                    }
                }
                if (c.HasChildren)
                {
                    FindAllMenuByButtons(c,parentName); // 递归调用，检查嵌套的控件
                }
            }
            if (menus!=null && menus.Count>0) 
            {
                SysPermissionBLL _sysPermissionBLL = new SysPermissionBLL();
                _sysPermissionBLL.AddMenuinfos(menus);
            }
        }

        /// <summary>
        /// 给按钮设置权限
        /// </summary>
        /// <param name="control">窗体对象</param>
        /// <param name="menus">用户菜单</param>
        /// <param name="parentName">窗体name</param>
        public static void FindButtonSetPermission(Control control,string parentName)
        {
            if (SysLoginUser.currentUser.UserLevelId==1) //超级管理员，跳过
            {
                return;
            }
            SysPermissionBLL _sysPermissionBLL = new SysPermissionBLL();
            var menus = _sysPermissionBLL.GetUserAllMenuInfos();
            foreach (Control c in control.Controls)
            {
                string typename = c.GetType().Name;
                if ((typename == "UISymbolButton" || typename == "UIButton") && c.Name.StartsWith("btn"))
                {
                    if (menus == null || !menus.Any(x => x.ObjName == c.Name && x.ParentName == parentName))
                    {
                        c.Enabled = false;
                    }
                    if (c.ContextMenuStrip is not null)
                    {
                        bool isSetParentTrue = false;
                        foreach (ToolStripItem item in c.ContextMenuStrip.Items)
                        {
                            if (menus == null || !menus.Any(x => x.ObjName == item.Name && x.ParentName == c.Name))
                            {
                                item.Enabled = false;
                            }
                            else 
                            { 
                                isSetParentTrue = true;
                            }
                        }
                        if (isSetParentTrue && !c.Enabled) 
                        {
                            c.Enabled = true;
                        }
                    }
                }

                if (typename == "UIDataGridView" && c.ContextMenuStrip is not null)
                {
                    foreach (ToolStripItem item in c.ContextMenuStrip.Items)
                    {
                        if (menus == null || !menus.Any(x => x.ObjName == item.Name && x.ParentName == c.Name))
                        {
                            item.Enabled = false;
                        }
                    }
                }

                if (c.HasChildren)
                {
                    FindButtonSetPermission(c, parentName); // 递归调用，检查嵌套的控件
                }
            }
        }
    }
}
