using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Machine
{
    //[DefaultEvent("StationtextChanged")]
    /// <summary>
    /// 调剂工位
    /// </summary>

    public class Station
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        //  Color bGColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        public Color BGColor { get; set; } = SystemColors.MenuBar;
        // public Color BGColor { get; set; } = Color.White;
        /// <summary>
        /// 进度条颜色
        /// </summary>

        //进度值
        public float Parvalue { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public RectangleF rectangleF { get; set; }
    }

    public class  ShowsItem
    {
        /// <summary>
        /// 目录
        /// </summary>
        public string MText { get; set; } = "名称";
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; } = "内容";
        /// <summary>
        /// 背景色
        /// </summary>
 
        public Color BGColor { get; set; } = SystemColors.MenuBar;
        /// <summary>
        /// 目录背景色
        /// </summary>

        public Color MGColor { get; set; } = Color.CadetBlue;

        /// <summary>
        /// 进度条颜色
        /// </summary>

        //内容颜色
        public Color Textcolor { get; set; } = Color.Blue;

        /// 位置
        /// </summary>
        public RectangleF rectangleF { get; set; }
    }
  
    /// <summary>
    /// 袋膜工位
    /// </summary>

    public class Model
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
    //    Color bGColor = System.Drawing.Color.CadetBlue;
        public Color BGColor { get; set; } = System.Drawing.Color.CadetBlue;
        /// <summary>
        /// 袋膜内部颜色
        /// </summary>
      // private Color haveColor = System.Drawing.SystemColors.MenuBar;

        public Color HaveColor { get; set; } = System.Drawing.SystemColors.MenuBar;

        /// 位置
        /// </summary>
        public RectangleF rectangleF { get; set; }
    }
}
