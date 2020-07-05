using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectPOC.Utility;
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
        public Dictionary<string, string> UserData;


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
            TxtUsername.SendKeys("Ankita");
            TxtLastname.SendKeys("singh");
            TxtEmail.SendKeys("Ankitasingh@gmail.com");
            TxtConfirmEmail.SendKeys("Ankitasingh@gmail.com");
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

        public Dictionary<string,string> GetRegisterUserValuesFromExcel()
        {
            string FileName = Environment.CurrentDirectory.ToString() + "\\ConfigFile\\TestDataFile.xlsx";
            ExcelOperations.PopulateInCollection(FileName, "RegisterUser");
            UserData = new Dictionary<string, string>();
            UserData.Add("FirstName", ExcelOperations.ReadData(1, "FirstName"));
            UserData.Add("LastName", ExcelOperations.ReadData(1, "LastName"));
            UserData.Add("Email", ExcelOperations.ReadData(1, "Email"));
            UserData.Add("ConfirmEmail", ExcelOperations.ReadData(1, "ConfirmEmail"));
            UserData.Add("Password", ExcelOperations.ReadData(1, "Password"));
            UserData.Add("ConfirmPassword", ExcelOperations.ReadData(1, "ConfirmPassword"));
            UserData.Add("Country", ExcelOperations.ReadData(1, "Country"));
            UserData.Add("ZipCode", ExcelOperations.ReadData(1, "ZipCode"));
            UserData.Add("Occupation", ExcelOperations.ReadData(1, "Occupation"));
            UserData.Add("Speciality", ExcelOperations.ReadData(1, "Speciality"));
            return UserData;
        } 
       

        public LandingPage RegisterUserExcel(Dictionary<string,string> UserData)
        {
            TxtUsername.SendKeys(UserData["FirstName"]);
            TxtLastname.SendKeys(UserData["LastName"]);
            TxtEmail.SendKeys(UserData["Email"]);
            TxtConfirmEmail.SendKeys(UserData["ConfirmEmail"]);
            userEmail = TxtEmail.GetAttribute("value");
            Console.WriteLine("User registered with email: " + userEmail);

            TxtPwd.SendKeys(UserData["Password"]);
            TxtConfirmPwd.SendKeys(UserData["ConfirmPassword"]);
            userPwd = TxtEmail.GetAttribute("value");
            Console.WriteLine("User registered with password : " + userPwd);

            // SelectCountry.SendKeys("FirstSampleUser");
            Console.WriteLine(" Existing selected value : " + SelectCountry.GetAttribute("value"));

            SelectElement oSelect = new OpenQA.Selenium.Support.UI.SelectElement(SelectCountry);
            oSelect.SelectByText(UserData["Country"]);
            Console.WriteLine(" New selected value : " + SelectCountry.GetAttribute("value"));

            SelectElement occupationSelect = new OpenQA.Selenium.Support.UI.SelectElement(SelectOccupation);
            Console.WriteLine(" Existing occupation : " + SelectOccupation.GetAttribute("value"));
            SelectElement occupationValue = new SelectElement(SelectOccupation);
            occupationValue.SelectByText(UserData["Occupation"]);
            Console.WriteLine(" New selected occupation is : " + SelectOccupation.GetAttribute("value"));

            //sub-category dropdown
            Thread.Sleep(1000);

            if (SpGrp.Displayed)
            {
                SelectElement specialtyGroup = new SelectElement(SpGrp);
                specialtyGroup.SelectByText(UserData["Speciality"]);
                Console.WriteLine(" New sub-speciality grp is : " + SpGrp.GetAttribute("text"));
            }

            BtnSubmit.Click();

            return new LandingPage(_driver);
        }
    }
}
