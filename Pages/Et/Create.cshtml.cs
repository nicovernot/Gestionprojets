using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exigeance_Taches.Models;
using MovieContexts.Models;

namespace Medecins.Pages.Et
{
    public class CreateModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public CreateModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExigeanceID"] = new SelectList(_context.Exigeance, "ExigeanceID", "description");
        ViewData["TacheID"] = new SelectList(_context.taches, "TacheID", "description");
            return Page();
        }

        [BindProperty]
        public Exigeance_Tache Exigeance_Tache { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exigeance_Tache.Add(Exigeance_Tache);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}