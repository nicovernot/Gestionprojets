using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exigeance_Taches.Models;
using MovieContexts.Models;

namespace Medecins.Pages.Et
{
    public class EditModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public EditModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exigeance_Tache Exigeance_Tache { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exigeance_Tache = await _context.Exigeance_Tache
                .Include(e => e.Exigeance)
                .Include(e => e.Tache).FirstOrDefaultAsync(m => m.Exigeance_TacheID == id);

            if (Exigeance_Tache == null)
            {
                return NotFound();
            }
           ViewData["ExigeanceID"] = new SelectList(_context.Exigeance, "ExigeanceID", "description");
           ViewData["TacheID"] = new SelectList(_context.taches, "TacheID", "description");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exigeance_Tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exigeance_TacheExists(Exigeance_Tache.Exigeance_TacheID))
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

        private bool Exigeance_TacheExists(int id)
        {
            return _context.Exigeance_Tache.Any(e => e.Exigeance_TacheID == id);
        }
    }
}
