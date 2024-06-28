using AdjustmentSys.DAL.Common;
using AdjustmentSys.Models.CommModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Common
{
    public class ComboxDataBLL
    {

        private readonly ComboxDataDAL comboxDataDAL = new ComboxDataDAL();
        /// <summary>
        /// 获取权限等级下拉数据
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetUserLevelComboxData()
        {
            return comboxDataDAL.GetUserLevelComboxData();
        }

        /// <summary>
        /// 获取医生科室下拉列表
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetDoctorDepartmentComboxData() 
        {
            return comboxDataDAL.GetDoctorDepartmentComboxData();
        }

        /// <summary>
        /// 获取厂家信息下拉数据
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetManufacturerComboxData() 
        {
            return comboxDataDAL.GetManufacturerComboxData();
        }

        /// <summary>
        /// 药品下拉列表数据集
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetParticlesInfoComboxData() 
        {
            return comboxDataDAL.GetParticlesInfoComboxData();
        }

        /// <summary>
        /// 药品下拉列表数据集,药柜
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetCabinetParticlesComboxData(string code)
        {
            return comboxDataDAL.GetCabinetParticlesComboxData(code);
        }
    }
}
