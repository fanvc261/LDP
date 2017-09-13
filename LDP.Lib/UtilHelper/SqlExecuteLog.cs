using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace LDP.Lib.Data
{
    class SqlExecuteLog
    {
        public static void Log(SqlCommand cmd)
        { 
            string logpath = AppDomain.CurrentDomain.BaseDirectory + "/SqlExecuteLog";
            if(!Directory.Exists(logpath))
            {
                Directory.CreateDirectory(logpath);
            }
            using(StreamWriter sw =  new StreamWriter(logpath + string.Format("/SqlExecuteLog_{0}.txt", DateTime.Now.ToString("yyyyMMdd")),true))
            {
                
                sw.WriteLine(string.Format("time : \t {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                sw.WriteLine("------------------------");
                if (System.Web.HttpContext.Current != null)
                {
                    sw.WriteLine(string.Format("URL : \t {0}", System.Web.HttpContext.Current.Request.RawUrl));
                }
                sw.WriteLine(string.Format("Query : \t {0}", GetQuery(cmd)));
                
                sw.WriteLine("------------------------");

                sw.Flush();
                sw.Close();
            }
        }

        private static string GetQuery(SqlCommand cmd)
        {
            string returnvalue = cmd.CommandText;

            //if (cmd.CommandText.Contains('@'))
            //{
            //    returnvalue = cmd.CommandText.Substring(0, cmd.CommandText.IndexOf('@')) + " \t";
            //}
            //else
            //{
            //    returnvalue = cmd.CommandText;
            //}

            bool isFirst = true;
            foreach (SqlParameter param in cmd.Parameters)
            {
                if(isFirst == true)
                {
                    returnvalue = string.Format(returnvalue.Replace("EXEC", "EXEC \t").Replace(param.ParameterName, string.Format("\t'{0}'", param.Value)));
                    isFirst = false;
                }
                else
                {
                    returnvalue = string.Format(returnvalue.Replace(param.ParameterName, string.Format("'{0}'", param.Value)));
                }
                
            }

            return returnvalue.Trim(',');
        }
    }
}
