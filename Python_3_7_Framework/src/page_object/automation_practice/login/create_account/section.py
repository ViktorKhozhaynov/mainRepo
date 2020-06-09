# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.html_entities.html_button_element import HtmlButtonElement
from src.core.selenium.html_entities.html_input_element import HtmlInputElement
from src.core.selenium.html_entities.html_section import HtmlSection


class CreateAccountSection(HtmlSection):
    @property
    def email_input(self):
        return HtmlInputElement(self.web_element,
                                By.xpath('.//div[@class="form-group" and label[@for="email_create"]]/input'),
                                self)

    @property
    def create_account_button(self):
        return HtmlButtonElement(self.web_driver, By.id('SubmitCreate'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.create_account_button.is_displayed)
        wait_until(lambda: self.create_account_button.is_enabled)
