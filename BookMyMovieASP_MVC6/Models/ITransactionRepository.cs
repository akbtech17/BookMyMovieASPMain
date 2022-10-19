namespace BookMyMovieASP_MVC6.Models
{
	public interface ITransactionRepository
	{
		public List<AkbtransactionDetail> GetAllTransactions();
		public TransactionResponse GetTransactionByTId (int? transactionId);
		public TransactionResponse CreateTransaction(TransactionRequest transactionRequest);
		public void AddMessageToQueue(string message);
	}
}
