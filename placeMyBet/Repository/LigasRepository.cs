using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PlaceMyBet.Constants;

namespace placeMyBet.Models
{
    public class LigasRepository
    {
        private MySqlConnection Connect()
        {
            MySqlConnection con = new MySqlConnection("Server=34.219.191.133;Port=3306;Database=placemybet;Uid=examen;password=examen;SslMode=none");
            return con;
        }

        internal List<LigasDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM leagues";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                LigasDTO liga = null;
                List<LigasDTO> ligas = new List<LigasDTO>();
                while (res.Read())
                {
                    liga = new LigasDTO(res.GetString(3), res.GetString(1));
                    ligas.Add(liga);
                }

                con.Close();
                return ligas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }
    }
}