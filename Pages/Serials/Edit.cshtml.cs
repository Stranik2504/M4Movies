using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M4Movies.Data;
using M4Movies.Model;

namespace M4Movies.Pages.Serials
{
    public class EditModel : PageModel
    {
        private readonly M4Movies.Data.M4MoviesContext _context;

        public EditModel(M4Movies.Data.M4MoviesContext context)
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

            var serial =  await _context.Serial.FirstOrDefaultAsync(m => m.Id == id);
            if (serial == null)
            {
                return NotFound();
            }
            Serial = serial;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Serial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialExists(Serial.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SerialExists(int id)
        {
          return (_context.Serial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
