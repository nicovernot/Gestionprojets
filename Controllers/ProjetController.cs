using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Projets.Models;
using MovieContexts.Models;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetController : ControllerBase
    {
        private readonly MovieContext _context;

        public ProjetController(MovieContext context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<Projet>> GetAll()
{
    return _context.Projets.ToList();
}

[HttpGet("{id}", Name = "GetProjet")]
public ActionResult<Projet> GetById(long id)
{
    var item = _context.Projets.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}

[HttpPost]
public IActionResult Create(Projet item)
{
    _context.Projets.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetProjet", new { id = item.ProjetID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, Projet item)
{
    var projet = _context.Projets.Find(id);
    if (projet == null)
    {
        return NotFound();
    }

    projet.RespID = item.RespID;
    projet.description = item.description;
    projet.nom=item.nom;
    projet.trigrame = item.trigrame;
   

    _context.Projets.Update(projet);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var projet = _context.Projets.Find(id);
    if (projet == null)
    {
        return NotFound();
    }

    _context.Projets.Remove(projet);
    _context.SaveChanges();
    return NoContent();
}



    }
}