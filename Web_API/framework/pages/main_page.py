from framework.elements.button import Button
from framework.pages.base_page import BasePage
from selenium.webdriver.common.by import By


class MainPage(BasePage):
    """
    Класс страницы Main
    """
    search_condition = By.XPATH
    uniq_locator_main_page = "//div[@class='logo__icon']"
    locator_button_here = "//a[@class='start__link']"

    def __init__(self):
        super().__init__(search_condition=self.search_condition, locator=self.uniq_locator_main_page,
                         page_name=self.__class__.__name__)

    def click_button_here_to_go(self):
        Button(self.search_condition, self.locator_button_here, self.__class__.__name__).actions_click()
