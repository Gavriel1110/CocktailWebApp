using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class UserManager
    {
        private User userDAL = new User();
        private Customer customerDAL = new Customer();

        public User GetUserById(int userId)
        {
            return userDAL.GetUserById(userId);
        }

        public User GetUserByUsername(string username)
        {
            return userDAL.GetUserByUsername(username);
        }

        public bool AddUser(string username, string password, bool isAdmin)
        {
            return userDAL.AddUser(username, password, isAdmin);
        }

        public List<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public bool AuthenticateUser(string username, string password)
        {
            return userDAL.AuthenticateUser(username, password);
        }

        public bool CreateUser(string username, string password, bool isAdmin, string firstName, string lastName, string email, string phone)
        {
            bool userCreated = userDAL.AddUser(username, password, isAdmin);
            if (userCreated)
            {
                User user = userDAL.GetUserByUsername(username);
                if (user != null)
                {
                    return customerDAL.AddCustomer(user.UserID, firstName, lastName, email, phone);
                }
            }
            return false;
        }
    }
}
