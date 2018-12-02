using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using TypeExigeances.Models;

namespace Medecins.Pages.Texi
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DeleteModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeExigeance TypeExigeance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeExigeance = await _context.TypeExigeance.FirstOrDefaultAsync(m => m.TypeExigeanceID == id);

            if (TypeExigeance == null)
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

            TypeExigeance = await _context.TypeExigeance.FindAsync(id);

            if (TypeExigeance != null)
            {
                _context.TypeExigeance.Remove(TypeExigeance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
