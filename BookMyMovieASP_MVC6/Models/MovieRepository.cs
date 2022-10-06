using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BookMyMovieASP_MVC6.Models
{
    public class MovieRepository: IMovieRepository
    {
        Db01Context db = new Db01Context();

        public void AddMovie(Akbmovie movie)
        {
            movie.MovieId = null;
            db.Add(movie);
            db.SaveChanges();
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                var movie = db.Akbmovies.Where(m => m.MovieId == id).FirstOrDefault();
                db.Akbmovies.Remove(movie);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

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
