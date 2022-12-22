const assert = require('chai').assert;
const MainPage = require('../../pageObjects/mainPage');
const LoginPage = require('../../pageObjects/loginPage');
const ProfilePage = require('../../pageObjects/profilePage');
const loginData = require('../../data/loginData.json');
const apiConfig = require('../../data/vkApiConfig.json');
const config = require('../../data/config.json');
const browser = require('../../browser/browser');
const vkApiUtils = require('../../utils/vkApiUtils');
const RequestUtils = require('../../utils/requestUtils');
const Utils = require('../../utils/utils');

describe('Vk.com testing', () => {
    const randPostText = Utils.getRandomText();
    const randEditPostText = Utils.getRandomText();
    const randPostComment = Utils.getRandomText();

    beforeEach(async function () {
        await MainPage.open();
        await MainPage.clickLogin();
        await LoginPage.login(loginData.phone, loginData.password);
        await browser.pause();
        await ProfilePage.clickMyPage();
    })

    it('Actions with wall post', async () => {
        const postId = (await vkApiUtils.wallPost(randPostText)).responseBody.response.post_id;
        await browser.pause();
        const newPostId = await ProfilePage.getNewPostId();
        const postAuthor = await ProfilePage.getPostAuthor();
        const postText = await ProfilePage.getPostTextWithoutPhoto();
        assert.equal(postAuthor, config.authorName, 'Authors are not equal');
        assert.equal(postText, randPostText, 'Wall post texts are not equal');
        assert.equal(newPostId, apiConfig.userId + '_' + postId, 'New post not created');
        const photoUrl = (await vkApiUtils.getUploadPhotoUrl()).responseBody.response.upload_url;
        const photoResponseBody = await RequestUtils.post(photoUrl, await vkApiUtils.getUploadPhotoBody(config.typeFile, config.filepath, config.filename));
        const savedPhoto = await vkApiUtils.saveWallPhoto(photoResponseBody.server, photoResponseBody.photo, photoResponseBody.hash);
        const photoOwnerId = savedPhoto.response[0]['owner_id'];
        const photoId = savedPhoto.response[0]['id'];
        await vkApiUtils.wallEdit(postId, randEditPostText, photoOwnerId, config.typeFile, photoId);
        await browser.pause();
        const editedPostText = await ProfilePage.getPostTextWithPhoto();
        const photoAttribute = await ProfilePage.getPhotoAttribute();
        assert.equal(photoAttribute, '/' + config.typeFile + photoOwnerId + '_' + photoId, 'Photos are not equal');
        assert.equal(editedPostText, randEditPostText, 'Edited text are not equal');
        await vkApiUtils.wallCreateComment(postId, randPostComment);
        await ProfilePage.showNewCommentButtonClick();
        await browser.pause();
        const commentPostAuthor = await ProfilePage.getCommentAuthor();
        assert.equal(commentPostAuthor, config.authorName, 'Comment authors are not equal');
        const commentPostText = await ProfilePage.getCommentText();
        assert.equal(commentPostText, randPostComment, 'Comment texts are not equal');
        await ProfilePage.clickLikeButton();
        const isLiked = await Utils.getBoolean((await vkApiUtils.isLiked(apiConfig.userId, postId)).responseBody.response.liked);
        assert.isTrue(isLiked, 'Post has not been liked by Ivan Ivanov');
        await vkApiUtils.wallDelete(apiConfig.userId, postId);
        const firstPostId = await ProfilePage.getNewPostId();
        assert.notEqual(firstPostId, postId, 'New post has not been deleted');
    });
});


