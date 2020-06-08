# -*- coding: utf-8 -*-
import sys

import pytest


def min_python_version(version: str) -> None:
    """ Checks if current version of python is acceptable """

    if isinstance(version, str):
        ver = tuple(int(x) for x in version.split('.'))
    elif isinstance(version, tuple):
        ver = version
    else:
        raise UnsupportedPythonVersionException('The python version you are currently using is not supported!')

    if not sys.version_info >= ver:
        pytest.exit(f'For the test to be executed properly you have to use python of {ver} of higher!')


class UnsupportedPythonVersionException(Exception):
    def __init__(self, message):
        super().__init__(message)
