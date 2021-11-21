using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CinemaProjectMVC.Models;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.ViewModels
{
    public class ScreeningFormViewModel
    {
        public int? Id { get; set; }

        public IEnumerable<Cinema> Cinemas { get; set; }

        [Required]
        [Display(Name = "Cinemas")]
        public byte? CinemaId { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

        [Required]
        [Display(Name = "Movies")]
        public byte? MovieId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        //[Required]
        //[Display(Name = "Available Seats")]
        ////[ValidNumberOfSeats]
        //public int AvailableSeats { get; set; }

        public List<Seat> Seats { get; set; }

        //[Required]
        //[Display(Name = "Available Seats")]
        //public List<Seat> AvailableSeats { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number")]
        public int Price { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Screening" : "New Screening";
            }
        }

        public ScreeningFormViewModel()
        {
            Id = 0;
        }

        public ScreeningFormViewModel(Screening screening)
        {
            Id = screening.Id;
            CinemaId = screening.CinemaId;
            MovieId = screening.MovieId;
            Date = screening.Date;
            //AvailableSeats = screening.AvailableSeats;
            Price = screening.Price;
        }
    }
}