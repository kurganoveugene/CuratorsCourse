const BasePage = require('./basePage');
const Button = require('../baseElement/button');
const TextBox = require('../baseElement/textbox');
const browser = require('../browser/browser');
class LoginPage extends BasePage {

    constructor() {
        super(new Button('//div[contains(@class,"vkc__EnterLogin__caption")]', 'Введите номер'), 'Login Page');
    }

    get inputPhone() {
        return new TextBox('//input[contains(@name,"login")]', 'Input Phone');
    }

    get nextButton() {
        return new Button('//button[contains(@type,"submit")]', 'Next Button');
    }

    get inputPassword() {
        return new TextBox('//input[contains(@name,"password")]', 'Input Password');
    }

    async login(phone, password) {
        await this.inputPhone.sendText(phone);
        await this.nextButton.click();
        await this.inputPassword.sendText(password);
        await this.nextButton.click();
    }
} module.exports = new LoginPage();
