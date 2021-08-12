using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Screening
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

        public Screening() { }

        public Screening(int id, Cinema cinema, Movie movie, List<DateTime> times, int availableSeats)
        {
            Id = id;
            Cinema = cinema;
            Movie = movie;
            Times = times;
            AvailableSeats = availableSeats;
        }
    }
}