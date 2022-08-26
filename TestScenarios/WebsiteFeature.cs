using LightBDD.Framework;
using LightBDD.NUnit3;
using System.Threading.Tasks;
using LightBDD.Framework.Scenarios;


[assembly:LightBddScopeAttribute]
namespace Rivertech___Exercise_2_UI_Automation_Testing.TestScenarios
{
   public partial class WebsiteFeature : WebsiteFeatureSteps
    {
        [Scenario]
        public void Verify_user_information()
        {

            Runner.AddSteps(
                     Given_Website_is_Online)
                 .RunAsync();
        }
    }
}
