const logger = require('../utils/logger');
class BaseElement {
    constructor(locator, name) {
        this.locator = locator;
        this.name = name;
    }

    async getElementText() {
        const el = await this.getElement();
        await logger.info("Element has been found. Trying to get text");
        return el.getText();
    }

    async clck() {
        const el = await this.getElement();
        await logger.info("Element has been found. Trying to click");
        return el.click();
    }
 
    async isElementDisplayed(){
        try {
            const el = await this.getElement();
            await logger.info("Element has been found");          
            return el.isDisplayed();  
        } catch (error) {
            return false;
        }                      
    }

    async getElement() {
        await logger.info("Trying to get Element " + this.name);       
        const el = await $(this.locator);
        return el;
    }

    async getProperty(property){
        const el = await this.getElement();
        await logger.info("Element has been found. Trying to get CSSProperty");
        return el.getCSSProperty(property);
    }
} module.exports = BaseElement;