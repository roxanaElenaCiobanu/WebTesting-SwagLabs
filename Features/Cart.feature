Feature: Cart

A short summary of the feature

Background: 
Given I am on the login page

Scenario Outline: Add to cart the third item from the list 
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login 
	And I click on 'Add to cart' button the item from the position '3' on page
	Then I see the item added to cart
	When I click on the cart button
	Then I see the item on the cart page
	
	Examples: 
	| username      | password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |

Scenario Outline: Change the quantity of items to be purchased
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login
	And I click on 'Add to cart' button the item from the position '2' on page
	Then I see the item added to cart
	When I click on the cart button
	Then I see the item on the cart page
	When I change the quantity to: '2'
	Then I see the quantity changed to '2'

	Examples: 
	| username      | password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |

Scenario Outline: Remove item from cart 
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login
	And I click on 'Add to cart' button the item from the position '3' on page
	Then I see the item added to cart
	When I click on 'Remove' button the item from the position '3' on page
	And I click on the cart button
	Then I see the cart is empty

	Examples: 
	| username      | password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |


Scenario Outline: "Continue Shopping" 
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login 
	And I click on 'Add to cart' button the item from the position '2' on page
	Then I see the item added to cart
	When I click on the cart button
	Then I see the item on the cart page
	When I click on the 'Continue Shopping' button
	Then I see the 'PRODUCTS' title on the page
	Then I return list of items page

	Examples: 
	| username      | password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |

Scenario Outline: Purchase one Item
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login 
	And I click on 'Add to cart' button the item from the position '3' on page
	Then I see the item added to cart
	When I click on the cart button
	Then I see the item on the cart page
	And I see the 'YOUR CART' title on the page
	Then I see the item on the cart page
	When I click on the 'Checkout' button
	Then I see the 'CHECKOUT: YOUR INFORMATION' title on the page
	When I fill in the information '<firstname>','<lastname>' and '<zipCode>' 
	And I click on the continue input
	Then I see the 'CHECKOUT: OVERVIEW' title on the page
	And I see the item on the cart page
	When I click on the 'Finish' button
	Then I see the 'CHECKOUT: COMPLETE!' title on the page

	Examples: 
	| username      | password     | firstname | lastname | zipCode |
	| standard_user | secret_sauce | FirstName | LastName | Test123 |
	| problem_user  | secret_sauce | FirstName | LastName | Test123 |
