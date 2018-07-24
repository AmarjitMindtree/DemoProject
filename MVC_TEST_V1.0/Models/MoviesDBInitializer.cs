using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_TEST_V1._0.Models
{
    public class MoviesDBInitializer : DropCreateDatabaseIfModelChanges<MovieDBContext>
    {
        protected override void Seed( MovieDBContext context)
        {
            IList<Movie> defaultMovies = new List<Movie>()
            {
                new Movie { Title="3 Idiots", Genre="Funny", ReleaseDate=DateTime.Parse("7/18/2018"), Price=4.50M},
                new Movie { Title="Lagan", Genre="Entertaining", ReleaseDate=DateTime.Parse("6/17/2017"), Price=5.50M},
                new Movie { Title="3 Tare Zamin Par", Genre="Informative", ReleaseDate=DateTime.Parse("5/16/2016"), Price=6.50M}
            };

            context.Movies.AddRange(defaultMovies);
            base.Seed(context);
        }
    }
}