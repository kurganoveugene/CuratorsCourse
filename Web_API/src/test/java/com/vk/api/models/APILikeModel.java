package com.vk.api.models;

public class APILikeModel {
    private Response response;
    private class Response {
    private String liked;
    private String copied;
    }

    public String getLiked(){
        return response.liked;
    }
    public String getCopied(){
        return response.copied;
    }
}
