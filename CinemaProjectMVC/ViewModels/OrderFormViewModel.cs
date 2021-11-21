using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CinemaProjectMVC.Models;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.ViewModels
{
    public class OrderFormViewModel
    {
        public IEnumerable<Screening> Screenings { get; set; }

        public int TicketsOrdered { get; set; }

        public int TotalPrice { get; set; }
    }
}