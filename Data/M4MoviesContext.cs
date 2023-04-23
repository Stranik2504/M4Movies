using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using M4Movies.Model;

namespace M4Movies.Data
{
    public class M4MoviesContext : DbContext
    {
        public M4MoviesContext (DbContextOptions<M4MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<M4Movies.Model.Movie> Movie { get; set; } = default!;

        public DbSet<M4Movies.Model.Serial>? Serial { get; set; }
    }
}
