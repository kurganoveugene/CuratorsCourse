class Post:
    def __init__(self, id_post, message, user, file=None, like=None, comment=None):
        self.id_post = id_post
        self.message = message
        self.user = user
        self.file = file
        self.like = like
        self.comment = comment
