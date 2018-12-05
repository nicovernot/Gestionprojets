using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Taches.Models;

namespace Gprojet.Pages.Taches
{
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Tache> Tache { get;set; }

        public async Task OnGetAsync(int id)
        {
            
            Tache = await _context.taches.Where(x=>x.JalonID==id)
                .Include(t => t.Jalons)
                .Include(t => t.Resps).ToListAsync();
        }
    }
}
