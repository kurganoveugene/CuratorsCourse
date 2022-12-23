package com.vk;

import com.google.gson.Gson;
import kong.unirest.Unirest;
import java.util.Map;

public class HttpClient {

    public static void setDefaultUrl(String url){
        Unirest.config().defaultBaseUrl(url);
    }

    public static <T> T postRequest(String route, Map<String, Object> params, Class<T> clazz) {
        String response = Unirest.post(route)
                .fields(params)
                .asString().getBody();
       return new Gson().fromJson(response, clazz);
    }

    public static <T> T postRequestSavePhotoOnServer(String route, Map<String, Object> params, String photo, Class<T> clazz) {
        String response = Unirest.post(route + "?photo={photo}")
                .queryString(params)
                .routeParam("photo", photo)
                .asString().getBody();
        return new Gson().fromJson(response, clazz);
    }
}
