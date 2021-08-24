using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Housefull",
                        ReleaseDate = DateTime.Parse("2014-7-11"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 2.99M
                    },

                    new Movie
                    {
                        Title = "Stree ",
                        ReleaseDate = DateTime.Parse("2018-8-10"),
                        Genre = "Horror",
                        Rating = "R",
                        Price = 1.99M
                    },

                    new Movie
                    {
                        Title = "Housefull 2",
                        ReleaseDate = DateTime.Parse("2017-7-10"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 1.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}