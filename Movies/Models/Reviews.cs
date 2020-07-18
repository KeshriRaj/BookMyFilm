using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string HonestReviews { get; set; }

        public Movie Movies { get; set; }
        public int MoviesId { get; internal set; }
    }
}
