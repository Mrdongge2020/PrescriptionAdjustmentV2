using AdjustmentSys.EFCore;
using AdjustmentSys.Models.Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Prescription
{
    public class PrescriptionAdjustmentDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 获取已下载列表数据
        /// </summary>
        /// <param name="preIds">处方编号</param>
        /// <returns></returns>
        public List<DownLoadedPre> GetDownLoadedPres(List<string> preIds) 
        {
            var data = _eFCoreContext.LocalDataPrescriptionInfos.Where(x => preIds.Contains(x.PrescriptionID))
                .Select(x => new DownLoadedPre
                {
                    PrescriptionID = x.PrescriptionID,
                    PatientName = x.PatientName,
                    PatientAge = x.PatientAge,
                    PatientSex = x.PatientSex.ToString(),
                    ProcessStatus = x.ProcessStatus,
                    Quantity = x.Quantity
                }).ToList();
            return data;
        }
    }
}
