package forms;

import aquality.selenium.elements.ElementType;
import aquality.selenium.elements.interfaces.ILabel;
import aquality.selenium.forms.Form;
import models.Post;
import org.openqa.selenium.By;

import java.util.LinkedList;
import java.util.List;

public class PostForm extends Form {

    private final By posts = By.xpath("//div[@id='page_wall_posts']/div[contains(@id,'post')]");
    private final String comment = "//div[contains(@id,'post%s_%s')]//*[contains(@class,'reply_replieable _post')]";

    public PostForm() {
        super(By.className("side_bar_nav"), "Login form");
    }

    public List<Post> GetPosts() {
        Post postComment;
        List<Post> listPostComment = new LinkedList<>();
        List<ILabel> listPostElements = getElementFactory().findElements(posts, ElementType.LABEL);
        for (ILabel list : listPostElements) {
            postComment = new Post();
            if (list.state().isDisplayed()) {
                postComment.setIdAndAuthor(list.getAttribute("id"));
            }
            if (list.findChildElement(By.xpath("//*[contains(@class, 'wall_post_text')]"), ElementType.LABEL).state().isDisplayed()) {
                postComment.setMessage(list.findChildElement(By.xpath("//*[contains(@class, 'wall_post_text')]"), ElementType.LABEL).getText());
            }
            if (list.findChildElements(By.xpath("//*[contains(@class, 'page_post_thumb_wrap')]"), ElementType.LABEL).size() > 0) {

                postComment.setIdImageWithVK(list.findChildElement(By.xpath("//*[contains(@class, 'page_post_thumb_wrap')]"), ElementType.LABEL).getAttribute("data-photo-id"));
            }
            listPostComment.add(postComment);
        }
        return listPostComment;
    }

    public List<Post> getComments(Post postInput) {

        List<ILabel> listCommentElements = getElementFactory().findElements(By.xpath(String.format(comment, postInput.getIdUser(), postInput.getIdPost())), ElementType.LABEL);
        Post comment;
        List<Post> listObject = new LinkedList<>();
        for (ILabel list : listCommentElements) {
            comment = new Post();
            if (list.state().isDisplayed()) {
                comment.setIdAndAuthor(list.getAttribute("id"));
            }
            if (list.findChildElement(By.xpath("//*[contains(@class, 'wall_reply_text')]"), ElementType.LABEL).state().isDisplayed()) {
                comment.setMessage(list.findChildElement(By.xpath("//*[contains(@class, 'wall_reply_text')]"), ElementType.LABEL).getText());
            }
            if (list.findChildElements(By.xpath("//*[contains(@class, 'page_post_thumb_wrap')]"), ElementType.LABEL).size() > 0) {
                comment.setIdImageWithVK(list.findChildElement(By.xpath("//*[contains(@class, 'page_post_thumb_wrap')]"), ElementType.LABEL).getAttribute("data-photo-id"));
            }
            listObject.add(comment);
        }
        return listObject;
    }

    public void clickLike(Post post) {
        getElementFactory().getLabel(By.id(String.format("post%s_%s", post.getIdUser(), post.getIdPost())), "label post").findChildElement(By.xpath("//*[contains(@class, 'PostBottomActionContainer')]"), ElementType.BUTTON).click();
    }
}
