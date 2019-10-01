﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int id, int mercadoId, double cuota, int boletoId)
        {
            Id = id;
            MercadoId = mercadoId;
            Cuota = cuota;
            BoletoId = boletoId;
        }

        public int Id { get; set; }

        public int MercadoId { get; set; }

        public double Cuota { get; set; }

        public int BoletoId { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(int mercadoId, double cuota)
        {
            MercadoId = mercadoId;
            Cuota = cuota;
        }

        public int MercadoId { get; set; }

        public double Cuota { get; set; }
    }
}