using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.MedicineCabinet;
using AdjustmentSys.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdjustmentSys.DAL.MedicineCabinet
{
    public class MedicineCabinetInfoDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 新增或编辑药柜
        /// </summary>
        /// <returns></returns>
        public string AddOrEditCabinetInfo(MedicineCabinetInfo cabinetInfo)
        {
            string error = "";
            try
            {
                if (cabinetInfo.ID != default(int))
                {
                    error=EditCabinetInfo(cabinetInfo);
                }
                else
                {                  
                    error = AddCabinetInfo(cabinetInfo);
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }

        /// <summary>
        /// 新增药柜
        /// </summary>
        private string AddCabinetInfo(MedicineCabinetInfo cabinetInfo) 
        {
            string error = "";
            bool isExitcabinet = _eFCoreContext.MedicineCabinetInfos.Any(x => x.Name == cabinetInfo.Name);
            if (isExitcabinet)
            {
                return "该药柜名称已存在";
            }

            //获取药柜组最大纵坐标
            int maxYindex=0;
            List<int> mIds=_eFCoreContext.MedicineCabinetInfos.Where(x => x.Code==cabinetInfo.Code).Select(x=>x.ID).ToList();
            if (mIds!=null && mIds.Count>0) 
            {
                maxYindex = _eFCoreContext.MedicineCabinetDetails.Max(x=>x.CoordinateY);
            }
            List<MedicineCabinetDetail> detailList = new List<MedicineCabinetDetail>();
            int indexX = 1;int indexY = maxYindex + 1;
            for (int i = 0;i<cabinetInfo.RowCount*cabinetInfo.ColCount;i++) 
            {
                if (indexX > 14) { indexX = 1; indexY = indexY + 1; }
                MedicineCabinetDetail detail = new MedicineCabinetDetail();
                detail.MedicineCabinetId = 0;
                detail.CoordinateX= indexX;
                detail.CoordinateY = indexY;
                detail.CreateBy = SysLoginUser._currentUser.UserId;
                detail.CreateName = SysLoginUser._currentUser.UserName;
                detail.CreateTime = DateTime.Now;
                detailList.Add(detail);
                indexX++;
            }

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    //插入药柜主表信息
                    _eFCoreContext.MedicineCabinetInfos.Add(cabinetInfo);
                    _eFCoreContext.SaveChanges();
                    //获取主表id插入详情表
                    foreach (var item in detailList)
                    {
                        item.MedicineCabinetId = cabinetInfo.ID;
                    }
                    //插入药柜详情信息
                    _eFCoreContext.MedicineCabinetDetails.AddRange(detailList);

                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    error = "新增药柜信息失败,请稍后再试";
                }
            }
            return error;
        }
        /// <summary>
        ///编辑药柜
        /// </summary>
        /// <param name="cabinetInfo"></param>
        /// <returns></returns>
        private string EditCabinetInfo(MedicineCabinetInfo cabinetInfo)
        {
            bool isExitcabinet = _eFCoreContext.MedicineCabinetInfos.Any(x => x.Name == cabinetInfo.Name && x.ID != cabinetInfo.ID);
            if (isExitcabinet)
            {
                return "该药柜名称已存在";
            }

            var cabinet = _eFCoreContext.MedicineCabinetInfos.FirstOrDefault(x => x.ID == cabinetInfo.ID);
            if (cabinet == null)
            {
                return "未找到要编辑的药柜信息，请刷新后再试";
            }

            string error = "";

            cabinet.Name = cabinetInfo.Name;
            cabinet.Code = cabinetInfo.Code;
            cabinet.Remark = cabinetInfo.Remark;

            //可省略
            _eFCoreContext.MedicineCabinetInfos.Update(cabinet);

            var result = _eFCoreContext.SaveChanges();
            if (result <= 0)
            {
                error = "编辑药柜信息失败，请稍后再试。";
            }
            return error;
        }

        /// <summary>
        /// 删除药柜
        /// </summary>
        public string DeleteCabinetInfo(int id)
        {
            string errorMsg = "";
            var cabinet = _eFCoreContext.MedicineCabinetInfos.FirstOrDefault(x => x.ID == id);
            if (cabinet==null) 
            {
                return "要删除的药柜数据不存在,请刷新后再试";
            }
            //获取相同药柜编组最后创建的药柜
            var lastCreateCabinet = _eFCoreContext.MedicineCabinetInfos.Where(x=>x.Code==cabinet.Code).OrderByDescending(x => x.ID).FirstOrDefault();
            if (lastCreateCabinet.ID != id) 
            {
                return "药柜删除只能相同编组中，创建时间从后往前依次删除，请先删除("+ cabinet.Code + ")编组中后创建的药柜("+ lastCreateCabinet .Name+ ")";
            }
            //是否存在与需要删除的相同编号的药柜
            var isExit = _eFCoreContext.MedicineCabinetInfos.Any(x => x.Code == cabinet.Code && x.ID != id);

            using (var dbContextTransaction = _eFCoreContext.Database.BeginTransaction())
            {
                try
                {
                    //删除药柜表
                    _eFCoreContext.MedicineCabinetInfos.Where(x => x.ID == id).ExecuteDelete();
                    if (!isExit) 
                    {
                        //删除药柜与药柜组的关联关系
                        _eFCoreContext.DeviceMedicineCabinetCodeRelations.Where(x => x.MedicineCabinetCode == cabinet.Code).ExecuteDelete();
                    }
                   
                    //删除药柜的其他初始化信息？
                    _eFCoreContext.MedicineCabinetDetails.Where(x => x.MedicineCabinetId == id).ExecuteDelete();

                    _eFCoreContext.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    errorMsg = "删除药柜信息失败,请稍后再试";
                }
            }

            return errorMsg;
        }

        /// <summary>
        /// 根据药柜ID，获取药柜信息
        /// </summary>
        /// <param name="id">药柜id</param>
        /// <returns></returns>
        public MedicineCabinetInfo GetCabinetInfo(int id)
        {
            return _eFCoreContext.MedicineCabinetInfos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        ///获取药柜列表
        /// </summary>
        /// <returns></returns>
        public List<MedicineCabinetListModel> GetCabinetInfoList()
        {
            return _eFCoreContext.MedicineCabinetInfos.OrderBy(x => x.Code).ThenBy(x => x.ID)
                .Select(x => new MedicineCabinetListModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Code = x.Code,
                    Specifications = (x.Specifications.HasValue ? (x.Specifications == 1 ? "大药柜" : "小药柜") : ""),
                    ColCount = x.ColCount,
                    RowCount = x.RowCount,
                    Remark =x.Remark
                }).ToList();
        }

       
    }
}
