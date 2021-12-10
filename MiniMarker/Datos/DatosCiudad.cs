using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// trabajar tipos de datos de sqlserver
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosCiudad
    {
        private int id_ciudad;
        private string ciu_nombre;

        public int Id_ciudad { get => id_ciudad; set => id_ciudad = value; }
        public string Ciu_nombre { get => ciu_nombre; set => ciu_nombre = value; }

        public DatosCiudad()
        {

        }

        public DatosCiudad(int idciudad, string ciunombre)
        {
            this.Id_ciudad = idciudad;
            this.Ciu_nombre = ciunombre;
        }

        // declaramos una variable vacia de tipo string
        string respuesta;

        // generamos una instacia a la clase sqlconnection para establecer conexiona la BD
        SqlConnection sqlconexion = new SqlConnection();

        // comando para ejecutar sentencias en sqlserver, declaramos una instancia de variable a sqlserver
        SqlCommand sqlcmd = new SqlCommand();

        // Metodo para guardar ciudad
        public string Guardar(DatosCiudad ciudad)
        {
            // generamos un capturador de errores
            try
            {
                // se establece la cadena de conexion con la clase conexion
                sqlconexion.ConnectionString = Conexion.Conex;
                // abrimos la cadena de conexion hacia sqlserver
                sqlconexion.Open();
                // comando para conectar a la BD
                sqlcmd.Connection = sqlconexion;
                // nombre de objeto al que se hara referencia en la BD
                sqlcmd.CommandText = "spguardar_ciudad";
                // hacemos referencia al tipo de objeto 
                sqlcmd.CommandType = CommandType.StoredProcedure;
                
                // declaracion de parametros que recibira el procedimiento almacenado
                SqlParameter P_Idciudad = new SqlParameter();
                // nombre del parametro en el procedimiento
                P_Idciudad.ParameterName = "@ID_CIUDAD";
                // establecer tipo de dato del parametro en el procedimiento
                P_Idciudad.SqlDbType = SqlDbType.Int;
                // idciudad es un parametro de salida
                P_Idciudad.Direction = ParameterDirection.Output;
                // agregamos el primer parametro (idciudad) al comando que se ejecutara en la bd
                sqlcmd.Parameters.Add(P_Idciudad);

                SqlParameter P_Nombre = new SqlParameter();
                P_Nombre.ParameterName = "@CIU_NOMBRE";
                P_Nombre.SqlDbType = SqlDbType.VarChar;
                // tamaño de ciunombre en el procedimiento
                P_Nombre.Size = 50;
                // generamos un envio de valor al parametro que hace referencia a ciunombre en el procedimiento
                P_Nombre.Value = ciudad.Ciu_nombre;
                sqlcmd.Parameters.Add(P_Nombre);

                // ejecucion del comando sqlcmd para enviar la informacion a la bd
                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "Guardado con exito!" :
                    "Registro no guardado";
            }
            catch (Exception e)
            {
                // capturamos el error y lo mostramos como mensaje
                respuesta = e.Message;
            }

            finally
            {
                // cerramos la conexion a la BD
                if (sqlconexion.State == ConnectionState.Open)
                {
                    sqlconexion.Close();
                }
            }

            // retornamos la respuesta
            return respuesta;
            
        }

        // Metodo para actualizar ciudad
        public string Actualizar(DatosCiudad ciudad)
        {
            // generamos un capturador de errores
            try
            {
                // se establece la cadena de conexion con la clase conexion
                sqlconexion.ConnectionString = Conexion.Conex;
                // abrimos la cadena de conexion hacia sqlserver
                sqlconexion.Open();
                // comando para conectar a la BD
                sqlcmd.Connection = sqlconexion;
                // nombre de objeto al que se hara referencia en la BD
                sqlcmd.CommandText = "spactualizar_ciudad";
                // hacemos referencia al tipo de objeto 
                sqlcmd.CommandType = CommandType.StoredProcedure;

                // declaracion de parametros que recibira el procedimiento almacenado
                SqlParameter P_Idciudad = new SqlParameter();
                // nombre del parametro en el procedimiento
                P_Idciudad.ParameterName = "@ID_CIUDAD";
                // establecer tipo de dato del parametro en el procedimiento
                P_Idciudad.SqlDbType = SqlDbType.Int;
                // idciudad es un parametro de salida
                P_Idciudad.Value = ciudad.Id_ciudad;
                // agregamos el primer parametro (idciudad) al comando que se ejecutara en la bd
                sqlcmd.Parameters.Add(P_Idciudad);

                SqlParameter P_Nombre = new SqlParameter();
                P_Nombre.ParameterName = "@CIU_NOMBRE";
                P_Nombre.SqlDbType = SqlDbType.VarChar;
                // tamaño de ciunombre en el procedimiento
                P_Nombre.Size = 50;
                // generamos un envio de valor al parametro que hace referencia a ciunombre en el procedimiento
                P_Nombre.Value = ciudad.Ciu_nombre;
                sqlcmd.Parameters.Add(P_Nombre);

                // ejecucion del comando sqlcmd para enviar la informacion a la bd
                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "Actualizado con exito!" :
                    "Registro no actulizado";
            }
            catch (Exception e)
            {
                // capturamos el error y lo mostramos como mensaje
                respuesta = e.Message;
            }

            finally
            {
                // cerramos la conexion a la BD
                if (sqlconexion.State == ConnectionState.Open)
                {
                    sqlconexion.Close();
                }
            }

            // retornamos la respuesta
            return respuesta;
        }

        // Metodo para eliminar una ciudad
        public string Eliminar(DatosCiudad ciudad)
        {
            // generamos un capturador de errores
            try
            {
                // se establece la cadena de conexion con la clase conexion
                sqlconexion.ConnectionString = Conexion.Conex;
                // abrimos la cadena de conexion hacia sqlserver
                sqlconexion.Open();
                // comando para conectar a la BD
                sqlcmd.Connection = sqlconexion;
                // nombre de objeto al que se hara referencia en la BD
                sqlcmd.CommandText = "speliminar_ciudad";
                // hacemos referencia al tipo de objeto 
                sqlcmd.CommandType = CommandType.StoredProcedure;

                // declaracion de parametros que recibira el procedimiento almacenado
                SqlParameter P_Idciudad = new SqlParameter();
                // nombre del parametro en el procedimiento
                P_Idciudad.ParameterName = "@ID_CIUDAD";
                // establecer tipo de dato del parametro en el procedimiento
                P_Idciudad.SqlDbType = SqlDbType.Int;
                // idciudad es un parametro de salida
                P_Idciudad.Value = ciudad.Id_ciudad;
                // agregamos el primer parametro (idciudad) al comando que se ejecutara en la bd
                sqlcmd.Parameters.Add(P_Idciudad);

                // ejecucion del comando sqlcmd para enviar la informacion a la bd
                respuesta = sqlcmd.ExecuteNonQuery() == 1 ?
                    "Eliminado con exito!" :
                    "Registro no eliminado";
            }
            catch (Exception e)
            {
                // capturamos el error y lo mostramos como mensaje
                respuesta = e.Message;
            }

            finally
            {
                // cerramos la conexion a la BD
                if (sqlconexion.State == ConnectionState.Open)
                {
                    sqlconexion.Close();
                }
            }

            // retornamos la respuesta
            return respuesta;
        }

        // Metodo para listar las ciudades
        public DataTable Listar()
        {
            DataTable LisRegistros = new DataTable("CIUDAD");
            try
            {
                sqlconexion.ConnectionString = Conexion.Conex;
                sqlcmd.Connection = sqlconexion;
                sqlcmd.CommandText = "spmostrar_ciudad";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                // ejecutamos el comando sqlcmd y llenamos el datatable con los registros
                // pasamos el parametro sqlcmd
                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcmd);
                // llenamos el sqladapter con lo que reciba la variable
                sqladapter.Fill(LisRegistros);
            }
            catch (Exception e)
            {
                // si se genera un error, la variable quedara vacia
                LisRegistros = null;
            }

            // retornamos la variable
            return LisRegistros;
        }
    }
}
