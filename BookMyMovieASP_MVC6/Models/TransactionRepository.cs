using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace BookMyMovieASP_MVC6.Models
{
	public class TransactionRepository : ITransactionRepository
	{
		Db01Context db = new Db01Context();
		public static string connAzureStorage = "DefaultEndpointsProtocol=https;AccountName=anshulkumarstorage256;AccountKey=PEdBR+R7xlLxZdCrfCmURzVlWLYEUlpmkGdGJP9diqkcyN9uIfxB9ZHnx3L481ULKBYnOMznHlgA+AStix+Sjg==;EndpointSuffix=core.windows.net";
		public void AddMessageToQueue(string message)
		{
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connAzureStorage);
			CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
			CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("transactions");
			CloudQueueMessage queueMessage = new CloudQueueMessage(message);
			cloudQueue.AddMessageAsync(queueMessage);
		}

		public TransactionResponse CreateTransaction(TransactionRequest TransactionRequest)
		{
			Guid guid = Guid.NewGuid();
			Random random = new Random();
			int tId = random.Next();

			DateTime dt = DateTime.Now; 

			// 1. post transaction details to transaction table
			AkbtransactionDetail transactionDetails = new AkbtransactionDetail();
			transactionDetails.TransactionId = tId;
			transactionDetails.MovieId = TransactionRequest.MovieId;
			transactionDetails.CustomerId = TransactionRequest.CustomerId;
			transactionDetails.TransactionTime = dt;
			db.AkbtransactionDetails.Add(transactionDetails);
			db.SaveChanges();

			// 2. post transaction seats details to seat table
			int? transactionId = tId;

			if (transactionId != null)
			{
				foreach (string seat in TransactionRequest.Seats)
				{
					db.AkbtransactionSeats.Add(new AkbtransactionSeat { TransactionId = transactionId, SeatNo = seat });
					AkbseatMap akbseatMap = db.AkbseatMaps.Where(sm => sm.MovieId == TransactionRequest.MovieId && sm.SeatNo.Equals(seat)).FirstOrDefault();
					akbseatMap.Status = 2;
					db.SaveChanges();
				}
			}


			// post to azure
			Akbcustomer customer = db.Akbcustomers.Where(c => c.CustomerId == TransactionRequest.CustomerId).FirstOrDefault();
			Akbmovie movie = db.Akbmovies.Where(m => m.MovieId == TransactionRequest.MovieId).FirstOrDefault();
			string seatsBooked = "";
			for (int i = 0; i < TransactionRequest.Seats.Length; i++)
			{
				seatsBooked += TransactionRequest.Seats[i];
				if (i + 1 < TransactionRequest.Seats.Length) seatsBooked += ", ";
			}
			string message = $"Name : {customer.FirstName}\n" +
				$"Email : {customer.Email}\n" +
				$"Seat No : {seatsBooked}\n" +
				$"No of Seats : {TransactionRequest.Seats.Length}\n" +
				$"Total Cost : {TransactionRequest.Seats.Length * movie.CostPerSeat}\n" +
				$"Movie Name : {movie.MovieName}\n" +
				$"Show Time : {movie.ShowTime}";
			AddMessageToQueue(message);
			return GetTransactionByTId(transactionId);
		}

		public List<AkbtransactionDetail> GetAllTransactions()
		{
			return db.AkbtransactionDetails.ToList();
		}

		public TransactionResponse GetTransactionByTId(int? transactionId)
		{
			TransactionResponse transactionResponse = new TransactionResponse();

			AkbtransactionDetail transactionDetails = db.AkbtransactionDetails.FirstOrDefault(transaction => transaction.TransactionId == transactionId);
			transactionResponse.TransactionTime = transactionDetails.TransactionTime;
			transactionResponse.TransactionId = transactionDetails.TransactionId;


			Akbmovie movieDetails = db.Akbmovies.FirstOrDefault(movie => movie.MovieId == transactionDetails.MovieId);
			transactionResponse.MovieId = movieDetails.MovieId;
			transactionResponse.MovieName = movieDetails.MovieName;
			transactionResponse.ReleaseDate = movieDetails.ReleaseDate;
			transactionResponse.Ratings = movieDetails.Ratings;
			transactionResponse.Genres = movieDetails.Genres;
			transactionResponse.ImageUrl = movieDetails.ImageUrl;
			transactionResponse.CostPerSeat = movieDetails.CostPerSeat;
			transactionResponse.ShowTime = movieDetails.ShowTime;
			transactionResponse.Duration = movieDetails.Duration;
			transactionResponse.AgeRating = movieDetails.AgeRating;
			transactionResponse.Language = movieDetails.Language;
			transactionResponse.MovieType = movieDetails.MovieType;

			Akbcustomer customerDetails = db.Akbcustomers.FirstOrDefault(customer => customer.CustomerId == transactionDetails.CustomerId);
			transactionResponse.CustomerId = customerDetails.CustomerId;
			transactionResponse.Email = customerDetails.Email;
			transactionResponse.FirstName = customerDetails.FirstName;

			List<AkbtransactionSeat> tranSeats = db.AkbtransactionSeats.Where(ts => ts.TransactionId == transactionId).ToList();
			transactionResponse.Seats = new string[tranSeats.Count];
			int cnt = 0;
			foreach (AkbtransactionSeat seat in tranSeats)
			{
				transactionResponse.Seats[cnt++] = seat.SeatNo;
			}

			transactionResponse.TotalCost = cnt * transactionResponse.CostPerSeat;
			return transactionResponse;
		}

		

		
	}
}
