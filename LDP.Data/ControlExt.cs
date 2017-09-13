using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;

namespace SNSV.Lib.Base
{
    public static class ControlExt
    {
        public static IEnumerable<Control> FindControlByAttribute(this Control control, string key)
        {
            var current = control as System.Web.UI.HtmlControls.HtmlControl;
            if (current != null)
            {
                var k = current.Attributes[key];
                if (k != null)
                    yield return current;
            }
            if (control.HasControls())
            {
                foreach (Control c in control.Controls)
                {
                    foreach (Control item in c.FindControlByAttribute(key))
                    {
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<Control> FindControlByAttribute(this Control control, string key, string value)
        {
            var current = control as System.Web.UI.HtmlControls.HtmlControl;
            if (current != null)
            {
                var k = current.Attributes[key];
                if (k != null && k == value)
                    yield return current;
            }
            if (control.HasControls())
            {
                foreach (Control c in control.Controls)
                {
                    foreach (Control item in c.FindControlByAttribute(key, value))
                    {
                        yield return item;
                    }
                }
            }
        }

        public static IEnumerable<T> GetAllControlsOfType<T>(this Control parent) where T : Control
        {
            var result = new List<T>();

            foreach (Control control in parent.Controls)
            {
                if (control is T)
                {
                    result.Add((T)control);
                }

                if (control.HasControls())
                {
                    result.AddRange(control.GetAllControlsOfType<T>());
                }
            }
            return result;

        }
        //public static IEnumerable<Control> GetControlByAtt(this Control ds)
        //{
        //    try
        //    {
        //        yield return new Control();
        //    }
        //    catch (Exception) { yield return new Control(); ; }
        //}


    }
}
