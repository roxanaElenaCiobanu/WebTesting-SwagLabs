# WebTesting-SwagLabs

Test Plan 

SwagLabs

Introduction

Tests in Scope:

T1. Login with <Standard user>/<problem_user>/locked_user
T1a. Login without username
T2a. Login without password
T2. Standard user: Filter items on page
T3. problem_user: Filter items on page
T4. Standard user: Remove item from cart 
oT5.problem_user: Remove item from cart (third one)
T6: Standard user: Change the quantity of items to be purchased
T7.  Standard user: Purchase one Item
O T8. Standard user: Add to cart the third item from the list 
O T9: problem_user: Add to cart the third item from the list 
T10: standard_user: Continue Shopping button
T11. Logout

Test not in scope:
T : Navigating to “About” page
T:  Navigate through submenus
T: Login with un-existing username

Test Results:


Bugs found during the test execution:

Bug 1:
standard_user / problem_user
Summary: Order can be placed without any item in the cart
Given I am logged in the "standard_user"
When I add an item in the cart
And I navigate to Cart page
Then I see the item present in the Cart page
When I remove the item from cart
Then the cart is empty
And I check the "checkout" button

Actual Result:
The "checkout" button is still enabled and the user can continue the placing order process

Expected Result:
The "checkout" button should be disabled as there is no item  in the cart to purchase 

Bug 2:
problem_user
Summary: [Checkout order form] Typing the text in the "lastname" textfield not working
Given I am logged in the "problem_user"
And I am on the "Checkout: Your Information" page for placing an order
When I enter the lastname into "lastname" textfield

Actual Result:
Then The lastname is entered in the "firstname" textfield,letter by letter and the firstname is over-written by the last letter typed

Expected Result:
The lastname should be added in the "lastname" textfield

Bug 3:
standard_user /problem_user
Summary: Cannot change the quantity of the items to be purchased
Given I am logged in the "standard_user"
And I am on the "cart" page
And there is one item in the cart
When I try to change the quantity of the item to be purchased from 1 to 2

Actual Result:
Then the quantity of the item to be purchased remains the same

Expected Result:
The quantity should be changed accordingly (to 2)

