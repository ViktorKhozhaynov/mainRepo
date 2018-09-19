package Selenium.PageObject.Rows.Header;

import Selenium.Common.HtmlEntities.HtmlButtonElement;
import Selenium.Common.HtmlEntities.HtmlElement;
import Selenium.Common.HtmlEntities.HtmlSection;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import java.util.function.Supplier;

public class NavigationRow extends HtmlSection {
    public NavigationRow(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public NavigationRow(Supplier<WebElement> webElement, By by) {
        super(webElement, by);
    }

    public HtmlElement ShopPhoneIconElement = new HtmlElement(WebElement(), By.cssSelector("i.icon-phone"));

    public HtmlElement ShopPhoneContainerELement = new HtmlElement(WebElement(), By.className("shop-phone"));

    public HtmlElement ShopPhoneElement = new HtmlElement(WebElement(), By.cssSelector("span.shop-phone strong"));

    public HtmlButtonElement ContactUsButton = new HtmlButtonElement(WebElement(), By.id("contact-link"));

    public HtmlButtonElement SignInButton = new HtmlButtonElement(WebElement(), By.cssSelector(".login"));
}
