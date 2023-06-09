﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly M4Movies.Data.M4MoviesContext _context;

        public IndexModel(M4Movies.Data.M4MoviesContext context)
        {
            _context = context;
        }

        public IList<Serial> Serial { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Serial != null)
            {
                Serial = await _context.Serial.ToListAsync();
            }
        }
    }
}
