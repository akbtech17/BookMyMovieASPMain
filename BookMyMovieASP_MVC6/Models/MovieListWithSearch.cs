namespace BookMyMovieASP_MVC6.Models
{
	public class MovieListWithSearch
	{
		public List<Akbmovie> movies { get; set; }
		public string filterString { get; set; }
	}
}
