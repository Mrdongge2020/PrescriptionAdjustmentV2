using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MedicineCabinet
{
    public class MedicineCabinetListModel
    {
        /// <summary>
        /// 药柜id
        /// </summary>

        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 规格，1=大药柜，2=小药柜
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 横向个数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 纵向个数
        /// </summary>
        public int ColCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
