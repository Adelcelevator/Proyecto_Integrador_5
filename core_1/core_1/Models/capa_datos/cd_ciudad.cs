using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace core_1.Models.capa_datos
{
    public class cd_ciudad
    {
        cd_conexion conexion = new cd_conexion();
        ob_ciudad obci = new ob_ciudad();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;


        public DataTable todas()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_ciudades";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }


    }
}