package Selenium.Common.HtmlEntities;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import java.util.function.Supplier;

public class HtmlElement extends HtmlSection {
    public HtmlElement(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlElement(Supplier<WebElement> webElement, By by) {
        super(webElement, by);
    }

    public String ExpectedText;

    public void Click() {
        try {
            WebElement().get().click();
        } catch (Exception ex) {
            log.error("An error has occurred while clicking on the element! Message: %s", ex.getMessage());
        }
    }
}
