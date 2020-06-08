# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.page_object.automation_practice.base.page import BasePage
from src.page_object.automation_practice.login.already_registered.section import AlreadyRegisteredSection
from src.page_object.automation_practice.login.create_account.section import CreateAccountSection
from src.test_data.dictionaries.user import AutoTestUser


class LoginPage(BasePage):
    @property
    def create_account_section(self):
        return CreateAccountSection(self.web_driver, By.id('create-account_form'), self)

    @property
    def already_registered_section(self):
        return AlreadyRegisteredSection(self.web_driver, By.id('login_form'), self)

    def wait_until_ready(self):
        self.create_account_section.wait_until_ready()
        self.already_registered_section.wait_until_ready()

    def login(self, user: AutoTestUser):
        self.already_registered_section.email_input.text = user.email
        self.already_registered_section.password_input.text = user.password

        self.already_registered_section.sign_in_button.click()
