using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting_SwagLabs.Utils;

namespace WebTesting_SwagLabs.PageObjects
{
    class ProductPage
    {
        IWebDriver driver;
        public ProductPage()
        {
            driver = Hooks1.driver;
        }

        IWebElement addToCartButton;
        IWebElement itemOnCart;
        IWebElement cartLinkOnProductPage => driver.FindElement(By.XPath("//a[@class = 'shopping_cart_link']"));
        IWebElement listOfProducts => driver.FindElement(By.ClassName("inventory_list"));
        SelectElement sortProductsDropdown => new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));

        ReadOnlyCollection<IWebElement> listOfProductPrices => driver.FindElements(By.XPath("//div[@class='pricebar']/div[@class='inventory_item_price']"));
        public void ClickOnAddToCartButton(string buttonName, string position)
        {
            string ButtonXPath = "//div[@id='inventory_container']/div[@class='inventory_list']/div[@class='inventory_item'][" + position + "]//button[text() = '" + buttonName + "']";
            addToCartButton = driver.FindElement(By.XPath(ButtonXPath));
            Assert.IsTrue(addToCartButton.Displayed);
            addToCartButton.Click();
            Thread.Sleep(5000);
        }
        public void CheckItemOnCart()
        {
            Thread.Sleep(5000);
            itemOnCart = driver.FindElement(By.XPath("//a[@class = 'shopping_cart_link']/span"));
            Assert.IsTrue(itemOnCart.Displayed);
        }
        public void ClickOnCartLinkOnProductPage()
        {
            cartLinkOnProductPage.Click();
        }

        public void listOfProductsOnProductPage()
        {
            Assert.IsTrue(listOfProducts.Displayed);
        }

        public void CheckItemOnCartNotPresent()
        {
            Assert.IsFalse(itemOnCart.Displayed);
        }

        public void SelectOptionFromFilterDropdown(string option)
        {
            sortProductsDropdown.SelectByText(option);
        }

        public List<float> GetListOfProductPrices()
        {
            List<float> prices = new List<float>();

            foreach (IWebElement productPrice in listOfProductPrices)
            {
                String price = productPrice.Text.Replace("$", "");
                prices.Add(float.Parse(price));
            }
            Console.WriteLine(string.Join("\t", prices));

            return prices;
        }

    }
}