using LDP.Lib.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LDP.Data.Constants
{
    public enum CategoryStatus
    {
        None = 0,
        Active = 1
    }

    public enum WigetStatus
    {
        None = 0,
        Active = 1        
    }

    public enum UserStatus
    {
        None = 0,
        Active = 1,
        Block = 2,
        Delete = 4,
        Encryption = 32
    }

    public enum PageStatus
    {
        None = 0,
        Admin = 1
    }


    public partial class ContainerGuid
    {
        public const string GuidHeader = "f50432a6-0000-43a7-a68f-ca088f05af7b";
        public const string GuidTop = "ecf1d679-58ad-44cc-84b4-62c28cd6a280";
        public const string GuidLeft = "7ee0f082-2a27-4075-a184-d04e18bc6ae0";
        public const string GuidRight = "a2336516-70b3-4891-889b-73ee828f6f91";
        public const string GuidBottom = "41d0db21-312f-4249-8b7d-20badf52f1b0";
        public const string GuidFooter = "72086953-fe1f-48fe-819a-866e5fb9473b";
    }

    public static class DataHelper
    {
        public static string GetDeviceid()
        {
            if (string.IsNullOrEmpty(CookieHelper.GetCookieValue("DEVICEID")))
            {
                string companyName = "LDP";
                Assembly currentAssem = typeof(DataHelper).Assembly;
                object[] attribs = currentAssem.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);
                if (attribs.Length > 0)
                {
                    companyName = ((AssemblyCompanyAttribute)attribs[0]).Company;
                    CookieHelper.SetCookie("DEVICEID", companyName);
                }

                return companyName;
            }
            else
            {
                return CookieHelper.GetCookieValue("DEVICEID");
            }

        }

        
    }
    //}
}
