# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.html_entities.html_button_element import HtmlButtonElement
from src.core.selenium.html_entities.html_input_element import HtmlInputElement
from src.core.selenium.html_entities.html_section import HtmlSection


class AlreadyRegisteredSection(HtmlSection):
    @property
    def email_input(self):
        return HtmlInputElement(self.web_element,
                                By.xpath('.//div[@class="form-group" and label[@for="email"]]/input'),
                                self)

    @property
    def password_input(self):
        return HtmlInputElement(self.web_element,
                                By.xpath('.//div[@class="form-group" and label[@for="passwd"]]//input'),
                                self)

    @property
    def forgot_password_button(self):
        return HtmlButtonElement(self.web_element, By.css('p.lost_password a'), self)

    @property
    def sign_in_button(self):
        return HtmlButtonElement(self.web_driver, By.id('SubmitLogin'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.sign_in_button.is_displayed)
        wait_until(lambda: self.sign_in_button.is_enabled)
