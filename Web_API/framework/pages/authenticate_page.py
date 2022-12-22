from framework.elements.button import Button
from framework.elements.text_box import TextBox
from framework.pages.base_page import BasePage
from selenium.webdriver.common.by import By

from framework.utils.random_utils import RandomUtils


class AuthenticatePage(BasePage):
    """
    Класс страницы Authenticate
    """
    search_condition = By.XPATH
    uniq_element_auth_page = "//div[@class='page-indicator' and text()='1 / 4']"

    locaror_input_password = TextBox(search_condition, "//input[@placeholder = 'Choose Password']",
                                     "Password field")
    locator_input_email = TextBox(search_condition, "//input[@placeholder='Your email']", "Email field")
    locator_input_domain = TextBox(search_condition, "//input[@placeholder='Domain']", "Domain field")
    locator_button_other = Button(search_condition, "//div[@class='dropdown__opener']", "Other")
    locator_other_value = Button(search_condition,
                                 f"//div[@class='dropdown__list-item' and text()='{RandomUtils.random_email()['other']}']",
                                 "Check other")
    locator_do_not_accept = Button(search_condition, "//span[@class='checkbox__box']", 'Accept the Terms & Conditions')
    locator_button_next = Button(search_condition, "//a[@class='button--secondary']", "Button Next")
    button_help_exit = Button(search_condition, "//div[contains(@class, 'align__cell u-right')]", "Exit help window")
    timer_loc = TextBox(search_condition, "//div[contains(@class, 'timer')]", "Timer field")
    locator_cookies = Button(search_condition, "//button[text()='Not really, no']", "Accept cookies")

    def __init__(self):
        super().__init__(search_condition=self.search_condition, locator=self.uniq_element_auth_page,
                         page_name=self.__class__.__name__)

    def send_password(self):
        input_pasword = self.locaror_input_password
        input_pasword.clear_field()
        input_pasword.send_keys(RandomUtils.random_password())

    def send_email(self):
        input_email = self.locator_input_email
        input_email.clear_field()
        input_email.send_keys(RandomUtils.email['your_email'])

    def send_domain(self):
        input_domain = self.locator_input_domain
        input_domain.clear_field()
        input_domain.send_keys(RandomUtils.email['your_domain'])

    def click_button_other(self):
        self.locator_button_other.click()

    def send_other_value(self):
        self.locator_other_value.click()

    def click_button_do_not_accept(self):
        self.locator_do_not_accept.click()

    def click_button_next(self):
        self.locator_button_next.click()

    def exit_help_window(self):
        self.button_help_exit.click()

    def get_timer_value(self):
        timer_field = self.timer_loc
        time_start = timer_field.find_element().text
        sec = int(time_start.split(':')[-1])
        return sec

    def accept_cookies(self):
        cookie = self.locator_cookies
        cookie.click()
        try:
            cookie.find_element()
        except:
            return True
        return False
