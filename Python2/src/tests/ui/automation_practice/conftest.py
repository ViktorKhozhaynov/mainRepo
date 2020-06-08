# -*- coding: utf-8 -*-
from pytest import fixture

from src.page_object.automation_practice.root import Root
from src.test_data.dictionaries.user import test_user


@fixture(scope='function')
def automation_practice(wd):
    """ Returns Root of the automation practicing portal """

    return Root().navigate()


@fixture(scope='function')
def login(automation_practice: Root):
    """ Login to the Main Page """

    return automation_practice.login(test_user)


@fixture(scope='function', autouse=True)
def driver_clean_up(wd):
    """ Quits the driver """

    yield
    wd.quit()
