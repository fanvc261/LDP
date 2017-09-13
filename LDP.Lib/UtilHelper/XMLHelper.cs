using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LDP.Lib.Common
{
    public static class XmlHelper
    {

        public static void XMLTransform(System.Web.UI.WebControls.Xml xml, string fname_template, XmlDocument doc)
        {
            XMLTransform(xml, fname_template, doc, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="fname_template"></param>
        /// <param name="doc"></param>
        /// <param name="xslArg"></param>
        /// <remarks></remarks>
        public static void XMLTransform(System.Web.UI.WebControls.Xml xml, string fname_template, XmlDocument doc, XsltArgumentList xslArg)
        {
            xml.XPathNavigator = doc.CreateNavigator();
            xml.TransformArgumentList = xslArg;
            xml.TransformSource = System.Web.HttpContext.Current.Server.MapPath(fname_template);
            xml.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public static void AddNode(XmlDocument doc, XmlElement parent, string name, string text)
        {
            XmlElement node = doc.CreateElement(name);
            node.InnerText = text;
            parent.AppendChild(node);
        }

        public static void AddNode(XmlDocument xmlDoc, string name, string content)
        {
            XmlElement elem = xmlDoc.CreateElement(name);
            XmlText text = xmlDoc.CreateTextNode(content);
            xmlDoc.DocumentElement.AppendChild(elem);
            xmlDoc.DocumentElement.LastChild.AppendChild(text);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public static void AddAttribute(XmlDocument doc, XmlElement parent, string name, string text)
        {
            XmlAttribute node = doc.CreateAttribute(name);
            node.InnerText = text;
            parent.AppendChild(node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="doc"></param>
        public static void WriteXML(string filename, XmlDocument doc)
        {
            XmlTextWriter writer = new XmlTextWriter(System.Web.HttpContext.Current.Server.MapPath("~/" + filename), Encoding.UTF8);
            doc.WriteTo(writer);
            writer.Flush();
            writer.Close();
        }

        public static string Attr(this XElement el, string name)
        {
            var attr = el.Attribute(name);
            return attr == null ? null : attr.Value;
        }

        public static XElement Attr<T>(this XElement el, string name, T value)
        {
            el.SetAttributeValue(name, value);
            return el;
        }

        public static XElement FromAttr<TTarget, TProperty>(this XElement el, TTarget target,
                                                            Expression<Func<TTarget, TProperty>> targetExpression)
        {
            var memberExpression = targetExpression.Body as MemberExpression;
            if (memberExpression == null) throw new InvalidOperationException("Expression is not a member expression.");
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null) throw new InvalidOperationException("Expression is not for a property.");
            var name = propertyInfo.Name;
            var attr = el.Attribute(name);
            if (attr == null) return el;
            if (typeof(TProperty) == typeof(string))
            {
                propertyInfo.SetValue(target, (string)attr, null);
                return el;
            }
            if (attr.Value == "null")
            {
                propertyInfo.SetValue(target, null, null);
            }
            else if (typeof(TProperty) == typeof(int))
            {
                propertyInfo.SetValue(target, (int)attr, null);
            }
            else if (typeof(TProperty) == typeof(bool))
            {
                propertyInfo.SetValue(target, (bool)attr, null);
            }
            else if (typeof(TProperty) == typeof(DateTime))
            {
                propertyInfo.SetValue(target, (DateTime)attr, null);
            }
            else if (typeof(TProperty) == typeof(double))
            {
                propertyInfo.SetValue(target, (double)attr, null);
            }
            else if (typeof(TProperty) == typeof(float))
            {
                propertyInfo.SetValue(target, (float)attr, null);
            }
            else if (typeof(TProperty) == typeof(decimal))
            {
                propertyInfo.SetValue(target, (decimal)attr, null);
            }
            else if (typeof(TProperty) == typeof(int?))
            {
                propertyInfo.SetValue(target, (int?)attr, null);
            }
            else if (typeof(TProperty) == typeof(bool?))
            {
                propertyInfo.SetValue(target, (bool?)attr, null);
            }
            else if (typeof(TProperty) == typeof(DateTime?))
            {
                propertyInfo.SetValue(target, (DateTime?)attr, null);
            }
            else if (typeof(TProperty) == typeof(double?))
            {
                propertyInfo.SetValue(target, (double?)attr, null);
            }
            else if (typeof(TProperty) == typeof(float?))
            {
                propertyInfo.SetValue(target, (float?)attr, null);
            }
            else if (typeof(TProperty) == typeof(decimal?))
            {
                propertyInfo.SetValue(target, (decimal?)attr, null);
            }
            return el;
        }

        public static XElement ToAttr<TTarget, TProperty>(this XElement el, TTarget target,
                                                          Expression<Func<TTarget, TProperty>> targetExpression)
        {
            var memberExpression = targetExpression.Body as MemberExpression;
            if (memberExpression == null) throw new InvalidOperationException("Expression is not a member expression.");
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null) throw new InvalidOperationException("Expression is not for a property.");
            var name = propertyInfo.Name;
            var val = propertyInfo.GetValue(target, null);
            if (typeof(TProperty) == typeof(string))
            {
                el.Attr(name, (string)val);
                return el;
            }
            if (val == null)
            {
                el.Attr(name, "null");
            }
            else if (typeof(TProperty) == typeof(int))
            {
                el.Attr(name, (int)val);
            }
            else if (typeof(TProperty) == typeof(bool))
            {
                el.Attr(name, (bool)val);
            }
            else if (typeof(TProperty) == typeof(DateTime))
            {
                el.Attr(name, (DateTime)val);
            }
            else if (typeof(TProperty) == typeof(double))
            {
                el.Attr(name, (double)val);
            }
            else if (typeof(TProperty) == typeof(float))
            {
                el.Attr(name, (float)val);
            }
            else if (typeof(TProperty) == typeof(decimal))
            {
                el.Attr(name, (decimal)val);
            }
            else if (typeof(TProperty) == typeof(int?))
            {
                el.Attr(name, (int?)val);
            }
            else if (typeof(TProperty) == typeof(bool?))
            {
                el.Attr(name, (bool?)val);
            }
            else if (typeof(TProperty) == typeof(DateTime?))
            {
                el.Attr(name, (DateTime?)val);
            }
            else if (typeof(TProperty) == typeof(double?))
            {
                el.Attr(name, (double?)val);
            }
            else if (typeof(TProperty) == typeof(float?))
            {
                el.Attr(name, (float?)val);
            }
            else if (typeof(TProperty) == typeof(decimal?))
            {
                el.Attr(name, (decimal?)val);
            }
            return el;
        }

        public static XElementWithContext<TContext> With<TContext>(this XElement el, TContext context)
        {
            return new XElementWithContext<TContext>(el, context);
        }

        public class XElementWithContext<TContext>
        {
            public XElementWithContext(XElement element, TContext context)
            {
                Element = element;
                Context = context;
            }

            public XElement Element { get; private set; }
            public TContext Context { get; private set; }

            public XElementWithContext<TNewContext> With<TNewContext>(TNewContext context)
            {
                return new XElementWithContext<TNewContext>(Element, context);
            }

            public XElementWithContext<TContext> ToAttr<TProperty>(
                Expression<Func<TContext, TProperty>> targetExpression)
            {
                Element.ToAttr(Context, targetExpression);
                return this;
            }

            public XElementWithContext<TContext> FromAttr<TProperty>(
                Expression<Func<TContext, TProperty>> targetExpression)
            {
                Element.FromAttr(Context, targetExpression);
                return this;
            }
        }
    }
}
