package com.userinyerface.utils;

import java.io.File;

public class FilePathManager {

    public static String getAbsolutePath(String relativePath){
        File file = new File(relativePath);
        return file.getAbsolutePath();
    }
}
