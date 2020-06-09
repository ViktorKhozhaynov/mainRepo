# -*- coding: utf-8 -*-
from _pytest.config.argparsing import Parser
from _pytest.nodes import Item
from _pytest.runner import CallInfo

# noinspection PyProtectedMember
from _pytest.config import Config
from pytest import fixture

from src.core.pytest.boot import setup, check
from src.core.selenium.boot.driver.storage import DriverStorage
from src.core.common.helpers.screenshot import ScreenShot


# General setup hooks
def pytest_addoption(parser: Parser):
    """ Pytest hook that adds options which can be later used as a pytest arguments """

    manual = "Browser type, here's you can chose which browsers you want to test against"
    parser.addoption('--browser', action='store', help=manual, type=str, default='chrome')

    manual = "Headless bool key, if True - starts browser in headless mode"
    parser.addoption('--headless', action='store', help=manual, type=bool, default=False)

    manual = "Remote bool key, if True - tries to execute tests on a standalone remote browser"
    parser.addoption('--remote', action='store', help=manual, type=bool, default=False)


def pytest_configure(config: Config):
    """ Basic configuration of pytest """

    check.min_python_version(config.inicfg.get('python_ver'))

    setup.pre_commit_hooks()
    setup.working_dir(config.rootdir)
    setup.logging_levels()


def pytest_runtest_makereport(item: Item, call: CallInfo):
    if call.when in ('call', 'setup') and call.excinfo is not None and DriverStorage.has_driver():
        ScreenShot.take(web_driver=DriverStorage.get_driver(), test_name=item.name)


@fixture(scope='session')
def browser_type(request):
    """ Passes a command line argument into a fixture """
    return request.config.getoption('browser')


@fixture(scope='session')
def headless(request):
    """ Passes a command line argument into a fixture """
    return request.config.getoption('headless')


@fixture(scope='session')
def remote(request):
    """ Passes a command line argument into a fixture """
    return request.config.getoption('remote')
