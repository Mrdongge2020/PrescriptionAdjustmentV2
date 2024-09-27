using AdjustmentSys.Models.Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.TCP
{
    public class PIDTool
    {
        public PID pid = new PID();
        public void PID_Int(ConfirmLocalDataPrescriptionDetail Detail, float Dweight, int box)
        {
            pid.ActualValue = (Math.Abs(Dweight) - 0.3f) * (Math.Abs(Dweight) / Dweight);
            //pid.err_last = (float)Detail.TotalAmountUse;
            //pid.err_prev = (float)Detail.lastTotalAmountUse;
            pid.Kp = 0.03f;
            pid.Ki = 0.03f;
            pid.Kd = 0.01f;
            pid.Nowweight = (float)Detail.NewDose * box * 2;


        }
        /// <summary>
        /// pid结构
        /// </summary>
        public struct PID
        {
            /// <summary>
            /// 定义设定值
            /// </summary>
          //  public float ExpectedValue;
            /// <summary>
            /// 定义实际值
            /// </summary>
            public float ActualValue;               //

            /// <summary>
            /// 定义偏差值
            /// </summary>
            public float err;                       //
            /// <summary>
            /// 定义上一个偏差值
            /// </summary>
            public float err_last;                  //
            /// <summary>
            /// 定义前一个的偏差值
            /// </summary>
            public float err_prev;                  //
            /// <summary>
            /// 定义比例、积分、微分系数
            /// </summary>
            public float Kp, Ki, Kd;                //

            public float Nowweight;                //本次调剂重量
        }
        /// <summary>
        /// 返回密度系数调整
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>

        public float PID_Realize()
        {
            //pid.ExpectedValue = float.Parse(txtc.Text);
            //pid.ActualValue = float.Parse(txtA.Text);
            pid.err = pid.ActualValue;
            //a1:
            //if (pid.err_last == 0)
            //{
            //    pid.err_last = pid.err;
            //}
            //if (pid.err_prev == 0)
            //{
            //    pid.err_prev = pid.err_last;
            //}

            ////增量式pid公式
            //float incrementValue = pid.Kp * (pid.err - pid.err_last) + pid.Ki * pid.err + pid.Kd * (pid.err - 2 * pid.err_last + pid.err_prev);
            //pid.err_prev = pid.err_last;
            //pid.err_last = pid.err;
            //if (Math.Abs(incrementValue / pid.ActualValue * pid.Nowweight) > Math.Abs(pid.ActualValue))
            //{
            //    pid.err -= incrementValue;

            //    goto a1;
            //}
            float x = 1;
            float incrementValue = pid.Kp * pid.Nowweight;
            if (incrementValue < Math.Abs(pid.ActualValue))
            {
                x = Math.Abs(Math.Abs(pid.ActualValue) / pid.ActualValue + pid.Kp);

            }
            else
            {
                if (Math.Abs(pid.ActualValue) < 0.3)
                {
                    x = 1;
                }
                else
                {
                    x = 1 + pid.ActualValue / pid.Nowweight;
                }


            }
            return (x);

        }
    }
}
