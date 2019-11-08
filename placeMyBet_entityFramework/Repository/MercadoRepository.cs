using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using placeMyBet.Models;
using PlaceMyBet.Constants;

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

        internal List<MercadoDTO> RetrieveDTO()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from mercado";

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
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "insert into mercado(partidoId, tipo, cUnder, cOver) values ('" + m.PartidoId + "','" + m.Tipo + "','" + m.CUnder + "','" + m.COver + "');";

            //try
            //{
            //    con.Open();
            //    command.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error al conectar con la base de datos");
            //}
        }
    }
}