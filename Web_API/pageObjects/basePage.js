const browser = require('../browser/browser');
const config = require('../data/config.json');
const logger = require('../utils/logger');
module.exports = class BasePage {

    constructor(element, pageName) {
        this.element = element;
        this.name = pageName;
    }

    async isPageOpened() {
        const isPageElement = await this.element.isElementDisplayed();
        logger.info(`${this.name} has been opened`)
        return isPageElement;
    }

    async open() {
        return browser.openWindow(config.url);
    }
}
