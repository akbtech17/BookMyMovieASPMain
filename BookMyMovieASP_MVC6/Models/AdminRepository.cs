namespace BookMyMovieASP_MVC6.Models
{
    public class AdminRepository : IAdminRepository
    {
        Db01Context db = new Db01Context();

        public Akbadmin GetAdminDetails(string Email)
        {
            Akbadmin? adminData = db.Akbadmins.Where(x => x.Email.ToLower().Equals(Email.ToLower())).FirstOrDefault();
            return adminData;
        }

        public bool ValidateSignIn(string Email, string Password)
        {
			Akbadmin? data = db.Akbadmins.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();
            return data != null;
        }


    }
}
