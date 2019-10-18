using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PlaceMyBet.Models
{
    public class BoletoRepository
    {
        private MySqlConnection Connect()
        {
            string comnString = "Server=127.0.0.1;Port=3306;Database=dam;Uid=root;password=;SslMode=none";
            //"Server=tcp:place-my-bet.database.windows.net,1433;InitialCatalog=PlaceMyBet;PersistSecurityInfo=False;UserID=placeMyBet;Password=2dawApuesta;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;ConnectionTimeout=30;"
            MySqlConnection con = new MySqlConnection(comnString);
            return con;
        }

        internal List<Boleto> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from boleto";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Boleto b = null;
                List<Boleto> boletos = new List<Boleto>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDateTime(3));
                    b = new Boleto(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDateTime(3));
                    boletos.Add(b);
                }

                con.Close();
                return boletos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }

        internal List<BoletoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from boleto";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                BoletoDTO b = null;
                List<BoletoDTO> boletos = new List<BoletoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDateTime(3));
                    b = new BoletoDTO(res.GetInt32(1), res.GetDouble(2), res.GetDateTime(3));
                    boletos.Add(b);
                }

                con.Close();
                return boletos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return null;
            }
        }

        internal void Save(Boleto b)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into boleto(usuario, importe, fecha) values ('" + b.Usuario + "','" + b.Importe + "','" + b.Fecha + "');";

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