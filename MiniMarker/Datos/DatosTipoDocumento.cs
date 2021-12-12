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
        private string tipo_doc_nombre;

        public int Id_tipoDocumento { get => id_tipoDocumento; set => id_tipoDocumento = value; }
        public string Tipo_doc_nombre { get => tipo_doc_nombre; set => tipo_doc_nombre = value; }  


        public DatosTipoDocumento()
        {

        }

        public DatosTipoDocumento(int idTipoDocumento)
        {
            this.Id_tipoDocumento = id_tipoDocumento;
            this.Tipo_doc_nombre = tipo_doc_nombre;
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
                P_IdtipoDocumento.ParameterName = "@ID_TIPODOCUMENTO";
                P_IdtipoDocumento.SqlDbType = SqlDbType.Int;
                P_IdtipoDocumento.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(P_IdtipoDocumento);
                
                sqlParameter P_tipodocnombre = new Sqlparameter();
                P_tipodocnombre.ParameterName = "@TIPO_DOC_NOMBRE";
                P_tipodocnombre.sqlDbType = sqlDbtype.Varchar;
                P_tipodocnombre.Size = 20;
                P_tipodocnombre.Value = tipoDocumento.Tipo_doc_nombre;
                sqlcmd.Parameters.add(P_tipodocnombre);


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
                P_IdtipoDocumento.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(P_IdtipoDocumento);

                sqlParameter P_tipodocnombre = new Sqlparameter();
                P_tipodocnombre.ParameterName = "@TIPO_DOC_NOMBRE";
                P_tipodocnombre.sqlDbType = sqlDbtype.Varchar;
                P_tipodocnombre.Size = 20;
                P_tipodocnombre.Value = tipoDocumento.Tipo_doc_nombre;
                sqlcmd.Parameters.add(P_tipodocnombre);


                sqlParameter_P

                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "Actualizar con exito!" :
                    "Resgistro no actualizadp";
            }
            catch (Exception e)
            {

                respuesta = e.Message;
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
            catch (Exception e)
            {
                respuesta = e.Message;

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
            catch (Exception e)
            {

                LisRegistros = null;
            }
            return LisRegistros;
        }
    }
}
