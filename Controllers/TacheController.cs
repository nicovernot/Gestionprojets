using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Taches.Models;
using MovieContexts.Models;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly MovieContext _context;

        public TacheController(MovieContext context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<Tache>> GetAll()
{
    return _context.taches.ToList();
}

[HttpGet("{id}", Name = "Gettache")]
public ActionResult<Tache> GetById(long id)
{
    var item = _context.taches.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}

[HttpGet("gtbj{id}", Name = "GettachebyJalon")]
public ActionResult<Array> Gettachebyjalon(long id)
{
   
   
    var tachesfinis = _context.taches
    .Where(x=>x.JalonID==id && x.datedemarage!=null && x.datefintache!=null).Count();
var tachescom = _context.taches
    .Where(x=>x.JalonID==id && x.datedemarage!=null && x.datefintache==null).Count();
    var nbtaches = _context.taches
    .Where(x=>x.JalonID==id).Count();
   int[] item = new int[3];
  item[0]=tachesfinis; 
  item[1]=tachescom;
  item[2]=nbtaches;
 

    return item;
}


[HttpPost]
public IActionResult Create(Tache item)
{
    _context.taches.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetTache", new { id = item.TacheID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, Tache item)
{
    var tache = _context.taches.Find(id);
    if (tache == null)
    {
        return NotFound();
    }

    tache.JalonID = item.JalonID;
    tache.TachePrece =tache.TachePrece;
    tache.datedebuttache =item.datedebuttache;
    tache.datedemarage=item.datedemarage;
    tache.datefintache = item.datefintache;
    tache.description = item.description;
    tache.nbjours = item.nbjours;

    _context.taches.Update(tache);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var tache = _context.taches.Find(id);
    if (tache == null)
    {
        return NotFound();
    }

    _context.taches.Remove(tache);
    _context.SaveChanges();
    return NoContent();
}



    }
}