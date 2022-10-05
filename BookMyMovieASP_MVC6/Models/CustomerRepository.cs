namespace BookMyMovieASP_MVC6.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        Db01Context db = new Db01Context();
        public bool ValidateSignIn(string Email, string Password)
        {

            var data = db.Akbcustomers.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();
            return data != null;
        }
    }
}
