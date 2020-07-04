using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectPOC.Pages
{
    public class HomePage
    {
        public readonly IWebDriver _driver;
        public HomePage(IWebDriver driver) => _driver = driver;

        IWebElement LnkLogin => _driver.FindElement(By.LinkText("Login"));

        public LoginPage GoToLoginPage()
        {
            Thread.Sleep(3000);
            LnkLogin.Click();
            //_driver.SwitchTo().Window(_driver.WindowHandles.Last());

            return new LoginPage(_driver);
        }

    }
}
