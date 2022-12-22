from framework.pages.base_page import BasePage
from selenium.webdriver.common.by import By
from framework.elements.text_box import TextBox
from framework.elements.label import Label
from framework.elements.button import Button
from selenium.webdriver.common.keys import Keys
from framework.browser.browser import Browser
# from


class HomePage(BasePage):
    search_condition = By.XPATH
    lbl_login_loc = "//div[@class='logo__icon']"

    def __init__(self):
        super().__init__(search_condition=HomePage.search_condition, locator=HomePage.lbl_login_loc,
                         page_name=self.__class__.__name__)
        super().wait_for_page_opened()

        # self.lbl_login = Label(search_condition=HomePage.search_condition, locator=HomePage.lbl_login_loc,
        #                        name="Login button")




