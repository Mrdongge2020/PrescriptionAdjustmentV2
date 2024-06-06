using AdjustmentSys.DAL.MedicineCabinet;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.MedicineCabinet
{
    public class MedicineCabinetInfoBLL
    {
        MedicineCabinetInfoDAL medicineCabinetInfoDAL = new MedicineCabinetInfoDAL();

        /// <summary>
        /// 新增或编辑药柜
        /// </summary>
        /// <returns></returns>
        public string AddOrEditCabinetInfo(MedicineCabinetInfo cabinetInfo)
        {
            return medicineCabinetInfoDAL.AddOrEditCabinetInfo(cabinetInfo);
        }

        /// <summary>
        /// 删除药柜
        /// </summary>
        public string DeleteCabinetInfo(int id)
        {
            
            return medicineCabinetInfoDAL.DeleteCabinetInfo(id);
        }

        /// <summary>
        /// 根据药柜ID，获取药柜信息
        /// </summary>
        /// <param name="id">药柜id</param>
        /// <returns></returns>
        public MedicineCabinetInfo GetCabinetInfo(int id)
        {
            return medicineCabinetInfoDAL.GetCabinetInfo(id);
        }

        /// <summary>
        ///获取药柜列表
        /// </summary>
        /// <returns></returns>
        public List<MedicineCabinetListModel> GetCabinetInfoList()
        {
            return medicineCabinetInfoDAL.GetCabinetInfoList();
        }
    }
}
