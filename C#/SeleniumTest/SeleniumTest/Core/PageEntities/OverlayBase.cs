using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class OverlayBase : HtmlSection
    {
        public OverlayBase(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public OverlayBase(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}
