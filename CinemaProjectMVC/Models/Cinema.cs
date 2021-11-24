using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number")]
        [Display(Name = "Total Number of Seats")]
        public int NumberOfSeats { get; set; }

        //public List<Seat> Seats { get; set; }

        public OpeningHour OpeningHour { get; set; }

        [Required]
        [Display(Name = "Opens At")]
        public byte OpeningHourId { get; set; }

        public ClosingHour ClosingHour { get; set; }

        [Required]
        [Display(Name = "Closes At")]
        public byte ClosingHourId { get; set; }
    }
}