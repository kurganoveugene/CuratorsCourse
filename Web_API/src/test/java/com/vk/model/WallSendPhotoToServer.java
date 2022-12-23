package com.vk.model;

import com.vk.HttpClient;

public class WallSendPhotoToServer extends HttpClient {

    private String photo;
    private String server;
    private String hash;

    public String getPhoto() {
        return photo;
    }

    public void setPhoto(String photo) {
        this.photo = photo;
    }

    public String getServer() {
        return server;
    }

    public void setServer(String server) {
        this.server = server;
    }

    public String getHash() {
        return hash;
    }

    public void setHash(String hash) {
        this.hash = hash;
    }
}
