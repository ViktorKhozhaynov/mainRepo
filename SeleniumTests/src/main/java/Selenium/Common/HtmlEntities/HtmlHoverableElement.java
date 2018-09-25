package Selenium.Common.HtmlEntities;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;

import java.util.function.Supplier;

public class HtmlHoverableElement extends HtmlElement{
    public HtmlHoverableElement(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlHoverableElement(Supplier<WebElement> webElement, By by) {
        super(webElement, by);
    }

    public void HoverOver() {
        Actions action = new Actions(WebDriver());
        action.moveToElement(WebElement().get()).perform();
    }
}
