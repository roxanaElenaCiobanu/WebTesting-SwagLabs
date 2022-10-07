using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting_SwagLabs.Utils;

namespace WebTesting_SwagLabs.PageObjects
{
    class CartPage
    {
        IWebDriver driver;
        public CartPage()
        {
            driver = Hooks1.driver;
        }

        IWebElement itemInCart;
        IWebElement buttonInCartPage;
        IWebElement firstNameOrderTextInput => driver.FindElement(By.Id("first-name"));
        IWebElement lastNameOrderTextInput => driver.FindElement(By.Id("last-name"));
        IWebElement zipCodeOrderTextInput => driver.FindElement(By.Id("postal-code"));
        IWebElement continueOrderInput => driver.FindElement(By.Id("continue"));
        IWebElement quantityOfPurchaseItem => driver.FindElement(By.ClassName("cart_quantity"));

        ReadOnlyCollection<IWebElement> listOfItemsInCart => driver.FindElements(By.XPath("//div[@class='cart_list']/div[@class='cart_item']"));
        public void CheckItemOnCartPage()
        {
            itemInCart = driver.FindElement(By.ClassName("cart_item"));
            Assert.IsTrue(itemInCart.Displayed);
        }

        public void ClickOnButtonInCartOrder(string buttonText)
        {
            string buttonInCartPageXpath = "//div[@class='cart_footer']//button[text()='" + buttonText + "']";
            buttonInCartPage = driver.FindElement(By.XPath(buttonInCartPageXpath));

            buttonInCartPage.Click();
        }

        public void CheckItemOnCartPageNotPresent()
        {

            if (listOfItemsInCart.LongCount() > 0)
            {
                Assert.Fail("Cart contains items");
            }

        }

        public void FillInTheOrderForm(string firstName, string lastName, string zipCode)
        {
            firstNameOrderTextInput.SendKeys(firstName);
            lastNameOrderTextInput.SendKeys(lastName);
            zipCodeOrderTextInput.SendKeys(zipCode);
        }
        public void ClickOnContinueInputInOrder()
        {
            continueOrderInput.Click();
        }

        public void ChangeQuantityOfItemPurchased(string number)
        {
            quantityOfPurchaseItem.SendKeys(number);
        }
        public void CheckTheQUantityOfItemPurchase(int number)
        {
            int quantityOfPurchaseItemText = int.Parse(quantityOfPurchaseItem.Text);

            Assert.IsTrue(quantityOfPurchaseItemText == number);
        }
    }

}