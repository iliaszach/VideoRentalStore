using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        
        public IEnumerable<Genre> Genres { get; set; }

        public  Movie Movie { get; set; }



        public string Title
        {
            get
            {
                return (Movie != null && Movie.Id != 0)?
                    "Edit Movie":"New Movie";
            }
        }
    }
}