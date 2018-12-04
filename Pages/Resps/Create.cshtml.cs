using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieContexts.Models;
using Resps.Models;

namespace Gprojet.Pages.Resps
{
    public class CreateModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public CreateModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Resp Resp { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.resp.Add(Resp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}