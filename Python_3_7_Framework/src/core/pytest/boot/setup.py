# -*- coding: utf-8 -*-
import os

import pytest

import logging as log
from logging import root

from pre_commit.git import get_git_dir
from pre_commit.main import main as pre_commit
from pre_commit.util import CalledProcessError

# noinspection PyProtectedMember
from py._path.local import LocalPath


def working_dir(path: LocalPath) -> None:
    """ Sets current dir to the specified path """

    if os.getcwd() == path.strpath:
        return
    try:
        os.chdir(str(path))
    except OSError as e:
        pytest.exit(f'It is impossible to set current dir to: {path}, please set it manually: {e.strerror}')
    finally:
        log.debug(f'Working dir of pytest has been set to: {str(path)}')


def pre_commit_hooks() -> None:
    """ Sets up git hooks """

    try:
        get_git_dir()
        pre_commit(['install'])
    except CalledProcessError:
        log.warning('Git folder has not bee found! Proceed without git hooks setup step')


def logging_levels():
    root.handlers.clear()
    log.getLogger("urllib3").setLevel(log.WARNING)
    log.getLogger("selenium").setLevel(log.WARNING)
