using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;

namespace MobileAutomationTest
{
    class TestInicialize
    {
        /*
         * Method Start App Session
         * Contains the Configuration Capabilitys
         */
        
        public AppiumDriver<IWebElement> driver { get; set; }
        

        [SetUp]
        public void Inicialize()
        {
            Utils.StartApp();
        }


        [TearDown]
        public void CloseDriver()
        {
            Utils.driver.CloseApp();
            Utils.driver.Quit();

        }


    }
}
