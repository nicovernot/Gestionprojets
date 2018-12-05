using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Jalons.Models;
using MovieContexts.Models;
using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JalonController : ControllerBase
    {
        private readonly MovieContext _context;

        public JalonController(MovieContext context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<Jalon>> GetAll()
{
    return _context.jalon.ToList();
}

[HttpGet("{id}", Name = "GetJalon")]
public ActionResult<Jalon> GetById(long id)
{
    var item = _context.jalon.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}


[HttpGet("bypr{id}", Name = "GetJalonbypr")]
public ActionResult<List<Jalon>> GetJalonbypr(long id)
{
    var item = _context.jalon.Where(x=>x.ProjetiD==id)
                .Include(n => n.Tache);
    if (item == null)
    {
        return NotFound();
    }
    return item.ToList();
}


[HttpGet("Maxdate{id}", Name = "GetJalonMaxdate")]
public ActionResult<DateTime> GetByMaxdate(long id)
{
    var item = _context.jalon.Where(x=>x.ProjetiD==id).Max(x=>x.datefinprevue);
    if (item == null)
    {
        return NotFound();
    }
 
  

    return item;
}

[HttpPost]
public IActionResult Create(Jalon item)
{
    _context.jalon.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetJalon", new { id = item.JalonID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, Jalon item)
{
    var jalon = _context.jalon.Find(id);
    if (jalon == null)
    {
        return NotFound();
    }

    jalon.ProjetiD = item.ProjetiD;
    jalon.nom = item.nom;
   

    _context.jalon.Update(jalon);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var jalon = _context.jalon.Find(id);
    if (jalon == null)
    {
        return NotFound();
    }

    _context.jalon.Remove(jalon);
    _context.SaveChanges();
    return NoContent();
}



    }
}