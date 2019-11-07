# -*- coding: UTF-8 -*-
import time
import types
import inspect
import config


def wait_until(condition: types.LambdaType, cycles=None, timeout=None) -> None:
    """
    Wait's until the condition returns True
    :param condition: Lambda expression that sets a condition
    :param cycles: Number of repetitions of evaluating the condition
    :param timeout: Timeout that's put between cycles
    """
    if cycles is None:
        cycles = config.default_explicit_wait_cycle_number

    if timeout is None:
        timeout = config.default_explicit_wait_cycle_timeout

    for _ in range(cycles):
        time.sleep(timeout)
        if condition():
            return
    raise WaitException(f'Lambda expression [{inspect.getsource(condition).strip()}] '
                        f'did not work after the set timeout!')


class WaitException(Exception):
    """ Custom exception that signals that condition hasn't been met """
    def __init__(self, message):
        self.message = message
