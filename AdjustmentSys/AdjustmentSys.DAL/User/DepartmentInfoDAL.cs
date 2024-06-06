using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdjustmentSys.Service
{
    public class DepartmentInfoDAL
    {
        private readonly EFCoreContext _eFCoreContext=new EFCoreContext();

        /// <summary>
        /// 新增或编辑医生科室
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDepartmentInfo(DepartmentInfo departmentInfo) 
        {
            string error = "";
            try
            {
                if (departmentInfo.ID != default(int))
                {
                    bool isExitDoctor = _eFCoreContext.DepartmentInfos.AsNoTracking().Any(x => x.DepartmentName == departmentInfo.DepartmentName && x.ID!= departmentInfo.ID);
                    if (isExitDoctor)
                    {
                        return "该科室名称已存在";
                    }

                    var doctor = _eFCoreContext.DepartmentInfos.AsNoTracking().FirstOrDefault(x => x.ID == departmentInfo.ID);
                    if (doctor == null) 
                    {
                        return "未找到要编辑的科室信息，请刷新后再试";
                    }
                    doctor.DepartmentName = departmentInfo.DepartmentName;
                    doctor.Address = departmentInfo.Address;
                    doctor.Contacts= departmentInfo.Contacts;
                    doctor.ContactsPhone= departmentInfo.ContactsPhone;               
                    doctor.Remark= departmentInfo.Remark;
                    doctor.UpdateTime= departmentInfo.UpdateTime;
                    doctor.UpdateBy= departmentInfo.UpdateBy;
                    doctor.UpdateName= departmentInfo.UpdateName;
                    //可省略
                    _eFCoreContext.DepartmentInfos.Update(doctor);
                }
                else
                {
                    bool isExitUser= _eFCoreContext.DepartmentInfos.AsNoTracking().Any(x => x.DepartmentName == departmentInfo.DepartmentName);
                    if (isExitUser) 
                    {
                        return "该科室名称已存在";
                    }
                    _eFCoreContext.DepartmentInfos.Add(departmentInfo);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0) {
                    error = (departmentInfo.ID>0?"编辑":"新增")+"科室信息失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error=e.Message;
            }

            return error;
        }

        /// <summary>
        /// 删除医生科室
        /// </summary>
        public string DeleteDepartmentInfo(int id)
        {
            var department = _eFCoreContext.DepartmentInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (department == null)
            {
                return "要删除的科室信息不存在，请刷新列表后再试";
            }
            var isUsed= _eFCoreContext.DoctorInfos.AsNoTracking().Any(x => x.DoctorDepartmentID == id && x.IsDelete==false);
            if (isUsed) 
            {
                return "该科室已经被医生绑定，不能直接删除";
            }

            _eFCoreContext.DepartmentInfos.Remove(department);
            int index=_eFCoreContext.SaveChanges();

            return index>0?"":"删除医生科室信息失败,请稍后再试";
        }

        /// <summary>
        /// 根据医生科室ID，获取医生科室信息
        /// </summary>
        /// <param name="id">医生科室id</param>
        /// <returns></returns>
        public DepartmentInfo GetDepartmentInfo(int id)
        {
            return _eFCoreContext.DepartmentInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 医生科室列表查询
        /// </summary>
        /// <param name="keywords">名称/联系人电话/联系人名称</param>
        /// <param name="isDelete">是否已删除</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<DepartmentPageListModel> GetDepartmentInfoByPage(string? keywords, int pageIndex,int pageSize,out int count) 
        {
            var where = _eFCoreContext.DepartmentInfos.AsNoTracking()
                .Where(dep=> 1==1);

            //关键字条件
            if (!String.IsNullOrEmpty(keywords))
            {
                where = where.Where(dep => (dep.DepartmentName.Contains(keywords) || dep.ContactsPhone.Contains(keywords) || dep.Contacts.Contains(keywords)));
            }
            //统计总记录数
            count = where.Count();
            if (count==0) {
                return null;
            }

            //结果按照创建时间倒序排序
            where = where.OrderByDescending(dep => dep.CreateTime);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            //获取结果，返回
            List<DepartmentPageListModel> resultList = new List<DepartmentPageListModel>();
            list.ForEach(item => {
                var model = new DepartmentPageListModel();
                model.ID = item.ID;
                model.DepartmentName= item.DepartmentName;
                model.Address= item.Address;
                model.Contacts = item.Contacts;
                model.ContactsPhone = item.ContactsPhone;
                model.Remark= item.Remark;
                model.CreateName = item.CreateName;
                model.CreateTime = item.CreateTime;
                model.UpdateName = item.UpdateName;
                model.UpdateTime = item.UpdateTime;
                resultList.Add(model);
            });

            return resultList;
        }

    }
}
