package com.vk.utils;

public class Config {

    public static final String WALL_POST = ConfigManager.getParameterValue("wallPost");
    public static final String WALL_EDIT = ConfigManager.getParameterValue("wallEdit");
    public static final String WALL_DELETE = ConfigManager.getParameterValue("wallDelete");
    public static final String PHOTOS_GET_WALL_UPLOAD_SERVER = ConfigManager.getParameterValue("photosGetWallUploadServer");
    public static final String PHOTOS_SAVE_WALL_PHOTO = ConfigManager.getParameterValue("photosSaveWallPhoto");
    public static final String WALL_CREATE_COMMENT = ConfigManager.getParameterValue("wallCreateComment");
    public static final String LIKES_GET_LIST = ConfigManager.getParameterValue("getLikesList");
    public static final String TYPE_OF_FILE = ConfigManager.getParameterValue("typeOfUploadFile");
    public static final String TYPE_OF_LIKE = ConfigManager.getParameterValue("typeOfLike");
}