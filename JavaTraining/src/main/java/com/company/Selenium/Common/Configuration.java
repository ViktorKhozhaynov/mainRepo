package com.company.Selenium.Common;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

import java.io.FileInputStream;
import java.io.InputStreamReader;

public class Configuration {
    private static final String CONFIG_PATH = "src/main/java/com/company/Selenium/config.json";

    private static final Logger logger = LogManager.getFormatterLogger(Configuration.class.getName());
    private static JSONObject _jsonObject;
    private static final Configuration config = new Configuration();

    private Configuration() {
        try {
            _jsonObject = (JSONObject) new JSONParser().parse(new InputStreamReader(new FileInputStream(CONFIG_PATH)));
        } catch (Exception ex) {
            logger.error("Parse Error has occurred during configuration parsing!");
            logger.error("Error message: %s", ex.getMessage());
        }
    }

    public String getValue(String key){
        return (String) _jsonObject.get(key);
    }

    public static Configuration getInstance() {
        return config;
    }
}