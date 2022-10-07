using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace WebTesting_SwagLabs.Utils
{
    [Binding]
    public sealed class Hooks1
    {
        public static IWebDriver driver;


        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
         
        }

        [AfterScenario]
        public void AfterScenario()
        {
           driver.Quit();
        }
    }
}