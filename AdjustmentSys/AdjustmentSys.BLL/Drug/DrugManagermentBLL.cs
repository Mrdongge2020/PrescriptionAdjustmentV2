using AdjustmentSys.DAL.Drug;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.User;
using AdjustmentSys.Tool.Enums;
using NPinyin;
using System;
using System.Collections.Generic;
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
    }
}
