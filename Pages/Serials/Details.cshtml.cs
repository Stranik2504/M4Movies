using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using M4Movies.Data;
using M4Movies.Model;

namespace M4Movies.Pages.Serials
{
    public class DetailsModel : PageModel
    {
        private readonly M4Movies.Data.M4MoviesContext _context;

        public DetailsModel(M4Movies.Data.M4MoviesContext context)
        {
            _context = context;
        }

      public Serial Serial { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serial == null)
            {
                return NotFound();
            }

            var serial = await _context.Serial.FirstOrDefaultAsync(m => m.Id == id);
            if (serial == null)
            {
                return NotFound();
            }
            else 
            {
                Serial = serial;
            }
            return Page();
        }
    }
}
