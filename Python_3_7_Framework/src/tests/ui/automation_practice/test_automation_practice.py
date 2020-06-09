# -*- coding: utf-8 -*-
from pytest import mark

from src.core.allure.decorators import jira
from src.core.allure.methods import step
from src.core.common.waiters.until import wait_until
from src.page_object.automation_practice.root import Root


@jira('TEST-XX')
@mark.selenium
class TestAutomationPractice:
    def test_example(self, login, automation_practice: Root):
        with step('Step 1 Example'):
            wait_until(lambda: automation_practice.main_page.header_section.is_displayed)
            assert automation_practice.main_page.header_section.login_button.is_hidden, \
                'Oh no! Login button is unexpectedly displayed!'

        with step('Step 2 Example'):
            assert 1 == 2, 'Oh no, it does not!'
