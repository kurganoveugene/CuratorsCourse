const BasePage = require('./basePage');
const Button = require('../baseElement/button');
class ProfilePage extends BasePage {

    constructor() {
        super(new Button('//div[@id="post_field"]', 'Что у вас нового?'), 'Profile Page');
    }

    get myPageButton() {
        return new Button('//li[@id="l_pr"]', "My page Button");
    }

    get wallPosts() {
        return new Button('//div[contains(@class,"post--withPostBottomAction")]', 'Posts on the wall');
    }

    get wallPostsAuthor() {
        return new Button('//a[@class="author"]', 'Wall posts author');
    }

    get wallPostTextWithPhoto() {
        return new Button('//div[@class="wall_post_text"]', 'Wall posts text');
    }

    get wallPostTextWithoutPhoto() {
        return new Button('//div[contains(@class,"zoom_text")]', 'Wall posts text');
    }

    get wallCommentPostAuthor() {
        return new Button('//div[@class="reply_author"]//a[@class="author"]', "Comment posts author");
    }

    get wallCommentPostText() {
        return new Button('//div[contains(@class,"wall_reply_text")]', "Comment posts text");
    }

    get showNewCommentButton() {
        return new Button('//span[contains(@class,"js-replies_next_label")]', "Show new comment button");
    }

    get wallPostLikeButton() {
        return new Button('//div[contains(@class,"PostBottomAction PostBottomAction--withBg PostButtonReactions PostButtonReactions--post  PostBottomAction--empty")]', "First Wall Post Like");
    }

    get wallPhotosList() {
        return new Button('//a[contains(@class,"page_post_thumb_wrap")]', 'All wall photo list')
    }

    async getPhotoAttribute() {
        const wallPosts = await this.wallPhotosList.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getAttribute("href");
        }
    }

    async showNewCommentButtonClick() {
        return this.showNewCommentButton.click();
    }

    async getCommentAuthor() {
        const wallPosts = await this.wallCommentPostAuthor.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getText();
        }
    }

    async getCommentText() {
        const wallPosts = await this.wallCommentPostText.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getText();
        }
    }

    async clickMyPage() {
        return this.myPageButton.click();
    }

    async getPostTextWithPhoto() {
        const wallPosts = await this.wallPostTextWithPhoto.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getText();
        }
    }

    async getPostTextWithoutPhoto() {
        const wallPosts = await this.wallPostTextWithoutPhoto.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getText();
        }
    }

    async getPostAuthor() {
        const wallPosts = await this.wallPostsAuthor.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getText();
        }
    }

    async getNewPostId() {
        const wallPosts = await this.wallPosts.getElements();
        for (let i = 0; i < wallPosts.length; i++) {
            return wallPosts[i].getAttribute("data-post-id");
        }
    }

    async clickLikeButton() {
        return this.wallPostLikeButton.click();
    }

} module.exports = new ProfilePage();
