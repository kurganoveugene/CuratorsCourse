package models;

import utils.UtilsRedex;

public class Post {
    private String idPost;
    private String idUser;
    private String idImage;
    private String message;

    public Post() {
    }

    public String getIdPost() {
        return idPost;
    }

    public String getIdUser() {
        return idUser;
    }

    public String getIdImage() {
        return idImage;
    }

    public void setIdPost(String idPost) {
        this.idPost = idPost;
    }

    public void setIdAndAuthor(String postId) {
        this.idPost = UtilsRedex.getId(postId);
        this.idUser = UtilsRedex.getUser(postId);
    }

    public void setIdUser(String idUser) {
        this.idUser = idUser;
    }

    public void setIdImage(String idImage) {
        this.idImage = idImage;
    }

    public void setIdImageWithVK(String idImage) {
        this.idImage = UtilsRedex.getId(idImage);
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String massage) {
        this.message = massage;
    }

    @Override
    public String toString() {
        return "Post{" +
                "idPost='" + idPost + "\n" +
                ", idUser='" + idUser + "\n" +
                ", idImage='" + idImage + "\n" +
                ", message='" + message + "\n" +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Post post = (Post) o;
        if (idPost != null ? !idPost.equals(post.idPost) : post.idPost != null) return false;
        if (idUser != null ? !idUser.equals(post.idUser) : post.idUser != null) return false;
        if (idImage != null ? !idImage.equals(post.idImage) : post.idImage != null) return false;
        return message != null ? message.equals(post.message) : post.message == null;
    }

    @Override
    public int hashCode() {
        int result = idPost != null ? idPost.hashCode() : 0;
        result = 31 * result + (idUser != null ? idUser.hashCode() : 0);
        result = 31 * result + (idImage != null ? idImage.hashCode() : 0);
        result = 31 * result + (message != null ? message.hashCode() : 0);
        return result;
    }
}
