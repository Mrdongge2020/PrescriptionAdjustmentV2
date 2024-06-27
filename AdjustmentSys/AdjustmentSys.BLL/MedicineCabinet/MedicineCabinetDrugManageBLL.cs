using AdjustmentSys.DAL.MedicineCabinet;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
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
    }
}
