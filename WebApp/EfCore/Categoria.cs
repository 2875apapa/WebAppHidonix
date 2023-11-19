using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.EfCore
{
    [Table("categoria")]
    public class Categoria
    {
        [Key, Required] public int Id { get; set; }
        [Required] public string Nome { get; set; }
        public string Descrizione { get; set; } = string.Empty;
        public string Immagine { get; set; } //Gestire immagine
        public List<string> Tags { get; set; } = new List<string>();
    }
}
