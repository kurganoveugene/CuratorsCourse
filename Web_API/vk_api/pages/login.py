from framework.elements.button import Button
from framework.elements.text_box import TextBox
from framework.pages.base_page import BasePage
from selenium.webdriver.common.by import By
from framework.utils.get_data import ParserData


class VkLogin(BasePage):
    """
    Класс страницы VkLogin
    """

    login_loc = "//input[@id='index_email']"
    elem_login_field = TextBox(By.XPATH, login_loc, 'Ввод логина')
    elem_password_field = TextBox(By.XPATH, "//input[@id='index_pass']", 'Ввод пароля')
    elem_btn_login_in = Button(By.XPATH, "//button[@id='index_login_button']", 'Нажатие кнопки входа в VK')

    def __init__(self):
        super().__init__(By.XPATH, locator=self.login_loc, page_name="Страница логирования")

    def send_login_vk(self):
        """
        Функция для ввода логина
        """
        self.elem_login_field.clear_field()
        self.elem_login_field.send_keys(ParserData().get_data('vk_test_data', 'login'))

    def send_password_vk(self):
        """
        Функция для ввода пароля
        """
        self.elem_password_field.clear_field()
        self.elem_password_field.send_keys(ParserData().get_data('vk_test_data', 'password'))

    def click_button_login(self):
        """
        Кнопка входа в VK
        """
        self.elem_btn_login_in.click()
