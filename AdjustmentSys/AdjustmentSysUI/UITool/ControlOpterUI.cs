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
            uIPage.Style = UIStyle.Custom;
            uIPage.Symbol = 361641;
            uIPage.TitleForeColor = Color.FromArgb(80, 126, 164);
            uIPage.TitleFillColor = SystemColors.GradientInactiveCaption;
        }
         
    }
}
