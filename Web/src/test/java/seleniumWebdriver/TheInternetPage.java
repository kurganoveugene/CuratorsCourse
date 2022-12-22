package seleniumWebdriver;
public enum TheInternetPage {
    CHECKBOXES,
    DOWNLOAD,
    DROPDOWN,
    DYNAMIC_CONTROLS,
    DYNAMIC_LOADING("dynamic_loading/1"),
    JAVASCRIPT_ALERTS,
    LOGIN,
    REDIRECTOR,
    STATUS_CODES,
    TABLES;
    private static final String BASE_URL = "https://userinyerface.com/game.html%20target=";
    private final String postfix;
    TheInternetPage() {
        this.postfix = name().toLowerCase();
    }
    TheInternetPage(String postfix) {
        this.postfix = postfix;
    }
    public String getAddress() {
        return BASE_URL.concat(postfix);
    }
}
