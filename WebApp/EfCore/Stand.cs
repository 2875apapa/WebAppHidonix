using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.EfCore
{
    [Table("stand")]
    public class Stand
    {
        [Key, Required] public int Id { get; set; }
        [Required] public string Nome { get; set; }
        public int X_dim { get; set; } = 0;
        public int Y_dim { get; set; } = 0;
        public string Descrizione { get; set; } = string.Empty;
        public int SocietaId { get; set; } = -1; //Non gestita nel compito assegnato?
        public string Immagine { get; set; } //Gestire immagine
        public List<string> Tags { get; set; } = new List<string>();
        public int PadiglioneId { get; set; }
        public Padiglione Padiglione { get; set; } = null!;
        public int SettoreId { get; set; }
        public Settore Settore { get; set; } = null!;

    }
}
