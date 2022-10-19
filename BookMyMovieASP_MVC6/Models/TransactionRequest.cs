namespace BookMyMovieASP_MVC6.Models
{
	public class TransactionRequest
	{
		public int TransactionId { get; set; }
		public int MovieId { get; set; }
		public int CustomerId { get; set; }
		public DateTime TransactionTime { get; set; }
		public string[] Seats { get; set; }
	}
}
