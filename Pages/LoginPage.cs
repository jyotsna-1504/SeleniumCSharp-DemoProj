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

        IWebElement ErrorMsg => _driver.FindElement(By.CssSelector("html body div#login_div_1.account div#login_div_2.error div#errorId.error em.errorfield"));

        public IWebElement BtnRegisterNow => _driver.FindElement(By.XPath("//a[@class='btn btn-lg btn-primary btn-block']"));
        public IWebElement LnkSignOut => _driver.FindElement(By.LinkText("Sign Out"));
        public void LoginWithValidEmail()
        {
            TxtEmail.SendKeys(UserRegistrationPage.userEmail);
            TxtPwd.SendKeys(UserRegistrationPage.userPwd);
            BtnSubmit.Click();

        }

        public void Login(string email, string password)
        {
            Thread.Sleep(2000);
            TxtEmail.SendKeys(email);
            TxtPwd.SendKeys(password);
            BtnSubmit.Submit();
            LnkSignOut.Click();
        }
        
        public void ClickRegisterNow()
        {
            Thread.Sleep(3000);        
            Console.WriteLine("Total windows on page : " + _driver.WindowHandles.Count);          
            Console.WriteLine("Current window is : " + _driver.CurrentWindowHandle);
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
            Thread.Sleep(1000);
            
            BtnRegisterNow.Click();
        }
        
        public string ReadMessage()
        {
            String ActualMessage=ErrorMsg.GetAttribute("innerHTML");
            return ActualMessage;
        }

        public void LoginWithoutSignout(string email, string password)
        {
            Thread.Sleep(2000);
            TxtEmail.SendKeys(email);
            TxtPwd.SendKeys(password);
            BtnSubmit.Submit();
            
        }
    }
}
