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
    locaror_input_password = "//input[@placeholder = 'Choose Password']"
    locator_input_email = "//input[@placeholder='Your email']"
    locator_input_domain = "//input[@placeholder='Domain']"
    locator_button_other = "//span[@class='icon icon-chevron-down']"
    locator_other_value = f"//div[@class='dropdown__list-item' and text()='{RandomUtils.random_email()['other']}']"
    locator_do_not_accept = "//span[@class='icon icon-check checkbox__check']"
    locator_button_next = "//a[@class='button--secondary']"
    locator_interests_unselect_all = "//label[@for='interest_unselectall']"
    locator_interests_value_0 = f"//label[@for='{RandomUtils.random_interests(0)}']"
    locator_interests_value_1 = f"//label[@for='{RandomUtils.random_interests(1)}']"
    locator_interests_value_2 = f"//label[@for='{RandomUtils.random_interests(2)}']"
    upload_locator = "//a[@class='avatar-and-interests__upload-button']"
    button_help_exit = "//button[@class='button button--solid button--blue help-form__send-to-bottom-button']"
    timer_loc = "//div[@class='timer timer--white timer--center']"
    locator_cookies = "//button[@class = 'button button--solid button--transparent']"

    def __init__(self):
        super().__init__(search_condition=self.search_condition, locator=self.uniq_element_auth_page,
                         page_name=self.__class__.__name__)

    def pasword_input(self):
        input_pasword = TextBox(self.search_condition, self.locaror_input_password, self.__class__.__name__)
        input_pasword.clear_field()
        input_pasword.send_keys(RandomUtils.random_password())

    def email_input(self):
        input_email = TextBox(self.search_condition, self.locator_input_email, self.__class__.__name__)
        input_email.clear_field()
        input_email.send_keys(RandomUtils.email['your_email'])

    def domain_input(self):
        input_domain = TextBox(self.search_condition, self.locator_input_domain, self.__class__.__name__)
        input_domain.clear_field()
        input_domain.send_keys(RandomUtils.email['your_domain'])

    def click_button_other(self):
        other_button = Button(self.search_condition, self.locator_button_other, self.__class__.__name__)
        other_button.click()

    def click_other_value(self):
        other = Button(self.search_condition, self.locator_other_value, self.__class__.__name__)
        other.click()

    def click_button_do_not_accept(self):
        button_do_not_accept = Button(self.search_condition, self.locator_do_not_accept, self.__class__.__name__)
        button_do_not_accept.click()

    def click_button_next(self):
        button_next = Button(self.search_condition, self.locator_button_next, self.__class__.__name__)
        button_next.click()

    def help_window(self):
        help_exit = Button(self.search_condition, self.button_help_exit, self.__class__.__name__)
        help_exit.click()

    def timer(self):
        timer_field = TextBox(self.search_condition, self.timer_loc, self.__class__.__name__)
        time_start = timer_field.find_element().text
        sec = int(time_start.split(':')[-1])
        return sec

    def add_cookies(self):
        add_cookie = Button(self.search_condition, self.locator_cookies, self.__class__.__name__)
        add_cookie.click()
        try:
            add_cookie.find_element()
        except:
            return True
        return False
