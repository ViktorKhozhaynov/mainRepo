using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.Core.TestEntities;
using System;

namespace SeleniumTest.Core
{
    [TestFixture]
    public class TestBase
    {
        protected ILog logger;
        protected Configuration config;
        protected IWebDriver WebDriver;

        [OneTimeSetUp]
        protected void InitializeFixture()
        {
            XmlConfigurator.Configure();
            logger = LogManager.GetLogger(GetType());

            config = Configuration.GetInstance();
        }
        
        [SetUp]
        protected void Initialize()
        {
            WebDriver = DriverFactory.GetDriver(config.GetDriverType);
        }

        [TearDown]
        protected void TearDown()
        {
            WebDriver.Quit();
        }

        protected void TestCase(string description, Action testBody)
        {
            TestCaseMethods.TestCase(description, testBody);
        }

        protected void TestStep(string description, Action testBody)
        {
            TestStepMethods.TestStep(description, testBody);
        }        
    }
}
