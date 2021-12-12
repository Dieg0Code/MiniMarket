using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class DatosCliente
    {
        private int id_cliente;
        private int id_categoria;
        private string cli_rut;
        private string cli_nombre;
        private string cli_apellido;
        private DateTime cli_fecha_nac;
        private string cli_direccion;
        private string cli_telefono;
        private string cli_correo;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Cli_rut { get => cli_rut; set => cli_rut = value; }
        public string Cli_nombre { get => cli_nombre; set => cli_nombre = value; }
        public string Cli_apellido { get => cli_apellido; set => cli_apellido = value; }
        public DateTime Cli_fecha_nac { get => cli_fecha_nac; set => cli_fecha_nac = value; }
        public string Cli_direccion { get => cli_direccion; set => cli_direccion = value; }
        public string Cli_telefono { get => cli_telefono; set => cli_telefono = value; }
        public string Cli_correo { get => cli_correo; set => cli_correo = value; }

        public DatosCliente()
        {

        }
        public DatosCliente(
            int idCliente, 
            string idCategoira, 
            string cliRut,
            string cliNombre,
            string cliApellido,
            DateTime cliFechaNac,
            string cliDireccion,
            string cliTelefono,
            string cliCorreo
            )
        {
            this.Id_cliente = id_cliente;
            this.Id_categoria = id_categoria;
            this.Cli_rut = cli_rut;
            this.Cli_nombre = cli_nombre;
            this.Cli_apellido = cli_apellido;
            this.Cli_fecha_nac = cli_fecha_nac;
            this.Cli_direccion = cli_direccion;
            this.Cli_telefono = cli_telefono;
            this.Cli_correo = cli_correo;

        }
        string respuesta;

        SqlConnection sqlConexion = new SqlConnection();

        SqlCommand sqlCmd = new SqlCommand();

        public string Guardar(DatosCliente cliente)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spguardar_cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdCliente = new SqlParameter();
                P_IdCliente.ParameterName = "@ID_CLIENTE";
                P_IdCliente.SqlDbType = SqlDbType.Int;
                P_IdCliente.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(P_IdCliente);

                SqlParameter P_IdCiudad = new SqlParameter();
                P_IdCiudad.ParameterName = "ID_CIUDAD";
                P_IdCiudad.SqlDbType = SqlDbType.Int;
                //P_IdCiudad.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(P_IdCiudad);

                SqlParameter P_CliRut = new SqlParameter();
                P_CliRut.ParameterName = "@CLI_RUT";
                P_CliRut.SqlDbType = SqlDbType.VarChar;
                P_CliRut.Size = 10;
                P_CliRut.Value = cliente.Cli_rut;
                sqlCmd.Parameters.Add(P_CliRut);

                SqlParameter P_CliNombre = new SqlParameter();
                P_CliNombre.ParameterName = "@CLI_NOMBRE";
                P_CliNombre.SqlDbType = SqlDbType.VarChar;
                P_CliNombre.Size = 30;
                P_CliNombre.Value = cliente.Cli_nombre;
                sqlCmd.Parameters.Add(P_CliNombre);

                SqlParameter P_CliApellido = new SqlParameter();
                P_CliApellido.ParameterName = "@CLI_APELLIDO";
                P_CliApellido.SqlDbType = SqlDbType.VarChar;
                P_CliApellido.Size = 30;
                P_CliApellido.Value = cliente.Cli_apellido;
                sqlCmd.Parameters.Add(P_CliApellido);

                SqlParameter P_CliFechaNac = new SqlParameter();
                P_CliFechaNac.ParameterName = "@CLI_FECHA_NAC";
                P_CliFechaNac.SqlDbType = SqlDbType.DateTime;
                P_CliFechaNac.Value = cliente.Cli_fecha_nac;
                // hay que arreglar


                SqlParameter P_CliDireccion = new SqlParameter();
                P_CliDireccion.ParameterName = "@CLI_DIRECCION";
                P_CliDireccion.SqlDbType = SqlDbType.VarChar;
                P_CliDireccion.Size = 80;
                P_CliDireccion.Value = cliente.Cli_direccion;
                sqlCmd.Parameters.Add(P_CliDireccion);

                SqlParameter P_CliTelefono = new SqlParameter();
                P_CliTelefono.ParameterName = "@CLI_TELEFONO";
                P_CliTelefono.SqlDbType = SqlDbType.Int;
                P_CliTelefono.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(P_CliTelefono);

                SqlParameter p_cliCorreo = new SqlParameter();
                p_cliCorreo.parameterName = "@CLI_CORREO";
                p_cliCorreo.SqlDbType = SqlDbType = SqlDbType.VarChar;
                p_cliCorreo.Size = 50;
                p_cliCorreo.Value = cliente.Cli_correo;
                sqlCmd.Parameters.Add(p_cliCorreo);

                respuesta = sqlCmd.ExecuteteNonQuery() == 1 ?
                    "Guardado con exito!!":
                    "Registro no guardado";


            }
            catch (Excetion e)
            {

                respuesta = e.Message 
            }
            finally
            {
                if (sqlConexion.state == ConnectionState.Open)
                {
                    sqlConexion.Close();
                }
            }
            return respuesta;

        }

        public string Actualizar (DatosCliente cliente)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spactualizar_cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdCliente = new SqlParameter();
                P_IdCliente.ParameterName = "@ID_CLIENTE";
                P_IdCliente.SqlDbType = SqlDbType.Int;
                P_IdCliente.Direction = ParameterDireccion.Output;
                sqlCmd.Parameters.Add(P_IdCliente);

                SqlParameter P_IdCiudad = new SqlParameter();
                P_IdCiudad.ParameterName = "ID_CIUDAD";
                P_IdCiudad.SqlDbTyper = SqlDbType.Int;
                P_IdCiudad.Direccion = ParameterDirection.Output;
                P_IdCiudad.Parameters.Add(P_IdCiudad);

                sqlParameter P_CliRut = new SqlParameter();
                P_CliRut.ParameterName = "@CLI_RUT";
                P_CliRut.SqlDbType = SqlDbType.VarChar;
                P_CliRut.Size = 10;
                P_CliRut.Value = cliente.Cli_rut;
                sqlCmd.Parameters.Add(P_CliRut);

                sqlParameter P_CliNombre = new SqlParameter();
                P_CliNombre.ParameterName = "@CLI_NOMBRE";
                P_CliNombre.SqlDbType = SqlDbType.VarChar;
                P_CliNombre.Size = 30;
                P_CliNombre.Value = cliente.Cli_nombre;
                sqlCmd.Parameters.Add(P_CliNombre);

                SqlParameter P_CliApellido = new SqlParameter();
                P_CliApellido.ParameterName = "@CLI_APELLIDO";
                P_CliApellido.SqlDbType = SqlDbType.VarChar;
                P_CliApellido.Size = 30;
                P_CliApellido.Value = cliente.Cli_apellido;
                sqlCmd.Parameters.Add(P_CliApellido);

                SqlParameter P_CliFechaNac = new SqlParameter();
                P_CliFechaNac.ParameterName = "@CLI_FECHA_NAC";
                P_CliFechaNac.SqlDbType = SqlDbType.DateTime;
                // hay que arreglar


                SqlParameter P_CliDireccion = new SqlParameter();
                P_CliDireccion.ParameterName = "@CLI_DIRECCION";
                P_CliDireccion.SqlDbType = SqlDbType = SqlDbType.VarChar;
                P_CliDireccion.Size = 80;
                P_CliDireccion.Value = cliente.Cli_direccion;
                sqlCmd.Parameters.Add(P_CliDireccion);

                SqlParameter P_CliTelefono = new SqlParameter();
                P_CliTelefono.ParameterName = "@CLI_TELEFONO";
                P_CliTelefono.SqlDbType = SqlDbType.Int;
                P_CliTelefono.Direccion = ParameterDireccion.Output;
                sqlCmd.Parameters.add(P_CliTelefono);

                SqlParameter p_cliCorreo = new SqlParameter();
                p_cliCorreo.parameterName = "@CLI_CORREO";
                p_cliCorreo.SqlDbType = SqlDbType = SqlDbType.VarChar;
                p_cliCorreo.Size = 50;
                p_cliCorreo.Value = cliente.Cli_correo;
                sqlCmd.Parameters.Add(p_cliCorreo);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ?
                    "Actualizar con exito!!" : "Registro no actualizado";


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

        public string Eliminar(DatosCliente cliente)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "speliminar_cliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                Sqlparameter p_IdCliente = new Sqlparameter();
                p_IdCliente.ParameterName = "@ID_CLIENTE";
                p_IdCliente.SqlDbType = SqlDbType.Int;
                p_IdCliente.Value = cliente.Id_cliente;
                sqlCmd.Parameters.Add(p_IdCliente);

                respuesta = sqlCmd.ExecuteNonQuery() == 1
                    "Eliminado con exito!!": 
                    "Registro no eliminado";

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
            DataTable LisRegistros = new DataTable("CLIENTE");
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "sqmostrar_cliente";
                sqlCmd.commandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                sqlAdapter.fill(LisRegistros);
            }
            catch (Exception e)
            {

                LisRegistros = null;
            }
            return LisRegistros;
        }

    }
}
