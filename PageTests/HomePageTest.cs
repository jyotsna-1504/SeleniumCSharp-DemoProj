using NUnit.Framework;
using ProjectPOC.Base;
using ProjectPOC.Pages;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ProjectPOC.PageTests
{
    public class HomePageTest : BaseClass
    {
        
        [Test]
        public void CheckNavigationToLoginPage()
        {
            HomePage hp = new HomePage(driver);
            hp.GoToLoginPage();           
            Assert.AreEqual("https://www.epocrates.com/account.do?mode=summary&ICID=website", driver.Url);
        }
    }
}
