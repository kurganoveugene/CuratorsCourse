package com.vk.api;

public enum APICommands {
    WALLPOST("wall.post"),
    WALLEDIT("wall.edit"),
    PHOTOSGETWALLUPLOADSERVER("photos.getWallUploadServer"),
    WALLCREARECOMMENT("wall.createComment"),
    LIKESISLIKED("likes.isLiked"),
    WALLDELEDE("wall.delete"),
    PHOTOSSAVEWALLPHOTO("photos.saveWallPhoto");

    private final String command;

    APICommands(String url) {
        this.command = url;
    }

    public String getCommand() {
        return command;
    }
}
