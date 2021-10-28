using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaProjectMVC.Models;

namespace CinemaProjectMVC.ViewModels
{
    public class ScreeningsListViewModel
    {
        public List<Screening> Screenings { get; set; }
    }
}