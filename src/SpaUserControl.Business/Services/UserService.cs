using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using System;

namespace SpaUserControl.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);
            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Errors.InvalidCredentials);
            return user;
        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);
            user.ChangeName(name);
            user.Validate();

            repository.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);
            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            repository.Update(user);
        }

        public User GetByEmail(string email)
        {
            var user = repository.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);
            return user;
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = GetByEmail(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            repository.Create(user);
        }

        public string ResetPassword(string email)
        {
            var user = repository.Get(email);
            var password = user.ResetPassword();
            user.Validate();

            repository.Update(user);
            return password;
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}