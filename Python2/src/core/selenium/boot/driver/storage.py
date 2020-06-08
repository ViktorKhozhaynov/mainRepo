# -*- coding: utf-8 -*-
from typing import Union

from selenium.webdriver.remote.webdriver import WebDriver


class DriverStorage:
    """
    Represents a storage which sole purpose is to contain currently used WebDriver object
    """
    _driver: WebDriver = None

    @classmethod
    def get_driver(cls) -> Union[WebDriver, None]:
        return cls._driver

    @classmethod
    def set_driver(cls, value):
        cls._driver = value

    @classmethod
    def has_driver(cls):
        return cls._driver is not None
