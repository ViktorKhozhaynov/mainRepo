using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class CityPromoSection : HtmlSection
    {
        public CityPromoSection(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public CityPromoSection(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public HtmlImageElement PromoTimeIcon => new HtmlImageElement(WebElement, By.ClassName("image_type_promo-time"), this);

        public HtmlElement PromoTimeTextElement => new HtmlElement(WebElement, By.CssSelector("div.city-promo-details__text[data-html='model.timeText']"), this);

        public HtmlImageElement PromoStarIcon => new HtmlImageElement(WebElement, By.ClassName("image_type_promo-star"), this);

        public HtmlElement PromoStarTextElement => new HtmlElement(WebElement, By.CssSelector("div.city-promo-details__text[data-html='model.priceText']"), this);

        public HtmlLinkElement AndroidStoreLink => new HtmlLinkElement(WebElement, By.XPath(".//a[not(contains(@style,'display:none'))][div[contains(@class, 'stores__icon_type_android')]]"), this);

        public HtmlLinkElement IosStoreLink => new HtmlLinkElement(WebElement, By.XPath(".//a[not(contains(@style,'display:none'))][div[contains(@class, 'stores__icon_type_ios')]]"), this);
    }
}
