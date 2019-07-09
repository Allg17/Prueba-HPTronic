using PruebaHpTronic.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades_Albert;

namespace PruebaHpTronic.BLL
{
    public class BancoBLL
    {
        public static bool Insertar(Banco banco)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            bool paso = false;
            try
            {
                conexion.Open();

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "InsertarBanco";
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", banco.Nombre.ToSql());
                comando.Parameters.AddWithValue("@Cuenta", banco.Cuenta.ToSql());
                comando.ExecuteNonQuery();

                paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            bool paso = false;
            try
            {
                conexion.Open();

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "EliminarBanco";
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", Id);
                comando.ExecuteNonQuery();

                paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return paso;
        }

        public static bool Modificar(Banco banco)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            bool paso = false;
            try
            {
                conexion.Open();

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "ModificarBancos";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id", banco.Id);
                comando.Parameters.AddWithValue("@Nombre", banco.Nombre.ToSql());
                comando.Parameters.AddWithValue("@Cuenta", banco.Cuenta.ToSql());
                comando.ExecuteNonQuery();

                paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return paso;
        }

        public static List<Banco> GetListBuscar(string filtro, string criterio, DateTime fechaInicio, DateTime fechaFin)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            List<Banco> users = new List<Banco>();
            try
            {
                string cadena = string.Empty;
                conexion.Open();

                cadena = "SELECT * FROM Bancos WHERE Fecha BETWEEN " + fechaInicio.ToSqlDate() + "AND" + fechaFin.ToSqlDate();


                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    users.Add(new Banco(registro["Id"].Toint(), registro["Nombre"].ToString(), registro["Cuenta"].ToString()));
                }
                registro.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return users;
        }

        public static List<Banco> GetListBuscar(string criterio)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            List<Banco> users = new List<Banco>();
            try
            {
                string cadena = string.Empty;
                conexion.Open();

                cadena = "SELECT * FROM Bancos WHERE Nombre LIKE  " + criterio.ToSqlComillasLike();


                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    users.Add(new Banco(registro["Id"].Toint(), registro["Nombre"].ToString(), registro["Cuenta"].ToString()));
                }
                registro.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return users;
        }

        public static List<Banco> GetListBuscar()
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            List<Banco> users = new List<Banco>();
            try
            {
                string cadena = string.Empty;
                conexion.Open();

                cadena = "SELECT * FROM Bancos";


                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    users.Add(new Banco(registro["Id"].Toint(), registro["Nombre"].ToString(), registro["Cuenta"].ToString()));
                }
                registro.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return users;
        }

        public static DataTable GetListAll()
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            DataTable dt = new DataTable();
            try
            {
                conexion.Open();
                string cadena = "select b.Id,b.Nombre,b.Cuenta," +
                    "t.Id_Banco,t.Tipo,t.Fecha,t.Detalle,t.Monto from Bancos b inner join Transacciones t on b.Id = t.Id_Banco";

                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                dt.Clear();
                dt.Columns.Add("Id");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Cuenta");
                dt.Columns.Add("Id_Banco");
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Fecha");
                dt.Columns.Add("Detalle");
                dt.Columns.Add("Monto");

                while (registro.Read())
                {
                    DataRow Valores = dt.NewRow();

                    Valores["Id"] = registro["Id"].Toint();
                    Valores["Nombre"] = registro["Nombre"].ToString();
                    Valores["Cuenta"] = registro["Cuenta"].ToString();
                    Valores["Id_Banco"] = registro["Id_Banco"].Toint();
                    Valores["Tipo"] = registro["Tipo"].ToString();
                    Valores["Fecha"] = registro["Fecha"].Todatetime();
                    Valores["Detalle"] = registro["Detalle"].ToString();
                    Valores["Monto"] = registro["Monto"].Todecimal();
                    dt.Rows.Add(Valores);
                }
                registro.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return dt;
        }
    }
}
