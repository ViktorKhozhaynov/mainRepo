# -*- coding: utf-8 -*-
from typing import Union

from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.remote.webelement import WebElement

from src.core.selenium.by import By
from src.core.selenium.html_entities.html_section import HtmlSection


class HtmlSectionList:
    def __init__(self, base_object: Union[WebDriver, WebElement], by: By, parent):
        self.base_object = base_object
        self.by = by
        self.parent = parent

    @property
    def _raw_list(self):
        return [HtmlSection(x, self.by, self.parent, from_web_element=True)
                for x in self.base_object.find_elements(**self.by.as_kwargs)]

    def __getitem__(self, item):
        return self._raw_list[item]

    def __len__(self):
        return len(self._raw_list)

    def __iter__(self):
        return self._raw_list.__iter__()
