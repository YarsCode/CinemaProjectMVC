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
        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; }

        [Required]
        [Display(Name = "Screening Times")]
        public ScreeningTime ScreeningTime { get; set; }
    }
}