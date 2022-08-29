using OpenQA.Selenium;
using Rivertech___Exercise_2_UI_Automation_Testing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivertech___Exercise_2_UI_Automation_Testing
{

    public enum WebsitePages
    {
        None,
        Home,
        Products,
        Cart,
        CustomerDetails,
        Checkout,
        CheckoutProductList,
        OrderConfirmation
    }

    public sealed class ReferenceManager
    {
        public WebsiteController websiteController;

        private static ReferenceManager instance = null;
        private static readonly object padlock = new object();
        private IWebDriver _driver;
        public IWebDriver Driver { get => _driver; set => _driver = value; }


        public static ReferenceManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ReferenceManager();
                        instance.websiteController = new WebsiteController();
                    }
                    return instance;
                }
            }
        }
    }
}
