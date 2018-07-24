using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_TEST_V1._0.Models
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext() : base("name=MoviesDBConnectionString")
        {
            Database.SetInitializer(new MoviesDBInitializer());
        }
        public DbSet<Movie> Movies { get; set; }
    }
}