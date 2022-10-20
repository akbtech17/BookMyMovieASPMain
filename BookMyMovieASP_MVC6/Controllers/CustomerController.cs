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
                int? cId = customerRepository.GetCustomerDetails(customer.Email).CustomerId;
				if(cId != null) TransactionRequest.CustomerId = cId;
                _notyf.Success("Login Success");
                return RedirectToAction("List", "Movie");
            }
            _notyf.Error("Login Failed");
            return View(customer);
        }

        [HttpGet]
        public IActionResult Logout() {
            CustomerStore.Email = "";
            CustomerStore.Name = "";
            _notyf.Success("Logged Out");
            return RedirectToAction("List", "Movie");
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel details)
        {
            Akbcustomer customerDetails = new Akbcustomer();
            customerDetails.FirstName = details.FirstName;
            customerDetails.Gender = details.Gender;
            customerDetails.Password = details.Password;
            customerDetails.Email = details.Email;

			if (customerRepository.RegisterCustomer(customerDetails)) {
                _notyf.Success("User Registered");
                return RedirectToAction("SignIn", "Customer");
            }
            _notyf.Success("Registration Failed");
            return View();
        }
    }
}
