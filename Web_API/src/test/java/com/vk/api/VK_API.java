package com.vk.api;

import com.vk.utils.JsonUtils;
import com.vk.utils.MapUtils;
import kong.unirest.Config;
import kong.unirest.HttpResponse;

import java.util.Map;

public class VK_API extends API<Object>{
    private Config expected = baseURL(JsonUtils.getValueFromFile("config.json").getValue("/APIRequestUrl").toString());
    private final String versionOfAPI = JsonUtils.getValueFromFile("config.json").getValue("/version").toString();

    public HttpResponse<?> wallPostAPI(Object object, String ownerID, String message, String accessToken){
      return getAPIObject(String.format("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s",APICommands.WALLPOST.getCommand(),"?",APIRequestFields.owner_id,"=",
                      ownerID,"&",APIRequestFields.message,"=",message,"&",APIRequestFields.access_token,"=",accessToken,"&",APIRequestFields.v,"=", versionOfAPI), object);
    }
    public HttpResponse<?> wallEditAPI(Object object, String ownerID, String postID, String message, String attachment, String accessToken){
        return getAPIObject(String.format("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s", APICommands.WALLEDIT.getCommand(),"?",
                APIRequestFields.owner_id,"=", ownerID,"&",APIRequestFields.post_id,"=", postID,"&",APIRequestFields.message,"=",message,"&",
                APIRequestFields.attachments,"=", attachment,"&", APIRequestFields.access_token,"=",accessToken,"&",APIRequestFields.v,"=", versionOfAPI), object);
    }
    public HttpResponse<?> photosGetWallUploadServerAPI(Object object, String accessToken){
        return getAPIObject(String.format("%s%s%s%s%s%s%s%s%s", APICommands.PHOTOSGETWALLUPLOADSERVER.getCommand(),"?",
                        APIRequestFields.access_token,"=",accessToken,"&",APIRequestFields.v,"=", versionOfAPI), object);
    }
    public HttpResponse<?> wallCreateCommentAPI(Object object, String ownerID, String postID, String message, String accessToken){
        return getAPIObject(String.format("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s",APICommands.WALLCREARECOMMENT.getCommand(),"?",
                APIRequestFields.owner_id,"=", ownerID,"&",APIRequestFields.post_id,"=",postID,"&",APIRequestFields.message,"=",message,"&",
                APIRequestFields.access_token,"=",accessToken,"&",APIRequestFields.v,"=", versionOfAPI), object);
    }
    public HttpResponse<?> likesIsLikedAPI(Object object, String itemID, String accessToken){
        return getAPIObject(String.format("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s", APICommands.LIKESISLIKED.getCommand(),"?",
                APIRequestFields.type,"=", JsonUtils.getValueFromFile("config.json").getValue("/type").toString(), "&",
                APIRequestFields.item_id,"=",itemID,"&", APIRequestFields.access_token,"=",accessToken,"&",APIRequestFields.v,"=", versionOfAPI),object);
    }
    public HttpResponse<?> wallDeleteAPI(String ownerID, String postID, String accessToken){
        return getAPI(String.format("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s", APICommands.WALLDELEDE.getCommand(),"?",
                APIRequestFields.owner_id,"=", ownerID,"&",APIRequestFields.post_id,"=",postID,"&",
                APIRequestFields.access_token,"=", accessToken,"&",APIRequestFields.v,"=", versionOfAPI)).asString();
    }
    public HttpResponse<?> fileTransfer(Object object, String uploadUrl, Map<String, Object> values){
        return postAPIPostObj(object, uploadUrl, values);
    }
    public HttpResponse<?> photosSaveWallPhotoAPI(String server, String photo, String hash, String accessToken){
        String[] keyArray = {String.valueOf(APIRequestFields.photo)};
        String[] valueArray = {photo};
        Map<String, Object> routeParams = MapUtils.getMap(keyArray, valueArray);
        return getAPIWithRouteParam(String.format("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s",APICommands.PHOTOSSAVEWALLPHOTO.getCommand(),"?",
               APIRequestFields.photo, "={",APIRequestFields.photo,"}&",APIRequestFields.server,"=", server,"&", APIRequestFields.hash,"=", hash,
                "&", APIRequestFields.access_token,"=", accessToken,"&",APIRequestFields.v,"=", versionOfAPI), routeParams);
    }
}
