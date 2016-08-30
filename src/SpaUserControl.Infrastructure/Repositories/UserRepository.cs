using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infrastructure.Data;
using System;
using System.Data.Entity;

namespace SpaUserControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext context;

        public UserRepository(AppDataContext context)
        {
            this.context = context;
        }

        public User Get(Guid id)
        {
            return context.Users.Find(id);
        }

        public User Get(string email)
        {
            return context.Users.Find(email.ToLower());
        }

        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.Entry<User>(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            context.Entry<User>(user).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}