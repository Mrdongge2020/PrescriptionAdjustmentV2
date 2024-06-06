using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.CommModel;
using AdjustmentSys.Models.Drug;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.DAL.Rule
{
    public class ParticleProhibitionRuleDAL
    {
        private readonly EFCoreContext _eFCoreContext = new EFCoreContext();

        /// <summary>
        /// 新增或编辑药品相容规则
        /// </summary>
        /// <returns></returns>
        public string AddOrEditRuleInfo(ParticleProhibitionRule ruleInfo)
        {
            string error = "";
            try
            {
                if (ruleInfo.ID != default(int))
                {
                    bool isExitRulr = _eFCoreContext.ParticleProhibitionRules.AsNoTracking().Any(x => x.Name == ruleInfo.Name  && x.ID != ruleInfo.ID);
                    if (isExitRulr)
                    {
                        return "该药品相容规则名称已存在";
                    }
                    isExitRulr = _eFCoreContext.ParticleProhibitionRules.AsNoTracking().Any(x => x.FirstParticlesID == ruleInfo.FirstParticlesID && x.SecondParticlesID==ruleInfo.SecondParticlesID && x.ID != ruleInfo.ID);
                    if (isExitRulr)
                    {
                        return "与该规则相同规则(第一味颗粒和第二味颗粒完全一致)已存在";
                    }
                    var rule = _eFCoreContext.ParticleProhibitionRules.AsNoTracking().FirstOrDefault(x => x.ID == ruleInfo.ID);
                    if (rule == null)
                    {
                        return "未找到要编辑的药品相容规则信息，请刷新后再试";
                    }
                    rule.Name = ruleInfo.Name;
                    rule.FirstParticlesID = ruleInfo.FirstParticlesID;
                    rule.SecondParticlesID = ruleInfo.SecondParticlesID;
                    rule.Remark = ruleInfo.Remark;
                    rule.UpdateTime = ruleInfo.UpdateTime;
                    rule.UpdateBy = ruleInfo.UpdateBy;
                    rule.UpdateName = ruleInfo.UpdateName;
                    //可省略
                    _eFCoreContext.ParticleProhibitionRules.Update(rule);
                }
                else
                {
                    bool isExitRulr = _eFCoreContext.ParticleProhibitionRules.AsNoTracking().Any(x => x.Name == ruleInfo.Name);
                    if (isExitRulr)
                    {
                        return "该药品相容规则名称已存在";
                    }
                    isExitRulr = _eFCoreContext.ParticleProhibitionRules.AsNoTracking().Any(x => x.FirstParticlesID == ruleInfo.FirstParticlesID && x.SecondParticlesID == ruleInfo.SecondParticlesID);
                    if (isExitRulr)
                    {
                        return "与该规则相同规则(第一味颗粒和第二味颗粒完全一致)已存在";
                    }
                    _eFCoreContext.ParticleProhibitionRules.Add(ruleInfo);
                }

                var result = _eFCoreContext.SaveChanges();
                if (result <= 0)
                {
                    error = (ruleInfo.ID > 0 ? "编辑" : "新增") + "药品相容规则信息失败，请稍后再试。";
                }
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;
        }

        /// <summary>
        /// 删除药品相容规则
        /// </summary>
        public string DeleteRuleInfo(int id)
        {
            var Rule = _eFCoreContext.ParticleProhibitionRules.AsNoTracking().FirstOrDefault(x => x.ID == id);
            if (Rule == null)
            {
                return "要删除的药品相容规则信息不存在，请刷新列表后再试";
            }
            int index=  _eFCoreContext.ParticleProhibitionRules.Where(x => x.ID == id).ExecuteDelete();

            return index > 0 ? "" : "删除药品相容规则信息失败,请稍后再试";
        }

        /// <summary>
        /// 根据药品相容规则ID，获取药品相容规则信息
        /// </summary>
        /// <param name="id">药品相容规则id</param>
        /// <returns></returns>
        public ParticleProhibitionRule GetRuleInfo(int id)
        {
            return _eFCoreContext.ParticleProhibitionRules.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// 药品相容规则列表查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public List<ParticleProhibitionRulesPageListModel> GetRuleInfoByPage(int pageIndex, int pageSize, out int count)
        {
            var where = _eFCoreContext.ParticleProhibitionRules.AsNoTracking();

            //统计总记录数
            count = where.Count();
            if (count == 0)
            {
                return null;
            }

            //结果按照创建时间降序排序
            where = where.OrderByDescending(x => x.CreateTime);

            //跳过翻页的数量
            var list = where.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();

            //获取结果，返回
            List<ParticleProhibitionRulesPageListModel> resultList = new List<ParticleProhibitionRulesPageListModel>();
            //获取颗粒信息
            var particlesInfos = _eFCoreContext.ParticlesInfos.AsNoTracking().Select(x=>new ComboxModel()
            { 
                Id = x.ID,
                Name = x.Name
            }).ToList();

            list.ForEach(item => {
                var model = new ParticleProhibitionRulesPageListModel();
                model.ID = item.ID;
                model.Name = item.Name; 
                model.Remark = item.Remark;
                model.CreateTime = item.CreateTime;
                model.CreateName = item.CreateName;
                model.UpdateName = item.UpdateName;
                model.UpdateTime = item.UpdateTime;
                if (particlesInfos != null && particlesInfos.Count > 0)
                {
                    model.FirstParticlesName = particlesInfos.FirstOrDefault(x => x.Id == item.FirstParticlesID)?.Name;
                    model.SecondParticlesName = particlesInfos.FirstOrDefault(x => x.Id == item.SecondParticlesID)?.Name;
                }
                resultList.Add(model);
            });
            return resultList;
        }
    }
}
