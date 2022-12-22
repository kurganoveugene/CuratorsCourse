from framework.constants.random import COUNT_LATTERS_MESSAGE
from framework.utils.get_data import ParserData
from framework.utils.random_utils import RandomUtils
from vk_api.pages.login import VkLogin
from vk_api.pages.main import MainVkPage
from vk_api.vk_api_utils.vk_api_utils import VkApiUtils


class TestVk:
    def test_vk(self, create_browser, base_fix):
        vk_login = VkLogin()
        login = vk_login.is_opened()
        assert login, 'Страница логирования не открылась'
        vk_login.send_login_vk()  # Ввод логина
        vk_login.send_password_vk()  # Ввод пароля
        vk_login.click_button_login()  # Нажатие кнопки вход
        main_page = MainVkPage()
        main = main_page.is_opened()
        assert main, "Страница Main не открылась"
        main_page.click_button_my_page()  # Нажатие кнопки Моя страница

        api = VkApiUtils(ParserData.get_data('vk_test_data', 'url'))
        post = main_page.create_post()  # Создать новый пост на стене
        assert post.id_post, 'Пост не создался'

        get_info_post = main_page.get_post_UI(post.user, post)  # Получаем информацию о посте через UI

        assert post.message == get_info_post.message, \
            f'Текст {post.message} записи с id {post.id_post} не соответсвует полученному через UI'
        assert post.user == get_info_post.user, \
            f'Пользователь {post.user} отправивший сообщение не соответсвуют пользователю полученному через UI'

        # Изменяем последний пост
        change_post = main_page.change_post(post.user, post,
                                            RandomUtils.random_letters(COUNT_LATTERS_MESSAGE))
        # Получаем информацию о изменённом посте через UI
        get_info_chenge_post = main_page.get_post_UI(change_post.user,
                                                     change_post)
        assert change_post.user == get_info_chenge_post.user, \
            f'Пользователь {change_post.user}, отправивший пост не соответсвтует пользователю {get_info_chenge_post.user} полученному через UI'
        assert change_post.file == get_info_chenge_post.file, \
            f'Фото, прикреплённое к посту не соответсвует фотографии полученной через UI'

        # Добавляем комментарий к посту
        add_comment = main_page.create_comment(change_post.user, RandomUtils.random_letters(COUNT_LATTERS_MESSAGE),
                                               post)
        # Получаем информацию о посте, после добавления комментария через UI
        get_info_post_after_add_comment = main_page.get_post_UI(add_comment.user,
                                                                add_comment)

        assert get_info_post_after_add_comment.user == add_comment.user, \
            f'Пользователь оставивший {add_comment.user} комментарий не соответсвтует пользователю {get_info_post_after_add_comment.user}, полученному через UI'
        assert get_info_post_after_add_comment.comment == add_comment.comment
        f'Комментарий {add_comment.comment} прикреплённый к посту не соответствует коментарию {get_info_post_after_add_comment.comment}, полученному через UI'

        # Добавляем лайк к посту через UI
        main_page.like_click(get_info_post_after_add_comment.user, get_info_post_after_add_comment)

        # Получаем информацию о посте, после добавления лайка, через API
        get_info_post_after_like = api.like_api(get_info_post_after_add_comment.user, get_info_post_after_add_comment)

        assert get_info_post_after_add_comment.user.id == get_info_post_after_like['response']['users'][0][
            'uid'], f'Лайк поста {get_info_post_after_add_comment.id_post}, полученный через API, поставил не правильный пользователь'

        # Удаляем пост через API
        api.delete_post(get_info_post_after_add_comment.user, get_info_post_after_add_comment)

        get_info_delete_post = main_page.get_post_UI(change_post.user,
                                                     change_post)
        assert get_info_delete_post == 'Пост удалён', f"Пост с id {get_info_delete_post.id_post} не удалился"
