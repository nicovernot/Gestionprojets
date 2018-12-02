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
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Exigeance_Tache> Exigeance_Tache { get;set; }

        public async Task OnGetAsync()
        {
            Exigeance_Tache = await _context.Exigeance_Tache
                .Include(e => e.Exigeance)
                .Include(e => e.Tache).ToListAsync();
        }
    }
}
