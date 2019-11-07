# -*- coding: UTF-8 -*-
from selenium.webdriver.common.by import By as DefautBy


class By:
    """
    Encapsulates both locator type and locator itself
    This class basically overrides default Selenium 'By' class
    """

    def __init__(self, by: str, locator: str):
        self.type = by
        self.locator = locator

    @staticmethod
    def id(locator: str):
        return By(DefautBy.ID, locator)

    @staticmethod
    def css(locator: str):
        return By(DefautBy.CSS_SELECTOR, locator)

    @staticmethod
    def xpath(locator: str):
        return By(DefautBy.XPATH, locator)

    @staticmethod
    def name(locator: str):
        return By(DefautBy.NAME, locator)

    @staticmethod
    def class_name(locator: str):
        return By(DefautBy.CLASS_NAME, locator)

    @staticmethod
    def tag_name(locator: str):
        return By(DefautBy.TAG_NAME, locator)
