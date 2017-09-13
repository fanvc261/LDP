using LDP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LDP.ROOT.Helper
{
    public static class RenderHelper
    {
        public static string RenderWigetCtr( Wiget wiget, int status)
        {
            return wiget.Content;
        }
    }
}
