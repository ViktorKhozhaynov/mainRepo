using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class DriverBase
    {
        protected static Configuration config = Configuration.GetInstance();
        protected ILog log;

        public IWebDriver WebDriver;

        [OneTimeSetUp]
        protected void InitializeFixture()
        {
            XmlConfigurator.Configure();
            log = LogManager.GetLogger(GetType().Name);
        }

        [SetUp]
        protected virtual void Initialize()
        {
            WebDriver = DriverFactory.GetDriver(config.DriverType);
        }

        [TearDown]
        protected void TearDown() => WebDriver.Quit();
    }
}
