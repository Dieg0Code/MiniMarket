using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosTipoDocumento
    {
        private int id_tipoDocumento;

        public int Id_tipoDocumento { get => id_tipoDocumento; set => id_tipoDocumento = value; }


        public DatosTipoDocumento()
        {

        }

        public DatosTipoDocumento(int idTipoDocumento)
        {
            this.Id_tipoDocumento = id_tipoDocumento;
        }
        string respuesta;

        SqlConnection sqlconexion = new SqlConnection();

        SqlCommand sqlcmd = new SqlCommand();

        public string guardar(DatosTipoDocumento tipoDocumento)
        {
            try
            {
                sqlconexion.ConnectionString = Conexion.Conex;
                sqlconexion.Open();
                sqlcmd.Connection = sqlconexion;
                sqlcmd.CommandText = "spguardar_tipoDocumento";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdtipoDocumento = new SqlParameter();
                P_IdtipoDocumento.ParameterName = "@ID_CIUDAD";
                P_IdtipoDocumento.SqlDbType = SqlDbType.Int;
                P_IdtipoDocumento.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(P_IdtipoDocumento);


                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "Guardado con exito!" :
                    "Registro no guardado";
            }
            catch (Exception a)
            {

                respuesta = a.Message;

            }
            finally
            {
                if (sqlconexion.State == ConnectionState.Open)
                {
                    sqlconexion.Close();
                }
            }
            return respuesta;
        }
        public string Actualizar(DatosTipoDocumento tipoDocumento)
        {
            try
            {
                sqlconexion.ConnectionString = Conexion.Conex;
                sqlconexion.Open();
                sqlcmd.Connection = sqlconexion;
                sqlcmd.CommandText = "spactualizar_tipoDocumento";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdtipoDocumento = new SqlParameter();
                P_IdtipoDocumento.ParameterName = "@ID_TIPODOCUMENTO";
                P_IdtipoDocumento.SqlDbType = SqlDbType.Int;
                P_IdtipoDocumento.Value = tipoDocumento.Id_tipoDocumento;
                sqlcmd.Parameters.Add(P_IdtipoDocumento);

                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "Actualizar con exito!" :
                    "Resgistro no actualizadp";
            }
            catch (Exception a)
            {

                respuesta = a.Message;
            }
            finally
            {
                if (sqlconexion.State == ConnectionState.Open)
                {
                    sqlconexion.Close();
                }
            }
            return respuesta;
        }

        public string Eliminar(DatosTipoDocumento tipoDocumento)
        {
            try
            {
                sqlconexion.ConnectionString = Conexion.Conex;
                sqlconexion.Open();
                sqlcmd.Connection = sqlconexion;
                sqlcmd.CommandText = "speliminar_tipoDocumento";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdtipoDocumento = new SqlParameter();
                P_IdtipoDocumento.ParameterName = "@ID_TIPODOCUMENTO";
                P_IdtipoDocumento.SqlDbType = SqlDbType.Int;
                P_IdtipoDocumento.Value = tipoDocumento.id_tipoDocumento;
                sqlcmd.Parameters.Add(P_IdtipoDocumento);

                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "eliminado con exito!" :
                    "registro no eliminado";
            }
            catch (Exception a)
            {
                respuesta = a.Message;

            }
            finally
            {
                if (sqlconexion.State == ConnectionState.Open)
                {
                    sqlconexion.Close();
                }
            }
            return respuesta;
        }
        public DataTable listar()
        {
            DataTable LisRegistros = new DataTable("TIPODOCUMENTO");
            try
            {
                sqlconexion.ConnectionString = Conexion.Conex;
                sqlcmd.Connection = sqlconexion;
                sqlcmd.CommandText = "spmostrar_tipociudad";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcmd);
                sqladapter.Fill(LisRegistros);
            }
            catch (Exception a)
            {

                LisRegistros = null;
            }
            return LisRegistros;
        }
    }
}
