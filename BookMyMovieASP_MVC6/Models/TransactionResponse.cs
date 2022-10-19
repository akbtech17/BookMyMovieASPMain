namespace BookMyMovieASP_MVC6.Models
{
	public class TransactionResponse
	{
		public int? TransactionId { get; set; }
		public DateTime TransactionTime { get; set; }
		public string[] Seats { get; set; }

		public int? TotalCost { get; set; }

		public int? CustomerId { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }


		public int? MovieId { get; set; }
		public string MovieName { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public int? Ratings { get; set; }
		public string Genres { get; set; }
		public string ImageUrl { get; set; }
		public int? CostPerSeat { get; set; }
		public DateTime? ShowTime { get; set; }
		public string Duration { get; set; }
		public string AgeRating { get; set; }
		public string Language { get; set; }
		public string MovieType { get; set; }

	}
}
