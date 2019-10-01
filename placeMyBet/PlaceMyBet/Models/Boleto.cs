using System;

namespace PlaceMyBet.Models
{
    public class Boleto
    {
        public Boleto(int id, int usuario, double importe, DateTime fecha)
        {
            Id = id;
            Usuario = usuario;
            Importe = importe;
            Fecha = fecha;
        }

        public int Id { get; set; }

        public int Usuario { get; set; }

        public double Importe { get; set; }

        public DateTime Fecha { get; set; }
    }

    public class BoletoDTO
    {
        public BoletoDTO(int usuario, double importe, DateTime fecha)
        {
            Usuario = usuario;
            Importe = importe;
            Fecha = fecha;
        }

        public int Usuario { get; set; }

        public double Importe { get; set; }

        public DateTime Fecha { get; set; }
    }
}