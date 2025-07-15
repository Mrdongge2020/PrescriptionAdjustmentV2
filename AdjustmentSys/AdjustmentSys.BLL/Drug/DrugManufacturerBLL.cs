using AdjustmentSys.DAL.Drug;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.User;
using AdjustmentSys.Service;
using AdjustmentSys.Tool.Enums;
using NPinyin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Drug
{
    public class DrugManufacturerBLL
    {
        DrugManufacturerDAL _drugManufacturerDAL = new DrugManufacturerDAL();
        /// <summary>
        /// 新增或编辑厂家
        /// </summary>
        /// <returns></returns>
        public string AddOrEditManufacturerInfo(ManufacturerInfo manInfo) 
        {
            if (manInfo.ID == 0)
            {//新增,加创建信息

                manInfo.CreateBy = SysLoginUser._currentUser.UserId;
                manInfo.CreateName = SysLoginUser._currentUser.UserName;
                manInfo.CreateTime = DateTime.Now;
                manInfo.DensityCoefficient = 1;
                manInfo.IsDelete = false;
            }
            manInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            manInfo.UpdateName = SysLoginUser._currentUser.UserName;
            manInfo.UpdateTime = DateTime.Now;
            return _drugManufacturerDAL.AddOrEditManufacturerInfo(manInfo);
        }

        /// <summary>
        /// 启用/禁用厂家
        /// </summary>
        public string DeleteManufacturerInfo(int id,bool isdelete) 
        { 
            return _drugManufacturerDAL.DeleteManufacturerInfo(id, isdelete);
        }

        /// <summary>
        /// 厂家列表查询
        /// </summary>
        /// <param name="keywords">名称/拼音码</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<ManufacturerPageListModel> GetManufacturerByPage(int pageIndex, int pageSize, out int count) 
        {
            return _drugManufacturerDAL.GetManufacturerByPage(pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 根据厂家id获取厂家解析码信息
        /// </summary>
        /// <param name="id">厂家id</param>
        /// <returns></returns>
        public List<ComboxModel> GetCodesByManufacturerId(int id)
        {
            return _drugManufacturerDAL.GetCodesByManufacturerId(id);
        }

        /// <summary>
        /// 根据厂家解析码id获取解析码数据
        /// </summary>
        /// <param name="id">厂家解析码id</param>
        /// <returns></returns>
        public ManufacturerResolutionCode GetCodesById(int id)
        {
            return _drugManufacturerDAL.GetCodesById(id);
        }

        /// <summary>
        /// 新增或编辑解析码
        /// </summary>
        /// <param name="code">解析码规则</param>
        /// <returns></returns>
        public string AddOrEditManufacturerResolutionCode(ManufacturerResolutionCode code)
        {
            if (code.ID == 0)
            {//新增,加创建信息

                code.CreateBy = SysLoginUser._currentUser.UserId;
                code.CreateName = SysLoginUser._currentUser.UserName;
                code.CreateTime = DateTime.Now;
            }
            code.UpdateBy = SysLoginUser._currentUser.UserId;
            code.UpdateName = SysLoginUser._currentUser.UserName;
            code.UpdateTime = DateTime.Now;
            return _drugManufacturerDAL.AddOrEditManufacturerResolutionCode(code);
        }

        /// <summary>
        /// 根据厂家条码规则分段获取数据
        /// </summary>
        public string RetBarcodeResult(BarcodeEnum section, string barcode, int startvalue, int length)
        {
            try
            {

                startvalue = startvalue - 1;
                if (barcode.Length < startvalue + 1)
                {
                    return "-1";
                }
                switch (section)
                {
                    case BarcodeEnum.Packaging://包装码
                        {
                            return barcode.Substring(startvalue, length);
                        }
                    case BarcodeEnum.PackagingType://包装类型
                        {
                            return barcode.Substring(startvalue, length);
                        }
                    case BarcodeEnum.BatchNumber://批号
                        {
                            return barcode.Substring(startvalue, length);
                        }
                    case BarcodeEnum.VaildUntil://有效期
                        {
                            // return "20" + barcode.Substring(startvalue, length);
                            if (length == 3)
                            {
                                int yeartime = DateTime.Now.Year;
                                int yeartime3 = yeartime / 10;
                                string timeStr = yeartime3.ToString() + barcode.Substring(startvalue, 1) + "-" +barcode.Substring(startvalue + 1, length - 1) + "-01";
                                DateTime VaildUntil = Convert.ToDateTime(timeStr);
                                if (VaildUntil.AddYears(3) < DateTime.Now)
                                {
                                    yeartime3 = yeartime3 + 1;
                                }
                                return yeartime3.ToString() + barcode.Substring(startvalue, length);
                            }
                            if (length == 10)
                            {
                                //获取生产日期
                                string yxqDate = barcode.Substring(startvalue, length);
                                if (string.IsNullOrEmpty(yxqDate))
                                {
                                    return "20" + barcode.Substring(startvalue, length);
                                }
                                if (yxqDate.Length == 10)
                                {
                                    string scDate = yxqDate.Substring(0, 4) + "-" + yxqDate.Substring(4, 2) + "-" + yxqDate.Substring(6, 2);
                                    if (DateTime.TryParse(scDate, out DateTime t))
                                    {
                                        int monthValue = int.Parse(yxqDate.Substring(8, 2));
                                        return t.AddMonths(monthValue).ToString("yyyy-MM-dd").Replace("-", "");
                                    }
                                    else
                                    {
                                        return "20" + barcode.Substring(startvalue, length);
                                    }
                                }
                            }
                            if (length == 9)
                            {
                                return barcode.Substring(startvalue, length);
                            }
                            return "20" + barcode.Substring(startvalue, length);
                        }
                    case BarcodeEnum.Equivalent://当量
                        {
                            if (startvalue == 0 || length == 0)
                            {
                                return "0";
                            }
                            if (length == 4)
                            {
                                return Math.Round((double)Convert.ToInt32(barcode.Substring(startvalue, length)) / 100, 3).ToString();
                            }
                            return Math.Round((double)Convert.ToInt32(barcode.Substring(startvalue, length)) / 10, 3).ToString();
                        }
                    case BarcodeEnum.Density://密度
                        {
                            if (length == 2)
                            {
                                return Math.Round((double)Convert.ToInt32(barcode.Substring(startvalue, length)) / 100, 3).ToString();
                            }
                            if (length == 3)
                            {
                                return Math.Round((double)Convert.ToInt32(barcode.Substring(startvalue, length)) / 100, 3).ToString();
                            }

                            return Math.Round((double)Convert.ToInt32(barcode.Substring(startvalue, length)) / 1000, 3).ToString();
                        }
                    case BarcodeEnum.LoadingCapacity://装量
                        {
                            if (length == 2)
                            {
                                return (Convert.ToInt32(barcode.Substring(startvalue, length)) * 10).ToString();
                            }
                            if (length == 4)
                            {
                                return (Convert.ToInt32(barcode.Substring(startvalue, length)) / 10).ToString();
                            }

                            if (length == 1)
                            {
                                if (Convert.ToInt32(barcode.Substring(startvalue, length)) < 5)
                                {
                                    return (Convert.ToInt32(barcode.Substring(startvalue, length)) * 100).ToString();
                                }
                                else
                                {
                                    return (Convert.ToInt32(barcode.Substring(startvalue, length)) * 10).ToString();
                                }
                            }
                            return barcode.Substring(startvalue, length);
                        }
                    default:
                        return "-1";
                }
            }
            catch (Exception e)
            {
                return "-2";
            }
        }
    }
}
