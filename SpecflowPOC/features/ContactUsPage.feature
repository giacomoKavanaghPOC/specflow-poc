Feature: ContactUsPage
	As an end user
	I want a contact us page
	So that I can find out more about QAWorks exciting services!!

@mytag
Scenario: Valid Submission
	Given I am on the QAWorks Site
	Then I should be able to contact QAWorks with the following information
	| name     | email                | subject         | message                                   |
	| j.Bloggs | j.Bloggs@qaworks.com | test automation | please contact me I want to find out more |

Scenario: Invalid email
	Given I am on the QAWorks Site
	Then I should not be able to contact QAWorks with an invalid entry
	| name     | email                | subject         | message                                   |
	| j.Bloggs | j.Bloggs@qaworks	  | test automation | please contact me I want to find out more |
	Then The error message should be The e-mail address entered is invalid.

Scenario: Blank entry
	Given I am on the QAWorks Site
	Then I should not be able to contact QAWorks with an invalid entry
	| name     | email                | subject         | message                                   |
	|		   | j.Bloggs@qaworks     | test automation | please contact me I want to find out more |
	Then The error message should be The field is required.
