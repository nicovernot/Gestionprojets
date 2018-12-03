using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exigeances.Models;
using MovieContexts.Models;

namespace Medecins.Pages.Exigeances
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
        ViewData["ProjetID"] = new SelectList(_context.Projets, "ProjetID", "nom");
        ViewData["TypeExigeanceID"] = new SelectList(_context.TypeExigeance, "TypeExigeanceID", "nom");
            return Page();
        }

        [BindProperty]
        public Exigeance Exigeance { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exigeance.Add(Exigeance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index/" ,new{id=Exigeance.ProjetID});
        }
    }
}