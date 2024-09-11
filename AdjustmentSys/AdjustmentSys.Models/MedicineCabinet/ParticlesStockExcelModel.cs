using AdjustmentSys.Common.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MedicineCabinet
{
    public class ParticlesStockExcelModel
    {
        /// <summary>
        /// 药柜id
        /// </summary>
        [Title(Titile = "药柜Id")]
        public int MedicineCabinetId { get; set; }
        /// <summary>
        /// 颗粒Id
        /// </summary>
        [Title(Titile = "颗粒Id")]
        public int? ParticlesID { get; set; }
        /// <summary>
        /// 颗粒编号
        /// </summary>
        [Title(Titile = "颗粒编号")]
        public int Code { get; set; }
        /// <summary>
        /// 颗粒名称
        /// </summary>
        [Title(Titile = "颗粒名称")]
        public string ParName { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [Title(Titile = "库存")]
        public float? Stock { get; set; }
    }
}
