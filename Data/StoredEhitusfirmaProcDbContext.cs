using Microsoft.EntityFrameworkCore;
using EhitusfirmaProc.Models;

namespace EhitusfirmaProc.Data
{
    public class StoredEhitusfirmaProcDbContext : DbContext
    {
        public StoredEhitusfirmaProcDbContext(DbContextOptions<StoredEhitusfirmaProcDbContext> options)
            : base(options) { }
        public DbSet<Projekt> Projektid { get; set;}
        public DbSet<Spetsialist> Spetsialistid { get; set;}
        public DbSet<Töötaja> Töötajad { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Töötaja>().ToTable("Töötajad");
            modelBuilder.Entity<Projekt>().ToTable("Projektid");
            modelBuilder.Entity<Spetsialist>().ToTable("Spetsialistid");
        }
    }
}
