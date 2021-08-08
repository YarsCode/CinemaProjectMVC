using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Rating
    {
        public byte Id { get; set; }

        public int Stars { get; set; }
    }
}