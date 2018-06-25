using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium;

namespace MobileAutomationTest
{
    class TestCases
    {
        private AppiumDriver<IWebElement> androidDriver;
        
        public void Validation_Test_Case()
        {
            PageObject pageObject = new PageObject(androidDriver);
            
            pageObject.Validates_Fields_CreateAccount();

        }
    }
}
