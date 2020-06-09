# -*- coding: utf-8 -*-
from selenium.webdriver.common.by import By as DefaultBy


class By:
    """
    Encapsulates both locator type and locator itself
    This class basically overrides default Selenium 'By' class
    """

    def __init__(self, by: str, locator: str):
        self.type = by
        self.locator = locator

    @property
    def as_kwargs(self):
        return {'by': self.type, 'value': self.locator}

    @staticmethod
    def id(locator: str):
        return By(DefaultBy.ID, locator)

    @staticmethod
    def css(locator: str):
        return By(DefaultBy.CSS_SELECTOR, locator)

    @staticmethod
    def xpath(locator: str):
        return By(DefaultBy.XPATH, locator)

    @staticmethod
    def name(locator: str):
        return By(DefaultBy.NAME, locator)

    @staticmethod
    def class_name(locator: str):
        return By(DefaultBy.CLASS_NAME, locator)

    @staticmethod
    def tag_name(locator: str):
        return By(DefaultBy.TAG_NAME, locator)
