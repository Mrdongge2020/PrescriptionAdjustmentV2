﻿using AdjustmentSys.DAL.Common;
using AdjustmentSys.EFCore;
using AdjustmentSys.Entity;
using AdjustmentSys.Models.Drug;
using AdjustmentSys.Models.PublicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.BLL.Common
{
    public class CommonDataBLL
    {
        CommonDataDAL _commonDataDAL = new CommonDataDAL();

        /// <summary>
        /// 获取所有药柜编号
        /// </summary>
        public List<string> GetMedicineCabinetCodes() 
        { 
            return _commonDataDAL.GetMedicineCabinetCodes();
        }

        /// <summary>
        /// 获取药品字典数据
        /// </summary>
        /// <returns></returns>
        public  List<ParticlesInfo> GetCommonParticles(List<int> ids = null)
        { 
            return _commonDataDAL.GetCommonParticles(ids);
        }
        /// <summary>
        /// 获取药柜详情信息
        /// </summary>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public List<MedicineCabinetDetail> GetMedicineCabinetDetails(string code) 
        {
            return _commonDataDAL.GetMedicineCabinetDetails(code);
        }

        /// <summary>
        /// 获取所有相容性规则信息
        /// </summary>
        public List<ParticleProhibitionRule> GetParticleProhibitionRules() 
        {
            return _commonDataDAL.GetParticleProhibitionRules();
        }
        /// <summary>
        /// 获取所有待下载处方
        /// </summary>
        /// <param name="preIds">处方编号集合</param>
        /// <returns></returns>
        public List<DataPrescription> GetAllDataPrescriptions(List<string> preIds)
        {
            
            return _commonDataDAL.GetAllDataPrescriptions(preIds);
        }
        /// <summary>
        /// 获取所有待下载处方详情
        /// </summary>
        /// <param name="preIds">处方编号集合</param>
        /// <returns></returns>
        public List<DataPrescriptionDetail> GetAllDataPrescriptionDetails(List<string> preIds)
        {
            return _commonDataDAL.GetAllDataPrescriptionDetails(preIds);
        }

        /// <summary>
        /// 获取所有厂家主信息
        /// </summary>
        /// <returns></returns>
        public List<ManufacturerInfo> GetManufacturerInfos() 
        { 
            return _commonDataDAL.GetManufacturerInfos();
        }
        /// <summary>
        /// 获取所有厂家解析码信息
        /// </summary>
        /// <returns></returns>
        public List<ManufacturerResolutionCode> GetManufacturerCodes(int mid=0) 
        {
            return _commonDataDAL.GetManufacturerCodes(mid);
        }
        /// <summary>
        /// 获取处方信息
        /// </summary>
        /// <returns></returns>
        public (object, object) GetPrescription(int preType, string preId) 
        {
            return _commonDataDAL.GetPrescription(preType, preId);
        }

        /// <summary>
        /// 根据rfid获取药柜详情数据
        /// </summary>
        /// <param name="rfid">rfid</param>
        public MedicineCabinetDetail GetMedicineCabinetDetail(int rfid) 
        {
            return _commonDataDAL.GetMedicineCabinetDetail(rfid, SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
        }

        /// <summary>
        /// 根据rfid获取颗粒字典数据
        /// </summary>
        /// <param name="rfid">rfid</param>
        /// <param name="code">药柜编号</param>
        /// <returns></returns>
        public ParticlesInfo GetParticlesInfo(int rfid)
        {
            return _commonDataDAL.GetParticlesInfo(rfid, SysDeviceInfo._currentDeviceInfo.MedicineCabinetCode);
        }
    }
}
