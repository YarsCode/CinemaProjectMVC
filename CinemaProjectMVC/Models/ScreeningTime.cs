using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class ScreeningTime
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Time { get; set; }

        [Required]
        public bool isAvailable { get; set; }
    }
}