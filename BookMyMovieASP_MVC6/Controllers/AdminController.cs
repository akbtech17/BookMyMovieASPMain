using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class AdminController : Controller
    {
        IMovieRepository repo;
        IAdminRepository adminRepository;
        public AdminController(IMovieRepository _repo, IAdminRepository _repo2)
        {
            this.repo = _repo;
            adminRepository = _repo2;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            Akbadmin akbadmin = new Akbadmin(); 
            return View(akbadmin);
        }

        [HttpPost]
        public IActionResult SignIn(Akbadmin admin)
        {
            if(adminRepository.ValidateSignIn(admin.Email, admin.Password)) {
                return RedirectToAction("MovieList");
            }
            return View(admin);
        }

        public IActionResult MovieList()
        {
            var data = repo.GetMovies();
            return View(data);
        }

        public IActionResult MovieDetails()
        {
            var data = repo.GetMovieById(1);
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
