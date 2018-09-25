package Selenium.Common.HtmlEntities;

import Selenium.Common.Helpers.CustomImplicitTimeout;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
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

    private WebElement _webElement() {
        return by != null && webElement != null
                ? webElement.get().findElement(by)
                : by != null
                    ? webDriver.findElement(by)
                    : webDriver.findElement(By.xpath(".//"));
    }

    public Supplier<WebElement> WebElement() {
        return () -> _webElement();
    }

    public WebDriver WebDriver() {
        return webDriver != null ? webDriver : ((WrapsDriver) webElement.get()).getWrappedDriver();
    }

    protected String InternalId() {
        return by != null ? by.toString() : "by.xpath //";
    }

    public String Text() {
        try (var ignored = new CustomImplicitTimeout(WebDriver(), QUICK_SEARCH_TIMEOUT)) {
            return _webElement().getText();
        } catch (Exception ex) {
            log.error("Error has occurred during an attempt to get the text of the element! Message: %s", ex.getMessage());
            return "";
        }
    }

    public Boolean IsPresent() {
        try (var ignored = new CustomImplicitTimeout(WebDriver(), QUICK_SEARCH_TIMEOUT)) {
            _webElement();
            return true;
        } catch (Exception ex) {
            log.warn("IsPresent: The element hasn't been found by '$s' locator in the DOM!", by.toString());
            return false;
        }
    }

    public Boolean IsAbsent() {
        try (var ignored = new CustomImplicitTimeout(WebDriver(), QUICK_SEARCH_TIMEOUT)) {
            int numberOfElements = webElement != null
                    ? webElement.get().findElements(by).size()
                    : webDriver.findElements(by).size();

            return numberOfElements == 0;
        } catch (Exception ex) {
            log.error("IsAbsent: Error has occurred during an attempt to get the element! Message: %s", ex.getMessage());
        }
        return false;
    }

    public Boolean IsDisplayed() {
        try (var ignored = new CustomImplicitTimeout(WebDriver(), QUICK_SEARCH_TIMEOUT)) {
            return _webElement().isDisplayed();
        } catch (NoSuchElementException ex) {
            log.error("IsDisplayed: Error has occurred during an attempt to get the element! Message: %s", ex.getMessage());
        }
        return false;
    }

    public Boolean IsHidden() {
        try (var ignored = new CustomImplicitTimeout(WebDriver(), QUICK_SEARCH_TIMEOUT)) {
            return !_webElement().isDisplayed();
        } catch (NoSuchElementException ex) {
            log.error("IsHidden: Error has occurred during an attempt to get the element! Message: %s", ex.getMessage());
        }
        return false;
    }
}
