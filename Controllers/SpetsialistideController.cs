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

        public async Task<List<Spetsialist>> GetSpetsialistid()
        {
            return await _context.Spetsialistid.ToListAsync();
        }

        public async Task<Spetsialist> GetSpetsialist(Guid id)
        {
            return await _context.Spetsialistid.FindAsync(id);
        }

        public async Task<Spetsialist> LisaSpetsialist(Spetsialist spetsialist)
        {
            _context.Spetsialistid.Add(spetsialist);
            await _context.SaveChangesAsync();
            return spetsialist;
        }

        public async Task UuendaSpetsialist(Guid id, Spetsialist spetsialist)
        {
            // Ensure the types match
            if (id != spetsialist.TöötajaID) return;

            _context.Entry(spetsialist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
