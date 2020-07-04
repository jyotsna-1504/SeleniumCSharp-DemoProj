using NUnit.Framework;
using ProjectPOC.Base;
using ProjectPOC.Pages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectPOC.PageTests
{
    class LoginPageTest : BaseClass
    {
       

        //[Test]
        public void VerifyRegisterNowIsClicked()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
            regNow.ClickRegisterNow();
            //Console.WriteLine("Landing Page url post ckicking RegisterNow is : " + driver.Url);
            //url shud be : https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website
            driver.Navigate().GoToUrl("https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website");
        }


        [Test]
        public void CreateUserAndLoginWithThatUser()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
            //regNow.ClickRegisterNow();
            driver.Navigate().GoToUrl("https://www.epocrates.com/liteRegistration.do");
            UserRegistrationPage ur = new UserRegistrationPage(driver);
            ur.RegisterUser();

            LandingPage lp = new LandingPage(driver);
            lp.MoveToLoginPage();

            regNow.LoginWithValidEmail();




        }

    }
}
