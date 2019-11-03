using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int id, int partidoId, int tipo, double cUnder, double cOver)
        {
            Id = id;
            PartidoId = partidoId;
            Tipo = tipo;
            CUnder = cUnder;
            COver = cOver;
        }

        public int Id { get; set; }

        public int Tipo { get; set; }

        public double CUnder { get; set; }

        public double COver { get; set; }

        public int PartidoId { get; set; }
        public Partido Partido { get; set; }

        public List<Apuesta> Apuesta { get; set; }
    }

    public class MercadoDTO
    {
        public MercadoDTO(int tipo, double cUnder, double cOver)
        {
            Tipo = tipo;
            CUnder = cUnder;
            COver = cOver;
        }

        public int Tipo { get; set; }

        public double CUnder { get; set; }

        public double COver { get; set; }
    }
}