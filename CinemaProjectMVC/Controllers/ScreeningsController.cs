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
            var screening = _context.Screenings.Include(s => s.Cinema).Include(s => s.Movie).ToList().SingleOrDefault(s => s.Id == id);

            if (screening == null)
                return HttpNotFound();

            var viewModel = new ScreeningFormViewModel(screening)
            {
                Cinemas = _context.Cinemas.ToList(),
                Movies = _context.Movies.ToList(),
            };

            return View("ScreeningForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Screening screening)
        {
            var cinema = _context.Cinemas.Single(c => c.Id == screening.CinemaId);
            var movie = _context.Movies.Single(m => m.Id == screening.MovieId);


            //List<Seat> Seats = new List<Seat>();
            //char rowLetter = 'A';
            //int seatNumInRow = 1;
            //for (int i = 1; i <= screening.AvailableSeatsNumber; i++, seatNumInRow++)
            //{
            //    Seats.Add(new Seat
            //    {
            //        Id = i - 1,
            //        CinemaId = screening.CinemaId,
            //        Cinema = cinema,
            //        Location = "" + rowLetter + seatNumInRow,
            //        isAvailable = true
            //    });
            //    if ((i % 10) == 0)
            //    {
            //        rowLetter++;
            //        seatNumInRow = 0;
            //    }
            //}

            //screening.AvailableSeats = Seats;
            var isValidSeatNumber = screening.AvailableSeatsNumber <= cinema.NumberOfSeats;
            var newScreening = new Screening(screening.Id, cinema, movie, screening.CinemaId, screening.MovieId, screening.Date, screening.AvailableSeatsNumber, screening.AvailableSeatsId, screening.Price);
            //var test = newScreening.AvailableSeats;
            //TODO => Check why i'm getting a 'primary key' error when creating seats
            if (!ModelState.IsValid || !isValidSeatNumber)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
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
                screeningInDb.AvailableSeatsNumber = newScreening.AvailableSeatsNumber;
                //screeningInDb.AvailableSeats = newScreening.AvailableSeats;
                screeningInDb.Price = newScreening.Price;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
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