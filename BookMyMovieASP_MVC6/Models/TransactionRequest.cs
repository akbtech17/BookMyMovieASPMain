namespace BookMyMovieASP_MVC6.Models
{
	public class TransactionRequest
	{
		public static int? TransactionId { get; set; }
		public static int? MovieId { get; set; }
		public static int? CustomerId { get; set; }
		public static DateTime? TransactionTime { get; set; }
		public static string[]? Seats { get; set; }
	}
}
