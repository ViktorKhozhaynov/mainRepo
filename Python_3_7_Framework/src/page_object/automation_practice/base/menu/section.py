# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.html_entities.html_button_element import HtmlButtonElement
from src.core.selenium.html_entities.html_section import HtmlSection


class MenuSection(HtmlSection):
    @property
    def women_button(self):
        return HtmlButtonElement(self.web_element,
                                 By.xpath('.//a[@class="sf-with-ul" and @title="Women"]'),
                                 self)

    @property
    def dresses_button(self):
        return HtmlButtonElement(self.web_element,
                                 By.xpath('.//a[@class="sf-with-ul" and @title="Dresses"]'),
                                 self)

    @property
    def t_shirts_button(self):
        return HtmlButtonElement(self.web_element,
                                 By.xpath('.//a[@class="sf-with-ul" and @title="T-shirts"]'),
                                 self)

    def wait_until_ready(self):
        wait_until(lambda: self.women_button.is_displayed)
        wait_until(lambda: self.dresses_button.is_displayed)
        wait_until(lambda: self.t_shirts_button.is_displayed)
