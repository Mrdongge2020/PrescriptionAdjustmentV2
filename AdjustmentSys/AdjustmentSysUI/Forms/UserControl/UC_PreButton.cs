using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace AdjustmentSysUI.Forms.UserControl
{
    public partial class UC_PreButton : UIUserControl
    {
        public UC_PreButton()
        {
            InitializeComponent();
        }

        private Color fillColor = Color.Lime;

        public Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                this.Invalidate(); // 触发重绘
            }
        }
        private void UC_PreButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // 创建一个蓝色的画刷
            //using (Brush blueBrush = new SolidBrush(Color.Lime))
            //{
            //    // 使用画刷填充椭圆
            //    e.Graphics.FillEllipse(blueBrush, new Rectangle(230, 85, 20, 20));
            //}
            e.Graphics.FillEllipse(fillColor, new Rectangle(230, 85, 20, 20));
            //e.Graphics.DrawString(Text, Font, ForeColor, new Rectangle(35, 0, Width, 40), ContentAlignment.MiddleLeft);
            e.Graphics.DrawString(Text, Font, ForeColor, new Rectangle(10, 50, Width, 10), ContentAlignment.MiddleLeft);
            //e.Graphics.DrawLine(ForeColor, 10, 40, Width - 20, 40);
            //e.Graphics.DrawString("", Font, ForeColor, new Rectangle(10, 40, Width, Height - 40), ContentAlignment.MiddleLeft);
            e.Graphics.Clear(this.BackColor);

        }
    }
}
