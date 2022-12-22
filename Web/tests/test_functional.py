from framework.pages.authenticate_page import AuthenticatePage
from framework.pages.main_page import MainPage
from framework.pages.profile_page import ProfilePage


class TestFunctional(object):

    def test_authenticate(self, create_browser, base_fix):
        main_page = MainPage()
        main_is_open = main_page.is_opened()
        assert main_is_open, 'Main page is not open'
        main_page.click_button_here_to_go()
        auth_page = AuthenticatePage()
        auth_is_open = auth_page.is_opened()
        assert auth_is_open, 'Auth page is not open'
        auth_page.pasword_input()
        auth_page.email_input()
        auth_page.domain_input()
        auth_page.click_button_other()
        auth_page.click_other_value()
        auth_page.click_button_do_not_accept()
        auth_page.click_button_next()
        profile = ProfilePage()
        profile_page_is_open = profile.is_opened()
        assert profile_page_is_open, 'Profile page is not open'
        profile.change_profile()
        img = profile.upload_photo()
        assert img, 'Картинка не загрузилась'
        profile.click_button_next_profile()

    def test_help_exit(self, create_browser, base_fix):
        main_page = MainPage()
        main_is_open = main_page.is_opened()
        assert main_is_open, 'Main page is not open'
        main_page.click_button_here_to_go()
        auth_page = AuthenticatePage()
        auth_is_open = auth_page.is_opened()
        assert auth_is_open, 'Auth page is not open'
        auth_page.help_window()

    def test_add_cookies(self, create_browser, base_fix):
        main_page = MainPage()
        main_is_open = main_page.is_opened()
        assert main_is_open, 'Main page is not open'
        main_page.click_button_here_to_go()
        auth_page = AuthenticatePage()
        auth_is_open = auth_page.is_opened()
        assert auth_is_open, 'Auth page is not open'
        cookie = auth_page.add_cookies()
        assert cookie, 'Cookies не приняты'

    def test_timer(self, create_browser, base_fix):
        main_page = MainPage()
        main_is_open = main_page.is_opened()
        assert main_is_open, 'Main page is not open'
        main_page.click_button_here_to_go()
        auth_page = AuthenticatePage()
        auth_is_open = auth_page.is_opened()
        assert auth_is_open, 'Auth page is not open'
        stert_timer = auth_page.timer()
        assert stert_timer == 0, 'Таймер стартует не с 0'
