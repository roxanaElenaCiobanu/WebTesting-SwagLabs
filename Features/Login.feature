Feature: Login

A short summary of the feature

Background: 
	Given I am on the login page

Scenario Outline: Login with "<username>" 
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login 
	Then I see the 'PRODUCTS' title on the page

Examples:
| username      | password     |
| standard_user | secret_sauce |
| problem_user  | secret_sauce |

Scenario Outline: Login with locked_out_user
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login 
	Then I see a error message: '<errorMessage>'

	Examples: 
	| username      | password     |   errorMessage         |
	| locked_out_user | secret_sauce | locked out |

Scenario Outline: Login without username
	When I enter credentials '<password>' in the field with placeholder: 'Password'
	And I login	
	Then I see a error message: '<errorMessage>'

	Examples:
	| password     | errorMessage |
	| secret_sauce |  Username is required     |

Scenario Outline: Login without password
	When I enter credentials '<username>' in the field with placeholder: 'Username'
	And I login	
	Then I see a error message: '<errorMessage>'

	Examples:
	| password     | errorMessage |
	| secret_sauce | Password is required    |

