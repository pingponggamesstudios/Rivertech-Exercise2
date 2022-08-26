using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivertech___Exercise_2_UI_Automation_Testing.Controllers
{
   

    public class WebsiteController
    {
        private static IWebDriver _driver;
        public static bool isInitialised;
        private static readonly string url = "https://www.saucedemo.com/";
        public static IWebDriver Driver { get => _driver; set => _driver = value; }

        public static void InitialiseDriver()
        {
            if (isInitialised)
            {
                return;
            }

            _driver = new ChromeDriver("C:\\Users\\Alistair Azzopardi\\source\\repos\\Rivertech - Exercise 2 UI Automation Testing\\Rivertech-Exercise2\\chromedriver");
            isInitialised = true;
        }

      

        [SetUp]
        public static void OpenWebsite()
        {
            InitialiseDriver();
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
        }

        public static void InsertLoginCredentials()
        {
            if (!isInitialised)
            {
                OpenWebsite();
            }

            //setup username
            IWebElement usernameTextBox = _driver.FindElement(By.Id("user-name"));
            usernameTextBox.Clear();
            usernameTextBox.SendKeys("standard_user");


            //setup password
            IWebElement passwordTextBox = _driver.FindElement(By.Id("password"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("secret_sauce");        
        }

        public static void SimulateLoginClick()
        {
            //click on login
            IWebElement loginButton = _driver.FindElement(By.Id("login-button"));
            loginButton.Click();
        }


        public static void AddItemToCart()
        {
            IWebElement addFleeceJacketToCartButton = _driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
            addFleeceJacketToCartButton.Click();
        }

        public static void ViewCart()
        {
            IWebElement viewCartButton = _driver.FindElement(By.Id("shopping_cart_container"));
            viewCartButton.Click();
        }

        public static void Checkout()
        {
            IWebElement checkoutButton = _driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();
        }

        public static void InputCustomerDetails()
        {
            //first name
            IWebElement firstNameTextBox = _driver.FindElement(By.Id("first-name"));
            firstNameTextBox.Clear();
            firstNameTextBox.SendKeys("John");

            //last name
            IWebElement LastNameTextBox = _driver.FindElement(By.Id("last-name"));
            LastNameTextBox.Clear();
            LastNameTextBox.SendKeys("Doe");

            //postal code
            IWebElement postalCodeTextBox = _driver.FindElement(By.Id("postal-code"));
            postalCodeTextBox.Clear();
            postalCodeTextBox.SendKeys("JDR1234");
        }

        public static void ContinueButton()
        {
            IWebElement continueButton = _driver.FindElement(By.Id("continue"));
            continueButton.Click();
        }

        public static void FinishCheckout()
        {
            IWebElement finishButton = _driver.FindElement(By.Id("finish"));
            finishButton.Click();
        }
    }
}
