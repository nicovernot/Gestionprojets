using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exigeances.Models;
using MovieContexts.Models;

namespace Medecins.Pages.Exigeances
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DetailsModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
