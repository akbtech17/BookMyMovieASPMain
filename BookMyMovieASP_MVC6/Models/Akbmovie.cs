using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookMyMovieASP_MVC6.Models
{
    public partial class Akbmovie
    {
        public Akbmovie()
        {
            AkbseatMaps = new HashSet<AkbseatMap>();
            AkbtransactionDetails = new HashSet<AkbtransactionDetail>();
        }

        public int? MovieId { get; set; }

		[DisplayName("Name")]
		public string MovieName { get; set; } = null!;

		[DisplayName("Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[DisplayName("Likes")]
		public int? Ratings { get; set; }
        public string? Genres { get; set; }
        public string? ImageUrl { get; set; }

		[DisplayName("Seat Cost")]
		public int? CostPerSeat { get; set; }
        public DateTime? ShowTime { get; set; }
        public string? Duration { get; set; }

		[DisplayName("Age Rating")]
		public string? AgeRating { get; set; }
        public string? Language { get; set; }
        public string? MovieType { get; set; }

        public virtual ICollection<AkbseatMap> AkbseatMaps { get; set; }
        public virtual ICollection<AkbtransactionDetail> AkbtransactionDetails { get; set; }
    }
}
