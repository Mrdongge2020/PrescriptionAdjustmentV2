using AdjustmentSys.EFCore;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.PublicModel;
using AdjustmentSys.Tool;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Common
{
    /// <summary>
    /// 下拉框数据获取
    /// </summary>
    public class ComboxDataDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 获取权限等级下拉数据
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetUserLevelComboxData()
        {
            List<ComboxModel> result = _eFCoreContext.LevelInfos.AsNoTracking().OrderBy(x => x.ID)
                .Select(x => new ComboxModel() { Id = x.ID, Name = x.LevelName })
                .ToList();
            return result;
        }

        /// <summary>
        /// 获取医生科室下拉列表
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetDoctorDepartmentComboxData()
        {
            List<ComboxModel> result = _eFCoreContext.DepartmentInfos.AsNoTracking().OrderBy(x => x.ID)
                .Select(x => new ComboxModel() { Id = x.ID, Name = x.DepartmentName })
                .ToList();
            return result;
        }

        /// <summary>
        /// 获取厂家信息下拉数据
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetManufacturerComboxData()
        {
            List<ComboxModel> result = _eFCoreContext.ManufacturerInfos.AsNoTracking().Where(x=>!x.IsDelete).OrderBy(x => x.ID)
                .Select(x => new ComboxModel() { Id = x.ID, Name = x.Name })
                .ToList();
            return result;
        }

        /// <summary>
        /// 药品下拉列表数据集,字典
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetParticlesInfoComboxData()
        {
            List<ComboxModel> result = new List<ComboxModel>();
            
            result = _eFCoreContext.ParticlesInfos.AsNoTracking().OrderBy(x => x.NameSimplifiedPinyin)
            .Select(x => new ComboxModel() { Id = x.ID, Name = x.Name+"(" + x.NameSimplifiedPinyin + ")" })
            .ToList(); 

            return result;
        }

        /// <summary>
        /// 获取医生下拉数据
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetDoctorComboxData()
        {
            List<ComboxModel> result = _eFCoreContext.DoctorInfos.AsNoTracking().OrderBy(x => x.ID)
                .Select(x => new ComboxModel() { Id = x.ID, Name = x.DoctorName })
                .ToList();
            return result;
        }
        /// <summary>
        /// 药品下拉列表数据集,药柜
        /// </summary>
        /// <returns></returns>
        public List<ComboxModel> GetCabinetParticlesComboxData()
        {
            List<ComboxModel> result = new List<ComboxModel>();
            string sql = $@" select a.ParticlesID as Id,c.Name+'('+c.NameSimplifiedPinyin+')' as Name 
                             from MedicineCabinetDetail as a
                             left join MedicineCabinetInfo as b on a.MedicineCabinetId=b.ID
                             left join ParticlesInfo as c  on a.ParticlesID=c.ID
                             where  b.Code='{SysDeviceInfo.currentDeviceInfo.MedicineCabinetCode}' and   a.ParticlesID is not null and a.ParticlesID>0
                             order by c.ID ";
            result = DBHelper.ExecuteQuery<ComboxModel>(sql);
            return result;
        }

    }
}
