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

        public Cinema Cinema { get; set; }

        [Required]
        public byte CinemaId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public byte MovieId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        [ValidNumberOfSeats]
        public int AvailableSeats { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number")]
        public int Price { get; set; }

        public Screening() { }

        public Screening(int id, Cinema cinema, Movie movie, byte cinemaId, byte movieId, DateTime date, int availableSeats, int price)
        {
            Id = id;
            Cinema = cinema;
            Movie = movie;
            CinemaId = cinemaId;
            MovieId = movieId;
            Date = date;
            AvailableSeats = availableSeats;
            Price = price;
        }
    }
}