# -*- coding: UTF-8 -*-
from src.core.by import By
from src.core.html_entities.html_element import HtmlElement
from src.core.html_entities.html_input_element import HtmlInputElement
from src.core.html_entities.html_section import HtmlSection


class LoanSection(HtmlSection):
    @property
    def promo_code_input(self):
        return HtmlInputElement(self.web_element, By.id('promocode'), self)

    @property
    def promo_code_apply_button(self):
        return HtmlElement(self.web_element, By.id('promocode-button'), self)

    @property
    def promo_code_button(self):
        return HtmlElement(self.web_element, By.id('promocode-button'), self)

    @property
    def promo_code_info_label(self):
        return HtmlElement(self.web_element, By.id('promo-code-info'), self)

    @property
    def total_repayable(self):
        return HtmlElement(self.web_element, By.id('calc_total_payable'), self)

    @property
    def total_repayable_with_discount(self):
        return HtmlElement(self.web_element, By.id('calc_new_total_payable'), self)

    def enter_promo_code(self, promo_code: str):
        self.promo_code_input.text = promo_code
        self.promo_code_button.click()
