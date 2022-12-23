using NUnit.Framework;
using UserInterfaceTest.Templates;
using UserInterfaceTest.Forms.Pages;
using System.Threading;
using UserInterfaceTest.Models;
using UserInterfaceTest.Utils;
using System;
using System.Collections.Generic;
using UserInterfaceTest.Configuration;
using Aquality.Selenium.Browsers;


namespace UserInterfaceTest
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test—ase1()
        {
            HomePage homePage = new HomePage();
            Assert.IsTrue(homePage.State.IsDisplayed,"Home page not opened");
            
            homePage.ClickLink();
            GamePage gamePage = new GamePage();
            Assert.IsTrue(gamePage.State.IsDisplayed,"Game page not opened");
            Assert.IsTrue(gamePage.FirstCard.State.IsDisplayed, "First card not opened");

            User randomUser = UserDataGenerator.GetUser();
            gamePage.FirstCard.SetUser(randomUser);
            gamePage.FirstCard.ClickOnTermsCheckBox();
            gamePage.FirstCard.ClickNext();
            Assert.IsTrue(gamePage.SecondCard.State.IsDisplayed, "Second card not opened");
            gamePage.SecondCard.UnselectAllCheckboxes();

            var interestsCount = gamePage.SecondCard.GetCheckBoxCount;
            var random = new Random();
            var number = random.Next(1, interestsCount);
            gamePage.SecondCard.SetAvatar(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                              $"Resources\\Environment\\{Configuration.Environment.CurrentEnvironmentName}\\test.jpg"));
            List<int> alreadyChecked = new List<int>();
            for (int i =0; i<3; i++) 
            {
                while (gamePage.SecondCard.GetInterestText(number).ToLower().Contains("select") || alreadyChecked.Contains(number))
                    number = random.Next(1, interestsCount);
                
                gamePage.SecondCard.CheckInterest(number);
                alreadyChecked.Add(number);
            }
            gamePage.SecondCard.ClickNext();
            Assert.IsTrue(gamePage.ThirdCard.State.IsDisplayed,"Third card not opened");
        }


        [Test]
        public void TestCase2() 
        {
            HomePage homePage = new HomePage();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page not opened");
            homePage.ClickLink();
            GamePage gamePage = new GamePage();
            Assert.IsTrue(gamePage.State.IsDisplayed, "Game page not opened");   
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => gamePage.Help.State.IsDisplayed),"Help form not displayed at start");
            gamePage.Help.ClickSendToBottom();
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => !gamePage.Help.State.IsDisplayed), "Help form displayed after close");
        }

        [Test]
        public void TestCase3() 
        {
            HomePage homePage = new HomePage();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page not opened");
            homePage.ClickLink();
            GamePage gamePage = new GamePage();
            Assert.IsTrue(gamePage.State.IsDisplayed, "Game page not opened");
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(()=>gamePage.Cookies.State.IsDisplayed),"Cookies form not displayed");
            gamePage.Cookies.AcceptCookies();
            Assert.IsTrue(AqualityServices.ConditionalWait.WaitFor(() => !gamePage.Cookies.State.IsDisplayed), "Cookies form didnt close after clicking accept button");
        }

        [Test]
        public void TestCase4() 
        {
            HomePage homePage = new HomePage();
            Assert.IsTrue(homePage.State.IsDisplayed, "Home page not opened");
            homePage.ClickLink();
            GamePage gamePage = new GamePage();
            Assert.IsTrue(gamePage.State.IsDisplayed, "Game page not opened");
            var startTime = Configuration.Configuration.GetTestData("startTime");
            Assert.AreEqual(startTime, gamePage.GetTime(),string.Format("Time dont starts from {0}",startTime));
        }
    }
}