Feature: Filter items on page

A short summary of the feature

Background: 
	Given I am on the login page
	

Scenario Outline: Filter items on page
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login 
	When I select 'Price (high to low)' option from the dropdown list
	Then The products are sorted in 'descending' order based on prices

	Examples: 
	| username      | password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |
