using System.ComponentModel.DataAnnotations;

namespace EhitusfirmaProc.Models
{
    public class Töötaja
    {
        [Key]
        public Guid TöötajaID { get; set; }
        public string Eesnimi { get; set; }
        public string Perekonnanimi { get; set; }
        public IEnumerable<Projekt> ProjektID { get; set; }
    }
}
