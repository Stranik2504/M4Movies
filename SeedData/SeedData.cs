using Microsoft.EntityFrameworkCore;
using M4Movies.Data;

namespace M4Movies.SeedData
{
    public static class SeedData
    {
        public static void Initilize(IServiceProvider serviceProvider)
        {
            using (var context = new M4MoviesContext(serviceProvider.GetRequiredService<DbContextOptions<M4MoviesContext>>()))
            {
                if (context == null || context.Movie == null)
                    throw new ArgumentNullException("Null");

                if (context.Movie.Any())
                    return;

                context.Movie.AddRange(
                    new Model.Movie
                    {
                        Title = "Avatar",
                        ReleaseDate = DateTime.Parse("17.12.2009"),
                        Genre = "Fantasy",
                        Price = 10.50M,
                        Rating = "R"
                    },
                    new Model.Movie
                    {
                        Title = "Avatar 2",
                        ReleaseDate = DateTime.Parse("8.7.2010"),
                        Genre = "Fantasy",
                        Price = 100.48M,
                        Rating = "G"
                    },
                    new Model.Movie
                    {
                        Title = "Instrestellar",
                        ReleaseDate = DateTime.Parse("5.12.2011"),
                        Genre = "Horror",
                        Price = 11.55M,
                        Rating = "PG"
                    });
                context.SaveChanges();
            }
        }
    }
}
