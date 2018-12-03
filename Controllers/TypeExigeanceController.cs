using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MovieContexts.Models;
using TypeExigeances.Models;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeExigeanceController : ControllerBase
    {
        private readonly MovieContext _context;

        public TypeExigeanceController(MovieContext context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<TypeExigeance>> GetAll()
{
    return _context.TypeExigeance.ToList();
}

[HttpGet("{id}", Name = "GetTypeExigeance")]
public ActionResult<TypeExigeance> GetById(long id)
{
    var item = _context.TypeExigeance.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}

[HttpPost]
public IActionResult Create(TypeExigeance item)
{
    _context.TypeExigeance.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetTypeExigeance", new { id = item.TypeExigeanceID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, TypeExigeance item)
{
    var TypeExigeance = _context.TypeExigeance.Find(id);
    if (TypeExigeance == null)
    {
        return NotFound();
    }

    TypeExigeance.nom = item.nom;

    _context.TypeExigeance.Update(TypeExigeance);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var TypeExigeance = _context.TypeExigeance.Find(id);
    if (TypeExigeance == null)
    {
        return NotFound();
    }

    _context.TypeExigeance.Remove(TypeExigeance);
    _context.SaveChanges();
    return NoContent();
}



    }
}