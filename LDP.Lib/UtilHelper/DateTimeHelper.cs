using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDP.Lib.Common
{
    public class DateTimeHelper
    {
        public static string getDateString(DateTime dtDate)
        { 
            return dtDate.ToShortDateString();
        }
    }
}
