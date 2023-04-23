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
    public class DeleteModel : PageModel
    {
        private readonly M4Movies.Data.M4MoviesContext _context;

        public DeleteModel(M4Movies.Data.M4MoviesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Serial == null)
            {
                return NotFound();
            }
            var serial = await _context.Serial.FindAsync(id);

            if (serial != null)
            {
                Serial = serial;
                _context.Serial.Remove(Serial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
