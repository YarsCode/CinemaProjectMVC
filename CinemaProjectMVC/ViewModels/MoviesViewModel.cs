using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CinemaProjectMVC.Models;

namespace CinemaProjectMVC.ViewModels
{
    public class MoviesViewModel
    {
        public int? Id { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}