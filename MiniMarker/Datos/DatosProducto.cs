using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProducto
    {
        private int id_producto;
        private int id_categoria;
        private string pro_codigo;
        private string pro_nombre;
        private int pro_stock;
        private decimal pro_precio_unitario;

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Pro_codigo { get => pro_codigo; set => pro_codigo = value; }
        public string Pro_nombre { get => pro_nombre; set => pro_nombre = value; }
        public int Pro_stock { get => pro_stock; set => pro_stock = value; }
        public decimal Pro_precio_unitario { get => pro_precio_unitario; set => pro_precio_unitario = value; }

        public DatosProducto()
        {

        }

        public DatosProducto(
            int idProducto,
            int idCategoria,
            string proCodigo,
            string proNombre,
            int proStock,
            decimal proPrecioUnitario
            )
        {
            this.Id_producto = idProducto;
            this.Id_categoria = idCategoria;
            this.Pro_codigo = proCodigo;
            this.Pro_nombre = proNombre;
            this.Pro_stock = proStock;
            this.Pro_precio_unitario = proPrecioUnitario;
        }

        string respuesta;

        SqlConnection sqlConexion = new SqlConnection();

        SqlCommand sqlCmd = new SqlCommand();

        public string Guardar(DatosProducto producto)
        {
            try
            {
                sqlConexion.ConnectionString = Conexion.Conex;
                sqlConexion.Open();
                sqlCmd.Connection = sqlConexion;
                sqlCmd.CommandText = "spguardar_PRODUCTO";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter P_IdProdcuto = new SqlParameter();
                P_IdProdcuto.ParameterName = "@ID_PRODUCTO";
                P_IdProdcuto.SqlDbType = SqlDbType.Int;
                P_IdProdcuto.Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add(P_IdProdcuto);

                SqlParameter P_IdCategoria = new SqlParameter();
                P_IdCategoria.ParameterName = "@ID_CATEGORIA";
                P_IdCategoria.SqlDbType = SqlDbType.Int;
                P_IdCategoria.Value = producto.Id_categoria;
                sqlCmd.Parameters.Add(P_IdCategoria);

                SqlParameter P_ProCodigo = new SqlParameter();
                P_ProCodigo.ParameterName = "@PRO_CODIGO";
                P_ProCodigo.SqlDbType = SqlDbType.VarChar;
                P_ProCodigo.Size = 10;
                P_ProCodigo.Value = producto.Pro_codigo;
                sqlCmd.Parameters.Add(P_ProCodigo);

                SqlParameter P_ProNombre = new SqlParameter();
                P_ProNombre.ParameterName = "@PRO_NOMBRE";
                P_ProNombre.SqlDbType = SqlDbType.VarChar;
                P_ProNombre.Size = 30;
                P_ProNombre.Value = producto.Pro_nombre;
                sqlCmd.Parameters.Add(Pro_nombre);

                SqlParameter P_ProStock = new SqlParameter();
                P_ProStock.ParameterName = "@PRO_STOCK";
                P_ProStock.SqlDbType = SqlDbType.Int;
                P_ProStock.Value = producto.Pro_stock;
                sqlCmd.Parameters.Add(P_ProStock);

                SqlParameter P_ProPrecioUnitario = new SqlParameter();
                P_ProPrecioUnitario.ParameterName = "@PRO_PRECIO_UNITARIO";
                P_ProPrecioUnitario.SqlDbType = SqlDbType.Decimal;
                // Size??
                P_ProPrecioUnitario.Value = producto.Pro_precio_unitario;
                sqlCmd.Parameters.Add(P_ProPrecioUnitario);

                respuesta = sqlCmd.ExecuteNonQuery() == 1 ? "Producto Guardado con Exito" : "Producto NO Guardado";
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
    }
}
