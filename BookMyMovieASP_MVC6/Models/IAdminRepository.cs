namespace BookMyMovieASP_MVC6.Models
{
    public interface IAdminRepository
    {
        bool ValidateSignIn(string Email, string Password);
        Akbadmin GetAdminDetails(string Email);

    }
}
