using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EhitusfirmaProc.Models
{
    public class Projekt
    {
        [Key] 
        public Guid ProjektID { get; set; }
        public string Name { get; set; }
        public string Kirjeldus { get; set; }
        public DateTime Alguskuupäev { get; set; }
        public DateTime Lõppkuupäev { get; set; }
        public ICollection<Töötaja> Töötajad { get; set; } = new List<Töötaja>();
        public ICollection<Spetsialist> Spetsialistid { get; set; } = new List<Spetsialist>();
    }
}
