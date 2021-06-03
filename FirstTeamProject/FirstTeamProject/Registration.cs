using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace FirstTeamProject
{
    public class Registration
    {
        
        public string _validMail = "";
        private ChromeDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);  
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void FirstRegistrationPage()
        {
            var registrationPage = new RegistrationPage(_webDriver);
            registrationPage.OpenPage()
            .SetFirstName("Den")
            .SetSecondName("Dende")
            .SetEmail()
            .SetPassword("Nicenice123#")
            .SetConfirmPassword("Nicenice123#")
            .SetPhomeNumber("111.111.1111")
            .ClickSubmit();

            var url = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", url);            
        }

        [Test]
        public void SecondRegistrationPage()
        {
            var registrationPage = new RegistrationPage(_webDriver);
            registrationPage.OpenPage()
            .SetFirstName("Den")
            .SetSecondName("Dende")
            .SetEmail()
            .SetPassword("Nicenice123#")
            .SetConfirmPassword("Nicenice123#")
            .SetPhomeNumber("111.111.1111")
            .ClickSubmit();

            System.Threading.Thread.Sleep(3000);                      

            var companyName = _webDriver.FindElement(By.CssSelector("[name = 'company_name']"));
            companyName.SendKeys("Test");

            var companySite = _webDriver.FindElement(By.CssSelector("[name = 'company_website']"));
            companySite.SendKeys("Test.com");

            var location = _webDriver.FindElement(By.CssSelector("[name = 'location']"));
            location.SendKeys("b");
            _webDriver.FindElement(By.CssSelector("[class = 'pac-item-query']")).Click();

            _webDriver.FindElement(By.CssSelector("[name = 'industry']")).Click();
            System.Threading.Thread.Sleep(1500);

            _webDriver.FindElements(By.CssSelector("[role = 'option']"))[2].Click();            

            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.CssSelector("[type = 'submit']")).Click();        

            System.Threading.Thread.Sleep(3000);            

            var url = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", url);
        }
    }
}