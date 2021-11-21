using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int? CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public int? ScreeningId { get; set; }

        public Screening Screening{ get; set; }

        //public byte ScreeningId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public bool isAvailable { get; set; }

        public Seat()
        {
            isAvailable = true;
        }
    }
}