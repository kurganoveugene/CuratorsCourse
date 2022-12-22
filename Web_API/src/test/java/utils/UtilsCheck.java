package utils;


import models.Post;

import java.util.List;

public class UtilsCheck {

    public static boolean checkPost(List<Post> listInput, Post myPost) {
        for (Post post : listInput) {
            if (post.equals(myPost)) {
                return true;
            }
        }
        return false;
    }
}
