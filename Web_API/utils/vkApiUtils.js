const RequestUtils = require('./requestUtils');
const apiConfig = require('../data/vkApiConfig.json');
const FormData = require('form-data');
const fs = require('fs2');
class VkApiUtils {

    static async get(method, params) {
        let query = apiConfig.baseUrl + method + '?v='
            + apiConfig.apiVersion + '&access_token='
            + apiConfig.token;
        for (let key in params) {
            query = query + '&' + key + '=' + params[key];
        }
        return RequestUtils.get(query);
    }

    static async post(method, params) {
        let query = apiConfig.baseUrl + method + '?v='
            + apiConfig.apiVersion + '&access_token='
            + apiConfig.token;
        for (let key in params) {
            query = query + '&' + key + '=' + params[key];
        }
        return RequestUtils.post(query);
    }

    static async wallPost(message) {
        return this.get(apiConfig.wallPost, { 'message': message });
    }

    static async wallEdit(postId, message, ownerId, type, photoId) {
        return this.get(apiConfig.wallEdit, {
            'attachments': type + ownerId + '_' + photoId,
            'message': message,
            'post_id': postId
        });
    }

    static async wallCreateComment(postId, message) {
        return this.get(apiConfig.wallCreateComment, {
            'message': message,
            'post_id': postId
        });
    }

    static async getUploadPhotoUrl() {
        return this.get(apiConfig.getWallUploadServer, {
        });
    }

    static async isLiked(ownerId, itemId) {
        return this.get(apiConfig.isLiked, {
            'type': 'post',
            'owner_id': ownerId,
            'item_id': itemId
        });
    }

    static async wallDelete(ownerId, itemId) {
        return this.get(apiConfig.wallDelete, {
            'owner_id': ownerId,
            'post_id': itemId
        });
    }

    static async saveWallPhoto(server, photo, hash) {
        return this.post(apiConfig.saveWallPhoto, {
            'server': server,
            'photo': photo,
            'hash': hash
        });
    }

    static async getUploadPhotoBody(typeFile, filePath, fileName) {
        const formData = new FormData();
        const image = await fs.readFile(filePath);
        formData.append(typeFile, image, fileName);
        return formData;
    }
} module.exports = VkApiUtils;
