# -*- coding: utf-8 -*-
from selenium.webdriver.remote.webdriver import WebDriver


class Page:
    """
    Base class for any class that is supposed to represent a full web page
    """

    def __init__(self, web_driver: WebDriver, parent):
        self.web_driver: WebDriver = web_driver
        self.parent = parent
