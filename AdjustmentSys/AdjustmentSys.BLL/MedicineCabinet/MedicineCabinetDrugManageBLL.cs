using AdjustmentSys.BLL.Common;
using AdjustmentSys.DAL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Machine;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using AdjustmentSys.Tool.Enums;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.MedicineCabinet
{
    public class MedicineCabinetDrugManageBLL
    {
        MedicineCabinetDrugManageDAL medicineCabinetDrugManageDAL = new MedicineCabinetDrugManageDAL();
        /// <summary>
        /// 根据分组编号获取药柜药品信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MedicineCabinetDetailListModel> GetCabinetDrugDetails(string code)
        {
            return medicineCabinetDrugManageDAL.GetCabinetDrugDetails(code);
        }

        /// <summary>
        /// 根据分组编号获取药柜信息
        /// </summary>
        /// <param name="code">分组code</param>
        /// <returns></returns>
        public List<MedicineCabinetInfo> GetCabinets(string code) 
        { 
            return medicineCabinetDrugManageDAL.GetCabinets(code);
        }


        /// <summary>
        /// 上架颗粒
        /// </summary>
        /// <param name="id">药柜id</param>
        /// <param name="code">药柜编号param>
        /// <param name="parId">颗粒id</param>
        public string ListingParticle(int id, string code, int parId)
        { 
            return medicineCabinetDrugManageDAL.ListingParticle(id, code, parId);
        }

        /// <summary>
        /// 下架颗粒
        /// </summary>
        /// <param name="id">药柜id</param>
        public string RemoveParticle(int id) 
        {
            return medicineCabinetDrugManageDAL.RemoveParticle(id);
        }

        /// <summary>
        /// 获取颗粒有效期列表
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<MedicineCabinetValidityModel> GetMedicineCabinetValidity(DateTime sdateTime, DateTime edateTime)
        { 
            return medicineCabinetDrugManageDAL.GetMedicineCabinetValidity(sdateTime,edateTime);
        }

        /// <summary>
        /// 修改药柜药品有效期
        /// </summary>
        /// <param name="particleId">颗粒id</param>
        /// <param name="validityDateTime">效期至</param>
        /// <returns></returns>
        public bool UpdateValidity(int? particleId, DateTime validityDateTime) 
        { 
            return medicineCabinetDrugManageDAL.UpdateValidity(particleId, validityDateTime);
        }

        /// <summary>
        /// 获取颗粒位置导出信息
        /// </summary>
        /// <returns></returns>
        public List<ParticlesPositionExcelModel> GetParticlesPosition()
        {
           return medicineCabinetDrugManageDAL.GetParticlesPosition();
        }

        /// <summary>
        /// 获取颗粒库存导出信息
        /// </summary>
        /// <returns></returns>
        public List<ParticlesStockExcelModel> GetParticlesStock() 
        {
            return medicineCabinetDrugManageDAL.GetParticlesStock();
        }

        /// <summary>
        /// 导入颗粒位置
        /// </summary>
        /// <returns></returns>
        public string ImportParticlesPositions(List<ParticlesPositionExcelModel> particlesPositionExcelModels) 
        {
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            var allParticles = commonDataBLL.GetCommonParticles();
            var allMedicineCabinetDetails = commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            List<MedicineCabinetDetail> updateMedicineCabinetDetails = new List<MedicineCabinetDetail>();
            foreach (var item in particlesPositionExcelModels)
            {
                //根据位置找到药柜详情
                MedicineCabinetDetail medicineCabinetDetail = allMedicineCabinetDetails.FirstOrDefault(x=>x.MedicineCabinetId==item.MedicineCabinetId && x.CoordinateX==item.CoordinateX && x.CoordinateY==item.CoordinateY);
                if (medicineCabinetDetail==null) 
                {
                    continue;
                }
                //获取当前位置要导入的颗粒id
                int? pid = allParticles.FirstOrDefault(x => x.Code == item.Code)?.ID;
                if (!pid.HasValue)
                {
                    pid=0;
                }
                //要导入的颗粒旧的药柜数据
                var oldData = allMedicineCabinetDetails.FirstOrDefault(x => x.MedicineCabinetId == item.MedicineCabinetId && x.ParticlesID == pid.Value);
                
                medicineCabinetDetail.Stock= oldData!=null?oldData.Stock:null;
                medicineCabinetDetail.ValidityTime= oldData != null ? oldData.ValidityTime : null;
                medicineCabinetDetail.BatchNumber= oldData != null ? oldData.BatchNumber : null;
                medicineCabinetDetail.BottleHeadAdjustAmount= oldData != null ? oldData.BottleHeadAdjustAmount : null;
                medicineCabinetDetail.TotalErrorAmount= oldData != null ? oldData.TotalErrorAmount : null;
                medicineCabinetDetail.TotalUsedAmount= oldData != null ? oldData.TotalUsedAmount : null;
                medicineCabinetDetail.CurentAdjustAmount= oldData != null ? oldData.CurentAdjustAmount : null;
                medicineCabinetDetail.LastWeightAmount= oldData != null ? oldData.LastWeightAmount : null;
                medicineCabinetDetail.EmptyBottleWeight= oldData != null ? oldData.EmptyBottleWeight : null;
                medicineCabinetDetail.DensityCoefficient= oldData != null ? oldData.DensityCoefficient : null;
                medicineCabinetDetail.RFID= oldData != null ? oldData.RFID:null;
                
                //绑定颗粒
                medicineCabinetDetail.ParticlesID = pid.Value;

                updateMedicineCabinetDetails.Add(medicineCabinetDetail);
            }

            if (!updateMedicineCabinetDetails.Any()) 
            {
                return "";
            }
            //批量更新
            return  medicineCabinetDrugManageDAL.UpdateRangeCabinetDetails(updateMedicineCabinetDetails);
        }

        /// <summary>
        /// 导入颗粒库存
        /// </summary>
        /// <returns></returns>
        public string ImportParticlesStocks(List<ParticlesStockExcelModel> particlesStockExcelModels)
        {
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            var allParticles = commonDataBLL.GetCommonParticles();
            var allMedicineCabinetDetails = commonDataBLL.GetMedicineCabinetDetails(SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
            List<MedicineCabinetDetail> updateMedicineCabinetDetails = new List<MedicineCabinetDetail>();
            foreach (var item in particlesStockExcelModels)
            {
                //根据位置找到药柜详情
                MedicineCabinetDetail medicineCabinetDetail = allMedicineCabinetDetails.FirstOrDefault(x => x.MedicineCabinetId == item.MedicineCabinetId && x.ParticlesID==item.ParticlesID);
                if (medicineCabinetDetail == null)
                {
                    continue;
                }
                medicineCabinetDetail.Stock = item.Stock;
                updateMedicineCabinetDetails.Add(medicineCabinetDetail);
            }

            if (!updateMedicineCabinetDetails.Any())
            {
                return "";
            }
            //批量更新
            return medicineCabinetDrugManageDAL.UpdateRangeCabinetDetails(updateMedicineCabinetDetails);
        }

        /// <summary>
        /// 添加颗粒库存
        /// </summary>
        /// <param name="par">颗粒</param>
        /// <param name="med">药柜</param>
        /// <param name="mcol">药柜颗粒操作记录</param>
        /// <returns></returns>
        public string AddParticleNum(ParticlesInfo par,MedicineCabinetDetail med, MedicineCabinetOperationLogInfo mcol) 
        {
            return medicineCabinetDrugManageDAL.AddParticleNum(par,med,mcol);
        }

        /// <summary>
        ///获取药柜详情信息
        /// </summary>
        /// <param name="id">id主键</param>
        /// <returns></returns>
        public MedicineCabinetDetail GetMedicineCabinetDetail(int id)
        {
            return medicineCabinetDrugManageDAL.GetMedicineCabinetDetail(id);
        }

        /// <summary>
        /// 获取药柜颗粒操作日志分页列表
        /// </summary>
        public MedicineCabinetOperationLogByPage GetMedicineCabinetOperationLogByPage(int? type, string parName, DateTime? sdate, DateTime? edate, int pageIndex, int pageSize, out int count)
        { 
            return medicineCabinetDrugManageDAL.GetMedicineCabinetOperationLogByPage(type, parName, sdate, edate, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获取药品使用统计数据
        /// </summary>
        public List<ParticleUsedStatistics> GetParticleUsedStatistics(string name, DateTime? stime, DateTime? etime) 
        {
            return medicineCabinetDrugManageDAL.GetParticleUsedStatistics(name, stime, etime);
        }
    }
}
