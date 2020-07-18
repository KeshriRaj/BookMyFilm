using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DTO
{
    public class ReviewsDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Reviews { get; set; }
    }
}
