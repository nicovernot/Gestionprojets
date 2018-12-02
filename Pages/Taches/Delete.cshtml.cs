using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Taches.Models;

namespace Medecins.Pages.Taches
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DeleteModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tache Tache { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tache = await _context.taches
                .Include(t => t.Jalons).FirstOrDefaultAsync(m => m.TacheID == id);

            if (Tache == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tache = await _context.taches.FindAsync(id);

            if (Tache != null)
            {
                _context.taches.Remove(Tache);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
