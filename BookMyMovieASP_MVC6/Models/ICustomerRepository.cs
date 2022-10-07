namespace BookMyMovieASP_MVC6.Models
{
    public interface ICustomerRepository
    {
        bool ValidateSignIn(string Email, string Password);
        Akbcustomer GetCustomerDetails(string Email);

        bool RegisterCustomer(Akbcustomer customerDetails);
    }
}
