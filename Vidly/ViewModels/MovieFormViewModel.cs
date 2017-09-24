using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please fill the Name field")]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Number in Stock must be between 1 and 20")]
        [Required]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movies" : "New Movies";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movies movies)
        {
            Id = movies.Id;
            Name = movies.Name;
            ReleaseDate = movies.ReleaseDate;
            NumberInStock = movies.NumberInStock;
            GenreId = movies.GenreId;

        }
    }
   
}