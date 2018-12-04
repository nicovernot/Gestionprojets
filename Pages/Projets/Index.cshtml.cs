using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Projets.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

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
                .Include(p => p.resp).ToListAsync();
        }


           static async Task<string> GetProjdateprevtAsync(int id)
        {
            string date;
            HttpResponseMessage response = await client.GetAsync("api/Maxdate"+id);
            if (response.IsSuccessStatusCode)
            {
                date = await response.Content.ReadAsAsync<String>();
            return date;
            }
            return "non établi";
        }
    }
}
