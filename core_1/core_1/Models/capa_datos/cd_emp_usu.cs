using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace core_1.Models.capa_datos
{
    public class cd_emp_usu
    {
        cd_conexion conexion = new cd_conexion();
        ob_emp_usu emple = new ob_emp_usu();
        List<ob_emp_usu> lista;
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();

        public DataTable todos()
        {
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "mostrar_empleado_us";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
                return tabla;
        }
        public DataTable busque(string ter)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_empleado_x_usu";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", ter);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla;
        }
    }
}