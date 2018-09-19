package Selenium.Tests;

import Selenium.Common.TestEntities.TestCategories.Smoke;
import Selenium.Common.TestEntities.TestBase;
import Selenium.PageObject.MainPortal;
import org.junit.experimental.categories.Category;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class MainPageTests extends TestBase {
    protected final MainPortal MainPortal = new MainPortal(webDriver());

    @Test
    @Category(Smoke.class)
    public final void HeaderAppearanceTest() throws Exception {
        TestCase("Several test cases for Header section located on the main page", () -> {
            var header = MainPortal.Header;

            TestStep("Open main page", TestBase::NavigateToBaseUrl);

            TestStep("Wait until Header is displayed", () -> waitUntil(x -> header.IsDisplayed()));

            TestStep("Validate Header's elements presence", () -> {
                Assertions.assertAll(() -> {
                    Assertions.assertTrue(header.BannerImage.IsDisplayed(), "Banner image hasn't been found!");
                    Assertions.assertTrue(header.NavigationRow.ContactUsButton.IsDisplayed(), "Contact Us button hasn't been found!");
               });
            });
        });
    }
}
