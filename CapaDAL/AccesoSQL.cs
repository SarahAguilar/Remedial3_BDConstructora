using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class AccesoSQL
    {
        private string cadConexion;
        public AccesoSQL(string cadenaBD)
        {
            cadConexion = cadenaBD;
        }
        public SqlConnection AbrirConexion(ref string mensaje) // Metodo con parametros de referencia
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = cadConexion;
            try
            {
                conexion1.Open();
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                conexion1 = null; //Devuelve una conexion nula
                mensaje = "Error: " + r.Message;
            }
            return conexion1;
        }

        public void CerrarConexion(SqlConnection conAbierta)
        {
            if (conAbierta != null) //Si la conexion es diferente de null
            {
                if (conAbierta.State == ConnectionState.Open) //Si el estado de la conexion es igual a abierta
                {
                    conAbierta.Close();//Cierra la conexion
                    conAbierta.Dispose();//Se destruye
                }
            }

        }



        public DataSet ConsultaDS(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                DS_salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(DS_salida, "Consulta1");
                    mensaje = "Consulta Correcta en DataSet";
                }
                catch (Exception a)
                {
                    DS_salida = null;
                    mensaje = "Error!" + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return DS_salida;
        }

        public SqlDataReader ConsultarReader(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                try
                {
                    contenedor = carrito.ExecuteReader();
                    mensaje = "Consulta Correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    mensaje = "Error!" + a.Message;
                }
            }
            return contenedor;
        }

        public Boolean MultiplesConsultasDataSet(string querySql, SqlConnection conAbierta, ref string mensaje, ref DataSet dataset1, string nomConsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(dataset1, nomConsulta);
                    mensaje = "Consulta correcta en el DataSet";
                    salida = true;
                }
                catch (Exception a)
                {
                    mensaje = "Error: " + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return salida;
        }

        public bool Modificar(SqlConnection conAbierta, string sentenciaSQL, ref string msj, List<SqlParameter> lista)
        {
            SqlCommand carrito = null; //Crea el comando
            Boolean salida = false;
            AbrirConexion(ref msj);
            if (conAbierta != null)
            {
                carrito = new SqlCommand();
                carrito.CommandText = sentenciaSQL;
                carrito.Connection = conAbierta;
                foreach (SqlParameter temp in lista)
                {
                    carrito.Parameters.Add(temp);
                }
                try
                {
                    carrito.ExecuteNonQuery(); //Realiza cambios de la base
                    salida = true;
                    // msj = "Modificación correcta";
                }
                catch (Exception e)
                {
                    salida = false;
                    // msj = "Error" + e.Message;
                }
            }
            else
            {
                salida = false;
            }
            return salida;
        }






    }
}
