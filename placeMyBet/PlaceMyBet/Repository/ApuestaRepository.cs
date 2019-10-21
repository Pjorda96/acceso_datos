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
            string comnString = "Server=127.0.0.1;Port=3306;Database=placeMyBet;Uid=root;password=;SslMode=none";
            //string comnString = "Server=tcp:place-my-bet.database.windows.net,1433;InitialCatalog=PlaceMyBet;PersistSecurityInfo=False;UserID=placeMyBet;Password=2dawApuesta;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;ConnectionTimeout=30;";
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
                    a = new Apuesta(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetInt32(3), res.GetDouble(4), res.GetInt32(5), res.GetDateTime(6));
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
            command.CommandText = "SELECT email, tipoApuesta, cuota, tipo, importe FROM apuesta INNER JOIN usuario INNER JOIN mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetDouble(2), res.GetInt32(3), res.GetDouble(4));
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
            command.CommandText = "insert into partido(usuario, importe, mercado, cuota, tipo, fecha) values ('" + a.UsuarioId + "','" + a.Importe + "','" + a.MercadoId + a.Cuota + +a.TipoApuesta + a.Fecha +"');";

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                //this.Recalculate(a.MercadoId);
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
            }
        }

        //internal void Recalculate(int mercadoId)
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();

        //    try
        //    {
        //        con.Open();
        //        command.CommandText = "get sum(importe) from boleto;";
        //        MySqlDataReader resOver = command.ExecuteReader();
        //        resOver = resOver * 0.4; // pending to refactor

        //        Debug.WriteLine(resOver);
        //        command.CommandText = "get sum(importe) from boleto;";
        //        MySqlDataReader resUnder = command.ExecuteReader();
        //        resOver = resUnder * 0.6; // pending to refactor

        //        var total = resOver + resUnder;

        //        var probOver = resOver / total;
        //        var cuotaOver = 0.95 / probOver;

        //        var probUnder = resOver / total;
        //        var cuotaUnder = 0.95 / probUnder;

        //        command.CommandText = "update mercado set cOver = " + cuotaOver + ", cUnder = " + cuotaUnder + " where id = " + mercadoId + " ;";
        //        con.Close();
        //    }
        //    catch (MySqlException e)
        //    {
        //        Debug.WriteLine("Error al conectar con la base de datos");
        //    }
        //}
    }
}