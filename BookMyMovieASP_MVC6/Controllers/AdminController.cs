using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class AdminController : Controller
    {
        IMovieRepository movieRepository;
        IAdminRepository adminRepository;
        public AdminController(IMovieRepository _repo, IAdminRepository _repo2)
        {
            this.movieRepository = _repo;
            adminRepository = _repo2;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            //Akbadmin akbadmin = new Akbadmin(); 
            //return View(akbadmin);
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Akbadmin admin)
        {
            if (adminRepository.ValidateSignIn(admin.Email, admin.Password))
            {
                AdminStore.Email = admin.Email;
                return RedirectToAction("MovieList");
            }
            return View(admin);
        }

 
        public IActionResult MovieList()
        {
            var data = movieRepository.GetMovies();
            return View(data);
        }

        public IActionResult MovieDetails()
        {
            var data = movieRepository.GetMovieById(1);
            return View(data);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Akbmovie movie)
        {
            if (ModelState.IsValid) {
                movieRepository.AddMovie(movie);
                return RedirectToAction("List", "Movie");
            }
            return View(movie);
        }

        public IActionResult EditMovie()
        {
            return View();
        }
    }
}
