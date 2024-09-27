using AdjustmentSys.Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Assembiy
{
    /// <summary>
    /// 盒子对象
    /// </summary>
    public class Medbox
    {
        /// <summary>
        /// 处方编号
        /// </summary>
        public string PrescriptionID { get; set; }
        /// <summary>
        /// 处方详情
        /// </summary>
        public List<ParticlesDetail> ParticlesDetails { get; set; }
        /// <summary>
        ///出盒状态
        /// </summary>
        public bool OutState { get; set; }
        /// <summary>
        /// 封口状态
        /// </summary>
        public bool SealState { get; set; }
        /// <summary>
        /// 当前药盒完成的颗粒品种数量
        /// </summary>
        public int FinishValue { get; set; }
        /// <summary>
        /// //药盒进度
        /// </summary>
        public int Bar { get; set; }
        /// <summary>
        /// 当前无盒作状态 =0 无 =1供盒中  =2待调剂 =3调剂中  =4待封口 =5封口中 =6待出盒 =7 出盒中；
        /// </summary>
        public BoxStatusEnum State { get; set; }

    }

    /// <summary>
    /// 药盒的颗粒详情
    /// </summary>
    public class ParticlesDetail
    {
        /// <summary>
        /// 颗粒码
        /// </summary>
        public int ParticlesID { get; set; }
        /// <summary>
        /// 量仓的千分比
        /// </summary>
        public int Steper { get; set; }
        /// <summary>
        /// 颗粒完成状态
        /// </summary>
        public bool Finish { get; set; }

    }
    
}
