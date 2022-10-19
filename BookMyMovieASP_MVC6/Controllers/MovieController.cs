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

			MovieListWithSearch movieListWithSearch = new MovieListWithSearch();
			movieListWithSearch.movies = repo.GetMovies();
			movieListWithSearch.filterString = "";

			return View(movieListWithSearch);
		}

		[HttpPost]
		public IActionResult List(MovieListWithSearch movieListWithSearch)
		{
            
			movieListWithSearch.movies = repo.GetMovies();
			if (movieListWithSearch.filterString == null) return View(movieListWithSearch);
			movieListWithSearch.movies = movieListWithSearch.movies.Where(m => m.MovieName.Substring(0, movieListWithSearch.filterString.Length).ToLower().Equals(movieListWithSearch.filterString.ToLower())).ToList();
			return View(movieListWithSearch);
		}

		public IActionResult Details(int id)
        {
            /*if (CustomerStore.Email.Length == 0)
            {
                _notyf.Error("Unauthorized Access Detected");
                return RedirectToAction("SignIn", "Customer");
            }*/
            var data = repo.GetMovieById(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult SeatBook() 
        {
            List<AkbseatMap> seatMap = repo.GetSeatMap(1);
            return View(seatMap);
        }

        [HttpGet]
        public IActionResult BookingConfirmation() {
            return View();
        }
    }
}