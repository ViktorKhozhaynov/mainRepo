using log4net;
using System;
using System.IO;
using System.Xml;

namespace SeleniumTest.Core
{
    public sealed class Configuration
    {
        private static Configuration instance;

        private const string configName = "Configuration.xml";
        private XmlNode config;
        private static readonly ILog log = LogManager.GetLogger(typeof(Configuration).Name);

        private Configuration()
        {
            log.Debug("Configuration initialization has been started!");

            var stream = this.GetType().Assembly.GetManifestResourceStream("SeleniumTest." + configName);
            var configFileRepr = new XmlDocument();

            try
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Couldnot find embedded mappings resource file.", configName);
                }
                configFileRepr.Load(stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            config = configFileRepr.SelectNodes("./configuration")[0];

            log.Info("Configuration has finished it's initialization successfully!");
        }

        public static Configuration GetInstance()
        {
            if (instance == null)
                instance = new Configuration();
            return instance;
        }

        public string GetValue(string key) => config.SelectNodes($"./{key}")[0].InnerText;

        public DriverType GetDriverType => (DriverType) Enum.Parse(typeof(DriverType), GetValue("driverType"));
    }
}
