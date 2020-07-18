using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MoviesName { get; set; }
        public Languages Language { get; set; }
        public int LanguageId { get; internal set; }
        //public string LanguageName { get; internal set; }
    }
}
