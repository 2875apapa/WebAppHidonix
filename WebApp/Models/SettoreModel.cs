using System.Collections.Generic;
using WebApp.EfCore;

namespace WebApp.Models
{
    public class SettoreModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipologia { get; set; } = string.Empty;
        public int NumStand { get; set; } = 0;
        public string Descrizione { get; set; } = string.Empty;
        public string Stato { get; set; } = "Bozza";
        public List<string> Tags { get; set; } = new List<string>();
    }
}
