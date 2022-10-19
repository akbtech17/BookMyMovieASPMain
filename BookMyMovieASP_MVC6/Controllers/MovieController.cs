using AspNetCoreHero.ToastNotification.Abstractions;
using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo;
        INotyfService _notyf;
        ITransactionRepository _transRepo;
        public MovieController(IMovieRepository _repo, ICustomerRepository _repo2, INotyfService notyf, ITransactionRepository repo3)
        {
            this.repo = _repo;
            _notyf = notyf;
            _transRepo = repo3;
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
            Akbmovie data = repo.GetMovieById(id);
            TransactionRequest.MovieId = id;
            return View(data);
        }
        [HttpGet]
        public IActionResult SeatBook() 
        {
            SeatmapWithSeatInput viewDetails = new SeatmapWithSeatInput();
            viewDetails.seats = repo.GetSeatMap(1);
            viewDetails.selectedSeats = "";
            return View(viewDetails);
        }

		[HttpPost]
		public IActionResult SeatBook(SeatmapWithSeatInput request)
		{
            TransactionRequest.TransactionTime = DateTime.Now;
			TransactionRequest.Seats = request.selectedSeats.Split(", ");
            TransactionRequest obj = new TransactionRequest();

            if (obj != null) {
				TransactionResponse response =  _transRepo.CreateTransaction(obj);
                if (response != null)
                {
					ViewBag.response = response;
					return RedirectToAction("BookingConfirmation", "Movie");
				}
                else {
					_notyf.Error("Transaction Failed");
					return View();
				}
               
			}
            return View();
		}

		[HttpGet]
        public IActionResult BookingConfirmation(TransactionResponse response) {
            return View(ViewBag.response);
        }
    }
}