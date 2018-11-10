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
        public MapSection(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public MapSection(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}
