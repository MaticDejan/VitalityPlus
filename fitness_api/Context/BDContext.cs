using Fitness_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Application.Context
{
    public class BDContext: DbContext
    {
        public BDContext(DbContextOptions<BDContext>option):base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Produs> Produse { get; set; }

        public DbSet<Meniu> Meniuri {  get; set; }

        public DbSet<ProdusGramaj> ProdusGramaje { get; set; }
        public DbSet<Cereri> Cereri { get; set; }

        public DbSet<Exercitiu> Exercitiu { get; set; }
        public DbSet<Antrenament> Antrenament { get; set; }
        public DbSet<ExercitiuEfort> ExercitiuEfort {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>().ToTable("Users");
            modelbuilder.Entity<Produs>().ToTable("Produse");
            modelbuilder.Entity<Meniu>().ToTable("Meniuri");
            modelbuilder.Entity<ProdusGramaj>().ToTable("ProdusGramaje");
            modelbuilder.Entity<Cereri>().ToTable("Cereri");
            modelbuilder.Entity<Exercitiu>().ToTable("Exercitiu");
            modelbuilder.Entity<Antrenament>().ToTable("Antrenament");
            modelbuilder.Entity<ExercitiuEfort>().ToTable("ExercitiuEfort");
        }
    }
}