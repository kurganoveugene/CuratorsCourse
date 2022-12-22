const MainPage = require('../../pageobjects/mainPage');
const LoginPage = require('../../pageobjects/loginPage');
const ProfilePage = require('../../pageobjects/profilePage');
const loginData = require('../../data/loginData.json');
const assert = require('chai').assert;

describe('Userinterface testing', () => {

    beforeEach(async function () {  
        await MainPage.open();
        const isMainPageOpened = await MainPage.isPageOpened();
        assert.isTrue(isMainPageOpened, 'MainPage is not opened');
        await MainPage.clckBtnNext();
    })

    it('Login form testing', async () => {                 
        const isLoginPageOpened = await LoginPage.isPageOpened();
        assert.isTrue(isLoginPageOpened, 'LoginPage is not opened');
        await LoginPage.login(loginData.password, loginData.email, loginData.domain);
        const isProfilePageOpened = await ProfilePage.isPageOpened();
        assert.isTrue(isProfilePageOpened, 'ProfilePage is not opened');
        await ProfilePage.pickInterest();    
        await ProfilePage.clckNextBtn();
        const errorMessageText = await ProfilePage.getErrorMessageText();
        assert.equal(errorMessageText, 'Please upload a picture','Error message had not appear'); 
        const errorMessageColor = await ProfilePage.getErrorMessageColor();    
        assert.equal(errorMessageColor,"#29c566","Error message is not green");
    });

    it('Help form testing', async () => {                  
        await LoginPage.hideHelpForm();
        const isHidenHelpForm = await LoginPage.isHidenHelpForm();
        assert.isTrue(isHidenHelpForm, 'Help form is not hidden');             
    });

    it('Coockies testing', async () => {         
        await LoginPage.acceptCoockies();      
        const isAcceptCoockiesDisplayed = await LoginPage.isAcceptCoockiesDisplayed();
        assert.isFalse(isAcceptCoockiesDisplayed,"Coockies has not accepted");                       
    });

    it('Timer testing', async () => {              
        const startTime = await LoginPage.getTime();        
        assert.equal(startTime, '00:00:01','timer do not starts from "00:00"');                 
    });
});


