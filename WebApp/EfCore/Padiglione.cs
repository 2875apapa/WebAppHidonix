﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.EfCore
{
    [Table("padiglione")]
    public class Padiglione
    {
        [Key, Required] public int Id {  get; set; }
        [Required] public string Nome { get; set; }
        [Required] public string Area { get; set; }
        public string Poweredby { get; set; } = string.Empty;
        public string Descrizione { get; set; } = string.Empty;
        public string Immagine { get; set; } //Gestire immagine
        public List<string> Tags { get; set; } = new List<string>();
        public List<Stand> Stands { get; set; } = new List<Stand>();

    }
}
