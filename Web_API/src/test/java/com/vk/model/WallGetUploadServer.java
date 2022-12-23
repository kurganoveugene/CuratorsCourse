package com.vk.model;

import com.vk.HttpClient;

public class WallGetUploadServer extends HttpClient {

    private Response response;

    public Response getResponse() {
        return response;
    }

    public void setResponse(Response response) {
        this.response = response;
    }

    public static class Response{
        private String id;
        private String post_id;
        private String album_id;
        private String upload_url;



        public String getPost_id() {
            return post_id;
        }

        public void setPost_id(String post_id) {
            this.post_id = post_id;
        }

        public String getUpload_url() {
            return upload_url;
        }

        public void setUpload_url(String upload_url) {
            this.upload_url = upload_url;
        }

        public String getAlbum_id() {
            return album_id;
        }

        public void setAlbum_id(String album_id) {
            this.album_id = album_id;
        }


        public String getId() {
            return id;
        }

        public void setId(String id) {
            this.id = id;
        }
    }
}
