using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo;
        public MovieController(IMovieRepository _repo) 
        {
            this.repo = _repo;  
        }
        public IActionResult List()
        {
            var data = repo.GetMovies();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = repo.GetMovieById(id);
            return View(data);
        }
        public IActionResult SeatBook() 
        {
            return View();
        }
    }
}