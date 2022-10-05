namespace BookMyMovieASP_MVC6.Models
{
    public class MovieRepository: IMovieRepository
    {
        Db01Context db = new Db01Context();
        public Akbmovie GetMovieById(int id)
        {
            var data = db.Akbmovies.Where(movie => movie.MovieId == id).FirstOrDefault();
            return data;
        }

        public List<Akbmovie> GetMovies()
        {
            var data = db.Akbmovies.ToList();
            return data;
        }
    }
}
