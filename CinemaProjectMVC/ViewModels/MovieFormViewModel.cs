using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CinemaProjectMVC.Models;

namespace CinemaProjectMVC.ViewModels
{
    public class MovieFormViewModel
    {
        //public List<Movie> Movies;
        public int? Id { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Duration (Minutes)")]
        public int DurationInMinutes { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public byte? RatingId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DurationInMinutes = movie.DurationInMinutes;
            GenreId = movie.GenreId;
            RatingId= movie.RatingId;
        }
    }
}