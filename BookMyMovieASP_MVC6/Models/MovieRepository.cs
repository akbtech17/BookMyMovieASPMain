namespace BookMyMovieASP_MVC6.Models
{
    public class MovieRepository: IMovieRepository
    {
        BookMyMovieContext db = new BookMyMovieContext();
        public Movie GetMovieById(int id)
        {
            var data = db.Movies.Where(movie => movie.MovieId == id).FirstOrDefault();
            return data;
        }

        public List<Movie> GetMovies()
        {
            var data = db.Movies.ToList();
            return data;
        }
    }
}
