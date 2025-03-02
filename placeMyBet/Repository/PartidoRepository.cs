﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PlaceMyBet.Constants;

namespace PlaceMyBet.Models
{
    public class PartidoRepository
    {
        private MySqlConnection Connect()
        {
            MySqlConnection con = new MySqlConnection(MySQL.MySqlConnection);
            return con;
        }

        internal List<Partido> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Partido p = null;
                List<Partido> partidos = new List<Partido>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    p = new Partido(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    partidos.Add(p);
                }

                con.Close();
                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }

        internal List<PartidoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                PartidoDTO p = null;
                List<PartidoDTO> partidos = new List<PartidoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    p = new PartidoDTO(res.GetString(1), res.GetString(2));
                    partidos.Add(p);
                }

                con.Close();
                return partidos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }

        internal void Save(Partido p)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into partido(local, visitante, hora) values ('" + p.Local + "','" + p.Visitante + "','" + p.Hora + "');";

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
            }
        }
    }
}