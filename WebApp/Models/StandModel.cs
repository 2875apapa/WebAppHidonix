using System.Collections.Generic;
using WebApp.EfCore;

namespace WebApp.Models
{
    public class StandModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int X_dim { get; set; } = 0;
        public int Y_dim { get; set; } = 0;
        public string Descrizione { get; set; } = string.Empty;
        public string Padiglione {  get; set; } = string.Empty;
        public string Settore {  get; set; } = string.Empty;

        public List<string> Tags { get; set; } = new List<string>();
    }
}
