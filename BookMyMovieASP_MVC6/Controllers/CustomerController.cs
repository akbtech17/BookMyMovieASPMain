using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }
    }
}
