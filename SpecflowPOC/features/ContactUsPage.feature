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
