using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using CinemaProjectMVC.Models;
using CinemaProjectMVC.ViewModels;

namespace CinemaProjectMVC.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        static Genre genre1 = new Genre
        {
            Id = 1,
            Name = "Genre 1"
        };
        static Genre genre2 = new Genre
        {
            Id = 2,
            Name = "Genre 2"
        };
        static Rating rating1 = new Rating
        {
            Id = 1,
            Stars = 5
        };
        static Rating rating2 = new Rating
        {
            Id = 2,
            Stars = 4
        };
        IEnumerable<Genre> genres = new List<Genre>() { genre1, genre2 };
        IEnumerable<Rating> ratings = new List<Rating>() { rating1, rating2 };
        /*private List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "Movie 1",
                Genre = genre1,
                GenreId = genre1.Id,
                ReleaseDate = DateTime.Now,
                DurationInMinutes = 90,
                Rating = rating1
            },
            new Movie
            {
                Id = 2,
                Name = "Movie 2",
                Genre = genre1,
                GenreId = genre1.Id,
                ReleaseDate = DateTime.Now,
                DurationInMinutes = 70,
                Rating = rating1
            }
        };*/
        //Movie movie = new Movie
        //{
        //    Id = 1,
        //    Name = "Movie 1",
        //    Genre = genre1,
        //    GenreId = genre1.Id,
        //    ReleaseDate = DateTime.Now,
        //    DurationInMinutes = 90,
        //    Rating = rating1
        //};

        private List<Movie> movies = new List<Movie>()
        {
            new Movie(1, "Movie1", genre1, 1, DateTime.Now, 90, rating1),
            new Movie(2, "Movie2", genre2, 2, DateTime.Now, 70, rating2)
        };

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var viewModel = new MoviesViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Include(m => m.Rating).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            //if (id >= movies.Count)
            //    return HttpNotFound();
            //var movie = movies[id];
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }
    }
}