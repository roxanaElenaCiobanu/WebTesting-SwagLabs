using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;
using WebTesting_SwagLabs.PageObjects;

namespace WebTesting_SwagLabs.StepDefinition
{
    [Binding]
    public class LoginSteps
    {
        LoginPage login = new LoginPage();

       [When (@"I enter credentials '(.*)' in the field with placeholder: '(.*)'")]
        public void WhenIEnterCredentialsInTheFieldWithPlaceholder(String value, String placeholder)
        {
            String XPath = "//input[@placeholder = '" + placeholder + "']";

            login.EnterCredentials(XPath, value);
        }

        [When (@"I login")]
        public void ILogin()
        {
            login.ClickLoginButton();
        }

    }
}