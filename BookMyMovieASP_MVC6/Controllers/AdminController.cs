using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        public IActionResult EditMovie()
        {
            return View();
        }
    }
}
