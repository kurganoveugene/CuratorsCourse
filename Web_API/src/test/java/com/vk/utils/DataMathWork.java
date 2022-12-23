package com.vk.utils;

import java.util.Random;

public class DataMathWork {

    private static final int LEFT_LIMIT = 97;
    private static final int RIGHT_LIMIT = 122;

    public static String getRandomStringValue(int subStrLength) {
        Random random = new Random();
        StringBuilder randomString = new StringBuilder(subStrLength);
        for (int i = 0; i < subStrLength; i++) {
            int randomLimitedCapitalInt = LEFT_LIMIT + (int)
                    (random.nextFloat() * (RIGHT_LIMIT - LEFT_LIMIT + 1));
            randomString.append((char) +randomLimitedCapitalInt);
        }

        return randomString.toString();
    }
}