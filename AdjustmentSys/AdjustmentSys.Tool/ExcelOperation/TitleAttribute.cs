using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdjustmentSys.Common.Tool
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TitleAttribute : Attribute
    {
        public string Titile;

        public HSSFCellStyle CellType; 
    }
}
