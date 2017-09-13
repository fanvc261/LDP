using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LDP.Lib.Common
{
    public class EncryptionConfigurationHandler : IConfigurationSectionHandler
    {


        #region IConfigurationSectionHandler Members

        public object Create(object parent, object configContext, XmlNode node)
        {
            EncryptionConfiguration config = new EncryptionConfiguration();
            config.LoadValuesFromConfigurationXml(node);
            return config;
        }

        #endregion


    }
}
