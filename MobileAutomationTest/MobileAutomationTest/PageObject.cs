using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomationTest
{
    class PageObject
    {
        /*
         * Elements of Create Account
         */
        private AppiumDriver<IWebElement> _driver;
        private AndroidDriver<IWebElement> driver { get; set; }


        public PageObject(AppiumDriver<IWebElement> androidDriver)

        {
            this._driver = androidDriver;
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.Id, Using = "img_merlin_logo")]
        public IWebElement Logo { get; set; }

        [FindsBy(How = How.Id, Using = "text_title")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Id, Using = "button_create_account")]
        public IWebElement Create_Account_Button { get; set; }

        [FindsBy(How = How.Id, Using = "button_login")]
        public IWebElement Start_Sesion { get; set; }

        [FindsBy(How = How.Id, Using = "et_account_email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "et_account_password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "container_button_loading")]
        public IWebElement Next_Button { get; set; }

        [FindsBy(How = How.Id, Using = "_error_message")]
        public IWebElement ErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "button_hide_password")]
        public IWebElement HidePassword { get; set; }

        [FindsBy(How = How.Id, Using = "text_sign_up_name_title")]
        public IWebElement Name_Title_Field { get; set; }

        [FindsBy(How = How.Id, Using = "et_name")]
        public IWebElement Name_Field { get; set; }

        [FindsBy(How = How.Id, Using = "text_skip")]
        public IWebElement Text_Skip { get; set; }

        [FindsBy(How = How.Id, Using = "etZipCode")]
        public IWebElement Zip_Code { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='PERMITIR']")]
        public IWebElement Permission_Allow { get; set; }

        [FindsBy(How = How.Id, Using = "text_sign_up_work_experience_category_position_title")]
        public IWebElement Select_Job_Title { get; set; }

        [FindsBy(How = How.Id, Using = "container_button_loading")]
        public IWebElement Button_Loading { get; set; }

        [FindsBy(How = How.Id, Using = "text_sign_up_complete_profile_title")]
        public IWebElement Profile_Picture_Title { get; set; }

        [FindsBy(How = How.Id, Using = "text_sign_up_candidate_congratulation_title")]
        public IWebElement Congrulation_Title { get; set; }

        [FindsBy(How = How.Id, Using = "tv_candidate_name")]
        public IWebElement Candidate_Name { get; set; }

        [FindsBy(How = How.Id, Using = "snackbar_text")]
        public IWebElement Error_Account { get; set; }

        [FindsBy(How = How.Id, Using = "button_back_step")]
        public IWebElement Back_Button { get; set; }

        [FindsBy(How = How.Id, Using = "tvZipCodeCurrentLocation")]
        public IWebElement Location { get; set; }

        [FindsBy(How = How.Id, Using = "_icon_tab_profile")]
        public IWebElement Icon_Profile { get; set; }

        [FindsBy(How = How.Id, Using = "_image_settings")]
        public IWebElement Image_Settings { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='Log Out']")]
        public IWebElement Log_Out { get; set; }

        [FindsBy(How = How.Id, Using = "button_login")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.Id, Using = "text_login_title")]
        public IWebElement Welcome_back_Title { get; set; }

        [FindsBy(How = How.Id, Using = "_button_got_it")]
        public IWebElement GotIt_Button { get; set; }

        [FindsBy(How = How.Id, Using = "_tv_search")]
        public IWebElement Find_Jobs { get; set; }

        [FindsBy(How = How.Id, Using = "_text_name")]
        public IWebElement Text_Name { get; set; }
        /*
         * Test Data
         */

        public const string VALUE_EMAIL = "jhonesguerra_2011@hotmail.es";
        public const string VALUE_EMAIL2 = "jhonesguerra2011@hotmail.es";
        public const string VALUE_EMAIL3 = "jhonesguerra2798@gmail.com";
        public const string VALUE_PASS = "Esguerra";
        public const string VALUE_INCORRECT_EMAIL = "ttststststs";
        public const string VALUE_HIDE_PASS = "••••••••";
        public const string EXPECT_FRAME_NAME = "What’s your name?";
        public const string VALUE_NAME = "Johnathan Esguerra";
        public const string VALUE_ZIP_CODE = "5434";
        public const string EXPECT_CATEGORY_TEXT = "Please select the category of your previous job";
        public const string EXPECT_PROFILE_PICTURE = "Add your profile picture";
        public const string EXPECT_COMPLETE_PROFILE = "Please complete your profile";
        public const string EXPECT_CANDIDATE_NAME = "Johnathan Esguerra";
        public const string EXPECT_CREATE_COUNT = "Error:  It looks like youâ€™ve already registered. Please go back and log in.";
        public const string EXPECT_WELCOME_BACK_TITLE = "Welcome back!";
        public const string EXPECT_FIND_JOBS_TITLE = "Find Jobs";
        




        /*
         * Method validates the create account fields
         */
        public void Validates_Fields_CreateAccount()
        {
            try
            {
                Create_Account_Button.Click();
                Utils.VisibleElement("Validates the Email Field is visible", Email);
                Utils.VisibleElement("Validates the Password Field is visible", Password);
                Utils.Enable("Validates the Next Button is Disable", Next_Button);
                Email.Click();
                Email.SendKeys(VALUE_INCORRECT_EMAIL); //Enter text incorrect
                Password.Click();
                Utils.VisibleElement("Validates the Error message is visible", ErrorMessage); //Validate the Error message is visible
                Utils.Asserts("Validates the password field is not Focusable", "false", Utils.Focus_Element("et_account_password"));
                Utils.Enable("Validates the Next Button is Disable", Next_Button);

                Password.Click();
                Utils.Asserts("Validates the password field is Focusable", "true", Utils.Focus_Element("et_account_password"));
                Password.SendKeys(VALUE_PASS);
                Utils.HideKeyboard();
                Utils.Enable("Validates the Next Button is Disable", Next_Button);
                HidePassword.Click();
                Utils.Asserts("Validate the Password Hide correct", VALUE_HIDE_PASS, Utils.Get_Attribute(Password, "text"));

            }
            catch (Exception error)
            {

                Console.WriteLine("This Method Validates_Fields_CreateAccount could not be execute", error);
            }

        }

        public void Create_Existing_Account()
        {
            Utils.VisibleElement("Validates the Email Field is visible", Email);
            Utils.VisibleElement("Validates the Password Field is visible", Password);

            Email.Clear();
            Email.SendKeys(VALUE_EMAIL); //Enter text, Valid Email
            Utils.Enable("Validates the Next Button is Disable", Next_Button); //Validates, the Next Button is disable

            Password.Clear();
            Password.SendKeys(VALUE_PASS); //Enter text Password
            Utils.Enable("Validates the Next Button is Enable", Next_Button); //Validates, the Next Button is Enable

            Next_Button.Click();//Press Nex button
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("snackbar_text"))); //Wait Until the Text "It looks like youâ€™ve already registered" is visible

            Utils.VisibleElement("Validates the Error message is visible", Error_Account);
            Utils.Asserts("Validate the Text Error message is correct", EXPECT_CREATE_COUNT, Utils.Get_Attribute(Error_Account, "text")); //Get and validate the text in to Error message

            Back_Button.Click(); //Press back Button, to return to the beginning 
        }

        /*
         * Method, Validate the create Succesfull a new Account 
         */
        public void Create_Successfull_Account()
        {
            Create_Account_Button.Click(); //Press Create a new Account button

            Utils.VisibleElement("Validates the Email Field is visible", Email);
            Utils.VisibleElement("Validates the Password Field is visible", Password);

            Email.SendKeys(VALUE_EMAIL3); //Enter text, Valid Email
            Utils.Enable("Validates the Next Button is Disable", Next_Button); //Validates, the Next Button is disable

            Password.SendKeys(VALUE_PASS); //Enter text Password
            Utils.Enable("Validates the Next Button is Enable", Next_Button); //Validates, the Next Button is Enable

            Next_Button.Click();
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(30)); //Wait Until the Text "Whats your name" is visible
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("text_sign_up_name_title")));

            Utils.Asserts("Validates, the frame'Whats your name' is visible", EXPECT_FRAME_NAME, Utils.Get_Attribute(Name_Title_Field, "text")); //Validate the title is visible//

            Name_Field.SendKeys(VALUE_NAME); //Enter text Fisrt and last Name
            Next_Button.Click(); //Press Nex button

            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("etZipCode")));
            Utils.SendKeys_Keyboard("5434");
            Button_Loading.Click(); //Press button loading
            Permission_Allow.Click();


            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("text_sign_up_work_experience_category_position_title"))); //Wait Until the Text "Please Select the category Job" is visible
            Utils.Asserts("Validates, the Category job title is correct", EXPECT_CATEGORY_TEXT, Utils.Get_Attribute(Select_Job_Title, "text"));

            Text_Skip.Click(); //Press "No work experience button"
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("text_sign_up_complete_profile_title")));
            Utils.Asserts("Validates, the Profile Picture title is correct", EXPECT_PROFILE_PICTURE, Utils.Get_Attribute(Profile_Picture_Title, "text"));
            Text_Skip.Click();

            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("text_sign_up_candidate_congratulation_title"))); //Wait Until the Text "Please complete your profile" is visible
            Utils.Asserts("Validates, the Congrulation Picture title is correct", EXPECT_COMPLETE_PROFILE, Utils.Get_Attribute(Congrulation_Title, "text"));
            Utils.Asserts("Validates, the Candidate Name is correct", EXPECT_CANDIDATE_NAME, Utils.Get_Attribute(Candidate_Name, "text"));

            //Logout
            Icon_Profile.Click();
            Image_Settings.Click();
            Log_Out.Click();
        }

        /*
         * Method, validates login Sucessfull with validate user 
         */ 

        public void Login_User()
        {
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("button_login")));
            Login.Click(); //Click, Login button
            
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("text_login_title")));//Wait Until the Text "Welcome back" is visible
            Utils.Asserts("Validates the Welcome Back title", EXPECT_WELCOME_BACK_TITLE,Utils.Get_Attribute(Welcome_back_Title,"text"));
            Email.SendKeys(VALUE_EMAIL3); //Enter text, Valid Email
            Password.SendKeys(VALUE_PASS); //Enter text Password
            Next_Button.Click();
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("_button_got_it")));
            GotIt_Button.Click();

            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("_tv_search")));//Wait Until the Text "Find Jobs" is visible
            Utils.Asserts("Validates the Find Jobs Page",EXPECT_FIND_JOBS_TITLE,Utils.Get_Attribute(Find_Jobs,"text")); //Get and validate "Find Jobs" title.

            Icon_Profile.Click();
            Utils.Asserts("Validates the Text Name correct", VALUE_NAME, Utils.Get_Attribute(Text_Name, "text")); //Get and validate text name.


        }

        /*
         * Method, validates Sucessfull icome 
         */ 
        public void Sucessfull_Income()
        {
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.Id("img_merlin_logo")));
            Utils.VisibleElement("Validates the Logo element is visible",Logo);
            Utils.VisibleElement("Validtes the create Count button is visible", Create_Account_Button);

        }

        
        
    }
    


  }
