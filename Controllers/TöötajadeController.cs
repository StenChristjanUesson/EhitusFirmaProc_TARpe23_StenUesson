using EhitusfirmaProc.Data;
using EhitusfirmaProc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EhitusfirmaProc.Controllers
{
    public class TöötajadeController : Controller
    {
        private readonly StoredEhitusfirmaProcDbContext _context;

        public TöötajadeController(StoredEhitusfirmaProcDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Töötaja>>> GetAll()
        {
            return await _context.Töötajad.ToListAsync();
        }

        public async Task<ActionResult<Töötaja>> GetById(Guid id)
        {
            var töötaja = await _context.Töötajad.FindAsync(id);
            if (töötaja == null)
            {
                return NotFound();
            }
            return töötaja;
        }

        public async Task<ActionResult<Töötaja>> Create(Töötaja töötaja)
        {
            _context.Töötajad.Add(töötaja);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = töötaja.TöötajaID }, töötaja);
        }

        public async Task<IActionResult> Update(Guid id, Töötaja töötaja)
        {
            if (id != töötaja.TöötajaID)
            {
                return BadRequest();
            }

            _context.Entry(töötaja).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var töötaja = await _context.Töötajad.FindAsync(id);
            if (töötaja == null)
            {
                return NotFound();
            }

            _context.Töötajad.Remove(töötaja);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
