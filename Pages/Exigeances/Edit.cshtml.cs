using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exigeances.Models;
using MovieContexts.Models;

namespace Medecins.Pages.Exigeances
{
    public class EditModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public EditModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exigeance Exigeance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exigeance = await _context.Exigeance
                .Include(e => e.Projet)
                .Include(e => e.TypeExigeance).FirstOrDefaultAsync(m => m.ExigeanceID == id);

            if (Exigeance == null)
            {
                return NotFound();
            }
           ViewData["ProjetID"] = new SelectList(_context.Projets, "ProjetID", "ProjetID");
           ViewData["TypeExigeanceID"] = new SelectList(_context.TypeExigeance, "TypeExigeanceID", "nom");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Exigeance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExigeanceExists(Exigeance.ExigeanceID))
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

        private bool ExigeanceExists(int id)
        {
            return _context.Exigeance.Any(e => e.ExigeanceID == id);
        }
    }
}
