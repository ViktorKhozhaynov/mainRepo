# -*- coding: UTF-8 -*-
from selenium.webdriver.remote.webdriver import WebDriver


class DriverStorage:
    """
    Represents a storage which sole purpose is to contain currently used WebDriver object
    """
    _driver: WebDriver = None

    @classmethod
    def get_driver(cls):
        return cls._driver

    @classmethod
    def set_driver(cls, value):
        cls._driver = value
