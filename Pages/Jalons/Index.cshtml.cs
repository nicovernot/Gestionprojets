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
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

       public IList<Jalon> Jalon { get;set; }

        public async Task OnGetAsync(int id)
        {
            Jalon = await _context.jalon.Where(x=>x.ProjetiD==id)
                .Include(j => j.Projet).ToListAsync();
        }
    }
}
