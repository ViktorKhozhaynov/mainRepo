using OpenQA.Selenium;
using SeleniumTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.PageObject
{
    public class MapSection : HtmlSection
    {
        public MapSection(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public MapSection(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }
    }
}
