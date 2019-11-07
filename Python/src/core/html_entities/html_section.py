# -*- coding: UTF-8 -*-
from selenium.common.exceptions import NoSuchElementException
from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.remote.webelement import WebElement
from selenium.webdriver.common.action_chains import ActionChains
from typing import Union
import logging as log

from src.core.boot.driver_storage import DriverStorage
from src.core.by import By


class HtmlSection:
    """
    Representation of a DOM section of any size
    """
    def __init__(self, base_object: Union[WebDriver, WebElement], by: By, parent):
        self.base_object: Union[WebDriver, WebElement] = base_object
        self.by = by
        self.parent = parent

    @property
    def web_element(self):
        return self.base_object.find_element(self.by.type, self.by.locator)

    def click(self):
        self.web_element.click()

    def hover(self):
        hover = ActionChains(DriverStorage.get_driver()).move_to_element(self.web_element)
        hover.perform()

    @property
    def text(self):
        return self.web_element.text

    @property
    def name(self):
        return self.web_element.tag_name

    @property
    def internal_id(self):
        return f'{self.name}.{self.web_element.id}'

    @property
    def is_present(self):
        try:
            bool(self.web_element)
            return True
        except NoSuchElementException as e:
            log.debug(f'Element has not been found! Locator {self.by.locator} by {self.by.type} \n {e.msg}')
        return False

    @property
    def is_absent(self):
        return len(self.base_object.find_elements(self.by.type, self.by.locator)) == 0

    @property
    def is_displayed(self):
        try:
            return self.web_element.is_displayed()
        except NoSuchElementException as e:
            log.debug(f'Element has not been found! Locator {self.by.locator} by {self.by.type} \n {e.msg}')
        return False

    @property
    def is_hidden(self):
        return not self.is_displayed
