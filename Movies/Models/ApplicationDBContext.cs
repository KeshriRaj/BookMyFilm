using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Languages> LanguagesTable { get; set; }
        public DbSet<Movie> MoviesTable { get; set; }

        public DbSet<Reviews> ReviewsTable { get; set; }

    }
}
