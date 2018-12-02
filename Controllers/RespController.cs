using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Resps.Models;
using System;
using MovieContexts.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespController : ControllerBase
    {
        private readonly MovieContext _context;

        public RespController(MovieContext  context)
        {
            _context = context;

                       
        }

        [HttpGet]
public ActionResult<List<Resp>> GetAll()
{
    return _context.resp.ToList();
}

[HttpGet("{id}", Name = "GetResp")]
public ActionResult<Resp> GetById(long id)
{
    var item = _context.resp.Find(id);
    if (item == null)
    {
        return NotFound();
    }
    return item;
}

[HttpPost]
public IActionResult Create(Resp item)
{
    _context.resp.Add(item);
    _context.SaveChanges();

    return CreatedAtRoute("GetResp", new { id = item.RespID }, item);
}

[HttpPut("{id}")]
public IActionResult Update(long id, Resp item)
{
    var resp = _context.resp.Find(id);
    if (resp == null)
    {
        return NotFound();
    }

  
    resp.nom = item.nom;

    _context.resp.Update(resp);
    _context.SaveChanges();
    return NoContent();
}
[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var livre = _context.resp.Find(id);
    if (livre == null)
    {
        return NotFound();
    }

    _context.resp.Remove(livre);
    _context.SaveChanges();
    return NoContent();
}



    }
}