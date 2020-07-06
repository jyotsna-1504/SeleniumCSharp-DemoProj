/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;*/
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ProjectPOC.Base
{
    [TestFixture]
    public class BaseClass
    {
        public static IWebDriver driver;

        [SetUp]
        public void LaunchBrowserWithURL()
        {
            //driver = new ChromeDriver();
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epocrates.com");
           
        }

        [TearDown]
        public void CloseOpenWindows()
        {
            Console.WriteLine("About to close all browser windows");
            driver.Quit();
        }
    }
 
}
