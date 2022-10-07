using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;
using WebTesting_SwagLabs.PageObjects;

namespace WebTesting_SwagLabs.StepDefinition
{
    [Binding]
    public class GenericSteps
    {
        GenericPage generic = new GenericPage();

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            generic.NavigateToWebsite();
        }

        [Then(@"I see the '(.*)' title on the page")]
        public void ThenISeeTheTitleOnThePage(string text)
        {
            generic.GetPageTitle(text);
        }

        [Then(@"I see a error message: '(.*)'")]
        public void ThenISeeAErrorMessage(string text)
        {
            generic.GetLoginError(text);
        }




    }
}