using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MedicineCabinet
{
    public class MedicineCabinetValidityModel
    {
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string ParticleName { get; set; }
        /// <summary>
        /// 颗粒编码
        /// </summary>
        public int ParticleCode { get; set; }

        /// <summary>
        /// 效期至
        /// </summary>
        public DateTime ValidityTime { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumber { get; set; }
    }
}
