using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Request
{
    public class AddReviewRequest
    {
        public string Reviews { get; set; }
        public int MoviesId { get; set; }
    }
}
