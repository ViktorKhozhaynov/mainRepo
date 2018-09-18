package Selenium.Tests;

import Selenium.Common.Configs.Configuration;
import Selenium.Common.TestCategories.Smoke;
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
            var womenLink = MainPortal.Header.TopMenuRow.WomenHoverable;

            TestStep("Wait until the link is displayed and check the text", () -> {
                waitUntil(x -> MainPortal.Header.IsDisplayed());
                waitUntil(x -> MainPortal.Header.TopMenuRow.IsDisplayed());
                waitUntil(x -> MainPortal.Header.TopMenuRow.WomenHoverable.IsDisplayed());

                var tmp1 = womenLink.Text();
                Assert.assertEquals("'WOMEN' link text mismatch!", expectedLinkText.toUpperCase(), womenLink.Text());

                womenLink.Click();
            });
        });
    }
}
