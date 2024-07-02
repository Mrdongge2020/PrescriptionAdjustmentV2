using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    ///协定处方表
    /// </summary>
    [Table("AgreementPrescriptionInfo")]
    public class AgreementPrescriptionInfo:CreateModel
    {
        /// <summary>
        /// 处方名称
        /// </summary>
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("Description")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
