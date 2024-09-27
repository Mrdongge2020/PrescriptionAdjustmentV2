using AdjustmentSys.DAL.Common;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Common
{
    public class CommonDataBLL
    {
        CommonDataDAL _commonDataDAL = new CommonDataDAL();

        /// <summary>
        /// 获取所有药柜编号
        /// </summary>
        public List<string> GetMedicineCabinetCodes() 
        { 
            return _commonDataDAL.GetMedicineCabinetCodes();
        }

        /// <summary>
        /// 获取药品字典数据
        /// </summary>
        /// <returns></returns>
        public  List<ParticlesInfo> GetCommonParticles(List<int> ids = null)
        { 
            return _commonDataDAL.GetCommonParticles(ids);
        }
        /// <summary>
        /// 获取药柜详情信息
        /// </summary>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public List<MedicineCabinetDetail> GetMedicineCabinetDetails(string code) 
        {
            return _commonDataDAL.GetMedicineCabinetDetails(code);
        }

        /// <summary>
        /// 获取所有相容性规则信息
        /// </summary>
        public List<ParticleProhibitionRule> GetParticleProhibitionRules() 
        {
            return _commonDataDAL.GetParticleProhibitionRules();
        }
        /// <summary>
        /// 获取所有待下载处方
        /// </summary>
        /// <param name="preIds">处方编号集合</param>
        /// <returns></returns>
        public List<DataPrescription> GetAllDataPrescriptions(List<string> preIds)
        {
            
            return _commonDataDAL.GetAllDataPrescriptions(preIds);
        }
        /// <summary>
        /// 获取所有待下载处方详情
        /// </summary>
        /// <param name="preIds">处方编号集合</param>
        /// <returns></returns>
        public List<DataPrescriptionDetail> GetAllDataPrescriptionDetails(List<string> preIds)
        {
            return _commonDataDAL.GetAllDataPrescriptionDetails(preIds);
        }

        /// <summary>
        /// 获取所有厂家主信息
        /// </summary>
        /// <returns></returns>
        public List<ManufacturerInfo> GetManufacturerInfos() 
        { 
            return _commonDataDAL.GetManufacturerInfos();
        }
    }
}
