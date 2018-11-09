package Selenium.Common.Configs;

import java.util.HashMap;
import java.util.Map;

public class LocalRegistry {
    private static final LocalRegistry instance = new LocalRegistry();

    private LocalRegistry() {}

    public static LocalRegistry getInstance() {
        return instance;
    }

    private Map<String, String> registry = new HashMap<>() {{
        put("driversPath", "src/main/resources/Drivers/");
    }};

    public String getValue(String key) {
        return registry.get(key);
    }
}
