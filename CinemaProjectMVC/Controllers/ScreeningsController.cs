using System;
using System.Collections.Generic;
using CinemaProjectMVC.Models;
using System.Data.Entity;
using CinemaProjectMVC.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaProjectMVC.Controllers
{
    public class ScreeningsController : Controller
    {
        private ApplicationDbContext _context;

        public ScreeningsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Screenings
        public ActionResult Index()
        {
            var screenings = _context.Screenings.Include(s => s.Cinema).Include(s => s.Movie).ToList();

            return View(screenings);
        }

        public ActionResult New()
        {
            //var times = _context.Cinemas.

            //var availableSeats = 

            var cinemas = _context.Cinemas.ToList();
            var movies = _context.Movies.ToList();

            var viewModel = new ScreeningFormViewModel
            {
                Cinemas = cinemas,
                Movies = movies,
                Date = DateTime.Now
            };
            return View("ScreeningForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var screening = _context.Screenings.SingleOrDefault(s => s.Id == id);            
            //var times = chosenCinema.OpeningHour

            if (screening == null)
                return HttpNotFound();

            var viewModel = new ScreeningFormViewModel(screening)
            {
                Cinemas = _context.Cinemas.ToList(),
                Movies = _context.Movies.ToList(),
                //Times = _context.Cinemas.ToList()
            };

            return View("ScreeningForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Screening screening)
        {
            //var test = _context.Cinemas.Where(c => screening.CinemaId == c.Id).ToList();
            //screening.Cinema = _context.Cinemas.Single(c => c.Id == screening.CinemaId);
            //screening.Movie = _context.Movies.Single(m => m.Id == screening.MovieId);
            var cinema = _context.Cinemas.Single(c => c.Id == screening.CinemaId);
            var movie = _context.Movies.Single(m => m.Id == screening.MovieId);
            var isValidSeatNumber = screening.AvailableSeats <= cinema.TotalSeats;
            var newScreening = new Screening(screening.Id, cinema, movie, screening.CinemaId, screening.MovieId, screening.Date, screening.AvailableSeats, screening.Price);

            if (!ModelState.IsValid || !isValidSeatNumber)
            {
                //var openingHour = screening.Cinema.OpeningHour;
                //var closingHour = screening.Cinema.ClosingHour;
                

                var viewModel = new ScreeningFormViewModel(newScreening)
                {
                    Cinemas = _context.Cinemas.ToList(),
                    Movies = _context.Movies.ToList(),
                };
                return View("ScreeningForm", viewModel);
            }
            if (screening.Id == 0)
            {
                _context.Screenings.Add(newScreening);
            }
            else
            {
                var screeningInDb = _context.Screenings.Single(s => s.Id == newScreening.Id);

                screeningInDb.Cinema = newScreening.Cinema;
                screeningInDb.Movie = newScreening.Movie;
                screeningInDb.Date = newScreening.Date;
                screeningInDb.AvailableSeats = newScreening.AvailableSeats;
                screeningInDb.Price = newScreening.Price;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Screenings");
        }

        public ActionResult Delete(int id)
        {
            var screeningInDb = _context.Screenings.SingleOrDefault(c => c.Id == id);

            if (screeningInDb == null)
                return HttpNotFound();

            _context.Screenings.Remove(screeningInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Screenings");
        }        
    }
}