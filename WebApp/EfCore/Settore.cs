using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.EfCore
{
    [Table("settore")]
    public class Settore
    {
        [Key, Required] public int Id { get; set; }
        [Required] public string Nome { get; set; }
        public string Tipologia { get; set; } = string.Empty;
        public int NumStand { get; set; } = 0;
        public string Descrizione { get; set; } = string.Empty;
        public string Stato { get; set; } = "Bozza";
        public string Immagine { get; set; } //Gestire immagine
        public List<string> Tags { get; set; } = new List<string>();
        public List<Stand> Stands { get; set; } = new List<Stand>();
    }
}
