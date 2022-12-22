const BasePage = require('./basePage');
const Button = require('../baseelement/button');
const Dropdown = require('../baseelement/dropdown');
const Checkbox = require('../baseelement/checkbox');
const TextBox = require('../baseelement/textbox');
const randomUtil = require('../utils/randomUtil');
const browser = require('../browser/browser');
class LoginPage extends BasePage {   

    constructor() {
        super('//*[@class="login-form__terms-conditions"]', 'Login Page');
    }
  
    get inputPassword(){
        return new TextBox('//*[@placeholder="Choose Password"]','Input Password');
    }

    get inputEmail(){
        return new TextBox('//*[@placeholder="Your email"]','Input email');
    }

    get inputDomain(){
        return new TextBox('//*[@placeholder="Domain"]','Input domain');
    }

    get otherDropdown(){
        return new Dropdown('//*[@class="dropdown__field"]','Other Dropdown');
    }

    get dotCom(){
        return new Button('//*[@class="dropdown__list-item" and contains(text(),".com")]',"Dot com");
    } 
    
    get acceptTermsAndConditionsCheckbox(){
        return new Checkbox('//*[@class="checkbox__box"]','Checkbox accept Terms And Conditions');
    }

    get nextButton(){
        return new Button('//*[@class="button--secondary"]',"Next button");
    }
   
    get sendToBtmBtn(){
        return new Button('//*[@class="button button--solid button--blue help-form__send-to-bottom-button"]','Send to bottom button');
    }

    get coockiesAcceptBtn(){
        return new Button('//*[@name="button" and contains(text(),"Not really, no")]',"Coockies accept button");
    }

    get timer(){
        return new Button('//*[@class="timer timer--white timer--center"]','Timer');
    }

    get hidenHelpForm(){
        return new Button('//*[@class="help-form is-hidden"]','Hiden Form');
    }

    async isHidenHelpForm(){
        return this.hidenHelpForm.isElementDisplayed();
    }

    async getTime(){
        await browser.pause();
        return this.timer.getElementText();
    }

    async acceptCoockies(){
        await this.coockiesAcceptBtn.clck();
    }

    async isAcceptCoockiesDisplayed(){
        return this.coockiesAcceptBtn.isElementDisplayed();
    }   

    async hideHelpForm(){
        await this.sendToBtmBtn.clck();       
    }
        
    async login(password, email, domain) {    
        await this.inputPassword.sendText(password+randomUtil.getRandomText());
        await this.inputEmail.sendText(email+randomUtil.getRandomText());
        await this.inputDomain.sendText(domain);
        await this.otherDropdown.clck();      
        await this.dotCom.clck();
        await this.acceptTermsAndConditionsCheckbox.clck();
        await this.nextButton.clck();        
    }
} module.exports = new LoginPage();
