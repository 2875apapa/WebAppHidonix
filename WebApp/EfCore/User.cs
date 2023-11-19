using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.EfCore
{
    [Table("user")]
    public class User : IdentityUser
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime dataNascita { get; set; }

    }
}
