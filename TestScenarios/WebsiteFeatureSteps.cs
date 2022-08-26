using LightBDD.NUnit3;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rivertech___Exercise_2_UI_Automation_Testing.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rivertech___Exercise_2_UI_Automation_Testing.TestScenarios
{
    public partial class WebsiteFeatureSteps : FeatureFixture
    {  
        public void Given_Website_is_Online()
        {
            WebsiteController.OpenWebsite();

           // IWebElement passwordTextBox = firefoxDriver.FindElement(By.Id("passwordTextBox"));

            var t = "";
//            HttpResponseMessage responseMessage = await Task.Run(() => UsersController.ConnectWithAPIServer());
 //           Assert.IsTrue(responseMessage.IsSuccessStatusCode);
        }
    }
}
