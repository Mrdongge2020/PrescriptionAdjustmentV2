using AdjustmentSys.DAL.Prescription;
using AdjustmentSys.Models.Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Prescription
{
    public class PrescriptionAdjustmentBLL
    {
        PrescriptionAdjustmentDAL _prescriptionAdjustmentDAL = new PrescriptionAdjustmentDAL();

        /// <summary>
        /// 获取已下载列表数据
        /// </summary>
        /// <param name="preIds">处方编号</param>
        /// <returns></returns>
        public List<DownLoadedPre> GetDownLoadedPres(List<string> preIds) 
        { 
            return _prescriptionAdjustmentDAL.GetDownLoadedPres(preIds);
        }
    }
}
