# -*- coding: UTF-8 -*-
from uuid import uuid4
from pytest import fixture
from src.page_object.peachy.main_page import MainPage

PEACHY_BASE_URL = 'https://www.peachy.co.uk/'


@fixture(scope='function', autouse=True)
def open_main_page(wd):
    """ Opens base URL """
    yield wd.get(PEACHY_BASE_URL)
    wd.quit()


@fixture(scope='function')
def main_page(wd):
    """ Returns Main Page object """
    return MainPage(wd)


@fixture(scope='session')
def promo_code():
    """ Returns valid promo code for testing """
    return '5OFF'


@fixture(scope='session')
def invalid_promo_code():
    """ Returns valid promo code for testing """
    return str(uuid4())

