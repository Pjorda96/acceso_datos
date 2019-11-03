using placeMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int id, int usuarioId, double importe, int mercadoId, double cuota, int tipoApuesta, DateTime fecha)
        {
            Id = id;
            UsuarioId = usuarioId;
            Importe = importe;
            MercadoId = mercadoId;
            Cuota = cuota;
            TipoApuesta = tipoApuesta;
            Fecha = fecha;
        }

        public int Id { get; set; }

        public double Importe { get; set; }

        public double Cuota { get; set; }

        public int TipoApuesta { get; set; }

        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(String usuarioEmail, int partido, int tipoApuesta, double cuota, int tipo, double importe)
        {
            UsuarioEmail = usuarioEmail;
            Partido = partido;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            Tipo = tipo;
            Importe = importe;
        }

        public String UsuarioEmail { get; set; }

        public int Partido { get; set; }

        public int TipoApuesta { get; set; }

        public double Cuota { get; set; }

        public int Tipo { get; set; }

        public double Importe { get; set; }
    }
}