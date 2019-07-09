using PruebaHpTronic.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades_Albert;

namespace PruebaHpTronic.BLL
{
    public class TransaccionesBLL
    {
        public static bool Operacion(List<Transacciones> cobros)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            bool paso = false;
            var BaseDatosTransacciones = GetListBuscar(cobros.ElementAt(0).Id_Banco);
            try
            {
                //Esto es para Eliminar la Transaccion que no exista en la lista de Transacciones pasada por parametro
                foreach (var item in BaseDatosTransacciones)
                {
                    if(!cobros.Exists(x=>x.Id == item.Id))
                    {
                        Eliminar(item.Id);
                    }
                }


                conexion.Open();
                foreach (var item in cobros)
                {


                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = "OperacionTransacciones";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Id", item.Id);
                    comando.Parameters.AddWithValue("@Id_Banco", item.Id_Banco);
                    comando.Parameters.AddWithValue("@Tipo", item.Tipo);
                    comando.Parameters.AddWithValue("@Fecha", item.Fecha);
                    comando.Parameters.AddWithValue("@Detalle", item.Detalle);
                    comando.Parameters.AddWithValue("@Monto", item.Monto);

                    comando.ExecuteNonQuery();
                }
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
                comando.CommandText = "EliminarTransaccion";
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


        public static List<Transacciones> GetListBuscar(int Id_Banco)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            List<Transacciones> users = new List<Transacciones>();
            try
            {
                string cadena = string.Empty;
                conexion.Open();

                cadena = "SELECT * FROM Transacciones  WHere Id_Banco = "+Id_Banco;


                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    users.Add(new Transacciones(registro["Id"].Toint(), registro["Id_Banco"].Toint(), registro["Tipo"].ToString(), registro["Fecha"].Todatetime(),
                        registro["Detalle"].ToString(), registro["Monto"].Todecimal()));
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

        public static List<Transacciones> GetListBuscar(int Id_Banco,DateTime desde,DateTime hasta)
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            List<Transacciones> users = new List<Transacciones>();
            try
            {
                string cadena = string.Empty;
                conexion.Open();

                cadena = "SELECT * FROM Transacciones  WHere Id_Banco = " + Id_Banco + " AND Fecha BETWEEN "+ desde.ToSqlDate()+ " AND "+ hasta.ToSqlDate();


                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    users.Add(new Transacciones(registro["Id"].Toint(), registro["Id_Banco"].Toint(), registro["Tipo"].ToString(), registro["Fecha"].Todatetime(),
                        registro["Detalle"].ToString(), registro["Monto"].Todecimal()));
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

        public static List<Transacciones> GetListBuscar()
        {
            SqlConnection conexion = new SqlConnection("server=AlbertLopezG\\sqlexpress; database=Finanzas; integrated security = true");
            List<Transacciones> users = new List<Transacciones>();
            try
            {
                string cadena = string.Empty;
                conexion.Open();

                cadena = "SELECT * FROM Transacciones";


                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    users.Add(new Transacciones(registro["Id"].Toint(), registro["Id_Banco"].Toint(), registro["Tipo"].ToString(), registro["Fecha"].Todatetime(),
                        registro["Detalle"].ToString(), registro["Monto"].Todecimal()));
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
    }
}
