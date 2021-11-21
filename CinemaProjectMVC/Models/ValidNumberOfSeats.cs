using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using CinemaProjectMVC.Models;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class ValidNumberOfSeats : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public ValidNumberOfSeats()
        {
            _context = new ApplicationDbContext();
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var screening = (Screening)validationContext.ObjectInstance;
        //    var cinema = _context.Cinemas.Include(c => c.Seats).SingleOrDefault(c => c.Id == screening.CinemaId);


        //    //if (customer.MembershipTypeId == MembershipType.Unknown ||
        //    //    customer.MembershipTypeId == MembershipType.PayAsYouGo)
        //    //    return ValidationResult.Success;
        //    //if (customer.Birthdate == null)
        //    //    return new ValidationResult("Birthdate is required.");

        //    //var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

        //    //TODO ===> Fix this function's logic
        //    var numberOfSeats = cinema.Seats.Where(s => s.isAvailable).ToList().Count();

        //    return (screening.AvailableSeats <= numberOfSeats)
        //        ? ValidationResult.Success
        //        : new ValidationResult("Your chosen cinema has only " + cinema.NumberOfSeats + " seats, please select a valid number.");
        //}
    }
}