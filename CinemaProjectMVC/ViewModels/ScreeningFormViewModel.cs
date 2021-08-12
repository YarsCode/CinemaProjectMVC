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
        public int Id { get; set; }

        [Required]
        public Cinema Cinema { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public List<DateTime> Times { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; }

        public ScreeningFormViewModel()
        {
            Id = 0;
        }

        public ScreeningFormViewModel(int id, Cinema cinema, Movie movie, List<DateTime> times, int availableSeats)
        {
            Id = id;
            Cinema = cinema;
            Movie = movie;
            Times = times;
            AvailableSeats = availableSeats;
        }
    }
}