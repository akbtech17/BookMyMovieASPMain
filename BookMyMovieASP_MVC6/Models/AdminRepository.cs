namespace BookMyMovieASP_MVC6.Models
{
    public class AdminRepository : IAdminRepository
    {
        Db01Context db = new Db01Context();
        public bool ValidateSignIn(string Email, string Password)
        {
            var data = db.Akbadmins.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();
            return data != null;
        }
    }
}
