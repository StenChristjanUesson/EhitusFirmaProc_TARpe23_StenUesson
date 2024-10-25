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

        public async Task<List<Projekt>> GetProjektid()
        {
            return await _context.Projektid.Include(p => p.Töötajad).ToListAsync();
        }

        public async Task<Projekt> GetProjekt(Guid id)
        {
            return await _context.Projektid.Include(p => p.Töötajad).FirstOrDefaultAsync(p => p.ProjektID == id);
        }

        public async Task<Projekt> LisaProjekt(Projekt projekt)
        {
            _context.Projektid.Add(projekt);
            await _context.SaveChangesAsync();
            return projekt;
        }

        public async Task UuendaProjekt(Guid id, Projekt projekt)
        {
            // Ensure the types match
            if (id != projekt.ProjektID) return;

            _context.Entry(projekt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
