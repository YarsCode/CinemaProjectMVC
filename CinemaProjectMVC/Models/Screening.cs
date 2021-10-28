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
        public int AvailableSeatsNumber { get; set; }

        //public List<Seat> AvailableSeats { get; set; }

        [Required]
        public byte AvailableSeatsId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number")]
        public int Price { get; set; }

        public Screening() { }

        //public Screening(int availableSeatsNumber)
        //{
        //    AvailableSeats = new List<Seat>(new Seat[availableSeatsNumber]);
        //}

        public Screening(int id, Cinema cinema, Movie movie, byte cinemaId, byte movieId, DateTime date, int availableSeatsNumber, byte availableSeatsId, int price)
        {
            Id = id;
            Cinema = cinema;
            Movie = movie;
            CinemaId = cinemaId;
            MovieId = movieId;
            Date = date;
            AvailableSeatsNumber = availableSeatsNumber;
            AvailableSeatsId = availableSeatsId;
            //AvailableSeats = setAvailableSeats(availableSeatsNumber);
            //AvailableSeats = new List<Seat>(new Seat[availableSeatsNumber]);
            //AvailableSeats = availableSeats;
            Price = price;
        }

        //public List<Seat> setAvailableSeats(int numberOfSeats)
        //{
        //    List<Seat> Seats = new List<Seat>();
        //    char rowLetter = 'A';
        //    int seatNumInRow = 1;
        //    for (int i = 1; i <= numberOfSeats; i++, seatNumInRow++)
        //    {
        //        Seats.Add(new Seat
        //        {
        //            Id = i - 1,
        //            CinemaId = this.CinemaId,
        //            Cinema = this.Cinema,
        //            Location = "" + rowLetter + seatNumInRow,
        //            isAvailable = true
        //        });
        //        if ((i % 10) == 0)
        //        {
        //            rowLetter++;
        //            seatNumInRow = 0;
        //        }
        //    }

        //    return Seats;
        //}
    }
}