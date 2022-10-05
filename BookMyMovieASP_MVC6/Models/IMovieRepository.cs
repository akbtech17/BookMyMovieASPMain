namespace BookMyMovieASP_MVC6.Models
{
    public interface IMovieRepository
    {
        List<Akbmovie> GetMovies();
        Akbmovie GetMovieById(int id);

        void AddMovie(Akbmovie movie);
    }
}
