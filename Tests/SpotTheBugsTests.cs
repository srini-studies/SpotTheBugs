using FluentAssertions;
using FluentAssertions.Execution;
using SpotTheBugs.Data;
using SpotTheBugs.Pages;

namespace SpotTheBugs.Tests
{
    [Parallelizable(ParallelScope.Self)]    
    public class SpotTheBugsTests: BaseTest
    {

        [SetUp]
        public override async Task Setup()
        {
            await base.Setup();
            await Page.GotoAsync(BaseUrl!);
        }


        [Test]
        public async Task TestCase_1_Page_Loaded_Correctly_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Verify page heading is correct and all mandatory fields are visible

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // Heading Locator
            var headingLocator = _challengePage.GetHeadingLocator();
            
            // Get Mandatory Fields Locators
            // Last Name
            var lastNameLocator = _challengePage.GetLastNameTextBoxLocator();
            // Phone Number
            var phoneNumberLocator = _challengePage.GetPhoneNumberTextBoxLocator();
            // Email
            var emailLocator = _challengePage.GetEmailTextBoxLocator();
            // Password
            var passwordLocator = _challengePage.GetPasswordTextBoxLocator();
            // Terms and Conditions
            var termsAndConditionsLocator = _challengePage.GetTermsAndConditionsCheckBoxLocator();

            using (new AssertionScope())
            {
                bool isHeaderVisible = (await headingLocator.IsVisibleAsync());
                var innerText = await headingLocator.InnerTextAsync();
                isHeaderVisible.Should().BeTrue();
                innerText.Should().Be(expected: TestDataCommon.Heading);

                (await lastNameLocator.IsVisibleAsync()).Should().BeTrue();
                (await lastNameLocator.IsEnabledAsync()).Should().BeTrue();

                (await phoneNumberLocator.IsVisibleAsync()).Should().BeTrue();
                (await phoneNumberLocator.IsEnabledAsync()).Should().BeTrue();

                (await emailLocator.IsVisibleAsync()).Should().BeTrue();
                (await emailLocator.IsEnabledAsync()).Should().BeTrue();

                (await passwordLocator.IsVisibleAsync()).Should().BeTrue();
                (await passwordLocator.IsEnabledAsync()).Should().BeTrue();
                
                (await termsAndConditionsLocator.IsVisibleAsync()).Should().BeTrue();
                // (await termsAndConditionsLocator.IsEnabledAsync()).Should().BeTrue();                
            }
        }


        [Test]
        public async Task TestCase_2_All_Mandatory_Fields_Are_Enabled_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Verify all mandatory fields are enabled

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // Last Name
            var lastNameLocator = _challengePage.GetLastNameTextBoxLocator();
            // Phone Number
            var phoneNumberLocator = _challengePage.GetPhoneNumberTextBoxLocator();
            // Email
            var emailLocator = _challengePage.GetEmailTextBoxLocator();
            // Password
            var passwordLocator = _challengePage.GetPasswordTextBoxLocator();
            // Terms and Conditions
            var termsAndConditionsLocator = _challengePage.GetTermsAndConditionsCheckBoxLocator();

            using (new AssertionScope())
            {                
                (await lastNameLocator.IsEnabledAsync()).Should().BeTrue();
                
                (await phoneNumberLocator.IsEnabledAsync()).Should().BeTrue();
                
                (await emailLocator.IsEnabledAsync()).Should().BeTrue();
                
                (await passwordLocator.IsEnabledAsync()).Should().BeTrue();
                
                (await termsAndConditionsLocator.IsEnabledAsync()).Should().BeTrue();                
            }
        }


        [Test]
        public async Task TestCase_3_Registration_Successful_With_All_Valid_Madatory_Inputs_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Verify successfuly message is displayed

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // Last Name
            await _challengePage.PopulateLastNameWithValidInput();
            // Phone Number
            await _challengePage.PopulatePhoneNumberWithValidInput();
            // Email
            await _challengePage.PopulateEmailWithValidInput();
            // Password
            await _challengePage.PopulatePasswordWithValidInput();
            
            // Click Register button
            await _challengePage.ClickRegisterButton();

            // Verify Success Message is displayed
            (await _challengePage.GetMessageRegistrationSuccessfulTextLocator().InnerTextAsync())
                .Should().Be(TestDataCommon.SuccessMessage);
        }


        [Test]
        public async Task TestCase_4_Registration_Information_Is_Saved_Correctly_After_Succesful_Registration_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // First Name
            await _challengePage.PopulateFirstNameWithValidInput();
            // Last Name
            await _challengePage.PopulateLastNameWithValidInput();
            // Phone Number            
            await _challengePage.PopulatePhoneNumberWithValidInput();
            // Country
            await _challengePage.PopulateCountryWithValidInput();
            // Email
            await _challengePage.PopulateEmailWithValidInput();
            // Password
            await _challengePage.PopulatePasswordWithValidInput();

            // Click Register button
            await _challengePage.ClickRegisterButton();

            using (new AssertionScope())
            {
                (await _challengePage.GetMessageRegistrationSuccessfulTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.SuccessMessage);

                (await _challengePage.GetInfoFirstNameTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.FirstName + TestDataCorrectInput.FirstName);

                (await _challengePage.GetInfoLastNameTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.LastName + TestDataCorrectInput.LastName);

                (await _challengePage.GetInfoPhoneNumberTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.PhoneNumber + TestDataCorrectInput.PhoneNumber);

                (await _challengePage.GetInfoEmailTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.Email + TestDataCorrectInput.Email);

                (await _challengePage.GetInfoCountryTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.Country + TestDataCorrectInput.Country);
            }
        }


        [Test]
        public async Task TestCase_5_Resigtration_Without_Mandatory_Fields_Should_Not_Be_Successful_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // Clear Mandatory fields
            await _challengePage.ClearMandatoryFields();

            // Click Registration
            await _challengePage.ClickRegisterButton();

            using (new AssertionScope())
            {
                (await _challengePage.GetMessageRegistrationSuccessfulTextLocator().IsVisibleAsync())
                    .Should().BeFalse();
            }
        }


        [Test]
        public async Task TestCase_6_Invalid_Password_Should_Display_Error_Message_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);
            
            // Last Name
            await _challengePage.PopulateLastNameWithValidInput();
            // Phone Number            
            await _challengePage.PopulatePhoneNumberWithValidInput();
            // Email
            await _challengePage.PopulateEmailWithValidInput();
            // Password
            await _challengePage.PopulatePasswordWithInvalidInput();

            // Click Registration
            await _challengePage.ClickRegisterButton();

            using (new AssertionScope())
            {
                (await _challengePage.GetMessagePasswordErrorTextLocator().IsVisibleAsync())
                    .Should().BeTrue();

                (await _challengePage.GetMessagePasswordErrorTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.ErrorPassword);
            }
        }


        [Test]
        public async Task TestCase_7_Invalid_PhoneNumber_Should_Display_Error_Message_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // Last Name
            await _challengePage.PopulateLastNameWithValidInput();
            // Phone Number            
            await _challengePage.PopulatePhoneNumberWithInvalidInput();
            // Email
            await _challengePage.PopulateEmailWithValidInput();
            // Password
            await _challengePage.PopulatePasswordWithValidInput();

            // Click Registration
            await _challengePage.ClickRegisterButton();

            using (new AssertionScope())
            {
                (await _challengePage.GetMessagePhoneNumberErrorTextLocator().IsVisibleAsync())
                    .Should().BeTrue();

                (await _challengePage.GetMessagePhoneNumberErrorTextLocator().InnerTextAsync())
                    .Should().Be(TestDataCommon.ErrorPhoneNumner);
            }
        }

        [Test]
        public async Task TestCase_8_Registration_With_No_LastName_And_Invalid_Email_Should_Not_Be_Successful_Async()
        {
            TestContext.WriteLine(TestContext.CurrentContext.Test.Name);

            // Instantiate Page
            var _challengePage = new ChallengeSpotTheBugsPage(Page);

            // Last Name
            await _challengePage.ClearLastNameFieldInput();
            // Phone Number            
            await _challengePage.PopulatePhoneNumberWithValidInput();
            // Email
            await _challengePage.PopulateEmailWithInvalidInput();
            // Password
            await _challengePage.PopulatePasswordWithValidInput();

            // Click Registration
            await _challengePage.ClickRegisterButton();

            using (new AssertionScope())
            {
                (await _challengePage.GetMessageRegistrationSuccessfulTextLocator().IsVisibleAsync())
                    .Should().BeFalse();
            }
        }
    }
}
