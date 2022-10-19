using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class AdminController : Controller
    {
        public static int MovieId { get; set; }

        IMovieRepository movieRepository;
        IAdminRepository adminRepository;
        INotyfService _notyf;
        public AdminController(IMovieRepository _repo, IAdminRepository _repo2, INotyfService notyf)
        {
            this.movieRepository = _repo;
            adminRepository = _repo2;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Akbadmin admin)
        {
            if (adminRepository.ValidateSignIn(admin.Email, admin.Password))
            {
                AdminStore.Email = admin.Email;
                AdminStore.Name = adminRepository.GetAdminDetails(admin.Email).FirstName;
                _notyf.Success("Login Success");
                return RedirectToAction("MovieList");
            }
            _notyf.Error("Login Failed");
            return View(admin);
        }

        [HttpGet]
        public IActionResult Logout() {
            AdminStore.Email = "";
            AdminStore.Name = "";
            _notyf.Success("Logged Out");
            return RedirectToAction("List", "Movie");
        }

 
        public IActionResult MovieList()
        {
            /*ViewBag.adminName = adminName;*/
            List<Akbmovie> data = movieRepository.GetMovies();
            return View(data);
        }

        
        public IActionResult MovieDetails(int id)
        {
            Akbmovie data = movieRepository.GetMovieById(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            /*if (AdminStore.Email.Length == 0)
            {
                _notyf.Error("Unauthorized Access Detected");
                return RedirectToAction("SignIn", "Admin");
            }*/

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Akbmovie movie)
        {
            if (ModelState.IsValid) {
                movieRepository.AddMovie(movie);
                _notyf.Success("Movie Added Successfuly");
                return RedirectToAction("MovieList", "Admin");
            }
            _notyf.Error("Operation Failed");
            return View(movie);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            /*if (AdminStore.Email.Length == 0)
            {
                _notyf.Error("Unauthorized Access Detected");
                return RedirectToAction("SignIn", "Admin");
            }*/
            var movieDetails = movieRepository.GetMovieById(id);
            MovieId = id;
            return View(movieDetails);
        }

        [HttpPost]
        public IActionResult EditMovie(Akbmovie movieDetails) {
            movieDetails.MovieId = MovieId;
            if (movieRepository.EditMovie(movieDetails)) {
                _notyf.Success("Movie Updated Successfuly");
                return RedirectToAction("MovieList", "Admin");
            }
            _notyf.Error("Operation Failed");
            return View();
        }

        public IActionResult DeleteMovie(int id)
        {
            movieRepository.DeleteMovie(id);
            _notyf.Success("Movie Deleted Successfuly");
            return RedirectToAction("MovieList", "Admin");
        }
    }
}
