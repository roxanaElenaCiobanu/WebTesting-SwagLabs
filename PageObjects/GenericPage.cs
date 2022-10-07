using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting_SwagLabs.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace WebTesting_SwagLabs.PageObjects
{
    class GenericPage
    {
        IWebDriver driver;
        public GenericPage()
        {
            driver = Hooks1.driver;
        }
        IWebElement pageTitle => driver.FindElement(By.ClassName("title"));
        IWebElement loginError => driver.FindElement(By.XPath("//h3[@data-test = 'error']"));

        public void NavigateToWebsite()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        public void GetPageTitle(String text)
        {
            string pageTitleText = pageTitle.Text;
            Console.WriteLine("Titlu=" + pageTitleText);
            Assert.IsTrue(pageTitle.Displayed);
            Assert.IsTrue(pageTitleText.Contains(text));
        }

        public void GetLoginError(String text)
        {
            string loginErrorText = loginError.Text;
            Assert.IsTrue(loginError.Displayed);
            Assert.IsTrue(loginErrorText.Contains(text));
        }

    }
}