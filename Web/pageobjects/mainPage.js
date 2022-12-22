const BasePage = require('./basePage');
const Button = require('../baseelement/baseelement');
class MainPage extends BasePage { 

    constructor() {
        super("//p[@class='start__paragraph'][1]", 'Main Page');
    }
   
    open() {
        return super.open('');
    }

    get btnNext(){
      return new Button('/html/body/div/div[1]/div/div[4]/p/a','Next page button');  
    } 
         
    async clckBtnNext(){
        await this.btnNext.clck();
    }      
} module.exports = new MainPage();
