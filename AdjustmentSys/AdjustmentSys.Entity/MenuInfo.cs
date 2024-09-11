using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 系统菜单表
    /// </summary>
    [Table("MenuInfo")]
    public class MenuInfo:CreateModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("MenuName")]
        [MaxLength(20)]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单等级,1,2
        /// </summary>
        [Column("MenuName")]
        public int Level { get; set; }
        /// <summary>
        /// 父级菜单id
        /// </summary>
        [Column("MenuName")]
        public int ParentId { get; set; }
    }
}
