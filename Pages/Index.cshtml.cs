using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projets.Models;

namespace Medecins.Pages
{
    public class IndexModel : PageModel
    {        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Projet> Projet { get;set; }

        public async Task OnGetAsync()
        {
            Projet = await _context.Projets
                .Include(p => p.resp).ToListAsync();
        }
    }
}
