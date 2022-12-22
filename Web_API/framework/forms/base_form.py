class BaseForm:
    def __init__(self, element, name):
        self.element = element
        self.name = name

    def click_element_form(self):
        self.element.click()
