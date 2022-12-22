class User:
    def __init__(self, id, first_name, last_name):
        self.id = id
        self.first_name = first_name
        self.last_name = last_name

    def __eq__(self, other):
        if isinstance(other, User):
            return (self.id == other.id and
                    self.first_name == other.first_name and
                    self.last_name == other.last_name)
        return NotImplemented