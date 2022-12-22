const browser = require('../browser/browser');
module.exports = class BasePage { 
    
    constructor(locator, name){
        this.locator = locator;
        this.name = name;
    }
     
    async isPageOpened() {       
        await $(this.locator).waitForDisplayed()
        const isPageElement = await $(this.locator).isDisplayed();
        return isPageElement;  
    }  

    open () {        
        return browser.openWindow();
    }
}
