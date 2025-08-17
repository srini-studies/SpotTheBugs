using FluentAssertions;
using Microsoft.Playwright;
using SpotTheBugs.Data;

namespace SpotTheBugs.Pages
{    
    public class ChallengeSpotTheBugsPage
    {
        IPage _page;

        private readonly ILocator _headingChallengeSpotTheBugs;
        private readonly ILocator _txtboxFirstName;
        private readonly ILocator _txtboxLastName;
        private readonly ILocator _txtboxPhoneNumber;
        private readonly ILocator _dropdownCountry;
        private readonly ILocator _txtboxEmail;
        private readonly ILocator _txtboxPassword;
        private readonly ILocator _checkboxTermsAndConditions;
        private readonly ILocator _buttonRegister;
        private readonly ILocator _textMessageSuccessfullyRegistered;
        private readonly ILocator _textMessagePasswordError;
        private readonly ILocator _textMessagePhoneNumberError;
        private readonly ILocator _textInfoFirstName;
        private readonly ILocator _textInfoLastName;
        private readonly ILocator _textInfoPhoneNumber;
        private readonly ILocator _textInfoCountry;
        private readonly ILocator _textInfoEmail;

        public ChallengeSpotTheBugsPage(IPage page)
        {
            _page = page;

            _headingChallengeSpotTheBugs = _page.GetByRole(AriaRole.Heading, new() { Name = "CHALLENGE - Spot the BUGS!" } );
            _txtboxFirstName = _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name" });
            _txtboxLastName = _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name* Phone nunber*" });
            _txtboxPhoneNumber = _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter phone number" });            
            _dropdownCountry = _page.Locator("#countries_dropdown_menu");
            _txtboxEmail = _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter email" });
            _txtboxPassword = _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
            _checkboxTermsAndConditions = page.GetByRole(AriaRole.Checkbox, new() { Name = "I agree with the terms and conditions" });
            _buttonRegister = _page.GetByRole(AriaRole.Button, new() { Name = "Register" });

            _textMessageSuccessfullyRegistered = _page.GetByText("Successfully registered");
            _textMessagePasswordError = _page.GetByText("The password should contain");
            _textMessagePhoneNumberError = _page.GetByText("The phone number should");
            _textInfoFirstName = _page.GetByText("First Name:");
            _textInfoLastName = _page.GetByText("Last Name:");
            _textInfoPhoneNumber = _page.GetByText("Phone Number:");
            _textInfoCountry = _page.GetByText("Country:");
            _textInfoEmail = _page.GetByText("Email:");
        }

        public ILocator GetHeadingLocator() => _headingChallengeSpotTheBugs;
  
        public ILocator GetFirstNameTextBoxLocator() => _txtboxFirstName;

        public ILocator GetLastNameTextBoxLocator() => _txtboxLastName;

        public ILocator GetPhoneNumberTextBoxLocator() => _txtboxPhoneNumber;

        public ILocator GetEmailTextBoxLocator() => _txtboxEmail;

        public ILocator GetPasswordTextBoxLocator() => _txtboxPassword;

        public ILocator GetCountryDropdownLocator() => _dropdownCountry;

        public ILocator GetTermsAndConditionsCheckBoxLocator() => _checkboxTermsAndConditions;

        public ILocator GetRegisterButtonLocator() => _buttonRegister;

        public ILocator GetMessageRegistrationSuccessfulTextLocator() => _textMessageSuccessfullyRegistered;
     
        public ILocator GetMessagePasswordErrorTextLocator() => _textMessagePasswordError;

        public ILocator GetMessagePhoneNumberErrorTextLocator() => _textMessagePhoneNumberError;

        public ILocator GetInfoFirstNameTextLocator() => _textInfoFirstName;

        public ILocator GetInfoLastNameTextLocator() => _textInfoLastName;

        public ILocator GetInfoPhoneNumberTextLocator() => _textInfoPhoneNumber;

        public ILocator GetInfoCountryTextLocator() => _textInfoCountry;
  
        public ILocator GetInfoEmailTextLocator() => _textInfoEmail;
  

        public async Task ClickRegisterButton()
        {
            await _buttonRegister.ClickAsync();
        }

        public async Task PopulateFirstNameWithValidInput()
        {
            await _txtboxFirstName.FillAsync(TestDataCorrectInput.FirstName);
        }

        public async Task PopulateLastNameWithValidInput()
        {
            await _txtboxLastName.FillAsync(TestDataCorrectInput.LastName);
        }

        public async Task ClearLastNameFieldInput()
        {
            await _txtboxLastName.ClearAsync();
        }

        public async Task PopulatePhoneNumberWithValidInput()
        {
            await _txtboxPhoneNumber.FillAsync(TestDataCorrectInput.PhoneNumber);
        }

        public async Task PopulatePhoneNumberWithInvalidInput()
        {
            await _txtboxPhoneNumber.FillAsync(TestDataIncorrectInput.PhoneNumber);
        }

        public async Task PopulatePasswordWithValidInput()
        {
            await _txtboxPassword.FillAsync(TestDataCorrectInput.Password);
        }

        public async Task PopulatePasswordWithInvalidInput()
        {
            await _txtboxPassword.FillAsync(TestDataIncorrectInput.Password);
        }

        public async Task PopulateEmailWithValidInput()
        {
            await _txtboxEmail.FillAsync(TestDataCorrectInput.Email);
        }

        public async Task PopulateEmailWithInvalidInput()
        {
            await _txtboxEmail.FillAsync(TestDataIncorrectInput.Email);
        }

        public async Task PopulateCountryWithValidInput()
        {
            await _dropdownCountry.SelectOptionAsync(new SelectOptionValue { Label = TestDataCorrectInput.Country });
        }

        public async Task ClearMandatoryFields()
        {
            await _txtboxLastName.ClearAsync();
            await _txtboxPhoneNumber.ClearAsync();
            await _txtboxPassword.ClearAsync();
            await _txtboxEmail.ClearAsync();
        }

        public async Task PopulateMandatoryFieldsWithValidInput()
        {
            await Task.CompletedTask;
        }
    }
}
