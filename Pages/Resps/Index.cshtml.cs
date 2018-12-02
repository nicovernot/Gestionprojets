using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using Resps.Models;

namespace Medecins.Pages.Resps
{
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Resp> Resp { get;set; }

        public async Task OnGetAsync()
        {
            Resp = await _context.resp.ToListAsync();
        }
    }
}
