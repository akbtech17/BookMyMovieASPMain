namespace BookMyMovieASP_MVC6.Models
{
    public interface IMovieRepository
    {
        List<Akbmovie> GetMovies();
        Akbmovie GetMovieById(int id);

        void AddMovie(Akbmovie movie);

        bool DeleteMovie(int id);

        bool EditMovie(Akbmovie movieDetails);

        List<AkbseatMap> GetSeatMap(int movieId);
        
    }
}
