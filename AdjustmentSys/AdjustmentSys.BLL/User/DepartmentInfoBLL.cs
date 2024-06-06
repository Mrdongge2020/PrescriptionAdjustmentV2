using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.User
{
    public class DepartmentInfoBLL
    {
        DepartmentInfoDAL _departmentInfo = new DepartmentInfoDAL();

        /// <summary>
        /// 新增或编辑医生科室
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDepartmentInfo(DepartmentInfo departmentInfo)
        {
            if (departmentInfo.ID == 0)
            {//新增,加创建信息

                departmentInfo.CreateBy = SysLoginUser._currentUser.UserId;
                departmentInfo.CreateName = SysLoginUser._currentUser.UserName;
                departmentInfo.CreateTime = DateTime.Now;
            }

            departmentInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            departmentInfo.UpdateName = SysLoginUser._currentUser.UserName;
            departmentInfo.UpdateTime = DateTime.Now;
            return _departmentInfo.AddOrEditDepartmentInfo(departmentInfo);
        }

        /// <summary>
        /// 删除医生科室
        /// </summary>
        public string DeleteDepartmentInfo(int id)
        {
            return _departmentInfo.DeleteDepartmentInfo(id);
        }

        /// <summary>
        /// 根据医生科室ID，获取医生科室信息
        /// </summary>
        /// <param name="id">医生科室id</param>
        /// <returns></returns>
        public DepartmentInfo GetDepartmentInfo(int id)
        {
            return _departmentInfo.GetDepartmentInfo(id);
        }

        /// <summary>
        /// 医生科室列表查询
        /// </summary>
        /// <param name="keywords">名称/联系人电话/联系人名称</param>
        /// <param name="isDelete">是否已删除</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<DepartmentPageListModel> GetDepartmentInfoByPage(string? keywords, int pageIndex, int pageSize, out int count) 
        {
            return _departmentInfo.GetDepartmentInfoByPage(keywords,pageIndex,pageSize,out count);
        }
    }
}
