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
            var closingHours= _context.ClosingHours.ToList();

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
                _context.Cinemas.Add(cinema);
            }
            else
            {
                var cinemaInDb = _context.Cinemas.Single(c => c.Id == cinema.Id);

                cinemaInDb.Name = cinema.Name;
                cinemaInDb.Address = cinema.Address;
                cinemaInDb.TotalSeats = cinema.TotalSeats;
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

            if (cinemaInDb == null)
                return HttpNotFound();

            _context.Cinemas.Remove(cinemaInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Cinemas");
        }
    }
}