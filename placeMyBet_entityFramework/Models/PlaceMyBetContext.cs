using Microsoft.EntityFrameworkCore;
using PlaceMyBet.Constants;
using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placeMyBet.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DatosBanco> DatosBancos { get; set; }

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(MySQL.MySqlConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "12345678B", "Pablo", "Jorda Garcia", "pjorda96@gmail.com", DateTime.Parse("2019-10-19 19:28:49"), 0, false));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(2, "87654321A", "Eugenio", "Tio Uge", "halleck@gmail.com", DateTime.Parse("2019-10-19 19:28:49"), 100, false));
            modelBuilder.Entity<DatosBanco>().HasData(new DatosBanco(1, "Tarjeta Black", "Pablo Jorda Garcia", 1, "126443653", DateTime.Parse("2019-10-19 19:28:49"), 123, 1));
            modelBuilder.Entity<DatosBanco>().HasData(new DatosBanco(2, "Visa Super Platino", "Eugenio", 1, "1266443653", DateTime.Parse("2019-10-19 19:28:49"), 321, 2));
            modelBuilder.Entity<Partido>().HasData(new Partido(1, "Valencia", "Barsa", DateTime.Parse("2019-10-19 19:28:49")));
            modelBuilder.Entity<Partido>().HasData(new Partido(2, "Madrid", "Leganes", DateTime.Parse("2019-10-19 19:28:49")));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1, 1, 1.20, 3));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2, 2, 1.5, 2.5));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 1, 10, 1, 1.20, 0, DateTime.Parse("2019-10-19 19:28:49")));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, 2, 100, 2, 1.50, 1, DateTime.Parse("2019-10-19 19:28:49")));
        }
    }
}