using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Exigeances.Models;
using MovieContexts.Models;
using Taches.Models;
using Exigeance_Taches.Models;

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
        public IList<Tache> Tache { get;set; } 

        public IList<Exigeance_Tache> Exigeance_Tache { get;set; }  
        public async Task OnGetAsync(int id)
        {
            Exigeance = await _context.Exigeance.Where(x=>x.ProjetID==id)
                .Include(e => e.Projet)
                .Include(e => e.TypeExigeance).ToListAsync();
        }

                public async Task<List<Exigeance_Tache>> GetExiAsync(int id)
        {
            Exigeance_Tache = await _context.Exigeance_Tache.Where(x=>x.ExigeanceID ==id)              
                .ToListAsync();

                return Exigeance_Tache.ToList();
        }
        


                public async Task<List<Tache>> GetTacheAsync(int id)
        {
            Tache = await _context.taches.Where(x=>x.TacheID==id).ToListAsync();
        return Tache.ToList();
        }
    }
}
