using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Akbmovie
    {
        public Akbmovie()
        {
            AkbseatMaps = new HashSet<AkbseatMap>();
            AkbtransactionDetails = new HashSet<AkbtransactionDetail>();
        }

		[Display(Name = "Movie Id")]
		public int? MovieId { get; set; }

		[Display(Name = "Movie Name")]
		[Required(ErrorMessage = "Movie Name is required")]
		[RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
		[MaxLength(50)]
		public string MovieName { get; set; } = null!;

		[Required(ErrorMessage = "Release Date is required")]
		[DisplayFormat(DataFormatString = "{0: MMM dd, yyyy}")]
		[Display(Name = "Release Date")]
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
		[Display(Name = "Image URL")]
		public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Cost is required")]
		[Display(Name = "Seat Cost")]
		public int? CostPerSeat { get; set; }
		

		[Required(ErrorMessage = "Show Time is required")]
		[DisplayFormat(DataFormatString = "{0: MMM dd, yyyy}")]
		[Display(Name = "Show Time")]
		public DateTime? ShowTime { get; set; }

		[Required(ErrorMessage = "Duration is required")]
		[RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
		[MaxLength(10)]
		public string? Duration { get; set; }

		[Required(ErrorMessage = "Age Rating is required")]
		[RegularExpression(@"^.{1,}$", ErrorMessage = "Minimum 1 character required")]
		[MaxLength(4)]
		[Display(Name = "Age Rating")]
		public string? AgeRating { get; set; }

		[Required(ErrorMessage = "Language is required")]
		[RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
		[MaxLength(10)]
		public string? Language { get; set; }

		[Required(ErrorMessage = "Theatre Type is required")]
		[RegularExpression(@"^.{2,}$", ErrorMessage = "Minimum 2 characters required")]
		[MaxLength(10)]
		[Display(Name = "Theatre Type")]
		public string? MovieType { get; set; }

		[Display(Name = "Is Adult")]
		public bool IsAdult { get; set; }

        public virtual ICollection<AkbseatMap> AkbseatMaps { get; set; }
        public virtual ICollection<AkbtransactionDetail> AkbtransactionDetails { get; set; }
    }
}
