using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace SeleniumTest.Core
{
    public enum DriverType
    {
        InternetExplorer,
        Chrome,
        Firefox
    }

    public class DriverFactory
    {
        public static IWebDriver GetDriver(DriverType browserType)
        {
            switch (browserType)
            {
                case DriverType.Firefox:
                    return new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));

                case DriverType.InternetExplorer:
                    return new InternetExplorerDriver();

                case DriverType.Chrome:
                    return new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));  
            }
            return null;
        }
    }
}
