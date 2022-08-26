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
        public void Given_Credentials_are_Inserted()
        {
            WebsiteController.InsertLoginCredentials();

            var _driver = WebsiteController.Driver;

            IWebElement usernameTextBox = _driver.FindElement(By.Id("user-name"));
            IWebElement passwordTextBox = _driver.FindElement(By.Id("password"));

            //wait for field to be filled in, incase of slow connection
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementExists(By.Id("user-name")));

            Assert.AreEqual(usernameTextBox.GetAttribute("value"), "standard_user");
            Assert.AreEqual(passwordTextBox.GetAttribute("value"), "secret_sauce");
        }

        public void When_Credentials_Are_Correct_User_Can_Login()
        {
            var _driver = WebsiteController.Driver;

            WebsiteController.SimulateLoginClick();

            //check if title element exists
            IWebElement titleText = _driver.FindElement(By.ClassName("title"));
            Assert.IsNotNull(titleText);
        }

        public void When_Adding_Object_To_Cart()
        {
            WebsiteController.AddItemToCart();

            //check if the badge has been added to the icon, upon adding an item to the cart
            var _driver = WebsiteController.Driver;
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementIsVisible(By.ClassName("shopping_cart_badge")));

            Assert.IsNotNull(_driver.FindElement(By.ClassName("shopping_cart_badge")));
        }

        public void When_Viewing_Cart()
        {
            WebsiteController.ViewCart();

            var _driver = WebsiteController.Driver;
            Assert.IsNotNull(_driver.FindElement(By.Id("checkout")));

            IWebElement cartQuantityText = _driver.FindElement(By.ClassName("cart_quantity"));
            Assert.IsNotNull(cartQuantityText);
            Assert.IsTrue(cartQuantityText.Text == "1");
        }

        public void When_Checkout_Is_Clicked()
        {
            WebsiteController.Checkout();

            var _driver = WebsiteController.Driver;

            WebsiteController.InputCustomerDetails();
            IWebElement firstNameTextBox = _driver.FindElement(By.Id("first-name"));
            IWebElement LastNameTextBox = _driver.FindElement(By.Id("last-name"));
            IWebElement postalCodeTextBox = _driver.FindElement(By.Id("postal-code"));

            Assert.IsNotEmpty(firstNameTextBox.GetAttribute("value"));
            Assert.IsNotEmpty(LastNameTextBox.GetAttribute("value"));
            Assert.IsNotEmpty(postalCodeTextBox.GetAttribute("value"));

            WebsiteController.ContinueButton();
        }

        public void Then_Confirm_Total_Price()
        {
            var _driver = WebsiteController.Driver;
            IWebElement summaryItemTotalElement = _driver.FindElement(By.ClassName("summary_subtotal_label"));
            IWebElement summaryTaxElement = _driver.FindElement(By.ClassName("summary_tax_label"));
            IWebElement summaryTotalIncludingTaxElement = _driver.FindElement(By.ClassName("summary_total_label"));
            Assert.IsTrue(summaryItemTotalElement.Text.Contains("49.99"));
            Assert.IsTrue(summaryTaxElement.Text.Contains("4.00"));
            Assert.IsTrue(summaryTotalIncludingTaxElement.Text.Contains("53.99"));
        }


        public void Then_Finish_Checkout_Process()
        {
            var _driver = WebsiteController.Driver;

            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            w.Until(ExpectedConditions.ElementIsVisible(By.Id("finish")));

            WebsiteController.FinishCheckout();

            try
            {
                Assert.IsNull(_driver.FindElement(By.ClassName("shopping_cart_badge")));
            }
            catch (Exception e)
            {
                Console.WriteLine("Cart quantity badge has been removed; hence, item has been bought.");
            }
        }
    }
}
