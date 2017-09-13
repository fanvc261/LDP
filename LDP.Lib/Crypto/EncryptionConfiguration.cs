
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Xml;
using log4net;

namespace LDP.Lib.Common
{
    
    public class EncryptionConfiguration
    {
        private static readonly ILog log
            = LogManager.GetLogger(typeof(EncryptionConfiguration));

        private XmlNode rsaNode;

        

        public void LoadValuesFromConfigurationXml(XmlNode node)
        {

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "RSAKeyValue")
                    rsaNode = child;
            }
        }

        public String RsaKey
        {
            get
            {
                if (this.rsaNode != null)
                    return this.rsaNode.OuterXml;

                return String.Empty;

            }

        }

        public static EncryptionConfiguration GetConfig()
        {
            //return (EncryptionConfiguration)ConfigurationManager.GetSection("system.web/mojoEncryption");

            try
            {
                if (
                    (HttpRuntime.Cache["EncryptionConfiguration"] != null)
                    && (HttpRuntime.Cache["EncryptionConfiguration"] is EncryptionConfiguration)
                )
                {
                    return (EncryptionConfiguration)HttpRuntime.Cache["EncryptionConfiguration"];
                }

                EncryptionConfiguration config
                    = new EncryptionConfiguration();

                

                string pathToConfigFile
                    = System.Web.Hosting.HostingEnvironment.MapPath(ConfigHelper.GetStringProperty("CryptoHelperKeyFile", "~/Encryption.config"));

                log.Debug("path to crypto key " + pathToConfigFile);

                if (!File.Exists(pathToConfigFile))
                {
                    log.Error("crypto file not found " + pathToConfigFile);
                    return config;
                }

                FileInfo fileInfo = new FileInfo(pathToConfigFile);
                
                XmlDocument configXml = new XmlDocument();
                configXml.Load(fileInfo.FullName);
                config.LoadValuesFromConfigurationXml(configXml.DocumentElement);

                

                AggregateCacheDependency aggregateCacheDependency
                    = new AggregateCacheDependency();

               
                aggregateCacheDependency.Add(new CacheDependency(pathToConfigFile));

                System.Web.HttpRuntime.Cache.Insert(
                    "EncryptionConfiguration",
                    config,
                    aggregateCacheDependency,
                    DateTime.Now.AddYears(1),
                    TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.Default,
                    null);

                return (EncryptionConfiguration)HttpRuntime.Cache["EncryptionConfiguration"];

            }
            catch (HttpException ex)
            {
                log.Error(ex);

            }
            catch (System.Xml.XmlException ex)
            {
                log.Error(ex);

            }
            catch (ArgumentException ex)
            {
                log.Error(ex);

            }
            catch (NullReferenceException ex)
            {
                log.Error(ex);

            }

            return null;



        }


    }
}
