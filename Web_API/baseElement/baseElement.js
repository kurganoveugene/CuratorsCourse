const logger = require('../utils/logger');
class BaseElement {
    constructor(locator, name) {
        this.locator = locator;
        this.name = name;
    }

    async getElementText() {
        const el = await this.getElement();
        await logger.info('Elements has been found. Trying to get text');
        return el.getText();
    }

    async getElementsText() {
        const els = await this.getElements();
        await logger.info('Elements has been found. Trying to get text');
        const arr = [];
        for (let value of els) {
            arr.push(await value.getText());
        };
        return arr;
    }

    async click() {
        const el = await this.getElement();
        await logger.info('Element has been found. Trying to click');
        return el.click();
    }

    async isElementDisplayed() {
        try {
            const el = await this.getElement();
            await logger.info('Element has been found');
            return el.isDisplayed();
        } catch (error) {
            await logger.error(error);
            return false;
        }
    }

    async getElement() {
        await logger.info(`Trying to get Element ${this.name}`);
        const el = await $(this.locator);
        return el;
    }

    async getProperty(property) {
        const el = await this.getElement();
        await logger.info('Element has been found. Trying to get CSSProperty');
        return el.getCSSProperty(property);
    }

    async getElements() {
        await logger.info(`Trying to get Elements ${this.name}`);
        const elemets = await $$(this.locator);
        return elemets;
    }

    async getElementAttribute(attribute) {
        const el = await this.getElement();
        await logger.info('Element has been found. Trying to get attribute');
        return el.getAttribute(attribute);
    }
} module.exports = BaseElement;