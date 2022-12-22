package utils;

import models.Response;
import org.json.JSONArray;
import org.json.JSONObject;

public class UtilsResponse {
    public static String getId(String responseInput) {
        JSONObject json = new JSONObject(responseInput);
        JSONObject response = (JSONObject) json.get("response");
        return String.valueOf(response.get("post_id"));
    }

    public static int getCount(String responseInput) {
        JSONObject json = new JSONObject(responseInput);
        JSONObject response = (JSONObject) json.get("response");
        return (int) (response.get("count"));
    }

    public static String getCommentId(String responseInput) {
        JSONObject json = new JSONObject(responseInput);
        JSONObject response = (JSONObject) json.get("response");
        return String.valueOf(response.get("comment_id"));
    }

    public static String getUrl(String responseInput) {
        JSONObject json = new JSONObject(responseInput);
        JSONObject response = (JSONObject) json.get("response");
        return String.valueOf(response.get("upload_url"));
    }

    public static Response getResponseUploadAttribute(String responseInput) {
        Response out = new Response();
        JSONObject json = new JSONObject(responseInput);
        out.setServer(String.valueOf(json.get("server")));
        out.setPhotosList(String.valueOf(json.get("photos_list")));
        out.setAid((int) (json.get("aid")));
        out.setHash(String.valueOf(json.get("hash")));
        return out;
    }

    public static String getMediaId(String responseInput) {
        JSONObject json = new JSONObject(responseInput);
        JSONArray arr = json.getJSONArray("response");
        arr.getJSONObject(0).get("id");
        return arr.getJSONObject(0).get("id").toString();
    }
}
