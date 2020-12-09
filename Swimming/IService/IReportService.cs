using Swimming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.IService
{
   public interface IReportService
    {
        void Export(string table, string type, Radzen.Query query = null);
    }
}
