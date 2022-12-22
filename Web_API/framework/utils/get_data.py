import json


class ParserData:
    """
    Класс для получения данных
    """

    @staticmethod
    def get_data(file, param):
        with open(f'tests/TestDataVk/{file}.json') as file:
            data = json.loads(file.read())
            return data[f'{param}']
