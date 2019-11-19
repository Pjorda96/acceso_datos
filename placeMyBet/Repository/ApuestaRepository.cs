using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PlaceMyBet.Constants;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            MySqlConnection con = new MySqlConnection(MySQL.MySqlConnection);
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
            command.CommandText = "SELECT email, partido, tipoApuesta, cuota, tipo, importe FROM apuesta INNER JOIN usuario INNER JOIN mercado m WHERE m.id = mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetInt32(2), res.GetDouble(3), res.GetInt32(4), res.GetDouble(5));
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

        internal List<ApuestaDTO> RetrieveByUserEmail(string email)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT email, partido, tipo, tipoApuesta, cuota, importe FROM apuesta a JOIN usuario u JOIN mercado m WHERE email = '"
                + email + "' AND m.id = (SELECT mercado FROM apuesta JOIN usuario WHERE email = '"
                + email + "')";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetInt32(2), res.GetDouble(3), res.GetInt32(4), res.GetDouble(5));
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

        internal List<ApuestaDTO> RetrieveByMercado(int mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT email, partido, tipo, tipoApuesta, cuota, importe FROM apuesta a JOIN usuario u JOIN mercado m WHERE m.id = " + mercado;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetInt32(2), res.GetDouble(3), res.GetInt32(4), res.GetDouble(5));
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

        /*** Ejercicio 2 ***/
        internal List<ApuestaDTO> RetrieveByMercadoGt(int mercado, int cantidad)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT email, partido, tipo, tipoApuesta, cuota, importe FROM apuesta a JOIN usuario u JOIN mercado m WHERE m.id = " + mercado + " && importe > " + cantidad;

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetString(0), res.GetInt32(1), res.GetInt32(2), res.GetDouble(3), res.GetInt32(4), res.GetDouble(5));
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
        /*** Fin Ejercicio 2 ***/

        /*** Ejercicio 3 ***/
        internal string Save(Apuesta a)
        {
            /*** Fin Ejercicio 3 ***/
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            
            if (a.TipoApuesta == 0)
            {
                command.CommandText = "SELECT cOver FROM mercado WHERE id = " + a.MercadoId;
            }
            else if (a.TipoApuesta == 1)
            {
                command.CommandText = "SELECT cUnder FROM mercado WHERE id = " + a.MercadoId;
            }

            double cuota = 0.0;
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                while (res.Read())
                {
                    cuota = res.GetDouble(0);
                }

                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return "Error al conectar con la base de datos";
            }

            command.CommandText = "insert into apuesta(usuario, importe, mercado, cuota, tipoApuesta, fecha) values (" + a.UsuarioId + "," + a.Importe + "," + a.MercadoId + "," + cuota.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," +a.TipoApuesta + ",'" + a.Fecha + "');";

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                this.Recalculate(a.MercadoId);

                /*** Ejercicio 3 ***/
                con.Open();
                command.CommandText = "SELECT COUNT(id) FROM apuesta";
                MySqlDataReader res = command.ExecuteReader();

                int apuestasNumber = 0;
                while (res.Read())
                {
                    apuestasNumber = res.GetInt32(0);
                }

                return "El usuario tiene " + apuestasNumber + " apuestas actualmente";
                /*** Ejercicio 3 ***/
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar con la base de datos");
                return "Error al conectar con la base de datos";
            }
        }

        internal void Recalculate(int mercadoId)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "SELECT sum(importe) from apuesta WHERE tipoApuesta = 0;";
                MySqlDataReader queryOver = command.ExecuteReader();
                int resOver = 0;
                while (queryOver.Read())
                {
                    resOver = queryOver.GetInt32(0);
                }
                con.Close();
                
                con.Open();
                command.CommandText = "SELECT sum(importe) from apuesta WHERE tipoApuesta = 1;";
                MySqlDataReader queryUnder = command.ExecuteReader();
                int resUnder = 0;
                while (queryUnder.Read())
                {
                    resUnder = queryUnder.GetInt32(0);
                }
                con.Close();

                double total = resOver + resUnder;

                double probOver = resOver / total;
                double cuotaOver = 0.95 / probOver;

                double probUnder = resUnder / total;
                double cuotaUnder = 0.95 / probUnder;

                con.Open();
                command.CommandText = "update mercado set cOver = " + cuotaOver.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", cUnder = " + cuotaUnder.ToString(System.Globalization.CultureInfo.InvariantCulture) + " where id = " + mercadoId + " ;";
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