package Selenium.Common.HtmlEntities;

import Selenium.Common.Helpers.CustomImplicitTimeout;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.net.URL;
import java.util.Optional;
import java.util.function.Supplier;

public class HtmlImageElement extends HtmlElement {
    public HtmlImageElement(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlImageElement(Supplier<WebElement> webElement, By by) {
        super(webElement, by);
    }

    public Optional<String> Src() {
        try (var ignore = new CustomImplicitTimeout(WebDriver(), 2)) {
            return Optional.of(_webElement().getAttribute("src"));
        } catch (Exception ex) {
            log.warn("An error has occurred while getting src attribute of an IMG element! Message: %s", ex.getMessage());
        }
        return Optional.empty();
    }

    //region methods

    public Optional<BufferedImage> TryGetImage() {
        try {
            String logoSRC = Src().orElseThrow(() -> new Exception("No Src attribute has been found in the element '" + InternalId() + "'!"));

            URL imageURL = new URL(logoSRC);
            return Optional.of(ImageIO.read(imageURL));
        } catch (Exception ex) {
            log.warn("An error has occurred while downloading the image! Message: %s", ex.getMessage());
        }
        return Optional.empty();
    }
    //endregion
}
