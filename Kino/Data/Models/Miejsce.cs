using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Models
{
    public class Miejsce
    {
        [Key]
        public int IdMiejsce { get; set; }
        public int Rzad { get; set; }
        public bool CzyZajete { get; set; }
        public Seans Seans { get; set; }
    }
}
