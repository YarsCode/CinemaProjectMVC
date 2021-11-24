using System;
using System.Collections.Generic;
using CinemaProjectMVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.Entity;
using CinemaProjectMVC.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaProjectMVC.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Orders
        public ActionResult Index()
        {
            var cinemas = _context.Cinemas.ToList();

            var viewModel = new ChooseCinemasViewModel
            {
                Cinemas = cinemas
            };

            return View(viewModel);
        }

        public ActionResult AvailableScreenings(int id)
        {
            var screenings = _context.Screenings.Include(s => s.Cinema).Where(s => s.CinemaId == id).ToList();
            var cinemas = _context.Cinemas.ToList();
            var movies = _context.Movies.ToList();

            var viewModel = new OrderFormViewModel
            {
                Screenings = screenings
            };

            return View("OrderForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Order order)
        {
            var screeningInDb = _context.Screenings.Include(s => s.Seats).Single(s => s.Id == order.ScreeningId);

            foreach (var availableSeat in order.ChosenSeats)
            {
                var takenSeat = _context.Seats.Single(s => s.ScreeningId == screeningInDb.Id && s.Id == availableSeat);

                takenSeat.isAvailable = false;
            }

            order.Screening = screeningInDb;
            order.Screening.Cinema = _context.Cinemas.Single(c => c.Id == order.Screening.CinemaId);
            order.Screening.Movie = _context.Movies.Single(m => m.Id == order.Screening.MovieId);

            _context.SaveChanges();

            return PartialView("OrderComplete", order);
        }

        [HttpPost]
        public ActionResult SeatSelection(Screening screening)
        {
            var screeningInDb = _context.Screenings.Include(s => s.Seats).Single(s => s.Id == screening.Id);

            return View(screeningInDb);
        }
    }
}