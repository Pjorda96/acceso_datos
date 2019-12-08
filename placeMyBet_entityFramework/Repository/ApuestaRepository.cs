using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using placeMyBet.Models;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        internal List<Apuesta> Retrieve()
        {
            var apuestas = new List<Apuesta>();

            using (var context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(a => a.Mercado).ToList();
            }

            return apuestas;
        }


        internal Apuesta Retrieve(int id)
        {
            var apuesta = new Apuesta();

            using (var context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas
                    .Where(a => a.Id == id)
                    .FirstOrDefault();
            }

            return apuesta;
        }

        public ApuestaDTO ToDTO(Apuesta a)
        {
            return new ApuestaDTO(a.UsuarioId, a.MercadoId, a.TipoApuesta, a.Cuota, a.Mercado.Tipo, a.Importe);
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            var apuestas = new List<ApuestaDTO>();

            using (var context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(a => a.Mercado).Select(a => ToDTO(a)).ToList();
            }

            return apuestas;
        }

        internal List<ApuestaDTO> RetrieveByUserEmail(string email)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT email, partido, tipo, tipoApuesta, cuota, importe FROM apuesta a JOIN usuario u JOIN mercado m WHERE email = '"
            //    + email + "' AND m.id = (SELECT mercado FROM apuesta JOIN usuario WHERE email = '"
            //    + email + "')";

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    ApuestaDTO a = null;
            //    List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            //    while (res.Read())
            //    {
            //        a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetInt32(2), res.GetDouble(3), res.GetInt32(4), res.GetDouble(5));
            //        apuestas.Add(a);
            //    }

            //    con.Close();
            //    return apuestas;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error al conectar con la base de datos");
            //    return null;
            //}

            return null;
        }

        internal List<ApuestaDTO> RetrieveByMercado(int mercado)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT email, partido, tipo, tipoApuesta, cuota, importe FROM apuesta a JOIN usuario u JOIN mercado m WHERE m.id = " + mercado;

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    ApuestaDTO a = null;
            //    List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            //    while (res.Read())
            //    {
            //        a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetInt32(2), res.GetDouble(3), res.GetInt32(4), res.GetDouble(5));
            //        apuestas.Add(a);
            //    }

            //    con.Close();
            //    return apuestas;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error al conectar con la base de datos");
            //    return null;
            //}

            return null;
        }

        internal void Save(Apuesta a)
        {
            try
            {
                using (var context = new PlaceMyBetContext())
                {
                    var apuesta = new Apuesta
                    {
                        UsuarioId = a.UsuarioId,
                        Importe = a.Importe,
                        MercadoId = a.MercadoId,
                        Cuota = a.Cuota,
                        TipoApuesta = a.TipoApuesta,
                        Fecha = a.Fecha,
                    };
                    context.Apuestas.Add(apuesta);
                    context.SaveChanges();

                    this.Recalculate(a.MercadoId);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error al añadir un apuesta");
            }
        }

        internal void Recalculate(int mercadoId)
        {
            try
            {
                using (var context = new PlaceMyBetContext())
                {
                    double resOver = context.Apuestas.Where(m1 => m1.MercadoId == mercadoId & m1.TipoApuesta == 0).Select(i1 => i1.Importe).Sum();
                    double resUnder = context.Apuestas.Where(m2 => m2.MercadoId == mercadoId & m2.TipoApuesta == 1).Select(i2 => i2.Importe).Sum();

                    double total = resOver + resUnder;

                    double probOver = resOver / total;
                    double cuotaOver = 0.95 / probOver;

                    double probUnder = resUnder / total;
                    double cuotaUnder = 0.95 / probUnder;

                    var mercado = context.Mercados.First(m => m.Id == mercadoId);
                    mercado.COver = cuotaOver;
                    mercado.CUnder = cuotaUnder;
                    context.SaveChanges();
                }
            }
                catch (Exception e)
            {
                Debug.WriteLine("Error al añadir un apuesta");
            }
        }
    }
}