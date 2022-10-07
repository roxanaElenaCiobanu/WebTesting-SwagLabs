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
    class CartSteps
    {
        CartPage cart = new CartPage();

        [Then(@"I see the item on the cart page")]
        public void ThenISeeTheItemOnTheCartPage()
        {
            cart.CheckItemOnCartPage();  
        }

        [When(@"I click on the '(.*)' button")]
        public void WhenIClickOnTheButton(string textButton)
        {
           cart.ClickOnButtonInCartOrder(textButton);
        }

        [Then(@"I see the cart is empty")]
        public void ThenISeeTheCartIsEmpty()
        {
            cart.CheckItemOnCartPageNotPresent();
        }

        [When(@"I fill in the information '(.*)','(.*)' and '(.*)'")]
        public void WhenIFillInTheInformationAnd(string firstName, string lastName, string zipCode)
        {
           cart.FillInTheOrderForm(firstName, lastName, zipCode);
        }

        [When(@"I click on the continue input")]
        public void WhenIClickOnTheInput()
        {
            cart.ClickOnContinueInputInOrder();
        }

        [When(@"I change the quantity to: '(.*)'")]
        public void WhenIChangeTheQuantityTo(string number)
        {
            cart.ChangeQuantityOfItemPurchased(number);
        }

        [Then(@"I see the quantity changed to '(.*)'")]
        public void ThenISeeTheQuantityChanged(int number)
        {
            cart.CheckTheQUantityOfItemPurchase(number);
        }

    }



}
