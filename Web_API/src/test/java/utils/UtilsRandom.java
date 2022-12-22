package utils;


import org.apache.commons.lang3.RandomStringUtils;

public class UtilsRandom {

    public static int getRandomInt(int start, int end) {
        return start + (int) (Math.random() * end);
    }

    public static String getRandomAlphanumericString() {
        return RandomStringUtils.randomAlphanumeric(getRandomInt(Integer.parseInt(UtilsGetConfig.getConfigTest("minLengthRandomString")),
                Integer.parseInt(UtilsGetConfig.getConfigTest("maxLengthRandomString"))));
    }
}
