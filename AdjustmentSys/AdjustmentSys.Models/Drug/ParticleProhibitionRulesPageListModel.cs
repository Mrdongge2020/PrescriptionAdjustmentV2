using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Drug
{
    /// <summary>
    /// 颗粒相容规则分页列表
    /// </summary>
    public class ParticleProhibitionRulesPageListModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 规则名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 第一味颗粒
        /// </summary>
        public string FirstParticlesName { get; set; }
        /// <summary>
        /// 第二味颗粒
        /// </summary>
        public string SecondParticlesName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string? CreateName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人名称
        /// </summary>
        public string? UpdateName { get; set; }
    }
}
