using AdjustmentSys.Entity;
using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdjustmentSys.Models.Machine
{
    /// <summary>
    /// 处方主表
    /// </summary>
    public class DataPrescriptionTB
    {
        #region 数据表原生字段
        /// <summary>
        /// 主键自增
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 处方编号
        /// </summary>
        public string PrescriptionID { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        public SexEnum PatientSex { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public int PatientAge { get; set; }

        /// <summary>
        /// 出生月份
        /// </summary>
        public int PatientBirthMonth { get; set; }

        /// <summary>
        /// 无
        /// </summary>
        public int PatientBirthDay { get; set; }

        /// <summary>
        /// 患者联系方式
        /// </summary>
        public string PatientTel { get; set; }

        /// <summary>
        /// 患者邮件
        /// </summary>
        public string PatientEmail { get; set; }

        /// <summary>
        /// 患者的位置信息
        /// </summary>
        public string PatientLocation { get; set; }

        /// <summary>
        /// 开方医生
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 协定处方名称
        /// </summary>
        public string PrescriptionName { get; set; }

        /// <summary>
        /// 处方创建人
        /// </summary>
        public string CreateName { get; set; }

        /// <summary>
        /// 处方创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 划价员
        /// </summary>
        public string ValuerName { get; set; }

        /// <summary>
        /// 划价单号
        /// </summary>
        public string ValueSn { get; set; }

        /// <summary>
        /// 划价时间
        /// </summary>
        public DateTime ValuationTime { get; set; }

        /// <summary>
        /// 挂单号
        /// </summary>
        public string RegisterID { get; set; }

        /// <summary>
        /// 处方缴费类型
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 缴费状态
        /// </summary>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// 处方类型，住院或门诊
        /// </summary>
        public string PrescriptionType { get; set; }

        //// <summary>
        /// 住院床号
        /// </summary>
        public string? BedNumber { get; set; }

        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportTime { get; set; }

        /// <summary>
        /// 处方付数
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 分服次数
        /// </summary>
        public int TaskFrequency { get; set; }

        /// <summary>
        /// 单付单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 处方总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 处方明细条数
        /// </summary>
        public int DetailedCount { get; set; }

        /// <summary>
        /// 处方状态
        /// </summary>
        public int ProcessStatus { get; set; }

        /// <summary>
        /// 处方来源
        /// </summary>
        public int PrescriptionSource { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 处方使用方式
        /// </summary>
        public string UsageMethod { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string BackupField1 { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string BackupField2 { get; set; }

        /// <summary>
        /// 预留字段1
        /// </summary>
        public string BackupField3 { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public DateTime Writetime { get; set; }

        public bool Oddsate { get; set; }//奇数调方

        public int TaskState { get; set; }//调剂状态
        #endregion


        public List<DetailStructure> ParticlesDetail { get; set; }
        /// <summary>
        /// 处方明细结构
        /// </summary>
        /// 
        public class DetailStructure
        {
            public string PrescriptionID;//处方HIS码
            public Int32 ParticlesID;   //颗粒码
            public string ParticlesName;//颗粒名    
            public string ParticlesNameHIS;//HIS颗粒名称
            public string ParticlesCodeHIS;//HIS码
            public string BatchNumber;//批号
            public int ParticleOrder;//颗粒排序
            public double DoseHerb;//饮片剂量
            public double Equivalent;//当量
            public double Dose;//剂量
            public double NewDose;// 每格剂量
            public decimal Price;//单价
            public double Density;//颗粒密度
            public double DensityCoefficient;//颗粒密度匹配系数
            public double DoseLimit;//剂量上限
            public double CurrentWeight;//当前称重量
            public double DeductStockWeight;/// 提前扣除的库存
            public string Explain;//说明
            public bool Deductstate;//全自动扣除库存状态
            public int? RFID { get; set; }
            public CabinetStorageInfoTB CabinetParticles;


        }
        public struct PointStructure
        {
            public int ArkID;//颗粒柜号
            public int Layer;//颗粒层号
            public int CoordinateX;//X坐标
            public int CoordinateY;//Y坐标
        }
        public struct PointdownStructure
        {
            public Int32 ParticlesID;//颗粒ID
            public double Weight;//颗粒重量
            public int CoordinateX;//X坐标
            public int CoordinateY;//Y坐标
                                   //  public CabinetStorageInfoTB CabinetParticles;
        }





        /// <summary>
        /// 返回当前处方的颗粒ID列表
        /// </summary>
        /// 

        //public List<Int32> ListParticlesID
        //{
        //    get
        //    {
        //        List<Int32> Results = new List<int>();
        //        foreach (DetailStructure value in ParticlesDetail)
        //        {
        //            Results.Add(value.ParticlesID);
        //        }
        //        return Results;
        //    }
        //}
        ///// <summary>
        /////返回处方颗粒编号与药品明细字典
        ///// </summary>
        //public Dictionary<Int32, PointStructure> ListPoint
        //{
        //    get
        //    {
        //        Dictionary<Int32, PointStructure> Results = new Dictionary<Int32, PointStructure>();
        //        foreach (DetailStructure Point in ParticlesDetail)
        //        {
        //            PointStructure temp = new PointStructure();
        //            //temp.ArkID = Point.ArkID;
        //            //temp.Layer = Point.Layer;
        //            //temp.CoordinateX = Point.CoordinateX;
        //            //temp.CoordinateY = Point.CoordinateY;
        //            if (Results.Keys.Contains(Point.ParticlesID))
        //            {
        //                throw new Exception("处方存在相同的颗粒,请检查处方明细!");
        //            }
        //            else
        //            {
        //                Results.Add(Point.ParticlesID, temp);
        //            }
        //        }
        //        return Results;
        //    }
        //}
        #region 扩展字段
        /// <summary>
        /// 调剂盒数
        /// </summary>
        public int BoxNumber { get; set; }
        /// <summary>
        /// 拆分次数
        /// </summary>
        public int BreakNumber { get; set; }
        ///


        /// <summary>
        /// 生成的实时使用方式
        /// </summary>
        public string GenerateUseWay { get; set; }
        public string GenerateUseWay1 { get; set; }



        #endregion
        #region 公共方法        

        /// <summary>
        /// 处方状态枚举
        /// </summary>
        //public enum PrescriptionState
        //{
        //    未确认 = 0,
        //    已确认未下载 = 1,
        //    已下载 = 2,
        //    已调剂 = 3,
        //    作废 = 4
        //}
        /// <summary>
        /// 更新处方状态(0=未确认;1=已确认未下载;2=已下载;3=已调剂;4=作废)
        /// </summary>
        /// <param name="VoingeID">唯一编号</param>
        /// <param name="ProcessStatus">处方状态</param>
        /// <param name="DeviceID">调剂设备编号</param>
        /// <returns></returns>
        #endregion

    }
}
