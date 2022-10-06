using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Akbadmin
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid password")]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;
    }
}
