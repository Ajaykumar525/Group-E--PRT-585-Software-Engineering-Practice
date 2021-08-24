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
                        Title = "Hera pheri",
                        ReleaseDate = DateTime.Parse("2021-8-20"),
                        Genre = "comedy",
                        Rating = "R",
                        Price = 8.00M
                    },

                    new Movie
                    {
                        Title = "Dhamaal",
                        ReleaseDate = DateTime.Parse("2021-8-27"),
                        Genre = "comedy",
                        Rating = "R",
                        Price = 9.00M
                    },
                    new Movie
                    {
                        Title = "Raabta",
                        ReleaseDate = DateTime.Parse("2021-8-12"),
                        Genre = "Romantic",
                        Rating = "R",
                        Price = 10.00M
                    }


                );
                context.SaveChanges();
            }
        }
    }
}