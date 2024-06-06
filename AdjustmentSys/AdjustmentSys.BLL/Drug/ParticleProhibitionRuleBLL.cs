using AdjustmentSys.DAL.Drug;
using AdjustmentSys.DAL.Rule;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.User;
using NPinyin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Drug
{
    public class ParticleProhibitionRuleBLL
    {
        private readonly ParticleProhibitionRuleDAL _particleProhibitionRuleDAL = new ParticleProhibitionRuleDAL();

        /// <summary>
        /// 新增或编辑药品相容规则
        /// </summary>
        /// <returns></returns>
        public string AddOrEditRuleInfo(ParticleProhibitionRule ruleInfo) 
        {
            if (ruleInfo.ID == 0)
            {//新增,加创建信息

                ruleInfo.CreateBy = SysLoginUser._currentUser.UserId;
                ruleInfo.CreateName = SysLoginUser._currentUser.UserName;
                ruleInfo.CreateTime = DateTime.Now;
            }
            
            ruleInfo.UpdateBy = SysLoginUser._currentUser.UserId;
            ruleInfo.UpdateName = SysLoginUser._currentUser.UserName;
            ruleInfo.UpdateTime = DateTime.Now;
            return _particleProhibitionRuleDAL.AddOrEditRuleInfo(ruleInfo);
        }

        /// <summary>
        /// 删除药品相容规则
        /// </summary>
        public string DeleteRuleInfo(int id) 
        {
            return _particleProhibitionRuleDAL.DeleteRuleInfo(id);
        }

        /// <summary>
        /// 根据药品相容规则ID，获取药品相容规则信息
        /// </summary>
        /// <param name="id">药品相容规则id</param>
        /// <returns></returns>
        public ParticleProhibitionRule GetRuleInfo(int id)
        {
            return _particleProhibitionRuleDAL.GetRuleInfo(id);
        }

        /// <summary>
        /// 药品相容规则列表查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<ParticleProhibitionRulesPageListModel> GetRuleInfoByPage(int pageIndex, int pageSize, out int count)
        {
            return _particleProhibitionRuleDAL.GetRuleInfoByPage(pageIndex,pageSize,out count);
        }

    }
}
