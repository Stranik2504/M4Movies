using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using M4Movies.Data;
using M4Movies.Model;

namespace M4Movies.Pages.Serials
{
    public class CreateModel : PageModel
    {
        private readonly M4Movies.Data.M4MoviesContext _context;

        public CreateModel(M4Movies.Data.M4MoviesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Serial Serial { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Serial == null || Serial == null)
            {
                return Page();
            }

            _context.Serial.Add(Serial);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
