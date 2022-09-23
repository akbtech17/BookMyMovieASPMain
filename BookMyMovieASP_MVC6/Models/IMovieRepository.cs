namespace BookMyMovieASP_MVC6.Models
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
    }
}
