using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            string comnString = "Server=127.0.0.1;Port=3306;Database=dam;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(comnString);
            return con;
        }

        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetInt32(3) + " " + res.GetInt32(4));
                    a = new Apuesta(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetInt32(3), res.GetInt32(4));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetInt32(3));
                    a = new ApuestaDTO(res.GetInt32(1), res.GetDouble(2));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }

        internal void Save(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into partido(mercado, cuota, boleto) values ('" + a.MercadoId + "','" + a.Cuota + "','" + a.BoletoId + "');";

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                this.Recalculate(a.MercadoId);
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
            }
        }

        internal void Recalculate(int mercadoId)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "get sum(importe) from boleto;";
                MySqlDataReader resOver = command.ExecuteReader();
                resOver = resOver * 0.4; // pending to refactor

                Debug.WriteLine(resOver);
                command.CommandText = "get sum(importe) from boleto;";
                MySqlDataReader resUnder = command.ExecuteReader();
                resOver = resUnder * 0.6; // pending to refactor

                var total = resOver + resUnder;

                var probOver = resOver / total;
                var cuotaOver = 0.95 / probOver;

                var probUnder = resOver / total;
                var cuotaUnder = 0.95 / probUnder;

                command.CommandText = "update mercado set cOver = " + cuotaOver + ", cUnder = " + cuotaUnder + " where id = " + mercadoId + " ;";
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
            }
        }
    }
}