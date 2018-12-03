using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieContexts.Models;
using Projets.Models;

namespace Medecins.Pages.Projets
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
        ViewData["RespID"] = new SelectList(_context.resp, "RespID", "nom");
            return Page();
        }

        [BindProperty]
        public Projet Projet { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projets.Add(Projet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}