using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
using NPinyin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.User
{
    public class DoctorInfoBLL
    {
        DoctorInfoDAL doctorInfoDAL = new DoctorInfoDAL();
        /// <summary>
        /// 新增或编辑医生
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDoctorInfo(DoctorInfo doctorInfo)
        {
            if (doctorInfo.ID == 0)
            {//新增,加创建信息

                doctorInfo.CreateBy = SysLoginUser._currentUser.UserId;
                doctorInfo.CreateName = SysLoginUser._currentUser.UserName;
                doctorInfo.CreateTime = DateTime.Now;
            }
            doctorInfo.InitialPinyin =Pinyin.GetInitials(doctorInfo.DoctorName);
            doctorInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            doctorInfo.UpdateName = SysLoginUser._currentUser.UserName;
            doctorInfo.UpdateTime = DateTime.Now;
            return doctorInfoDAL.AddOrEditDoctorInfo(doctorInfo);
        }

        /// <summary>
        /// 删除医生
        /// </summary>
        public string DeleteDoctorInfo(int id)
        {
            return doctorInfoDAL.DeleteDoctorInfo(id);
        }

        /// <summary>
        /// 根据医生ID，获取医生信息
        /// </summary>
        /// <param name="id">医生id</param>
        /// <returns></returns>
        public DoctorInfo GetDoctorInfo(int id)
        {
            return doctorInfoDAL.GetDoctorInfo(id);
        }

        /// <summary>
        /// 医生列表查询
        /// </summary>
        /// <param name="keywords">名称/电话/拼音码</param>
        /// <param name="doctorDepartmentID">科室id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<DoctorPageListModel> GetDoctorInfoByPage(string? keywords, int? doctorDepartmentID, int pageIndex, int pageSize, out int count) 
        {
            return doctorInfoDAL.GetDoctorInfoByPage(keywords,doctorDepartmentID,pageIndex,pageSize,out count);
        }
    }
}
