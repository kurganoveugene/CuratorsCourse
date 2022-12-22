package utils;


import models.Post;

public class UtilModel {
    public static void fillMyPost(Post myPost) {
        myPost.setIdUser(UtilsGetConfig.getConfig("idUser"));
        myPost.setMessage(UtilsRandom.getRandomAlphanumericString());
    }
}
