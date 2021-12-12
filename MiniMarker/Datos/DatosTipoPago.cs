    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
     public class DatosTipoPago
    {
        private int id_tipo_pago;
        private string tipo_pago_nombre;

        public int Id_tipo_pago { get => id_tipo_pago; set => id_tipo_pago = value; }
        public string Tipo_pago_nombre { get => tipo_pago_nombre; set => tipo_pago_nombre = value; }

        public DatosTipoPago()
        {

        }

        public DatosTipoPago (int idTipoPago, string tipoPagoNombre)
        {
            this.Id_tipo_pago = idTipoPago;
            this.Tipo_pago_nombre = tipoPagoNombre;
        }

        string respuesta;

        SqlConnection sqlConexion = new SqlConnection();

        SqlCommand sqlCmd = new SqlCommand();

        public string Guardar (DatosTipoPago tipoPago)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spguardar_tipoPago";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdTipoPago = new SqlParameter();
                P_IdTipoPago.ParameterName = "@ID_TIPO_PAGO";
                P_IdTipoPago.SqlDbType = SqlDbType.Int;
                P_IdTipoPago.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(P_IdTipoPago);

                SqlParameter P_TipoPagoNombre = new SqlParameter();
                P_TipoPagoNombre.ParameterName = "@TIPO_PAGO_NOMBRE";
                P_TipoPagoNombre.SqlDbType = SqlDbType.VarChar;
                P_TipoPagoNombre.Size = 15;
                P_TipoPagoNombre.Value = tipoPago.tipo_pago_nombre;
                sqlCmd.Parameters.Add(P_TipoPagoNombre);

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

        public string Actualizar (DatosTipoPago tipoPago)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spactualizar_tipoPago";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdTipoPago = new SqlParameter();
                P_IdTipoPago.ParameterName = "@ID_TIPO_PAGO";
                P_IdTipoPago.SqlDbType = SqlDbType.Int;
                P_IdTipoPago.Value = tipoPago.Id_tipo_pago;
                sqlCmd.Parameters.Add(P_IdTipoPago);

                SqlParameter P_TipoPagoNombre = new SqlParameter();
                P_TipoPagoNombre.ParameterName = "@TIPO_PAGO_NOMBRE";
                P_TipoPagoNombre.SqlDbType = SqlDbType.VarChar;
                P_TipoPagoNombre.Size = 15;
                P_TipoPagoNombre.Value = tipoPago.Tipo_pago_nombre;
                sqlCmd.Parameters.Add(P_TipoPagoNombre);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ? "Actulizado con Exito" : "Registro no actualizado";
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

        public string Eliminar (DatosTipoPago tipoPago)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "speliminar_tipoPago";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdTipoPago = new SqlParameter();
                P_IdTipoPago.ParameterName = "@ID_TIPO_PAGO";
                P_IdTipoPago.SqlDbType = SqlDbType.Int;
                P_IdTipoPago.Value = tipoPago.Id_tipo_pago;
                sqlCmd.Parameters.Add(P_IdTipoPago);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ? "Eliminado con exito!" : "Registro no eliminado";
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
            DataTable LisRegistros = new DataTable("TIPO_PAGO");

            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spmostrar_tipoPago";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdapeter = new SqlDataAdapter(sqlCmd);
                sqlAdapeter.Fill(LisRegistros);
            }
            catch (Exception e)
            {

                LisRegistros = null;
            }

            return LisRegistros;
        }
    }
}
