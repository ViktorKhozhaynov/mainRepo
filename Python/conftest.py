# -*- coding: UTF-8 -*-

import os
import pytest

from _pytest.config.argparsing import Parser
from _pytest.nodes import Item
from _pytest.runner import CallInfo
from py._path.local import LocalPath
from _pytest.config import Config
import logging as log

from src.core.boot.driver_storage import DriverStorage
from src.core.helpers.screenshot import ScreenShot


# General setup hooks
def pytest_addoption(parser: Parser):
    """ Pytest hook that adds options which can be later used as a pytest arguments """

    manual = "Browser type, here's you can chose which browsers you want to test against"
    parser.addoption('--browser', action='store', help=manual, type=str, default='chrome')


def pytest_configure(config: Config):
    """ Basic configuration of pytest """

    set_working_dir(config.rootdir)


# Per-test hooks
def pytest_runtest_makereport(item: Item, call: CallInfo):
    if call.when == 'call' and call.excinfo is not None:
        ScreenShot.take(web_driver=DriverStorage.get_driver(), test_name=item.name)


def set_working_dir(path: LocalPath) -> None:
    """ Sets current dir to the specified path """
    if os.getcwd() == path.strpath:
        return
    try:
        os.chdir(str(path))
    except OSError as e:
        pytest.exit(f'It is impossible to set current dir to: {path}, please set it manually: {e.strerror}')
    finally:
        log.debug(f'Working dir of pytest has been set to: {str(path)}')
