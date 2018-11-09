package Selenium.PageObject.Rows.Header;

import Selenium.Common.HtmlEntities.HtmlElement;
import Selenium.Common.HtmlEntities.HtmlHoverableElement;
import Selenium.Common.HtmlEntities.HtmlSection;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class TopMenuRow extends HtmlSection {
    public TopMenuRow(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlHoverableElement WomenLink = new HtmlHoverableElement(WebElement(), By.xpath(".//a[contains(text(), 'Women')]")) {{ ExpectedText = "WOMEN"; }};

    public HtmlHoverableElement DressesLink = new HtmlHoverableElement(WebElement(), By.xpath("./ul/li/a[contains(text(), 'Dresses')]")) {{ ExpectedText = "DRESSES"; }};

    public HtmlHoverableElement TshirtsLink = new HtmlHoverableElement(WebElement(), By.xpath("./ul/li/a[contains(text(), 'T-shirts')]")) {{ ExpectedText = "T-SHIRTS"; }};
}
