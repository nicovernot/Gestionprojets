using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieContexts.Models;
using Taches.Models;
using Jalons.Models;

namespace Gprojet.Pages.Taches
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
        ViewData["JalonID"] = new SelectList(_context.jalon, "JalonID", "nom");
        ViewData["RespID"] = new SelectList(_context.resp, "RespID", "nom");
            return Page();
        }

        [BindProperty]
        public Tache Tache { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
              var datefin= Tache.datedemarage.AddDays(Tache.nbjours);
              Console.WriteLine("datefin"+datefin);
              Jalon jalon = _context.jalon.Find(Tache.JalonID);  
              if (jalon.datefinprevue !=null && jalon.datefinprevue<datefin){
              jalon.datefinprevue = datefin; 
              _context.jalon.Update(jalon);
              }
              if (jalon.datefinprevue ==null){
                 jalon.datefinprevue = datefin; 
                 _context.jalon.Update(jalon);
              }
             
            _context.taches.Add(Tache);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new{id = Tache.JalonID});
        }
    }
}