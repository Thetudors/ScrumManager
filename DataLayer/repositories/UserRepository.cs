using DataLayer.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.repositories
{
    public class UserRepository : IUserRepository
    {
        private ScrumManagerEntities context;

        public UserRepository()
        {
            context = new ScrumManagerEntities();
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public IEnumerable GetUsers()
        {
            return context.Users.ToList().Select(u => new { u.UserId,u.Username});
        }

        public User InsertUser(User user)
        {
            return context.Users.Add(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
