# -*- coding: UTF-8 -*-
from typing import Union

from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.remote.webelement import WebElement

from src.core.by import By
from src.core.html_entities.html_section import HtmlSection


class HtmlElement(HtmlSection):
    """
    Representation of the smallest HTML unit in the DOM
    """

    def __init__(self, base_object: Union[WebDriver, WebElement], by: By, parent, expected_text: str = None):
        super().__init__(base_object, by, parent)
        self.expected_text = expected_text

    def has_expected_text(self) -> bool:
        """
        Compares expected text with current text
        :return: bool result
        """

        # keep this condition as is
        # if use 'if self.expected_text' empty string might be evaluated as False
        if self.expected_text is not None:
            return self.text == self.expected_text
        else:
            raise ExpectedTextNotFoundException('expected_text attribute has not been found in the Html Element!')


class ExpectedTextNotFoundException(Exception):
    """ Custom exception that signals that expected text hasn't been set when it should have been """
    def __init__(self, message):
        self.message = message
