using DataLayer;
using DataLayer.interfaces;
using DataLayer.repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserManager : Manager
    {

        public IEnumerable GetUsers()
        {
            try
            {
                IUserRepository userRepository = new UserRepository();

                return userRepository.GetUsers();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Status Login(User user)
        {
            try
            {
                IUserRepository userRepository = new UserRepository();
               User u = userRepository.GetUserByUsername(user.Username);

                if (u == null)
                    return Status.Fail;

                if (user.Password == u.Password)
                {
                    SetCurrentUser(u);

                    return Status.Success;
                }

                return Status.Fail;
            }
            catch (Exception)
            {
                return Status.Fail;
            }
        }
        

  

        public User currentUser;

        public Status Register(User user)
        {
            try
            {
                IUserRepository userRepository = new UserRepository();

                currentUser = userRepository.InsertUser(user);

                SetCurrentUser(currentUser);

                userRepository.Save();

                return Status.Success;
            }
            catch (Exception )
            {
                return Status.Fail;
            }
       
        }

        private void SetCurrentUser(User currentUser)
        {
            this.currentUser = new User
            {
                UserId = currentUser.UserId,
                Username = currentUser.Username,
                Password = currentUser.Password
            };
        }
        
    }
}
