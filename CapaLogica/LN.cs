using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaLogica.Entidades;

namespace CapaLogica
{


    public class LN
    {

        public AccesoSQL acceso;
        private string conexion;


        public LN(string cdn) //Constructor
        {
            conexion = cdn;
            acceso = new AccesoSQL(cdn);
        }


        public string Open() //Metodo abrir conexion
        {
            string msj = "";
            acceso.AbrirConexion(ref msj);
            return msj;
        }



        

        public DataTable VerObra(ref string msgSalida)
        {
            string query = "SELECT o.ID_Obra, o.Nom_Obra, o.Direccion, o.Fecha_Inicio, " +
                "o.Fecha_Termino, du.Nombre_Dueno, enca.Nom_Encargado " +
                " FROM obra o " +
                "INNER JOIN dueno du " +
                "  ON o.ID_Dueno = du.ID_Dueno " +
                "INNER JOIN EncargadoObra enca " +
                "ON o.ID_Encargado = enca.ID_Encargado";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = acceso.ConsultaDS(query, acceso.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

        public Boolean InsertarObra(string nombre, string direccion, DateTime inicio, DateTime fin, int dueño, int encargado)
        {
            Boolean salida = false;
            string msj = "";
            List<SqlParameter> listaP = new List<SqlParameter>();
            string query = "Insert into Obra (Nom_Obra, Direccion, Fecha_Inicio, Fecha_Termino, ID_Dueno, ID_Encargado)"
                            + "VALUES(@nombre, @direccion, @inicio, @fin, @dueño, @encargado); ";
            listaP.Add(new SqlParameter()
            {
                ParameterName = "nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = nombre
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "direccion",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = direccion
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "inicio",
                SqlDbType = SqlDbType.DateTime,
                Value = inicio
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fin",
                SqlDbType = SqlDbType.DateTime,
                Value = fin
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "dueño",
                SqlDbType = SqlDbType.Int,
                Value = dueño

            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "encargado",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Value = encargado
            });
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public List<Dueno> SelectDueno(ref string msj)
        {
            string query = "SELECT * FROM Dueno;";//consulta en la tabla cuatrimestre

            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query, acceso.AbrirConexion(ref msj), ref msj);

            List<Dueno> listSalida = new List<Dueno>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Entidades.Dueno
                    {
                        ID_Dueno = (int)atrapaDatos[0],
                        Nombre_Dueno = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            return listSalida;
        }

        public List<EncargadoObra> SelectEncargado(ref string msj)
        {
            string query = "SELECT * FROM EncargadoObra;";//consulta en la tabla cuatrimestre

            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query, acceso.AbrirConexion(ref msj), ref msj);

            List<EncargadoObra> listSalida = new List<EncargadoObra>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Entidades.EncargadoObra
                    {
                        ID_Encargado = (int)atrapaDatos[0],
                        Nom_Encargado = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            return listSalida;
        }

        public Boolean BorrarObra(string id)
        {
            string query = "DELETE FROM Obra where ID_Obra = " + id;
            string msj = "";
            Boolean salida = false;
            List<SqlParameter> listaP = new List<SqlParameter>();
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public List<TipoMaterial> getTiposMaterial(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from TipoMaterial";

            cnTemp = acceso.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<TipoMaterial> listSalida = new List<TipoMaterial>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new TipoMaterial
                    {
                        ID_Tipo = (int)atrapaDatos[0],
                        tipo = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }


        public List<Material> getMaterial(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Material";

            cnTemp = acceso.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<Material> listSalida = new List<Material>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Material
                    {
                        idMAterial = (int)atrapaDatos[0],
                        desc = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }

        public List<Obra> getObra(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Obra";

            cnTemp = acceso.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<Obra> listSalida = new List<Obra>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Obra
                    {
                        idObra = (int)atrapaDatos[0],
                        obra = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }

        public List<Proveedor> getProveedor(ref string msgSalida)
        {
            SqlConnection cnTemp = null;
            string query1 = "Select * from Proveedor";

            cnTemp = acceso.AbrirConexion(ref msgSalida);
            SqlDataReader atrapaDatos = null;

            atrapaDatos = acceso.ConsultarReader(query1, cnTemp, ref msgSalida);

            List<Proveedor> listSalida = new List<Proveedor>();

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    listSalida.Add(new Proveedor
                    {
                        idProveedor = (int)atrapaDatos[0],
                        proveedor = (string)atrapaDatos[1]
                    });
                }

            }
            else
            {
                listSalida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return listSalida;
        }


        public ProveeMateObra getRegId(string name, ref string msg)
        {
            SqlConnection cnTemp = null;
            string query1 = "select * from Provee_De_Materi_Obra where recibio  = '"+ name.Trim() + "'";
            cnTemp = acceso.AbrirConexion(ref msg);
            SqlDataReader atrapaDatos = null;
            ProveeMateObra salida = new ProveeMateObra();

            atrapaDatos = acceso.ConsultarReader(query1, cnTemp, ref msg);

            if (atrapaDatos != null)
            {
                while (atrapaDatos.Read())
                {
                    salida.Recibio = (string)atrapaDatos[0];
                    salida.Entrega = (string)atrapaDatos[1];
                    salida.Cantidad = (int)atrapaDatos[2];
                    salida.FechaEntre = (DateTime)atrapaDatos[3];
                    salida.Precio = Convert.ToDouble(atrapaDatos[4]);
                    salida.idobra = (int)atrapaDatos[5];
                    salida.idmaterial = (int)atrapaDatos[6];
                    salida.idproveedor = (int)atrapaDatos[7];
                }
            }
            else
            {
                salida = null;
            }

            cnTemp.Close();
            cnTemp.Dispose();

            return salida;

        }

        public DataTable getMaterialDataSet(ref string msgSalida)
        {
            string query1 = "select Descripcion_Mat, Marca, Presentacion, TipoMaterial.Tipo  " +
                "from Material " +
                "INNER JOIN TipoMaterial on Material.ID_Tipo = TipoMaterial.ID_Tipo";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = acceso.ConsultaDS(query1, acceso.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }


        public DataTable getProvMatObraDataSet(ref string msgSalida)
        {
            string query1 = "select Recibio, Entrega, Cantidad, Fecha_Entre, Precio, Obra.Nom_Obra, Material.Descripcion_Mat, Proveedor.Correo_Proveedor " +
                "from Provee_De_Materi_Obra  " +
                "Inner JOIN Obra on Provee_De_Materi_Obra.ID_Obra = Obra.ID_Obra " +
                "inner join Material on Provee_De_Materi_Obra.ID_Material = Material.ID_Material " +
                "inner join Proveedor on Provee_De_Materi_Obra.ID_Proveedor = Proveedor.ID_Proveedor";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = acceso.ConsultaDS(query1, acceso.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

        public DataTable getObraByDuenoDataSet(ref string msgSalida, int duenio)
        {
            string query1 = "select Nom_Obra , Direccion, Fecha_Inicio, Fecha_Termino, EncargadoObra.Nom_Encargado  " +
                "from Obra   " +
                "inner join EncargadoObra on Obra.ID_Encargado = EncargadoObra.ID_Encargado " +
                "where ID_Dueno =  " + duenio;
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = acceso.ConsultaDS(query1, acceso.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }
        public DataTable getDuenoDataSet(ref string msgSalida)
        {
            string query1 = "select ID_Dueno, Nombre_Dueno, Telefono, Correo, Empresa from Dueno";
            DataTable salida = null;
            DataSet contenedor = null;
            contenedor = acceso.ConsultaDS(query1, acceso.AbrirConexion(ref msgSalida), ref msgSalida);
            if (contenedor != null)
            {
                salida = contenedor.Tables[0];
            }
            return salida;
        }

        public Boolean InsertarMaterial(string descMaterial, string marca, string presrntacion, int idTipo)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO Material (Descripcion_Mat, Marca, Presentacion, ID_Tipo)" +
                           "VALUES (@descMaterial, @marca, @presrntacion, @idTipo);";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "descMaterial",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = descMaterial
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "marca",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = marca
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "presrntacion",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = presrntacion
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "idTipo",
                SqlDbType = SqlDbType.Int,
                Value = idTipo
            });

            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }

        public Boolean InsertarProveMatObra(string recibio, string entrega, int cantidad, DateTime fechaEntrega,
            float precio, int idObra,
            int idMaterial, int idProvee)
        {
            Boolean salida = false;
            string msj = "";
            string query = "INSERT INTO Provee_De_Materi_Obra (Recibio, Entrega, Cantidad, Fecha_Entre, Precio, ID_Obra, ID_Material, ID_Proveedor)" +
                           " VALUES (@recibio, @entrega, @cantidad, @fechaEntrega, @precio, @idObra, @idMaterial, @idProvee);";
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "recibio",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = recibio
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "entrega",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = entrega
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "cantidad",
                SqlDbType = SqlDbType.Int,
                Value = cantidad
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fechaEntrega",
                SqlDbType = SqlDbType.DateTime,
                Value = fechaEntrega
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "precio",
                SqlDbType = SqlDbType.Float,
                Value = precio
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "idObra",
                SqlDbType = SqlDbType.Int,
                Value = idObra
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "idMaterial",
                SqlDbType = SqlDbType.Int,
                Value = idMaterial
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "idProvee",
                SqlDbType = SqlDbType.Int,
                Value = idProvee
            });

            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }


        public Boolean UpdateProveMatObra(string recibio, string entrega, int cantidad, DateTime fechaEntrega,
            float precio, int idObra,
            int idMaterial, int idProvee, string name)
        {
            Boolean salida = false;
            string msj = "";
            
            List<SqlParameter> listaP = new List<SqlParameter>();

            listaP.Add(new SqlParameter()
            {
                ParameterName = "recibio",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = recibio
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "entrega",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Value = entrega
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "cantidad",
                SqlDbType = SqlDbType.Int,
                Value = cantidad
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "fechaEntrega",
                SqlDbType = SqlDbType.DateTime,
                Value = fechaEntrega
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "precio",
                SqlDbType = SqlDbType.Float,
                Value = precio
            });

            listaP.Add(new SqlParameter()
            {
                ParameterName = "idObra",
                SqlDbType = SqlDbType.Int,
                Value = idObra
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "idMaterial",
                SqlDbType = SqlDbType.Int,
                Value = idMaterial
            });
            listaP.Add(new SqlParameter()
            {
                ParameterName = "idProvee",
                SqlDbType = SqlDbType.Int,
                Value = idProvee
            });

            
            string query = "UPDATE Provee_De_Materi_Obra SET Recibio = @recibio, Entrega = @entrega, Cantidad = @cantidad, Fecha_Entre = @fechaEntrega, " +
                "Precio = @precio, ID_Obra = @idObra, ID_Material = @idMaterial, ID_Proveedor = @idProvee WHERE Recibio = '" + name.Trim() + "'";
            salida = acceso.Modificar(acceso.AbrirConexion(ref msj), query, ref msj, listaP);
            return salida;
        }
    }
}
