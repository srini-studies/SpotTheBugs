'''
# SpotTheBugs
Test Automation project using .Net, NUnit and Playwright to execute test cases for SpotTheBugs

1.	Contents

	2.  Setup Instructions
	3.  Approach for the Test
	4.  Identified Bugs
	5.  Identified Test Cases to Automate
	6.  Tech stack selection for Test Automation
	7.  Pre-requisites, dependencies and project settings
	8.  Project Structure

2.  Setup Instructions	
	
	2.1  Clone Git Repository 
	     git clone https://github.com/srini-studies/SpotTheBugs.git

	2.2  Restore .Net Packages
	     dotnet restore

	2.3  Install Playwright
	     playwright install

	2.4  Build Project
	     dotnet build

	2.5  Run Tests
	     dotnet test
		All the test having [Test] attribute will be run

3.  Approach and Execution of the Test

	3.1 Performed exploratory testing to understand the application
	3.2 Identified Bugs
	3.3 Identified Test Cases
	3.4 Identified Test Cases to Automate
	3.5 Selected Tech Stack for Test Automation
	3.6 Implemented Test Automation

4. Identified Bugs

   4.1 Terms and Conditions checkbox not working / not enabled

   4.2 Registration can be done without filling all mandatory fields

   4.3 Password - error when 20 characters entered
 		- message: password should contain [6-20] characters
 		- Used Boundary Value Analysis technique
 
   4.4 Phone number accepts alphabets

   4.5 Phone number saved incorrectly

   4.6 Last name not saved with one less character

   4.7 Email address format not validated

   4.8 Password not hidden - displayed as plain text not as ****

   4.9 Psw length validation: [6,20] characters
 		Selling Psw?

   4.10 Can click Register multiple times
 		- That means a user can be registered multiple times


5. Identified Test Cases to Automate

Test Cases

| No. | Test Case                                                                        | Test Result |
|-----|----------------------------------------------------------------------------------|-------------|
| 1   | Page Loaded Correctly                                                            | Passed      |
| 2   | All Mandatory Fields Are Enabled                                                 | Failed      |
| 3   | Registration Successful with all valid inputs for Mandatory Fields               | Passed      |
| 4   | Verify Information is saved correctly after Registration                         | Failed      |
| 5   | Registration not successful without All Mandatory Fields                         | Passed      |
| 6   | Registration not successful without some Mandatory Fields                        | Skipped     |
| 7   | Invalid Password should display error message                                    | Passed      |
| 8   | Invalid Phone Number should display error message                                | Passed      |
| 9   | Registration should not be successful without Last Name and Invalid Email Format | Failed      |


6. Tech stack selection for the automation framework
		
	Tech stack for the test automation project  
	.Net Core, NUnit, Playwright, Visual Studio Community 2022


7.  Pre-requisites, dependencies and project settings for the .Net NUnit Test Project with Playwright.

	7.1 Pre-requisite
		.NET SDK .NET 8.0
		Install from: https://dotnet.microsoft.com/download

	7.2 Dependencies
		Playwright
			use the following command to install Playwright pwsh bin\Debug\net8.0\playwright.ps1 install	 		
		NUnit   
		FluentAssertions
		Microsoft.Extensions.Configuration
		Microsoft.Extensions.Configuration.Binder
		Microsoft.Extensions.Configuration.FileExtensions   
		Microsoft.Extensions.Configuration.Json
		Microsoft.Playwright.NUnit
		NUnit3TestAdapter

	7.3 appsettings.json
		Specify Url needed to be tested in appsettings.json file
		[Url: https://qa-practice.netlify.app/bugs-form]

	7.4. Run Settings file for Parallelisation:
	
		<RunSettings>
		  <RunConfiguration>
		    <MaxCpuCount>4</MaxCpuCount>
		  </RunConfiguration>
		</RunSettings>


8.  Project Structure

	SpotTheBugs
	│
	├── Data
	│   └── Data.cs                           # test data
	│
	├── Pages
	│   └── ChallengesSpotTheBugsPage.cs      # Page object model for interactions
	│
	├── Tests
	│   ├── BaseTest.cs                       # Base class for common test setup/teardown
	│   └── SpotTheBugsTests.cs               # Main test suite for SpotTheBugs
	│
	├── appsettings.json                      # Configuration file for test environment - web application Url
	├── test.runsettings                      # Test settings file for test execution
	└── TestConfiguration.cs                  # Test configurations mapping from appsettings.json

'''