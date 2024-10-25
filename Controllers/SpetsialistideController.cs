using EhitusfirmaProc.Data;
using EhitusfirmaProc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EhitusfirmaProc.Controllers
{
    public class SpetsialistideController : Controller
    {
        private readonly StoredEhitusfirmaProcDbContext _context;

        public SpetsialistideController(StoredEhitusfirmaProcDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Spetsialist>>> GetAll()
        {
            return await _context.Spetsialistid.ToListAsync();
        }

        public async Task<ActionResult<Spetsialist>> GetById(Guid id)
        {
            var spetsialist = await _context.Spetsialistid.FindAsync(id);
            if (spetsialist == null)
            {
                return NotFound();
            }
            return spetsialist;
        }

        public async Task<ActionResult<Spetsialist>> Create(Spetsialist spetsialist)
        {
            _context.Spetsialistid.Add(spetsialist);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = spetsialist.SpetsialistID }, spetsialist);
        }

        public async Task<IActionResult> Update(Guid id, Spetsialist spetsialist)
        {
            if (id != spetsialist.SpetsialistID)
            {
                return BadRequest();
            }

            _context.Entry(spetsialist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var spetsialist = await _context.Spetsialistid.FindAsync(id);
            if (spetsialist == null)
            {
                return NotFound();
            }

            _context.Spetsialistid.Remove(spetsialist);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
