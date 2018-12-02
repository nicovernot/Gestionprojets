using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Projets.Models;

namespace Medecins.Pages.Projets
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DeleteModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projet Projet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projet = await _context.Projets
                .Include(p => p.resp).FirstOrDefaultAsync(m => m.ProjetID == id);

            if (Projet == null)
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

            Projet = await _context.Projets.FindAsync(id);

            if (Projet != null)
            {
                _context.Projets.Remove(Projet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
