using System.ComponentModel.DataAnnotations;

namespace BookMyMovieASP_MVC6.Models
{
	public class RegisterViewModel
	{
		public int? CustomerId { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; } = null!;
		
		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		[MinLength(8)]
		[MaxLength(20)]
		public string Password { get; set; } = null!;

		[Required(ErrorMessage = "Confirm Password is required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password an confirmation password do not match.")]
		[MinLength(8)]
		[MaxLength(20)]
		public string ConfirmPassword { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string Gender { get; set; } = null!;
	}
}
