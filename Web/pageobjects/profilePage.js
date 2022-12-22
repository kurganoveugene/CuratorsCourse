const BasePage = require('./basePage');
const Checkbox = require('../baseelement/checkbox');
const RandomUtil = require('../utils/randomUtil');
const Button = require('../baseelement/button');
class ProfilePage extends BasePage {  

    constructor() {
        super('//*[@class="avatar-and-interests__title" and contains(text(),"This is me")]', 'Profile Page');
    }

    get interest(){
        return new Checkbox(`//*[contains(text(),"${RandomUtil.getRandomInterest()}")]//..//*[@class="checkbox__box"]`,'Interest Checkbox');        
    }

    get nextButton(){
        return new Button('//*[@name="button" and contains(text(),"Next")]',"Next button")
    }

    get errorMessage(){
        return new Button('//*[@class="avatar-and-interests__error" and contains(text(),"Please upload a picture")]',"Error message");
    }

    async getErrorMessageColor(){
        const property = await this.errorMessage.getProperty('color');        
        return property.parsed.hex;
    }

    async getErrorMessageText(){
        return this.errorMessage.getElementText();
    }

    async clckNextBtn(){
        await this.nextButton.clck();
    }

   async pickInterest(){
       await this.interest.clck(); 
       await this.interest.clck();       
   }      
  
} module.exports = new ProfilePage();
