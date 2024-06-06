using AdjustmentSys.Entity.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdjustmentSys.Entity
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Table("UserInfo")]
    public class UserInfo: UpdateModel
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Column("UserName")]
        [MaxLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Column("UserPassword")]
        [MaxLength(20)]
        public string UserPassword { get; set; }
        /// <summary>
        /// 账号状态：1：可用，0禁用
        /// </summary>
        [Column("State")]
        public bool State { get; set; }
        /// <summary>
        /// 办公室
        /// </summary>
        [Column("Office")]
        [MaxLength(50)]
        public string? Office { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("Phone")]
        [MaxLength(50)]
        public string? Phone { get; set; }
        /// <summary>
        /// 用户权限等级
        /// </summary>
        [Column("UserLevel")]
        public int UserLevel { get; set; }
        /// <summary>
        /// 用户权限等级名称
        /// </summary>
        [Column("UserLevelName")]
        [MaxLength(50)]
        public string? UserLevelName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [MaxLength(200)]
        public string? Remark { get; set; }
    }
}
