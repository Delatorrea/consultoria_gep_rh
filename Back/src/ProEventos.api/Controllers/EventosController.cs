using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.api.Data;
using ProEventos.api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json")]
  public class EventosController : ControllerBase
  {

    public readonly DataContext _context;

    public EventosController(DataContext context)
    {
      this._context = context;
    }

    // GET: api/Eventos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evento>>> Get()
    {
      return await _context.Eventos.ToListAsync();

    }

    // GET: api/Eventos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> GetById(int id)
    {

      var evento = await _context.Eventos.FindAsync(id);
      if (evento == null)
      {
        return NotFound();
      }
      return evento;
    }

    // PUT: api/Eventos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento eventos)
    {
      if (id != eventos.EventoId)
      {
        return BadRequest();
      }

      _context.Entry(eventos).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EventoExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Eventos
    [HttpPost]
    public async Task<ActionResult<Evento>> Post(Evento evento)
    {
      _context.Eventos.Add(evento);
      await _context.SaveChangesAsync();
      return CreatedAtAction("Get", new { id = evento.EventoId }, evento);
    }


    // DELETE: api/Eventos/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Evento>> Delete(int id)
    {
      var evento = await _context.Eventos.FindAsync(id);
      if (evento == null)
      {
        return NotFound();
      }
      _context.Eventos.Remove(evento);
      await _context.SaveChangesAsync();
      return evento;
    }

    private bool EventoExists(int id)
    {
      return _context.Eventos.Any(e => e.EventoId == id);
    }
  }
}
