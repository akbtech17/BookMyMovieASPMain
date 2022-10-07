using AspNetCoreHero.ToastNotification.Abstractions;
using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
    public class CustomerController : Controller
    {
        IMovieRepository repo;
        ICustomerRepository customerRepository;
        INotyfService _notyf;
        public CustomerController(IMovieRepository _repo, ICustomerRepository _repo2, INotyfService notyf)
        {
            this.repo = _repo;
            customerRepository = _repo2;
            _notyf = notyf;
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
                _notyf.Success("Success Notification");
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
