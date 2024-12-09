using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MedicineCabinet
{
    public class ParticleUsedStatistics
    {
        /// <summary>
        /// 药品名称
        /// </summary>
        public string ParticleName { get; set; }

        /// <summary>
        /// 使用数量
        /// </summary>
        public float UseAmount { get; set; }
        /// <summary>
        /// 使用次数
        /// </summary>
        public float UseCount { get; set; }
    }
}
