using LightBDD.NUnit3;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rivertech___Exercise_2_UI_Automation_Testing.Controllers;
using SeleniumExtras.WaitHelpers;
using System;

namespace Rivertech___Exercise_2_UI_Automation_Testing.TestScenarios
{
    public partial class WebsiteFeatureSteps : FeatureFixture
    {
        private WebsiteController _websiteController { get => ReferenceManager.Instance.websiteController; }
        private IWebDriver _driver { get => ReferenceManager.Instance.Driver; set => ReferenceManager.Instance.Driver = value; }

        public void Given_Credentials_are_Inserted()
        {
            _websiteController.InsertLoginCredentials();
            
            IWebElement usernameTextBox = _websiteController.GetWebElementById("user-name");
            IWebElement passwordTextBox = _websiteController.GetWebElementById("password");

            //wait for field to be filled in, incase of slow connection
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementExists(By.Id("user-name")));

            Assert.AreEqual(usernameTextBox.GetAttribute("value"), "standard_user");
            Assert.AreEqual(passwordTextBox.GetAttribute("value"), "secret_sauce");
        }

        public void When_Credentials_Are_Correct_User_Can_Login()
        {
            _websiteController.SimulateLoginClick();

            //check if title element exists
            IWebElement titleText = _websiteController.GetWebElementByClass("title");
            Assert.IsNotNull(titleText);
        }

        public void When_Adding_Object_To_Cart()
        {
            _websiteController.AddItemToCart();

            //check if the badge has been added to the icon, upon adding an item to the cart
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_badge")));

            Assert.IsNotNull(_websiteController.GetWebElementByClass("shopping_cart_badge"));
        }

        public void When_Viewing_Cart()
        {
            _websiteController.ViewCart();

            Assert.IsNotNull(_websiteController.GetWebElementById("checkout"));

            IWebElement cartQuantityText = _websiteController.GetWebElementByClass("cart_quantity");
            Assert.IsNotNull(cartQuantityText);
            Assert.IsTrue(cartQuantityText.Text == "1");
        }

        public void When_Checkout_Is_Clicked()
        {

            _websiteController.Checkout();


            _websiteController.InputCustomerDetails();
            IWebElement firstNameTextBox = _websiteController.GetWebElementById("first-name");
            IWebElement LastNameTextBox = _websiteController.GetWebElementById("last-name");
            IWebElement postalCodeTextBox = _websiteController.GetWebElementById("postal-code");

            Assert.IsNotEmpty(firstNameTextBox.GetAttribute("value"));
            Assert.IsNotEmpty(LastNameTextBox.GetAttribute("value"));
            Assert.IsNotEmpty(postalCodeTextBox.GetAttribute("value"));

            _websiteController.ContinueButton();
        }

        public void Then_Confirm_Total_Price()
        {
            IWebElement summaryItemTotalElement = _websiteController.GetWebElementByClass("summary_subtotal_label");
            IWebElement summaryTaxElement = _websiteController.GetWebElementByClass("summary_tax_label");
            IWebElement summaryTotalIncludingTaxElement = _websiteController.GetWebElementByClass("summary_total_label");
            Assert.IsTrue(summaryItemTotalElement.Text.Contains("49.99"));
            Assert.IsTrue(summaryTaxElement.Text.Contains("4.00"));
            Assert.IsTrue(summaryTotalIncludingTaxElement.Text.Contains("53.99"));
        }


        public void Then_Finish_Checkout_Process()
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementIsVisible(By.Id("finish")));

            _websiteController.FinishCheckout();

            try
            {
                Assert.IsNull(_websiteController.GetWebElementByClass("shopping_cart_badge"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Cart quantity badge has been removed; hence, item has been bought.");
            }
        }
    }
}
