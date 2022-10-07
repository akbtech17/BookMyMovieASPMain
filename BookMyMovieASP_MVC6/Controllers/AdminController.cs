using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;


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
                AdminStore.Name = adminRepository.GetAdminDetails(admin.Email).FirstName;
                return RedirectToAction("MovieList");
            }
            return View(admin);
        }

        [HttpGet]
        public IActionResult Logout() {
            AdminStore.Email = "";
            AdminStore.Name = "";
            return RedirectToAction("List", "Movie");
        }

 
        public IActionResult MovieList()
        {
            /*ViewBag.adminName = adminName;*/
            var data = movieRepository.GetMovies();
            return View(data);
        }

        
        public IActionResult MovieDetails(int id)
        {
            var data = movieRepository.GetMovieById(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            if (AdminStore.Email.Length == 0) {
                return RedirectToAction("List", "Movie");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Akbmovie movie)
        {
            if (ModelState.IsValid) {
                movieRepository.AddMovie(movie);
                return RedirectToAction("MovieList", "Admin");
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movieDetails = movieRepository.GetMovieById(id);
            return View(movieDetails);
        }

        [HttpPost]
        public IActionResult EditMovie(Akbmovie movieDetails) {

            return RedirectToAction("MovieList", "Admin");
        }

        public IActionResult DeleteMovie(int id)
        {
            movieRepository.DeleteMovie(id);
            return RedirectToAction("MovieList", "Admin");
        }
    }
}
