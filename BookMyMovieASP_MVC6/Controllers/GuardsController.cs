using BookMyMovieASP_MVC6.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyMovieASP_MVC6.Controllers
{
	public class GuardsController : Controller
	{
		public bool IsAdminLoggedIn()
		{
			return AdminStore.Email.Equals("");
		}

		public bool IsCustomerLoggedIn() 
		{
			return CustomerStore.Email.Equals("");
		}
	}
}
