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
    public class DeleteModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public DeleteModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resp Resp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resp = await _context.resp.FirstOrDefaultAsync(m => m.RespID == id);

            if (Resp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resp = await _context.resp.FindAsync(id);

            if (Resp != null)
            {
                _context.resp.Remove(Resp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
