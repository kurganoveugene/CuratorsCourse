package models;

public class Response {
    private String server;
    private String photosList;
    private int aid;
    private String hash;

    public Response() {
    }

    public String getServer() {
        return server;
    }

    public void setServer(String server) {
        this.server = server;
    }

    public String getPhotosList() {
        return photosList;
    }

    public void setPhotosList(String photosList) {
        this.photosList = photosList;
    }

    public int getAid() {
        return aid;
    }

    public void setAid(int aid) {
        this.aid = aid;
    }

    public String getHash() {
        return hash;
    }

    public void setHash(String hash) {
        this.hash = hash;
    }

    @Override
    public String toString() {
        return "Response{" +
                "\nserver='" + server + '\'' +
                ", \nphotosList='" + photosList + '\'' +
                ", \naid=" + aid +
                ", \nhash='" + hash + '\'' +
                '}';
    }
}
