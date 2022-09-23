using System;
using System.Collections.Generic;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int? Ratings { get; set; }
        public string? Genres { get; set; }
        public string? ImageUrl { get; set; }
        public int? CostPerSeat { get; set; }
        public DateTime? ShowTime { get; set; }
        public string? Duration { get; set; }
        public string? AgeRating { get; set; }
        public string? Language { get; set; }
        public string? MovieType { get; set; }
    }
}
