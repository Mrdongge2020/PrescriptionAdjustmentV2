using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
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
        /// 获取所有药柜编号
        /// </summary>
        public List<string> GetMedicineCabinetCodes() 
        { 
            return _eFCoreContext.MedicineCabinetInfos.OrderBy(x => x.Code).Select(x=>x.Code).Distinct().ToList();
        }
        /// <summary>
        /// 获取药品字典数据
        /// </summary>
        /// <returns></returns>
        public  List<ParticlesInfo> GetCommonParticles(List<int> ids)
        {
            //List<ParticlesInfoEditModel> result = new List<ParticlesInfoEditModel>();
            //string sql = @" select a.ID,a.Name,a.FullName,a.Code,a.NameFullPinyin,a.NameSimplifiedPinyin,a.ManufacturerId,a.ListingNumber,a.Remark,a.HisCode,a.HisName,a.Density,a.Equivalent,a.DoseLimit,a.PackageNumber,a.WholesalePrice,a.RetailPrice
            //            from ParticlesInfo as a ";
            //if (ids != null && ids.Count > 0) 
            //{
            //    sql += " where a.ID in ("+string.Join(',', ids) +") ";
            //}
            //result = DBHelper.ExecuteQuery<ParticlesInfoEditModel>(sql);

            if (ids != null && ids.Count > 0)
            {
                return _eFCoreContext.ParticlesInfos.Where(x => ids.Contains(x.ID)).ToList();
            }
           
            return _eFCoreContext.ParticlesInfos.ToList();
        }



        /// <summary>
        /// 获取药柜详情信息
        /// </summary>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public List<MedicineCabinetDetail> GetMedicineCabinetDetails(string code) 
        {
            //List<MedicineCabinetDetail> result = new List<MedicineCabinetDetail>();
            // string sql = $@" select  a.*  from MedicineCabinetDetail as a 
            //join MedicineCabinetInfo as b on a.MedicineCabinetId=b.ID
            //where b.Code='{code}' ";
            // result = DBHelper.ExecuteQuery<MedicineCabinetDetail>(sql);

            List<MedicineCabinetDetail> result = (from a in _eFCoreContext.MedicineCabinetDetails
                                                  join b in _eFCoreContext.MedicineCabinetInfos
                                                  on a.MedicineCabinetId equals b.ID
                                                  where b.Code == code
                                                  select a
                                                  ).ToList();
            //var meIds = _eFCoreContext.MedicineCabinetInfos.Where(x => x.Code == code).Select(x => x.ID).ToList();
            //List<MedicineCabinetDetail> result= _eFCoreContext.MedicineCabinetDetails
            //    .Where(x=> meIds.Contains(x.MedicineCabinetId)).AsNoTracking()
            //    .ToList();
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

        /// <summary>
        /// 获取所有厂家主信息
        /// </summary>
        /// <returns></returns>
        public List<ManufacturerInfo> GetManufacturerInfos()
        {
            return _eFCoreContext.ManufacturerInfos.Where(x=>x.IsDelete).ToList();
        }

        /// <summary>
        /// 获取所有厂家解析码信息
        /// </summary>
        /// <returns></returns>
        public List<ManufacturerResolutionCode> GetManufacturerCodes(int mid)
        {
            if (mid == 0)
            {
                var data = (from a in _eFCoreContext.ManufacturerResolutionCodes
                            join b in _eFCoreContext.ManufacturerInfos
                            on a.ManufacturerId equals b.ID
                            where b.IsDelete == false
                            select a).ToList();
                return data;
            }
            else 
            {
                var data = (from a in _eFCoreContext.ManufacturerResolutionCodes
                            join b in _eFCoreContext.ManufacturerInfos
                            on a.ManufacturerId equals b.ID
                            where b.IsDelete == false && a.ManufacturerId == mid
                            select a).ToList();
                return data;
            }
            
            
        }


        /// <summary>
        /// 获取处方信息
        /// </summary>
        /// <returns></returns>
        public (object,object) GetPrescription(int preType,string preId) 
        {
            object info=null;
            object details = null;
            switch (preType) 
            { 
                case 1:
                    info = _eFCoreContext.DataPrescriptions.FirstOrDefault(x => x.PrescriptionID == preId);
                    details = _eFCoreContext.DataPrescriptionDetails.Where(x => x.PrescriptionID == preId).ToList();
                    break;
                case 2:
                    info = _eFCoreContext.LocalDataPrescriptionInfos.FirstOrDefault(x => x.PrescriptionID == preId);
                    details = _eFCoreContext.LocalDataPrescriptionDetails.Where(x => x.PrescriptionID == preId).ToList();
                    break;
                case 3:
                    info = _eFCoreContext.LocalDataPrescriptionInfoRecords.FirstOrDefault(x => x.PrescriptionID == preId);
                    details = _eFCoreContext.LocalDataPrescriptionDetailRecords.Where(x => x.PrescriptionID == preId).ToList();
                    break;
            }

            return (info, details);
        }

        /// <summary>
        /// 根据rfid获取药柜详情数据
        /// </summary>
        /// <param name="rfid">rfid</param>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public MedicineCabinetDetail GetMedicineCabinetDetail(int rfid,string code)
        {
           return (from a in _eFCoreContext.MedicineCabinetDetails
                    join b in _eFCoreContext.MedicineCabinetInfos
                    on a.MedicineCabinetId equals b.ID
                    where b.Code == code && a.RFID == rfid
                    select a
                    ).FirstOrDefault();
        }
        /// <summary>
        /// 根据rfid获取颗粒字典数据
        /// </summary>
        /// <param name="rfid">rfid</param>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public ParticlesInfo GetParticlesInfo(int rfid, string code)
        {
            return (from a in _eFCoreContext.MedicineCabinetDetails
                    join b in _eFCoreContext.MedicineCabinetInfos
                    on a.MedicineCabinetId equals b.ID
                    join c in _eFCoreContext.ParticlesInfos
                    on a.ParticlesID equals c.ID
                    where b.Code == code && a.RFID == rfid
                    select c
                    ).FirstOrDefault();
        }
    }
}
