# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.html_entities.html_input_element import HtmlInputElement
from src.core.selenium.html_entities.html_section import HtmlSection


class SearchSection(HtmlSection):
    @property
    def search_input(self):
        return HtmlInputElement(self.web_driver, By.id('search_query_top'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.search_input.is_displayed)
