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
            var screenings = _context.Screenings.Where(s => s.CinemaId == id).ToList();
            var cinemas = _context.Cinemas.ToList();
            var movies = _context.Movies.ToList();

            var viewModel = new ScreeningFormViewModel
            {
                Cinemas = cinemas,
                Movies = movies,
                Date = DateTime.Now
            };

            return View("OrderForm", screenings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Screening screening)
        {
            var screeningInDb = _context.Screenings.Single(s => s.Id == screening.Id);

            return RedirectToAction("", "");
        }
    }
}