import requests


class BaseVkApi:
    def __init__(self, url):
        self.url = url

    def get_method(self, method, token, version, params=None):
        response = requests.get(f"{self.url}{method}?{params}&access_token={token}&v={version}")
        return response

    def post_method(self, method, token, version, params=None):
        response = requests.post(f"{self.url}{method}?{params}&access_token={token}&v={version}")
        return response
