using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Akbmovie
    {
        public int? MovieId { get; set; }

        [Required(ErrorMessage = "Movie Name is required")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [MaxLength(50)]
        public string MovieName { get; set; } = null!;

        [Required(ErrorMessage = "Release Date is required")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Ratings are required")]
        public int? Ratings { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [MaxLength(200)]
        public string? Genres { get; set; }

        [Required(ErrorMessage = "Image Url is required")]
        [RegularExpression(@"^.{10,}$", ErrorMessage = "Minimum 10 characters required")]
        [MaxLength(50)]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        public int? CostPerSeat { get; set; }

        [Required(ErrorMessage = "Show Time is required")]
        public DateTime? ShowTime { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [MaxLength(10)]
        public string? Duration { get; set; }

        [Required(ErrorMessage = "Age Rating is required")]
        [RegularExpression(@"^.{1,}$", ErrorMessage = "Minimum 1 character required")]
        [MaxLength(4)]
        public string? AgeRating { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [MaxLength(10)]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Theatre Type is required")]
        [RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(10)]
        public string? MovieType { get; set; }
    }
}
