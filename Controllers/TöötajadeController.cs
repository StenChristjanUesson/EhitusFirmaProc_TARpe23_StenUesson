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

        public async Task<List<Töötaja>> GetTöötaja()
        {
            return await _context.Töötajad.ToListAsync();
        }

        public async Task<Töötaja> GetTöötaja(int id)
        {
            return await _context.Töötajad.FindAsync(id);
        }

        public async Task<Töötaja> CreateTöötaja(Töötaja töötaja)
        {
            _context.Töötajad.Add(töötaja);
            await _context.SaveChangesAsync();
            return töötaja;
        }

        public async Task UpdateTöötaja(Guid id, Töötaja töötaja)
        {
            if (id != töötaja.TöötajaID) return;

            _context.Entry(töötaja).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
