using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sistema_de_Controle_de_Alienígenas.Models;

namespace Sistema_de_Controle_de_Alienígenas.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<AlienModel> Aliens { get; set; }
        public DbSet<RegistroModel> Registros { get; set; }
        public DbSet<PlanetaModel> Planetas { get; set; }
        public DbSet<PoderModel> Poderes { get; set; }
        public DbSet<AlienPoderModel> AlienPoder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //definindo ID  de ALienPoder
            modelBuilder.Entity<AlienPoderModel>()
                .HasKey(ap => new { ap.AlienId, ap.PoderId });

            //Relação 1 -> N entre alien e planeta
            modelBuilder.Entity<AlienModel>()
                .HasOne(a => a.Planeta)
                .WithMany()
                .HasForeignKey(a => a.PlanetaID);

            // Relação N -> N entre alien e poder
            modelBuilder.Entity<AlienModel>()
                .HasMany(a => a.AlienPoderes)
                .WithOne(ap => ap.Alien)
                .HasForeignKey(ap => ap.AlienId);

            modelBuilder.Entity<PoderModel>()
               .HasMany(a => a.AlienPoderes)
               .WithOne(ap => ap.Poder)
               .HasForeignKey(ap => ap.PoderId);

            //Relação 1 -> N entre alien e registro
            modelBuilder.Entity<RegistroModel>()
                .HasOne(a => a.Alien)
                .WithMany()
                .HasForeignKey(a => a.AlienId);
        }
    }
}
