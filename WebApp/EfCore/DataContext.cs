using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.EfCore
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.UseSerialColumns();    

        }

        public DbSet<Stand> Stands { get; set; }
        public DbSet<Settore> Settori { get; set; }
        public DbSet<Padiglione> Padiglioni { get; set; }
        public DbSet<Categoria> Categorie { get; set; }

    }
}
