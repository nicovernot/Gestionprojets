using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieContexts.Models;
using TypeExigeances.Models;

namespace Medecins.Pages.Texi
{
    public class IndexModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public IndexModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<TypeExigeance> TypeExigeance { get;set; }

        public async Task OnGetAsync()
        {
            TypeExigeance = await _context.TypeExigeance.ToListAsync();
        }
    }
}
