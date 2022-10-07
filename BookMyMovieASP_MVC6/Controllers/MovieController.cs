using AspNetCoreHero.ToastNotification.Abstractions;
using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo;
        INotyfService _notyf;
        public MovieController(IMovieRepository _repo, ICustomerRepository _repo2, INotyfService notyf)
        {
            this.repo = _repo;
            _notyf = notyf;
        }
   
        public IActionResult List()
        {
            var data = repo.GetMovies();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            if (CustomerStore.Email.Length == 0)
            {
                _notyf.Error("Unauthorized Access Detected");
                return RedirectToAction("SignIn", "Customer");
            }
            var data = repo.GetMovieById(id);
            return View(data);
        }
        public IActionResult SeatBook() 
        {
            return View();
        }
    }
}