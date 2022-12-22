const fetch = require('node-fetch');
const logger = require('./logger');
class RequestUtils {

    static async get(url) {
        try {
            logger.info('Trying to send get request by ' + url);
            const responseBody = await fetch(url);
            const jsonBody = await responseBody.json();
            const statusCode = await responseBody.status;
            logger.info('Status code is ' + statusCode);
            const obj = {
                responseBody: jsonBody,
                statusCode: statusCode,
            }
            return obj;
        } catch (error) {
            logger.error(error);
        }
    }

    static async post(url, body) {
        try {
            logger.info('Trying to send post request by ' + url);
            const responseBody = await fetch(url, {
                method: 'POST',
                body: body
            });
            const jsonBody = await responseBody.json();
            const statusCode = await responseBody.status;
            logger.info('Status code is ' + statusCode);
            return jsonBody;
        } catch (error) {
            logger.error(error);
        }
    }
} module.exports = RequestUtils;

