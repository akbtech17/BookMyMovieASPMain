using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BookMyMovieASP_MVC6.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        Db01Context db = new Db01Context();

        public Akbcustomer GetCustomerDetails(string Email)
        {
            try
            {
                var customer = db.Akbcustomers.Where(c => c.Email.ToLower().Equals(Email.ToLower())).FirstOrDefault();
                return customer;
            }
            catch (Exception Ex) {
                return null;
            }
            return null;
        }

        public bool RegisterCustomer(Akbcustomer customerDetails)
        {
            try
            {
                customerDetails.CustomerId = null;
                db.Akbcustomers.Add(customerDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool ValidateSignIn(string Email, string Password)
        {

            var data = db.Akbcustomers.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();
            return data != null;
        }
    }
}
