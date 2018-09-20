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
            var navigationRow = header.NavigationRow;
            var shopPhone = "0123-456-789";

            TestStep("Open main page", TestBase::NavigateToBaseUrl);

            TestStep("Wait until Header is displayed", () -> waitUntil(x -> header.IsDisplayed()));

            TestStep("Validate Header's elements presence", () -> {
                Assertions.assertAll(() -> {
                    Assertions.assertTrue(header.BannerImage.IsDisplayed(), "Banner image hasn't been found!");
                    Assertions.assertTrue(navigationRow.ContactUsButton.IsDisplayed(), "Contact Us button hasn't been found!");
               });
            });

            TestStep("Validate Header's elements presence", () -> {
                var topMenuRow = header.TopMenuRow;

                Assertions.assertAll(() -> {
                    Assertions.assertTrue(header.BannerImage.IsDisplayed(), "Banner image hasn't been found!");
                    Assertions.assertTrue(navigationRow.ContactUsButton.IsDisplayed(), "Contact Us button hasn't been found!");

                    Assertions.assertEquals(navigationRow.ContactUsButton.ExpectedText, navigationRow.ContactUsButton.Text(), "Contact Us button text mismatch!");
                    Assertions.assertEquals(navigationRow.SignInButton.ExpectedText, navigationRow.SignInButton.Text(), "Sign In button text mismatch!");
                    Assertions.assertEquals(navigationRow.ShopPhoneContainerELement.ExpectedText + shopPhone, navigationRow.ShopPhoneContainerELement.Text(), "Shop Phone text mismatch!");
                    Assertions.assertEquals(shopPhone, navigationRow.ShopPhoneElement.Text(), "Shop Phone number mismatch!");

                    Assertions.assertEquals(topMenuRow.WomenLink.ExpectedText, topMenuRow.WomenLink.Text(), "Women link text mismatch!");
                    Assertions.assertEquals(topMenuRow.DressesLink.ExpectedText, topMenuRow.DressesLink.Text(), "Dresses link text mismatch!");
                    Assertions.assertEquals(topMenuRow.TshirtsLink.ExpectedText, topMenuRow.TshirtsLink.Text(), "T-Shirts link text mismatch!");
                });
            });
        });
    }
}
