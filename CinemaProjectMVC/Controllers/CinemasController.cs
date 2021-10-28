using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaProjectMVC.Models;
using CinemaProjectMVC.ViewModels;

namespace CinemaProjectMVC.Controllers
{
    public class CinemasController : Controller
    {
        private ApplicationDbContext _context;

        public CinemasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cinemas
        public ActionResult Index()
        {
            var cinemas = _context.Cinemas.Include(c => c.OpeningHour).Include(c => c.ClosingHour).ToList();

            return View(cinemas);
        }

        public ActionResult Details(int id)
        {
            var cinema = _context.Cinemas.Include(c => c.OpeningHour).Include(c => c.ClosingHour).SingleOrDefault(m => m.Id == id);

            if (cinema == null)
                return HttpNotFound();

            return View(cinema);
        }

        public ActionResult New()
        {
            var openingHours = _context.OpeningHours.ToList();
            var closingHours = _context.ClosingHours.ToList();

            openingHours.ForEach(i => i.Hour = i.Time.ToShortTimeString());
            closingHours.ForEach(i => i.Hour = i.Time.ToShortTimeString());

            var viewModel = new CinemaFormViewModel
            {
                OpeningHours = openingHours,
                ClosingHours = closingHours
            };
            return View("CinemaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CinemaFormViewModel(cinema)
                {
                    OpeningHours = _context.OpeningHours.ToList(),
                    ClosingHours = _context.ClosingHours.ToList()
                };
                return View("CinemaForm", viewModel);
            }            

            if (cinema.Id == 0)
            {
                cinema.Seats = SetSeats(cinema);
                _context.Cinemas.Add(cinema);
            }
            else
            {
                var cinemaInDb = _context.Cinemas.Include(c => c.Seats).Single(c => c.Id == cinema.Id);
                cinemaInDb.Seats.Clear();

                cinemaInDb.Name = cinema.Name;
                cinemaInDb.Address = cinema.Address;
                cinemaInDb.NumberOfSeats = cinema.NumberOfSeats;
                cinemaInDb.Seats = SetSeats(cinemaInDb);
                cinemaInDb.OpeningHourId = cinema.OpeningHourId;
                cinemaInDb.ClosingHourId = cinema.ClosingHourId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Cinemas");
        }

        public ActionResult Edit(int id)
        {
            var cinema = _context.Cinemas.SingleOrDefault(c => c.Id == id);

            if (cinema == null)
                return HttpNotFound();

            var openingHours = _context.OpeningHours.ToList();
            var closingHours = _context.ClosingHours.ToList();

            openingHours.ForEach(i => i.Hour = i.Time.ToShortTimeString());
            closingHours.ForEach(i => i.Hour = i.Time.ToShortTimeString());


            var viewModel = new CinemaFormViewModel(cinema)
            {
                OpeningHours = openingHours,
                ClosingHours = closingHours
            };

            return View("CinemaForm", viewModel);
        }

        
        public ActionResult Delete(int id)
        {
            var cinemaInDb = _context.Cinemas.SingleOrDefault(c => c.Id == id);

            //cinemaInDb.TotalSeats = new List<Seat>();

            //foreach (var seat in cinemaInDb.TotalSeats)
            //{
            //    _context.Seats.Remove(seat);
            //    _context.SaveChanges();
            //};

            if (cinemaInDb == null)
                return HttpNotFound();

            _context.Cinemas.Remove(cinemaInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Cinemas");
        }

        public List<Seat> SetSeats(Cinema cinema)
        {
            List<Seat> Seats = new List<Seat>();
            char rowLetter = 'A';
            int seatNumInRow = 1;
            for (int i = 1; i <= cinema.NumberOfSeats; i++, seatNumInRow++)
            {
                Seats.Add(new Seat
                {
                    Id = i - 1,
                    CinemaId = cinema.Id,
                    Cinema = cinema,
                    Location = "" + rowLetter + seatNumInRow,
                    isAvailable = true
                });
                if ((i % 10) == 0)
                {
                    rowLetter++;
                    seatNumInRow = 0;
                }
            };
            return Seats;
        }

        //public List<int> SetSeats(int totalSeatsNumber)
        //{
        //    List<int> totalSeats = new List<int>();
        //    char rowLetter = 'A';
        //    int seatNumInRow = 1;
        //    for (int i = 1; i <= totalSeatsNumber; i++, seatNumInRow++)
        //    {
        //        totalSeats.Add(seatNumInRow);
        //        if ((i % 10) == 0)
        //        {
        //            rowLetter++;
        //            seatNumInRow = 0;
        //        }
        //    }

        //    return totalSeats;
        //}
    }
}