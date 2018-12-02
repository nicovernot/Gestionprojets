using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exigeance_Taches.Models;
using MovieContexts.Models;

namespace Medecins.Pages.Et
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DetailsModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public Exigeance_Tache Exigeance_Tache { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exigeance_Tache = await _context.Exigeance_Tache
                .Include(e => e.Exigeance)
                .Include(e => e.Tache).FirstOrDefaultAsync(m => m.Exigeance_TacheID == id);

            if (Exigeance_Tache == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
