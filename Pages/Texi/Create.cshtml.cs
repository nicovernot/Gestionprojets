using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieContexts.Models;
using TypeExigeances.Models;

namespace Medecins.Pages.Texi
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
            return Page();
        }

        [BindProperty]
        public TypeExigeance TypeExigeance { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TypeExigeance.Add(TypeExigeance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}