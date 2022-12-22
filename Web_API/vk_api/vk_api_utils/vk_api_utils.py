from framework.utils.get_data import ParserData
from vk_api.vk_api_utils.base_vk_api import BaseVkApi
from vk_api.vk_models.User import User


class VkApiUtils(BaseVkApi):

    def get_current_user(self):
        """
        Функция получения текущего пользователя
        """
        users_info = self.get_method('users.get', ParserData.get_data('vk_test_data', 'token'),
                                     ParserData.get_data('vk_test_data', 'version'))
        user = User(users_info.json()['response'][0]['id'], users_info.json()['response'][0]['first_name'],
                    users_info.json()['response'][0]['last_name'])
        return user

    def create_post_my_wall(self, text_message, user):
        """
        Функция создания поста на стене.
        """
        post = self.post_method('wall.post', ParserData.get_data('vk_test_data', 'token'),
                                ParserData.get_data('vk_test_data', 'version'),
                                f"owner_id={user.id}&message='{text_message}'")

        return (post.json()['response']['post_id'], text_message, user)

    def get_last_photos(self, user):
        """
        Функция для получения последнего фото.
        """
        last_photo = self.get_method('photos.getAll', ParserData.get_data('vk_test_data', 'token'),
                                     ParserData.get_data('vk_test_data', 'version'), f"owner_id={user.id}")
        return str(last_photo.json()['response']['items'][0]['id'])

    def change_last_post(self, user, new_message, post, photo):
        """
        Функция изменения последенго поста
        (изменение текста и добавления фото).
        """
        change_post = self.post_method('wall.edit', ParserData.get_data('vk_test_data', 'token'),
                                       ParserData.get_data('vk_test_data', 'version'),
                                       f"owner_id={user.id}&message={new_message}&post_id={post.id_post}&attachment=photo{user.id}_{photo}")
        return change_post.json()

    def create_comment_api(self, user, new_message, post):
        """
        Функция добавления комментария к посту.
        """
        comment = self.post_method('wall.createComment', ParserData.get_data('vk_test_data', 'token'),
                                   ParserData.get_data('vk_test_data', 'version'),
                                   f"owner_id={user.id}&message={new_message}&post_id={post.id_post}")
        return comment.json()

    def like_api(self, user, post):
        """
        Функция добавления лайка к посту.
        """
        like = self.get_method('wall.getLikes', ParserData.get_data('vk_test_data', 'token'),
                                ParserData.get_data('vk_test_data', 'version'),
                                f"owner_id={user.id}&post_id={post.id_post}")
        return like.json()

    def delete_post(self,user, post):
        """
        Функция удаления поста.
        """
        self.get_method('wall.delete', ParserData.get_data('vk_test_data', 'token'),
                        ParserData.get_data('vk_test_data', 'version'),
                        f"owner_id={user.id}&post_id={post.id_post}")
