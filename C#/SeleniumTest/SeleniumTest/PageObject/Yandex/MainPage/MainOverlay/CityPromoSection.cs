using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class CityPromoSection : HtmlSection
    {
        public CityPromoSection(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public CityPromoSection(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public HtmlImageElement PromoTimeIcon => new HtmlImageElement(WebElement, By.ClassName("image_type_promo-time"));

        public HtmlElement PromoTimeTextElement => new HtmlElement(WebElement, By.CssSelector("div.city-promo-details__text[data-html='model.timeText']"));

        public HtmlImageElement PromoStarIcon => new HtmlImageElement(WebElement, By.ClassName("image_type_promo-star"));

        public HtmlElement PromoStarTextElement => new HtmlElement(WebElement, By.CssSelector("div.city-promo-details__text[data-html='model.priceText']"));

        public HtmlLinkElement AndroidStoreLink => new HtmlLinkElement(WebElement, By.XPath("//a[contains(@class, 'link_js_inited')][div[contains(@class, 'stores__icon_type_android')]]"));

        public HtmlLinkElement IosStoreLink => new HtmlLinkElement(WebElement, By.XPath("//a[contains(@class, 'link_js_inited')][div[contains(@class, 'stores__icon_type_ios')]]"));
    }
}
