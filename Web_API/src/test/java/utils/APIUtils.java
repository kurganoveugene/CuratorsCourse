package utils;


import enam.Wall;
import kong.unirest.Unirest;
import models.Post;
import models.Response;

import java.io.File;
import java.util.*;


public class APIUtils {
    public static String postResponse(Wall method, Map<String, Object> map) {
        return Unirest.post(method.getStatus())
                .queryString(map)
                .queryString("access_token", UtilsGetConfig.getConfig("token"))
                .queryString("v", UtilsGetConfig.getConfig("V_API"))
                .asString().getBody();
    }

    public static String getResponse(Wall method, Map<String, Object> map) {
        return Unirest.post(method.getStatus())
                .queryString(map)
                .queryString("access_token", UtilsGetConfig.getConfig("token"))
                .queryString("v", UtilsGetConfig.getConfig("V_API"))
                .asString().getBody();
    }

    public static Map<String, Object> createMapNewPost(String message) {
        Map<String, Object> mapPost = new HashMap<>();
        mapPost.put("message", message);
        return mapPost;
    }

    public static Map<String, Object> createMapEditPost(Post myPost, String message) {
        Map<String, Object> mapPost = new HashMap<>();
        mapPost.put("post_id", myPost.getIdPost());
        mapPost.put("message", message);
        mapPost.put("attachments", String.format("photo%s_%s", myPost.getIdUser(), myPost.getIdImage()));
        return mapPost;
    }

    public static Map<String, Object> createMapComment(String idPost, String message) {
        Map<String, Object> mapPost = new HashMap<>();
        mapPost.put("post_id", idPost);
        mapPost.put("message", message);
        return mapPost;
    }

    public static Map<String, Object> createMapGetLikes(String idPost) {
        Map<String, Object> mapPost = new HashMap<>();
        mapPost.put("post_id", idPost);
        return mapPost;
    }

    public static Map<String, Object> createMapDelete(String idPost) {
        Map<String, Object> mapPost = new HashMap<>();
        mapPost.put("post_id", idPost);
        return mapPost;
    }

    public static Map<String, Object> createMapUploadServer() {
        Map<String, Object> map = new HashMap<>();
        map.put("album_id", UtilsGetConfig.getConfig("album_id"));
        return map;
    }

    public static Map<String, Object> createMapPhotoSave(Response response) {
        Map<String, Object> map = new HashMap<>();
        map.put("album_id", UtilsGetConfig.getConfig("album_id"));
        map.put("server", response.getServer());
        map.put("photos_list", response.getPhotosList());
        map.put("aid", response.getAid());
        map.put("hash", response.getHash());
        return map;
    }

    public static String uploadPhoto(String url) {
        String str = Unirest.post(url)
                .field("file", new File(UtilsGetConfig.getConfigTest("filePath")))
                .queryString("access_token", UtilsGetConfig.getConfig("token"))
                .queryString("v", UtilsGetConfig.getConfig("V_API"))
                .asString().getBody();
        System.out.println(str);
        return str;
    }
}

