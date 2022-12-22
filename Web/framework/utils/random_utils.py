import random
import string
from random import choice
from framework.constants.random import COUNT_LATTERS_EMAIL, DOMAIN, OTHER, INTERESTS


class RandomUtils:
    email: dict

    @staticmethod
    def random_email():
        letters = string.ascii_lowercase
        your_email = ''.join(
            choice(letters) for i in range(COUNT_LATTERS_EMAIL))
        your_domain = choice(DOMAIN)
        other = choice(OTHER)
        latter_for_pasword = choice(your_email)

        result_email = {
            'your_email': your_email,
            'your_domain': your_domain,
            'other': other,
            'latter_for_pasword': latter_for_pasword
        }
        RandomUtils.email = result_email

        return result_email

        # return rand_string

    @staticmethod
    def random_password():
        letters = string.ascii_uppercase
        first = choice(letters)
        second = RandomUtils.email['latter_for_pasword']
        last = ''.join(
            str(random.randint(0, 9)) for i in range(COUNT_LATTERS_EMAIL))

        result = first + second + last
        return result

    @staticmethod
    def random_interests(num):
        interes_list = INTERESTS
        result_interests_list = []
        for i in range(3):
            val = choice(interes_list)
            result_interests_list.append(val)
            interes_list.remove(val)
        return result_interests_list[num]

    @staticmethod
    def random_navigate_for_image():
        x = random.randint(305, 600)
        y = random.randint(150, 720)
        return (x, y)
