using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdjustmentSys.Entity.BaseEntity;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 颗粒相融规则
    /// </summary>
    [Table("ParticleProhibitionRule")]
    public class ParticleProhibitionRule:UpdateModel
    {
        /// <summary>
        /// 规则名称
        /// </summary>
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 第一味颗粒
        /// </summary>
        [Column("FirstParticlesID")]
        public int FirstParticlesID { get; set; }
        /// <summary>
        /// 第二味颗粒
        /// </summary>
        [Column("SecondParticlesID")]
        public int SecondParticlesID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [MaxLength(200)]
        public string? Remark { get; set; }

    }
}
