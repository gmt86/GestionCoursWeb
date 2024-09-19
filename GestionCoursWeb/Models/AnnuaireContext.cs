using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionCours.Model
{

    public class AnnuaireContext : DbContext
    {
        public DbSet<Diplome> Diplomes { get; set; }
        public DbSet<Promotion> Promotions { get; set; } 
        public DbSet<Eleve> Eleves { get; set; }

        public AnnuaireContext(DbContextOptions options) :base(options) 
        { 
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Diplome>().Property(d => d.Code).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Diplome>().Property(d => d.Nom).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<Diplome>().Property(d => d.Niveau).IsRequired();
            modelBuilder.Entity<Diplome>().HasKey(d=>d.Code);

            modelBuilder.Entity<Promotion>().Property(p => p.Nom).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Promotion>().Property(p => p.DateDebut).IsRequired();
            modelBuilder.Entity<Promotion>().Property(p => p.DateFin).IsRequired();


            modelBuilder.Entity<Eleve>().Property(e => e.Nom).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Eleve>().Property(e => e.Prenom).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Eleve>().Property(e=> e.Email).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Eleve>().Property(e => e.Address).HasMaxLength(100);
            modelBuilder.Entity<Eleve>().Property(e => e.CodePostal).HasMaxLength(5);
            modelBuilder.Entity<Eleve>().Property(e => e.Ville).HasMaxLength(50);


            modelBuilder.Entity<Promotion>().HasOne<Diplome>(p =>p.Diplome)
                                            .WithMany(d=>d.Promotions)
                                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Eleve>().HasMany<Promotion>(e => e.Promotions)
                                           .WithMany(p => p.Eleves);
                                           

        }

    }
}
