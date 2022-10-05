using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class AdminController : Controller
    {
        IMovieRepository repo;
        public AdminController(IMovieRepository _repo)
        {
            this.repo = _repo;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var data = repo.GetMovies();
            return View(data);
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
