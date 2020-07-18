using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Request
{
    public class UpdateMoviesRequest:AddMoviesRequest
    {
        public int MovieId { get; set; }
       
    }
}
