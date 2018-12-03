using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Exigeance_Taches.Models;
using System;
using MovieContexts.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExigeanceTacheController : ControllerBase
    {
        private readonly MovieContext _context;

        public ExigeanceTacheController(MovieContext context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<Exigeance_Tache>> GetAll()
{
    return _context.Exigeance_Tache.ToList();
}

[HttpGet("{id}", Name = "GetExigeanceTache")]
public ActionResult<Exigeance_Tache> GetById(long id)
{
    var item = _context.Exigeance_Tache.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}

[HttpPost]
public IActionResult Create(Exigeance_Tache item)
{
    _context.Exigeance_Tache.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetExigeanceTache", new { id = item.Exigeance_TacheID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, Exigeance_Tache item)
{
    var exigeance_Tache = _context.Exigeance_Tache.Find(id);
    if (exigeance_Tache == null)
    {
        return NotFound();
    }


    exigeance_Tache.ExigeanceID = item.ExigeanceID;
    exigeance_Tache.TacheID = item.TacheID;

    _context.Exigeance_Tache.Update(exigeance_Tache);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var exigeance_Tache = _context.Exigeance_Tache.Find(id);
    if (exigeance_Tache == null)
    {
        return NotFound();
    }

    _context.Exigeance_Tache.Remove(exigeance_Tache);
    _context.SaveChanges();
    return NoContent();
}



    }
}