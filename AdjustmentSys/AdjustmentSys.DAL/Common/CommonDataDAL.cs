using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Common
{
    public class CommonDataDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();
        /// <summary>
        /// 获取药品字典数据
        /// </summary>
        /// <returns></returns>
        public  List<ParticlesInfoEditModel> GetCommonParticles(List<int> ids)
        {
            List<ParticlesInfoEditModel> result = new List<ParticlesInfoEditModel>();
            string sql = @" select a.ID,a.Name,a.FullName,a.Code,a.NameFullPinyin,a.NameSimplifiedPinyin,a.ManufacturerId,a.ListingNumber,a.Remark,b.HisCode,b.HisName,b.Density,b.Equivalent,b.DoseLimit,b.PackageNumber,b.WholesalePrice,b.RetailPrice
                        from ParticlesInfo as a
                        left join ParticlesInfoExtend as b on a.ID=b.ParticlesID ";
            if (ids != null && ids.Count > 0) 
            {
                sql += " where a.ID in ("+string.Join(',', ids) +") ";
            }
            result = DBHelper.ExecuteQuery<ParticlesInfoEditModel>(sql);
            return result;
        }

        /// <summary>
        /// 获取药柜详情信息
        /// </summary>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public List<MedicineCabinetDetail> GetMedicineCabinetDetails(string code) 
        {
            List<MedicineCabinetDetail> result = new List<MedicineCabinetDetail>();
            string sql = $@" select  a.*  from MedicineCabinetDetail as a 
						     join MedicineCabinetInfo as b on a.MedicineCabinetId=b.ID
						     where b.Code='{code}' ";
            result = DBHelper.ExecuteQuery<MedicineCabinetDetail>(sql);
            return result;
        }

        /// <summary>
        /// 获取所有相容性规则信息
        /// </summary>
        public List<ParticleProhibitionRule> GetParticleProhibitionRules()
        {
            
            var result = _eFCoreContext.ParticleProhibitionRules.ToList();
            return result;
        }
         
        /// <summary>
        /// 获取所有待下载处方
        /// </summary>
        /// <param name="preIds">处方编号集合</param>
        /// <returns></returns>
        public List<DataPrescription> GetAllDataPrescriptions(List<string> preIds) 
        {
            var list = _eFCoreContext.DataPrescriptions.Where(x => preIds.Contains(x.PrescriptionID)).ToList();
            return list;
        }
        /// <summary>
        /// 获取所有待下载处方详情
        /// </summary>
        /// <param name="preIds">处方编号集合</param>
        /// <returns></returns>
        public List<DataPrescriptionDetail> GetAllDataPrescriptionDetails(List<string> preIds)
        {
            var list = _eFCoreContext.DataPrescriptionDetails.Where(x =>preIds.Contains(x.PrescriptionID)).ToList();
            return list;
        }

    }
}
