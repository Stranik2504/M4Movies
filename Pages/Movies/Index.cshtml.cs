using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M4Movies.Data;
using M4Movies.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace M4Movies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly M4Movies.Data.M4MoviesContext _context;

        public IndexModel(M4Movies.Data.M4MoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public SelectList Ratings { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieRating { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                var genreList = _context.Movie.Select(x => x.Genre).OrderBy(x => x);
                var moives = _context.Movie.OrderBy(x => x.ReleaseDate).OrderByDescending(x => x.Title).Select(x => x);
                var ratings = _context.Movie.OrderBy(x => x.Rating).Select(x => x.Rating);

                if (!string.IsNullOrEmpty(SearchString))
                {
                    moives = moives.Where(x => x.Title.ToLower().Contains(SearchString.ToLower()));
                }

                if (!string.IsNullOrEmpty(MovieGenre))
                {
                    moives = moives.Where(x => x.Genre == MovieGenre);
                }

                if (!string.IsNullOrEmpty(MovieRating))
                {
                    moives = moives.Where(x => x.Rating == MovieRating);
                }

                Genres = new SelectList(await genreList.Distinct().ToListAsync());
                Ratings = new SelectList(await ratings.Distinct().ToListAsync());
                Movie = await moives.ToListAsync();
            }
        }
    }
}
