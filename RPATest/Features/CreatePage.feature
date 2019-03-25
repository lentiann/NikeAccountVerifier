Feature: CreateProject
	Check if creation of project and selection
	works correctly.

@smoke @positive
Scenario: CheckCreationOfProjectAndSubProject
	Given I have navigated to the application
	When I enter Username and Password
		| UserName | Password |
		| admin    | manager |
	Then I click login button
	Then I click new project button
	Then I enter ProjectName and test
		| ProjectName |
		| Testproject |
	Then I click submitProject button
	Then I select last element in ProjectList
	Then I click new subproject button
	Then I enter SubProjectName and test
		| SubProjectName |
		| TestSubProject |
	Then I click submitSubProject button
	Then I select last element in SubProjectList
	Then click submitProject button
	Then click OkButton button


