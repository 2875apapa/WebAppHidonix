using System.Collections.Generic;

namespace WebApp.Models
{
    public class PadiglioneModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public string Poweredby { get; set; } = string.Empty;
        public string Descrizione { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
    }
}
