package Selenium.Tests;

import Selenium.Common.TestEntities.TestCategories.Smoke;
import Selenium.Common.TestEntities.TestBase;
import Selenium.PageObject.MainPortal;
import org.junit.Assert;
import org.junit.Test;
import org.junit.experimental.categories.Category;

public class MainPageTests extends TestBase {
    protected final MainPortal MainPortal = new MainPortal(webDriver());

    @Test
    @Category(Smoke.class)
    public final void TestNumberOne() throws Exception {
        TestCase("Several test cases for Women link on the main page", () -> {
            var expectedLinkText = "Women";

            TestStep("Open main page", TestBase::NavigateToBaseUrl);

            TestStep("Wait until the link is displayed and check the text", () -> {
                var womenLink = MainPortal.Header.TopMenuRow.WomenHoverable;

                waitUntil(x -> MainPortal.Header.IsDisplayed());
                waitUntil(x -> MainPortal.Header.TopMenuRow.IsDisplayed());
                waitUntil(x -> womenLink.IsDisplayed());

                Assert.assertEquals("'WOMEN' link text mismatch!", expectedLinkText.toUpperCase(), womenLink.Text());

                womenLink.Click();
            });
        });
    }
}
