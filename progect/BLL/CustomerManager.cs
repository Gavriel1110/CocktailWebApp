using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class CustomerManager
    {
        private Customer customerDAL = new Customer();

        public List<Customer> GetAllCustomers()
        {
            return customerDAL.GetAllCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            return customerDAL.GetCustomerById(customerId);
        }

        public Customer GetCustomerByUserId(int userId)
        {
            return customerDAL.GetCustomerByUserId(userId);
        }

        public bool UpdateCustomerProfile(int userId, string firstName, string lastName, string email, string phone)
        {
            return customerDAL.UpdateCustomerProfile(userId, firstName, lastName, email, phone);
        }

        public void DeleteCustomer(int customerId)
        {
            customerDAL.DeleteCustomer(customerId);
        }

        public bool AddCustomer(int userId, string firstName, string lastName, string email, string phone)
        {
            return customerDAL.AddCustomer(userId, firstName, lastName, email, phone);
        }

        public bool UpdateCustomer(int customerId, string firstName, string lastName, string email, string phone)
        {
            return customerDAL.UpdateCustomer(customerId, firstName, lastName, email, phone);
        }
    }
}
