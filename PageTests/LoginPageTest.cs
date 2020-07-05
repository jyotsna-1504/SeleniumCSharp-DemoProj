using NUnit.Framework;
using ProjectPOC.Base;
using ProjectPOC.Pages;
using ProjectPOC.Utility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace ProjectPOC.PageTests
{
    class LoginPageTest : BaseClass
    {
       // public string FileName = Environment.CurrentDirectory.ToString() + "\\ConfigFile\\TestDataFile.xlsx";
        
        //[Test]
        public void VerifyRegisterNowIsClicked()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
           
           /* Console.WriteLine("Total windows on page : " + driver.WindowHandles.Count);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine("Current window is : " + driver.CurrentWindowHandle);
*/
            regNow.ClickRegisterNow();
            //Console.WriteLine("Landing Page url post ckicking RegisterNow is : " + driver.Url);
            //url shud be : https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website
            // driver.Navigate().GoToUrl("https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website");
        }


        //[Test]
        public void CreateUserAndLoginWithThatUser()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            hmpg_test.CheckNavigationToLoginPage();
            regNow.ClickRegisterNow();
            //driver.Navigate().GoToUrl("https://www.epocrates.com/liteRegistration.do");
            UserRegistrationPage ur = new UserRegistrationPage(driver);
            ur.RegisterUser();

            LandingPage lp = new LandingPage(driver);
            lp.MoveToLoginPage();

           // string Filename=
            //ExcelOperations.PopulateInCollection(FileName);

            regNow.Login(ExcelOperations.ReadData(1, "Email"), ExcelOperations.ReadData(1, "Password"));

        }

       [Test]
        public void VerifyLoginWithAlreadyCreatedUser()
        {
            LoginPage regNow = new LoginPage(driver);
            HomePageTest hmpg_test = new HomePageTest();
            //hmpg_test.CheckNavigationToLoginPage();
            driver.Navigate().GoToUrl("https://www.epocrates.com/account.do?mode=summary&ICID=website");
            string FileName = Environment.CurrentDirectory.ToString() + "\\ConfigFile\\TestDataFile.xlsx";
            ExcelOperations.PopulateInCollection(FileName);

            regNow.Login(ExcelOperations.ReadData(1, "Email"), ExcelOperations.ReadData(1, "Password"));


        }

    }
}
