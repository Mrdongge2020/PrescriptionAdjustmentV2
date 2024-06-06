using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.User;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdjustmentSys.Service
{
    public class DoctorInfoDAL
    {
        private readonly EFCoreContext _eFCoreContext=new EFCoreContext();

        /// <summary>
        /// 新增或编辑医生
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDoctorInfo(DoctorInfo doctorInfo) 
        {
            string error = "";
            try
            {
                if (doctorInfo.ID != default(int))
                {
                    bool isExitDoctor = _eFCoreContext.DoctorInfos.AsNoTracking().Any(x => x.DoctorName == doctorInfo.DoctorName && x.ID!= doctorInfo.ID);
                    if (isExitDoctor)
                    {
                        return "该医生名称已存在";
                    }

                    var doctor = _eFCoreContext.DoctorInfos.AsNoTracking().FirstOrDefault(x => x.ID == doctorInfo.ID);
                    if (doctor == null) 
                    {
                        return "未找到要编辑的医生信息，请刷新后再试";
                    }
                    doctor.DoctorName = doctorInfo.DoctorName;
                    doctor.InitialPinyin = doctorInfo.InitialPinyin;
                    doctor.DoctorDepartmentID= doctorInfo.DoctorDepartmentID;
                    doctor.DoctorDepartmentName = doctorInfo.DoctorDepartmentName;
                    doctor.EMail= doctorInfo.EMail;               
                    doctor.Phone= doctorInfo.Phone;
                    doctor.Office= doctorInfo.Office;
                    doctor.Remark= doctorInfo.Remark;
                    doctor.UpdateTime= doctorInfo.UpdateTime;
                    doctor.UpdateBy= doctorInfo.UpdateBy;
                    doctor.UpdateName= doctorInfo.UpdateName;
                    //可省略
                    _eFCoreContext.DoctorInfos.Update(doctor);
                }
                else
                {
                    bool isExitUser= _eFCoreContext.DoctorInfos.AsNoTracking().Any(x => x.DoctorName == doctorInfo.DoctorName);
                    if (isExitUser) 
                    {
                        return "该医生名称已存在";
                    }
                    _eFCoreContext.DoctorInfos.Add(doctorInfo);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0) {
                    error = (doctorInfo.ID>0?"编辑":"新增")+"医生信息失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error=e.Message;
            }

            return error;
        }

        /// <summary>
        /// 删除医生
        /// </summary>
        public string DeleteDoctorInfo(int id)
        {
            var doctor = _eFCoreContext.DoctorInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (doctor == null)
            {
                return "要删除的医生信息不存在，请刷新列表后再试";
            }
            doctor.IsDelete = true;
            doctor.DeleteName = SysLoginUser._currentUser.UserName;
            doctor.DeleteBy = SysLoginUser._currentUser.UserId;
            doctor.DeleteTime=DateTime.Now;
            _eFCoreContext.DoctorInfos.Update(doctor);
            int index=_eFCoreContext.SaveChanges();

            return index>0?"":"删除医生信息失败,请稍后再试";
        }

        /// <summary>
        /// 根据医生ID，获取医生信息
        /// </summary>
        /// <param name="id">医生id</param>
        /// <returns></returns>
        public DoctorInfo GetDoctorInfo(int id)
        {
            return _eFCoreContext.DoctorInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 医生列表查询
        /// </summary>
        /// <param name="keywords">名称/电话/拼音码</param>
        /// <param name="doctorDepartmentID">科室id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<DoctorPageListModel> GetDoctorInfoByPage(string? keywords,int? doctorDepartmentID, int pageIndex,int pageSize,out int count) 
        {
            var where = _eFCoreContext.DoctorInfos.AsNoTracking()
                .Where(doc=> !doc.IsDelete);

            //关键字条件
            if (!String.IsNullOrEmpty(keywords))
            {
                where = where.Where(doc => (doc.DoctorName.Contains(keywords) || doc.Phone.Contains(keywords) || doc.InitialPinyin.Contains(keywords)));
            }

            //doctorDepartmentID条件
            if (doctorDepartmentID.HasValue)
            {
                where = where.Where(doc => doc.DoctorDepartmentID == doctorDepartmentID);
            }
            
            //统计总记录数
            count = where.Count();
            if (count==0) {
                return null;
            }

            //结果按照创建时间倒序排序
            where = where.OrderByDescending(doc => doc.CreateTime);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            //获取结果，返回
            List<DoctorPageListModel> resultList = new List<DoctorPageListModel>();
            list.ForEach(item => {
                var model = new DoctorPageListModel();
                model.ID = item.ID;
                model.DoctorName= item.DoctorName;
                model.InitialPinyin= item.InitialPinyin;
                model.DoctorDepartmentName = item.DoctorDepartmentName;
                model.Phone = item.Phone;
                model.Office= item.Office;
                model.Remark= item.Remark;
                model.EMail= item.EMail;
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
