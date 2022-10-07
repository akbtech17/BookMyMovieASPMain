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
                CustomerStore.Email = customer.Email;
                CustomerStore.Name = customerRepository.GetCustomerDetails(customer.Email).FirstName;
                return RedirectToAction("List", "Movie");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Logout() {
            CustomerStore.Email = "";
            CustomerStore.Name = "";
            return RedirectToAction("List", "Movie");
        }

        public IActionResult Register() 
        {
            return View();
        }
    }
}
