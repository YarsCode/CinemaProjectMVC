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
        public List<Movie> Movies;
        //public int? Id { get; set; }

        //public IEnumerable<Genre> Genres { get; set; }

        //[Required]
        //[StringLength(255)]
        //public string Name { get; set; }

        //[Required]
        //[Display(Name = "Genre")]
        //public byte? GenreId { get; set; }

        //[Required]
        //[Display(Name = "Release Date")]
        //public DateTime ReleaseDate { get; set; }

        //[Required]
        //[Display(Name = "Duration")]
        //public int DurationInMinutes { get; set; }

        //public IEnumerable<Rating> Ratings { get; set; }

        //public MoviesViewModel(Movie movie)
        //{
        //    Id = movie.Id;
        //    Name = movie.Name;
        //    ReleaseDate = movie.ReleaseDate;
        //    DurationInMinutes = movie.DurationInMinutes;
        //    GenreId = movie.GenreId;
        //}
    }
}