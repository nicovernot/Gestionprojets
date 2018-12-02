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
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Exigeance> Exigeance { get;set; }

        public async Task OnGetAsync()
        {
            Exigeance = await _context.Exigeance
                .Include(e => e.Projet)
                .Include(e => e.TypeExigeance).ToListAsync();
        }
    }
}
