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
    public class MenuInfo:BaseModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("Name")]
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 菜单等级,1,2
        /// </summary>
        [Column("Level")]
        public int Level { get; set; }
        /// <summary>
        /// 父级菜单id
        /// </summary>
        [Column("ParentId")]
        public int ParentId { get; set; }
        /// <summary>
        /// 父级菜单控件名称
        /// </summary>
        [Column("ParentName")]
        [MaxLength(20)]
        public string ParentName { get; set; }
        /// <summary>
        /// 控件名称
        /// </summary>
        [Column("ObjName")]
        [MaxLength(20)]
        public string ObjName { get; set; }
    }
}
