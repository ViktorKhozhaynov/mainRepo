package com.company.Selenium.Tests;

import com.company.Selenium.Common.Config;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.junit.Test;

public class Tests {
    private static final Logger logger = LogManager.getFormatterLogger(Tests.class.getName());

    @Test
    public void Test() {
        System.out.println("Working Directory = " +
                System.getProperty("user.dir"));
        Config tmp = Config.getInstance();
        logger.info(tmp.getValue("driver"));
    }
}
