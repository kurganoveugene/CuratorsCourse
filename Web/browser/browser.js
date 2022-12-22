const config = require('../data/config.json');
class Browser{
    async openWindow(){
        await browser.url(config.baseUrl);
        return this.maxWindow();
    }

    async pause(){
        return browser.pause(config.timeout);
    }

    async maxWindow(){
        return browser.maximizeWindow();
    }   
    
} module.exports = new Browser();