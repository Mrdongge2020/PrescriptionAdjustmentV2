using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.User
{
    public class UserPageListModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>

        public string UserName { get; set; }
        /// <summary>
        /// 账号状态：可用,禁用
        /// </summary>
        public string StateText { get; set; }
        /// <summary>
        /// 办公室
        /// </summary>
        public string? Office { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 用户权限等级名称
        /// </summary>
        public string? UserLevelName { get; set; }
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
