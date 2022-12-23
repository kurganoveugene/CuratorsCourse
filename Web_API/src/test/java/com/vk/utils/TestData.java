package com.vk.utils;

public class TestData {

    public static final String OWNER_ID = TestDataManager.getParameterValue("ownerId");
    public static final String ACCESS_TOKEN = TestDataManager.getParameterValue("accessToken");
    public static final String V = TestDataManager.getParameterValue("v");
    public static final int RANDOM_STR_LENGTH = Integer.valueOf(TestDataManager.getParameterValue("randomStrLength"));
    public static final String RANDOM_STRING = DataMathWork.getRandomStringValue(RANDOM_STR_LENGTH);
    public static final String UPDATE_RANDOM_STRING = DataMathWork.getRandomStringValue(RANDOM_STR_LENGTH);
    public static final String UPLOAD_FILE = TestDataManager.getParameterValue("uploadFile");
}