using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estacionamento.Models;

namespace Estacionamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadiasController : ControllerBase
    {
        private readonly EstacionamentoContext _context;

        public EstadiasController(EstacionamentoContext context)
        {
            _context = context;
        }

        // GET: api/Estadias
        [HttpGet]
        public IEnumerable<Estadia> GetEstadia()
        {
            return _context.Estadia;
        }

        // GET: api/Estadias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadia = await _context.Estadia.FindAsync(id);

            if (estadia == null)
            {
                return NotFound();
            }

            return Ok(estadia);
        }

        // PUT: api/Estadias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadia([FromRoute] int id, [FromBody] Estadia estadia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadia.id)
            {
                return BadRequest();
            }

            _context.Entry(estadia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadiaExists(id))
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

        // POST: api/Estadias
        [HttpPost]
        public async Task<IActionResult> PostEstadia([FromBody] Estadia estadia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Estadia.Add(estadia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadia", new { id = estadia.id }, estadia);
        }

        // DELETE: api/Estadias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadia = await _context.Estadia.FindAsync(id);
            if (estadia == null)
            {
                return NotFound();
            }

            _context.Estadia.Remove(estadia);
            await _context.SaveChangesAsync();

            return Ok(estadia);
        }

        private bool EstadiaExists(int id)
        {
            return _context.Estadia.Any(e => e.id == id);
        }
    }
}