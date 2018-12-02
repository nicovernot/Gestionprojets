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
    public class DetailsModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DetailsModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

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
    }
}
