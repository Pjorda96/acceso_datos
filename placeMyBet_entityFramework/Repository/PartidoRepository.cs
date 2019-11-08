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
    public class PartidoRepository
    {
        internal List<Partido> Retrieve()
        {
            var partidos = new List<Partido>();

            using (var context = new PlaceMyBetContext())
            {
                partidos = context.Partidos.ToList();
            }

            return partidos;
        }

        internal Partido Retrieve(int id)
        {
            var partido = new Partido();

            using (var context = new PlaceMyBetContext())
            {
                partido = context.Partidos
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }

            return partido;
        }

        internal List<PartidoDTO> RetrieveDTO()
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from partido";

            //try
            //{
            //    con.Open();
            //    MySqlDataReader res = command.ExecuteReader();

            //    PartidoDTO p = null;
            //    List<PartidoDTO> partidos = new List<PartidoDTO>();
            //    while (res.Read())
            //    {
            //        Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
            //        p = new PartidoDTO(res.GetString(1), res.GetString(2));
            //        partidos.Add(p);
            //    }

            //    con.Close();
            //    return partidos;
            //}
            //catch (MySqlException e)
            //{
            //    Debug.WriteLine("Error al conectar con la base de datos");
            //    return null;
            //}

            return null;
        }

        internal void Save(Partido p)
        {
            var context = new PlaceMyBetContext();

            context.Partidos.Add(p);
            context.SaveChanges();
        }
    }
}