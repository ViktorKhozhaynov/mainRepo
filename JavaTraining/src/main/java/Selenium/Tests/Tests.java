package Selenium.Tests;

import Selenium.Common.Configs.Configuration;
import Selenium.Common.TestEntities.TestBase;
import org.junit.Test;

public class Tests extends TestBase {
    private static final Configuration config = Configuration.getInstance();

    @Test
    public void TestNumberOne() {
        TestCase("This is the firest test I've written here!", () -> {
            var someVariable = "Blah Blah Blah!";
            log.info("Working Directory = " + System.getProperty("user.dir"));

            TestStep("This is the first test step! Voila!", () -> {
                log.info("First step ever!");
            });
        });
    }
}
