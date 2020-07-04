using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectPOC.Pages
{
   
    public class LoginPage
    {
        
        public IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;
        //UserRegistrationPage regUser = new UserRegistrationPage(driver);

        IWebElement TxtEmail => _driver.FindElement(By.Name("emailuser"));
        IWebElement TxtPwd => _driver.FindElement(By.Name("emailpassword"));
        IWebElement BtnSubmit => _driver.FindElement(By.Name("email_submit_button"));
        //IWebElement BtnRegisterNow => _driver.FindElement(By.LinkText("Register Now"));
        //a[@class='btn btn-lg btn-primary btn-block']
        public IWebElement BtnRegisterNow => _driver.FindElement(By.XPath("a[@class='btn btn-lg btn-primary btn-block']"));
        public void LoginWithValidEmail()
        {
            TxtEmail.SendKeys(UserRegistrationPage.userEmail);
            TxtPwd.SendKeys(UserRegistrationPage.userPwd);
            BtnSubmit.Click();

        }
        public void ClickRegisterNow()
        {
            Thread.Sleep(3000);
            //_driver.SwitchTo().Window(_driver.WindowHandles.Last());
            var popup = _driver.WindowHandles[1]; // handler for the new tab
            Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
            Assert.AreEqual(_driver.SwitchTo().Window(popup).Url, "https://www.epocrates.com/liteRegistration.do?mode=display&ICID=website"); // url is OK  
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            BtnRegisterNow.Click();
        }
        /*public LoginPage GoToLoginPage()
        {
            Thread.Sleep(3000);
            LnkLogin.Click();
            return new LoginPage(_driver);
        }*/
    }
}
