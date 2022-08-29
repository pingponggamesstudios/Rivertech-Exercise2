using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rivertech___Exercise_2_UI_Automation_Testing.Controllers
{


    public class WebsiteController
    {
        private bool isInitialised;
        private static IWebDriver _driver { get => ReferenceManager.Instance.Driver; set => ReferenceManager.Instance.Driver = value; }
        private IDictionary<WebsitePages, string> websitePages;

        private void InitialiseDriver()
        {
            if (isInitialised)
            {
                return;
            }

            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            _driver = new ChromeDriver(basePath + @"../../chromedriver");
            isInitialised = true;
        }

        public WebsiteController()
        {
            PopulateWebsitePagesDictionary();
        }

        private void PopulateWebsitePagesDictionary()
        {
            websitePages = new Dictionary<WebsitePages, string>();

            websitePages.Add(WebsitePages.Home, "https://www.saucedemo.com/");
            websitePages.Add(WebsitePages.Products, "https://www.saucedemo.com/inventory.html");
            websitePages.Add(WebsitePages.Cart, "https://www.saucedemo.com/cart.html");
            websitePages.Add(WebsitePages.CustomerDetails, "https://www.saucedemo.com/checkout-step-one.html");
            websitePages.Add(WebsitePages.CheckoutProductList, "https://www.saucedemo.com/checkout-step-two.html");
            websitePages.Add(WebsitePages.OrderConfirmation, "https://www.saucedemo.com/checkout-complete.html");
        }

        [SetUp]
        private void OpenWebsite(WebsitePages pageToNavigate)
        {
            InitialiseDriver();
            _driver.Url = websitePages[pageToNavigate];
            _driver.Manage().Window.Maximize();
        }

        public void InsertLoginCredentials()
        {
            OpenWebsite(WebsitePages.Home);

            //setup username
            IWebElement usernameTextBox = GetWebElementById("user-name");
            usernameTextBox.Clear();
            usernameTextBox.SendKeys("standard_user");


            //setup password
            IWebElement passwordTextBox = GetWebElementById("password");
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("secret_sauce");
        }

        public void SimulateLoginClick()
        {
            //click on login
            IWebElement loginButton = GetWebElementById("login-button");
            loginButton.Click();
        }

        public void AddItemToCart()
        {
            OpenWebsite(WebsitePages.Products);

            IWebElement addFleeceJacketToCartButton = GetWebElementById("add-to-cart-sauce-labs-fleece-jacket");
            addFleeceJacketToCartButton.Click();
        }

        public void ViewCart()
        {
            IWebElement viewCartButton = GetWebElementById("shopping_cart_container");
            viewCartButton.Click();
        }

        public void Checkout()
        {
            IWebElement checkoutButton = GetWebElementById("checkout");
            checkoutButton.Click();
        }

        public void InputCustomerDetails()
        {
            //first name
            IWebElement firstNameTextBox = GetWebElementById("first-name");
            firstNameTextBox.Clear();
            firstNameTextBox.SendKeys("John");

            //last name
            IWebElement LastNameTextBox = GetWebElementById("last-name");
            LastNameTextBox.Clear();
            LastNameTextBox.SendKeys("Doe");

            //postal code
            IWebElement postalCodeTextBox = GetWebElementById("postal-code");
            postalCodeTextBox.Clear();
            postalCodeTextBox.SendKeys("JDR1234");
        }

        public void ContinueButton()
        {
            IWebElement continueButton = GetWebElementById("continue");
            continueButton.Click();
        }

        public void FinishCheckout()
        {
            IWebElement finishButton = GetWebElementById("finish");
            finishButton.Click();
        }

        public IWebElement GetWebElementById(string elementId)
        {
            return _driver.FindElement(By.Id(elementId));
        }

        public IWebElement GetWebElementByClass(string className)
        {
            return _driver.FindElement(By.ClassName(className));
        }
    }
}
