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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}