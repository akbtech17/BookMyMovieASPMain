using System;
using System.Collections.Generic;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Akbcustomer
    {
        public int CustomerId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
    }
}
