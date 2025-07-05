using AdjustmentSys.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 角色菜单权限表
    /// </summary>
    [Table("PermissionInfo")]
    public class PermissionInfo:BaseModel
    {
        /// <summary>
        /// 权限等级ID
        /// </summary>
        [Column("LevelID")]
        public int LevelID { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        [Column("MenuID")]
        public int MenuID { get; set; }
    }
}
