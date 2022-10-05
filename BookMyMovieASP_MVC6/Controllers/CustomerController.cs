using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class CustomerController : Controller
    {
        IMovieRepository repo;
        ICustomerRepository customerRepository;
        public CustomerController(IMovieRepository _repo, ICustomerRepository _repo2)
        {
            this.repo = _repo;
            customerRepository = _repo2;
        }

        [HttpGet]
        public IActionResult SignIn()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Akbcustomer customer)
        {
            if (customerRepository.ValidateSignIn(customer.Email, customer.Password))
            {
                //return RedirectToAction("Movie", "List", new { area = "" });
                return RedirectToAction("List", "Movie");
            }
            return View(customer);
        }


        public IActionResult Register() 
        {
            return View();
        }
    }
}
