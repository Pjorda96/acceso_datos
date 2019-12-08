using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using placeMyBet.Models;

namespace PlaceMyBet.Models
{
    public class MercadoRepository
    {
        internal List<Mercado> Retrieve()
        {
            var mercados = new List<Mercado>();

            using (var context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.ToList();
            }

            return mercados;
        }

        internal Mercado Retrieve(int id)
        {
            var mercado = new Mercado();

            using (var context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(m => m.Id == id)
                    .FirstOrDefault();
            }

            return mercado;
        }

        public MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.Tipo, m.CUnder, m.COver);
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            var mercados = new List<MercadoDTO>();

            using (var context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Select(m => ToDTO(m)).ToList();
            }

            return mercados;
        }

        internal List<MercadoDTO> RetrieveByPartido(int id)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "SELECT tipo, cOver, cUnder FROM mercado WHERE partido = " + id;

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    MercadoDTO m = null;
            //    List<MercadoDTO> mercados = new List<MercadoDTO>();
            //    while (res.Read())
            //    {
            //        Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetInt32(2) + " " + res.GetInt32(3) + " " + res.GetDouble(4));
            //        m = new MercadoDTO(res.GetInt32(2), res.GetInt32(3), res.GetDouble(4));
            //        mercados.Add(m);
            //    }

            //    con.Close();
            //    return mercados;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error al conectar con la base de datos");
            //    return null;
            //}

            return null;
        }

        internal void Save(Mercado m)
        {
            try
            {
                using (var context = new PlaceMyBetContext())
                {
                    var mercado = new Mercado
                    {
                        Tipo = m.Tipo,
                        COver = m.COver,
                        CUnder = m.CUnder,
                        PartidoId = m.PartidoId
                    };
                    context.Mercados.Add(mercado);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error al añadir un mercado");
            }
        }
    }
}