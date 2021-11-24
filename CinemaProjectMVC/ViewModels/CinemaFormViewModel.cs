using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CinemaProjectMVC.Models;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.ViewModels
{
    public class CinemaFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid number")]
        [Display(Name = "Total Seats")]
        public int NumberOfSeats { get; set; }

        public IEnumerable<OpeningHour> OpeningHours { get; set; }

        [Required]
        [Display(Name = "Opens At")]
        public byte? OpeningHourId { get; set; }

        public IEnumerable<ClosingHour> ClosingHours { get; set; }

        [Required]
        [Display(Name = "Closes At")]
        public byte? ClosingHourId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Cinema" : "New Cinema";
            }
        }

        public CinemaFormViewModel() 
        {
            Id = 0;
        }

        public CinemaFormViewModel(Cinema cinema)
        {
            Id = cinema.Id;
            Name = cinema.Name;
            Address = cinema.Address;
            NumberOfSeats = cinema.NumberOfSeats;
            OpeningHourId = cinema.OpeningHourId;
            ClosingHourId = cinema.ClosingHourId;            
        }
    }
}