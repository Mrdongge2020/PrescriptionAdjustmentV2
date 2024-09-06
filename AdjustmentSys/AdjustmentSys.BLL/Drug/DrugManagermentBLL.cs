﻿using AdjustmentSys.BLL.Common;
using AdjustmentSys.DAL.Drug;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using NPinyin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AdjustmentSys.BLL.Drug
{
    /// <summary>
    /// 药品管理业务逻辑类
    /// </summary>
    public class DrugManagermentBLL
    {
        DrugManagermentDAL drugManagermentDAL = new DrugManagermentDAL();
        /// <summary>
        /// 新增或编辑药品
        /// </summary>
        /// <returns></returns>
        public string AddOrEditDrugInfo(ParticlesInfoEditModel drugInfo)
        {
            drugInfo.NameFullPinyin = string.IsNullOrEmpty(drugInfo.NameFullPinyin)? Pinyin.GetPinyin(drugInfo.Name):drugInfo.NameFullPinyin;
            drugInfo.NameSimplifiedPinyin = string.IsNullOrEmpty(drugInfo.NameSimplifiedPinyin) ? Pinyin.GetInitials(drugInfo.Name):drugInfo.NameSimplifiedPinyin;
            
            return drugManagermentDAL.AddOrEditDrugInfo(drugInfo);
        }

        /// <summary>
        /// 删除药品
        /// </summary>
        public string DeleteDrugInfo(int id)
        {           
            return drugManagermentDAL.DeleteDrugInfo(id);
        }

        /// <summary>
        /// 根据药品ID，获取药品信息
        /// </summary>
        /// <param name="id">药品id</param>
        /// <returns></returns>
        public ParticlesInfoEditModel GetDrugInfo(int id)
        {
            return drugManagermentDAL.GetDrugInfo(id);
        }

        /// <summary>
        /// 药品列表查询
        /// </summary>
        /// <param name="keywords">名称/拼音码</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<ParticlesPageListModel> GetDrugInfoByPage(string? keywords, int pageIndex, int pageSize, out int count)
        {
            return drugManagermentDAL.GetDrugInfoByPage(keywords,pageIndex,pageSize,out count);
        }

        /// <summary>
        /// 根据厂家id和解析码获取解析数据
        /// </summary>
        /// <param name="code">解析码</param>
        /// <param name="manufacturerId">厂家id</param>
        /// <returns></returns>
        public ManufacturerRuleResultModel GetManufacturerRuleResult(string code,int manufacturerId) 
        {
            var codes = drugManagermentDAL.GetManufacturerCodes(manufacturerId);
            if (codes==null || codes.Count<=0) 
            {
                return null;
            }
            //只有一条直接解析完成返回
            if (codes.Count==1) 
            {
                return GetAnalysisResult(codes[0], code);
            }

            //多个规则，优先解析长度相等的规则
            var lengthEquelsRule = codes.FirstOrDefault(x => x.ExampleCode.Length == code.Length);
            int lengthEquelsRuleId = 0;
            if (lengthEquelsRule!=null) 
            {
                var result= GetAnalysisResult(lengthEquelsRule,code);
                if (result!=null)
                {
                    return result;
                }
                lengthEquelsRuleId = lengthEquelsRule.ID;
            }

            //排除长度相等的那一条,再循环读取
            codes = codes.Where(x => x.ID != lengthEquelsRuleId).ToList();
            foreach (var item in codes)
            {
                var result = GetAnalysisResult(item, code);
                if (result != null)
                {
                    return result;
                }
            }

            //读取完了还没解析成功，返回null
            return null;
        }

        /// <summary>
        /// 获取解析结果
        /// </summary>
        /// <param name="code">编码规则</param>
        /// <returns></returns>
        private ManufacturerRuleResultModel GetAnalysisResult(ManufacturerResolutionCode code,string codeStr) 
        {
            DrugManufacturerBLL drugManufacturerBLL = new DrugManufacturerBLL();
            ManufacturerRuleResultModel resultModel = new ManufacturerRuleResultModel();

            resultModel.PackageNumber = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Packaging, codeStr, code.LargePackagingCodeIndex, code.LargePackagingCodeLength);
            resultModel.PackageType = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.PackagingType, codeStr, (int)code.PackagingTypeIndex, (int)code.PackagingTypeLength);
            resultModel.BatchNumber = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.BatchNumber, codeStr, (int)code.BatchNumberIndex, (int)code.BatchNumberLength);
            resultModel.VaildUntil = drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.VaildUntil, codeStr, (int)code.ValidityPeriodIndex, (int)code.ValidityPeriodLength);
            resultModel.Density =float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Density, codeStr, code.DensityIndex, code.DensityLength));
            resultModel.Equivalent = float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.Equivalent, codeStr, (int)code.EquivalentIndex, (int)code.EquivalentLength));
            resultModel.LoadCapacity= float.Parse(drugManufacturerBLL.RetBarcodeResult(BarcodeEnum.LoadingCapacity, codeStr, (int)code.LoadingCapacityIndex, (int)code.LoadingCapacityLength));
            return resultModel;
        }

        /// <summary>
        /// 获取导出的excel数据
        /// </summary>
        /// <returns></returns>
        public List<ParticlesExportModel> ParticlesExports() 
        { 
            return drugManagermentDAL.ParticlesExports();
        }

        public List<ErrorParticlesExportModel> CheckAllParticlesImport(List<ErrorParticlesExportModel> errorParticlesExportModels) 
        {
            CommonDataBLL commonDataBLL = new CommonDataBLL();
            ComboxDataBLL comboxDataBLL = new ComboxDataBLL();

            var allParticles = commonDataBLL.GetCommonParticles();
            var manufacturers = comboxDataBLL.GetManufacturerComboxData();
            errorParticlesExportModels.ForEach(item =>
            {
                if (string.IsNullOrEmpty(item.ParName)) 
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "药品简称不可以为空";
                    return;
                }
                if (item.ParName.Length>0)
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "药品简称长度不可超过20";
                    return;
                }
                if (allParticles.Any(x=>x.Name== item.ParName))
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "药品简称已在系统药品字典存在";
                    return;
                }
                if (string.IsNullOrEmpty(item.FullName))
                {
                    item.FullName = item.ParName;
                }
                if (!string.IsNullOrEmpty(item.FullName) && item.FullName.Length > 50)
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "药品全称长度不可超过50";
                    return;
                }

                item.ManufacturerId = 1;
                if (!string.IsNullOrEmpty(item.ManufacturerName)) 
                {
                    if (manufacturers != null)
                    {
                        var id = manufacturers.FirstOrDefault(x => x.Name == item.ManufacturerName)?.Id;
                        if (id.HasValue)
                        {
                            item.ManufacturerId = (int)id;
                        }
                        else 
                        {
                            item.IsPassed = "不通过";
                            item.ErrorMessage = "厂家在系统不存在";
                            return;
                        }
                    }
                }

                if (string.IsNullOrEmpty(item.HisCode))
                {
                    item.HisCode = "无";
                }
                if (item.HisCode.Length > 50)
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "HIS编码长度不可超过50";
                    return;
                }
                if (!string.IsNullOrEmpty(item.HisName) && item.HisName.Length > 50)
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "HIS名称长度不可超过50";
                    return;
                }

                if (item.Density<0.5 && item.Density>2) 
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "密度只能是在[0.5~2]之间";
                    return;
                }
                if (item.DensityCoefficient < 0.5 && item.Density > 2)
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "密度系数只能是在[0.5~2]之间";
                    return;
                }
                if (item.DensityCoefficient < 0.5 && item.Density > 2)
                {
                    item.IsPassed = "不通过";
                    item.ErrorMessage = "密度系数只能是在[0.5~2]之间";
                    return;
                }

            });
        }
    }
}
