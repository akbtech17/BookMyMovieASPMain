using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Akbmovie
    {
        public int? MovieId { get; set; }

        [Required(ErrorMessage = "Movie Name is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Movie Name")]
        [MinLength(8)]
        [MaxLength(20)]
        public string MovieName { get; set; } = null!;

        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Ratings are required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Ratings")]
        public int? Ratings { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Genre")]
        public string? Genres { get; set; }

        [Required(ErrorMessage = "Image Url is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Image Url")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Cost")]
        public int? CostPerSeat { get; set; }

        [Required(ErrorMessage = "Show Time is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Show Time")]
        public DateTime? ShowTime { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Duration")]
        [MinLength(2)]
        [MaxLength(20)]
        public string? Duration { get; set; }

        [Required(ErrorMessage = "Age Rating is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Age Rating")]
        [MinLength(1)]
        [MaxLength(4)]
        public string? AgeRating { get; set; }

        [Required(ErrorMessage = "Language is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Language")]
        [MinLength(4)]
        [MaxLength(20)]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Theatre Type is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Theatre Type")]
        [MinLength(2)]
        [MaxLength(20)]
        public string? MovieType { get; set; }
    }
}
