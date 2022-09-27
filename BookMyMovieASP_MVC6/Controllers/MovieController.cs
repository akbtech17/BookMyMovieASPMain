using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo;
        public MovieController(IMovieRepository _repo) {
            this.repo = _repo;  
        }
        public IActionResult List()
        {
            var data = repo.GetMovies();
            return View(data);
        }
        public IActionResult Details()
        {
            var data = repo.GetMovieById(1);
            return View(data);
        }

    }
}
