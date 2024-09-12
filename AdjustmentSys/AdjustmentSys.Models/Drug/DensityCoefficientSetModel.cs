using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Drug
{
    public class DensityCoefficientSetModel
    {
        public int ID { get; set; }

        public int Code { get; set; }
        public string ParName { get; set; }
        public int? ManufacturerID { get; set; }
        public float Density { get; set; }
        public float? DensityCoefficient { get; set; }
    }
}
