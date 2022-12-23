package com.userinyerface.utils;

import java.util.Random;

public class DataMathWork {

    private static final int LEFT_LIMIT_CAPITAL = 65;
    private static final int RIGHT_LIMIT_CAPITAL = 90;
    private static final int LEFT_LIMIT_LOWERCASE = 97;
    private static final int RIGHT_LIMIT_LOWERCASE = 122;
    private static final int CYR_LEFT_LIMIT_CAPITAL = 1040;
    private static final int CYR_RIGHT_LIMIT_CAPITAL = 1071;
    private static final int DIG_LEFT_LIMIT_CAPITAL = 48;
    private static final int DIG_RIGHT_LIMIT_CAPITAL = 57;

    public static String getRandomStringValue(int length) {

        Random random = new Random();
        StringBuilder buffer = new StringBuilder(length);
        for (int i = 0; i < length; i++) {
            int randomLimitedCapitalInt = LEFT_LIMIT_CAPITAL + (int)
                    (random.nextFloat() * (RIGHT_LIMIT_CAPITAL - LEFT_LIMIT_CAPITAL + 1));
            buffer.append((char) +randomLimitedCapitalInt);
        }

        for (int i = 0; i < length; i++) {
            int randomLimitedLowercaseInt = LEFT_LIMIT_LOWERCASE + (int)
                    (random.nextFloat() * (RIGHT_LIMIT_LOWERCASE - LEFT_LIMIT_LOWERCASE + 1));
            buffer.append((char) +randomLimitedLowercaseInt);
        }

        int randomLimitedCyrInt = CYR_LEFT_LIMIT_CAPITAL + (int)
                (random.nextFloat() * (CYR_RIGHT_LIMIT_CAPITAL - CYR_LEFT_LIMIT_CAPITAL + 1));
        buffer.append((char) +randomLimitedCyrInt);

        int randomLimitedDigInt = DIG_LEFT_LIMIT_CAPITAL + (int)
                (random.nextFloat() * (DIG_RIGHT_LIMIT_CAPITAL - DIG_LEFT_LIMIT_CAPITAL + 1));
        buffer.append((char) +randomLimitedDigInt);

        return buffer.toString();
    }
}


