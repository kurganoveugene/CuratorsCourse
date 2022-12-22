package utils;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class UtilsRedex {
    public static String getId(String input) {
        return getMather(input).group(2);
    }

    public static String getUser(String input) {
        return getMather(input).group(1);
    }

    private static Matcher getMather(String input) {
        String regex = "([0-9]+)[_]([0-9]+)";
        Pattern p = Pattern.compile(regex);
        Matcher m = p.matcher(input);
        m.find();
        return m;
    }
}
