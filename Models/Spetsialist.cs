using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EhitusfirmaProc.Models
{
    public class Spetsialist
    {
        [Key]
        public Guid SpetsialistID { get; set; }
        public string Eriala { get; set; }
        public IEnumerable<Töötaja> TöötajaID { get; set; }
    }
}
