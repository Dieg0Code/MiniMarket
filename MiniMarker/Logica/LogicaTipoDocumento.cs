using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaTipoDocumento
    {
        // Metodo para llamar al procedimiento y agregar una ciudad
        public static string Guardar(string ciunombre)
        {
            DatosTipoDocumento obj_ciudad = new DatosTipoDocumento();
            obj_ciudad.Ciu_nombre = ciunombre;
            return obj_ciudad.Guardar(obj_ciudad);
        }

        // Metodo para llamar al procedimiento y actualizar una ciudad
        public static string Actualizar(int idciudad, string ciunombre)
        {
            DatosCiudad obj_ciudad = new DatosCiudad();
            obj_ciudad.Id_ciudad = idciudad;
            obj_ciudad.Ciu_nombre = ciunombre;
            return obj_ciudad.Actualizar(obj_ciudad);
        }

        // Metodo para llamar al procedimiento y eliminar una ciudad
        public static string Eliminar(int idciudad)
        {
            DatosCiudad obj_ciudad = new DatosCiudad();
            obj_ciudad.Id_ciudad = idciudad;
            return obj_ciudad.Eliminar(obj_ciudad);
        }

        // Metodo para llamar al procedimiento y listar todas las ciudades
        public static DataTable Listar()
        {
            return new DatosCiudad().Listar();
        }
    }
}
