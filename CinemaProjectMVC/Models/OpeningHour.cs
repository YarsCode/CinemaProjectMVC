using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class OpeningHour
    {
        public byte Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [NotMapped]
        public string Hour { get; set; }
    }
}