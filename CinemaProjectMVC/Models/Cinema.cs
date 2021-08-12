﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }

        public OpeningHour OpeningHour { get; set; }

        [Required]
        [Display(Name = "Opens At")]
        public byte OpeningHourId { get; set; }

        public ClosingHour ClosingHour { get; set; }

        [Required]
        [Display(Name = "Closes At")]
        public byte ClosingHourId { get; set; }

        public Cinema() { }

        public Cinema(int id, string name, string address, int totalSeats, OpeningHour openingHour, ClosingHour closingHour, byte openingHourId, byte closingHourId/*int availableSeats, ScreeningTime screeningTime*/)
        {
            Id = id;
            Name = name;
            Address = address;
            TotalSeats = totalSeats;
            OpeningHour = openingHour;
            OpeningHourId = openingHourId;
            ClosingHour = closingHour;
            ClosingHourId = closingHourId;
        }
    }
}