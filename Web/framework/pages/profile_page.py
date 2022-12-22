import pyautogui

from framework.browser.browser import Browser
from framework.elements.button import Button
from framework.elements.text_box import TextBox
from framework.pages.base_page import BasePage
from selenium.webdriver.common.by import By

from framework.utils.random_utils import RandomUtils
from tests.config.waits import Waits


class ProfilePage(BasePage):
    """
    Класс страницы Profile
    """
    search_condition = By.XPATH
    uniq_element_auth_page = "//div[@class='page-indicator' and text()='2 / 4']"
    locator_interests_unselect_all = "//label[@for='interest_unselectall']"
    locator_interests_value_0 = f"//label[@for='{RandomUtils.random_interests(0)}']"
    locator_interests_value_1 = f"//label[@for='{RandomUtils.random_interests(1)}']"
    locator_interests_value_2 = f"//label[@for='{RandomUtils.random_interests(2)}']"
    upload_locator = "//a[@class='avatar-and-interests__upload-button']"
    locator_button_next_profile = "//button[text()='Next']"
    locator_upload_photo = "//a[@class='avatar-and-interests__upload-button']"
    locator_wait_image = "//li[text()='Please upload a picture']"

    def __init__(self):
        super().__init__(search_condition=self.search_condition, locator=self.uniq_element_auth_page,
                         page_name=self.__class__.__name__)

    def change_profile(self):
        unselect_all = Button(self.search_condition, self.locator_interests_unselect_all, self.__class__.__name__)
        unselect_all.click()
        interes_value_0 = Button(self.search_condition, self.locator_interests_value_0, self.__class__.__name__)
        interes_value_0.click()
        interes_value_1 = Button(self.search_condition, self.locator_interests_value_1, self.__class__.__name__)
        interes_value_1.click()
        interes_value_2 = Button(self.search_condition, self.locator_interests_value_2, self.__class__.__name__)
        interes_value_2.click()

    def click_button_next_profile(self):
        button_next = Button(self.search_condition, self.locator_button_next_profile, self.__class__.__name__)
        button_next.click()

    def upload_photo(self):
        help_exit = Button(self.search_condition, self.locator_upload_photo, self.__class__.__name__)
        help_exit.click()
        self.click_button_next_profile()
        Browser.get_browser().get_driver().implicitly_wait(Waits.PAGE_LOAD_TIMEOUT_SEC)
        pyautogui.sleep(5)
        pyautogui.moveTo(200, 285, 1)
        pyautogui.click()
        pyautogui.sleep(1)
        x1 = RandomUtils.random_navigate_for_image()[0]
        y1 = RandomUtils.random_navigate_for_image()[1]
        pyautogui.moveTo(x1, y1, 1)
        pyautogui.click(clicks=2)
        return True
