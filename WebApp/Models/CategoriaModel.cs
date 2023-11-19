using System.Collections.Generic;

namespace WebApp.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
    }
}
