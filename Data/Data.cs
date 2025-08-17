using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotTheBugs.Data
{
    public static class TestDataCommon
    {
        public const string Heading = "CHALLENGE - Spot the BUGS!";
        public const string SuccessMessage = @"Successfully registered the following information";
        public const string ErrorPhoneNumner = @"The phone number should contain at least 10 characters!";
        public const string ErrorPassword = @"The password should contain between [6,20] characters!";
        public const string FirstName = @"First Name: ";
        public const string LastName = @"Last Name: ";
        public const string PhoneNumber = @"Phone Number: ";
        public const string Email = @"Email: ";
        public const string Country = @"Country: ";
    }

    public static class TestDataCorrectInput
    {
        public const string FirstName = @"John";
        public const string LastName = @"Doe";
        public const string PhoneNumber = @"12345678901";
        public const string Country = @"Japan";
        public const string Email = @"abcd@email.com";
        public const string Password = @"12345678912";
    }

    public static class TestDataIncorrectInput
    {
        public const string FirstName = @"John";
        public const string LastName = @"Doe";
        public const string PhoneNumber = @"";
        public const string Country = @"12345";
        public const string Email = @"abcd";
        public const string Password = @"12345";
    }

}



