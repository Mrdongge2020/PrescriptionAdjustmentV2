using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.MedicineCabinet
{
    /// <summary>
    /// 药柜管理数据库操作
    /// </summary>
    public class MedicineCabinetDrugManageDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();
        /// <summary>
        /// 根据分组编号获取药柜药品信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MedicineCabinetDetailListModel> GetCabinetDrugDetails(string code)
        {
            string sql = $@" SELECT
			                        a.ID,
			                        a.MedicineCabinetId,
			                        a.CoordinateX,
			                        a.CoordinateY,
			                        a.ParticlesID,
			                        c.Name AS ParticlesName,
			                        a.ValidityTime,
			                        a.Stock,
									a.DensityCoefficient,
			                        a.RFID 
                             FROM MedicineCabinetDetail AS a
                             JOIN MedicineCabinetInfo AS b ON a.MedicineCabinetId= b.ID
                             LEFT JOIN ParticlesInfo AS c ON a.ParticlesID= c.ID 
                             WHERE b.Code= '{code}'";
            var datails=DBHelper.ExecuteQuery<MedicineCabinetDetailListModel>(sql);
            return datails;
        }

        /// <summary>
        /// 根据分组编号获取药柜信息
        /// </summary>
        /// <param name="code">分组code</param>
        /// <returns></returns>
        public List<MedicineCabinetInfo> GetCabinets(string code)
        {
           return   _eFCoreContext.MedicineCabinetInfos.Where(x => x.Code == code).OrderBy(x=>x.ID).ToList();
        }

        /// <summary>
        /// 上架颗粒
        /// </summary>
        /// <param name="id">药柜id</param>
        /// <param name="code">药柜编号param>
        /// <param name="parId">颗粒id</param>
        public string ListingParticle(int id, string code, int parId)
        {
            //var meIds = _eFCoreContext.MedicineCabinetInfos.Where(x => x.Code == code).Select(x => x.ID).ToList();
            //if (_eFCoreContext.MedicineCabinetDetails.Any(x => meIds.Contains(x.MedicineCabinetId) && x.ParticlesID == parId))
            //{
            //    return "药柜已上架该颗粒了";
            //}
            var detail = _eFCoreContext.MedicineCabinetDetails.FirstOrDefault(x => x.ID == id);
            if (detail == null)
            {
                return "药柜信息不存在了";
            }
            detail.ParticlesID = parId;
            detail.DensityCoefficient = 1;
            detail.Stock = 0;
            detail.RFID = parId;
            _eFCoreContext.MedicineCabinetDetails.Update(detail);
            int index= _eFCoreContext.SaveChanges();
            return index > 0 ? "" : "上架颗粒失败，请稍后再试";
        }

        /// <summary>
        /// 下架颗粒
        /// </summary>
        /// <param name="id">药柜id</param>
        public string RemoveParticle(int id)
        {
            var detail = _eFCoreContext.MedicineCabinetDetails.FirstOrDefault(x => x.ID == id);
            if (detail == null)
            {
                return "药柜信息不存在了";
            }
            detail.ParticlesID = null;
            _eFCoreContext.MedicineCabinetDetails.Update(detail);
            int index = _eFCoreContext.SaveChanges();
            return index > 0 ? "" : "下架颗粒失败，请稍后再试";
        }

    }
}
