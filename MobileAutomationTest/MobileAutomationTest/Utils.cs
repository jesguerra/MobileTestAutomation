using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace MobileAutomationTest
{
   public static class Utils
    {
        public static AppiumDriver<IWebElement> driver { get; set; }
        public static WebDriverWait wait;
        public static void StartApp()
        {

            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("deviceName", "Android");
         //   cap.SetCapability("app", "C:\\Merlin\\Merlin-qaDebug-2.12.1.apk");
            cap.SetCapability("appPackage", "com.merlinjobs.android");
            cap.SetCapability("appActivity", ".main.SplashActivity");
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("udid", "CB5A2AYLCQ");
          //  cap.SetCapability("skipUnlock", true);
            cap.SetCapability("platformVersion", "6.0");


            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("img_merlin_logo")));

            

        }
        public static void Asserts(string Escenario ,string ExpectMessage, string ActualMessage)
        {
            try{
                Assert.AreEqual(ExpectMessage, ActualMessage); //Assert 
                
                //Write the Messsage Assert in console
                Console.WriteLine("Assert OK:"+  Escenario + ActualMessage);
            }
            catch(Exception){

                //Write the Message Assert Fail in Console
                Console.WriteLine("Assert Faild: " + Escenario + ": " + ActualMessage +"");
               

            }
        }

        /*
         * Method, validates if the element is visible
         */
        public static void VisibleElement(string EscenarioDesc, IWebElement IWebElement)
        {
            try{
                bool Exist = IWebElement.Displayed;

                if (Exist)
                {
                    Console.WriteLine(EscenarioDesc + ":" + Exist);
                }
                
            }
            catch(Exception){

                Console.WriteLine(EscenarioDesc + ": the item is not visible");
            }  

        }

        public static void Enable(string EscenarioDesc, IWebElement IWebElement)
        {
            try
            {
                bool Enable = IWebElement.Selected;

                if (Enable)
                {
                    Console.WriteLine(EscenarioDesc + " The element"+ Enable);
                }
                else
                {
                    Console.WriteLine(EscenarioDesc + " the Element : "+ "Is Disable");
                }

            }
            catch (Exception)
            {

                Console.WriteLine(EscenarioDesc +"The element is not Enable");
            }

        }
        public static string Focus_Element(string element)
        {
            try{
                IWebElement WebElement =  driver.FindElementById(element);
                return WebElement.GetAttribute("focusable");

            }
            catch(Exception Error){

                Console.WriteLine("Focus Element could not be execute",Error);
                return "Element No found";
            }
        }

        public static string Get_Attribute(IWebElement element, string Attribute)
        {
            try{ 
                return element.GetAttribute(Attribute);

            }
            catch (Exception Error)
            {

                Console.WriteLine("The Attribite element is not found", Error);
                return "Element No found";
            }
        }


        /*
         * Hide Keyboard
         */

        public static void HideKeyboard()
        {
            try{
                driver.HideKeyboard();
            }
            catch (Exception ErrorM)
            {
                Console.Write("-- Keyboard --",ErrorM);
            }
        }

        /*
         * Enter text Keyboard
         */ 

        public static void SendKeys_Keyboard(string Value)
        {
            try{
                driver.Keyboard.SendKeys(Value);
            }
            catch(Exception ErrorM)
            {
                Console.WriteLine("--Keyboard-- send keys",ErrorM);
            }
        }
        public static void Close()
        {
             
            driver.CloseApp();
            driver.Quit();

        }

        
    }


}
