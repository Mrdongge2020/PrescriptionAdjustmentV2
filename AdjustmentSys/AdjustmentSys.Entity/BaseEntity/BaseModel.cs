using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity.BaseEntity
{
    /// <summary>
    /// id主键实体
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// ID主键
        /// </summary>
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int ID { get; set; }
    }
}
