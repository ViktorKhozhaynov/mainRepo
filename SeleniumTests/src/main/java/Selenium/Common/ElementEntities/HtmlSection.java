package Selenium.Common.ElementEntities;

import Selenium.Common.Helpers.CustomImplicitTimeout;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.internal.WrapsDriver;

import java.util.function.Supplier;

public class HtmlSection {
    protected final int QUICK_SEARCH_TIMEOUT = 2;
    protected Logger log = LogManager.getFormatterLogger(this.getClass().getName());
    private WebDriver webDriver;
    private Supplier<WebElement> webElement;
    private By by;

    private HtmlSection() {}

    public HtmlSection(WebDriver webDriver, By by) {
        this.webDriver = webDriver;
        this.by = by;
    }

    public HtmlSection(Supplier<WebElement> webElement, By by) {
        this.webElement = webElement;
        this.by = by;
    }

    public WebElement WebElement() {
        return by != null && webElement != null
                ? webElement.get().findElement(by)
                : by != null
                    ? webDriver.findElement(by)
                    : webDriver.findElement(By.xpath(".//"));
    }

    public WebDriver WebDriver() {
        return webDriver != null ? webDriver : ((WrapsDriver) webElement.get()).getWrappedDriver();
    }

    public String Text() {
        try (var ignored = new CustomImplicitTimeout(WebDriver(), QUICK_SEARCH_TIMEOUT)) {
            return WebElement().getText();
        } catch (Exception ex) {
            log.error("Error has occurred during an attempt to get the text of the element! Message: %s", ex.getMessage());
            return "";
        }
    }

    public Boolean IsPresent() {
        try (var ignored = new CustomImplicitTimeout(webDriver, QUICK_SEARCH_TIMEOUT)) {
            webDriver.findElement(by);
            return true;
        } catch (Exception ex) {
            log.warn("The element hasn't been found by '$s' in the DOM!", by.toString());
            return false;
        }
    }

    public Boolean IsAbsent() {
        try (var ignored = new CustomImplicitTimeout(webDriver, QUICK_SEARCH_TIMEOUT)) {
            return webDriver.findElements(by).size() == 0;
        } catch (Exception ex) {
            log.error("Error has occurred during an attempt to get the element! Message: %s", ex.getMessage());
        }
        return false;
    }

    public Boolean IsDisplayed() {
        return WebElement().isDisplayed();
    }

    public Boolean IsHidden() {
        return !WebElement().isDisplayed();
    }
}