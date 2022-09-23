namespace BookMyMovieASP_MVC6.Models
{
    public class MovieRepository: IMovieRepository
    {
        BookMyMovieContext db = new BookMyMovieContext();
        public Movie GetMovieById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            var data = db.Movies.ToList();
            if (data == null)
            {
                Console.WriteLine("Null is encountered");
            
            }
            return data;
        }
    }
}
