using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectPOC.Pages
{
   
    public class LandingPage
    {
        public IWebDriver _driver;
        public LandingPage(IWebDriver driver) => _driver = driver;
        //Locators
        public IWebElement BtnContinue => _driver.FindElement(By.Id("clickhandler"));
        IWebElement LnkSignOut => _driver.FindElement(By.LinkText("Sign Out"));

        public LoginPage MoveToLoginPage()
        {
            BtnContinue.Click();
            Thread.Sleep(3000);
            LnkSignOut.Click();
            return new LoginPage(_driver);
        }


    }
}
