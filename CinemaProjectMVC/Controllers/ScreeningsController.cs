using System;
using System.Collections.Generic;
using CinemaProjectMVC.Models;
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
            var screenings = _context.Screenings.ToList();

            return View(screenings);
        }
    }
}