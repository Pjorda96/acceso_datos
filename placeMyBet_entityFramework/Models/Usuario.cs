using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placeMyBet.Models
{
    public class Usuario
    {
        public Usuario(int usuarioId, string dni, string nombre, string apellidos, string email, DateTime birdthDate, double saldo, Boolean active)
        {
            UsuarioId = usuarioId;
            DNI = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            BirtdhDate = birdthDate;
            Saldo = saldo;
            Active = active;
        }

        public Usuario ()
        {

        }

        public int UsuarioId { get; set; }

        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public DateTime BirtdhDate { get; set; }

        public double Saldo { get; set; }

        public bool Active { get; set; }

        public List<DatosBanco> DatosBanco { get; set; }

        public List<Apuesta> Apuesta { get; set; }
    }
}