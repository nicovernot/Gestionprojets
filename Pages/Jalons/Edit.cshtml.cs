using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jalons.Models;
using MovieContexts.Models;

namespace Gprojet.Pages.Jalons
{
    public class EditModel : PageModel
    {
        private readonly MovieContexts.Models.MovieContext _context;

        public EditModel(MovieContexts.Models.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jalon Jalon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jalon = await _context.jalon
                .Include(j => j.Projet)
                .Include(j => j.Resp).FirstOrDefaultAsync(m => m.JalonID == id);

            if (Jalon == null)
            {
                return NotFound();
            }
           ViewData["ProjetiD"] = new SelectList(_context.Projets, "ProjetID", "ProjetID");
           ViewData["RespID"] = new SelectList(_context.resp, "RespID", "RespID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jalon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JalonExists(Jalon.JalonID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index",new{id = Jalon.ProjetiD});
        }

        private bool JalonExists(int id)
        {
            return _context.jalon.Any(e => e.JalonID == id);
        }
    }
}
