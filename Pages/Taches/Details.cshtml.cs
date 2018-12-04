using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Taches.Models;

namespace Gprojet.Pages.Taches
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DetailsModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public Tache Tache { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tache = await _context.taches
                .Include(t => t.Jalons)
                .Include(t => t.Resps).FirstOrDefaultAsync(m => m.TacheID == id);

            if (Tache == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
