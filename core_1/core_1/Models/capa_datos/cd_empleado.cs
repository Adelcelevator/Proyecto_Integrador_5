using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using core_1.Models.capa_datos.objetos;

namespace core_1.Models.capa_datos
{
    public class cd_empleado
    {
        cd_conexion conexion = new cd_conexion();
        public ob_empleado obcli = new ob_empleado();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_empleado()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_empleado";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public Boolean nuevo_emplea(string ci, string nombre, string ape, string naci, string dire, string tele, string cel)
        {
            try
            {
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "crear_editar_empleado";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ci", ci);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@ape", ape);
                comando.Parameters.AddWithValue("@naci", naci);
                comando.Parameters.AddWithValue("@reg", DateTime.Now.ToString());
                comando.Parameters.AddWithValue("@tele", tele);
                comando.Parameters.AddWithValue("@cel", cel);
                comando.Parameters.AddWithValue("@id", 0);
                comando.Parameters.AddWithValue("@dire", dire);
                comando.Parameters.AddWithValue("@est", "Activo");
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}