using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Partido
    {
        public Partido(int id, string local, string visitante, DateTime hora)
        {
            Id = id;
            Local = local;
            Visitante = visitante;
            Hora = hora;
        }

        public int Id { get; set; }

        public string Local { get; set; }

        public string Visitante { get; set; }

        public DateTime Hora { get; set; }

        public List<Mercado> Mercado { get; set; }
    }

    public class PartidoDTO
    {
        public PartidoDTO(string local, string visitante)
        {
            Local = local;
            Visitante = visitante;
        }

        public string Local { get; set; }

        public string Visitante { get; set; }
    }
}