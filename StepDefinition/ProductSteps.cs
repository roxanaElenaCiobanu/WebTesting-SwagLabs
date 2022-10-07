using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebTesting_SwagLabs.PageObjects;

namespace WebTesting_SwagLabs.StepDefinition
{
    [Binding]
    class ProductSteps
    {
        ProductPage product = new ProductPage();

        [When(@"I click on '(.*)' button the item from the position '(.*)' on page")]
        public void WhenIClickOnButtonTheItemFromThePositionOnPage(string buttonName, string position)
        {
            product.ClickOnAddToCartButton(buttonName, position);
        }

        [Then(@"I see the item added to cart")]
        public void ThenISeeTheItemAddedToCart()
        {
            product.CheckItemOnCart();
        }

        [When(@"I click on the cart button")]
        public void WhenIClickOnTheCartButton()
        {

            product.ClickOnCartLinkOnProductPage();
        }

        [Then(@"I return list of items page")]
        public void ThenIReturnListOfItemsPage()
        {
            product.listOfProductsOnProductPage();
        }

        [Then(@"I see the item removed from the cart")]
        public void ThenISeeTheItemRemovedFromTheCart()
        {
            product.CheckItemOnCartNotPresent();
        }

        [When(@"I select '(.*)' option from the dropdown list")]
        public void WhenISelectOptionFromTheDropdownList(string filterOption)
        {
            product.SelectOptionFromFilterDropdown(filterOption);
        }

        [Then(@"The products are sorted in '(.*)' order based on prices")]
        public void ThenThePricesAreSortedAccordingly (String sortingOrder)
        {
            List<float> productPrices = product.GetListOfProductPrices();

            if (sortingOrder.ToLower().CompareTo("ascending") ==0 )
                Assert.That(productPrices, Is.Ordered.Ascending);
            else
                if (sortingOrder.ToLower().CompareTo("descending") == 0)
                    Assert.That(productPrices, Is.Ordered.Descending);
                else
                    Assert.Fail("The test Fail as the step parameter was not recognised. Please use just ascending or descending");

        }


    }
}
