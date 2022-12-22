package enam;

public enum Wall {
    EDIT("wall.edit"),
    CREATE_COMMENT("wall.createComment"),
    POST("wall.post"),
    DELETE("wall.delete"),
    GET_LIKES("wall.getLikes"),
    PHOTOS_SAVE("photos.save"),
    GET_UPLOAD_SERVER("photos.getUploadServer");

    private String method;

    Wall(String method) {
        this.method = method;
    }

    public String getStatus() {
        return method;
    }

    @Override
    public String toString() {
        return method;
    }
}
