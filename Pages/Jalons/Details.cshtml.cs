using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jalons.Models;
using MovieContexts.Models;

namespace Gprojet.Pages.Jalons
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DetailsModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public Jalon Jalon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jalon = await _context.jalon
                .Include(j => j.Projet)
                .Include(j => j.Resp).FirstOrDefaultAsync(m => m.JalonID == id);

            if (Jalon == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
