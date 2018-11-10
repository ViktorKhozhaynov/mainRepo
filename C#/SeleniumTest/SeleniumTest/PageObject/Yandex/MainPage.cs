using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class MainPage : PageBase
    {
        public MainPage(IWebDriver webDriver, PageBase parent) : base(webDriver, parent)
        {
        }

        public HeaderMenu Header => new HeaderMenu(webDriver, By.Id("header"));

        public ServiceMenu ServiceMenu => new ServiceMenu(webDriver, By.ClassName("service-menu"));

        public MapSection Map => new MapSection(webDriver, By.Id("maps"));

        public MainOverlay MainOverlay => new MainOverlay(webDriver, By.CssSelector("div[role='main'] div.layout__col:not(.js-placeholder)"));
    }
}
