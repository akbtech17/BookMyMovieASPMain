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

        public bool EditMovie(Akbmovie new_data)
        {
            try
            {
                var old_data = db.Akbmovies.Where(m => m.MovieId == new_data.MovieId).FirstOrDefault();
                if (old_data != null)
                {
                    old_data.MovieName = new_data.MovieName;
                    old_data.ReleaseDate = new_data.ReleaseDate;
                    old_data.Ratings = new_data.Ratings;
                    old_data.Genres = new_data.Genres;
                    old_data.ImageUrl = new_data.ImageUrl;
                    old_data.CostPerSeat = new_data.CostPerSeat;
                    old_data.ShowTime = new_data.ShowTime;
                    old_data.Duration = new_data.Duration;
                    old_data.AgeRating = new_data.AgeRating;
                    old_data.Language = new_data.Language;
                    old_data.MovieType = new_data.MovieType;
                }
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
