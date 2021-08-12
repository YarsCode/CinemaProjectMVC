using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaProjectMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int DurationInMinutes { get; set; }

        public Rating Rating { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public byte RatingId { get; set; }

        public Movie() { }
        public Movie(int id, string name, Genre genre, byte genreId, DateTime releaseDate, int durationInMinutes, Rating rating, byte ratingId)
        {
            Id = id;
            Name = name;
            Genre = genre;
            GenreId = genreId;
            ReleaseDate = releaseDate;
            DurationInMinutes = durationInMinutes;
            Rating = rating;
            RatingId = ratingId;
        }
    }
}