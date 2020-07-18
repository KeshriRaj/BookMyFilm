using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Request
{
    public class AddMoviesRequest
    {
        public int LanguageID { get; set; }
        public string MoviesName { get; set; }
    }
}
