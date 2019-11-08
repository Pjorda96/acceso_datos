using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placeMyBet.Models
{
    public class DatosBanco
    {
        public DatosBanco(int id, string alias, string titular, int tipo, string numero, DateTime expTime, int cvv, int usuarioId)
        {
            Id = id;
            Alias = alias;
            Titular = titular;
            Tipo = tipo;
            Numero = numero;
            ExpTime = expTime;
            Cvv = cvv;
            UsuarioId = usuarioId;
        }

        public DatosBanco ()
        {

        }

        public int Id { get; set; }

        public string Alias { get; set; }

        public string Titular { get; set; }

        public int Tipo { get; set; }

        public string Numero { get; set; }

        public DateTime ExpTime { get; set; }

        public int Cvv { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}