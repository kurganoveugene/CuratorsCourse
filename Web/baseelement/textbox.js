const BaseElement = require("./baseelement");
const logger = require('../utils/logger');
class TextBox extends BaseElement{

    constructor(locator, name){
        super(locator, name);
    }  

    async sendText(text) {
        const el = await this.getElement();
        logger.info("Element has been found. Trying to send text");
        return el.setValue(text);
    }
} module.exports = TextBox;