using System;
using System.Collections.Generic;
using CinemaProjectMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.ViewModels
{
    public class SeatSelectionViewModel
    {
        [Required]
        public List<Seat> Seats { get; set; }

        [Required]
        public int NumberOfTicketsOrdered { get; set; }
    }
}