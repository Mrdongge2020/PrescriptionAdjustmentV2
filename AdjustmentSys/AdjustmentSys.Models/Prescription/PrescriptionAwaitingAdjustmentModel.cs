using AdjustmentSys.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Models.Prescription
{
    public class PrescriptionAwaitingAdjustmentModel
    {
        public LocalDataPrescriptionInfo PrescriptionInfo { get; set; }

        public List<LocalDataPrescriptionDetail> PrescriptionDetails { get; set; }
    }
}
