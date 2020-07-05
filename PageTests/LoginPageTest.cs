using NUnit.Framework;
using ProjectPOC.Base;
using ProjectPOC.Pages;
using ProjectPOC.Utility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace ProjectPOC.PageTests
{
    class LoginPageTest : BaseClass
    {
        //public string FileName = Environment.CurrentDirectory.ToString() + "\\ConfigFile\\TestDataFile.xlsx";

        [Test]
        public void VerifyRegisterNowIsClicked()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
           
            regNow.ClickRegisterNow();
            Assert.AreEqual(driver.SwitchTo().Window(driver.WindowHandles[1]).Url, "https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website"); // url is OK  
        }


        [Test]
        public void CreateUserAndLoginWithThatUser()
        {
            //Boolean correctPage = false;
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
            regNow.ClickRegisterNow();
            Assert.AreEqual(driver.SwitchTo().Window(driver.WindowHandles[1]).Url, "https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website"); // url is OK  

            UserRegistrationPage ur = new UserRegistrationPage(driver);
            //ur.RegisterUser();
            Dictionary<string,string> UserData = ur.GetRegisterUserValuesFromExcel();
            ur.RegisterUserExcel(ur.UserData);
            LandingPage lp = new LandingPage(driver);
           
            lp.MoveToLoginPage();

            regNow.Login(ExcelOperations.ReadData(1, "Email"), ExcelOperations.ReadData(1, "Password"));

        }

        [Test]
        public void VerifyLoginWithAlreadyCreatedUser()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
            
            string FileName = Environment.CurrentDirectory.ToString() + "\\ConfigFile\\TestDataFile.xlsx";
            ExcelOperations.PopulateInCollection(FileName,"LoginUser");
            Thread.Sleep(1000);
            regNow.Login(ExcelOperations.ReadData(1, "Email"), ExcelOperations.ReadData(1, "Password"));
        }

        [Test]
        public void LoginWithInvalidEmail()
        {
            LoginPage logPg = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
            logPg.LoginWithoutSignout("test@120","System@123");
            String actualMsg = logPg.ReadMessage();
            Assert.AreEqual(actualMsg, "Your email and/or password is incorrect. Please try again.");

        }
    }
}
