using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Exigeances.Models;
using MovieContexts.Models;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExigeanceController : ControllerBase
    {
        private readonly MovieContext _context;

        public ExigeanceController(MovieContext context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<Exigeance>> GetAll()
{
    return _context.Exigeance.ToList();
}

[HttpGet("{id}", Name = "GetExigeance")]
public ActionResult<Exigeance> GetById(long id)
{
    var item = _context.Exigeance.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}

[HttpPost]
public IActionResult Create(Exigeance item)
{
    _context.Exigeance.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetExigeance", new { id = item.ExigeanceID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, Exigeance item)
{
    var exigeance = _context.Exigeance.Find(id);
    if ( exigeance == null)
    {
        return NotFound();
    }
   
   exigeance.ProjetID = exigeance.ProjetID;
   exigeance.TypeExigeanceID = exigeance.TypeExigeanceID;
   exigeance.description = exigeance.description;
   exigeance.nom = exigeance.nom;

    _context.Exigeance.Update(exigeance);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var exigeance = _context.Exigeance.Find(id);
    if (exigeance == null)
    {
        return NotFound();
    }

    _context.Exigeance.Remove(exigeance);
    _context.SaveChanges();
    return NoContent();
}



    }
}