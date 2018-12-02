using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Taches.Models;

namespace Medecins.Pages.Taches
{
    public class EditModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public EditModel(MovieContexts.Models.MovieContext context)
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
           ViewData["JalonID"] = new SelectList(_context.jalon, "JalonID", "nom");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(Tache.TacheID))
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

        private bool TacheExists(int id)
        {
            return _context.taches.Any(e => e.TacheID == id);
        }
    }
}
