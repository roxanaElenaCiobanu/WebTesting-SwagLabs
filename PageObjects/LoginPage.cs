using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting_SwagLabs.Utils;

namespace WebTesting_SwagLabs.PageObjects
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage() 
        {
            driver = Hooks1.driver;
                
        }
        IWebElement loginButton => driver.FindElement(By.Id("login-button"));
        IWebElement credentials;

        public void EnterCredentials(String XPath,String value)
        {
            credentials = driver.FindElement(By.XPath(XPath));
            credentials.SendKeys(value);
        }

        public void ClickLoginButton()
        {
            loginButton.Click();
        }

    }
}
