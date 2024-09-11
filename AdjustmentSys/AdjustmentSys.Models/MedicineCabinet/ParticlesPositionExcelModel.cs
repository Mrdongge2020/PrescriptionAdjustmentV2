using AdjustmentSys.Common.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MedicineCabinet
{
    /// <summary>
    /// 颗粒位置
    /// </summary>
    public class ParticlesPositionExcelModel
    {
        /// <summary>
        /// 药柜id
        /// </summary>
        [Title(Titile = "药柜Id")]
        public int MedicineCabinetId { get; set; }
        /// <summary>
        /// 颗粒Id
        /// </summary>
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
        /// X横坐标
        /// </summary>
        [Title(Titile = "X横坐标")]
        public int CoordinateX { get; set; }
        /// <summary>
        /// Y纵坐标
        /// </summary>
        [Title(Titile = "Y纵坐标")]
        public int CoordinateY { get; set; }
    }
}
