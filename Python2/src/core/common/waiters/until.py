# -*- coding: utf-8 -*-
import inspect
import time
import types

from src.core.common.waiters.implicit_wait import implicitly_wait

DEFAULT_CYCLES_NUMBER = 20
DEFAULT_TIMEOUT = 1


def wait_until(condition: types.LambdaType, cycles=DEFAULT_CYCLES_NUMBER, timeout=DEFAULT_TIMEOUT) -> None:
    """
    Waits until the condition returns True

    :param condition: Lambda expression that sets a condition
    :param cycles: Number of repetitions of evaluating the condition
    :param timeout: Timeout that's put between cycles
    """

    if becomes_true(condition, cycles, timeout):
        return

    raise WaitException(f'[{inspect.getsource(condition).strip()}] did not happen after the wait!')


def becomes_true(condition: types.LambdaType, cycles=DEFAULT_CYCLES_NUMBER, timeout=DEFAULT_TIMEOUT) -> bool:
    """
    Cycles until condition is True or returns False

    :param condition: Lambda expression that sets a condition
    :param cycles: Number of repetitions of evaluating the condition
    :param timeout: Timeout that's put between cycles
    """

    with implicitly_wait(1):
        for _ in range(cycles):
            if condition():
                return True
            time.sleep(timeout)

    return False


class WaitException(Exception):
    """ Custom exception that signals that condition hasn't been met """

    def __init__(self, message):
        self.message = message
