using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LDP.Data
{
    public static class DataSetExt
    {
        
        public static DataTable GetFirstTable(this DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }
    }
}
