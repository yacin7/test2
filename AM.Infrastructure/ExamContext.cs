using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ExamContext:DbContext
    {
        public DbSet<Chanson> Chansons { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Artiste> Artistes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=FestivalDb;Integrated Security=true;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Foreign Key
            modelBuilder.Entity<Concert>().HasOne(c => c.Festival)
                                          .WithMany(f => f.Concerts)
                                          .HasForeignKey(c => c.FestivalFk);
            modelBuilder.Entity<Concert>().HasOne(c => c.Artiste)
                                         .WithMany(f => f.Concerts)
                                         .HasForeignKey(c => c.ArtisteFk);
            //Pk de la table porteuse
            modelBuilder.Entity<Concert>()
                .HasKey(c => new { c.DateConcert, c.ArtisteFk, c.FestivalFk });
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(50);
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
