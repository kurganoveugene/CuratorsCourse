const config = require('../data/config.json');
const logger = require('../utils/logger');
class Browser {
    async openWindow(baseUrl) {
        logger.info('Trying open browser');
        await browser.url(baseUrl);
        return this.maxWindow();
    }

    async pause(timeout = config.timeout) {
        logger.info('Seting up pause in ' + timeout);
        return browser.pause(timeout);
    }

    async maxWindow() {
        logger.info('Trying to maximize window');
        return browser.maximizeWindow();
    }
} module.exports = new Browser();