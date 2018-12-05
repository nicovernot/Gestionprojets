using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Projets.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Jalons.Models;

namespace Medecins.Pages.Projets
{
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Projet> Projet { get;set; }
        static HttpClient client = new HttpClient();
        public async Task OnGetAsync()
        {
         

            Projet = await _context.Projets
                .Include(s=>s.Jalon)
                .Include(i=>i.Exigeance)
                .Include(p => p.resp).ToListAsync();
        }


           public async Task<List<Jalon>> GetTacheAsyn(int id)
        {
           var jal = await _context.jalon
           .Where(l=>l.ProjetiD==id)
           .Include(x=>x.Tache).ToListAsync();
           return jal;
        }

        public string GetNameAndContent()
{
     //Takes up to 30 seconds
    return "Retour date";
}

    }
}
