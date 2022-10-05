using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
