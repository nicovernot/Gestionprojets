using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Jalons.Models;
using MovieContexts.Models;

namespace Gprojet.Pages.Jalons
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
        ViewData["ProjetiD"] = new SelectList(_context.Projets, "ProjetID", "nom");
        ViewData["RespID"] = new SelectList(_context.resp, "RespID", "nom");
            return Page();
        }

        [BindProperty]
        public Jalon Jalon { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.jalon.Add(Jalon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new{id = Jalon.ProjetiD});
        }
    }
}