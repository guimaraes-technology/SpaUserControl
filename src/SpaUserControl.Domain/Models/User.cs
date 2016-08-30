using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using System;

namespace SpaUserControl.Domain.Models
{
    public class User
    {
        protected User()
        {
        }

        public User(string name, string email)
        {
            Id = new Guid();
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Errors.InvalidPasswordConfirmation);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, Errors.PasswordsDoesNotMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Errors.InvalidUserPassword);

            Password = password;
        }

        public string ResetPassword()
        {
            var password = Guid.NewGuid().ToString().Substring(0, 8);
            Password = PasswordAssertionConcern.Encrypt(password);

            return password;
        }

        public void ChangeName(string name)
        {
            AssertionConcern.AssertArgumentNotNull(name, Errors.InvalidUserName);
            AssertionConcern.AssertArgumentLength(Name, 3, 60, Errors.InvalidUserName);

            Name = name;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(Name, 3, 60, Errors.InvalidUserName);
            EmailAssertionConcern.AssertIsValid(Email);
            PasswordAssertionConcern.AssertIsValid(Password);
        }
    }
}