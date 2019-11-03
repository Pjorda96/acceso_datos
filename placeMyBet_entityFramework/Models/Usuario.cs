using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placeMyBet.Models
{
    public class Usuario
    {
        public Usuario(int id, string dni, string nombre, string apellidos, string email, DateTime birdthDate, double saldo, Boolean active)
        {
            Id = id;
            DNI = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            BirtdhDate = birdthDate;
            Saldo = saldo;
            Active = active;
        }

        public int Id { get; set; }

        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public DateTime BirtdhDate { get; set; }

        public double Saldo { get; set; }

        public bool Active { get; set; }

        public List<DatosBanco> DatosBanco { get; set; }

        public Apuesta Apuesta { get; set; }
    }
}