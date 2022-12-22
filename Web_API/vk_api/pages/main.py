from selenium.common.exceptions import TimeoutException, NoSuchElementException
from selenium.webdriver.common.by import By

from framework.constants.random import COUNT_LATTERS_MESSAGE
from framework.elements.button import Button
from framework.elements.text_box import TextBox
from framework.pages.base_page import BasePage
from framework.utils.get_data import ParserData
from framework.utils.random_utils import RandomUtils
from vk_api.forms.LeftMenuForm import LeftMenuForm
from vk_api.vk_api_utils.vk_api_utils import VkApiUtils
from vk_api.vk_models.Post import Post
from vk_api.vk_models.User import User


class MainVkPage(BasePage):
    """"
    Класс главной страницы ВК
    """
    uniq_elem_main_page = "//div[@class='stories_feed_cont']"
    elem_btn_my_page = Button(By.XPATH, "//li[@id='l_pr']", 'нажатие кнопки моей страницы')

    def __init__(self):
        super().__init__(By.XPATH, locator=self.uniq_elem_main_page,
                         page_name="Главная страница")

    def click_button_my_page(self):
        """
        Функция нажатия кнопки Моя страница
        """
        left_menu = LeftMenuForm(self.elem_btn_my_page, 'Кнопка Моя Страница')
        left_menu.click_element_form()

    def create_post(self):
        """
        Функция для создания поста на стене
        """
        api = VkApiUtils(ParserData.get_data('vk_test_data', 'url'))
        user = api.get_current_user()
        post_api = api.create_post_my_wall(RandomUtils.random_letters(COUNT_LATTERS_MESSAGE), user)
        post = Post(post_api[0], post_api[1], post_api[2])
        return post

    def get_post_UI(self, user, post):
        """
        Функция проверки поста на странице, через UI
        """
        element_name = TextBox(By.XPATH,
                               f"//div[@id='post{user.id}_{post.id_post}']//*[@class='post_author']//a[@href='/id{user.id}']",
                               'Имя отправившего последний пост')
        element_text = TextBox(By.XPATH,
                               f"//div[@id='post{user.id}_{post.id_post}']//div[contains(@class,'wall_post_text')]",
                               'Текст последнего поста')
        element_photo = TextBox(By.XPATH, f"//div[@id='wpt{user.id}_{post.id_post}']//a",
                                'Файл последнего поста')
        try:
            element_name.scroll_by_script()
        except TimeoutException:
            return "Пост удалён"

        user_name = element_name.find_element().text.split()
        message = element_text.find_element().text
        try:
            file = element_photo.get_attribute('href').split('_')[-1]
        except TimeoutException:
            post = Post(post.id_post, message[1:-1], User(user.id, user_name[0], user_name[1]), file=None,
                        like=post.like, comment=post.comment)
            return post
        get_post = Post(post.id_post, message[1:-1], User(user.id, user_name[0], user_name[1]), file=file,
                        like=post.like,
                        comment=post.comment)
        return get_post

    def change_post(self, user, post, new_message):
        """
        Функция изменения поста
        (Изменить комментарий и добавить фото).
        """
        api = VkApiUtils(ParserData.get_data('vk_test_data', 'url'))
        photo = api.get_last_photos(user)
        change_post = api.change_last_post(user, new_message, post, photo)
        post = Post(change_post['response']['post_id'], new_message, user, file=photo)
        return post

    def create_comment(self, user, new_message, post):
        """
        Функция создания комментария к посту.
        """
        api = VkApiUtils(ParserData.get_data('vk_test_data', 'url'))
        comment = api.create_comment_api(user, new_message, post)
        id_comment = comment['response']['comment_id']
        post = Post(post.id_post, new_message, user, post.file, post.like, id_comment)
        return post

    def like_click(self, user, post):
        """
        Функция добавления лайка к посту.
        """
        btn_like = Button(By.XPATH,
                          f"//div[@id='post{user.id}_{post.id_post}']//div[contains(@class,'PostButtonReactions__icon')]",
                          'Поставить лайк')
        btn_like.click()
