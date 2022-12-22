import pyautogui

from framework.browser.browser import Browser
from framework.elements.button import Button
from framework.elements.text_box import TextBox
from framework.pages.base_page import BasePage
from selenium.webdriver.common.by import By

from framework.utils.random_utils import RandomUtils
from framework.utils.utils_graph_interface import GraphInterface
from tests.config.waits import Waits


class ProfilePage(BasePage):
    """
    Класс страницы Profile
    """

    search_condition = By.XPATH
    uniq_element_auth_page = "//div[@class='page-indicator' and text()='2 / 4']"
    locator_interests_unselect_all = Button(search_condition, "//label[@for='interest_unselectall']", "Unselect all")
    locator_button_next_profile = Button(search_condition, "//button[text()='Next']", 'Button Next ProfilePage')
    locator_upload_photo = Button(search_condition, "//a[@class='avatar-and-interests__upload-button']",
                                  'Button upload photo')

    def __init__(self):
        super().__init__(search_condition=self.search_condition, locator=self.uniq_element_auth_page,
                         page_name=self.__class__.__name__)

    def get_locator_value(self, interes):
        return Button(self.search_condition, f"//label[@for='{interes}']", "Interests value")

    def change_profile(self, index):
        unselect_all = self.locator_interests_unselect_all
        unselect_all.click()
        for i in index:
            self.get_locator_value(i).click()

    def click_button_next_profile(self):
        self.locator_button_next_profile.click()

    def upload_photo(self):
        click_upload = self.locator_upload_photo
        click_upload.click()
        self.click_button_next_profile()
        Browser.get_browser().get_driver().implicitly_wait(Waits.PAGE_LOAD_TIMEOUT_SEC)
        GraphInterface.move_to_mouse()
        return True
