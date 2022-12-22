import pyautogui

from framework.utils.random_utils import RandomUtils


class GraphInterface:
    @staticmethod
    def move_to_mouse():
        pyautogui.sleep(5)
        pyautogui.moveTo(200, 285, 1)
        pyautogui.click()
        pyautogui.sleep(1)
        x1 = RandomUtils.random_navigate_for_image()[0]
        y1 = RandomUtils.random_navigate_for_image()[1]
        pyautogui.moveTo(x1, y1, 1)
        pyautogui.click(clicks=2)
