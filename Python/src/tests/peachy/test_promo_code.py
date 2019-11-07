# -*- coding: UTF-8 -*-
from allure import step, testcase as tc
from src.core.waiters.until import wait_until


class TestPromoCode:
    @tc('FT001')
    def test_promo_code_application(self, main_page, promo_code):
        with step('Open main page. Validate no overlay has been shown. Save current repayable value'):
            main_page.wait_until_ready()
            assert main_page.discount_overlay.is_absent, 'Discount overlay appeared even though it should not!'

            initial_repayable = main_page.loan_section.total_repayable.text

        with step(f'Enter promo code - {promo_code}. Wait for the new repayable to be calculated'):
            main_page.loan_section.enter_promo_code(promo_code)

            wait_until(lambda: main_page.loan_section.total_repayable_with_discount.is_displayed)

        with step('Verify promo code has been applied correctly'):
            expected_repayable = float(initial_repayable[1:]) - 5
            actual_repayable = float(main_page.loan_section.total_repayable_with_discount.text[1:])
            assert expected_repayable == actual_repayable, 'After aplying the promo code ' \
                                                           'repayable did not change as expected!'

    @tc('FT002')
    def test_invalid_promo_code(self, main_page, invalid_promo_code):
        with step('Open main page. Validate no overlay has been shown'):
            main_page.wait_until_ready()
            assert main_page.discount_overlay.is_absent, 'Discount overlay appeared even though it should not!'

        with step(f'Enter invalid promo code - {invalid_promo_code}. Wait until error label appears'):
            main_page.loan_section.enter_promo_code(invalid_promo_code)
            wait_until(lambda: main_page.loan_section.promo_code_info_label.is_displayed)

            assert main_page.loan_section.promo_code_info_label.text == 'Promo code is not valid'
