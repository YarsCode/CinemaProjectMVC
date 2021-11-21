using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Screening Screening { get; set; }

        [Required]
        public int ScreeningId { get; set; }

        [Required]
        public int[] ChosenSeats { get; set; }

        [Required]
        public int TotalPrice { get; set; }
    }
}