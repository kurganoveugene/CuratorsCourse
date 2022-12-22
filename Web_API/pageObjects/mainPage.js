const BasePage = require('./basePage');
const Button = require('../baseElement/baseElement');
class MainPage extends BasePage {

    constructor() {
        super(new Button('//div[contains(@class,"VkIdForm__header")]', 'Вход вКонтакте'), 'Main Page');
    }

    get loginButton() {
        return new Button('//button[contains(@class,"VkIdForm__signInButton")]', 'Login button');
    }

    async clickLogin() {
        await this.loginButton.click();
    }
} module.exports = new MainPage();
