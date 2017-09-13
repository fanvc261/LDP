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
        public static string GetFirstRowMessage(this DataSet ds)
        {
            try
            {
                if (ds.Tables[0].Rows.Count <= 0)
                    return string.Empty;
                string message = ds.Tables[0].Rows[0][0].ToString();
                int i = message.LastIndexOf("MSGDESC=");
                message = (i > 0) ? message.Substring(i + 8) : message;
                return message;
                /*
                int i = message.LastIndexOf("(MSG");
                message = (i > 0) ? message.Substring(i + 10) : message;

                i = message.LastIndexOf("(REQ");
                message = (i > 0) ? message.Substring(i + 10) : message;
                return message;*/
            }
            catch (Exception) { return string.Empty; }
        }

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
