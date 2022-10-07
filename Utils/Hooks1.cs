using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography;
using TechTalk.SpecFlow;

namespace WebTesting_SwagLabs.Utils
{
    [Binding]
    public sealed class Hooks1
    {

        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario,step;

        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Result" + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");
        public static IWebDriver driver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if(context.TestError !=null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
           driver.Quit();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
