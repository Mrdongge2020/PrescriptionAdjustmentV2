using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.MedicineCabinet
{
    /// <summary>
    /// 药柜管理列表实体
    /// </summary>
    public class MedicineCabinetDetailListModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 药柜id
        /// </summary>
        public int MedicineCabinetId { get; set; }
        /// <summary>
        /// 横坐标
        /// </summary>
        public int CoordinateX { get; set; }
        /// <summary>
        /// 纵坐标
        /// </summary>
        public int CoordinateY { get; set; }
        /// <summary>
        /// 颗粒id
        /// </summary>
        public int? ParticlesID { get; set; }
        /// <summary>
        /// 颗粒名称
        /// </summary>
        public string? ParticlesName { get; set; }

        /// <summary>
        /// 效期至
        /// </summary>
        public DateTime? ValidityTime { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public float? Stock { get; set; }
        /// <summary>
        /// rfd
        /// </summary>
        public int? RFID { get; set; }
    }
}
