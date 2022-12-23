package com.vk.utils;

import com.vk.HttpClient;
import com.vk.model.*;
import java.io.UnsupportedEncodingException;

public class VKAPIUtils extends HttpClient {

    public static WallSendMessage sendWallMessage() {
        return postRequest(Config.WALL_POST, VKAPIFieldRequestData.wallMessageParams(), WallSendMessage.class);
    }

    public static WallSavePhoto editWallMessageAndAddPhoto(String post_id) throws UnsupportedEncodingException {
        WallGetUploadServer wallGetUploadServer = postRequest(Config.PHOTOS_GET_WALL_UPLOAD_SERVER, VKAPIFieldRequestData.photosWallUploadServerParams(), WallGetUploadServer.class);
        WallSendPhotoToServer wallSendPhotoToServer = postRequest(wallGetUploadServer.getResponse().getUpload_url(), VKAPIFieldRequestData.sendUpLoadPhotoToServerParams(), WallSendPhotoToServer.class);
        WallSavePhoto savePhoto = postRequestSavePhotoOnServer(Config.PHOTOS_SAVE_WALL_PHOTO, VKAPIFieldRequestData.savePhotoOnServer(wallSendPhotoToServer.getServer(), wallSendPhotoToServer.getHash()),wallSendPhotoToServer.getPhoto(), WallSavePhoto.class);
        postRequest(Config.WALL_EDIT, VKAPIFieldRequestData.editWallMessageWithSendPhoto(post_id, savePhoto.getResponse().get(0).getId()), WallEditPost.class);

        return savePhoto;
    }

    public static WallSendComment sendWallComent(String post_id) {
        return postRequest(Config.WALL_CREATE_COMMENT, VKAPIFieldRequestData.wallCommentParams(post_id), WallSendComment.class);
    }

    public static LikeGetList getLikesList(String comment_id) {
        return postRequest(Config.LIKES_GET_LIST, VKAPIFieldRequestData.wallOwnerCommentParams(comment_id), LikeGetList.class);
    }

    public static WallDelete wallDeletePost(String post_id) {
        return postRequest(Config.WALL_DELETE, VKAPIFieldRequestData.wallDeletePost(post_id), WallDelete.class);
    }

    public static boolean isTrueLikeOwner(String owner_id){

        return TestData.OWNER_ID.equals(owner_id);
    }

    public static boolean isIdExist(String post_id){
        return !post_id.isEmpty() && !post_id.equals(null);
    }


}
