using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool.Configuration
{
    public interface IConfiguration
    {
        string Read(string key);
    }
}
