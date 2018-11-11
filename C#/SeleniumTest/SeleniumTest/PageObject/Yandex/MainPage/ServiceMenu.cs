using OpenQA.Selenium;
using SeleniumTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.PageObject
{
    public class ServiceMenu : HtmlSection
    {
        public ServiceMenu(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public ServiceMenu(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }
    }
}
