using EhitusfirmaProc.Data;
using EhitusfirmaProc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EhitusfirmaProc.Controllers
{
    public class ProjektideController : Controller
    {
        private readonly StoredEhitusfirmaProcDbContext _context;
        public ProjektideController(StoredEhitusfirmaProcDbContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<IEnumerable<Projekt>>> GetAll()
        {
            return await _context.Projektid.ToListAsync();
        }

        public async Task<ActionResult<Projekt>> GetById(Guid id)
        {
            var projekt = await _context.Projektid.FindAsync(id);
            if (projekt == null)
            {
                return NotFound();
            }
            return projekt;
        }

        public async Task<ActionResult<Projekt>> Create(Projekt projekt)
        {
            _context.Projektid.Add(projekt);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = projekt.ProjektID }, projekt);
        }

        public async Task<IActionResult> Update(Guid id, Projekt projekt)
        {
            if (id != projekt.ProjektID)
            {
                return BadRequest();
            }

            _context.Entry(projekt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var projekt = await _context.Projektid.FindAsync(id);
            if (projekt == null)
            {
                return NotFound();
            }

            _context.Projektid.Remove(projekt);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
