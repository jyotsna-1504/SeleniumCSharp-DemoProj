using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectPOC.Pages
{
    public class UserRegistrationPage
    {
        public readonly IWebDriver _driver;
        public UserRegistrationPage(IWebDriver driver) => _driver = driver;
        public static string userEmail = null;
        public static string userPwd = null;


        //Identifiers
        IWebElement TxtUsername => _driver.FindElement(By.Id("name_first"));
        IWebElement TxtLastname => _driver.FindElement(By.Id("name_last"));
        IWebElement TxtEmail => _driver.FindElement(By.Id("email"));
        IWebElement TxtConfirmEmail => _driver.FindElement(By.Id("emailConfirm"));
        IWebElement TxtPwd => _driver.FindElement(By.Id("password"));
        IWebElement TxtConfirmPwd => _driver.FindElement(By.Id("input_password"));
        IWebElement SelectCountry => _driver.FindElement(By.Id("country"));

        IWebElement TxtZipcode => _driver.FindElement(By.Id("zipWork"));
        IWebElement SelectOccupation => _driver.FindElement(By.Id("occupation"));
        IWebElement SpGrp => _driver.FindElement(By.Id("specialtyGroup"));
        //button
        IWebElement BtnSubmit => _driver.FindElement(By.XPath("//input[@alt='JOIN']"));



        //Methods 
        public LandingPage RegisterUser()
        {
            TxtUsername.SendKeys("Agasthya");
            TxtLastname.SendKeys("singh");
            TxtEmail.SendKeys("Agasthya@gmail.com");
            TxtConfirmEmail.SendKeys("Agasthya@gmail.com");
            userEmail = TxtEmail.GetAttribute("value");
            Console.WriteLine("User registered with email: " + userEmail);

            TxtPwd.SendKeys("System@123");
            TxtConfirmPwd.SendKeys("System@123");
            userPwd = TxtEmail.GetAttribute("value");
            Console.WriteLine("User registered with password : " + userPwd);

            // SelectCountry.SendKeys("FirstSampleUser");
            Console.WriteLine(" Existing selected value : " + SelectCountry.GetAttribute("value"));

            SelectElement oSelect = new OpenQA.Selenium.Support.UI.SelectElement(SelectCountry);
            oSelect.SelectByValue("1108");
            Console.WriteLine(" New selected value : " + SelectCountry.GetAttribute("value"));

            SelectElement occupationSelect = new OpenQA.Selenium.Support.UI.SelectElement(SelectOccupation);
            Console.WriteLine(" Existing occupation : " + SelectOccupation.GetAttribute("value"));
            SelectElement occupationValue = new SelectElement(SelectOccupation);
            occupationValue.SelectByText("Lab Director");
            Console.WriteLine(" New selected occupation is : " + SelectOccupation.GetAttribute("value"));

            //sub-category dropdown
            Thread.Sleep(1000);

            if (SpGrp.Displayed)
            {
                SelectElement specialtyGroup = new SelectElement(SpGrp);
                specialtyGroup.SelectByText("Dental Lab Director");
                Console.WriteLine(" New sub-speciality grp is : " + SpGrp.GetAttribute("text"));
            }

            BtnSubmit.Click();



            return new LandingPage(_driver);
        }
    }
}
