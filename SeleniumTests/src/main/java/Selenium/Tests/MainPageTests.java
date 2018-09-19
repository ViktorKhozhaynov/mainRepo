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
            var womenLink = MainPortal.Header.TopMenuRow.WomenLink;

            TestStep("Open main page", TestBase::NavigateToBaseUrl);

            TestStep("Wait until the link is displayed", () -> {
                waitUntil(x -> womenLink.IsDisplayed());
            });

            TestStep("Validate the text of the link", () -> {
                Assert.assertEquals("'WOMEN' link text mismatch!", womenLink.ExpectedText, womenLink.Text());

                womenLink.Click();
            });
        });
    }
}
