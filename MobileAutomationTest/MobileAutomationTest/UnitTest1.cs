using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;


namespace MobileAutomationTest
{
    [TestFixture]
   // class UnitTest1 : TestInicialize
    public class UnitTest1

    {
        public AppiumDriver<IWebElement> driver { get; set; }

        [SetUp]

        public void Inicialize()
        {
            Utils.StartApp();
        }
        
        [Test]
        public void Test1()
        {
            PageObject pageObject = new PageObject(Utils.driver);
            pageObject.Sucessfull_Income();
            // pageObject.Validates_Fields_CreateAccount();
            // pageObject.Create_Existing_Account();
            // pageObject.Create_Successfull_Account();
            pageObject.Login_User();
        } 
        
          
        
        [TearDown]
        public void CloseDriver()
        {
            Utils.driver.CloseApp();
            Utils.driver.Quit();
            
        }
        
        
    }
}
