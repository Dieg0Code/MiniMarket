using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    class DatosCategoria
    {
        private int id_categoria;
        private string cat_nombre;

        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Cat_nombre { get => cat_nombre; set => cat_nombre = value; }

        public DatosCategoria()
        {

        }

        public DatosCategoria(int idCategoria, string catNombre)
        {
            this.Id_categoria = idCategoria;
            this.Cat_nombre = cat_nombre;
        }

        string respuesta;

        SqlConnection sqlConexion = new SqlConnection();

        SqlCommand sqlCmd = new SqlCommand();

        public string Guardar(DatosCategoria categoria)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spguardar_categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdCategoria = new SqlParameter();
                P_IdCategoria.ParameterName = "@ID_CATEGORIA";
                P_IdCategoria.SqlDbType = SqlDbType.Int;
                P_IdCategoria.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(P_IdCategoria);

                SqlParameter P_CatNombre = new SqlParameter();
                P_CatNombre.ParameterName = "@CAT_NOMBRE";
                P_CatNombre.SqlDbType = SqlDbType.VarChar;
                P_CatNombre.Size = 20;
                P_CatNombre.Value = categoria.Cat_nombre;
                sqlCmd.Parameters.Add(P_CatNombre);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ? "Guardado con exito!!" : "Registro no guardado";
            }
            catch (Exception e)
            {

                respuesta = e.Message;
            }

            finally
            {
                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();

                }
            }

            return respuesta;
        }

        public string Actualizar (DatosCategoria categoria)
        {
            try
            {
                // DB connection
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spactualizar_categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // SP config
                SqlParameter P_IdCategoria = new SqlParameter();
                P_IdCategoria.ParameterName = "@ID_CATEGORIA";
                P_IdCategoria.SqlDbType = SqlDbType.Int;
                P_IdCategoria.Value = categoria.Id_categoria;
                sqlCmd.Parameters.Add(P_IdCategoria);

                SqlParameter P_CatNombre = new SqlParameter();
                P_CatNombre.ParameterName = "@CAT_NOMBRE";
                P_CatNombre.SqlDbType = SqlDbType.VarChar;
                P_CatNombre.Size = 20;
                P_CatNombre.Value = categoria.Cat_nombre;
                sqlCmd.Parameters.Add(P_CatNombre);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ? "Actualizado con exito!!" : "Registro no actualizado";
            }
            catch (Exception e)
            {

                respuesta = e.Message;
            }

            finally
            {
                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();

                }
            }

            return respuesta;
        }

        public string Eliminar (DatosCategoria categoria)
        {
            try
            {
                // DB connection
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "speliminar_categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // SP config
                SqlParameter P_IdCategoria = new SqlParameter();
                P_IdCategoria.ParameterName = "@ID_CATEGORIA";
                P_IdCategoria.SqlDbType = SqlDbType.Int;
                P_IdCategoria.Value = categoria.Id_categoria;
                sqlCmd.Parameters.Add(P_IdCategoria);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ? "Eliminado con exito!!" : "Registro no eliminado";
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            finally
            {
                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();
                }
            }

            return respuesta;
        }

        public DataTable Listar()
        {
            DataTable LisRegistros = new DataTable("CATEGORIA");
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "sqmostrar_categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlAdapter.Fill(LisRegistros);
            }
            catch (Exception e)
            {

                LisRegistros = null;
            }

            return LisRegistros;
        }

    }
}
