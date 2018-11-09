package Selenium.Common.HtmlEntities;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import java.util.function.Supplier;

public class HtmlButtonElement extends HtmlElement {
    public HtmlButtonElement(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlButtonElement(Supplier<WebElement> webElement, By by) {
        super(webElement, by);
    }
}
