using NUnit.Framework;
using ProjectPOC.Base;
using ProjectPOC.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPOC.PageTests
{
    
    class UserRegistrationPageTest : BaseClass
    {
        //[Test]
        public void VerifyUserRegistration()
        {
           // LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();

            LandingPage lp = new LandingPage(driver);

            //regNow.ClickRegisterNow();
            //Console.WriteLine("Landing Page url post ckicking RegisterNow is : " + driver.Url);
            //url shud be : https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website
            driver.Navigate().GoToUrl("https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website");
            UserRegistrationPage userReg = new UserRegistrationPage(driver);
            userReg.RegisterUser();
            Console.WriteLine("Landing Page url is : " + driver.CurrentWindowHandle);

            Assert.IsTrue(lp.BtnContinue.Displayed);

        }
    }
}
