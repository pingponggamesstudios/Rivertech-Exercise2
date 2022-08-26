using LightBDD.Framework;
using LightBDD.NUnit3;
using System.Threading.Tasks;
using LightBDD.Framework.Scenarios;

[assembly: LightBddScopeAttribute]
namespace Rivertech___Exercise_2_UI_Automation_Testing.TestScenarios
{
   public partial class WebsiteFeature : WebsiteFeatureSteps
    {
        [Scenario]
        public void Perform_Login_and_CheckOut()
        {
            Runner.AddSteps(
                     Given_Credentials_are_Inserted,
                     When_Credentials_Are_Correct_User_Can_Login,
                     When_Adding_Object_To_Cart,
                     When_Viewing_Cart,
                     When_Checkout_Is_Clicked,
                     Then_Confirm_Total_Price,
                     Then_Finish_Checkout_Process
                     ).RunAsync();
        }
    }
}
